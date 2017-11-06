using FluentScheduler;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TCSOFT.DMS.Fcpa.Entities;

namespace TCSOFT.DMS.Fcpa.Services.Jobs
{
    /// <summary>
    ///1.提醒功能分为：邮件和短信提醒
    ///2.提醒对象：经销商
    ///3.提醒的时间：每天上午9点
    ///4.提醒频率分为两种：
    ///一种是针对未完成的证书（未完成的证书需在2周内完成），所以：未完成的证书在新建后的第7天开始，每天提醒；
    ///一种是针对老证书的：过期日期提前28天提醒一次，14天后再提醒一次，最后7天内每天提醒，过期后一个月内每天提醒（过期后超过一个月，则不再提醒）；
    ///若期间证书的状态发生变化：如变成新更新、不更新，则针对当前证书不再提醒；
    /// </summary>
    public class AlermJob : IJob
    {
      
        public void Execute()
        {          
            var distributorUsers = new List<DistributorUserInfo>();
            using (var master = new TCDMS_MasterDataEntities())
            {
                distributorUsers.AddRange(master.Database.SqlQuery<DistributorUserInfo>("select DistributorID,master_UserInfo.UserID,master_UserInfo.Email,master_UserInfo.FullName,master_UserInfo.PhoneNumber from master_DistributorUserInfo inner join master_UserInfo on master_DistributorUserInfo.UserID=master_UserInfo.UserID").ToList());
            }

            using (var fcpa = new TCDMS_FCPAEntities())
            {
                //未完成
               var ss= fcpa.fcpa_DistributorInfo.Where(p => p.fcpa_CredentialInfo.Any(c => c.Status == 3)).ToList();
                fcpa.fcpa_DistributorInfo.Where(p => p.fcpa_CredentialInfo.Any(c => c.Status == 3)).ToList().ForEach(item =>
                {
                    distributorUsers.Where(p => p.DistributorID.ToString() == item.DistributorID).ToList().ForEach(user =>
                    {
                        fcpa.fcpa_AlarmInfo.Add(new fcpa_AlarmInfo
                        {
                            fcpa_UserInfo = fcpa.fcpa_UserInfo.Find(user.UserID),
                            AlarmTime = DateTime.Now,
                            ID = Guid.NewGuid()

                        });
                    });

                });
                fcpa.SaveChanges();
                //快过期
                fcpa.fcpa_DistributorInfo.Where(p => p.fcpa_CredentialInfo.Any(c => c.Status == 2)).ToList().ForEach(item =>
                {
                    distributorUsers.Where(p => p.DistributorID.ToString() == item.DistributorID).ToList().ForEach(user =>
                    {
                        fcpa.fcpa_AlarmInfo.Add(new fcpa_AlarmInfo
                        {
                            fcpa_UserInfo = fcpa.fcpa_UserInfo.Find(user.UserID),
                            AlarmTime = DateTime.Now,
                            ID = Guid.NewGuid()

                        });
                    });

                });

                fcpa.SaveChanges();

            }

        }

        class DistributorUserInfo
        {
            public Guid DistributorID { get; set; }
            public int UserID { get; set; }
            public string Email { get; set; }
            public string FullName { get; set; }
            public string PhoneNumber { get; set; }
        }


    }
}