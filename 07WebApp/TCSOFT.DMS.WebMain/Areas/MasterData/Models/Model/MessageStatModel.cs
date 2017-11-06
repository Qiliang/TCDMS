using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCSOFT.DMS.WebMain.Areas.MasterData.Models.Model
{
    using TCSOFT.DMS.MasterData.DTO.Message;
    public class MessageStatModel : MessageResultDTO
    {
        /// <summary>
        /// 用户类型Name
        /// </summary>
        public string UserTypeName
        {
            get
            {
                string result = string.Empty;
                if (UserType != null)
                {
                    switch (UserType)
                    {
                        case 0:
                            result = "系统管理员";
                            break;
                        case 1:
                            result = "贝克曼";
                            break;
                        case 2:
                            result = "经销商";
                            break;
                    }
                }

                return result;
            }
        }
        /// <summary>
        /// 短信类别
        /// </summary>
        public string MessageTypeStr
        {
            get
            { string result = string.Empty;

                switch (MessageType)
                {
                    case 0: 
                        result="登陆短信";
                        break;
                    case 1 :
                        result="用户申请通知";
                        break;
                }

                return result;
            }
        }
    }
}