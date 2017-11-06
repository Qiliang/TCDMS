using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCSOFT.DMS.MasterData.DTO.Product.ProductLine;

namespace TCSOFT.DMS.WebMain.Areas.MasterData.Models.Model.Product
{
    public class ProductLineResultModel : ProductLineResultDTO
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
        public bool Ischeck { get; set; }
    }
}