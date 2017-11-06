using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.Document.DTO
{
    public class QueryDTO: DocumentDTO
    {
        public int? page { get; set; }
        public int? rows { get; set; }
        public int Skip { get; set; }
        public string OrderBy { get; set; }
        public bool? Ascending { get; set; }

        public string ThenBy { get; set; }
        public bool? ThenAscending
        {
            get; set;
        }
    }
}
