using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.Product.InstrumentType
{
    public class InstrumentTypeSearchDTO
    {
        /// <summary>
        /// 仪器类型ID
        /// </summary>
        public int? InstrumentTypeID { get; set; }
        /// <summary>
        /// 最后修改人
        /// </summary>
        public string ModifyUser { get; set; }
    }
}
