using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.Document.DTO
{
    public class UserInfoDTO
    {       
        public int UserType { get; set; }
        public int[] ProductLineIDs { get; set; }     
        public int UserID { get; set; }
        public string FullName { get; set; }
    }
}
