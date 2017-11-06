using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.Fcpa.DTO.Credential
{
    public class CredentialResultDTO : FcpaDTO
    {
        public Guid ID { get; set; }
        public DistributorResultDTO Distributor { get; set; }//公司 
        public String DistributorName { get; set; }//公司名称
        public string Certificate { get; set; }//证书
        public int? Status { get; set; }//状态
        public string StatusDesc { get; set; }//状态描述
        public string Name { get; set; }//姓名
        public string Department { get; set; }//部门
        public string Title { get; set; }//职位
        public DateTime? CompletedDate { get; set; }//培训完成日期
        public bool? OffWork { get; set; }//在职状态
        public DateTime? OffWorkDate { get; set; }//离职时间
        public string OffWorkDesc { get; set; }//在职状态显示
        public bool? Domain1 { get; set; }//所属领域
        public bool? Domain2 { get; set; }//所属领域
        public string Domain { get; set; }//所属领域
        public string DomainDesc { get; set; }//所属领域显示
        public DateTime? UpdateDate { get; set; } //更新日期
        public DateTime? ExpireDate { get; set; }//过期日期
        public string Remark { get; set; }//备注
    }
}
