using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO
{
    [DataContract]
    public class StructureDTO
    {
        [DataMember]
        public string StructureID { get; set; }
        [DataMember]
        public string ParentStructureID { get; set; }
        [DataMember]
        public string StructureName { get; set; }
        [DataMember]
        public bool IsVisible { get; set; }
        [DataMember]
        public int IndexCode { get; set; }
        [DataMember]
        public string URL { get; set; }
        [DataMember]
        public int BelongButton { get; set; }
        [DataMember]
        public string DesImage { get; set; }
        [DataMember]
        public string Description { get; set; }
    }
}
