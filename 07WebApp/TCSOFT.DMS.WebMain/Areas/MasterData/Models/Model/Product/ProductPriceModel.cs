using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCSOFT.DMS.MasterData.DTO.Product.ProductPriceInfo;

namespace TCSOFT.DMS.WebMain.Areas.MasterData.Models.Model.Product
{
    public class ProductPriceModel : ProductPriceInfoResultDTO
    {
        public int Index { get; set; }
        /// <summary>
        /// 产品ID
        /// </summary>
        public Guid? ProductID
        {
            get
            {
                Guid? guid=null ;

                if (Product != null)
                {
                    guid = Product.ProductID;
                }

                return guid;
            }
        }
        /// <summary>
        /// 货号
        /// </summary>
        public string ArtNo
        {
            get 
            {
                string strArtNo=string.Empty;

                if (Product != null) 
                {
                     strArtNo= Product.ArtNo;
                }

                return strArtNo;
            }
        }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName
        {
            get
            {
                string strProductName = string.Empty;
                if (Product != null)
                {
                    strProductName = Product.ProductName;
                }

                return strProductName;
            }
        }
        /// <summary>
        /// 产品线
        /// </summary>
        public string ProductLineName
        {
            get
            {
                string strProductLineName = string.Empty;

                if (Product != null)
                {
                    strProductLineName = Product.ProductLineName;
                }

                return strProductLineName;
            }
        }
    }
}