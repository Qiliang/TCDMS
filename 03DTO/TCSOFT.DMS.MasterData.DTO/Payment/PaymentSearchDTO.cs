using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.Payment
{
    public class PaymentSearchDTO
    {
        /// <summary>
        /// 付款条款ID
        /// </summary>
        public int? PayID { get; set; }
        /// <summary>
        /// 模糊搜索
        /// </summary>
        public string SearchText { get; set; }
        /// <summary>
        /// 经销商ID
        /// </summary>
        public Guid? DistributorID { get; set; }

        /// <summary>
        /// 最后修改人
        /// </summary>
        public string ModifyUser { get; set; }
    }
}
