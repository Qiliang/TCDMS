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
    
    public partial class dict_RegionInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public dict_RegionInfo()
        {
            this.master_AreaRegionInfo = new HashSet<master_AreaRegionInfo>();
            this.master_DistributorInfo = new HashSet<master_DistributorInfo>();
        }
    
        public int RegionID { get; set; }
        public Nullable<int> RegionPID { get; set; }
        public string RegionName { get; set; }
        public string RegionCode { get; set; }
        public Nullable<int> RegionLevel { get; set; }
        public string CreateUser { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public string ModifyUser { get; set; }
        public Nullable<System.DateTime> ModifyTime { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<master_AreaRegionInfo> master_AreaRegionInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<master_DistributorInfo> master_DistributorInfo { get; set; }
    }
}
