using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.Common
{
    using TCSOFT.DMS.MasterData.DTO.User;
    public class FeedbackResultDTO
    {
        /// <summary>
        /// 反馈统计ID
        /// </summary>
        public int? FeedbackStatID { get; set; }
        /// <summary>
        /// 部门Name
        /// </summary>
        public string DepartName { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 用户类型
        /// </summary>
        public short? UserType { get; set; }
        /// <summary>
        /// 用户经销商Name
        /// </summary>
        public string UserDistributorstr { get; set; }
        /// <summary>
        /// 附件
        /// </summary>
        public AttachFileResultDTO AttachFile { get; set; }
        /// <summary>
        /// 反馈日期
        /// </summary>
        public DateTime? FeedbackDate { get; set; }
        /// <summary>
        /// 反馈状态
        /// </summary>
        public short? FeedbackStaus { get; set; }
        /// <summary>
        /// 反馈系统
        /// </summary>
        public string FeedbackSystem { get; set; }
        /// <summary>
        /// 反馈模块
        /// </summary>
        public string FeedbackModel { get; set; }
        /// <summary>
        /// 反馈内容
        /// </summary>
        public string FeedbackContent { get; set; }
        /// <summary>
        /// 处理人
        /// </summary>
        public string DealUser { get; set; }
        /// <summary>
        /// 处理时间
        /// </summary>
        public DateTime? DealDatetime { get; set; }


    }
    public class FeedbackOperateDTO
    {
        /// <summary>
        /// 反馈统计ID
        /// </summary>
        public int? FeedbackStatID { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int? UserID { get; set; }
        /// <summary>
        /// 反馈日期
        /// </summary>
        public DateTime? FeedbackDate { get; set; }
        /// <summary>
        /// 反馈状态
        /// </summary>
        public short? FeedbackStaus { get; set; }
        /// <summary>
        /// 反馈系统
        /// </summary>
        public string FeedbackSystem { get; set; }
        /// <summary>
        /// 反馈模块
        /// </summary>
        public string FeedbackModel { get; set; }
        /// <summary>
        /// 反馈内容
        /// </summary>
        public string FeedbackContent { get; set; }
        /// <summary>
        /// 处理人
        /// </summary>
        public string DealUser { get; set; }
        /// <summary>
        /// 处理时间
        /// </summary>
        public DateTime? DealDatetime { get; set; }

    }
    public class FeedbackSearchDTO:PagingDTO
    {
        /// <summary>
        /// 反馈系统
        /// </summary>
        public string FeedbackSystem { get; set; }
        /// <summary>
        /// 搜索条件
        /// </summary>
        public string SearchText { get; set; }
    }
}
