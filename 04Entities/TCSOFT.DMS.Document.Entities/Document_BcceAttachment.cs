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
    
    public partial class Document_BcceAttachment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Document_BcceAttachment()
        {
            this.Document_BcceAttachmentDownload = new HashSet<Document_BcceAttachmentDownload>();
        }
    
        public System.Guid AttachmentID { get; set; }
        public string AttachmentName { get; set; }
        public Nullable<int> AttachmentSize { get; set; }
        public Nullable<System.Guid> BcceID { get; set; }
    
        public virtual Document_Bcce Document_Bcce { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Document_BcceAttachmentDownload> Document_BcceAttachmentDownload { get; set; }
    }
}
