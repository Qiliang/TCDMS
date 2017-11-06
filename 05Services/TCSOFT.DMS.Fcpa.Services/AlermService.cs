using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCSOFT.DMS.Fcpa.DTO;
using TCSOFT.DMS.Fcpa.DTO.Alerm;
using TCSOFT.DMS.Fcpa.IServices;

namespace TCSOFT.DMS.Fcpa.Services
{
    public class AlermService:BaseService, IAlermService
    {
           
            public PageableDTO<AlermResultDTO> Query(AlermSearchDTO q)
            {
                q.InitQuery("AlarmTime", false);
                var roles = q.Role.ToIntArray();
                var res = fcpa.fcpa_AlarmInfo.Where(p =>
                 (string.IsNullOrEmpty(q.UserCode) ? true : p.fcpa_UserInfo.UserCode.Contains(q.UserCode))
                 && (string.IsNullOrEmpty(q.FullName) ? true : p.fcpa_UserInfo.FullName.Contains(q.FullName))
                 && (string.IsNullOrEmpty(q.PhoneNumber) ? true : p.fcpa_UserInfo.PhoneNumber.Contains(q.PhoneNumber))
                 && (string.IsNullOrEmpty(q.Email) ? true : p.fcpa_UserInfo.Email.Contains(q.Email))
                 && (q.Domain1.HasValue ? p.fcpa_UserInfo.Domain1 == q.Domain1 : true)
                 && (q.Domain2.HasValue ? p.fcpa_UserInfo.Domain2 == q.Domain2 : true)
                 && (string.IsNullOrEmpty(q.Role) ? true : roles.Any(a => p.fcpa_UserInfo.Role == a))
                 && (string.IsNullOrEmpty(q.RelDistributor) ? true : p.fcpa_UserInfo.RelDistributor.Contains(q.RelDistributor))
                 && (q.AlarmTimeFrom.HasValue ? p.AlarmTime >= q.AlarmTimeFrom : true)
                 && (q.AlarmTimeTo.HasValue ? p.AlarmTime <= q.AlarmTimeTo : true)
                ).Select(p => new AlermResultDTO
                {
                    ID = p.ID,
                    UserCode = p.fcpa_UserInfo.UserCode,
                    FullName = p.fcpa_UserInfo.FullName,
                    PhoneNumber = p.fcpa_UserInfo.PhoneNumber,
                    Email = p.fcpa_UserInfo.Email,
                    Domain1 = p.fcpa_UserInfo.Domain1,
                    Domain2 = p.fcpa_UserInfo.Domain2,
                    Role = p.fcpa_UserInfo.Role,
                    RelDistributor = p.fcpa_UserInfo.RelDistributor,
                    AlarmTime = p.AlarmTime
                })
                .ToPageable(q);
            
                res.rows.ForEach(p =>
                {
                    p.RoleDesc = Const.Role(p.Role);
                    p.RelDistributorDesc = Const.RelDistributor(p.RelDistributor, fcpa);
                    p.DomainDesc = Const.Domain(p.Domain1, p.Domain2);

                });

                return res;
            }
        }
}
