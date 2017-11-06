using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.ImportExcel
{
    public class ExcelDistributorDTO : ExcelImportDataDTO
    {
        /// <summary>
        /// 经销商ID
        /// </summary>
        public Guid? DistributorID { get; set; }
        public string IsActiveStr { get; set; }
        public string DistributorCode { get; set; }
        public string DistributorName { get; set; }
        public string DistributorTypeName { get; set; }
        public string DistributorServiceTypeName { get; set; }
        public string RegionName { get; set; }
        /// <summary>
        /// 经销商服务类型ID
        /// </summary>
        public int? DistributorServiceTypeID { get; set; }
        /// <summary>
        /// 经销商类别ID
        /// </summary>
        public int? DistributorTypeID { get; set; }
        /// <summary>
        /// 注册省份ID
        /// </summary>
        public int? RegionID { get; set; }
        public string InvoiceCode { get; set; }
        public string DeliverCode { get; set; }
        public string CSRNameReagent { get; set; }
        public string CSRNameD { get; set; }
        public string CSRNameB { get; set; }
        public string Office { get; set; }
        /// <summary>
        /// 检查信息
        /// </summary>
        public string CheckInfo { get; set; }
        /// <summary>
        /// 导入逻辑（1新增，2修改）
        /// </summary>
        public int UpLogic { get; set; }

    }
}
