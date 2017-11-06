//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace TCSOFT.DMS.MasterData.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class master_CustomerInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public master_CustomerInfo()
        {
            this.master_DistributorOKCInfo = new HashSet<master_DistributorOKCInfo>();
        }
    
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
        public string CreateUser { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public string ModifyUser { get; set; }
        public Nullable<System.DateTime> ModifyTime { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<master_DistributorOKCInfo> master_DistributorOKCInfo { get; set; }
        public virtual master_DistributorInfo master_DistributorInfo { get; set; }
    }
}
