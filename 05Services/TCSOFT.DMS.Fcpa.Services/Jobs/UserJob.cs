using FluentScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCSOFT.DMS.Fcpa.DTO.User;
using TCSOFT.DMS.Fcpa.Entities;

namespace TCSOFT.DMS.Fcpa.Services.Jobs
{
    public class UserJob : IJob
    {

        public void Execute()
        {
            using (var fcpa = new TCDMS_FCPAEntities())
            {
                using (var master = new TCDMS_MasterDataEntities())
                {
                    string sql = "SELECT master_UserInfo.*, master_DistributorUserInfo.DistributorID FROM master_UserInfo INNER JOIN master_UserRoleInfo ON master_UserInfo.UserID = master_UserRoleInfo.UserID  LEFT OUTER JOIN master_DistributorUserInfo ON  master_UserInfo.UserID = master_DistributorUserInfo.UserID LEFT OUTER JOIN master_DepartmentInfo ON master_UserInfo.DepartID = master_DepartmentInfo.DepartID";

                    master.Database.SqlQuery<UserJobDTO>(sql).ToList()
                        .GroupBy(p => p.UserID).Select(p => new { Key = p.Key, Value = p }).ToList().ForEach(res =>
                             {
                                 var userInfo = res.Value.First();
                                 var user = fcpa.fcpa_UserInfo.Find(userInfo.UserID);
                                 if (user == null)
                                 {
                                     fcpa.fcpa_UserInfo.Add(new fcpa_UserInfo
                                     {
                                         UserID = userInfo.UserID,
                                         UserCode = userInfo.UserCode,
                                         FullName = userInfo.FullName,
                                         PhoneNumber = userInfo.PhoneNumber,
                                         DynamicPassword = userInfo.DynamicPassword,
                                         EffectiveTtime = userInfo.EffectiveTtime,
                                         StopTime = userInfo.StopTime,
                                         Email = userInfo.Email,
                                         UserType = userInfo.UserType,
                                         AuditName = userInfo.AuditName,
                                         IsActive = userInfo.IsActive,
                                         NoActiveTime = userInfo.NoActiveTime,
                                         CreateUser = userInfo.CreateUser,
                                         CreateTime = userInfo.CreateTime,
                                         ModifyUser = userInfo.ModifyUser,
                                         ModifyTime = userInfo.ModifyTime,
                                         RelDistributor = string.Join(",", res.Value.Where(p => p.DistributorID != null).Select(p => p.DistributorID.Value.ToString()).Distinct()),
                                         Domain1 = res.Value.Where(p => p.DepartID == 1).Any(),
                                         Domain2 = res.Value.Where(p => p.DepartID == 2).Any(),
                                         Role = userInfo.UserType.HasValue ? userInfo.UserType.Value : 0,
                                     });
                                 }
                                 else
                                 {
                                     user.UserCode = userInfo.UserCode;
                                     user.FullName = userInfo.FullName;
                                     user.PhoneNumber = userInfo.PhoneNumber;
                                     user.DynamicPassword = userInfo.DynamicPassword;
                                     user.EffectiveTtime = userInfo.EffectiveTtime;
                                     user.StopTime = userInfo.StopTime;
                                     user.Email = userInfo.Email;
                                     user.UserType = userInfo.UserType;
                                     user.AuditName = userInfo.AuditName;
                                     user.IsActive = userInfo.IsActive;
                                     user.NoActiveTime = userInfo.NoActiveTime;
                                     user.CreateUser = userInfo.CreateUser;
                                     user.CreateTime = userInfo.CreateTime;
                                     user.ModifyUser = userInfo.ModifyUser;
                                     user.ModifyTime = userInfo.ModifyTime;
                                     user.RelDistributor = string.Join(",", res.Value.Where(p => p.DistributorID != null).Select(p => p.DistributorID.Value.ToString()).Distinct());
                                     user.Domain1 = res.Value.Where(p => p.DepartID == 1).Any();
                                     user.Domain2 = res.Value.Where(p => p.DepartID == 2).Any();
                                     user.Role = userInfo.UserType.HasValue ? userInfo.UserType.Value : 0;
                                 }

                             });
                }

                fcpa.SaveChanges();

            }
        }
    }
}