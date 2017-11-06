using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.IServices
{
    using IServices;
    using DTO.System.ModularSysEmail;
    using DTO.System.OperationSysEmail;
    using TCSOFT.DMS.MasterData.DTO.Message;
    using TCSOFT.DMS.MasterData.DTO.UsersStat;
    public interface ISystemServices
    {
        #region 模块管理员配置
        /// <summary>
        /// 得到所有模块管理员信息
        /// </summary>
        /// <returns></returns>
        List<ModularResultDTO> GetModularList(ModularSearchDTO dto);
        /// <summary>
        /// 修改模块管理员邮箱
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool UpdateModularInfo(ModularOperateDTO dto);
        #endregion
        #region 运维管理员配置
        /// <summary>
        /// 修改运维管理员邮箱
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool UpdateOperationInfo(OperationOperateDTO dto);
        #endregion

        #region 短信统计
        /// <summary>
        /// 得到所有短信
        /// </summary>
        /// <returns></returns>
        List<MessageResultDTO> GetMessageStatList(MessageSearchDTO dto);
        /// <summary>
        /// 新增短信
        /// </summary>
        /// <returns></returns>
        bool AddMessageStat(List<MessageOperateDTO> dtolist);
        /// <summary>
        /// 删除短信
        /// </summary>
        /// <returns></returns>
        bool DeleteMessageStat(MessageResultDTO dto);
        #endregion

        #region 用户统计
        /// <summary>
        /// 得到用户统计
        /// </summary>
        /// <returns></returns>
        List<UsersStatResultDTO> GetUsersStatList(UsersStatSearchDTO dto);
        /// <summary>
        /// 新增用户统计
        /// </summary>
        /// <returns></returns>
        bool AddUsersStat(UsersStatOperateDTO dto);
        /// <summary>
        /// 删除用户统计信息
        /// </summary>
        /// <returns></returns>
        bool DeleteUsersStat(UsersStatResultDTO dto);
        #endregion
    }
}
