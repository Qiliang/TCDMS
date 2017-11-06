using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.ImportExcel
{
    /// <summary>
    /// 维修产品
    /// </summary>
    public class ExcelRepairProductDTO : ExcelImportDataDTO
    {
        /// <summary>
        /// 产品ID
        /// </summary>
        public Guid? ProductID { get; set; }
        /// <summary>
        /// 状态字符串
        /// </summary>
        public string IsActiveStr { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public bool IsActive
        {
            get
            {
                bool result = false;
                if (IsActiveStr == "启用")
                {
                    result = true;
                }

                return result;
            }
        }
        /// <summary>
        /// 货号
        /// </summary>
        public string ArtNo { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 产品类型
        /// </summary>
        public string ProductTypeName { get; set; }
        /// <summary>
        /// 产品类型ID
        /// </summary>
        public int? ProductTypeID { get; set; }
        /// <summary>
        /// 产品小类
        /// </summary>
        public string ProductSmallTypeName { get; set; }
        /// <summary>
        /// 产品小类ID
        /// </summary>
        public int? ProductSmallTypeID { get; set; }
        /// <summary>
        /// 产品线
        /// </summary>
        public string ProductLineName { get; set; }
        /// <summary>
        /// 产品线ID
        /// </summary>
        public int? ProductLineID { get; set; }
        /// <summary>
        /// 3C产品字符串
        /// </summary>
        public string Is3CStr { get; set; }
        /// <summary>
        /// 3C产品
        /// </summary>
        public bool Is3C
        {
            get
            {
                bool result = false;
                if (Is3CStr == "是")
                {
                    result = true;
                }

                return result;
            }
        }
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
