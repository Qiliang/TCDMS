using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.Distributor.DistributorType
{
    using DTO.Common;
    public class DistributorTypeOperateDTO : OperateDTO
    {
        /// <summary>
        /// 经销商类别ID
        /// </summary>
        public int DistributorTypeID { get; set; }
        /// <summary>
        /// 经销商类别名
        /// </summary>
        public string DistributorTypeName { get; set; }
    }
}
