//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace TCSOFT.DMS.Document.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class master_CustomerApplyInfo
    {
        public System.Guid CustomerApplyID { get; set; }
        public Nullable<System.Guid> DistributorID { get; set; }
        public string CustomerName { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public Nullable<System.DateTime> ApplyTime { get; set; }
        public Nullable<short> Status { get; set; }
        public Nullable<System.DateTime> AuditTime { get; set; }
        public string Auditor { get; set; }
        public string AuditReason { get; set; }
        public string CreateUser { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public string ModifyUser { get; set; }
        public Nullable<System.DateTime> ModifyTime { get; set; }
    
        public virtual master_DistributorInfo master_DistributorInfo { get; set; }
    }
}
