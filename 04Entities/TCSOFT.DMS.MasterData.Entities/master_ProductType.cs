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
    
    public partial class master_ProductType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public master_ProductType()
        {
            this.master_ProductInfo = new HashSet<master_ProductInfo>();
        }
    
        public int ProductTypeID { get; set; }
        public string ProductTypeName { get; set; }
        public string OracleName { get; set; }
        public string ProductTypeAB { get; set; }
        public string CreateUser { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public string ModifyUser { get; set; }
        public Nullable<System.DateTime> ModifyTime { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<master_ProductInfo> master_ProductInfo { get; set; }
    }
}
