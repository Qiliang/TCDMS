using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace TCSOFT.DMS.MasterDataAPI.Controllers
{
    using DMS.MasterData.DTO.ImportExcel;
    using Newtonsoft.Json;
    using TCSOFT.DMS.Common;
    using TCSOFT.DMS.MasterData.DTO.Common;
    using TCSOFT.DMS.MasterData.IServices;
    using TCSOFT.DMS.MasterData.Services;
    /// <summary>
    /// 导入数据服务
    /// </summary>
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
            /// 1、试剂产品清单
            /// 2、维修产品清单
            /// 3、试剂产品价格
            /// 4、试剂产品特价
            /// 5、维修产品价格
            /// 6、经销商信息管理
            /// 7、经销商授权
            /// 8、经销商公告授权
            /// 9、关账日
            /// 10、客户信息
            /// 11、产品小类
            /// 12、产品型号
            /// 13、用户管理
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
                case 1: // 试剂产品清单
                    impdtolst = TransformHelper.ConvertBase64JsonStringToDTO<List<ExcelReagentProductDTO>>(idb.Data).ConvertAll<ExcelImportDataDTO>(g =>
                    {
                        return g as ExcelImportDataDTO;
                    });
                    idservices = (IImportDataServices)(new ProductServices());
                    break;
                case 2:
                    impdtolst = TransformHelper.ConvertBase64JsonStringToDTO<List<ExcelRepairProductDTO>>(idb.Data).ConvertAll<ExcelImportDataDTO>(g =>
                    {
                        return g as ExcelImportDataDTO;
                    });
                    idservices = (IImportDataServices)(new ProductServices());
                    break;
                case 3:
                    impdtolst = TransformHelper.ConvertBase64JsonStringToDTO<List<ExcelReagentPriceDTO>>(idb.Data).ConvertAll<ExcelImportDataDTO>(g =>
                    {
                        return g as ExcelImportDataDTO;
                    });
                    idservices = (IImportDataServices)(new ProductServices());
                    break;
                case 4: //试剂产品特价
                    impdtolst = TransformHelper.ConvertBase64JsonStringToDTO<List<ExcelProductSpecialDTO>>(idb.Data).ConvertAll<ExcelImportDataDTO>(g =>
                    {
                        return g as ExcelImportDataDTO;
                    });
                    idservices = (IImportDataServices)(new ProductServices());
                    break;
                case 5: //维修产品价格
                    impdtolst = TransformHelper.ConvertBase64JsonStringToDTO<List<ExcelRepairPriceDTO>>(idb.Data).ConvertAll<ExcelImportDataDTO>(g =>
                    {
                        return g as ExcelImportDataDTO;
                    });
                    idservices = (IImportDataServices)(new ProductServices());
                    break;
                case 6: //经销商信息
                    impdtolst = TransformHelper.ConvertBase64JsonStringToDTO<List<ExcelDistributorDTO>>(idb.Data).ConvertAll<ExcelImportDataDTO>(g =>
                    {
                        return g as ExcelImportDataDTO;
                    });
                    idservices = (IImportDataServices)(new DistributorServices());
                    break;
                case 7: //经销商授权
                    impdtolst = TransformHelper.ConvertBase64JsonStringToDTO<List<ExcelDistributorAuthorityDTO>>(idb.Data).ConvertAll<ExcelImportDataDTO>(g =>
                    {
                        return g as ExcelImportDataDTO;
                    });
                    idservices = (IImportDataServices)(new DistributorServices());
                    break;
                case 8:
                    impdtolst = TransformHelper.ConvertBase64JsonStringToDTO<List<ExcelDistributorADAuthorityDTO>>(idb.Data).ConvertAll<ExcelImportDataDTO>(g =>
                    {
                        return g as ExcelImportDataDTO;
                    });
                    idservices = (IImportDataServices)(new DistributorServices());
                    break;
                case 9:
                    impdtolst = TransformHelper.ConvertBase64JsonStringToDTO<List<ExclCloseDataDTO>>(idb.Data).ConvertAll<ExcelImportDataDTO>(g =>
                    {
                        return g as ExcelImportDataDTO;
                    });
                    idservices = (IImportDataServices)(new BaseInfoServices());
                    break;
                case 10:
                    impdtolst = TransformHelper.ConvertBase64JsonStringToDTO<List<ExcelCustomerInfoDTO>>(idb.Data).ConvertAll<ExcelImportDataDTO>(g =>
                    {
                        return g as ExcelImportDataDTO;
                    });
                    idservices = (IImportDataServices)(new CustomerServices());
                    break;
                case 11:
                    impdtolst = TransformHelper.ConvertBase64JsonStringToDTO<List<ExcelProductSmallClassDTO>>(idb.Data).ConvertAll<ExcelImportDataDTO>(g =>
                    {
                        return g as ExcelImportDataDTO;
                    });
                    idservices = (IImportDataServices)(new ProductServices());
                    break;
                case 12:
                    impdtolst = TransformHelper.ConvertBase64JsonStringToDTO<List<ExcelInstrumentModelDTO>>(idb.Data).ConvertAll<ExcelImportDataDTO>(g =>
                    {
                        return g as ExcelImportDataDTO;
                    });
                    idservices = (IImportDataServices)(new ProductServices());
                    break;
                case 13://用户信息
                    impdtolst = TransformHelper.ConvertBase64JsonStringToDTO<List<ExcelUser>>(idb.Data).ConvertAll<ExcelImportDataDTO>(g =>
                    {
                        return g as ExcelImportDataDTO;
                    });
                    idservices = (IImportDataServices)(new UserAuthorityServices());
                    break;
            }

            try
            {
                //判断是否返回的是真假，如果为假，则跳转chtch
                resultdto.SubmitResult = idservices.ImportData(impdtolst);
            }
            catch(Exception ex)
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