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
    
    public partial class imp_CustomerInfo
    {
        public System.Guid CustomerID { get; set; }
        public Nullable<System.Guid> DistributorID { get; set; }
        public string CustomerName { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string OracleNO { get; set; }
        public Nullable<System.DateTime> NoActiveTime { get; set; }
        public string NoActiveReason { get; set; }
        public string OracleName { get; set; }
        public string XSWNO { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string ImportUser { get; set; }
        public Nullable<System.DateTime> ImportDateTime { get; set; }
    }
}