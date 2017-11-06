using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TCSOFT.DMS.Common;
using TCSOFT.DMS.UserApply.DTO.Common;
using TCSOFT.DMS.UserApply.DTO.ImportExcel;
using TCSOFT.DMS.UserApply.IServices;
using TCSOFT.DMS.UserApply.Services;

namespace TCSOFT.DMS.UserApplyAPI.Controllers
{
    public class ImportDataController : ApiController
    {
        /// <summary>
        /// 导入数据实体
        /// </summary>
        public class ImportDataBody
        {
            /// <summary>
            /// 导入数据
            /// </summary>
            public string Data { get; set; }
            /// <summary>
            /// 导入类型
            /// 1、用户申请
            /// </summary>
            public short Type { get; set; }
        }

        /// <summary>
        /// 导入数据
        /// </summary>
        /// <param name="idb"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage ImportData(ImportDataBody idb)
        {
            List<ExcelImportDataDTO> impdtolst = null;
            ResultDTO<object> resultdto = new ResultDTO<object>();
            IImportDataServices idservices = null;
            switch (idb.Type)
            {
                 case 1: // 
                    impdtolst = TransformHelper.ConvertBase64JsonStringToDTO<List<ExcelBatch>>(idb.Data).ConvertAll<ExcelImportDataDTO>(g =>
                    {
                        return g as ExcelImportDataDTO;
                    });
                    idservices = (IImportDataServices)(new UserApplyServices());
                    break;
            }

            try
            {
                //判断是否返回的是真假，如果为假，则跳转chtch
                resultdto.SubmitResult = idservices.ImportData(impdtolst);
            }
            catch (Exception ex)
            {
                resultdto.Message = ex.Message;
                resultdto.SubmitResult = false;
            }

            HttpResponseMessage result = new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(resultdto),
                    System.Text.Encoding.GetEncoding("UTF-8"),
                    "application/json")
            };

            return result;
        }
    }
}
