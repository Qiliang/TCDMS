using FluentScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCSOFT.DMS.Fcpa.Entities;

namespace TCSOFT.DMS.Fcpa.Services.Jobs
{
    public class DistributorJob : IJob
    {    

        public void Execute()
        {        
            using (var fcpa = new TCDMS_FCPAEntities())
            {
                using (var master = new TCDMS_MasterDataEntities())
                {
                    const string sql = "SELECT distinct DistributorID,DistributorName,AreaName,[RegionName] FROM master_DistributorInfo  INNER JOIN master_DistributorRegionInfo  ON master_DistributorRegionInfo.RegionID = master_DistributorInfo.RegionID INNER JOIN master_AreaInfo ON master_AreaInfo.AreaID = master_DistributorRegionInfo.AreaID INNER JOIN [dict_RegionInfo] ON master_DistributorRegionInfo.RegionID=[dict_RegionInfo].RegionID";
                    var result = master.Database.SqlQuery<SyncDistributorModel>(sql);

                    result.ToList().ForEach(item =>
                    {
                        var distributor = fcpa.fcpa_DistributorInfo.Find(item.DistributorID.ToString());
                        if (distributor != null)
                        {
                            distributor.DistributorName = item.DistributorName;
                            distributor.AreaName = item.AreaName;
                            distributor.RegionName = item.RegionName;
                        }
                        else
                        {
                            fcpa.fcpa_DistributorInfo.Add(new fcpa_DistributorInfo
                            {
                                DistributorID = item.DistributorID.ToString(),
                                DistributorName = item.DistributorName,
                                AreaName = item.AreaName,
                                RegionName = item.RegionName
                            });
                        }

                    });
                }

                fcpa.SaveChanges();

            }
        }

        class SyncDistributorModel
        {
            public Guid DistributorID { get; set; }
            public string DistributorName { get; set; }
            public string AreaName { get; set; }
            public string RegionName { get; set; }

        }

    }
}