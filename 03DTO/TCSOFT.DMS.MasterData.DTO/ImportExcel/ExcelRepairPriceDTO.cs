using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.ImportExcel
{
    public class ExcelRepairPriceDTO : ExcelImportDataDTO
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
        /// DNP价格
        /// </summary>
        public string DNPPriceStr { get; set; }
        /// <summary>
        /// DNP价格
        /// </summary>
        public decimal? DNPPrice
        {
            get
            {
                decimal? result = null;
                try
                {
                    if (!string.IsNullOrEmpty(DNPPriceStr))
                    {
                        result = decimal.Parse(DNPPriceStr);
                    }
                }
                catch
                {

                    return result;
                }

                return result;
            }
        }
        /// <summary>
        /// DNP价格开始日期
        /// </summary>
        public string DNPPriceStartStr { get; set; }
        /// <summary>
        /// DNP价格开始日期
        /// </summary>
        public DateTime? DNPPriceStart
        {
            get
            {
                DateTime? result = null;
                try
                {
                    if (!string.IsNullOrEmpty(DNPPriceStartStr))
                    {
                        result = DateTime.Parse(DNPPriceStartStr);
                    }
                }
                catch
                {

                    return result;
                }
                return result;
            }
        }
        /// <summary>
        /// DNP价格结束日期
        /// </summary>
        public string DNPPriceEndStr { get; set; }
        /// <summary>
        /// DNP价格结束日期
        /// </summary>
        public DateTime? DNPPriceEnd
        {
            get
            {
                DateTime? result = null;
                try
                {
                    if (!string.IsNullOrEmpty(DNPPriceEndStr))
                    {
                        result = DateTime.Parse(DNPPriceEndStr);
                    }
                }
                catch {

                    return result;
                }
                return result;
            }
        }
        /// <summary>
        /// 检查信息
        /// </summary>
        public string CheckInfo { get; set; }
    }
}
