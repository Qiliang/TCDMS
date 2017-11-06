using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCSOFT.DMS.WebMain.Models.Model
{
    using DMS.MasterData.DTO;
    public class AuthorityTreeModel:StructureDTO
    {
        public List<AuthorityTreeButton> ButtonAuthorityList { get; set; }
        public List<AuthorityTreeModel> children { get; set; }
    }

    public class AuthorityTreeButton : ButtonDTO
    {
        /// <summary>
        /// 是否被选中(有权限)
        /// </summary>
        public bool IsChecked { get; set; }
    }
}