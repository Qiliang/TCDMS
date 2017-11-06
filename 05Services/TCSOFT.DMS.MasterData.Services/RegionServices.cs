using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TCSOFT.DMS.MasterData.Services
{
    using IServices;
    using AutoMapper;
    using Entities;
    using DTO.Area;
    using DTO.Common;
    public class RegionServices : BaseServices, IRegionServices
    {
        #region 大小区
        /// <summary>
        /// 大小区显示
        /// </summary>
        /// <param name="lngdto"></param>
        /// <returns></returns>
        public List<AreaResultDTO> GetAreaTree(AreaSearchDTO dto)
        {
            List<AreaResultDTO> result = new List<AreaResultDTO>();
            var tcdmse = SingleQueryObject.GetObj();

            int i = 0;
            var pp = tcdmse.master_AreaInfo.AsNoTracking().Where(p => p.AreaID != null);

            if (dto.DepartID != null)
            {
                pp = pp.Where(p => p.DepartID == dto.DepartID);
            }
            var qq = pp.ToList();
            var mm = qq.Where(p => p.AreaPID == null);
            foreach (var m in mm)
            {
                i++;
                AreaResultDTO One = new AreaResultDTO();
                One = Mapper.Map<master_AreaInfo, AreaResultDTO>(m);
                One.FictitiousID = i;
                One.children = new List<AreaResultDTO>();
                var nn = qq.Where(p => p.AreaPID == m.AreaID);
                foreach (var n in nn)
                {
                    i++;
                    AreaResultDTO Two = new AreaResultDTO();
                    Two = Mapper.Map<master_AreaInfo, AreaResultDTO>(n);
                    Two.FictitiousID = i;
                    One.children.Add(Two);
                    var ww = tcdmse.master_AreaRegionInfo.AsNoTracking().Where(w => w.AreaID == n.AreaID);
                    List<AreaResultDTO> region = null;
                    region = Mapper.Map<List<master_AreaRegionInfo>, List<AreaResultDTO>>(ww.ToList());
                    foreach (var r in region)
                    {
                        i++;
                        r.FictitiousID = i;
                        r.AreaPID = n.AreaID;
                    }
                    Two.children = region;
                }
                result.Add(One);
            }

            //if (dto.DepartID != null)
            //{
            //    List<int> Depat = new List<int>();
            //    UserAuthorityServices.GetDepare(tcdmse, Depat, dto.DepartID);
            //    Depat = Depat.Distinct().ToList();
            //    result = result.Where(p => Depat.Contains(p.DepartID.Value)).ToList();
            //}


            return result;
        }
        /// <summary>
        /// 大小区新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool AddArea(AreaOperateDTO dto)
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                if (dto.AreaPID == null)
                {
                    var dumplicated = tcdmse.master_AreaInfo.AsNoTracking().Where(p => p.DepartID == dto.DepartID && p.AreaPID == null && p.AreaName == dto.AreaName).FirstOrDefault();
                    if (dumplicated != null)
                    {
                        throw new Exception("相同部门下大区名称不可重复！");
                    }
                }
                else
                {
                    var dumplicated = tcdmse.master_AreaInfo.AsNoTracking().Where(p => p.AreaPID == dto.AreaPID && p.AreaName == dto.AreaName).FirstOrDefault();
                    if (dumplicated != null)
                    {
                        throw new Exception("相同大区下小区名称不可重复！");
                    }

                }

                master_AreaInfo addarea = new master_AreaInfo();
                Mapper.Map<AreaOperateDTO, master_AreaInfo>(dto, addarea);
                tcdmse.master_AreaInfo.Add(addarea);

                // 记录日志
                this.AddLog(tcdmse, new LogData
                {
                    CurrentLogType = LogType.ADD,
                    LogDetails = "新增大小区" + dto.AreaName,
                    OpratorName = dto.CreateUser
                });

                blResult = tcdmse.SaveChanges() > 0;
            }

            return blResult;
        }
        /// <summary>
        /// 大小区修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool UpdateArea(AreaOperateDTO dto)
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_AreaInfo.Where(p => p.AreaID == dto.AreaID).FirstOrDefault();
                if (pp != null)
                {
                    if (pp.AreaPID == null)
                    {
                        var dumplicated = tcdmse.master_AreaInfo.AsNoTracking().Where(p => p.DepartID == pp.DepartID && p.AreaPID == null && p.AreaName == dto.AreaName && p.AreaID != pp.AreaID).FirstOrDefault();
                        if (dumplicated != null)
                        {
                            throw new Exception("相同部门下大区名称不可重复！");
                        }
                    }
                    else
                    {
                        var dumplicated = tcdmse.master_AreaInfo.AsNoTracking().Where(p => p.AreaPID == pp.AreaPID && p.AreaID != pp.AreaID && p.AreaName == dto.AreaName).FirstOrDefault();
                        if (dumplicated != null)
                        {
                            throw new Exception("相同大区下小区名称不可重复！");
                        }

                    }

                    pp.AreaName = dto.AreaName;
                    pp.ModifyUser = dto.ModifyUser;
                    pp.ModifyTime = dto.ModifyTime;
                }

                blResult = tcdmse.SaveChanges() > 0;
                blResult = true;
            }

            return blResult;
        }
        /// <summary>
        /// 大小区删除
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool DeleteArea(AreaOperateDTO dto)
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_AreaInfo.Where(p => p.AreaID == dto.AreaID).FirstOrDefault();
                if (pp != null)
                {
                    var mm = tcdmse.master_DistributorRegionInfo.AsNoTracking().Where(m => m.AreaID == pp.AreaID || m.DistrictID == pp.AreaID).FirstOrDefault();
                    if (mm != null)
                    {
                        throw new Exception("此条信息已使用不可删除！");
                    }
                    var qq = tcdmse.master_AreaInfo.Where(q => q.AreaPID == pp.AreaID);
                    foreach (var q in qq)
                    {
                        var ww = tcdmse.master_AreaRegionInfo.Where(s => s.AreaID == q.AreaID);
                        tcdmse.master_AreaRegionInfo.RemoveRange(ww);
                    }
                    var qw = tcdmse.master_AreaRegionInfo.Where(s => s.AreaID == pp.AreaID);
                    tcdmse.master_AreaRegionInfo.RemoveRange(qw);

                    tcdmse.master_AreaInfo.RemoveRange(qq);
                    tcdmse.master_AreaInfo.Remove(pp);

                    // 记录日志
                    this.AddLog(tcdmse, new LogData
                    {
                        CurrentLogType = LogType.DELETE,
                        LogDetails = "删除大小区" + pp.AreaName,
                        OpratorName = dto.ModifyUser
                    });
                }

                blResult = tcdmse.SaveChanges() > 0;
            }

            return blResult;
        }
        /// <summary>
        /// 小区省份新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool AddAreaRegion(AreaOperateDTO dto)
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                foreach (var a in dto.RegionIDList)
                {
                    var pp = tcdmse.master_AreaRegionInfo.Where(p => p.AreaID == dto.AreaID && p.RegionID == a).FirstOrDefault();
                    if (pp == null)
                    {
                        master_AreaRegionInfo addarearegion = new master_AreaRegionInfo();
                        addarearegion.AreaID = dto.AreaID;
                        addarearegion.RegionID = a;

                        tcdmse.master_AreaRegionInfo.Add(addarearegion);
                    }
                }

                blResult = tcdmse.SaveChanges() > 0;
                blResult = true;
            }

            return blResult;
        }
        /// <summary>
        /// 小区省份修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool UpdateAreaRegion(AreaOperateDTO dto)
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_AreaRegionInfo.Where(p => p.AreaRegionID == dto.AreaRegionID).FirstOrDefault();
                if (pp != null)
                {
                    var qq = tcdmse.master_AreaRegionInfo.Where(p => p.AreaID == dto.AreaID && p.RegionID == dto.RegionID).FirstOrDefault();
                    if (qq == null)
                    {
                        pp.RegionID = dto.RegionID;
                    }
                }

                blResult = tcdmse.SaveChanges() > 0;
                blResult = true;
            }

            return blResult;
        }
        /// <summary>
        /// 小区省份删除
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool DeleteAreaRegion(AreaOperateDTO dto)
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_AreaRegionInfo.Where(p => p.AreaRegionID == dto.AreaRegionID).FirstOrDefault();
                if (pp != null)
                {
                    var mm = tcdmse.master_DistributorRegionInfo.AsNoTracking().Where(m => m.RegionID == pp.RegionID && m.DistrictID == pp.AreaID).FirstOrDefault();
                    if (mm != null)
                    {
                        throw new Exception("此条信息已使用不可删除！");
                    }

                    tcdmse.master_AreaRegionInfo.Remove(pp);
                }

                blResult = tcdmse.SaveChanges() > 0;
            }

            return blResult;
        }
        /// <summary>
        /// 大区
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public List<AreaResultDTO> GetArea()
        {
            List<AreaResultDTO> result = new List<AreaResultDTO>();
            var tcdmse = SingleQueryObject.GetObj();

            var pp = tcdmse.master_AreaInfo.AsNoTracking().Where(p => p.AreaPID == null).ToList();
            result = Mapper.Map<List<master_AreaInfo>, List<AreaResultDTO>>(pp);

            return result;
        }
        #endregion
        #region 行政区划
        /// <summary>
        /// 所有行政区划
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public List<RegionResultDTO> GetRegionList()
        {
            var result = new List<RegionResultDTO>();
            var tcdmse = SingleQueryObject.GetObj();

            var list = tcdmse.dict_RegionInfo.AsNoTracking().ToList();
            result = Mapper.Map<List<dict_RegionInfo>, List<RegionResultDTO>>(list);

            return result;
        }
        /// <summary>
        /// 新增行政区划
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool AddRegion(RegionOperateDTO dto)
        {
            var result = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var dumplicated = tcdmse.dict_RegionInfo.AsNoTracking().Where(p => p.RegionPID == dto.RegionPID && p.RegionName == dto.RegionName).FirstOrDefault();
                if (dumplicated != null)
                {
                    throw new Exception("新增行政区域不可同名！");
                }
                var newregion = new dict_RegionInfo();
                newregion = Mapper.Map<RegionOperateDTO, dict_RegionInfo>(dto);
                tcdmse.dict_RegionInfo.Add(newregion);
                result = tcdmse.SaveChanges() > 0;
            }

            return result;
        }
        /// <summary>
        /// 修改行政区划信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool UpdateRegion(RegionOperateDTO dto)
        {
            var result = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.dict_RegionInfo.Where(p => p.RegionID == dto.RegionID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在！");
                }
                var dumplicated = tcdmse.dict_RegionInfo.AsNoTracking().Where(p => p.RegionPID == dto.RegionPID && p.RegionID != dto.RegionID && p.RegionName == dto.RegionName).FirstOrDefault();
                if (dumplicated != null)
                {
                    throw new Exception("修改行政区域不可同名！");
                }
                Mapper.Map<RegionOperateDTO, dict_RegionInfo>(dto, pp);
                result = tcdmse.SaveChanges() > 0;
            }

            return result;
        }
        /// <summary>
        /// 删除行政区划
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool DeleteRegion(RegionSearchDTO dto)
        {
            var result = false;
            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                HashSet<int> hs = new HashSet<int>();
                var aa = tcdmse.master_AreaRegionInfo.AsNoTracking().Select(m => m.RegionID).Distinct().ToList();//区域省份信息
                var bb = tcdmse.master_DistributorInfo.AsNoTracking().Select(m => m.RegionID).Distinct().ToList();//经销商注册省份ID
                var cc = tcdmse.master_DistributorRegionInfo.AsNoTracking().Select(m => m.RegionID).Distinct().ToList();//经销商授权区域信息区域ID
                var ss = aa.Union(bb).Union(cc).ToList();
                if (ss.Count > 0)
                {
                    foreach (int s in ss)
                    {
                        if (!hs.Contains(s))
                        {
                            hs.Add(s);
                        }
                    }
                }

                var regionlist = tcdmse.dict_RegionInfo.AsNoTracking().ToList();
                //客户信息
                var cuslist = tcdmse.master_CustomerInfo.AsNoTracking().Select(m => new
                {
                    Province = m.Province,
                    City = m.City,
                    Country = m.Country
                }).Distinct().ToList();
                if (cuslist.Count > 0)
                {
                    foreach (var cus in cuslist)
                    {
                        var provinceid = regionlist.Where(m => m.RegionName == cus.Province).Select(m => m.RegionID).FirstOrDefault();
                        if (!hs.Contains(provinceid))
                        {
                            hs.Add(provinceid);
                        }
                        var cityid = regionlist.Where(m => m.RegionName == cus.City && m.RegionPID == provinceid).Select(m => m.RegionID).FirstOrDefault();
                        if (!hs.Contains(cityid))
                        {
                            hs.Add(cityid);
                        }
                        var countryid = regionlist.Where(m => m.RegionName == cus.Country && m.RegionPID == cityid).Select(m => m.RegionID).FirstOrDefault();
                        if (!hs.Contains(countryid))
                        {
                            hs.Add(countryid);
                        }
                    }
                }
                //客户申请信息
                var cusapplylist = tcdmse.master_CustomerApplyInfo.AsNoTracking().Select(m => new
                {
                    Province = m.Province,
                    City = m.City,
                    Country = m.Country
                }).Distinct().ToList();
                if (cusapplylist.Count > 0)
                {
                    foreach (var cus in cusapplylist)
                    {
                        var provinceid = regionlist.Where(m => m.RegionName == cus.Province).Select(m => m.RegionID).FirstOrDefault();
                        if (!hs.Contains(provinceid))
                        {
                            hs.Add(provinceid);
                        }
                        var cityid = regionlist.Where(m => m.RegionName == cus.City && m.RegionPID == provinceid).Select(m => m.RegionID).FirstOrDefault();
                        if (!hs.Contains(cityid))
                        {
                            hs.Add(cityid);
                        }
                        var countryid = regionlist.Where(m => m.RegionName == cus.Country && m.RegionPID == cityid).Select(m => m.RegionID).FirstOrDefault();
                        if (!hs.Contains(countryid))
                        {
                            hs.Add(countryid);
                        }
                    }
                }
                var pp = tcdmse.dict_RegionInfo.Where(p => p.RegionID == dto.RegionID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在！");
                }
                if (hs.Contains(pp.RegionID))
                {
                    throw new Exception("此条信息已使用不可删除！");
                }
                RemoveAllChild(tcdmse, pp, hs);

                tcdmse.dict_RegionInfo.Remove(pp);

                result = tcdmse.SaveChanges() > 0;
            }

            return result;
        }

        private void RemoveAllChild(TCDMS_MasterDataEntities tcdmse, dict_RegionInfo dict, HashSet<int> idset)
        {
            var child = tcdmse.dict_RegionInfo.Where(p => p.RegionPID == dict.RegionID);
            foreach (var p in child)
            {
                if (idset.Contains(p.RegionID))
                {
                    throw new Exception("此条信息已使用不可删除！");
                }
                RemoveAllChild(tcdmse, p, idset);
            }
            tcdmse.dict_RegionInfo.RemoveRange(child);
        }

        #endregion
    }
}
