using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.UserApply.DTO.ImportExcel
{
    public class ExcelUserApply : ExcelImportDataDTO
    {
        /// <summary>
        /// 用户申请的姓名
        /// </summary>
        public string UserApplyName { get; set; }
        /// <summary>
        /// 用户申请手机号
        /// </summary>
        public string UserPhone { get; set; }
        /// <summary>
        /// 用户申请邮箱
        /// </summary>
        public string UserEmail { get; set; }
        /// <summary>
        /// 用户申请模块
        /// </summary>
        public string UserModule { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>
        public short? AuditStatus { get; set; }
        /// <summary>
        /// 用户申请的模块的权限IDList
        /// </summary>
        public List<string> UserModuleList
        {
            get
            {
                List<string> ModuleList = new List<string>();
                if (!string.IsNullOrEmpty(UserModule))
                {
                    string ModuleString = string.Empty;

                    UserModule.Split(',').ToList().ForEach(m =>
                        {
                            ModuleString = m.Trim();
                            if (!string.IsNullOrEmpty(ModuleString))
                            {
                                ModuleList.Add(ModuleString);
                            }
                        });
                }

                return ModuleList;
            }
        }
        /// <summary>
        /// 审核角色id
        /// </summary>
        public string Userroleidstr { get; set; }
        /// <summary>
        /// 权限
        /// </summary>
        public List<UserApplyAut> userapplyAut { get; set; }
        /// <summary>
        /// 用户申请时间
        /// </summary>
        public DateTime? UserInfoTime { get; set; }
        /// <summary>
        /// 经销商IDList
        /// </summary>
        public string DistriButorIDStr { get; set; }
        public List<string> DistriButorIDList
        {
            get
            {
                List<string> DisList = new List<string>();
                if (!string.IsNullOrEmpty(DistriButorIDStr))
                {
                    string dissrt = string.Empty;
                    DistriButorIDStr.Split(',').ToList().ForEach(m =>
                        {
                            dissrt = m.Trim();
                            if (!string.IsNullOrEmpty(dissrt))
                            {
                                DisList.Add(dissrt);
                            }
                        });
                }

                return DisList;
            }
        }
        /// <summary>
        /// 导入逻辑（1新增，2修改）
        /// </summary>
        public int UpLogic { get; set; }
        public string CheckInfo { get; set; }
        /// <summary>
        /// 用户类型
        /// </summary>
        public string UserApplyType { get; set; }
    }
    
    public class ExcelBatch : ExcelImportDataDTO
    {
        /// <summary>
        /// 批次ID
        /// </summary>
        public Guid? BatchID { get; set; }
        /// <summary>
        ///批次申请的名字，年月日时分秒
        /// </summary>
        public string BatchName { get; set; }

        /// <summary>
        /// 申请人邮箱
        /// </summary>
        public string ApplyUserEamil { get; set; }
        /// <summary>
        /// 申请人手机号码
        /// </summary>
        public string ApplyUserPhone { get; set; }
        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime? ApplyTime { get; set; }
        /// <summary>
        /// 一个批次次用户申请的内容
        /// </summary>
        public List<ExcelUserApply> ExcelUserApply { get; set; }
        public string CreateUser { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>
        public short? AuditStatus { get; set; }
        /// <summary>
        /// 状态，  1是批次，二是单个。
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 申请人姓名
        /// </summary>
        public string ApplyUser { get; set; }
        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime UserApplyTime { get; set; }
        
    }
    public class UserApplyAut
    {
        // <summary>
        /// 结构ID
        /// </summary>
        public string StructureID { get; set; }
        /// <summary>
        /// 所属按钮权限
        /// </summary>
        public int? ButtonAuthority { get; set; }
    }
}
