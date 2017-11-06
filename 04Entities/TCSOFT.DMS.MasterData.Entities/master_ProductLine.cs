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
    
    public partial class master_ProductLine
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public master_ProductLine()
        {
            this.master_DistributorADInfo = new HashSet<master_DistributorADInfo>();
            this.master_DistributorProductLineInfo = new HashSet<master_DistributorProductLineInfo>();
            this.master_ProductInfo = new HashSet<master_ProductInfo>();
            this.master_ProductSmallType = new HashSet<master_ProductSmallType>();
            this.master_ProductModel = new HashSet<master_ProductModel>();
        }
    
        public int ProductLineID { get; set; }
        public Nullable<int> DepartID { get; set; }
        public string ProductLineName { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string ProductLineNameAB { get; set; }
        public string CreateUser { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public string ModifyUser { get; set; }
        public Nullable<System.DateTime> ModifyTime { get; set; }
    
        public virtual master_DepartmentInfo master_DepartmentInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<master_DistributorADInfo> master_DistributorADInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<master_DistributorProductLineInfo> master_DistributorProductLineInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<master_ProductInfo> master_ProductInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<master_ProductSmallType> master_ProductSmallType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<master_ProductModel> master_ProductModel { get; set; }
    }
}