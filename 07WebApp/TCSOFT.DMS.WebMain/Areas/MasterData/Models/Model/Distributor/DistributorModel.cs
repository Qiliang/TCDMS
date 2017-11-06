using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCSOFT.DMS.MasterData.DTO.Distributor.Distributor;

namespace TCSOFT.DMS.WebMain.Areas.MasterData.Models.Model.Distributor
{
    public class DistributorModel : DistributorResultDTO
    {
        /// <summary>
        /// 是否启用str
        /// </summary>
        public string IsActivestr
        {
            get 
            {
                string strIsActive = string.Empty;

                if (IsActive == true)
                {
                    strIsActive = "启用";
                }
                else 
                {
                    strIsActive = "停用";
                }

                return strIsActive;
            }
        }
        /// <summary>
        /// 是否有附件
        /// </summary>
        public bool? IsAtt { get; set; }
    }
}