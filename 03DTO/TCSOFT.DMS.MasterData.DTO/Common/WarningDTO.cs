using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.Common
{
    public class WarningDTO
    {
        /// <summary>
        /// 提醒ID
        /// </summary>
        public Guid? WarningID { get; set; }
        /// <summary>
        /// 所属模块对应信息ID
        /// </summary>
        public Guid? MappingID { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int? UserID { get; set; }
        /// <summary>
        /// 所属模块
        /// </summary>
        public string BelongModule { get; set; }
        /// <summary>
        /// 提醒信息
        /// </summary>
        public string WarningInfo { get; set; }
        /// <summary>
        /// 提醒信息显示
        /// </summary>
        public string WarningInfostr
        {
            get
            {
                var result = string.Empty;
                if (!string.IsNullOrEmpty(WarningInfo))
                {
                    result = WarningInfo.Length > 5 ? WarningInfo.Substring(0, 5) + "..." : WarningInfo;
                }
                return result;
            }
        }
    }
    public class WarningSearchDTO : PagingDTO
   {
       /// <summary>
       /// 所属模块对应信息ID
       /// </summary>
       public Guid? MappingID { get; set; }
       /// <summary>
       /// 提醒ID
       /// </summary>
       public Guid? WarningID { get; set; }
        /// <summary>
        /// 传导UserID来获取对应User的提醒信息。
        /// </summary>
       public int? UserID { get; set; }
   }
}
