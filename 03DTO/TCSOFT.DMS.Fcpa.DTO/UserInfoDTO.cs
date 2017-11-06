using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.Fcpa.DTO
{
    public class UserInfoDTO
    {       
        public int Role { get; set; }
        public string[] DistributorIDs { get; set; }     
        public bool Domain1 { get; set; }
        public bool Domain2 { get; set; }
    }
}
