using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.ImportExcel
{
    public class ExcelReagentPriceDTO : ExcelImportDataDTO
    {
        /// <summary>
        /// 产品ID
        /// </summary>
        public Guid? ProductID { get; set; }
        /// <summary>
        /// 货号
        /// </summary>
        public string ArtNo { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public string DNPPrice { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public string DNPPriceStart { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public string DNPPriceEnd { get; set; }
        /// <summary>
        /// 检查信息
        /// </summary>
        public string CheckInfo { get; set; }
    }
}
