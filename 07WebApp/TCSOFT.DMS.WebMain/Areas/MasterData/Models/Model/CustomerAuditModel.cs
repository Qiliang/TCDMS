using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCSOFT.DMS.WebMain.Areas.MasterData.Models.Model
{
    using TCSOFT.DMS.MasterData.DTO.CustomerAudit;
    public class CustomerAuditModel : CustomerAuditResultDTO
    {
        /// <summary>
        /// 审核状态字符串
        /// </summary>
        public string StatusStr
        {
            get
            {
                var result = string.Empty;
                switch (Status)
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

                return result;
            }
        }
    }
}