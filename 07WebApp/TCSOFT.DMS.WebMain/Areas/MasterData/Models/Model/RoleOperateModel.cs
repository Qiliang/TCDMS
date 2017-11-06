using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCSOFT.DMS.WebMain.Areas.MasterData.Models.Model
{
    using TCSOFT.DMS.MasterData.DTO.Role;
    using TCSOFT.DMS.WebMain.Models.Model;
    public class RoleOperateModel : RoleOperateDTO
    {
        private List<AuthorityTreeModel> _RoleAuthorityModel = null;
        public List<AuthorityTreeModel> RoleAuthorityModel
        {
            get
            {
                return _RoleAuthorityModel;
            }
            set
            {
                _RoleAuthorityModel = value;
                RoleAuthority = new List<RoleAuthorityDTO>();
                _RoleAuthorityModel.ForEach(p =>
                {
                    TreetoList(p);
                });
            }
        }
        private void TreetoList(AuthorityTreeModel root)
        {
            var num = root.ButtonAuthorityList.Where(m => m.IsChecked).Sum(g => g.ButtonID);
            if (num > 0)
            {
                RoleAuthority.Add(new RoleAuthorityDTO
                {
                    StructureID = root.StructureID,
                    RoleButtonAuthority = num
                });
            }
            if (root.children != null && root.children.Count > 0)
            {
                foreach (var child in root.children)
                {
                    TreetoList(child);
                }
            }
        }
    }
}