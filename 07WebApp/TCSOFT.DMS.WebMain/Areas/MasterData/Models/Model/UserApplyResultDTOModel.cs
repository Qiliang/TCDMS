using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCSOFT.DMS.UserApply.DTO.User.UserApply;

namespace TCSOFT.DMS.WebMain.Areas.MasterData.Models.Model
{
    public class UserApplyResultDTOModel : UserApplyUserResultDTO
    {
        public string UserApplyTypestr
        {
            get
            {
                string typestr = string.Empty;
                if (UserApplyType != null)
                {
                    switch (UserApplyType)
                    {
                        case 0:
                            typestr = "系统管理员";
                            break;
                        case 1:
                            typestr = "贝克曼";
                            break;
                        case 2:
                            typestr = "经销商";
                            break;
                    }
                }
                return typestr;
            }
        }
        public string UserApplyTimestr
        {
            get
            {
                return UserApplyTime != null ? UserApplyTime.Value.ToString("yyyy-MM-dd") : string.Empty;
            }
        }
        public string AuditStatusstr
        {
            get
            {
                string auditst = string.Empty;
                switch (AuditStatus)
                {
                    case 0:
                        auditst = "申请中";
                        break;
                    case 1:
                        auditst = "审核失败";
                        break;
                    case 2:
                        auditst = "审核成功";
                        break;
                    case 3:
                        auditst = "已保存";
                        break;
                }
                return auditst;
            }
        }
        public string DistributorIDlist 
        {
            get 
            {
                string dislist = string.Empty;

                if (!string.IsNullOrEmpty(DistributorIDList)) 
                {
                    Guid dis = Guid.Empty;
                    if (Guid.TryParse(DistributorIDList.Split(',').ToList().FirstOrDefault(), out dis))
                    {
                        dislist = dis.ToString();
                    }
                }

                return dislist;
            }
        }
        /// <summary>
        /// 是否为批次 附件
        /// </summary>
        public bool? IsAtt { get; set; }
        /// <summary>
        /// 附件 文件名称
        /// </summary>
        public string AttName { get; set; }
        /// <summary>
        /// 附件 原文件名称
        /// </summary>
        public string AttSrcName { get; set; }
        /// <summary>
        /// 附件 扩展名
        /// </summary>
        public string AttExtentionName { get; set; }
    }
}