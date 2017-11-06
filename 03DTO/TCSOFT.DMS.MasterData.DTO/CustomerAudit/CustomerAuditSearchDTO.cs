using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.CustomerAudit
{
    using TCSOFT.DMS.MasterData.DTO.Common;
    public class CustomerAuditSearchDTO:PagingDTO
    {
        /// <summary>
        /// 审核状态
        /// </summary>
        public short? Status { get; set; }
        /// <summary>
        /// 模糊查询
        /// </summary>
        public string SearchText { get; set; }
    }
}
