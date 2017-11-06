using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.Fcpa.DTO.Alerm
{
    public class AlermResultDTO: FcpaDTO
    {
        public Guid ID { get; set; }
        public string UserCode { get; set; } //用户代号 
        public string FullName { get; set; }//用户名称 
        public string PhoneNumber { get; set; }//手机号 
        public string Email { get; set; }//邮箱 
        public bool? Domain1 { get; set; }//所属领域--临床诊断
        public bool? Domain2 { get; set; }//所属领域--生命科学 
        public string DomainDesc { get; set; }
        public int? Role { get; set; }//角色 
        public string RoleDesc { get; set; }
        public string RelDistributor { get; set; }//关联经销商 
        public string RelDistributorDesc { get; set; }
        public DateTime? AlarmTime { get; set; }//提醒日期 
    }
}
