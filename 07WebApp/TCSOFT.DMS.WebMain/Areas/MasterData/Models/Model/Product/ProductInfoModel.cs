using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCSOFT.DMS.MasterData.DTO.Product.ProductInfo;

namespace TCSOFT.DMS.WebMain.Areas.MasterData.Models.Model.Product
{
    public class ProductInfoModel : ProductInfoResultDTO
    {
        /// <summary>
        /// 是否启用string
        /// </summary>
        public string IsActivestr
        {
            get 
            {
                string strIsActive=string.Empty;
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
        /// 是否是3c字符串
        /// </summary>
        public string Is3CStr
        {
            get
            {
                var result = "否";
                if (Is3C == true)
                {
                    result = "是";
                }

                return result;
            }
        }
    }
}