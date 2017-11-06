using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.Product.ProductInfo
{
    using TCSOFT.DMS.MasterData.DTO.Product.ProductLine;
    using TCSOFT.DMS.MasterData.DTO.Product.ProductSmallType;
    public class ProductInfoResultDTO
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
        /// 产品线Name
        /// </summary>
        public string ProductLineName { get; set; }
        /// <summary>
        /// 产品类型ID
        /// </summary>
        public int? ProductTypeID { get; set; }
        /// <summary>
        /// 产品类型Name
        /// </summary>
        public string ProductTypeName { get; set; }
        /// <summary>
        /// 产品小类ID
        /// </summary>
        public int? ProductSmallTypeID { get; set; }
        /// <summary>
        /// 产品小类名称
        /// </summary>
        public string ProductSmallTypeName { get; set; }
        /// <summary>
        /// 货号
        /// </summary>
        public string ArtNo { get; set; }
        /// <summary>
        /// 项目
        /// </summary>
        public string ReagentProject { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string ReagentSize { get; set; }
        /// <summary>
        /// 测试数
        /// </summary>
        public string ReagentTest { get; set; }
        /// <summary>
        /// 描述及备注
        /// </summary>
        public string RemarkDes { get; set; }
        /// <summary>
        /// 是否3C产品
        /// </summary>
        public bool? Is3C { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool? IsActive { get; set; }
        /// <summary>
        /// 停用原因
        /// </summary>
        public string StopReason { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 是否维修产品
        /// </summary>
        public bool? IsMaintenance { get; set; }
    }
}
