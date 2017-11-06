using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCSOFT.DMS.WebMain.Areas.MasterData.Models.Provider
{
    using DMS.Common;
    using DMS.MasterData.DTO.AccountDate;
    using DMS.MasterData.DTO.RateDTO;
    using DMS.WebMain.Common;
    using DMS.WebMain.Models.Provider;
    using TCSOFT.DMS.MasterData.DTO.ImportExcel;
    using TCSOFT.DMS.MasterData.DTO.Payment;
    using TCSOFT.DMS.MasterData.DTO.Transport;
    using TCSOFT.DMS.WebMain.Models.Model;
    public class BaseInfoProvider : BaseProvider
    {
        #region 汇率管理
        /// <summary>
        /// 得到所有汇率信息
        /// </summary>
        /// <returns></returns>
        public static List<RateResultDTO> GetRateList()
        {
            List<RateResultDTO> result = null;

            result = GetAPI<List<RateResultDTO>>(WebConfiger.MasterDataServicesUrl + "Rate");

            return result;
        }
        /// <summary>
        /// 得到一条汇率信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static RateResultDTO GetOneRate(int id)
        {
            RateResultDTO result = null;

            result = GetAPI<RateResultDTO>(WebConfiger.MasterDataServicesUrl + "Rate?id=" + id);

            return result;
        }
        /// <summary>
        /// 新增汇率信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static bool AddRate(RateOperateDTO dto)
        {
            bool blResult = PostAPI<bool>(WebConfiger.MasterDataServicesUrl + "Rate", dto);

            return blResult;
        }
        /// <summary>
        /// 修改汇率信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static bool UpdateRate(RateOperateDTO dto)
        {
            bool blResult = PutAPI<bool>(WebConfiger.MasterDataServicesUrl + "Rate", dto);

            return blResult;
        }
        #endregion

        #region 运输方式
        /// <summary>
        /// 得到所有运输方式信息
        /// </summary>
        /// <returns></returns>
        public static List<TransportResultDTO> GetTransportList(TransportSearchDTO dto)
        {
            List<TransportResultDTO> result = null;

            result = GetAPI<List<TransportResultDTO>>(WebConfiger.MasterDataServicesUrl + "Transport?TransportSearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return result;
        }
        /// <summary>
        /// 得到一条运输方式信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static ResultData<TransportResultDTO> GetTransport(int id)
        {
            ResultData<TransportResultDTO> result = new ResultData<TransportResultDTO>();

            result = GetAPI<ResultData<TransportResultDTO>>(WebConfiger.MasterDataServicesUrl + "Transport?id=" + id);

            return result;
        }
        /// <summary>
        /// 新增运输方式信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> AddTransport(TransportOperateDTO dto)
        {

            var blResult = PostAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "Transport", dto);

            return blResult;
        }
        /// <summary>
        /// 修改运输方式信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> UpdateTransport(TransportOperateDTO dto)
        {
            var blResult = PutAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "Transport", dto);

            return blResult;
        }
        #endregion

        #region 付款条款
        /// <summary>
        /// 得到所有付款条款信息
        /// </summary>
        /// <returns></returns>
        public static List<PaymentResultDTO> GetPaymentList(PaymentSearchDTO dto)
        {
            List<PaymentResultDTO> result = null;

            result = GetAPI<List<PaymentResultDTO>>(WebConfiger.MasterDataServicesUrl + "Payment?PaymentSearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return result;
        }
        /// <summary>
        /// 得到一条付款条款信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static ResultData<PaymentResultDTO> GetPayment(int id)
        {
             ResultData<PaymentResultDTO> result = new ResultData<PaymentResultDTO>();
             result = GetAPI<ResultData<PaymentResultDTO>>(WebConfiger.MasterDataServicesUrl + "Payment?id=" + id);

            return result;
        }
        /// <summary>
        /// 新增付款条款信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> AddPayment(PaymentOperateDTO dto)
        {
            ResultData<object> blResult = PostAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "Payment", dto);

            return blResult;
        }
        /// <summary>
        /// 修改付款条款信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> UpdatePayment(PaymentOperateDTO dto)
        {
            ResultData<object> blResult = PutAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "Payment", dto);

            return blResult;
        }
        /// <summary>
        /// 删除付款条款信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> DeletePayment(PaymentSearchDTO dto)
        {
            ResultData<object> blResult = DeleteAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "Payment?PaymentSearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return blResult;
        }
        #endregion

        #region 关账日
        /// <summary>
        /// 得到所有关账日信息信息
        /// </summary>
        /// <returns></returns>
        public static List<AccountDateResultDTO> GetAccountDateList()
        {
            List<AccountDateResultDTO> result = null;

            result = GetAPI<List<AccountDateResultDTO>>(WebConfiger.MasterDataServicesUrl + "AccountDate");

            return result;
        }
        /// <summary>
        /// 得到一条关账日信息信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static AccountDateResultDTO GetOneAccountDate(int id)
        {
            AccountDateResultDTO result = null;

            result = GetAPI<AccountDateResultDTO>(WebConfiger.MasterDataServicesUrl + "AccountDate?id=" + id);

            return result;
        }
        /// <summary>
        /// 新增关账日信息信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> AddAccountDate(AccountDateOperateDTO dto)
        {
            ResultData<object> result = null;

            result = PostAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "AccountDate", dto);

            return result;
        }
        /// <summary>
        /// 修改关账日信息信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> UpdateAccountDate(AccountDateOperateDTO dto)
        {
            ResultData<object> result = null;

            result = PutAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "AccountDate", dto);

            return result;
        }
        /// <summary>
        /// 戴锐2017/06/08
        /// 导入，关帐日.
        /// </summary>
        /// <param name="regentprdlist"></param>
        /// <returns></returns>
        public static ResultData<object>ImportColseData(List<ExclCloseDataDTO> regentprdlist)
        {
            return PostAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "ImportData", new { Data = TransformHelper.ConvertDTOTOBase64JsonString(regentprdlist), Type = 9 });
        }
        #endregion
    }
}