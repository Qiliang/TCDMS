using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCSOFT.DMS.MasterData.DTO.Distributor.Distributor;
using TCSOFT.DMS.MasterData.DTO.Distributor.DistributorAnnounceAuthority;

namespace TCSOFT.DMS.MasterData.DTO.ImportExcel
{
    public class ExcelDistributorADAuthorityDTO : ExcelImportDataDTO
    {
        /// <summary>
        /// 经销商名称
        /// </summary>
        public string DistributorName { get; set; }
        /// <summary>
        /// 经销商id
        /// </summary>
        public Guid? DistributorID
        {
            get;
            set;
        }
        /// <summary>
        /// 经销商类别
        /// </summary>
        public string DistributorTypeName { get; set; }
        /// <summary>
        /// 经销商服务类型
        /// </summary>
        public string DistributorServiceTypeName { get; set; }
        /// <summary>
        /// 注册省份
        /// </summary>
        public string RegionName { get; set; }
        /// <summary>
        /// 产品线
        /// </summary>
        public string ProductLineName { get; set; }
        /// <summary>
        /// 产品线列表
        /// </summary>
        public string[] ProductLineNameList
        {
            get
            {
                if (!string.IsNullOrEmpty(ProductLineName))
                {
                    return ProductLineName.Split(',');
                }

                return null;
            }
        }
        /// <summary>
        /// 产品线ID列表
        /// </summary>
        public List<int> ProductLineIDList { get; set; }
        /// <summary>
        /// 导入逻辑（1新增，2修改）
        /// </summary>
        public int UpLogic { get; set; }
        public string CheckInfo { get; set; }
    }
}
