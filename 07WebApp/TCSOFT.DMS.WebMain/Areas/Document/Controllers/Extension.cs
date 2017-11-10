using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using TCSOFT.DMS.Document.DTO;
using TCSOFT.DMS.MasterData.DTO;
using TCSOFT.DMS.WebMain.Areas.Document.Models.Model;

namespace TCSOFT.DMS.WebMain.Areas.Document.Controllers
{
    public static class Extension
    {
        public static UserInfoDTO UserInfo(this UserLoginDTO userLoginDTO)
        {

            return new UserInfoDTO
            {
                UserID = 2,
                UserType = 1,
                FullName = "lfl",
                ProductLineIDs = new int[] { }
            };
            //return new UserInfoDTO
            //{
            //    UserID = userLoginDTO.UserID,
            //    UserType = userLoginDTO.UserType,
            //    FullName = userLoginDTO.FullName
            //};
        }

        public static byte[] ToExcel<T>(this List<T> result, List<ExcelHeaderModel> views)
        {
            XSSFWorkbook book = new XSSFWorkbook();
            ISheet sheet = book.CreateSheet();
            var dataStyle = book.CreateCellStyle();
            var headerStyle = book.CreateCellStyle();
            dataStyle.Alignment = headerStyle.Alignment = HorizontalAlignment.Center;
            dataStyle.VerticalAlignment = headerStyle.VerticalAlignment = VerticalAlignment.Center;
            headerStyle.FillPattern = FillPattern.SolidForeground;
            headerStyle.FillForegroundColor = HSSFColor.OliveGreen.Index;
            IFont font = book.CreateFont();
            font.Color = HSSFColor.White.Index;
            headerStyle.SetFont(font);

            // 添加表头               
            IRow titleRow = sheet.CreateRow(0);

            for (int i = 0; i < views.Count; i++)
            {
                var view = views[i];
                ICell cell = titleRow.CreateCell(i, CellType.String);

                cell.CellStyle = headerStyle;
                cell.SetCellValue(view.Header);
                sheet.SetColumnWidth(i, view.Width * 256);
            }
            for (int i = 0; i < result.Count; i++)
            {
                var entity = result[i];
                var row = sheet.CreateRow(i + 1);
                int index = 0;
                foreach (var item in views)
                {
                    var cell = row.CreateCell(index, CellType.String);
                    cell.CellStyle.Alignment = HorizontalAlignment.Center;
                    cell.CellStyle.VerticalAlignment = VerticalAlignment.Center;
                    cell.SetCellValue(entity.GetType().GetProperty(item.PropertyName).GetValue(entity).Show());
                    index++;
                }
            }

            using (MemoryStream ms = new MemoryStream())
            {
                book.Write(ms);
                return ms.ToArray();
            }

        }

        public static string Show(this object me)
        {
            if (me == null) return string.Empty;
            return me.ToString();
        }

        public static bool ToBool(this string s)
        {
            bool v;
            if (bool.TryParse(s, out v))
            {
                return v;
            }
            return false;

        }

        public static bool? TryBool(this string me)
        {
            if (string.IsNullOrEmpty(me)) return null;
            bool value;
            if (bool.TryParse(me, out value))
                return value;
            else
                return null;

        }
    }

}