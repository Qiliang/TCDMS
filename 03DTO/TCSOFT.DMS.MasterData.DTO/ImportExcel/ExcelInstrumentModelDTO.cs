using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.ImportExcel
{
    public class ExcelInstrumentModelDTO : ExcelImportDataDTO
    {

        /// <summary>
        /// 仪器型号
        /// </summary>
        public string ProductModelName { get; set; }
        /// <summary>
        /// 产品线
        /// </summary>
        public string ProductLineName { get; set; }
        /// <summary>
        /// 产品线ID
        /// </summary>
        public int? ProductLineID{ get; set; }
        /// <summary>
        /// 检查信息
        /// </summary>
        public string CheckInfo { get; set; }
    }
}
