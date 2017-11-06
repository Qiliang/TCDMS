using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCSOFT.DMS.WebMain.Areas.MasterData.Models.Provider
{
    using TCSOFT.DMS.Common;
    using TCSOFT.DMS.MasterData.DTO.Customer;
    using TCSOFT.DMS.MasterData.DTO.Distributor.Distributor;
    using TCSOFT.DMS.MasterData.DTO.Product.InstrumentType;
    using TCSOFT.DMS.MasterData.DTO.Product.OKCPriceInfo;
    using TCSOFT.DMS.MasterData.DTO.Product.ProductInfo;
    using TCSOFT.DMS.MasterData.DTO.Product.ProductLine;
    using TCSOFT.DMS.MasterData.DTO.Product.ProductModel;
    using TCSOFT.DMS.MasterData.DTO.Product.ProductPriceInfo;
    using TCSOFT.DMS.MasterData.DTO.Product.ProductSmallType;
    using TCSOFT.DMS.MasterData.DTO.Product.ProductType;
    using TCSOFT.DMS.MasterData.DTO.ImportExcel;
    using TCSOFT.DMS.WebMain.Areas.MasterData.Models.Model;
    using TCSOFT.DMS.WebMain.Areas.MasterData.Models.Model.Product;
    using TCSOFT.DMS.WebMain.Common;
    using TCSOFT.DMS.WebMain.Models.Model;
    using TCSOFT.DMS.WebMain.Models.Provider;
    public class ProductManagementProvider : BaseProvider
    {
        /// <summary>
        /// 得到所有产品基本信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static List<ProductInfoBaseDTO> GetProductBaseInfo()
        {
            List<ProductInfoBaseDTO> result = null;

            result = GetAPI<List<ProductInfoBaseDTO>>(WebConfiger.MasterDataServicesUrl + "QueryProductBaseInfo");

            return result;
        }
        #region 产品线
        /// <summary>
        /// 得到所有产品线信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static List<ProductLineResultModel> GetProductLine(ProductLineSearchDTO dto)
        {
            List<ProductLineResultModel> result = null;

            result = GetAPI<List<ProductLineResultModel>>(WebConfiger.MasterDataServicesUrl + "ProductLine?ProductLineSearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return result;
        }
        /// <summary>
        /// 得到所有产品线基本信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static List<ProductLineBaseDTO> GetProductLineBaseInfo()
        {
            List<ProductLineBaseDTO> result = null;

            result = GetAPI<List<ProductLineBaseDTO>>(WebConfiger.MasterDataServicesUrl + "QueryProductLineBaseInfo");

            return result;
        }
        /// <summary>
        /// 得到一条产品线信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static ResultData<ProductLineResultDTO> GetOneProductLine(int id)
        {
            ResultData<ProductLineResultDTO> result = null;

            result = GetAPI<ResultData<ProductLineResultDTO>>(WebConfiger.MasterDataServicesUrl + "ProductLine?id=" + id);

            return result;
        }
        /// <summary>
        /// 产品线新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> AddProductLine(ProductLineOperateDTO dto)
        {
            ResultData<object> result = null;

            result = PostAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "ProductLine",dto);

            return result;
        }
        /// <summary>
        /// 产品线修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> UpdateProductLine(ProductLineOperateDTO dto)
        {
            ResultData<object> result = null;

            result = PutAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "ProductLine", dto);

            return result;
        }
        /// <summary>
        /// 产品线删除
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> DeleteProductLine(ProductLineOperateDTO dto)
        {
            ResultData<object> blResult = DeleteAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "ProductLine?ProductLineOperateDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return blResult;
        }
        #endregion

        #region 仪器类型
        /// <summary>
        /// 得到仪器类型
        /// </summary>
        /// <returns></returns>
        public static List<InstrumentTypeResultDTO> GetInstrumentTypeList()
        {
            List<InstrumentTypeResultDTO> result = null;

            result = GetAPI<List<InstrumentTypeResultDTO>>(WebConfiger.MasterDataServicesUrl + "InstrumentType");

            return result;
        }
        /// <summary>
        /// 得到一条仪器类型
        /// </summary>
        /// <returns></returns>
        public static ResultData<InstrumentTypeResultDTO> GetInstrumentType(int id)
        {
            ResultData<InstrumentTypeResultDTO> result = null;

            result = GetAPI<ResultData<InstrumentTypeResultDTO>>(WebConfiger.MasterDataServicesUrl + "InstrumentType?id=" + id);

            return result;
        }
        /// <summary>
        /// 新增仪器类型
        /// </summary>
        /// <returns></returns>
        public static ResultData<object> AddInstrumentType(InstrumentTypeOperateDTO dto)
        {
            ResultData<object> result = null;

            result = PostAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "InstrumentType", dto);

            return result;
        }
        /// <summary>
        /// 修改仪器类型
        /// </summary>
        /// <returns></returns>
        public static ResultData<object> UpdateInstrumentType(InstrumentTypeOperateDTO dto)
        {
            ResultData<object> result = null;

            result = PutAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "InstrumentType", dto);

            return result;
        }
        /// <summary>
        /// 删除仪器类型
        /// </summary>
        /// <returns></returns>
        public static ResultData<object> DeleteInstrumentType(InstrumentTypeSearchDTO dto)
        {
            ResultData<object> blResult = DeleteAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "InstrumentType?InstrumentTypeSearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return blResult;
        }
        #endregion

        #region 产品型号(仪器型号)
        /// <summary>
        /// 得到所有产品型号信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static List<ProductModelResultModel> GetProductModel(ProductModelSearchDTO dto)
        {
            List<ProductModelResultModel> result = null;

            result = GetAPI<List<ProductModelResultModel>>(WebConfiger.MasterDataServicesUrl + "ProductModel?ProductModelSearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return result;
        }
        /// <summary>
        /// 得到一条产品型号信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static ResultData<ProductModelResultModel> GetOneProductModel(int id)
        {
            ResultData<ProductModelResultModel> result = null;

            result = GetAPI<ResultData<ProductModelResultModel>>(WebConfiger.MasterDataServicesUrl + "ProductModel?id=" + id);

            return result;
        }
        /// <summary>
        /// 产品型号新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> AddProductModel(ProductModelOperateDTO dto)
        {
            ResultData<object> result = null;

            result = PostAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "ProductModel", dto);

            return result;
        }
        /// <summary>
        /// 产品型号修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> UpdateProductModel(ProductModelOperateDTO dto)
        {
            ResultData<object> result = null;

            result = PutAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "ProductModel", dto);

            return result;
        }
        /// <summary>
        /// 产品型号删除
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> DeleteProductModel(ProductModelOperateDTO dto)
        {
            ResultData<object> blResult = DeleteAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "ProductModel?ProductModelOperateDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return blResult;
        }
        /// <summary>
        /// 导入产品型号
        /// </summary>
        /// <param name="regentprdlist"></param>
        /// <returns></returns>
        public static ResultData<object> ImportProductModel(List<ExcelInstrumentModelDTO> implist)
        {
            return PostAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "ImportData", new { Data = TransformHelper.ConvertDTOTOBase64JsonString(implist), Type = 12 });
        }
        #endregion

        #region 产品小类
        /// <summary>
        /// 得到所有产品小类信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static List<ProductSmallTypeResultModel> GetProductSmallType(ProductSmallTypeSearchDTO dto)
        {
            List<ProductSmallTypeResultModel> result = null;

            result = GetAPI<List<ProductSmallTypeResultModel>>(WebConfiger.MasterDataServicesUrl + "ProductSmallType?ProductSmallTypeSearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return result;
        }
        /// <summary>
        /// 得到所有产品小类基本信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static List<ProductSmallTypeBaseDTO> GetProductSmallTypeBaseInfo()
        {
            List<ProductSmallTypeBaseDTO> result = null;

            result = GetAPI<List<ProductSmallTypeBaseDTO>>(WebConfiger.MasterDataServicesUrl + "QueryProductSmallTypeBaseInfo");

            return result;
        }
        /// <summary>
        /// 得到一条产品小类信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static ResultData<ProductSmallTypeResultModel> GetOneProductSmallType(int id)
        {
            ResultData<ProductSmallTypeResultModel> result = null;

            result = GetAPI<ResultData<ProductSmallTypeResultModel>>(WebConfiger.MasterDataServicesUrl + "ProductSmallType?id=" + id);

            return result;
        }
        /// <summary>
        /// 产品小类新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> AddProductSmallType(ProductSmallTypeOperateDTO dto)
        {
            ResultData<object> result = null;

            result = PostAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "ProductSmallType", dto);

            return result;
        }
        /// <summary>
        /// 产品小类修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> UpdateProductSmallType(ProductSmallTypeOperateDTO dto)
        {
            ResultData<object> result = null;

            result = PutAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "ProductSmallType", dto);

            return result;
        }
        /// <summary>
        /// 产品小类删除
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> DeleteProductSmallType(ProductSmallTypeOperateDTO dto)
        {
            ResultData<object> blResult = DeleteAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "ProductSmallType?ProductSmallTypeOperateDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return blResult;
        }
        /// <summary>
        /// 导入产品小类
        /// </summary>
        /// <param name="regentprdlist"></param>
        /// <returns></returns>
        public static ResultData<object>ImportProductSmallType(List<ExcelProductSmallClassDTO> implist)
        {
            return PostAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "ImportData", new { Data = TransformHelper.ConvertDTOTOBase64JsonString(implist), Type = 11 });
        }
        #endregion

        #region 产品类型
        /// <summary>
        /// 得到产品类型
        /// </summary>
        /// <returns></returns>
        public static List<ProductTypeResultDTO> GetProductTypeList(ProductTypeSearchDTO dto)
        {
            List<ProductTypeResultDTO> result = null;

            result = GetAPI<List<ProductTypeResultDTO>>(WebConfiger.MasterDataServicesUrl + "ProductType?ProductTypeSearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return result;
        }
        /// <summary>
        /// 得到所有产品类型基本信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static List<ProductTypeBaseDTO> GetProductTypeBaseInfo()
        {
            List<ProductTypeBaseDTO> result = null;

            result = GetAPI<List<ProductTypeBaseDTO>>(WebConfiger.MasterDataServicesUrl + "QueryProductTypeBaseInfo");

            return result;
        }
        /// <summary>
        /// 得到一条产品类型
        /// </summary>
        /// <returns></returns>
        public static ResultData<ProductTypeResultDTO> GetProductType(int id)
        {
            ResultData<ProductTypeResultDTO> result = null;

            result = GetAPI<ResultData<ProductTypeResultDTO>>(WebConfiger.MasterDataServicesUrl + "ProductType?id=" + id);

            return result;
        }
        /// <summary>
        /// 新增产品类型
        /// </summary>
        /// <returns></returns>
        public static ResultData<object> AddProductType(ProductTypeOperateDTO dto)
        {
            ResultData<object> result = null;

            result = PostAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "ProductType", dto);

            return result;
        }
        /// <summary>
        /// 修改产品类型
        /// </summary>
        /// <returns></returns>
        public static ResultData<object> UpdateProductType(ProductTypeOperateDTO dto)
        {
            ResultData<object> result = null;

            result = PutAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "ProductType", dto);

            return result;
        }
        /// <summary>
        /// 删除产品类型
        /// </summary>
        /// <returns></returns>
        public static ResultData<object> DeleteProductType(ProductTypeSearchDTO dto)
        {
            ResultData<object> blResult = DeleteAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "ProductType?ProductTypeSearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return blResult;
        }
        #endregion

        #region 试剂产品清单
        /// <summary>
        /// 得到试剂产品清单信息
        /// </summary>
        /// <returns></returns>
        public static ResultData<List<ProductInfoModel>> GetReagentInfo(ProductInfoSearchDTO dto)
        {
            ResultData<List<ProductInfoModel>> result = null;

            result = GetAPI<ResultData<List<ProductInfoModel>>>(WebConfiger.MasterDataServicesUrl + "ReagentInfo?ProductInfoSearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return result;
        }
        /// <summary>
        /// 得到一条试剂产品清单信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<ProductInfoModel> GetOneReagentInfo(ProductInfoSearchDTO dto)
        {
            ResultData<ProductInfoModel> result = new ResultData<ProductInfoModel>(); ;

            var pp = GetAPI<ResultData<List<ProductInfoModel>>>(WebConfiger.MasterDataServicesUrl + "ReagentInfo?ProductInfoSearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));
            if (pp.Object != null && pp.Object.Count > 0)
            {
                result.Object = pp.Object.First();
                result.SubmitResult = true;
            }
            else
            {
                result.Message = "此条信息不存在！";
                result.SubmitResult = false;
            }

            return result;
        }
        /// <summary>
        /// 新增试剂产品
        /// </summary>
        /// <returns></returns>
        public static ResultData<object> AddReagentInfo(ProductInfoOperateDTO dto)
        {
            ResultData<object> result = null;

            result = PostAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "ReagentInfo", dto);

            return result;
        }
        /// <summary>
        /// 修改试剂产品
        /// </summary>
        /// <returns></returns>
        public static ResultData<object> UpdateReagentInfo(ProductInfoOperateDTO dto)
        {
            ResultData<object> result = null;

            result = PutAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "ReagentInfo", dto);

            return result;
        }
        /// <summary>
        /// 删除试剂产品
        /// </summary>
        /// <returns></returns>
        public static ResultData<object> DeleteReagentInfo(ProductInfoOperateDTO dto)
        {
            ResultData<object> result = null;

            result = DeleteAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "ReagentInfo?ProductInfoOperateDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return result;
        }
        /// <summary>
        /// 停启用试剂产品
        /// </summary>
        /// <returns></returns>
        public static ResultData<object> StartOrStopReagentInfo(ProductInfoOperateDTO dto)
        {
            ResultData<object> result = null;

            result = PutAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "ReagentInfo", dto);

            return result;
        }
        /// <summary>
        /// 导入试剂产品清单
        /// </summary>
        /// <param name="regentprdlist"></param>
        /// <returns></returns>
        public static ResultData<object>ImportReagentProduct(List<ExcelReagentProductDTO> regentprdlist)
        {
            return PostAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "ImportData", new { Data = TransformHelper.ConvertDTOTOBase64JsonString(regentprdlist), Type = 1 });
        }
        #endregion

        #region 试剂产品价格
        /// <summary>
        /// 得到试剂产品价格信息
        /// </summary>
        /// <returns></returns>
        public static ResultData<List<ProductPriceModel>> GetReagentPriceList(ProductPriceInfoSearchDTO dto)
        {
            ResultData<List<ProductPriceModel>> result = null;

            result = GetAPI<ResultData<List<ProductPriceModel>>>(WebConfiger.MasterDataServicesUrl + "ReagentPrice?ProductPriceInfoSearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));
            int i = 1;
            foreach (var a in result.Object)
            {
                a.Index = i;
                i++;
            }
            return result;
        }
        /// <summary>
        /// 修改试剂产品价格
        /// </summary>
        /// <returns></returns>
        public static ResultData<object> UpdateReagentPrice(ProductPriceInfoOperateDTO dto)
        {
            ResultData<object> result = null;

            result = PutAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "ReagentPrice", dto);

            return result;
        }
        /// <summary>
        /// 删除试剂产品价格
        /// </summary>
        /// <returns></returns>
        public static ResultData<object> DeleteReagentPrice(ProductPriceInfoOperateDTO dto)
        {
            ResultData<object> result = null;

            result = DeleteAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "ReagentPrice?ProductPriceInfoOperateDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return result;
        }
        /// 导入试剂产品价格
        /// </summary>
        /// <param name="regentprdlist"></param>
        /// <returns></returns>
        public static ResultData<object> ImportReagentPrice(List<ExcelReagentPriceDTO> regentprdlist)
        {
            return PostAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "ImportData", new { Data = TransformHelper.ConvertDTOTOBase64JsonString(regentprdlist), Type = 3 });
        }
        #endregion
        
        #region OKC价格（产品特价）
        /// <summary>
        /// 得到OKC信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<List<OKCPriceInfoResultDTO>> GetOKCList(OKCPriceInfoSearchDTO dto)
        {
            ResultData<List<OKCPriceInfoResultDTO>> result = new ResultData<List<OKCPriceInfoResultDTO>>();

            result = GetAPI<ResultData<List<OKCPriceInfoResultDTO>>>(WebConfiger.MasterDataServicesUrl + "OKCInfo?OKCPriceInfoSearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return result;
        }
        /// <summary>
        /// 得到一条OKC信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<OKCPriceInfoResultDTO> GetOneOKC(OKCPriceInfoSearchDTO dto)
        {
            ResultData<OKCPriceInfoResultDTO> result = new ResultData<OKCPriceInfoResultDTO>();

            var pp = GetAPI<ResultData<List<OKCPriceInfoResultDTO>>>(WebConfiger.MasterDataServicesUrl + "OKCInfo?OKCPriceInfoSearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));
            if (pp.Object != null && pp.Object.Count > 0)
            {
                result.Object = pp.Object.First();
                result.SubmitResult = true;
            }
            else
            {
                result.Message = "此条信息不存在！";
                result.SubmitResult = false;
            }

            return result;
        }
        /// <summary>
        /// 查询okc中的产品
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<List<OKCProductResult>> GetOKCProduct(OKCPriceInfoSearchDTO dto)
        {
            ResultData<List<OKCProductResult>> result = new ResultData<List<OKCProductResult>>();

            result = GetAPI<ResultData<List<OKCProductResult>>>(WebConfiger.MasterDataServicesUrl + "OKCPriceInfo?OKCPriceInfoSearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return result;
        }
        /// <summary>
        /// 查询okc中的经销商
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<List<OKCDistributorResult>> GetOKCDistributor(OKCPriceInfoSearchDTO dto)
        {
            ResultData<List<OKCDistributorResult>> result = new ResultData<List<OKCDistributorResult>>();

            result = GetAPI<ResultData<List<OKCDistributorResult>>>(WebConfiger.MasterDataServicesUrl + "OKCDistributor?OKCPriceInfoSearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return result;
        }
        /// <summary>
        /// 新增OKC
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> AddOKC(OKCPriceInfoOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();

            result = PostAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "OKCInfo", dto);

            return result;
        }
        /// <summary>
        /// 新增OKC产品特价
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> AddOKCProduct(OKCPriceInfoModel dto)
        {
            ResultData<object> result = new ResultData<object>();
            OKCPriceInfoOperateDTO okcdto = dto;
            okcdto.ProductOKC = new List<OKCProductOperate>();
            OKCProductOperate okcpro = new OKCProductOperate();
            okcdto.ProductOKC.Add(okcpro);
            okcpro.ProductID = dto.ProductID;
            okcpro.ProductOKCPrice = dto.ProductOKCPrice;

            result = PostAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "OKCInfo", okcdto);

            return result;
        }
        /// <summary>
        /// 新增OKC经销商及最终客户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> AddOKCDepAndCus(OKCPriceInfoModel dto)
        {
            ResultData<object> result = new ResultData<object>();
            OKCPriceInfoOperateDTO okcdto = dto;
            okcdto.DistributorOKC = new List<OKCDistributorOperate>();
            OKCDistributorOperate okcdep = new OKCDistributorOperate();
            okcdto.DistributorOKC.Add(okcdep);
            okcdep.DistributorID = dto.DistributorID;
            okcdep.CustomerID = dto.CustomerID;

            result = PostAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "OKCInfo", okcdto);

            return result;
        }
        /// <summary>
        /// 修改OKC号
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> UpdateOKC(OKCPriceInfoOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();

            result = PutAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "OKCInfo", dto);

            return result;
        }
        /// <summary>
        /// 删除OKC
        /// </summary>
        /// <returns></returns>
        public static ResultData<object> DeleteOKC(OKCPriceInfoOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();

            result = DeleteAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "OKCInfo?OKCPriceInfoOperateDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return result;
        }
        /// <summary>
        /// 得到试剂产品清单信息
        /// </summary>
        /// <returns></returns>
        public static ResultData<List<ProductInfoModel>> GetIsActiveReagentInfo(ProductInfoSearchDTO dto)
        {
            ResultData<List<ProductInfoModel>> result = null;

            result = GetAPI<ResultData<List<ProductInfoModel>>>(WebConfiger.MasterDataServicesUrl + "ReagentInfo?ProductInfoSearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return result;
        }
        /// <summary>
        /// 得到经销商信息
        /// </summary>
        /// <returns></returns>
        public static ResultData<List<DistributorResultDTO>> GetDistributorList(DistributorSearchDTO dto)
        {
            ResultData<List<DistributorResultDTO>> result = null;

            result = GetAPI<ResultData<List<DistributorResultDTO>>>(WebConfiger.MasterDataServicesUrl + "DistributorManagerment?DistributorSearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return result;
        }
        /// <summary>
        /// 得到启用的客户信息
        /// </summary>
        /// <returns></returns>
        public static ResultData<List<CustomerInfoModel>> GetIsActiveCustomerList(CustomerSearchDTO dto)
        {
            ResultData<List<CustomerInfoModel>> result = null;

            result = GetAPI<ResultData<List<CustomerInfoModel>>>(WebConfiger.MasterDataServicesUrl + "CustomerInfo?CustomerSearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return result;
        }
        /// <summary>
        /// 导入试剂产品特价
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> ImportReagentSpecial(List<ExcelProductSpecialDTO> dto)
        {
            return PostAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "ImportData", new { Data = TransformHelper.ConvertDTOTOBase64JsonString(dto), Type = 4 });
        }
        #endregion

        #region 维修产品清单
        /// <summary>
        /// 得到维修产品清单
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<List<ProductInfoModel>> GetMaintenanceInfoList(ProductInfoSearchDTO dto)
        {
            ResultData<List<ProductInfoModel>> result = null;

            result = GetAPI<ResultData<List<ProductInfoModel>>>(WebConfiger.MasterDataServicesUrl + "MaintenanceInfo?ProductInfoSearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return result;
        }
        /// <summary>
        /// 得到一条维修产品信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static ResultData<ProductInfoModel> GetMaintenanceInfo(ProductInfoSearchDTO dto)
        {
            ResultData<ProductInfoModel> result = new ResultData<ProductInfoModel>();

            var resultlist = GetAPI<ResultData<List<ProductInfoModel>>>(WebConfiger.MasterDataServicesUrl + "MaintenanceInfo?ProductInfoSearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));
            if (resultlist.Object!=null &&resultlist.Object.Count > 0)
            {
                result.Object = resultlist.Object.First();
                result.SubmitResult = true;
            }
            else
            {
                result.Message = "此条信息不存在！";
            }

            return result;
        }
        /// <summary>
        /// 维修产品新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> AddMaintenanceInfo(ProductInfoOperateDTO dto)
        {
            ResultData<object> result = null;

            result = PostAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "MaintenanceInfo", dto);

            return result;
        }
        /// <summary>
        /// 维修产品修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> UpdateMaintenanceInfo(ProductInfoOperateDTO dto)
        {
            ResultData<object> result = null;

            result = PutAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "MaintenanceInfo", dto);

            return result;
        }
        /// <summary>
        /// 维修产品停启用
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> ChangeStatusMaintenanceInfo(ProductInfoOperateDTO dto)
        {
            ResultData<object> result = null;

            result = PutAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "MaintenanceInfo", dto);

            return result;
        }
        /// <summary>
        /// 维修产品删除
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> DeleteMaintenanceInfo(ProductInfoOperateDTO dto)
        {
            ResultData<object> blResult = DeleteAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "MaintenanceInfo?ProductInfoOperateDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return blResult;
        }
        /// <summary>
        /// 导入维修产品清单
        /// </summary>
        /// <param name="regentprdlist"></param>
        /// <returns></returns>
        public static ResultData<object> ImportRepairProduct(List<ExcelRepairProductDTO> Repairprdlist)
        {
            return PostAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "ImportData", new { Data = TransformHelper.ConvertDTOTOBase64JsonString(Repairprdlist), Type = 2 });
        }
        #endregion

        #region 维修产品价格
        /// <summary>
        /// 得到维修产品清单
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<List<ProductPriceModel>> GetMaintenancePriceList(ProductPriceInfoSearchDTO dto)
        {
            ResultData<List<ProductPriceModel>> result = null;

            result = GetAPI<ResultData<List<ProductPriceModel>>>(WebConfiger.MasterDataServicesUrl + "MaintenancePrice?ProductPriceInfoSearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));
            int i = 1;
            foreach (var a in result.Object)
            {
                a.Index = i;
                i++;
            }

            return result;
        }
        /// <summary>
        /// 得到一条维修产品信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static ResultData<ProductPriceModel> GetMaintenancePrice(ProductPriceInfoSearchDTO dto)
        {
            ResultData<ProductPriceModel> result = new ResultData<ProductPriceModel>();

            var resultlist = GetAPI<List<ProductPriceModel>>(WebConfiger.MasterDataServicesUrl + "MaintenancePrice?ProductPriceInfoSearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));
            if (resultlist.Count > 0)
            {
                result.Object = resultlist.First();
                result.SubmitResult = true;
            }
            else
            {
                result.Message = "此条信息不存在！";
            }

            return result;
        }
        /// <summary>
        /// 维修产品修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> UpdateMaintenancePrice(ProductPriceInfoOperateDTO dto)
        {
            ResultData<object> result = null;

            result = PutAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "MaintenancePrice", dto);

            return result;
        }
        /// <summary>
        /// 维修产品删除
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> DeleteMaintenancePrice(ProductPriceInfoOperateDTO dto)
        {
            ResultData<object> blResult = DeleteAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "MaintenancePrice?ProductPriceInfoOperateDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return blResult;
        }
        /// <summary>
        /// 导入维修产品价格
        /// </summary>
        /// <param name="regentprdlist"></param>
        /// <returns></returns>
        public static ResultData<object> ImportRepairPrice(List<ExcelRepairPriceDTO> implist)
        {
            return PostAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "ImportData", new { Data = TransformHelper.ConvertDTOTOBase64JsonString(implist), Type = 5 });
        }
        #endregion
    }
}