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
    
    public partial class master_DistributorOKCInfo
    {
        public int DistributorOKCID { get; set; }
        public Nullable<System.Guid> DistributorID { get; set; }
        public Nullable<int> OKCID { get; set; }
        public Nullable<System.Guid> CustomerID { get; set; }
    
        public virtual master_CustomerInfo master_CustomerInfo { get; set; }
        public virtual master_DistributorInfo master_DistributorInfo { get; set; }
        public virtual master_OKCInfo master_OKCInfo { get; set; }
    }
}
