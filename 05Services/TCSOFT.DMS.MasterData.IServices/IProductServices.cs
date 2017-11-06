using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TCSOFT.DMS.MasterData.IServices
{
    using DTO.Product.ProductSmallType;
    using DTO.Product.ProductLine;
    using DTO.Product.ProductType;
    using DTO.Product.InstrumentType;
    using DTO.Product.ReagentInfo;
    using DTO.Product.ProductPriceInfo;
    using TCSOFT.DMS.MasterData.DTO.Product.OKCPriceInfo;
    using TCSOFT.DMS.MasterData.DTO.Product.ProductModel;
    using TCSOFT.DMS.MasterData.DTO.Product.ProductInfo;
    public interface IProductServices
    {
        #region 产品线
        /// <summary>
        /// 得到所有产品线信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        List<ProductLineResultDTO> GetProductLine(ProductLineSearchDTO dto);
        /// <summary>
        /// 得到所有产品线基本信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        List<ProductLineBaseDTO> GetProductLineBaseInfo();
        /// <summary>
        /// 得到一条产品线信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ProductLineResultDTO GetOneProductLine(int id);
        /// <summary>
        /// 产品线新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool AddProductLine(ProductLineOperateDTO dto);
        /// <summary>
        /// 产品线修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool UpdateProductLine(ProductLineOperateDTO dto);
        /// <summary>
        /// 产品线删除
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool DeleteProductLine(ProductLineOperateDTO dto);
        /// <summary>
        /// 产品线停启用
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool StopEnableProductLine(ProductLineOperateDTO dto);
        #endregion
        #region 产品小类
        /// <summary>
        /// 得到所有产品小类信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        List<ProductSmallTypeResultDTO> GetProductSmallType(ProductSmallTypeSearchDTO dto);
        /// <summary>
        /// 得到所有产品小类基本信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        List<ProductSmallTypeBaseDTO> GetProductSmallTypeBaseInfo();
        /// <summary>
        /// 得到一条产品小类信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ProductSmallTypeResultDTO GetOneProductSmallType(int id);
        /// <summary>
        /// 产品小类新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool AddProductSmallType(ProductSmallTypeOperateDTO dto);
        /// <summary>
        /// 产品小类修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool UpdateProductSmallType(ProductSmallTypeOperateDTO dto);
        /// <summary>
        /// 产品小类删除
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool DeleteProductSmallType(ProductSmallTypeOperateDTO dto);
        /// <summary>
        /// 产品小类停启用
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool StopEnableProductSmallType(ProductSmallTypeOperateDTO dto);
        #endregion
        #region 产品型号（仪器型号）
        /// <summary>
        /// 得到所有产品型号信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        List<ProductModelResultDTO> GetProductModel(ProductModelSearchDTO dto);
        /// <summary>
        /// 得到一条产品型号信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ProductModelResultDTO GetOneProductModel(int id);
        /// <summary>
        /// 产品型号新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool AddProductModel(ProductModelOperateDTO dto);
        /// <summary>
        /// 产品型号修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool UpdateProductModel(ProductModelOperateDTO dto);
        /// <summary>
        /// 产品型号删除
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool DeleteProductModel(ProductModelOperateDTO dto);
        /// <summary>
        /// 产品型号停启用
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool StopEnableProductModel(ProductModelOperateDTO dto);
        #endregion
        #region 维修产品清单
        /// <summary>
        /// 得到所有维修产品信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        List<ProductInfoResultDTO> GetMaintenanceInfo(ProductInfoSearchDTO dto);
        /// <summary>
        /// 维修产品新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool AddMaintenanceInfo(ProductInfoOperateDTO dto);
        /// <summary>
        /// 维修产品修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool UpdateMaintenanceInfo(ProductInfoOperateDTO dto);
        /// <summary>
        /// 维修产品删除
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool DeleteMaintenanceInfo(ProductInfoOperateDTO dto);
        /// <summary>
        /// 维修产品停启用
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool StopEnableMaintenanceInfo(ProductInfoOperateDTO dto);
        #endregion
        #region 维修产品价格
        /// <summary>
        /// 得到维修产品价格
        /// </summary>
        /// <returns></returns>
        List<ProductPriceInfoResultDTO> GetMaintenancePrice(ProductPriceInfoSearchDTO dto);
        /// <summary>
        /// 修改维修产品价格
        /// </summary>
        /// <returns></returns>
        bool UpdateMaintenancePrice(ProductPriceInfoOperateDTO dto);
        /// <summary>
        /// 删除维修产品价格
        /// </summary>
        /// <returns></returns>
        bool DeleteMaintenancePrice(ProductPriceInfoOperateDTO dto);
        #endregion

        #region 产品类型
        /// <summary>
        /// 得到产品类型
        /// </summary>
        /// <returns></returns>
        List<ProductTypeResultDTO> GetProductTypeList(ProductTypeSearchDTO dto);
        /// <summary>
        /// 得到所有产品类型基本信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        List<ProductTypeBaseDTO> GetProductTypeBaseInfo();
        /// <summary>
        /// 得到一条产品类型
        /// </summary>
        /// <returns></returns>
        ProductTypeResultDTO GetProductType(int id);
        /// <summary>
        /// 新增产品类型
        /// </summary>
        /// <returns></returns>
        bool AddProductType(ProductTypeOperateDTO dto);
        /// <summary>
        /// 修改产品类型
        /// </summary>
        /// <returns></returns>
        bool UpdateProductType(ProductTypeOperateDTO dto);
        /// <summary>
        /// 删除产品类型
        /// </summary>
        /// <returns></returns>
        bool DeleteProductType(ProductTypeSearchDTO dto);
        #endregion
        #region 仪器类型
        /// <summary>
        /// 得到仪器类型
        /// </summary>
        /// <returns></returns>
        List<InstrumentTypeResultDTO> GetInstrumentTypeList();
        /// <summary>
        /// 得到一条仪器类型
        /// </summary>
        /// <returns></returns>
        InstrumentTypeResultDTO GetInstrumentType(int id);
        /// <summary>
        /// 新增仪器类型
        /// </summary>
        /// <returns></returns>
        bool AddInstrumentType(InstrumentTypeOperateDTO dto);
        /// <summary>
        /// 修改仪器类型
        /// </summary>
        /// <returns></returns>
        bool UpdateInstrumentType(InstrumentTypeOperateDTO dto);
        /// <summary>
        /// 删除仪器类型
        /// </summary>
        /// <returns></returns>
        bool DeleteInstrumentType(InstrumentTypeSearchDTO dto);
        #endregion
        #region 试剂产品清单
        /// <summary>
        /// 得到试剂产品清单
        /// </summary>
        /// <returns></returns>
        List<ProductInfoResultDTO> GetReagentInfoList(ProductInfoSearchDTO dto);
        /// <summary>
        /// 得到所有产品基本信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        List<ProductInfoBaseDTO> GetProductBaseInfo();
        /// <summary>
        /// 新增试剂产品
        /// </summary>
        /// <returns></returns>
        bool AddReagentInfo(ProductInfoOperateDTO dto);
        /// <summary>
        /// 修改试剂产品
        /// </summary>
        /// <returns></returns>
        bool UpdateReagentInfo(ProductInfoOperateDTO dto);
        /// <summary>
        /// 删除试剂产品
        /// </summary>
        /// <returns></returns>
        bool DeleteReagentInfo(ProductInfoOperateDTO dto);
        /// <summary>
        /// 停/启用试剂产品
        /// </summary>
        /// <returns></returns>
        bool StartOrStopReagentInfo(ProductInfoOperateDTO dto);
        #endregion
        #region 试剂产品价格
        /// <summary>
        /// 得到试剂产品价格
        /// </summary>
        /// <returns></returns>
        List<ProductPriceInfoResultDTO> GetReagentPriceList(ProductPriceInfoSearchDTO dto);
        /// <summary>
        /// 修改试剂产品价格
        /// </summary>
        /// <returns></returns>
        bool UpdateReagentPrice(ProductPriceInfoOperateDTO dto);
        /// <summary>
        /// 删除试剂产品价格
        /// </summary>
        /// <returns></returns>
        bool DeleteReagentPrice(ProductPriceInfoOperateDTO dto);
        
        #endregion
        #region 产品特价
        /// <summary>
        /// 显示OKC信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        List<OKCPriceInfoResultDTO> GetOKCList(OKCPriceInfoSearchDTO dto);
        /// <summary>
        /// 得到OKC产品价格
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        List<OKCProductResult> GetOKCPrice(OKCPriceInfoSearchDTO dto);
        /// <summary>
        /// 得到OKC经销商及最终客户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        List<OKCDistributorResult> GetOKCDistributor(OKCPriceInfoSearchDTO dto);
        /// <summary>
        /// 新增OKC号
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool AddOKC(OKCPriceInfoOperateDTO dto);
        /// <summary>
        /// 新增OKC产品特价
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool AddOKCProduct(OKCPriceInfoOperateDTO dto);
        /// <summary>
        /// 新增OKC经销商及最终客户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool AddOKCDepAndCus(OKCPriceInfoOperateDTO dto);
        /// <summary>
        /// 修改OKC
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool UpdateOKC(OKCPriceInfoOperateDTO dto);
        /// <summary>
        /// 删除OKC
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool DeleteOKC(OKCPriceInfoOperateDTO dto);
        /// <summary>
        /// 删除OKC产品特价
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool DeleteOKCProduct(OKCPriceInfoOperateDTO dto);
        /// <summary>
        /// 删除OKC经销商及最终客户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool DeleteOKCDepAndCus(OKCPriceInfoOperateDTO dto);
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool OKCInfoInsert(OKCPriceInfoOperateDTO dto);
        #endregion
    }
}
