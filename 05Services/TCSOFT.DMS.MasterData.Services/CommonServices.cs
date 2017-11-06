using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

namespace TCSOFT.DMS.MasterData.Services
{
    using DTO;
    using DTO.Common;
    using IServices;
    using Entities;
    public class CommonServices : ICommonServices
    {
        /// <summary>
        /// 取得所有模块
        /// </summary>
        /// <returns></returns>
        public List<StructureDTO> GetAllStructure()
        {
            List<StructureDTO> result = null;

            var pp = SingleQueryObject.GetObj().dict_Structure.AsNoTracking().OrderBy(g => new { g.StructureID, g.IndexCode }).ToList();
            result = Mapper.Map<List<StructureDTO>>(pp);

            return result;
        }

        /// <summary>
        /// 取得所有按钮
        /// </summary>
        /// <returns></returns>
        public List<ButtonDTO> GetAllButton()
        {
            List<ButtonDTO> result = null;

            var pp = SingleQueryObject.GetObj().dict_ButtonInfo.AsNoTracking().OrderBy(g => g.IndexCode).ToList();
            result = Mapper.Map<List<ButtonDTO>>(pp);

            return result;
        }
        /// <summary>
        /// 取得模块日志
        /// </summary>
        /// <returns></returns>
        public List<LogDTO> GetAllLogByBelongModel(string BelongModel)
        {
            List<LogDTO> result = null;

            var pp = SingleQueryObject.GetObj().common_LogInfo.AsNoTracking().Where(p => p.BelongModel == BelongModel).OrderBy(g => g.LogIndex).ToList();
            result = Mapper.Map<List<LogDTO>>(pp);

            return result;
        }

        /// <summary>
        /// 取得用户权限
        /// </summary>
        /// <param name="intUserid">用户ID</param>
        /// <returns></returns>
        public List<CurrentAuthorityDTO> GetUserAuthority(int intUserid)
        {
            List<CurrentAuthorityDTO> result = new List<CurrentAuthorityDTO>();
            var pp = SingleQueryObject.GetObj().master_UserInfo.AsNoTracking().Where(p => p.UserID == intUserid).FirstOrDefault();
            //var roleauth = Mapper.Map<List<CurrentUserRoleAuthority>>(pp.master_RoleInfo.SelectMany(t=>t.master_RoleAuthority).ToList());
            var custauth = Mapper.Map<List<CurrentUserCustomerAuthority>>(pp.master_UserCustomerAuthority.ToList());
            List<CurrentAuthorityDTO> TempResult = new List<CurrentAuthorityDTO>();
            //roleauth.ForEach(g =>
            //{
            //    TempResult.Add(new CurrentAuthorityDTO { StructureID = g.StructureID, BelongButton = g.RoleButtonAuthority.Value });
            //});
            custauth.ForEach(g =>
            {
                TempResult.Add(new CurrentAuthorityDTO { StructureID = g.StructureID, BelongButton = g.UserButtonAuthority.Value });
            });
            CurrentAuthorityDTO cadto = null;
            foreach (var p in TempResult)
            {
                cadto = result.Where(g => g.StructureID == p.StructureID).FirstOrDefault();
                if (cadto == null)
                {
                    result.Add(new CurrentAuthorityDTO { StructureID = p.StructureID, BelongButton = p.BelongButton });
                }
                else
                {
                    cadto.BelongButton |= p.BelongButton;
                }
            }

            return result;
        }
        /// <summary>
        /// 取得角色权限
        /// </summary>
        /// <param name="intRoleidlst">角色ID列表</param>
        /// <returns></returns>
        public List<CurrentAuthorityDTO> GetRoleAuthority(List<int> intRoleidlst)
        {
            List<CurrentAuthorityDTO> result = new List<CurrentAuthorityDTO>();
            var pp = SingleQueryObject.GetObj().master_RoleAuthority.AsNoTracking().Where(p => intRoleidlst.Contains(p.RoleID.Value)).ToList();
            var TempResult = Mapper.Map<List<CurrentUserRoleAuthority>>(pp);
            CurrentAuthorityDTO cadto = null;
            foreach (var p in TempResult)
            {
                cadto = result.Where(g => g.StructureID == p.StructureID).FirstOrDefault();
                if (cadto == null)
                {
                    result.Add(new CurrentAuthorityDTO { StructureID = p.StructureID, BelongButton = p.RoleButtonAuthority.Value });
                }
                else
                {
                    cadto.BelongButton |= p.RoleButtonAuthority.Value;
                }
            }

            return result;
        }
        /// <summary>
        /// 取得角色类型权限
        /// </summary>
        /// <param name="intRoletype">角色类型</param>
        /// <returns></returns>
        public List<CurrentAuthorityDTO> GetRoleTypeAuthority(int intRoletype)
        {
            List<CurrentAuthorityDTO> result = new List<CurrentAuthorityDTO>();
            var pp = SingleQueryObject.GetObj().master_RoleAuthority.AsNoTracking().Where(p => p.master_RoleInfo.RoleType == intRoletype).ToList();
            var TempResult = Mapper.Map<List<CurrentUserRoleAuthority>>(pp);
            CurrentAuthorityDTO cadto = null;
            foreach (var p in TempResult)
            {
                cadto = result.Where(g => g.StructureID == p.StructureID).FirstOrDefault();
                if (cadto == null)
                {
                    result.Add(new CurrentAuthorityDTO { StructureID = p.StructureID, BelongButton = p.RoleButtonAuthority.Value });
                }
                else
                {
                    cadto.BelongButton |= p.RoleButtonAuthority.Value;
                }
            }

            return result;
        }

        /// <summary>
        /// 取得所有管理员信息
        /// </summary>
        /// <param name="asdto">查询对象</param>
        /// <returns></returns>
        public List<AdminDTO> GetAdminInfo(AdminSearchDTO asdto)
        {
            List<AdminDTO> result = null;

            if (asdto.RoleIdList != null && asdto.RoleIdList.Count > 0)
            {
                var pp = SingleQueryObject.GetObj().master_UserInfo.AsNoTracking().Where(p => p.master_RoleInfo.Any(g => asdto.RoleIdList.Contains(g.RoleID))).ToList();
                result = new List<AdminDTO>();
                pp.ForEach(m =>
                {
                    m.master_RoleInfo.Select(s => s.RoleID).ToList().ForEach(f =>
                    {
                        AdminDTO ad = new AdminDTO();
                        ad.UserID = m.UserID;
                        ad.Email = m.Email;
                        ad.PhoneNumber = m.PhoneNumber;
                        ad.RoleID = f;
                        result.Add(ad);
                    });
                });
            }

            return result;
        }
        /// <summary>
        /// 新增多个附件
        /// </summary>
        /// <param name="dtolist"></param>
        /// <returns></returns>
        public bool AddAttachFileList(List<AttachFileOperateDTO> dtolist)
        {
            bool result = false;
            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                if (dtolist.Count > 0)
                {
                    List<common_AttachFileInfo> newitemlist = new List<common_AttachFileInfo>();

                    Mapper.Map<List<AttachFileOperateDTO>, List<common_AttachFileInfo>>(dtolist, newitemlist);
                    tcdmse.common_AttachFileInfo.AddRange(newitemlist);

                    result = tcdmse.SaveChanges() > 0;
                }
            }
            return result;
        }
        /// <summary>
        /// 删除附件
        /// </summary>
        /// <param name="dtolist"></param>
        /// <returns></returns>
        public bool DeleteAttachFile(AttachFileOperateDTO dto)
        {
            bool result = false;
            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                if (dto.AttachFileID != null)
                {
                    var pp = tcdmse.common_AttachFileInfo.Where(p => p.AttachFileID == dto.AttachFileID).FirstOrDefault();
                    if (pp == null)
                    {
                        throw new Exception("此条信息不存在！");
                    }
                    tcdmse.common_AttachFileInfo.Remove(pp);
                }
                else if ((dto.BelongModule != null) && (!string.IsNullOrEmpty(dto.BelongModulePrimaryKey)))
                {
                    var pp = tcdmse.common_AttachFileInfo.Where(p => p.BelongModule == dto.BelongModule && p.BelongModulePrimaryKey == dto.BelongModulePrimaryKey);

                    tcdmse.common_AttachFileInfo.RemoveRange(pp);
                }
                else if (dto.BelongModule != null)
                {
                    var pp = tcdmse.common_AttachFileInfo.Where(p => p.BelongModule == dto.BelongModule);

                    tcdmse.common_AttachFileInfo.RemoveRange(pp);
                }
                result = tcdmse.SaveChanges() > 0;
            }
            return result;
        }
        /// <summary>
        /// 得到附件信息（查询）
        /// </summary>
        /// <param name="dtolist"></param>
        /// <returns></returns>
        public List<AttachFileResultDTO> GetAttachFileList(AttachFileSearchDTO dto)
        {
            List<AttachFileResultDTO> result = null;
            var tcdmse = SingleQueryObject.GetObj();

            var pp = tcdmse.common_AttachFileInfo.AsNoTracking().Where(p => p.AttachFileID != null);
            if (dto.AttachFileID != null)
            {
                pp = pp.Where(p => p.AttachFileID == dto.AttachFileID);
            }
            else
            {
                if (dto.BelongModule != null)
                {
                    pp = pp.Where(p => p.BelongModule == dto.BelongModule);
                    if (!string.IsNullOrEmpty(dto.BelongModulePrimaryKey))
                    {
                        pp = pp.Where(p => p.BelongModulePrimaryKey == dto.BelongModulePrimaryKey);
                    }
                }

            }
            result = Mapper.Map<List<common_AttachFileInfo>, List<AttachFileResultDTO>>(pp.ToList());

            return result;
        }
        /// <summary>
        /// 得到反馈信息（查询）
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public List<FeedbackResultDTO> GetFeedbackList(FeedbackSearchDTO dto)
        {
            List<FeedbackResultDTO> result = null;
            var tcdmse = SingleQueryObject.GetObj();

            var pp = tcdmse.master_FeedbackStat.AsNoTracking().Where(p => p.FeedbackStatID != null);
            {
                if (!string.IsNullOrEmpty(dto.FeedbackSystem))
                {
                    pp = pp.Where(p => p.FeedbackSystem == dto.FeedbackSystem);
                }
                if (!string.IsNullOrEmpty(dto.SearchText))
                {
                    pp = pp.Where(p => p.master_UserInfo.master_DistributorInfo.Any(m => m.DistributorName.Contains(dto.SearchText)) ||
                        p.master_UserInfo.FullName.Contains(dto.SearchText));
                }
            }
            dto.Count = pp.Count();
            pp = pp.OrderBy(m => m.FeedbackStaus).ThenByDescending(m => m.FeedbackDate).ThenBy(m => m.FeedbackStatID).Skip((dto.page - 1) * dto.rows).Take(dto.rows);

            result = Mapper.Map<List<master_FeedbackStat>, List<FeedbackResultDTO>>(pp.ToList());

            return result;
        }
        /// <summary>
        /// 新增反馈信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public int AddFeedback(FeedbackOperateDTO dto)
        {
            int result = -1;
            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                master_FeedbackStat newitem = new master_FeedbackStat();
                newitem = Mapper.Map<FeedbackOperateDTO, master_FeedbackStat>(dto);

                tcdmse.master_FeedbackStat.Add(newitem);
                tcdmse.SaveChanges();
                result = newitem.FeedbackStatID;
            }

            return result;
        }
        /// <summary>
        /// 修改反馈信息（修改状态）
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool UpdateFeedback(FeedbackOperateDTO dto)
        {
            bool result = false;
            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_FeedbackStat.Where(p => p.FeedbackStatID == dto.FeedbackStatID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在！");
                }
                pp.FeedbackStaus = dto.FeedbackStaus;
                pp.DealUser = dto.DealUser;
                pp.DealDatetime = dto.DealDatetime;

                result = tcdmse.SaveChanges() > 0;
            }
            return result;
        }
        #region 日志管理
        /// <summary>
        /// 查询日志管理
        /// </summary>
        /// <returns></returns>
        public List<LogDTO> GetLog(LogSearchDTO dto)
        {
            List<LogDTO> result = null;
            var tcdmse = SingleQueryObject.GetObj();

            var pp = tcdmse.common_LogInfo.AsNoTracking().Where(p => p.LogIndex != null);
            if (dto.Year != null)
            {
                pp = pp.Where(p => p.LogDate.Value.Year == dto.Year);
            }
            if (dto.Month != null)
            {
                pp = pp.Where(p => p.LogDate.Value.Month == dto.Month);
            }
            if (!string.IsNullOrEmpty(dto.BelongModel))
            {
                pp = pp.Where(p => p.BelongModel == dto.BelongModel);
            }
            if (!string.IsNullOrEmpty(dto.SearchText))
            {
                pp = pp.Where(p => p.OpratorName.Contains(dto.SearchText));
            }
            dto.Count = pp.Count();
            pp = pp.OrderBy(m => m.LogIndex).Skip((dto.page - 1) * dto.rows).Take(dto.rows);

            result = Mapper.Map<List<common_LogInfo>, List<LogDTO>>(pp.ToList());

            return result;
        }
        #endregion
        #region 提醒管理
        /// <summary>
        /// 查询提醒管理
        /// </summary>
        /// <returns></returns>
        public List<WarningDTO> GetWarningInfo(WarningSearchDTO dto)
        {
            List<WarningDTO> result = null;
            var tcdmse = SingleQueryObject.GetObj();

            var pp = tcdmse.common_WarningInfo.AsNoTracking().Where(p => p.WarningID != null);
         
                pp = pp.Where(t => t.UserID == dto.UserID);

            dto.Count = pp.Count();
            pp = pp.OrderBy(m => m.WarningID).Skip((dto.page - 1) * dto.rows).Take(dto.rows);

            result = Mapper.Map<List<common_WarningInfo>, List<WarningDTO>>(pp.ToList());

            return result;
        }
        /// <summary>
        /// 新增提醒管理
        /// </summary>
        /// <returns></returns>
        public bool AddWarningInfo(WarningDTO dto)
        {
            bool result = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                common_WarningInfo warning = new common_WarningInfo();
                Mapper.Map<WarningDTO, common_WarningInfo>(dto, warning);

                tcdmse.common_WarningInfo.Add(warning);

                result = tcdmse.SaveChanges() > 0;
            }

            return result;
        }
        /// <summary>
        /// 删除一条提醒信息
        /// </summary>
        /// <returns></returns>
        public bool DeleteWarningInfo(WarningSearchDTO dto)
        {
            bool result = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.common_WarningInfo.Where(p => p.WarningID == dto.WarningID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在！");
                }
                tcdmse.common_WarningInfo.Remove(pp);
                result = tcdmse.SaveChanges() > 0;
            }

            return result;
        }
        #endregion
    }
}
