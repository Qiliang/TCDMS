using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCSOFT.DMS.UserApply.DTO.User.UserApply;
using TCSOFT.DMS.WebMain.Models.Model;

namespace TCSOFT.DMS.WebMain.Areas.User.Models.Model
{
    public class UserApplyBatchchResultModel : UserApplyBatchResultDTO
    {
        public string AuditStatusstr
        {
            get
            {
                string auditst = string.Empty;
                switch (AuditStatus)
                {
                    case 0:
                        auditst = "申请中";
                        break;
                    case 1:
                        auditst = "审核失败";
                        break;
                    case 2:
                        auditst = "审核成功";
                        break;
                    case 3:
                        auditst = "已保存";
                        break;
                }
                return auditst;
            }
        }
        public string ApplyTimestr
        {
            get 
            {
                return ApplyTime != null ? ApplyTime.Value.ToString("yyyy-MM-dd") : null;
            }
        }
    }
    public class UserApplyModel : UserApplyOperateDTO
    {
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
                    ApplyUserAuthority = new List<UserApplyAuthority>();
                    foreach (var p in value)
                    {
                        if (p.LevelOne != null)
                        {
                            if (ApplyUserAuthority.Where(w => p.LevelOne.StructureID == w.StructureID).FirstOrDefault() == null) 
                            {
                                ApplyUserAuthority.Add(new UserApplyAuthority() { StructureID = p.LevelOne.StructureID, AppyUserButtonAuthority = p.LevelOne.BelongButton });
                            }
                        }
                        if (p.LevelTWO != null )
                        {
                            if (ApplyUserAuthority.Where(w => p.LevelTWO.StructureID == w.StructureID).FirstOrDefault() == null) 
                            {
                                ApplyUserAuthority.Add(new UserApplyAuthority() { StructureID = p.LevelTWO.StructureID, AppyUserButtonAuthority = p.LevelTWO.BelongButton });
                            }
                        }
                        if (p.LevelThree != null)
                        {
                            ApplyUserAuthority.Add(new UserApplyAuthority() { StructureID = p.LevelThree.StructureID, AppyUserButtonAuthority = p.LevelThree.BelongButton });
                        }
                    }
                }
            }
        }
    }
    public class UserApplyResultModel : UserApplyUserResultDTO
    {
        public string UserApplyTypestr 
        {
            get 
            {
                string typestr = string.Empty;
                if (UserApplyType != null) 
                {
                    switch (UserApplyType) 
                    {
                        case 0:
                            typestr = "系统管理员";
                            break;
                        case 1:
                            typestr = "贝克曼";
                            break;
                        case 2:
                            typestr = "经销商";
                            break;
                    }
                }
                return typestr;
            }
        }
        public string UserApplyTimestr 
        {
            get 
            {
                return UserApplyTime != null ? UserApplyTime.Value.ToString("yyyy-MM-dd") : string.Empty;
            }
        }
        public string AuditStatusstr
        {
            get
            {
                string auditst = string.Empty;
                switch (AuditStatus)
                {
                    case 0:
                        auditst = "申请中";
                        break;
                    case 1:
                        auditst = "审核失败";
                        break;
                    case 2:
                        auditst = "审核成功";
                        break;
                    case 3:
                        auditst = "已保存";
                        break;
                }
                return auditst;
            }
        }
    }
}