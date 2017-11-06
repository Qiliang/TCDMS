using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCSOFT.DMS.MasterData.DTO.User;

namespace TCSOFT.DMS.WebMain.Areas.User.Models.Model
{
    public class UserModel : UserResultDTO
    {
        /// <summary>
        /// 用户类型
        /// </summary>
        public string UserTypestr 
        {
            get 
            {
                string Utstr = string.Empty;
                switch (UserType) 
                {
                    case 0:
                        Utstr = "系统管理员";
                        break;
                    case 1:
                        Utstr = "贝克曼";
                        break;
                    case 2:
                        Utstr = "经销商";
                        break;
                }
                return Utstr; 
            } 
        }
        /// <summary>
        /// 
        /// </summary>
        public string StopTimestr
        {
            get
            {
                string isstr = string.Empty;
                if (StopTime != null)
                {
                    isstr = StopTime.Value.ToString("yyyy-MM-dd");
                }
                return isstr;
            }
        }
        public string NoActiveTimestr
        {
            get
            {
                string isstr = string.Empty;
                if (NoActiveTime != null)
                {
                    isstr = NoActiveTime.Value.ToString("yyyy-MM-dd");
                }
                return isstr;
            }
        }
    }
}