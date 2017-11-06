using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.Product.ProductType
{
    public class ProductTypeSearchDTO
    {
        /// <summary>
        /// 产品类型ID
        /// </summary>
        public int? ProductTypeID { get; set; }
        /// <summary>
        /// 查询
        /// </summary>
        public string SearchText { get; set; }
        /// <summary>
        /// 最后修改人
        /// </summary>
        public string ModifyUser { get; set; }
    }
}
