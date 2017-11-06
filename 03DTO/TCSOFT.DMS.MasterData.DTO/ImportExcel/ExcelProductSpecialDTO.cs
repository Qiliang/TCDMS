using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.ImportExcel
{
    public class ExcelProductSpecialDTO : ExcelImportDataDTO
    {
        public Guid? ProductID { get; set; }
        public int? OKCID { get; set; }
        public string ArtNo { get; set; }
        public string ProductOKCPrice { get; set; }
        /// <summary>
        /// 检查信息
        /// </summary>
        public string CheckInfo { get; set; }
    }
}
