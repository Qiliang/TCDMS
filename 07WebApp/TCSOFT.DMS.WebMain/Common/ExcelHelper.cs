using Npoi.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace TCSOFT.DMS.WebMain.Common
{
    public delegate bool CheckInfo(object obj);
    public class ExcelHelper
    {
        /// <summary>
        /// 导出EXCEL
        /// </summary>
        /// <param name="strTempLateFile">模板文件</param>
        /// <param name="strGenarateDir">生成文件目录</param>
        /// <param name="strGenarateFileName">生成文件名</param>
        /// <param name="data">生成文件数据</param>
        /// <param name="SheetName"></param>
        /// <returns></returns>
        public static bool Export(string strTempLateFile, string strGenarateDir, string strGenarateFileName, List<object> data, string SheetName)
        {
            bool blResult = false;
            try
            {
                if (!Directory.Exists(strGenarateDir))
                {
                    Directory.CreateDirectory(strGenarateDir);
                }
                string strGenarateFile = strGenarateDir + "\\" + strGenarateFileName;
                File.Copy(strTempLateFile, strGenarateFile, true);
                var mapper = new Mapper(strGenarateFile);
                mapper.Put(data, SheetName, false);
                mapper.Save(strGenarateFile);

                blResult = true;
            }
            catch (Exception ex)
            {
                blResult = false;
                Logger.WriteLog(ex.Message);
            }

            return blResult;
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sm"></param>
        /// <param name="SheetName"></param>
        /// <returns></returns>
        public static List<T> Import<T>(Stream sm, string SheetName,List<string[]> arrmapperlst,CheckInfo chckinfo=null,string strErrorPath=null) where T:class
        {
            List<T> result = new List<T>();
            var importer = new Mapper(sm);
            var sheets = importer.Workbook.GetSheet(SheetName);
            var col = sheets.GetRow(0);
            col.CreateCell(col.Count()).SetCellValue("检测情况");

            foreach (string[] arrstr in arrmapperlst)
            {
                importer.Map<T>(arrstr[0], arrstr[1]);
            }

            var items = importer.Take<T>(SheetName).ToList();
            items.ForEach(g =>
            {
                result.Add(g.Value);
            });

            if (chckinfo != null && !chckinfo(result))
            {
                importer.Put<T>(result, SheetName);
                importer.Save(strErrorPath);

                return null;
            }

            return result;
        }
    }
}