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
    
    public partial class fcpa_AlarmInfo
    {
        public System.Guid ID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<System.DateTime> AlarmTime { get; set; }
    
        public virtual fcpa_UserInfo fcpa_UserInfo { get; set; }
    }
}