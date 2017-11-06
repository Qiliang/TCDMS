using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.IServices
{
    using DTO.RateDTO;
    using DTO.AccountDate;
    using DTO.Payment;
    using DTO.Transport;
    public interface IBaseInfoServices
    {
        #region 汇率
        /// <summary>
        /// 得到所有汇率信息
        /// </summary>
        /// <returns></returns>
        List<RateResultDTO> GetRateList();
        /// <summary>
        /// 得到一条汇率信息
        /// </summary>
        /// <returns></returns>
        RateResultDTO GetRate(int id);
        /// <summary>
        /// 新增汇率信息
        /// </summary>
        /// <returns></returns>
        bool AddRate(RateOperateDTO dto);
        /// <summary>
        /// 修改汇率信息
        /// </summary>
        /// <returns></returns>
        bool UpdateRate(RateOperateDTO dto);
        /// <summary>
        /// 删除汇率信息
        /// </summary>
        /// <returns></returns>
        bool DeleteRate(RateSearchDTO dto);
        #endregion
        #region 关账日
        /// <summary>
        /// 得到所有关账日信息
        /// </summary>
        /// <returns></returns>
        List<AccountDateResultDTO> GetAccountDateList();
        /// <summary>
        /// 得到一条关账日信息
        /// </summary>
        /// <returns></returns>
        AccountDateResultDTO GetAccountDate(int id);
        /// <summary>
        /// 新增关账日信息
        /// </summary>
        /// <returns></returns>
        bool AddAccountDate(AccountDateOperateDTO dto);
        /// <summary>
        /// 修改关账日信息
        /// </summary>
        /// <returns></returns>
        bool UpdateAccountDate(AccountDateOperateDTO dto);
        /// <summary>
        /// 删除关账日信息
        /// </summary>
        /// <returns></returns>
        bool DeleteAccountDate(AccountDateSearchDTO dto);
        #endregion
        #region 运输方式
        /// <summary>
        /// 得到所有运输方式信息
        /// </summary>
        /// <returns></returns>
        List<TransportResultDTO> GetTransport(TransportSearchDTO dto);
        /// <summary>
        /// 得到一条运输方式信息
        /// </summary>
        /// <returns></returns>
        TransportResultDTO GetOneTransport(int id);
        /// <summary>
        /// 运输方式新增
        /// </summary>
        /// <returns></returns>
        bool AddTransport(TransportOperateDTO dto);
        /// <summary>
        /// 运输方式修改
        /// </summary>
        /// <returns></returns>
        bool UpdateTransport(TransportOperateDTO dto);
        /// <summary>
        /// 运输方式停/启用
        /// </summary>
        /// <returns></returns>
        bool StopEnableTransport(TransportOperateDTO dto);
        #endregion
        #region 付款条款
        /// <summary>
        /// 得到所有付款条款信息
        /// </summary>
        /// <returns></returns>
        List<PaymentResultDTO> GetPaymentList(PaymentSearchDTO dto);
        /// <summary>
        /// 得到一条付款条款信息
        /// </summary>
        /// <returns></returns>
        PaymentResultDTO GetPayment(int id);
        /// <summary>
        /// 新增付款条款信息
        /// </summary>
        /// <returns></returns>
        bool AddPayment(PaymentOperateDTO dto);
        /// <summary>
        /// 修改付款条款信息
        /// </summary>
        /// <returns></returns>
        bool UpdatePayment(PaymentOperateDTO dto);
        /// <summary>
        /// 删除付款条款信息
        /// </summary>
        /// <returns></returns>
        bool DeletePayment(PaymentSearchDTO dto);
        /// <summary>
        /// 停/启用付款条款信息
        /// </summary>
        /// <returns></returns>
        bool StartOrStopPayment(PaymentOperateDTO dto);
        #endregion
    }
}
