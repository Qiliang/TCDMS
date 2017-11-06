using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.Document.DTO
{
    public class UserQueryDTO
    {
        public int UserID { get; set; }
        public string UserCode { get; set; }
        public int? ProductLineID { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public short? UserType { get; set; }
    }
}
