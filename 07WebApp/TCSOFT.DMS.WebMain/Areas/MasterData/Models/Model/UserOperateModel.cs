using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCSOFT.DMS.WebMain.Areas.MasterData.Models.Model
{
    using TCSOFT.DMS.MasterData.DTO.User;
    using TCSOFT.DMS.WebMain.Models.Model;
    public class UserOperateModel : UserOperate
    {
        private List<AuthorityTreeModel> _UserAuthorityModel = null;
        public List<AuthorityTreeModel> UserAuthorityModel 
        {
            get
            {
                return _UserAuthorityModel;
            }
            set
            {
                _UserAuthorityModel = value;
                UserAuthority = new List<UserCustomerAuthority>();
                _UserAuthorityModel.ForEach(p => {
                    TreetoList(p);
                });
            }
        }
        /// <summary>
        /// 是否自定义
        /// </summary>
        public bool IsCustom { get; set; }
        private void TreetoList(AuthorityTreeModel root)
        {
            var num = root.ButtonAuthorityList.Where(m => m.IsChecked).Sum(g => g.ButtonID);
            if (num > 0)
            {
                UserAuthority.Add(new UserCustomerAuthority
                {
                    StructureID = root.StructureID,
                    UserButtonAuthority = num
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