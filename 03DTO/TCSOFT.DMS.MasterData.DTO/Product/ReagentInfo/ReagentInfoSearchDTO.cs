using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.Product.ReagentInfo
{
    public class ReagentInfoSearchDTO
    {
        /// <summary>
        /// 产品ID
        /// </summary>
        public Guid ProductID { get; set; }
        /// <summary>
        /// 试剂产品ID
        /// </summary>
        public int? ReagentInfoID { get; set; }
        /// <summary>
        /// 查询
        /// </summary>
        public string SearchText { get; set; }
    }
}
