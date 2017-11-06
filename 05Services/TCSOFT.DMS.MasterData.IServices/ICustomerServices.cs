using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.IServices
{
    using TCSOFT.DMS.MasterData.DTO.Customer;
    using TCSOFT.DMS.MasterData.DTO.CustomerAudit;
    public interface ICustomerServices
    {
        #region 客户信息
        /// <summary>
        /// 得到客户信息列表（查询）
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        List<CustomerResultDTO> GetCustomerList(CustomerSearchDTO dto);
        /// <summary>
        /// 得到相似客户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        List<CustomerResultDTO> GetSimilarCustomerList(CustomerSearchDTO dto);
        /// <summary>
        /// 新增客户信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool AddCustomer(CustomerOperateDTO dto);
        /// <summary>
        /// 修改客户信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool UpdateCustomer(CustomerOperateDTO dto);
        /// <summary>
        /// 删除客户信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool DeleteCustomer(CustomerOperateDTO dto);
        /// <summary>
        /// 停启用客户信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool ChangeStatusCustomer(CustomerOperateDTO dto);
        #endregion

        #region 客户审核
        /// <summary>
        /// 得到客户审核列表(查询)
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        List<CustomerAuditResultDTO> GetCustomerAuditList(CustomerAuditSearchDTO dto);
        /// <summary>
        /// 客户信息审核成功
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool CustomerAuditSuccess(CustomerAuditOperateDTO dto);
        /// <summary>
        /// 客户信息审核失败
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool CustomerAuditFail(CustomerAuditOperateDTO dto);
        #endregion
    }
}
