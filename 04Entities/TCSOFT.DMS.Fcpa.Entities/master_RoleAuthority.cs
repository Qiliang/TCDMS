//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace TCSOFT.DMS.Fcpa.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class master_RoleAuthority
    {
        public int RoleAuthorityID { get; set; }
        public Nullable<int> RoleID { get; set; }
        public string StructureID { get; set; }
        public Nullable<int> RoleButtonAuthority { get; set; }
    
        public virtual dict_Structure dict_Structure { get; set; }
        public virtual master_RoleInfo master_RoleInfo { get; set; }
    }
}