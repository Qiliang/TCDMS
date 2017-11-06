using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.Customer
{
    using TCSOFT.DMS.MasterData.DTO.Common;
    public class CustomerSearchDTO:PagingDTO
    {
        /// <summary>
        /// 客户ID
        /// </summary>
        public Guid? CustomerID { get; set; }
        /// <summary>
        /// 模糊搜索条件
        /// </summary>
        public string SearchText { get; set; }
        /// <summary>
        /// 省份
        /// </summary>
        public string Province { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 县区
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// 查询类型(0.查询客户信息，1.查询相似客户)
        /// </summary>
        public int QueryType { get; set; }
    }
}
