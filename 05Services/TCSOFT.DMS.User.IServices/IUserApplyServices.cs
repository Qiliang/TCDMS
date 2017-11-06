using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCSOFT.DMS.UserApply.DTO.User;
using TCSOFT.DMS.UserApply.DTO.User.UserApply;

namespace TCSOFT.DMS.UserApply.IServices
{
    public interface IUserApplyServices
    {
        #region 用户申请/审核
        /// <summary>
        /// 查询申请的批次
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        List<UserApplyBatchResultDTO> GetApplyBatchUser(UserApplySearchDTO dto);
        /// <summary>
        /// 查询申请的用户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        List<UserApplyUserResultDTO> GetApplyUser(UserApplySearchDTO dto);
        /// <summary>
        /// 保存批次及用户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool AddApplyUser(BatchApplyOperateDTO dto);
        /// <summary>
        /// 申请用户/申请批次用户(含全部)
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool ApplyUser(BatchApplyOperateDTO dto);
        #endregion

        //#region 用户审核
        ///// <summary>
        ///// 得到所有用户申请信息(含模糊查询)
        ///// </summary>
        ///// <returns></returns>
        List<UserApplyUserResultDTO> GetUserApply(UserApplySearchDTO dto);
        /// <summary>
        /// 用户审核(通过)
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool AuditUserApplyEgis(UserApplyOperateDTO dto);
        /// <summary>
        /// 用户审核(拒绝)
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool AuditUserApplyRefuse(UserApplyOperateDTO dto);
        //#endregion

        //#region 已有用户
        ///// <summary>
        ///// 变更权限
        ///// </summary>
        ///// <param name="dto"></param>
        ///// <returns></returns>
        //bool ChangeUserAut(UserApplyOperateDTO dto);
        //#endregion
    }
}
