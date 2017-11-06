using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCSOFT.DMS.MasterData.DTO.User.UserApply;
using TCSOFT.DMS.WebMain.Models.Model;

namespace TCSOFT.DMS.WebMain.Areas.MasterData.Models.Model
{
    public class UserApplyModel : UserApplyOperateDTO
    {
        /// <summary>
        /// 用户类型
        /// </summary>
        public string UserApplyTypeName { get; set; }
        /// <summary>
        /// 经销商Namestr
        /// </summary>
        public string DistributorNamestr { get; set; }
        private List<AuthorityListModel> _ApplyAuth = null;
        public List<AuthorityListModel> ApplyAuth
        {
            get
            {
                return _ApplyAuth;
            }
            set
            {
                _ApplyAuth = value;
                if (value != null)
                {
                    ApplyUserAuthority = new List<DMS.MasterData.DTO.User.UserApplyAuthority>();
                    foreach (var p in value)
                    {
                        if (ApplyUserAuthority.Where(w=>w.StructureID==p.LevelOne.StructureID).FirstOrDefault()==null)
                        {
                            ApplyUserAuthority.Add(new DMS.MasterData.DTO.User.UserApplyAuthority()
                            {
                                StructureID = p.LevelOne.StructureID,
                                AppyUserButtonAuthority = p.LevelOne.BelongButton
                            });
                        }
                        ApplyUserAuthority.Add(new DMS.MasterData.DTO.User.UserApplyAuthority()
                        {
                            StructureID = p.LevelTWO.StructureID,
                            AppyUserButtonAuthority = p.LevelTWO.BelongButton
                        });
                    }
                }
            }
        }
    }
}