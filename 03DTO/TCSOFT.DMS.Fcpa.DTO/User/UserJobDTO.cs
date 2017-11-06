using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.Fcpa.DTO.User
{
    public class UserJobDTO
    {
        public int UserID { get; set; }
        public int? DepartID { get; set; }
        public string UserCode { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string DynamicPassword { get; set; }
        public DateTime? EffectiveTtime { get; set; }
        public DateTime? StopTime { get; set; }
        public string Email { get; set; }
        public short? UserType { get; set; }
        public string AuditName { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? NoActiveTime { get; set; }
        public string CreateUser { get; set; }
        public DateTime? CreateTime { get; set; }
        public string ModifyUser { get; set; }
        public DateTime? ModifyTime { get; set; }
        public Guid? DistributorID { get; set; }
    }
}
