using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.ImportExcel
{
    public class ExcelUser : ExcelImportDataDTO
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int? UserID { get; set; }
        public string UserCode { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string RoleNamestr { get; set; }
        public List<string> RoleNamelist
        {
            get
            {
                List<string> rolelist = new List<string>();
                if (!string.IsNullOrEmpty(RoleNamestr))
                {
                    string rolestr = string.Empty;

                    RoleNamestr.Split(',').ToList().ForEach(g =>
                    {
                        rolestr = g.Trim();
                        if (!string.IsNullOrEmpty(rolestr))
                        {
                            rolelist.Add(rolestr);
                        }
                    });
                }

                return rolelist;
            }
        }
        public string DistributorNamestr { get; set; }
        public List<string> DistributorNamelist
        {
            get
            {
                List<string> dislist = new List<string>();
                if (!string.IsNullOrEmpty(DistributorNamestr))
                {
                    string disstr = string.Empty;

                    DistributorNamestr.Split(',').ToList().ForEach(g =>
                    {
                        disstr = g.Trim();
                        if (!string.IsNullOrEmpty(disstr))
                        {
                            dislist.Add(disstr);
                        }
                    });
                }

                return dislist;
            }
        }
        public string StopTime { get; set; }
        public string CheckInfo { get; set; }
        /// <summary>
        /// 导入逻辑（1新增，2修改）
        /// </summary>
        public int UpLogic { get; set; }
    }
}
