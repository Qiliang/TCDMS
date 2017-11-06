using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.Fcpa.DTO.Fcpa
{
    public class FcpaSearchDTO : QueryDTO
    {
        public string DistributorID { get; set; }
        public string Status { get; set; }
        public int? Year { get; set; }
        public string Area { get; set; }
        public string Region { get; set; }

        public string DistributorName { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Title { get; set; }
        public DateTime? CompletedDateFrom { get; set; }
        public DateTime? CompletedDateTo { get; set; }
        public DateTime? UpdateDateFrom { get; set; }
        public DateTime? UpdateDateTo { get; set; }
        public string OffWork { get; set; }
        public bool? Domain1 { get; set; }
        public bool? Domain2 { get; set; }
        public string Remark { get; set; }
        public string UserDistributorIDs { get; set; }
    }
}
