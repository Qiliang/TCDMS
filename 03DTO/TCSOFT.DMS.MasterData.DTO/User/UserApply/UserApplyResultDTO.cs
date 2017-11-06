using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.User.UserApply
{
    public class UserApplyResultDTO
    {
        /// <summary>
        /// 用户申请流水ID
        /// </summary>
        public int UserApplyID { get; set; }
        /// <summary>
        /// 批次ID
        /// </summary>
        public Guid? BatchID { get; set; }
        /// <summary>
        /// 变更权限用户ID
        /// </summary>
        public int? UserChangeID { get; set; }
        /// <summary>
        /// 用户申请姓名
        /// </summary>
        public string UserApplyName { get; set; }
        /// <summary>
        /// 申请手机号
        /// </summary>
        public string UserApplyTelNumber { get; set; }
        /// <summary>
        /// 申请邮箱
        /// </summary>
        public string UserApplyEmail { get; set; }
        /// <summary>
        /// 申请用户类型
        /// </summary>
        public short UserApplyType { get; set; }
        public string UserApplyTypeName
        {
            get
            {
                string result = string.Empty;

                switch (UserApplyType)
                {
                    case 1:
                        result = "贝克曼";
                        break;
                    case 2:
                        result = "经销商";
                        break;
                }

                return result;
            }
        }
        /// <summary>
        /// 经销商IDList
        /// </summary>
        public string DistributorIDList { get; set; }

        /// <summary>
        /// 经销商NameList
        /// </summary>
        public List<string> DistributorNameList { get; set; }
        /// <summary>
        /// 经销商Name字符串
        /// </summary>
        public string DistributorName
        {
            get
            {
                string DistributorNamestr = string.Empty;
                string DistributorNameListStr = string.Empty;
                if (!string.IsNullOrEmpty(DistributorNameListStr))
                {
                    DistributorNameListStr = DistributorNameList.ToString();
                    if (!string.IsNullOrEmpty(DistributorNameListStr))
                    {
                        var pp = DistributorNameListStr.Split(',');
                        if (pp.Count() > 0)
                        {
                            DistributorNamestr = pp.FirstOrDefault();
                        }
                    }
                }
                return DistributorNamestr;
            }
        }
        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime? UserApplyTime { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>
        public int? AuditStatus { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>
        public string AuditStatusName
        {
            get
            {
                string result = string.Empty;

                if (AuditStatus != null)
                {
                    switch (AuditStatus)
                    {
                        case 0:
                            result = "待审核";
                            break;
                        case 1:
                            result = "审核失败";
                            break;
                        case 2:
                            result = "审核通过";
                            break;
                    }
                }

                return result;
            }
        }
        /// <summary>
        /// 审核人ID
        /// </summary>
        public int? AuditUserID { get; set; }
        /// <summary>
        /// 审核失败原因
        /// </summary>
        public string AuditFalseReason { get; set; }
        /// <summary>
        /// 用户申请权限
        /// </summary>
        public List<UserApplyAuthority> ApplyUserAuthority { get; set; }
        /// <summary>
        /// 第一个经销商
        /// </summary>
        public string Distributorid
        {
            get
            {
                string DistributorIDstr = string.Empty;
                if (!string.IsNullOrEmpty(DistributorIDList))
                {
                    var pp = DistributorIDList.Split(',').ToList();
                    if (pp.Count() > 0)
                    {
                        DistributorIDstr = pp.FirstOrDefault();
                    }
                }

                return DistributorIDstr;
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
