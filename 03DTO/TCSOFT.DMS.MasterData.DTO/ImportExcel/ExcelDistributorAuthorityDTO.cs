using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.ImportExcel
{
    public class ExcelDistributorAuthorityDTO : ExcelImportDataDTO
    {
        public string DistributorName { get; set; }
        public string IsOrderGoodsstr { get; set; }
        public string ProductLineNamestr { get; set; }
        public List<string> ProductLineNamelist
        {
            get
            {
                List<string> ProductLinelist = new List<string>();
                if (!string.IsNullOrEmpty(ProductLineNamestr))
                {
                    string ProductLinestr = string.Empty;

                    ProductLineNamestr.Split(',').ToList().ForEach(g =>
                    {
                        ProductLinestr = g.Trim();
                        if (!string.IsNullOrEmpty(ProductLinestr))
                        {
                            ProductLinelist.Add(ProductLinestr);
                        }
                    });
                }

                return ProductLinelist;
            }
        }
        public string RegionNamestr { get; set; }
        public List<string> RegionNamelist
        {
            get
            {
                List<string> Regionlist = new List<string>();
                if (!string.IsNullOrEmpty(RegionNamestr))
                {
                    string Regionstr = string.Empty;

                    RegionNamestr.Split(',').ToList().ForEach(g =>
                    {
                        Regionstr = g.Trim();
                        if (!string.IsNullOrEmpty(Regionstr))
                        {
                            Regionlist.Add(Regionstr);
                        }
                    });
                }

                return Regionlist;
            }
        }
        public string PayNamestr { get; set; }
        public List<string> PayNamelist
        {
            get
            {
                List<string> Paylist = new List<string>();
                if (!string.IsNullOrEmpty(PayNamestr))
                {
                    string Paystr = string.Empty;

                    PayNamestr.Split(',').ToList().ForEach(g =>
                    {
                        Paystr = g.Trim();
                        if (!string.IsNullOrEmpty(Paystr))
                        {
                            Paylist.Add(Paystr);
                        }
                    });
                }

                return Paylist;
            }
        }
        public string TransportNamestr { get; set; }
        public List<string> TransportNamelist
        {
            get
            {
                List<string> Transportlist = new List<string>();
                if (!string.IsNullOrEmpty(TransportNamestr))
                {
                    string Transportstr = string.Empty;

                    TransportNamestr.Split(',').ToList().ForEach(g =>
                    {
                        Transportstr = g.Trim();
                        if (!string.IsNullOrEmpty(Transportstr))
                        {
                            Transportlist.Add(Transportstr);
                        }
                    });
                }

                return Transportlist;
            }
        }
        /// <summary>
        /// 导入逻辑（1新增，2修改）
        /// </summary>
        public int UpLogic { get; set; }
        public string CheckInfo { get; set; }
    }
}
