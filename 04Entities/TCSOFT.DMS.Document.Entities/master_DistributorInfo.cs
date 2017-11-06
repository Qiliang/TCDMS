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
    
    public partial class master_DistributorInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public master_DistributorInfo()
        {
            this.master_CustomerApplyInfo = new HashSet<master_CustomerApplyInfo>();
            this.master_CustomerInfo = new HashSet<master_CustomerInfo>();
            this.master_DistributorADInfo = new HashSet<master_DistributorADInfo>();
            this.master_DistributorOKCInfo = new HashSet<master_DistributorOKCInfo>();
            this.master_DistributorPayInfo = new HashSet<master_DistributorPayInfo>();
            this.master_DistributorProductLineInfo = new HashSet<master_DistributorProductLineInfo>();
            this.master_DistributorTransport = new HashSet<master_DistributorTransport>();
            this.master_UserInfo = new HashSet<master_UserInfo>();
        }
    
        public System.Guid DistributorID { get; set; }
        public Nullable<int> DistributorServiceTypeID { get; set; }
        public Nullable<int> DistributorTypeID { get; set; }
        public Nullable<int> RegionID { get; set; }
        public string DistributorCode { get; set; }
        public string DistributorName { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> NoActiveTime { get; set; }
        public string NoActiveReason { get; set; }
        public string InvoiceCode { get; set; }
        public string DeliverCode { get; set; }
        public string CSRNameReagent { get; set; }
        public string CSRNameD { get; set; }
        public Nullable<bool> IsOrderGoods { get; set; }
        public string CSRNameB { get; set; }
        public string Office { get; set; }
        public string CreateUser { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public string ModifyUser { get; set; }
        public Nullable<System.DateTime> ModifyTime { get; set; }
    
        public virtual dict_RegionInfo dict_RegionInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<master_CustomerApplyInfo> master_CustomerApplyInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<master_CustomerInfo> master_CustomerInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<master_DistributorADInfo> master_DistributorADInfo { get; set; }
        public virtual master_DistributorServiceType master_DistributorServiceType { get; set; }
        public virtual master_DistributorType master_DistributorType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<master_DistributorOKCInfo> master_DistributorOKCInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<master_DistributorPayInfo> master_DistributorPayInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<master_DistributorProductLineInfo> master_DistributorProductLineInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<master_DistributorTransport> master_DistributorTransport { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<master_UserInfo> master_UserInfo { get; set; }
    }
}