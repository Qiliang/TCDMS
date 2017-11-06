using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCSOFT.DMS.MasterData.DTO.Common;

namespace TCSOFT.DMS.MasterData.DTO.User.UserApply
{
    public class UserApplyOperateDTO : OperateDTO
    {
        /// <summary>
        /// 用户申请流水ID
        /// </summary>
        public int? UserApplyID { get; set; }
        /// <summary>
        /// 批次
        /// </summary>
        public Guid? BatchID { get; set; }
        /// <summary>
        /// 变更权限用户ID
        /// </summary>
        public int? UserChangeID { get; set; }
        /// <summary>
        /// 用户申请姓名
        /// </summary>
        public string UserApplyName { get; set; }
        /// <summary>
        /// 申请手机号
        /// </summary>
        public string UserApplyTelNumber { get; set; }
        /// <summary>
        /// 申请邮箱
        /// </summary>
        public string UserApplyEmail { get; set; }
        /// <summary>
        /// 申请用户类型
        /// </summary>
        public short UserApplyType { get; set; }
        /// <summary>
        /// 审核角色
        /// </summary>
        public string AuditRoleIDList { get; set; }
        /// <summary>
        /// 经销商IDList
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
        /// 审核失败原因
        /// </summary>
        public string AuditFalseReason { get; set; }
        /// <summary>
        /// 用户申请权限
        /// </summary>
        public List<UserApplyAuthority> ApplyUserAuthority { get; set; }
        /// <summary>
        /// 用户有效时间
        /// </summary>
        public DateTime? StopTime { get; set; }
        /// <summary>
        /// 当前用户角色ID
        /// </summary>
        public List<int?> RoleIDlist { get; set; }
        /// <summary>
        /// 审核的模块ID
        /// </summary>
        public List<string> modelIDlist { get; set; }
    }
}
