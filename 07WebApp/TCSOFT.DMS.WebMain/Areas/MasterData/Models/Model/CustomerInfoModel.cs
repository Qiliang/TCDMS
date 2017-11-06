using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCSOFT.DMS.WebMain.Areas.MasterData.Models.Model
{
    using TCSOFT.DMS.MasterData.DTO.Customer;
    public class CustomerInfoModel : CustomerResultDTO
    {
        /// <summary>
        /// 状态
        /// </summary>
        public string Status
        {
            get
            {
                var result = "停用";
                if (IsActive == true)
                {
                    result = "启用";
                }

                return result;
            }
        }
    }
}