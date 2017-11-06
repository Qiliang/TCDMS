using FluentScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCSOFT.DMS.Fcpa.Entities;

namespace TCSOFT.DMS.Fcpa.Services.Jobs
{
    public class OrgJob : IJob
    {
        public void Execute()
        {        
            using (var fcpa = new TCDMS_FCPAEntities())
            {
                var distributorGroup = fcpa.fcpa_CredentialInfo.Where(p => !string.IsNullOrEmpty(p.Certificate)).GroupBy(p => p.fcpa_DistributorInfo.DistributorID).Select(p => new { Count = p.Count(), DistributorID = p.Key }).ToList();

                fcpa.fcpa_DistributorInfo.ToList().ForEach(item =>
                {
                    item.ValidNum = distributorGroup.Where(p => p.DistributorID == item.DistributorID).Select(p => p.Count).FirstOrDefault();
                    if (item.ValidNum.HasValue && item.ShouldNum.HasValue)
                        item.Rate = Math.Floor((item.ValidNum * 1.0 / item.ShouldNum * 100).Value);
                });

                fcpa.SaveChanges();

            }
        }
    }
}