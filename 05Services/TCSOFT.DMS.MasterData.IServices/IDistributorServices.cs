using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.IServices
{
    using DTO.Distributor.DistributorType;
    using DTO.Distributor.DistributorServiceType;
    using DTO.Distributor.Distributor;
    using DTO.Distributor.DistributorAnnounceAuthority;
    using DTO.Distributor.DistributorAuthority;
    using TCSOFT.DMS.MasterData.DTO.Distributor.DistributorPriceAuthority;
    public interface IDistributorServices
    {
        #region 经销商类别
        /// <summary>
        /// 得到所有经销商类别
        /// </summary>
        /// <returns></returns>
        List<DistributorTypeResultDTO> GetDistributorType(DistributorTypeSearchDTO dto);
        /// <summary>
        /// 经销商类别新增
        /// </summary>
        /// <returns></returns>
        bool AddDistributorType(DistributorTypeOperateDTO dto);
        /// <summary>
        /// 经销商类别修改
        /// </summary>
        /// <returns></returns>
        bool UpdateDistributorType(DistributorTypeOperateDTO dto);
        /// <summary>
        /// 经销商类别删除
        /// </summary>
        /// <returns></returns>
        bool DeleteDistributorType(DistributorTypeOperateDTO dto);
        #endregion

        #region 经销商服务类型
        /// <summary>
        /// 得到所有经销商服务类型
        /// </summary>
        /// <returns></returns>
        List<DistributorServiceTypeResultDTO> GetDistributorServiceType(DistributorServiceTypeSearchDTO dto);
        /// <summary>
        /// 经销商服务类型新增
        /// </summary>
        /// <returns></returns>
        bool AddDistributorServiceType(DistributorServiceTypeOperateDTO dto);
        /// <summary>
        /// 经销商服务类型修改
        /// </summary>
        /// <returns></returns>
        bool UpdateDistributorServiceType(DistributorServiceTypeOperateDTO dto);
        /// <summary>
        /// 经销商服务类型删除
        /// </summary>
        /// <returns></returns>
        bool DeleteDistributorServiceType(DistributorServiceTypeOperateDTO dto);
        #endregion

        #region 经销商管理
        /// <summary>
        /// 得到经销商信息
        /// </summary>
        /// <returns></returns>
        List<DistributorResultDTO> GetDistributorList(DistributorSearchDTO dto);
        /// <summary>
        /// 得到经销商信息(开头字符为查询条件)
        /// </summary>
        /// <returns></returns>
        List<DistributorBaseDTO> GetDistributorBaseInfoByName(string DistributorName);
        /// <summary>
        /// 新增经销商信息
        /// </summary>
        /// <returns></returns>
        bool AddDistributor(DistributorOperateDTO dto);
        /// <summary>
        /// 修改经销商信息
        /// </summary>
        /// <returns></returns>
        bool UpdateDistributor(DistributorOperateDTO dto);
        /// <summary>
        /// 删除经销商信息
        /// </summary>
        /// <returns></returns>
        bool DeleteDistributor(DistributorOperateDTO dto);
        /// <summary>
        /// 停/启用经销商
        /// </summary>
        /// <returns></returns>
        bool StartOrStopDistributor(DistributorOperateDTO dto);
        /// <summary>
        /// 经销商更名
        /// </summary>
        /// <returns></returns>
        bool DistributorChangeName(DistributorChangeNameDTO dto);
        #endregion

        #region 经销商授权
        /// <summary>
        /// 得到经销商授权信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        List<DistributorAuthorityResultDTO> GetDistributorAuthority(DistributorAuthoritySearchDTO dto);
        /// <summary>
        /// 得到经销商授权付款条款信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        List<DistributorPaymentResultDTO> GetDistributorAuthorityPay(DistributorAuthoritySearchDTO dto);
        /// <summary>
        /// 得到经销商授权运输方式信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        List<DistributorTransportResultDTO> GetDistributorAuthorityTransport(DistributorAuthoritySearchDTO dto);
        /// <summary>
        /// 得到经销商授权产品线信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        List<DistributorProductLineResultDTO> GetDistributorAuthorityProductLine(DistributorAuthoritySearchDTO dto);
        /// <summary>
        /// 得到经销商授权产品线区域信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        List<DistributorRegionResultDTO> GetDistributorAuthorityRegion(DistributorAuthoritySearchDTO dto);
        /// <summary>
        /// 授权经销商订货权限
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool DistributorOrderGoodsAuthority(DistributorAuthorityOperateDTO dto);
        /// <summary>
        /// 授权经销商付款条款
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool DistributorPayAuthority(DistributorAuthorityOperateDTO dto);
        /// <summary>
        /// 授权经销商运输方式
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool DistributorTransportAuthority(DistributorAuthorityOperateDTO dto);
        /// <summary>
        /// 授权经销商产品线
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool DistributorProductLineAuthority(DistributorAuthorityOperateDTO dto);
        /// <summary>
        /// 授权经销商产品线区域
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool DistributorProductLineRegionAuthority(DistributorAuthorityOperateDTO dto);
        /// <summary>
        /// 删除经销商付款条款
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool DeleteDistributorPayAuthority(DistributorAuthorityOperateDTO dto);
        /// <summary>
        /// 删除经销商运输方式
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool DeleteDistributorTransportAuthority(DistributorAuthorityOperateDTO dto);
        /// <summary>
        /// 删除经销商产品线
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool DeleteDistributorProductLineAuthority(DistributorAuthorityOperateDTO dto);
        /// <summary>
        /// 删除经销商产品线区域
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool DeleteDistributorProductLineRegionAuthority(DistributorAuthorityOperateDTO dto);
        #endregion

        #region 经销商公告授权
        /// <summary>
        /// 得到经销商公告授权信息
        /// </summary>
        /// <returns></returns>
        List<DistributorAnnounceAuthorityResultDTO> GetDistributorAnnounceAuthorityList(DistributorAnnounceAuthoritySearchDTO dto);
        /// <summary>
        /// 新增经销商公告授权
        /// </summary>
        /// <returns></returns>
        bool AddDistributorAnnounceAuthority(DistributorAnnounceAuthorityOperateDTO dto);
        #endregion

        #region 经销商价格授权
        /// <summary>
        /// 得到经销商OKC信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        List<DistributorOKCProduct> GetDisOKCList(DistributorPriceAuthoritySearchDTO dto);
        #endregion
    }
}
