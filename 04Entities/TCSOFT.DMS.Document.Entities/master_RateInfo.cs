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
    
    public partial class master_RateInfo
    {
        public int RateID { get; set; }
        public string Currency { get; set; }
        public string RateCode { get; set; }
        public Nullable<short> RateYear { get; set; }
        public Nullable<decimal> RateBudget { get; set; }
        public Nullable<decimal> MonthRate { get; set; }
        public Nullable<decimal> FebRate { get; set; }
        public Nullable<decimal> MarchRate { get; set; }
        public Nullable<decimal> AprilRate { get; set; }
        public Nullable<decimal> MayRate { get; set; }
        public Nullable<decimal> JuneRate { get; set; }
        public Nullable<decimal> JulyRate { get; set; }
        public Nullable<decimal> AugustRate { get; set; }
        public Nullable<decimal> SepRate { get; set; }
        public Nullable<decimal> OctRate { get; set; }
        public Nullable<decimal> NovRate { get; set; }
        public Nullable<decimal> DecRate { get; set; }
        public string CreateUser { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public string ModifyUser { get; set; }
        public Nullable<System.DateTime> ModifyTime { get; set; }
    }
}