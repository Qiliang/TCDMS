using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO
{
    [Serializable]
    public class ButtonDTO
    {
        public int ButtonID { get; set; }
        public string ButtonName { get; set; }
        public string ButtonValue { get; set; }
        public string ButtonJavascript { get; set; }
        public bool IsVisible { get; set; }
        public string IconName { get; set; }
        public int IndexCode { get; set; }
    }
}
