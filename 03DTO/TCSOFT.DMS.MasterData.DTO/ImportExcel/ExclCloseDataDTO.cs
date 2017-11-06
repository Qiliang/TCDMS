using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.ImportExcel
{
    //关帐日实体类，2017/06/08  1.导入功能引用遍历
    public class ExclCloseDataDTO : ExcelImportDataDTO
    {
        /// <summary>
        /// 关帐日名称
        /// </summary>
        public string AccountDateName { get; set; }
        /// <summary>
        /// 关帐日年份
        /// </summary>
        public string AccountDateYear { get; set; }
        /// <summary>
        /// 地点
        /// </summary>
        public string AccountDatePlace { get; set; }
        /// <summary>
        /// 一月
        /// </summary>
        public string MonthDate { get; set; }
        /// <summary>
        /// 日期格式转换判断成功还是失败，如果填写了错误的日期，默认强制赋值为空
        /// </summary>
        public string MonthDateIf
        {
            get
            {
                try
                {
                    Convert.ToDateTime(MonthDate);
                }
                catch { MonthDate = ""; }
                return MonthDate;
            }


        }
        /// <summary>
        /// 二月
        /// </summary>
        public string FebDate { get; set; }
        /// <summary>
        ///  日期格式转换判断成功还是失败，如果填写了错误的日期，默认强制赋值为空
        /// </summary>
        public string FebDateIf
        {
            get 
            {
                try
                {
                    Convert.ToDateTime(FebDate);
                }
                catch { FebDate = ""; }
                return FebDate;
            }
        }
        /// <summary>
        /// 三月
        /// </summary>
        public string MarchDate { get; set; }
        public string MarchDateIf
        {
            get
            {
                try
                {
                    Convert.ToDateTime(MarchDate);
                }
                catch { MarchDate = ""; }
                return MarchDate;
            }
        }
        /// <summary>
        /// 四月
        /// </summary>
        public string AprilDate { get; set; }
        public string AprilDateIf
        {
            get
            {
                try
                {
                    Convert.ToDateTime(AprilDate);
                }
                catch { AprilDate = ""; }
                return AprilDate;
            }
        }
        /// <summary>
        /// 五月
        /// </summary>
        public string MayDate { get; set; }
        public string MayDateIf { 
            get
            {
                try
                {
                    Convert.ToDateTime(MayDate);
                }
                catch { MayDate = ""; }
                return MayDate;
            }
        }
        /// <summary>
        /// 六月
        /// </summary>
        public string JuneDate { get; set; }
        public string JuneDateIf
        {
            get 
            {
                try
                {
                    Convert.ToDateTime(JuneDate);
                }
                catch { JuneDate = ""; }
                return JuneDate;
            }
        }
        /// <summary>
        /// 七月
        /// </summary>
        public string JulyDate { get; set; }
        public string JulyDateIf
        {
            get
            {
                try
                {
                    Convert.ToDateTime(JulyDate);
                }
                catch { JulyDate = ""; }
                return JulyDate;
            }
        }

        /// <summary>
        /// 八月
        /// </summary>
        public string AugustDate { get; set; }
        public string AugustDateIf
        {
            get
            {
                try
                {
                    Convert.ToDateTime(AugustDate);
                }
                catch { AugustDate = ""; }
                return AugustDate;
            }
        }
        /// <summary>
        /// 九月
        /// </summary>
        public string SepDate { get; set; }
        public string SepDateDateIf
        {
            get
            {
                try
                {
                    Convert.ToDateTime(SepDate);
                }
                catch { SepDate = ""; }
                return SepDate;
            }
        }
        /// <summary>
        /// 十月
        /// </summary>
        public string OctDate { get; set; }
        public string OctDateIf
        {
            get
            {
                try
                {
                    Convert.ToDateTime(OctDate);
                }
                catch { OctDate = ""; }
                return OctDate;
            }
        }
        /// <summary>
        /// 十一月
        /// </summary>
        public string NovDate { get; set; }
        public string NovDateIf
        {
            get
            {
                try
                {
                    Convert.ToDateTime(NovDate);
                }
                catch { NovDate = ""; }
                return NovDate;
            }
        }
        /// <summary>
        /// 十二月
        /// </summary>
        public string DecDate { get; set; }
        public string DecDateIf
        {
            get
            {
                try
                {
                    Convert.ToDateTime(DecDate);
                }
                catch { DecDate = ""; }
                return DecDate;
            }
        }
        public string CheckInfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AccountDateBelongModelstr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> AccountDateBelongModellist
        {
            get
            {
                List<string> Modeullists = new List<string>();
                if (!string.IsNullOrEmpty(AccountDateBelongModelstr))
                {
                    string Modeullistr = string.Empty;

                    AccountDateBelongModelstr.Split(',').ToList().ForEach(g =>
                    {
                        Modeullistr = g.Trim();
                        if (!string.IsNullOrEmpty(Modeullistr))
                        {
                            Modeullists.Add(Modeullistr);
                        }
                    });
                }
                else
                {
                    Modeullists.Add("全部");
                }

                return Modeullists;
            }
        }

    }
}
