using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace TCSOFT.DMS.WebMain.Models.Provider
{
    using Model;
    using Common;
    using MasterData.DTO;
    using TCSOFT.DMS.Common;
    using TCSOFT.DMS.MasterData.DTO.Common;
    using TCSOFT.DMS.MasterData.DTO.Message;
    using TCSOFT.DMS.MasterData.DTO.User;
    using TCSOFT.DMS.WebMain.Areas.MasterData.Models.Provider;
    public class HomeProvider:BaseProvider
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="lngdto"></param>
        /// <returns></returns>
        public static UserLoginDTO Login(LoginDTO lngdto)
        {
            //var gg =GlobalStaticData.StructureInfo;
            UserLoginDTO ulngdto = null;

            ulngdto = GetAPI<UserLoginDTO>(WebConfiger.MasterDataServicesUrl + "Login?logins=" + TransformHelper.ConvertDTOTOBase64JsonString(lngdto));
          
            return ulngdto;
        }

        /// <summary>
        /// 获取所有结构信息
        /// </summary>
        /// <returns></returns>
        public static List<StructureDTO> GetStructureInfo()
        {
            List<StructureDTO> result = GetAPI<List<StructureDTO>>(WebConfiger.MasterDataServicesUrl + "Common?type=1");

            return result;
        }

        /// <summary>
        /// 获取所有按钮信息
        /// </summary>
        /// <returns></returns>
        public static List<ButtonDTO> GetButtonInfo()
        {
            List<ButtonDTO> result = GetAPI<List<ButtonDTO>>(WebConfiger.MasterDataServicesUrl + "Common?type=2");

            return result;
        }
        /// <summary>
        /// 检测手机号是否存在及是否拥有权限
        /// </summary>
        /// <param name="PhoneNumber"></param>
        /// <param name="ErrorStatusCode">1：手机号不存在 2：没权限</param>
        /// <returns></returns>
        public static bool CheckPhoneNumber(string PhoneNumber,ref short ErrorStatusCode)
        {
            ErrorStatusCode = GetAPI<short>(WebConfiger.MasterDataServicesUrl + "Login?PhoneNumber=" + PhoneNumber + "&validecode=''");
            bool result = ErrorStatusCode == 0;

            return result;
        }
        /// <summary>
        /// 保存密码
        /// </summary>
        /// <param name="PhoneNumber"></param>
        /// <param name="strDymicPassword"></param>
        /// <param name="intValidDate"></param>
        /// <returns></returns>
        public static bool SaveDymicPassword(MoblieLoginDTO mldto)
        {
            bool result = PutAPI<bool>(WebConfiger.MasterDataServicesUrl + "Login", mldto);

            return result;
        }

        /// <summary>
        /// 记录短信登录
        /// </summary>
        /// <param name="PhoneNumber"></param>
        /// <param name="SendContent"></param>
        /// <returns></returns>
        public static bool SaveMessageLog(string PhoneNumber, string SendContent = null)
        {
            bool result = false;

            UserSearchDTO dto = new UserSearchDTO();
            dto.PhoneNumber = PhoneNumber;
            dto.page = 1;
            dto.rows = 1;
            var user = UserAuthorityProvider.GetUser(dto);

            List<MessageOperateDTO> msgdtolist = new List<MessageOperateDTO>();
            msgdtolist.Add(new MessageOperateDTO
            {
                UserID = user.Object.Select(m => m.UserID).FirstOrDefault(),
                SendTime = DateTime.Now,
                MessageType = 0
            });

            TCSOFT.DMS.WebMain.Models.Provider.CommonProvider.AddMessageStat(msgdtolist);

            return result;
        }
        /// <summary>
        /// 上传附件
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> AddAttachFileList(List<AttachFileOperateDTO> dtolist)
        {
            ResultData<object> result = null;

            result = PostAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "AttachFile", dtolist);

            return result;
        }
        #region 提醒管理
        /// <summary>
        /// 得到提醒信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<List<WarningDTO>> GetWarningInfo(WarningSearchDTO dto)
        {
            ResultData<List<WarningDTO>> result = new ResultData<List<WarningDTO>>();

            result = GetAPI<ResultData<List<WarningDTO>>>(WebConfiger.MasterDataServicesUrl + "Warning?WarningSearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return result;
        }
        /// <summary>
        /// 新增提醒管理
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultDTO<object> AddWarningInfo(WarningDTO dto)
        {
            ResultDTO<object> resultdto = new ResultDTO<object>();

            resultdto = PostAPI<ResultDTO<object>>(WebConfiger.MasterDataServicesUrl + "Warning", dto);

            return resultdto;
        }
        /// <summary>
        /// 删除一条提醒信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static bool DeleteWarningInfo(WarningSearchDTO dto)
        {
            bool blResult = DeleteAPI<bool>(WebConfiger.MasterDataServicesUrl + "Warning?WarningSearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return blResult;
        }
        #endregion
    }
}