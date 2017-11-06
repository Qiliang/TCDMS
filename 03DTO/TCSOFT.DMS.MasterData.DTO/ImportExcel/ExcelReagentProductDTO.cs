using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.ImportExcel
{
    /// <summary>
    /// 试剂产品
    /// </summary>
    public class ExcelReagentProductDTO:ExcelImportDataDTO
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
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string ReagentSize { get; set; }
        /// <summary>
        /// 产品类型
        /// </summary>
        public string ProductTypeName { get; set; }
        /// <summary>
        /// 产品类型ID
        /// </summary>
        public int? ProductTypeID { get; set; }
        /// <summary>
        /// 产品线
        /// </summary>
        public string ProductLineName { get; set; }
        /// <summary>
        /// 产品线ID
        /// </summary>
        public int? ProductLineID { get; set; }
        /// <summary>
        /// 项目
        /// </summary>
        public string ReagentProject { get; set; }
        /// <summary>
        /// 测试数
        /// </summary>
        public string ReagentTest { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string RemarkDes { get; set; }
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
