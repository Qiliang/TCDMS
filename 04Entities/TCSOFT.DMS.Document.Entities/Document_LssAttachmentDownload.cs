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
    
    public partial class Document_LssAttachmentDownload
    {
        public int UserID { get; set; }
        public Nullable<System.Guid> LssID { get; set; }
        public Nullable<bool> IsDownload { get; set; }
    
        public virtual Document_Lss Document_Lss { get; set; }
    }
}