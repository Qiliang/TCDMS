using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.Product.ProductLine
{
    public class ProductLineSearchDTO
    {
        /// <summary>
        /// 模糊查询
        /// </summary>
        public string SearchText { get; set; }
        /// <summary>
        /// 经销商ID
        /// </summary>
        public Guid? DistributorID { get; set; }
    }
}
