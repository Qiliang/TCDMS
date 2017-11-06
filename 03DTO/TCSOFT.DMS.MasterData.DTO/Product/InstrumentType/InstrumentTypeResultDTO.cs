using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.Product.InstrumentType
{
    public class InstrumentTypeResultDTO
    {
        /// <summary>
        /// 仪器类型ID
        /// </summary>
        public int? InstrumentTypeID { get; set; }
        /// <summary>
        /// 仪器类型名
        /// </summary>
        public string InstrumentTypeName { get; set; }
    }
}
