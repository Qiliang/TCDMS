using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCSOFT.DMS.UserApply.DTO.Common;

namespace TCSOFT.DMS.UserApply.DTO.User.UserApply
{
    public class UserApplySearchDTO : PagingDTO
    {
        /// <summary>
        /// 模糊查询
        /// </summary>
        public string SearchText { get; set; }
        /// <summary>
        /// 经销商ID
        /// </summary>
        public Guid? DistributorID { get; set; }
        /// <summary>
        /// 批次ID
        /// </summary>
        public Guid? BatchID { get; set; }
        /// <summary>
        /// 查询ID
        /// 1、申请批次 2、申请用户
        /// </summary>
        public int Query { get; set; }
        /// <summary>
        /// 当前用户角色ID
        /// </summary>
        public List<int?> RoleIDlist { get; set; }
        /// <summary>
        /// 用户申请ID
        /// </summary>
        public int? UserApplyID { get; set; }
    }
}
