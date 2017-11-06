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
    
    public partial class master_ProductInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public master_ProductInfo()
        {
            this.master_ProductPriceInfo = new HashSet<master_ProductPriceInfo>();
            this.master_ProductOKCPriceInfo = new HashSet<master_ProductOKCPriceInfo>();
        }
    
        public System.Guid ProductID { get; set; }
        public Nullable<int> ProductLineID { get; set; }
        public Nullable<int> ProductSmallTypeID { get; set; }
        public Nullable<int> ProductTypeID { get; set; }
        public string ArtNo { get; set; }
        public string ReagentProject { get; set; }
        public string ReagentSize { get; set; }
        public string ReagentTest { get; set; }
        public string RemarkDes { get; set; }
        public Nullable<bool> Is3C { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string ProductName { get; set; }
        public Nullable<bool> IsMaintenance { get; set; }
        public string StopReason { get; set; }
        public string CreateUser { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public string ModifyUser { get; set; }
        public Nullable<System.DateTime> ModifyTime { get; set; }
    
        public virtual master_ProductSmallType master_ProductSmallType { get; set; }
        public virtual master_ProductType master_ProductType { get; set; }
        public virtual master_ProductLine master_ProductLine { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<master_ProductPriceInfo> master_ProductPriceInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<master_ProductOKCPriceInfo> master_ProductOKCPriceInfo { get; set; }
    }
}