using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.Fcpa.DTO.Org
{
    public class OrgResultDTO : FcpaDTO
    {
        public string ID { get; set; }
        public string DistributorName { get; set; }//公司
        public string OrgMap { get; set; }//组织架构图
        public string Trains { get; set; }//培训人员名单
        public string Status { get; set; }//状态       
        public DateTime? OrgMapUpdateTime { get; set; }//组织架构图更新日期
        public DateTime? TrainsUpdateTime { get; set; }//培训人员名单更新日期
        public int? ValidNum { get; set; }//实际证书效期内的人员人数
        public int? ShouldNum { get; set; }//应参与培训的人员人数
        public double? Rate { get; set; }//完成率
        public string OrgMapFile { get; set; }       
    }
}
