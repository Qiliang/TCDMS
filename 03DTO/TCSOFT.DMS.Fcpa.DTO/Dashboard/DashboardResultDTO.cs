using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
          
namespace TCSOFT.DMS.Fcpa.DTO.Dashboard
{
    public class DashboardResultDTO : FcpaDTO
    {
        [JsonProperty(PropertyName = "value")]
        public int Count { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Status { get; set; }
    }
}
