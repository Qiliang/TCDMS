using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCSOFT.DMS.UserApply.DTO.Common;

namespace TCSOFT.DMS.UserApply.DTO.User.UserApply
{
    public class UserApplyBatchResultDTO
    {
        /// <summary>
        /// 批次ID
        /// </summary>
        public Guid? BatchID { get; set; }
        /// <summary>
        /// 申请批次Name
        /// </summary>
        public string BatchName { get; set; }
        /// <summary>
        /// 申请人
        /// </summary>
        public string ApplyUser { get; set; }
        /// <summary>
        /// 申请人邮箱
        /// </summary>
        public string ApplyUserEamil { get; set; }
        /// <summary>
        /// 申请人手机号
        /// </summary>
        public string ApplyUserPhone { get; set; }
        /// <summary>
        /// 申请状态
        /// </summary>
        public short? AuditStatus { get; set; }
        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime? ApplyTime { get; set; }
        /// <summary>
        /// 用户申请经销商
        /// </summary>
        public string DistributorID { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public short? Status { get; set; }
        /// <summary>
        /// 申请用户List
        /// </summary>
        public List<UserApplyUserResultDTO> UserApplyUserList { get; set; }
    }
    public class UserApplyUserResultDTO
    {
        /// <summary>
        /// 用户申请ID
        /// </summary>
        public int UserApplyID { get; set; }
        /// <summary>
        /// 批次ID
        /// </summary>
        public Guid? BatchID { get; set; }
        /// <summary>
        /// 变更ID
        /// </summary>
        public int? UserChangeID { get; set; }
        /// <summary>
        /// 申请用户Name
        /// </summary>
        public string UserApplyName { get; set; }
        /// <summary>
        /// 申请用户手机号
        /// </summary>
        public string UserApplyTelNumber { get; set; }
        /// <summary>
        /// 申请用户邮箱
        /// </summary>
        public string UserApplyEmail { get; set; }
        /// <summary>
        /// 申请用户类型
        /// </summary>
        public short? UserApplyType { get; set; }
        /// <summary>
        /// 经销商ID
        /// </summary>
        public string DistributorIDList { get; set; }
        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime? UserApplyTime { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>
        public short? AuditStatus { get; set; }
        /// <summary>
        /// 判断审核状态转化为文字
        /// </summary>
        public string AuditStatusstr
        {
            get
            {
                string auditst = string.Empty;
                switch (AuditStatus)
                {
                    case 0:
                        auditst = "申请中";
                        break;
                    case 1:
                        auditst = "审核失败";
                        break;
                    case 2:
                        auditst = "审核成功";
                        break;
                    case 3:
                        auditst = "已保存";
                        break;
                }
                return auditst;
            }
        }
        /// <summary>
        /// 审核角色
        /// </summary>
        public string AuditRoleIDList { get; set; }
        /// <summary>
        /// 审核拒绝原因
        /// </summary>
        public string AuditFalseReason { get; set; }
        /// <summary>
        /// 申请用户权限
        /// </summary>
        public List<UserApplyAuthority> ApplyUserAuthority { get; set; }
    }
}
