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
    
    public partial class master_AreaInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public master_AreaInfo()
        {
            this.master_AreaRegionInfo = new HashSet<master_AreaRegionInfo>();
            this.master_UserInfo = new HashSet<master_UserInfo>();
        }
    
        public int AreaID { get; set; }
        public Nullable<int> DepartID { get; set; }
        public Nullable<int> AreaPID { get; set; }
        public string AreaName { get; set; }
        public string AreaPath { get; set; }
        public string CreateUser { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public string ModifyUser { get; set; }
        public Nullable<System.DateTime> ModifyTime { get; set; }
    
        public virtual master_DepartmentInfo master_DepartmentInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<master_AreaRegionInfo> master_AreaRegionInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<master_UserInfo> master_UserInfo { get; set; }
    }
}
