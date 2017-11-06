using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.Transport
{
    using DTO.Common;
    public class TransportOperateDTO : OperateDTO
    {
        /// <summary>
        /// 运输方式ID
        /// </summary>
        public int TransportID { get; set; }
        /// <summary>
        /// 运输方式
        /// </summary>
        public string TransportName { get; set; }
        /// <summary>
        /// 订单类型
        /// </summary>
        public string OrderType { get; set; }
        /// <summary>
        /// 运输启用状态
        /// </summary>
        public bool? TransportStatus { get; set; }
    }
}
