using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCSOFT.DMS.Fcpa.DTO;
using TCSOFT.DMS.Fcpa.DTO.Org;
using TCSOFT.DMS.Fcpa.IServices;

namespace TCSOFT.DMS.Fcpa.Services
{
    public class OrgMapService : BaseService, IOrgMapService
    {
        public OrgResultDTO Get(string id)
        {
            var p = fcpa.fcpa_DistributorInfo.Find(id);
            return new OrgResultDTO
            {
                ID = p.DistributorID,
                DistributorName = p.DistributorName,
                OrgMap = p.OrgMap,
                Trains = p.Trains,
                OrgMapUpdateTime = p.OrgMapUpdateTime,
                TrainsUpdateTime = p.TrainsUpdateTime,
                ValidNum = p.ValidNum,
                ShouldNum = p.ShouldNum,
                Rate = p.Rate,
                OrgMapFile = p.OrgMapFile
        };
    }


    public PageableDTO<OrgResultDTO> Query(OrgSearchDTO q)
    {
        var token = q.UserInfo;
        q.InitQuery("ID", false);
        var status = q.Status.ToIntArray();
        return fcpa.fcpa_DistributorInfo.Where(p =>
        (string.IsNullOrEmpty(q.DistributorName) ? true : p.DistributorName.Contains(q.DistributorName))
        && (string.IsNullOrEmpty(q.Status) ? true : status.Any(a => p.Status == a))
        ).Where(p => token.Role == 0 ? true : token.DistributorIDs.Contains(p.DistributorID))
        .Select(p => new OrgResultDTO
        {
            ID = p.DistributorID,
            DistributorName = p.DistributorName,
            OrgMap = p.OrgMap,
            Trains = p.Trains,
            OrgMapUpdateTime = p.OrgMapUpdateTime,
            TrainsUpdateTime = p.TrainsUpdateTime,
            ValidNum = p.ValidNum,
            ShouldNum = p.ShouldNum,
            Rate = p.Rate
        })
        .ToPageable(q);
    }
}
}
