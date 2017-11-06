using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.Distributor.DistributorServiceType
{
    using DTO.Common;
    public class DistributorServiceTypeOperateDTO : OperateDTO
    {
        /// <summary>
        /// 经销商服务类型ID
        /// </summary>
        public int DistributorServiceTypeID { get; set; }
        /// <summary>
        /// 经销商服务类型名
        /// </summary>
        public string DistributorServiceTypeName { get; set; }
    }
}
