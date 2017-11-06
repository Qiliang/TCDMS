using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCSOFT.DMS.MasterData.DTO.Common;
using TCSOFT.DMS.UserApply.DTO.ImportExcel;
using TCSOFT.DMS.UserApply.DTO.User.UserApply;
using TCSOFT.DMS.UserApply.Entities;
using TCSOFT.DMS.UserApply.IServices;

namespace TCSOFT.DMS.UserApply.Services
{
    public class UserApplyServices : IUserApplyServices, IImportDataServices
    {
        #region 用户申请
        /// <summary>
        /// 查询申请的批次
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public List<UserApplyBatchResultDTO> GetApplyBatchUser(UserApplySearchDTO dto)
        {
            List<UserApplyBatchResultDTO> result = null;
            var tcdmse = SingleQueryObject.GetObj();
            var pp = tcdmse.UserApply_ApplyBatch.AsNoTracking().Where(p => p.AuditStatus == 0 || p.AuditStatus == 1 || p.AuditStatus == 3);

            if (dto.DistributorID != null)
            {
                pp = pp.Where(p => p.DistributorID.Contains(dto.DistributorID.Value.ToString()));
            }
            if (dto.BatchID != null)
            {
                pp = tcdmse.UserApply_ApplyBatch.AsNoTracking().Where(p => p.BatchID == dto.BatchID);
            }

            dto.Count = pp.Count();
            var aa = pp.OrderByDescending(o => o.CreateTime).ThenByDescending(t => t.BatchID).Skip((dto.page - 1) * dto.rows).Take(dto.rows).ToList();

            result = Mapper.Map<List<UserApply_ApplyBatch>, List<UserApplyBatchResultDTO>>(aa.ToList());

            return result;
        }
        /// <summary>
        /// 查询申请的用户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public List<UserApplyUserResultDTO> GetApplyUser(UserApplySearchDTO dto)
        {
            List<UserApplyUserResultDTO> result = null;
            var tcdmse = SingleQueryObject.GetObj();
            var pp = tcdmse.UserApply_UserApplyInfo.AsNoTracking().Where(p => p.UserApplyID != null);

            if (dto.BatchID != null)
            {
                pp = pp.Where(p => p.BatchID == dto.BatchID);
            }

            result = Mapper.Map<List<UserApply_UserApplyInfo>, List<UserApplyUserResultDTO>>(pp.ToList());

            return result;
        }
        /// <summary>
        /// 保存批次及用户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool AddApplyUser(BatchApplyOperateDTO dto)
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_UserApplyEntities())
            {
                UserApply_ApplyBatch batch = null;
                var pp = tcdmse.UserApply_ApplyBatch.Where(p => p.BatchID == dto.BatchID).FirstOrDefault();
                if (pp == null)
                {
                    batch = new UserApply_ApplyBatch();
                    Mapper.Map<BatchApplyOperateDTO, UserApply_ApplyBatch>(dto, batch);
                    tcdmse.UserApply_ApplyBatch.Add(batch);
                }
                else
                {
                    pp.AuditStatus = dto.AuditStatus;
                    var qq = tcdmse.UserApply_UserApplyInfo.Where(q => q.BatchID == pp.BatchID);
                    foreach (var q in qq)
                    {
                        tcdmse.UserApply_UserApplyAuthority.RemoveRange(q.UserApply_UserApplyAuthority);
                    }
                    tcdmse.UserApply_UserApplyInfo.RemoveRange(qq);
                    batch = pp;
                }

                foreach (var e in dto.BatchApplyUser)
                {
                    UserApply_UserApplyInfo userapply = new UserApply_UserApplyInfo();

                    Mapper.Map<UserApplyOperateDTO, UserApply_UserApplyInfo>(e, userapply);
                    string strRoleIdList = String.Empty;
                    // roleid 2-13为模块管理员
                    if (e.UserChangeID != null)
                    {
                        userapply.AuditRoleIDList = e.AuditRoleIDList;
                    }
                    else
                    {
                        
                        var gg = ModelRoleDTO.ModelRolelist.Where(p => p.RoleID >= 2 && p.RoleID <= 13).ToList();
                        var mm = gg.Where(p => e.ApplyUserAuthority.Any(g => g.StructureID == p.ModelID)).Select(s => s.RoleID).Distinct().ToList();
                        mm.ForEach(u =>
                        {
                            strRoleIdList += "," + u.ToString();
                        });
                        userapply.AuditRoleIDList = strRoleIdList + ",";
                    }
                    
                    if (batch != null)
                    {
                        userapply.UserApply_ApplyBatch = batch;
                    }
                    tcdmse.UserApply_UserApplyInfo.Add(userapply);
                    foreach (var i in e.ApplyUserAuthority)
                    {
                        UserApply_UserApplyAuthority userappluauthority = new UserApply_UserApplyAuthority();
                        userappluauthority.UserApply_UserApplyInfo = userapply;
                        userappluauthority.StructureID = i.StructureID;
                        userappluauthority.AppyUserButtonAuthority = i.AppyUserButtonAuthority;
                        userappluauthority.IsAdopt = false;

                        tcdmse.UserApply_UserApplyAuthority.Add(userappluauthority);
                    }
                }

                blResult = tcdmse.SaveChanges() > 0;
            }

            return blResult;
        }
        /// <summary>
        /// 申请用户/申请批次用户(含全部)
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool ApplyUser(BatchApplyOperateDTO dto)
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_UserApplyEntities())
            {
                if (dto.BatchIDlist != null)
                {
                    var pp = tcdmse.UserApply_ApplyBatch.Where(p => dto.BatchIDlist.Contains(p.BatchID));
                    foreach (var p in pp)
                    {
                        p.AuditStatus = dto.AuditStatus;
                    }
                    var qq = tcdmse.UserApply_UserApplyInfo.Where(q => dto.BatchIDlist.Contains(q.BatchID));
                    foreach (var q in qq)
                    {
                        q.AuditStatus = dto.AuditStatus;
                    }
                    dto.BatchApplyUser = Mapper.Map<List<UserApply_UserApplyInfo>, List<UserApplyOperateDTO>>(qq.ToList(), dto.BatchApplyUser);
                }

                blResult = tcdmse.SaveChanges() > 0;
            }

            return blResult;
        }
        #endregion

        #region 用户审核
        public List<UserApplyUserResultDTO> GetUserApply(UserApplySearchDTO dto)
        {
            List<UserApplyUserResultDTO> result = null;
            var tcdmse = SingleQueryObject.GetObj();

            var pp = tcdmse.UserApply_UserApplyInfo.AsNoTracking().Where(p => p.AuditStatus == 0);

            if (dto != null)
            {
                if (!string.IsNullOrEmpty(dto.SearchText))
                {
                    pp = pp.Where(p => p.UserApplyName.Contains(dto.SearchText));
                }
                if (dto.RoleIDlist != null)
                {
                    pp = pp.Where(p => dto.RoleIDlist.Where(g => p.AuditRoleIDList.Contains(("," + (g ?? -1).ToString() + ","))).Count() > 0);
                }
                if (dto.UserApplyID != null)
                {
                    pp = pp.Where(p => p.UserApplyID == dto.UserApplyID);
                }
            }
            result = Mapper.Map<List<UserApply_UserApplyInfo>, List<UserApplyUserResultDTO>>(pp.ToList());

            return result;
        }

        /// <summary>
        /// 用户审核(通过)
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool AuditUserApplyEgis(UserApplyOperateDTO dto)
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_UserApplyEntities())
            {
                var pp = tcdmse.UserApply_UserApplyInfo.Where(p => p.UserApplyID == dto.UserApplyID).FirstOrDefault();

                if (pp != null)
                {
                    Mapper.Map<UserApply_UserApplyInfo, UserApplyOperateDTO>(pp, dto);
                    dto.AuditRoleIDList = ",";
                    List<UserApplyAuthority> uaur = new List<UserApplyAuthority>();
                    foreach (var rl in dto.RoleIDlist)
                    {
                        if (pp.AuditRoleIDList.Contains("," + rl.Value.ToString() + ","))
                        {
                            dto.AuditRoleIDList = dto.AuditRoleIDList + rl.Value.ToString() + ",";
                            pp.AuditRoleIDList = pp.AuditRoleIDList.Replace("," + rl + ",", ",");
                            List<string> Sid = ModelRoleDTO.ModelRolelist.Where(p => p.RoleID == rl).Select(s => s.ModelID).ToList();
                            foreach (var s in Sid)
                            {
                                uaur.AddRange(dto.ApplyUserAuthority.Where(ua => ua.StructureID.StartsWith(s)).Select(w => new UserApplyAuthority
                                {
                                    StructureID = w.StructureID,
                                    AppyUserButtonAuthority = w.AppyUserButtonAuthority
                                }));
                            }
                        }
                    }
                    dto.ApplyUserAuthority = uaur;
                    if (pp.AuditRoleIDList == ",")
                    {
                        pp.AuditStatus = 2;
                        tcdmse.SaveChanges();
                        if (pp.BatchID != null)
                        {
                            var qq = tcdmse.UserApply_UserApplyInfo.Where(p => p.BatchID == pp.BatchID).Select(s => s.AuditRoleIDList).Distinct().ToList();
                            if (qq.Count() == 1)
                            {
                                if (qq.FirstOrDefault() == ",")
                                {
                                    var pq = tcdmse.UserApply_ApplyBatch.Where(p => p.BatchID == pp.BatchID).FirstOrDefault();
                                    var asta = tcdmse.UserApply_UserApplyInfo.Where(p => p.BatchID == pp.BatchID).Select(s => s.AuditStatus).Distinct().ToList();
                                    if (asta.Count() == 1 && asta.FirstOrDefault() == 2)
                                    {
                                        pq.AuditStatus = 2;
                                    }
                                    else
                                    {
                                        pq.AuditStatus = 1;
                                    }
                                }
                            }
                        }
                    }
                }

                blResult = tcdmse.SaveChanges() > 0;
                blResult = true;
            }

            return blResult;
        }

        /// <summary>
        /// 用户审核(拒绝)
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool AuditUserApplyRefuse(UserApplyOperateDTO dto)
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_UserApplyEntities())
            {
                var pp = tcdmse.UserApply_UserApplyInfo.Where(p => p.UserApplyID == dto.UserApplyID).FirstOrDefault();
                if (pp != null)
                {
                    pp.AuditFalseReason = dto.AuditFalseReason;
                    Mapper.Map<UserApply_UserApplyInfo, UserApplyOperateDTO>(pp, dto);
                    dto.AuditRoleIDList = ",";
                    List<UserApplyAuthority> uaur = new List<UserApplyAuthority>();
                    foreach (var rl in dto.RoleIDlist)
                    {
                        if (pp.AuditRoleIDList.Contains("," + rl.Value.ToString() + ","))
                        {
                            dto.AuditRoleIDList = dto.AuditRoleIDList + rl.Value.ToString() + ",";
                            pp.AuditRoleIDList = pp.AuditRoleIDList.Replace("," + rl + ",", ",");
                            List<string> Sid = ModelRoleDTO.ModelRolelist.Where(p => p.RoleID == rl).Select(s => s.ModelID).ToList();
                            foreach (var s in Sid)
                            {
                                uaur.AddRange(dto.ApplyUserAuthority.Where(ua => ua.StructureID.StartsWith(s)).Select(w => new UserApplyAuthority
                                {
                                    StructureID = w.StructureID,
                                    AppyUserButtonAuthority = w.AppyUserButtonAuthority
                                }));
                            }
                        }
                    }
                    dto.ApplyUserAuthority = uaur;
                }
                if (pp.AuditRoleIDList == ",")
                {
                    pp.AuditStatus = 1;
                    tcdmse.SaveChanges();
                    if (pp.BatchID != null)
                    {
                        var qq = tcdmse.UserApply_UserApplyInfo.Where(p => p.BatchID == pp.BatchID).Select(s => s.AuditRoleIDList).Distinct().ToList();
                        if (qq.Count() == 1)
                        {
                            if (qq.FirstOrDefault() == ",")
                            {
                                var pq = tcdmse.UserApply_ApplyBatch.Where(p => p.BatchID == pp.BatchID).FirstOrDefault();
                                pq.AuditStatus = 1;
                            }
                        }
                    }
                }

                blResult = tcdmse.SaveChanges() > 0;
                blResult = true;
            }
            return blResult;
        }
        #endregion

        /// <summary>
        /// 导入数据
        /// </summary>
        /// <param name="impdto"></param>
        /// <returns></returns>
        public bool ImportData(List<ExcelImportDataDTO> impdtolst)
        {
            bool blResult = false;

            using (var tcdms = new Entities.TCDMS_UserApplyEntities())
            {
                foreach (var p in impdtolst)
                {
                    if (p is ExcelBatch) // 判断是否为用户信息
                    {

                        #region 用户申请批次表导入
                        ExcelBatch exrdt = p as ExcelBatch;

                        UserApply_ApplyBatch userbatch = new UserApply_ApplyBatch();
                        userbatch.BatchID = exrdt.BatchID.Value;
                        userbatch.BatchName = exrdt.BatchName;
                        userbatch.ApplyUserEamil = exrdt.ApplyUserEamil;
                        userbatch.ApplyUserPhone = exrdt.ApplyUserPhone;
                        userbatch.Status = Convert.ToInt16(exrdt.Status);
                        userbatch.ApplyUser = exrdt.ApplyUser;
                        userbatch.CreateTime = DateTime.Now;
                        userbatch.CreateUser = p.Importer;
                        userbatch.AuditStatus = exrdt.AuditStatus;
                        userbatch.ApplyTime = DateTime.Now;
                        tcdms.UserApply_ApplyBatch.Add(userbatch);
                        #endregion
                        #region 用户申请表导入
                        foreach (var q in exrdt.ExcelUserApply)
                        {
                            UserApply_UserApplyInfo Userappinfo = new UserApply_UserApplyInfo();
                            Userappinfo.UserApplyName = q.UserApplyName;
                            Userappinfo.BatchID = exrdt.BatchID;
                            Userappinfo.UserApplyTelNumber = q.UserPhone;
                            Userappinfo.UserApplyEmail = q.UserEmail;
                            Userappinfo.UserApplyType = Convert.ToInt16(q.UserApplyType);
                            Userappinfo.AuditRoleIDList = q.Userroleidstr;
                            Userappinfo.CreateUser = p.Importer;
                            Userappinfo.CreateTime = DateTime.Now;
                            Userappinfo.AuditStatus = q.AuditStatus;
                            Userappinfo.DistributorIDList = q.DistriButorIDStr;
                            tcdms.UserApply_UserApplyInfo.Add(Userappinfo);

                            foreach (var i in q.userapplyAut)
                            {
                                UserApply_UserApplyAuthority userappluauthority = new UserApply_UserApplyAuthority();
                                userappluauthority.UserApply_UserApplyInfo = Userappinfo;
                                userappluauthority.StructureID = i.StructureID;
                                userappluauthority.AppyUserButtonAuthority = i.ButtonAuthority;

                                tcdms.UserApply_UserApplyAuthority.Add(userappluauthority);
                            }
                        }
                        #endregion
                    }
                }
                blResult = tcdms.SaveChanges() > 0;
            }

            return blResult;
        }
    }
}
