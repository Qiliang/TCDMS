using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.Fcpa.DTO.Credential
{
    public class DistributorResultDTO : FcpaDTO
    {
        public string DistributorID { get; set; }
        public string DistributorName { get; set; }
        public string AreaName { get; set; }
        public string RegionName { get; set; }
        public string OrgMap { get; set; }
        public string OrgMapFile { get; set; }
        public string Trains { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<System.DateTime> OrgMapUpdateTime { get; set; }
        public Nullable<System.DateTime> TrainsUpdateTime { get; set; }
        public Nullable<int> ValidNum { get; set; }
        public Nullable<int> ShouldNum { get; set; }
        public Nullable<double> Rate { get; set; }
        public Nullable<bool> Domain1 { get; set; }
        public Nullable<bool> Domain2 { get; set; }
    }
}
