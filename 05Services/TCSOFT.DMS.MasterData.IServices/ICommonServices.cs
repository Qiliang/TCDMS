using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.IServices
{
    using DTO;
    using DTO.Common;
    public interface ICommonServices
    {
        /// <summary>
        /// 取得所有模块
        /// </summary>
        /// <returns></returns>
        List<StructureDTO> GetAllStructure();
        /// <summary>
        /// 取得所有功能按钮
        /// </summary>
        /// <returns></returns>
        List<ButtonDTO> GetAllButton();
        /// <summary>
        /// 取得模块日志
        /// </summary>
        /// <returns></returns>
        List<LogDTO> GetAllLogByBelongModel(string BelongModel);
        /// <summary>
        /// 取得用户权限
        /// </summary>
        /// <param name="intUserid">用户ID</param>
        /// <returns></returns>
        List<CurrentAuthorityDTO> GetUserAuthority(int intUserid);
        /// <summary>
        /// 取得角色权限
        /// </summary>
        /// <param name="intRoleidlst">角色ID</param>
        /// <returns></returns>
        List<CurrentAuthorityDTO> GetRoleAuthority(List<int> intRoleidlst);
        /// <summary>
        /// 取得角色类型权限
        /// </summary>
        /// <param name="intRoletype">角色类型</param>
        /// <returns></returns>
        List<CurrentAuthorityDTO> GetRoleTypeAuthority(int intRoletype);
        /// <summary>
        /// 取得所有管理员信息
        /// </summary>
        /// <param name="asdto">查询对象</param>
        /// <returns></returns>
        List<AdminDTO> GetAdminInfo(AdminSearchDTO asdto);
        /// <summary>
        /// 新增多个附件
        /// </summary>
        /// <param name="dtolist"></param>
        /// <returns></returns>
        bool AddAttachFileList(List<AttachFileOperateDTO> dtolist);
        /// <summary>
        /// 删除附件
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool DeleteAttachFile(AttachFileOperateDTO dto);
        /// <summary>
        /// 得到附件信息（查询）
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        List<AttachFileResultDTO> GetAttachFileList(AttachFileSearchDTO dto);
        /// <summary>
        /// 得到反馈信息（查询）
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        List<FeedbackResultDTO> GetFeedbackList(FeedbackSearchDTO dto);
        /// <summary>
        /// 新增反馈信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        int AddFeedback(FeedbackOperateDTO dto);
        /// <summary>
        /// 修改反馈信息（修改状态）
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool UpdateFeedback(FeedbackOperateDTO dto);
        #region 日志管理
        /// <summary>
        /// 查询日志管理
        /// </summary>
        /// <returns></returns>
        List<LogDTO> GetLog(LogSearchDTO dto);
        #endregion
        #region 提醒管理
        /// <summary>
        /// 查询提醒管理
        /// </summary>
        /// <returns></returns>
        List<WarningDTO> GetWarningInfo(WarningSearchDTO dto);
        /// <summary>
        /// 新增提醒管理
        /// </summary>
        /// <returns></returns>
        bool AddWarningInfo(WarningDTO dto);
        /// <summary>
        /// 删除一条提醒信息
        /// </summary>
        /// <returns></returns>
        bool DeleteWarningInfo(WarningSearchDTO dto);
        #endregion
    }
}
