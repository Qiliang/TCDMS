//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace TCSOFT.DMS.UserApply.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserApply_UserApplyAuthority
    {
        public int UserAppLyAuthorityID { get; set; }
        public Nullable<int> UserApplyID { get; set; }
        public string StructureID { get; set; }
        public Nullable<int> AppyUserButtonAuthority { get; set; }
        public Nullable<bool> IsAdopt { get; set; }
    
        public virtual UserApply_UserApplyInfo UserApply_UserApplyInfo { get; set; }
    }
}
