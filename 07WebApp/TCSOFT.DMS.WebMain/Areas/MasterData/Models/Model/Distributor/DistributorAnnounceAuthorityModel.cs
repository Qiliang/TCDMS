using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCSOFT.DMS.WebMain.Areas.MasterData.Models.Model.Distributor
{
    using TCSOFT.DMS.MasterData.DTO.Distributor.DistributorAnnounceAuthority;
    public class DistributorAnnounceAuthorityModel : DistributorAnnounceAuthorityResultDTO
    {
        public string ProductLineNames
        {
            get
            {
                var result = string.Empty;
                if (ProductLineList.Count > 0)
                {
                    result = string.Join(",", ProductLineList.Select(m => m.ProductLineName).ToList());
                }
                return result;
            }
        }
        public List<int> ProductLineIDList
        {
            get 
            {
                List<int> result = new List<int>();
                if (ProductLineList.Count > 0)
                {
                    foreach (var qq in ProductLineList.Select(m => m.ProductLineID).ToList())
                    {
                        result.Add(qq);
                    }
                }
                return result;
            }
        }

    }
}