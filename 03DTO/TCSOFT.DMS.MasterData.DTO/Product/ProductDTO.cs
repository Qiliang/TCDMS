using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.Product
{
    using DTO.Common;
    public class ProductDTO : OperateDTO
    {
        /// <summary>
        /// 产品ID
        /// </summary>
        public Guid? ProductID { get; set; }
        /// <summary>
        /// 产品线ID
        /// </summary>
        public int? ProductLineID { get; set; }
        /// <summary>
        /// 产品类型ID
        /// </summary>
        public int? ProductTypeID { get; set; }
        /// <summary>
        /// 仪器类型ID
        /// </summary>
        public int? InstrumentTypeID { get; set; }
        /// <summary>
        /// 仪器型号ID
        /// </summary>
        public int? InstrumentModelID { get; set; }
        /// <summary>
        /// OKCID
        /// </summary>
        public int? OKCID { get; set; }
        /// <summary>
        /// 试剂产品ID
        /// </summary>
        public int? ReagentInfoID { get; set; }
        /// <summary>
        /// 维修产品ID
        /// </summary>
        public int? MaintenanceID { get; set; }
        /// <summary>
        /// 产品价格ID
        /// </summary>
        public int? ProductPriceID { get; set; }
        /// <summary>
        /// 货号
        /// </summary>
        public string ArtNo { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }
    }
}
