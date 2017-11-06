using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.Product.ProductSmallType
{
    public class ProductSmallTypeSearchDTO
    {
        /// <summary>
        /// 模糊查询
        /// </summary>
        public string SearchText { get; set; }
        /// <summary>
        /// 模糊查询
        /// </summary>
        public int? ProductLineID { get; set; }
    }
}
