using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TCSOFT.DMS.MasterData.Services
{
    using AutoMapper;
    using DTO.Common;
    using DTO.Role;
    using DTO.User;
    using IServices;
    using DTO;
    using DTO.User.UserApply;
    using Entities;
    using TCSOFT.DMS.MasterData.DTO.ImportExcel;
    using System.Data.Entity;
    public class UserAuthorityServices : BaseServices, IUserAuthorityServices, IImportDataServices
    {
        #region 部门
        /// <summary>
        /// 得到所有部门信息
        /// </summary>
        /// <returns></returns>
        public List<DepartmentResultDTO> GetDepartmentList()
        {
            List<DepartmentResultDTO> result = new List<DepartmentResultDTO>();
            var tcdmse = SingleQueryObject.GetObj();

            var roots = tcdmse.master_DepartmentInfo.AsNoTracking().Where(p => p.DepartParentID == null).ToList();
            var departlist = AutoMapper.Mapper.Map<List<master_DepartmentInfo>, List<DepartmentResultDTO>>(roots);
            for (int i = 0; i < departlist.Count; i++)
            {
                departlist[i] = GetDepartTree(departlist[i]);
            }
            result = departlist;

            return result;
        }
        private DepartmentResultDTO GetDepartTree(DepartmentResultDTO root)
        {
            var tcdmse = SingleQueryObject.GetObj();

            var roots = tcdmse.master_DepartmentInfo.AsNoTracking().Where(p => p.DepartParentID == root.DepartID).ToList();
            var departlist = Mapper.Map<List<master_DepartmentInfo>, List<DepartmentResultDTO>>(roots);
            for (int i = 0; i < departlist.Count; i++)
            {
                departlist[i].ParentPathName = root.PathName;
                departlist[i] = GetDepartTree(departlist[i]);
            }
            if (departlist.Count > 0)
            {
                root.children = departlist;
            }

            return root;
        }
        /// <summary>
        /// 得到一条部门信息
        /// </summary>
        /// <returns></returns>
        public DepartmentResultDTO GetDepartment(int id)
        {
            DepartmentResultDTO result = new DepartmentResultDTO();
            var tcdmse = SingleQueryObject.GetObj();

            var pp = tcdmse.master_DepartmentInfo.AsNoTracking().Where(p => p.DepartID == id).FirstOrDefault();
            if (pp == null)
            {
                throw new Exception("此条信息不存在！");
            }
            result = AutoMapper.Mapper.Map<master_DepartmentInfo, DepartmentResultDTO>(pp);

            return result;
        }
        /// <summary>
        /// 新增部门信息
        /// </summary>
        /// <returns></returns>
        public bool AddDepartment(DepartmentOperateDTO dto)
        {
            var result = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_DepartmentInfo.AsNoTracking().Where(p => p.DepartParentID == dto.DepartParentID && p.DepartName == dto.DepartName).FirstOrDefault();
                if (pp != null)
                {
                    throw new Exception("部门名称不能重复！");
                }
                var newdepart = new master_DepartmentInfo();
                newdepart = Mapper.Map<DepartmentOperateDTO, master_DepartmentInfo>(dto);
                tcdmse.master_DepartmentInfo.Add(newdepart);
                // 记录日志
                this.AddLog(tcdmse, new LogData
                {
                    CurrentLogType = LogType.ADD,
                    LogDetails = "新增部门" + dto.DepartName,
                    OpratorName = dto.CreateUser
                });
                result = tcdmse.SaveChanges() > 0;

                newdepart.DepartPath = dto.DepartPath + newdepart.DepartID + "/";
                tcdmse.SaveChanges();
            }

            return result;
        }
        /// <summary>
        /// 修改部门信息
        /// </summary>
        /// <returns></returns>
        public bool UpdateDepartment(DepartmentOperateDTO dto)
        {
            var result = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_DepartmentInfo.Where(p => p.DepartID == dto.DepartID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在");
                }
                var ss = tcdmse.master_DepartmentInfo.AsNoTracking().Where(p => p.DepartParentID == dto.DepartParentID && p.DepartName == dto.DepartName && p.DepartID != dto.DepartID).FirstOrDefault();
                if (ss != null)
                {
                    throw new Exception("部门名称不能重复！");
                }
                dto.CreateTime = pp.CreateTime;
                dto.CreateUser = pp.CreateUser;
                dto.DepartPath = pp.DepartPath;
                Mapper.Map<DepartmentOperateDTO, master_DepartmentInfo>(dto, pp);
                result = tcdmse.SaveChanges() > 0;
            }

            return result;
        }
        /// <summary>
        /// 删除部门信息
        /// </summary>
        /// <returns></returns>
        public bool DeleteDepartment(DepartmentSearchDTO dto)
        {
            var result = false;
            List<int> idlist = new List<int>();

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_DepartmentInfo.Where(p => p.DepartID == dto.DepartID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在");
                }
                if (pp.master_AreaInfo.Count > 0 || pp.master_UserInfo.Count > 0)
                {
                    throw new Exception("信息已被使用不可删除！");
                }
                idlist.Add(pp.DepartID);
                var children = tcdmse.master_DepartmentInfo.AsNoTracking().Where(p => p.DepartParentID == pp.DepartID).Select(m => m.DepartID).ToList();
                foreach (var child in children)
                {
                    idlist.AddRange(GetDepartIDList(child).ToList());
                }
                var remo = tcdmse.master_DepartmentInfo.Where(p => idlist.Contains(p.DepartID)).ToList();
                foreach (var r in remo)
                {
                    tcdmse.master_DepartmentInfo.Remove(r);
                    this.AddLog(tcdmse, new LogData
                    {
                        CurrentLogType = LogType.DELETE,
                        LogDetails = "删除部门" + r.DepartName,
                        OpratorName = dto.ModifyUser
                    });
                }

                result = tcdmse.SaveChanges() > 0;
            }

            return result;
        }
        private List<int> GetDepartIDList(int child)
        {
            var result = new List<int>();
            var tcdmse = SingleQueryObject.GetObj();

            var pp = tcdmse.master_DepartmentInfo.AsNoTracking().Where(p => p.DepartID == child).FirstOrDefault();
            if (pp != null)
            {
                if (pp.master_AreaInfo.Count > 0 || pp.master_UserInfo.Count > 0)
                {
                    throw new Exception("信息已被使用不可删除！");
                }
                result.Add(pp.DepartID);
                var children = tcdmse.master_DepartmentInfo.AsNoTracking().Where(p => p.DepartParentID == pp.DepartID).Select(m => m.DepartID).ToList();
                foreach (var ss in children)
                {
                    result.AddRange(GetDepartIDList(ss).ToList());
                }
            }

            return result;
        }
        public List<DepartmentResultDTO> GetDepartment()
        {
            List<DepartmentResultDTO> result = new List<DepartmentResultDTO>();
            var tcdmse = SingleQueryObject.GetObj();

            var roots = tcdmse.master_DepartmentInfo.AsNoTracking().ToList();
            result = AutoMapper.Mapper.Map<List<master_DepartmentInfo>, List<DepartmentResultDTO>>(roots);

            return result;
        }
        #endregion

        #region 角色
        /// <summary>
        /// 得到所有角色信息
        /// </summary>
        /// <returns></returns>
        public List<RoleResultDTO> GetRoleList(RoleSearchDTO dto)
        {
            List<RoleResultDTO> result = new List<RoleResultDTO>();
            var tcdmse = SingleQueryObject.GetObj();

            var pp = tcdmse.master_RoleInfo.AsNoTracking().Where(m => m.RoleID != null);
            if (dto.RoleType != null)
            {
                pp = pp.Where(m => m.RoleType == dto.RoleType);
            }
            if (!string.IsNullOrEmpty(dto.SearchText))
            {
                pp = pp.Where(m => m.RoleName.Contains(dto.SearchText));
            }
            result = AutoMapper.Mapper.Map<List<master_RoleInfo>, List<RoleResultDTO>>(pp.ToList());

            return result;
        }
        /// <summary>
        /// 得到一条角色信息
        /// </summary>
        /// <returns></returns>
        public RoleResultDTO GetRole(int id)
        {
            RoleResultDTO result = new RoleResultDTO();
            var tcdmse = SingleQueryObject.GetObj();

            var pp = tcdmse.master_RoleInfo.AsNoTracking().Where(p => p.RoleID == id).FirstOrDefault();
            if (pp == null)
            {
                throw new Exception("此条信息不存在！");
            }
            result = AutoMapper.Mapper.Map<master_RoleInfo, RoleResultDTO>(pp);

            return result;
        }
        /// <summary>
        /// 新增角色信息
        /// </summary>
        /// <returns></returns>
        public bool AddRole(RoleOperateDTO dto)
        {
            var result = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_RoleInfo.AsNoTracking().Where(p => p.RoleName == dto.RoleName).FirstOrDefault();
                if (pp != null)
                {
                    throw new Exception("角色名不能重复！");
                }
                var newrole = new master_RoleInfo();
                newrole = Mapper.Map<RoleOperateDTO, master_RoleInfo>(dto);
                tcdmse.master_RoleInfo.Add(newrole);
                tcdmse.SaveChanges();
                if (dto.RoleAuthority != null && dto.RoleAuthority.Count > 0)
                {
                    for (int i = 0; i < dto.RoleAuthority.Count; i++)
                    {
                        var newauth = new master_RoleAuthority()
                        {
                            RoleButtonAuthority = dto.RoleAuthority[i].RoleButtonAuthority,
                            StructureID = dto.RoleAuthority[i].StructureID,
                            RoleID = newrole.RoleID
                        };
                        tcdmse.master_RoleAuthority.Add(newauth);
                    }
                }


                result = tcdmse.SaveChanges() >= 0;
            }

            return result;
        }
        /// <summary>
        /// 修改角色信息
        /// </summary>
        /// <returns></returns>
        public bool UpdateRole(RoleOperateDTO dto)
        {
            var result = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_RoleInfo.Where(p => p.RoleID == dto.RoleID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在");
                }
                var ss = tcdmse.master_RoleInfo.AsNoTracking().Where(p => p.RoleName == dto.RoleName && p.RoleID != dto.RoleID).FirstOrDefault();
                if (ss != null)
                {
                    throw new Exception("角色名不能重复！");
                }
                dto.CreateTime = pp.CreateTime;
                dto.CreateUser = pp.CreateUser;
                Mapper.Map<RoleOperateDTO, master_RoleInfo>(dto, pp);
                var remove = tcdmse.master_RoleAuthority.Where(p => p.RoleID == pp.RoleID).ToList();
                tcdmse.master_RoleAuthority.RemoveRange(remove);
                if (dto.RoleAuthority != null && dto.RoleAuthority.Count > 0)
                {
                    for (int i = 0; i < dto.RoleAuthority.Count; i++)
                    {
                        var newauth = new master_RoleAuthority()
                        {
                            RoleButtonAuthority = dto.RoleAuthority[i].RoleButtonAuthority,
                            StructureID = dto.RoleAuthority[i].StructureID,
                            RoleID = pp.RoleID
                        };
                        tcdmse.master_RoleAuthority.Add(newauth);
                    }
                }
                result = tcdmse.SaveChanges() > 0;
            }

            return result;
        }
        /// <summary>
        /// 删除角色信息
        /// </summary>
        /// <returns></returns>
        public bool DeleteRole(RoleSearchDTO dto)
        {
            var result = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_RoleInfo.Where(p => p.RoleID == dto.RoleID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在");
                }
                var auth = tcdmse.master_RoleAuthority.Where(a => a.RoleID == dto.RoleID).ToList();
                tcdmse.master_RoleAuthority.RemoveRange(auth);
                if (pp.master_UserInfo.Count > 0)
                {
                    throw new Exception("信息已使用，不可删除！");
                }
                tcdmse.master_RoleInfo.Remove(pp);
                result = tcdmse.SaveChanges() > 0;
            }

            return result;
        }
        #endregion

        #region 用户审核
        /// <summary>
        /// 已授权用户模块
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public List<UsersByAuthoritedResultDTO> GetUsersByAuthorited(UsersByAuthoritedSearchDTO dto)
        {
            List<UsersByAuthoritedResultDTO> lstresult = null;
            var ww = dto.ApplyUserAuthority.Select(s => s.StructureID).ToList();
            var gg = from g in SingleQueryObject.GetObj().master_UserCustomerAuthority
                     where ww.Contains(g.StructureID) &&
                     (dto.DistributorID == null || g.master_UserInfo.master_DistributorInfo.Where(w => dto.DistributorID == w.DistributorID.ToString()).Count() > 0) &&
                     g.StructureID.Length == 3
                     select new UsersByAuthoritedResultDTO
                           {
                               UserID = g.master_UserInfo.UserID,
                               FullName = g.master_UserInfo.FullName,
                               StructureID = g.StructureID,
                               StructureName = g.dict_Structure.StructureName
                           };
            if (dto.RoleIDlist.Count() != 0)
            {
                var modelid = ModelRoleDTO.ModelRolelist.Where(p => dto.RoleIDlist.Contains(p.RoleID)).Select(s => s.ModelID).ToList();
                gg = gg.Where(p => modelid.Contains(p.StructureID));
            }
            dto.Count = gg.Select(t => t).Count();
            lstresult = gg.Select(t => t).OrderBy(o => o.UserID).ThenBy(t => t.StructureID).Skip((dto.page - 1) * dto.rows).Take(dto.rows).ToList();

            return lstresult;
        }

        /// <summary>
        /// 用户审核(通过)
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool AuditUserApplyAdopt(UserApplyOperateDTO dto)
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                List<int?> ridlist = new List<int?>();//审核的角色
                List<string> modellist = new List<string>();//审核的模块
                if (dto != null)
                {
                    var strauth = tcdmse.dict_Structure.ToList();
                    var qq = tcdmse.master_UserInfo.Where(p => p.PhoneNumber == dto.UserApplyTelNumber).FirstOrDefault();
                    if (qq == null)
                    {
                        //从用户申请表 => 用户表
                        master_UserInfo user = new master_UserInfo();
                        user.FullName = dto.UserApplyName;
                        user.PhoneNumber = dto.UserApplyTelNumber;
                        user.Email = dto.UserApplyEmail;
                        user.UserType = dto.UserApplyType;
                        user.IsActive = true;
                        user.StopTime = dto.StopTime;
                        user.DepartID = 1;
                        user.CreateTime = dto.CreateTime;
                        user.CreateUser = dto.CreateUser;
                        tcdmse.master_UserInfo.Add(user);
                        tcdmse.SaveChanges();

                        //用户申请表关联经销商str => 用户经销商表
                        if (dto.DistributorIDList != null)
                        {
                            List<string> Dlist = dto.DistributorIDList.Split(',').ToList();
                            List<Guid> Dguidlist = new List<Guid>();
                            foreach (var d in Dlist)
                            {
                                Guid g = Guid.Empty;
                                if (Guid.TryParse(d, out g))
                                {
                                    Dguidlist.Add(Guid.Parse(d));
                                }
                            }
                            var dd = tcdmse.master_DistributorInfo.Where(w => Dguidlist.Contains(w.DistributorID));
                            foreach (var d in dd)
                            {
                                user.master_DistributorInfo.Add(d);
                            }
                        }
                    }
                    qq = tcdmse.master_UserInfo.Where(p => p.PhoneNumber == dto.UserApplyTelNumber).FirstOrDefault();

                    if (dto.UserChangeID == null)//新用户申请
                    {
                        List<CurrentAuthorityDTO> uappa = new List<CurrentAuthorityDTO>();
                        foreach (var rl in dto.RoleIDlist)
                        {
                            if (dto.AuditRoleIDList.Contains("," + rl.Value.ToString() + ","))
                            {
                                ridlist.Add(rl);
                                //通过静态类取得角色对应的模块ID
                                List<string> Sid = ModelRoleDTO.ModelRolelist.Where(p => p.RoleID == rl).Select(s => s.ModelID).ToList();
                                foreach (var s in Sid)
                                {
                                    uappa.AddRange(dto.ApplyUserAuthority.Where(ua => ua.StructureID.StartsWith(s)).Select(sw => new CurrentAuthorityDTO
                                    {
                                        StructureID = sw.StructureID,
                                        BelongButton = sw.AppyUserButtonAuthority
                                    }));
                                }
                            }
                        }
                        //得到通过模块的权限
                        var userapplyaut = uappa.Select(s => new { s.StructureID, s.BelongButton }).Distinct().ToList();
                        modellist.AddRange(userapplyaut.Where(s => s.StructureID.Length == 3).Select(ss => ss.StructureID).ToList());
                        foreach (var q in userapplyaut)
                        {
                            master_UserCustomerAuthority userauthority = new master_UserCustomerAuthority();
                            userauthority.UserID = qq.UserID;
                            userauthority.StructureID = q.StructureID;
                            userauthority.UserButtonAuthority = q.BelongButton;

                            tcdmse.master_UserCustomerAuthority.Add(userauthority);
                        }
                    }
                    else
                    {
                        List<CurrentAuthorityDTO> uappa = new List<CurrentAuthorityDTO>();
                        foreach (var rl in dto.RoleIDlist)
                        {
                            if (dto.AuditRoleIDList.Contains("," + rl.Value.ToString() + ","))
                            {
                                //通过静态类取得角色对应的模块ID
                                List<string> Sid = ModelRoleDTO.ModelRolelist.Where(p => p.RoleID == rl).Select(s => s.ModelID).ToList();
                                foreach (var s in Sid)
                                {
                                    tcdmse.master_UserCustomerAuthority.RemoveRange(qq.master_UserCustomerAuthority.Where(ua => ua.StructureID.StartsWith(s)));

                                    uappa.AddRange(dto.ApplyUserAuthority.Where(ua => ua.StructureID.StartsWith(s)).Select(sw => new CurrentAuthorityDTO
                                    {
                                        StructureID = sw.StructureID,
                                        BelongButton = sw.AppyUserButtonAuthority
                                    }));
                                }
                            }
                        }
                        //得到通过模块的权限
                        var userapplyaut = uappa.Select(s => new { s.StructureID, s.BelongButton }).Distinct().ToList();
                        modellist.AddRange(userapplyaut.Where(s => s.StructureID.Length == 3).Select(ss => ss.StructureID).ToList());
                        foreach (var q in userapplyaut)
                        {
                            master_UserCustomerAuthority userauthority = new master_UserCustomerAuthority();
                            userauthority.UserID = qq.UserID;
                            userauthority.StructureID = q.StructureID;
                            userauthority.UserButtonAuthority = q.BelongButton;

                            tcdmse.master_UserCustomerAuthority.Add(userauthority);
                        }
                    }
                }

                blResult = tcdmse.SaveChanges() > 0;
            }

            return blResult;
        }
        #endregion

        #region 用户管理
        /// <summary>
        /// 得到所有用户信息(含模糊查询)
        /// </summary>
        /// <returns></returns>
        public List<UserResultDTO> GetUser(UserSearchDTO dto)
        {
            List<UserResultDTO> result = null;
            var tcdmse = SingleQueryObject.GetObj();
            var pp = tcdmse.master_UserInfo.AsNoTracking().Where(p => p.UserID > 0);
            if (dto != null)
            {
                #region 主数据
                if (dto.QueryType == 1) // 取得模块部门所对应区域下的模块管理员
                {
                    var gg = tcdmse.master_AreaInfo.AsNoTracking().Where(g => g.DepartID == dto.DepartID && g.AreaPID == null).ToList();
                    List<UserResultDTO> arrlst = new List<UserResultDTO>();

                    foreach (var m in gg)
                    {
                        var person = m.master_UserInfo.ToList();
                        if (person.Count == 0)
                        {
                            continue;
                        }

                        foreach (var ps in person)
                        {
                            UserResultDTO urd = new UserResultDTO();
                            urd.CusAdminAreaNames = m.master_DepartmentInfo.DepartName + @"/" + m.AreaName;
                            urd.AreaID = m.AreaID;
                            urd.Email = ps.Email;
                            urd.UserID = ps.UserID;
                            arrlst.Add(urd);
                        }
                    };
                    dto.Count = arrlst.Count();
                    return arrlst;//Mapper.Map<List<master_UserInfo>, List<UserResultDTO>>(gg.ToList());
                }
                #endregion

                #region 主数据
                if (!string.IsNullOrEmpty(dto.DepartPath))
                {
                    var depid = tcdmse.master_DepartmentInfo.Where(p => p.DepartPath.Contains(dto.DepartPath)).Select(s => s.DepartID);
                    pp = pp.Where(p => depid.Contains(p.DepartID.Value));
                }
                //过滤条件，用户类型过滤
                if (dto.UserTypeID != null)
                {
                    pp = pp.Where(p => p.UserType == dto.UserTypeID);
                }
                if (!string.IsNullOrEmpty(dto.PhoneNumber))
                {
                    pp = pp.Where(p => p.PhoneNumber == dto.PhoneNumber);
                }
                if (dto.RoleIDlist != null && dto.RoleIDlist.Count() > 0)
                {
                    pp = pp.Where(p => p.master_RoleInfo.Any(g => dto.RoleIDlist.Contains(g.RoleID)));
                }
                #endregion

                if (dto.EffectiveTtime != null)
                {
                    pp = pp.Where(p => DbFunctions.TruncateTime(p.EffectiveTtime) == dto.EffectiveTtime);
                }
                //模糊查询，按用户编号、手机号、姓名、邮箱、经销商名称模糊搜索
                #region 用户申请系统
                if (dto.QueryType == 2) //已有用户
                {
                    pp = pp.Where(p => p.IsActive == true && (p.StopTime >= DateTime.Now || p.StopTime == null));
                }
                if (dto.QueryType == 3)//停用用户
                {
                    pp = pp.Where(p => p.IsActive == false || (p.IsActive == true && p.StopTime < DateTime.Now));
                }

                if (dto.UserType != null)
                {
                    pp = pp.Where(p => p.UserType == dto.UserType);
                }
                if (dto.DistributorIDList != null && dto.DistributorIDList.Count > 0)
                {
                    pp = pp.Where(p => p.master_DistributorInfo.Where(w => dto.DistributorIDList.Contains(w.DistributorID)).Count() > 0);
                }
                if (dto.UserID != null)
                {
                    pp = pp.Where(p => p.UserID == dto.UserID);
                }
                #endregion

                if (!string.IsNullOrEmpty(dto.SearchText))
                {
                    pp = pp.Where(p => p.FullName.Contains(dto.SearchText) ||
                        p.Email.Contains(dto.SearchText) ||
                        p.PhoneNumber.Contains(dto.SearchText) ||
                        p.UserCode.Contains(dto.SearchText) ||
                        p.master_DistributorInfo.Where(w => w.DistributorName.Contains(dto.SearchText)).Count() > 0
                        );
                }
            }
            dto.Count = pp.Count();
            pp = pp.OrderByDescending(m => m.CreateTime).Skip((dto.page - 1) * dto.rows).Take(dto.rows);

            result = Mapper.Map<List<master_UserInfo>, List<UserResultDTO>>(pp.ToList());

            return result;
        }
        /// <summary>
        /// 得到一条用户信息
        /// </summary>
        /// <returns></returns>
        public UserResultDTO GetOneUser(int id)
        {
            UserResultDTO result = null;
            var tcdmse = SingleQueryObject.GetObj();

            var pp = tcdmse.master_UserInfo.AsNoTracking().Where(p => p.UserID == id).FirstOrDefault();
            if (pp == null)
            {
                throw new Exception("此条信息不存在！");
            }
            result = Mapper.Map<master_UserInfo, UserResultDTO>(pp);

            return result;
        }
        /// <summary>
        /// 用户信息新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool AddUser(UserOperate dto)
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                //判断手机号
                var pn = tcdmse.master_UserInfo.Where(p => p.PhoneNumber == dto.PhoneNumber).FirstOrDefault();
                if (pn != null)
                {
                    throw new Exception("该手机号已存在！");
                }
                //用户
                master_UserInfo user = new master_UserInfo();
                Mapper.Map<UserOperate, master_UserInfo>(dto, user);
                tcdmse.master_UserInfo.Add(user);
                tcdmse.SaveChanges();
                //用户权限
                if (dto.UserAuthority != null)
                {
                    foreach (var i in dto.UserAuthority)
                    {
                        if (i == null) { continue; }
                        master_UserCustomerAuthority userauthority = new master_UserCustomerAuthority();
                        userauthority.UserID = user.UserID;
                        userauthority.StructureID = i.StructureID;
                        userauthority.UserButtonAuthority = i.UserButtonAuthority;

                        tcdmse.master_UserCustomerAuthority.Add(userauthority);
                    }
                }
                //用户角色
                if (dto.UserRole != null)
                {
                    var ur = tcdmse.master_RoleInfo.Where(r => dto.UserRole.Contains(r.RoleID)).ToList();
                    string rolestr = string.Join(",", ur.Select(s => s.RoleName).ToArray());//取得新增角色（日志）
                    foreach (var u in ur)
                    {
                        user.master_RoleInfo.Add(u);
                    }

                    // 记录日志
                    if (!string.IsNullOrEmpty(rolestr))
                    {
                        this.AddLog(tcdmse, new LogData
                        {
                            CurrentLogType = LogType.ADD,
                            LogDetails = "新增用户角色：" + "用户：" + dto.FullName + "角色：" + rolestr,
                            OpratorName = dto.CreateUser
                        });
                    }
                }
                //关联经销商
                if (dto.UserDistributor != null)
                {
                    var ur = tcdmse.master_DistributorInfo.Where(r => dto.UserDistributor.Contains(r.DistributorID)).ToList();
                    string disstr = string.Join(",", ur.Select(s => s.DistributorName).ToArray());//取得新增经销商（日志）
                    foreach (var u in ur)
                    {
                        user.master_DistributorInfo.Add(u);
                    }

                    // 记录日志
                    if (!string.IsNullOrEmpty(disstr))
                    {
                        this.AddLog(tcdmse, new LogData
                        {
                            CurrentLogType = LogType.ADD,
                            LogDetails = "新增用户关联经销商：" + "用户：" + dto.FullName + "经销商：" + disstr,
                            OpratorName = dto.CreateUser
                        });
                    }
                }

                // 记录日志
                this.AddLog(tcdmse, new LogData
                {
                    CurrentLogType = LogType.ADD,
                    LogDetails = "新增用户" + dto.FullName,
                    OpratorName = dto.CreateUser
                });

                blResult = tcdmse.SaveChanges() > 0;
                blResult = true;
            }

            return blResult;
        }
        /// <summary>
        /// 用户信息修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool UpdateUser(UserOperate dto)
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_UserInfo.Where(p => p.UserID == dto.UserID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在！");
                }

                var pn = tcdmse.master_UserInfo.Where(p => p.UserID != dto.UserID && p.PhoneNumber == dto.PhoneNumber).FirstOrDefault();
                if (pn != null)
                {
                    throw new Exception("该手机号已存在！");
                }
                //用户权限
                var ww = tcdmse.master_UserCustomerAuthority.Where(w => w.UserID == pp.UserID);
                tcdmse.master_UserCustomerAuthority.RemoveRange(ww);
                if (dto.UserAuthority != null)
                {
                    foreach (var i in dto.UserAuthority)
                    {
                        if (i == null) { continue; }
                        master_UserCustomerAuthority userauthority = new master_UserCustomerAuthority();
                        userauthority.UserID = pp.UserID;
                        userauthority.StructureID = i.StructureID;
                        userauthority.UserButtonAuthority = i.UserButtonAuthority;

                        tcdmse.master_UserCustomerAuthority.Add(userauthority);
                    }
                }
                //用户角色
                if (pp.master_AreaInfo.Count > 0)
                {
                    if (dto.UserRole == null || dto.UserRole.Where(p => p.Value == 98).Count() == 0)
                    {
                        throw new Exception("已负责区域，无法去除客户管理员角色");
                    }
                }

                var OldRoleID = pp.master_RoleInfo.Select(q => q.RoleID).ToList();
                var llRoleID = dto.UserRole != null ? dto.UserRole.Select(p => p.Value).ToList() : new List<int>();
                var ChangeRoleID = OldRoleID.Except(llRoleID).Union(
                    llRoleID.Except(OldRoleID)
                    ).ToList();
                
                if(ChangeRoleID.Count>0)
                {
                    //记录日志

                    string roledelstr = string.Join(",", pp.master_RoleInfo.Select(s => s.RoleName).ToArray());
                    if (!string.IsNullOrEmpty(roledelstr))
                    {
                        this.AddLog(tcdmse, new LogData
                        {
                            CurrentLogType = LogType.DELETE,
                            LogDetails = "删除用户角色：" + "用户：" + dto.FullName + "角色：" + roledelstr,
                            OpratorName = dto.ModifyUser
                        });
                    }

                    pp.master_RoleInfo.Clear();
                    if (dto.UserRole != null)
                    {
                        var ur = tcdmse.master_RoleInfo.Where(r => dto.UserRole.Contains(r.RoleID)).ToList();
                        foreach (var u in ur)
                        {
                            pp.master_RoleInfo.Add(u);
                        }

                        //记录日志
                        string rolestr = string.Join(",", pp.master_RoleInfo.Select(s => s.RoleName).ToArray());
                        this.AddLog(tcdmse, new LogData
                        {
                            CurrentLogType = LogType.ADD,
                            LogDetails = "新增用户角色：" + "用户：" + dto.FullName + "角色：" + rolestr,
                            OpratorName = dto.ModifyUser
                        });
                    }
                }


                var OldID = pp.master_DistributorInfo.Select(q => q.DistributorID).ToList();
                var llid = dto.UserDistributor != null ? dto.UserDistributor.Select(p => p.Value).ToList() : new List<Guid>();
                var Change=OldID.Except(llid).Union(
                    llid.Except(OldID)
                    ).ToList();
                if (Change.Count > 0)
                {
                    string disdelstr = string.Join(",", pp.master_DistributorInfo.Select(s => s.DistributorName).ToArray());
                    if (!string.IsNullOrEmpty(disdelstr))
                    {
                        this.AddLog(tcdmse, new LogData
                        {
                            CurrentLogType = LogType.DELETE,
                            LogDetails = "删除用户关联经销商：" + "用户：" + dto.FullName + "经销商：" + disdelstr,
                            OpratorName = dto.ModifyUser
                        });
                    }

                    //关联经销商
                    //记录日志
                    pp.master_DistributorInfo.Clear();
                    if (dto.UserDistributor != null)
                    {
                        var ur = tcdmse.master_DistributorInfo.Where(r => dto.UserDistributor.Contains(r.DistributorID)).ToList();
                        string disstr = string.Join(",", ur.Select(s => s.DistributorName).ToArray());//取得新增经销商（日志）
                        foreach (var u in ur)
                        {
                            pp.master_DistributorInfo.Add(u);
                        }

                        // 记录日志
                        this.AddLog(tcdmse, new LogData
                        {
                            CurrentLogType = LogType.ADD,
                            LogDetails = "新增用户关联经销商：" + "用户：" + dto.FullName + "经销商：" + disstr,
                            OpratorName = dto.ModifyUser
                        });
                    }
                }
                //用户
                pp.UserType = dto.UserType;
                pp.UserCode = dto.UserCode;
                pp.PhoneNumber = dto.PhoneNumber;
                pp.FullName = dto.FullName;
                pp.Email = dto.Email;
                pp.DepartID = dto.DepartID;
                pp.StopTime = dto.StopTime;
                pp.ModifyTime = dto.ModifyTime;
                pp.ModifyUser = dto.ModifyUser;

                blResult = tcdmse.SaveChanges() > 0;
                blResult = true;
            }

            return blResult;
        }
        /// <summary>
        /// 用户信息删除
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool DeleteUser(UserOperate dto)
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_UserInfo.Where(p => p.UserID == dto.UserID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在！");
                }
                //用户权限
                var ww = tcdmse.master_UserCustomerAuthority.Where(w => w.UserID == pp.UserID);
                tcdmse.master_UserCustomerAuthority.RemoveRange(ww);
                //用户角色
                pp.master_RoleInfo.Clear();
                //关联经销商
                pp.master_DistributorInfo.Clear();
                //用户
                tcdmse.master_UserInfo.Remove(pp);

                // 记录日志
                this.AddLog(tcdmse, new LogData
                {
                    CurrentLogType = LogType.DELETE,
                    LogDetails = "删除用户" + pp.FullName,
                    OpratorName = dto.ModifyUser
                });

                blResult = tcdmse.SaveChanges() > 0;
            }

            return blResult;
        }
        /// <summary>
        /// 用户信息停启用
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool StopEnableUser(UserOperate dto)
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_UserInfo.Where(p => p.UserID == dto.UserID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在！");
                }
                if (dto.IsActive == true && pp.StopTime < DateTime.Now)
                {
                    throw new Exception("该用户已到期，启用无效");
                }
                pp.ModifyUser = dto.ModifyUser;
                pp.ModifyTime = dto.ModifyTime;
                pp.IsActive = dto.IsActive;
                pp.NoActiveTime = dto.NoActiveTime;

                if (dto.IsActive == false)
                {
                    // 记录日志
                    this.AddLog(tcdmse, new LogData
                    {
                        CurrentLogType = LogType.UNENABLE,
                        LogDetails = "停用用户" + pp.FullName,
                        OpratorName = dto.ModifyUser
                    });
                }

                blResult = tcdmse.SaveChanges() > 0;
            }

            return blResult;
        }
        /// <summary>
        /// 新增客户管理员
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool AddCustomerAdmin(UserOperate dto)
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_UserInfo.Where(p => p.UserID == dto.UserID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在！");
                }
                pp.ModifyUser = dto.ModifyUser;
                pp.ModifyTime = dto.ModifyTime;
                if (pp.master_AreaInfo.Where(g => g.AreaID == dto.AreaID).Count() == 0)
                {
                    pp.master_AreaInfo.Add(tcdmse.master_AreaInfo.Where(g => g.AreaID == dto.AreaID).FirstOrDefault());
                }

                blResult = tcdmse.SaveChanges() > 0;
            }

            return blResult;
        }
        /// <summary>
        /// 删除客户管理员
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool DeleteCustomerAdmin(UserOperate dto)
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_UserInfo.Where(p => p.UserID == dto.UserID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在！");
                }
                pp.ModifyUser = dto.ModifyUser;
                pp.ModifyTime = dto.ModifyTime;
                var aui = pp.master_AreaInfo.Where(g => g.AreaID == dto.AreaID).ToList();
                if (aui.Count() > 0)
                {
                    aui.ForEach(g =>
                    {
                        pp.master_AreaInfo.Remove(g);
                    });
                }

                blResult = tcdmse.SaveChanges() > 0;
            }

            return blResult;
        }
        /// <summary>
        /// 修改模块管理员邮箱
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool UpdateModularAdmin(UserOperate dto)
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_UserInfo.Where(p => p.UserID == dto.UserID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在！");
                }
                pp.ModifyUser = dto.ModifyUser;
                pp.ModifyTime = dto.ModifyTime;
                pp.Email = dto.Email;

                blResult = tcdmse.SaveChanges() > 0;
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

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                foreach (var p in impdtolst)
                {
                    if (p is ExcelUser) // 判断是否为用户信息
                    {
                        ExcelUser exrdt = p as ExcelUser;
                        if (exrdt.UpLogic == 2)
                        {
                            var origin = tcdmse.master_UserInfo.Where(m => m.UserID == exrdt.UserID).FirstOrDefault();
                            origin.UserCode = exrdt.UserCode;
                            origin.FullName = exrdt.FullName;
                            origin.PhoneNumber = exrdt.PhoneNumber;
                            origin.Email = exrdt.Email;
                            origin.IsActive = true;
                            origin.ModifyUser = exrdt.Importer;
                            origin.ModifyTime = DateTime.Now;
                            origin.StopTime = DateTime.Parse(exrdt.StopTime);
                            origin.master_DistributorInfo.Clear();
                            var pp = tcdmse.master_DistributorInfo.Where(w => exrdt.DistributorNamelist.Contains(w.DistributorName));
                            pp.ToList().ForEach(g =>
                            {//经销商
                                origin.master_DistributorInfo.Add(g);
                            });
                            origin.master_RoleInfo.Clear();
                            var qq = tcdmse.master_RoleInfo.Where(w => exrdt.RoleNamelist.Contains(w.RoleName));
                            origin.UserType = qq.Select(s => s.RoleType).FirstOrDefault();
                            qq.ToList().ForEach(g =>//角色
                            {
                                origin.master_RoleInfo.Add(g);
                            });
                        }
                        else
                        {
                            master_UserInfo mprd = new master_UserInfo();
                            mprd.UserCode = exrdt.UserCode;
                            mprd.FullName = exrdt.FullName;
                            mprd.PhoneNumber = exrdt.PhoneNumber;
                            mprd.Email = exrdt.Email;
                            mprd.IsActive = true;
                            mprd.DepartID = 1;
                            mprd.CreateUser = exrdt.Importer;
                            mprd.CreateTime = DateTime.Now;
                            if (!string.IsNullOrEmpty(exrdt.StopTime))//到期日
                            {
                                mprd.StopTime = DateTime.Parse(exrdt.StopTime);
                            }
                            var pp = tcdmse.master_DistributorInfo.Where(w => exrdt.DistributorNamelist.Contains(w.DistributorName));
                            pp.ToList().ForEach(g =>
                            {//经销商
                                mprd.master_DistributorInfo.Add(g);
                            });
                            var qq = tcdmse.master_RoleInfo.Where(w => exrdt.RoleNamelist.Contains(w.RoleName));
                            mprd.UserType = qq.Select(s => s.RoleType).FirstOrDefault();
                            qq.ToList().ForEach(g =>//角色
                            {
                                mprd.master_RoleInfo.Add(g);
                            });

                            tcdmse.master_UserInfo.Add(mprd);

                            // 记录日志
                            this.AddLog(tcdmse, new LogData
                            {
                                CurrentLogType = LogType.IMPORT,
                                LogDetails = "导入用户" + exrdt.FullName,
                                OpratorName = exrdt.Importer
                            });
                        }

                    }
                }

                blResult = tcdmse.SaveChanges() > 0;
            }

            return blResult;
        }
    }
}
