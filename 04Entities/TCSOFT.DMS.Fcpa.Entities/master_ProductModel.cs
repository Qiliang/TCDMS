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
    
    public partial class master_ProductModel
    {
        public int ProductModelID { get; set; }
        public Nullable<int> ProductLineID { get; set; }
        public string ProductModelName { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string CreateUser { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public string ModifyUser { get; set; }
        public Nullable<System.DateTime> ModifyTime { get; set; }
    
        public virtual master_ProductLine master_ProductLine { get; set; }
    }
}
