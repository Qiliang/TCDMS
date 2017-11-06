using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCSOFT.DMS.WebMain.Areas.MasterData.Models.Provider
{
    using TCSOFT.DMS.Common;
    using TCSOFT.DMS.MasterData.DTO.Customer;
    using TCSOFT.DMS.MasterData.DTO.CustomerAudit;
    using TCSOFT.DMS.MasterData.DTO.ImportExcel;
    using TCSOFT.DMS.WebMain.Areas.MasterData.Models.Model;
    using TCSOFT.DMS.WebMain.Common;
    using TCSOFT.DMS.WebMain.Models.Model;
    using TCSOFT.DMS.WebMain.Models.Provider;
    public class CustomerProvider:BaseProvider
    {
        #region 客户信息
        /// <summary>
        /// 得到客户信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<List<CustomerInfoModel>> GetCustomerList(CustomerSearchDTO dto)
        {
            ResultData<List<CustomerInfoModel>> result = null;

            result = GetAPI<ResultData<List<CustomerInfoModel>>>(WebConfiger.MasterDataServicesUrl + "CustomerInfo?CustomerSearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return result;
        }
        /// <summary>
        /// 得到一条客户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static ResultData<CustomerInfoModel> GetCustomer(CustomerSearchDTO dto)
        {
            ResultData<CustomerInfoModel> result = new ResultData<CustomerInfoModel>();

            var resultlist = GetAPI<ResultData<List<CustomerInfoModel>>>(WebConfiger.MasterDataServicesUrl + "CustomerInfo?CustomerSearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));
            if (resultlist.Object != null && resultlist.Object.Count > 0)
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
        /// 新增客户信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> AddCustomer(CustomerOperateDTO dto)
        {
            ResultData<object> result = null;

            result = PostAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "CustomerInfo", dto);

            return result;
        }
        /// <summary>
        /// 修改客户信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> UpdateCustomer(CustomerOperateDTO dto)
        {
            ResultData<object> result = null;
            
            result = PutAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "CustomerInfo", dto);

            return result;
            
        }
        /// <summary>
        /// 删除客户信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> DeleteCustomer(CustomerOperateDTO dto)
        {
            ResultData<object> result = DeleteAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "CustomerInfo?CustomerOperateDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return result;
        }
        /// <summary>
        /// 停启用客户信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> ChangeStatusCustomer(CustomerOperateDTO dto)
        {
            ResultData<object> result = null;
          
            result = PutAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "CustomerInfo", dto);

            return result;
        }
        /// <summary>
        /// 导入客户信息
        /// </summary>
        /// <param name="regentprdlist"></param>
        /// <returns></returns>
        public static ResultData<object> ImportCustomer(List<ExcelCustomerInfoDTO> implist)
        {
            return PostAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "ImportData", new { Data = TransformHelper.ConvertDTOTOBase64JsonString(implist), Type = 10 });
        }
        #endregion

        #region 客户审核
        /// <summary>
        /// 得到客户审核信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<List<CustomerAuditModel>> GetCustomerAuditList(CustomerAuditSearchDTO dto)
        {
            ResultData<List<CustomerAuditModel>> result = null;

            result = GetAPI<ResultData<List<CustomerAuditModel>>>(WebConfiger.MasterDataServicesUrl + "CustomerAudit?CustomerAuditSearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return result;
        }
        /// <summary>
        /// 客户审核成功
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> CustomerAuditSuccess(CustomerAuditOperateDTO dto)
        {
            ResultData<object> result = null;

            result = PutAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "CustomerAudit", dto);

            return result;

        }
        /// <summary>
        /// 客户审核失败
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> CustomerAuditFail(CustomerAuditOperateDTO dto)
        {
            ResultData<object> result = null;

            result = PutAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "CustomerAudit", dto);

            return result;

        }
        #endregion
    }
}