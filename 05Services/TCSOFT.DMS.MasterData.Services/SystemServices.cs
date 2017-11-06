using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.Services
{
    using IServices;
    using DTO.System.ModularSysEmail;
    using DTO.System.OperationSysEmail;
    using AutoMapper;
    using TCSOFT.DMS.MasterData.Entities;
    using TCSOFT.DMS.MasterData.DTO.Message;
    using TCSOFT.DMS.MasterData.DTO.UsersStat;
    public class SystemServices : ISystemServices
    {
        #region 模块管理员配置
        /// <summary>
        /// 得到所有模块管理员信息
        /// </summary>
        /// <returns></returns>
        public List<ModularResultDTO> GetModularList(ModularSearchDTO dto)
        {
            List<ModularResultDTO> result = new List<ModularResultDTO>();
            var tcdmse = SingleQueryObject.GetObj();
            //dict_Structure和master_UserInfo关联查询所有的模块管理员信息

            return result;
        }
        /// <summary>
        /// 修改模块管理员邮箱
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool UpdateModularInfo(ModularOperateDTO dto)
        {
            bool result = false;
            //根据用户ID和模块,修改该模块的邮箱
            return result;
        }
        #endregion
        #region 运维管理员配置
        /// <summary>
        /// 修改运维管理员邮箱
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool UpdateOperationInfo(OperationOperateDTO dto)
        {
            bool result = false;
            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_UserInfo.Where(p => p.UserID == dto.UserID).FirstOrDefault();
                if(pp==null)
                {
                    throw new Exception("此条信息不存在！");
                }
                pp.Email = dto.Email;
                pp.ModifyTime = dto.ModifyTime;
                pp.ModifyUser = dto.ModifyUser;

                result = tcdmse.SaveChanges() > 0;
            }
            return result;
        }
        #endregion

        #region 短信统计
        /// <summary>
        /// 得到短信统计
        /// </summary>
        /// <returns></returns>
        public List<MessageResultDTO> GetMessageStatList(MessageSearchDTO dto)
        {
            List<MessageResultDTO> result = null;
            var tcdmse = SingleQueryObject.GetObj();
            var pp = tcdmse.master_MessageStat.AsNoTracking().Where(p => p.MessageStatID != null);
            if (!string.IsNullOrEmpty(dto.SearchText))
            {
                pp = pp.Where(p => p.master_UserInfo.master_DepartmentInfo.DepartName.Contains(dto.SearchText) ||
                   p.master_UserInfo.FullName.Contains(dto.SearchText) ||
                   p.master_UserInfo.PhoneNumber.Contains(dto.SearchText) ||
                   p.master_UserInfo.master_DistributorInfo.Any(m => m.DistributorName.Contains(dto.SearchText)));
            }
            dto.Count = pp.Count();
            pp = pp.OrderByDescending(m => m.SendTime).ThenBy(m => m.MessageStatID).Skip((dto.page - 1) * dto.rows).Take(dto.rows);
            result = Mapper.Map<List<master_MessageStat>, List<MessageResultDTO>>(pp.ToList());

            return result;
        }
        /// <summary>
        /// 新增短信
        /// </summary>
        /// <returns></returns>
        public bool AddMessageStat(List<MessageOperateDTO> dtolist)
        {
            bool result = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var newitemlist = new List<master_MessageStat>();
                newitemlist = Mapper.Map<List<MessageOperateDTO>, List<master_MessageStat>>(dtolist);
                tcdmse.master_MessageStat.AddRange(newitemlist);
                result = tcdmse.SaveChanges() > 0;
            }

            return result;
        }
        /// <summary>
        /// 删除短信
        /// </summary>
        /// <returns></returns>
        public bool DeleteMessageStat(MessageResultDTO dto)
        {
            bool result = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_MessageStat.Where(p => p.MessageStatID == dto.MessageStatID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在！");
                }
                tcdmse.master_MessageStat.Remove(pp);

                result = tcdmse.SaveChanges() > 0;
            }

            return result;
        }
        #endregion

        #region 用户统计
        /// <summary>
        /// 得到用户统计
        /// </summary>
        /// <returns></returns>
        public List<UsersStatResultDTO> GetUsersStatList(UsersStatSearchDTO dto)
        {
            List<UsersStatResultDTO> result = null;
            var tcdmse = SingleQueryObject.GetObj();
            var pp = tcdmse.master_UsersStat.AsNoTracking().Where(p => p.UsersStatID != null);
            if (!string.IsNullOrEmpty(dto.SearchText))
            {
                pp = pp.Where(p => p.master_UserInfo.master_DepartmentInfo.DepartName.Contains(dto.SearchText) ||
                   p.master_UserInfo.FullName.Contains(dto.SearchText) ||
                   p.master_UserInfo.PhoneNumber.Contains(dto.SearchText) ||
                   (dto.UserType != null && p.master_UserInfo.UserType == dto.UserType) ||
                   p.master_UserInfo.master_DistributorInfo.Any(m => m.DistributorName.Contains(dto.SearchText)));
            }
            dto.Count = pp.Count();
            pp = pp.OrderByDescending(m => m.UseModelTime).ThenBy(m => m.UsersStatID).Skip((dto.page - 1) * dto.rows).Take(dto.rows);
            result = Mapper.Map<List<master_UsersStat>, List<UsersStatResultDTO>>(pp.ToList());

            return result;
        }
        /// <summary>
        /// 新增用户统计
        /// </summary>
        /// <returns></returns>
        public bool AddUsersStat(UsersStatOperateDTO dto)
        {
            bool result = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var newitem = new master_UsersStat();
                newitem = Mapper.Map<UsersStatOperateDTO, master_UsersStat>(dto);
                tcdmse.master_UsersStat.Add(newitem);
                result = tcdmse.SaveChanges() > 0;
            }

            return result;
        }
        /// <summary>
        /// 删除用户统计信息
        /// </summary>
        /// <returns></returns>
        public bool DeleteUsersStat(UsersStatResultDTO dto)
        {
            bool result = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_UsersStat.Where(p => p.UsersStatID == dto.UsersStatID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在！");
                }
                tcdmse.master_UsersStat.Remove(pp);

                result = tcdmse.SaveChanges() > 0;
            }

            return result;
        }
        #endregion

    }
}
