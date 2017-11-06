using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.ImportExcel
{
    public class ExcelCustomerInfoDTO : ExcelImportDataDTO
    {
        /// <summary>
        /// 客户ID
        /// </summary>
        public Guid? CustomerID { get; set; }
        /// <summary>
        /// 省份
        /// </summary>
        public string Province { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 客户类型
        /// </summary>
        public string CustomerType { get; set; }
        /// <summary>
        /// Oracle号
        /// </summary>
        public string OracleNO { get; set; }
        /// <summary>
        /// OracleName
        /// </summary>
        public string OracleName { get; set; }
        /// <summary>
        /// 经销商提交客户名称
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// XSW编号
        /// </summary>
        public string XSWNO { get; set; }
        /// <summary>
        /// 经销商名称
        /// </summary>
        public string DistributorName { get; set; }
        /// <summary>
        /// 判断是否满足唯一条件
        /// </summary>
        public string CheckInfo { get; set; }
        /// <summary>
        /// 导入逻辑（1新增，2修改）
        /// </summary>
        public int UpLogic { get; set; }
    }
}
