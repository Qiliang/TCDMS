using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCSOFT.DMS.WebMain.Models.Provider
{
    using TCSOFT.DMS.MasterData.DTO.Distributor.Distributor;
    using TCSOFT.DMS.MasterData.DTO.Message;
    using TCSOFT.DMS.WebMain.Common;
    using TCSOFT.DMS.WebMain.Models.Model;
    public class CommonProvider : BaseProvider
    {
        /// <summary>
        /// 通过经销商名称开头字符得到经销商基本信息
        /// </summary>
        /// <param name="lngdto"></param>
        /// <returns></returns>
        public static List<DistributorBaseDTO> GetDistributorBaseInfoByName(string DistributorName)
        {
            List<DistributorBaseDTO> result = null;

            result = GetAPI<List<DistributorBaseDTO>>(WebConfiger.MasterDataServicesUrl + "QueryDistributorBaseInfo?DistributorName=" + DistributorName);

            return result;
        }
        /// <summary>
        /// 新增短信统计
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> AddMessageStat(List<MessageOperateDTO> dtolist)
        {
            ResultData<object> result = null;

            result = PostAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "MessageStat", dtolist);

            return result;
        }
    }
}