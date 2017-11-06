using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCSOFT.DMS.WebMain.Areas.MasterData.Models.Model
{
    using TCSOFT.DMS.MasterData.DTO.Common;
    public class FeedbackModel : FeedbackResultDTO
    {
        /// <summary>
        /// 状态字符串
        /// </summary>
        public string FeedbackStausStr
        {
            get
            {
                string result = string.Empty;

                switch (FeedbackStaus)
                { 
                    case 0:
                        result = "待处理";
                        break;
                    case 1:
                        result = "已处理";
                        break;
                }

                return result;
            }
        }
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
        /// 下载标识
        /// </summary>
        public bool DownLoadFeedback
        {
            get
            {
                bool result = false;

                if (AttachFile != null)
                {
                    result = true;
                }

                return result;
            }
        }
        /// <summary>
        /// 附件文件名
        /// </summary>
        public string AttachFileName
        {
            get
            {
                string result = string.Empty;

                if (AttachFile != null)
                {
                    result = AttachFile.AttachFileName;
                }

                return result;
            }
        }
        /// <summary>
        /// 附件原文件名
        /// </summary>
        public string AttachFileSrcName
        {
            get
            {
                string result = string.Empty;

                if (AttachFile != null)
                {
                    result = AttachFile.AttachFileSrcName;
                }

                return result;
            }
        }
        /// <summary>
        /// 附件扩展名
        /// </summary>
        public string AttachFileExtentionName
        {
            get
            {
                string result = string.Empty;

                if (AttachFile != null)
                {
                    result = AttachFile.AttachFileExtentionName;
                }

                return result;
            }
        }
    }
}