using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.Common
{
    public class DepartmentResultDTO
    {
        /// <summary>
        /// 虚拟ID
        /// </summary>
        public int? FictitiousID { get; set; }
        /// <summary>
        /// 部门ID
        /// </summary>
        public int? DepartID { get; set; }
        /// <summary>
        /// 部门父ID
        /// </summary>
        public int? DepartParentID { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartName { get; set; }
        /// <summary>
        /// 部门说明
        /// </summary>
        public string DepartIntroduction { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateUser { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 最后修改人
        /// </summary>
        public string ModifyUser { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime? ModifyTime { get; set; }
        /// <summary>
        /// 子部门
        /// </summary>
        public List<DepartmentResultDTO> children { get; set; }
        public string ParentPathName { get; set; }
        public string PathName
        {
            get
            {
                return (ParentPathName == null ? String.Empty : (ParentPathName + @"\")) + DepartName;
            }
        }
        /// <summary>
        /// 部门路径
        /// </summary>
        public string DepartPath { get; set; }
    }
    public class DepartmentOperateDTO
    {
        /// <summary>
        /// 部门ID
        /// </summary>
        public int? DepartID { get; set; }
        /// <summary>
        /// 部门父ID
        /// </summary>
        public int? DepartParentID { get; set; }
        /// <summary>
        /// 部门路径
        /// </summary>
        public string DepartPath { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartName { get; set; }
        /// <summary>
        /// 部门说明
        /// </summary>
        public string DepartIntroduction { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateUser { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 最后修改人
        /// </summary>
        public string ModifyUser { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime? ModifyTime { get; set; }
    }
    public class DepartmentSearchDTO
    {
        /// <summary>
        /// 部门ID
        /// </summary>
        public int? DepartID { get; set; }
        /// <summary>
        /// 部门父ID
        /// </summary>
        public int? DepartParentID { get; set; }
        /// <summary>
        /// 最后修改人
        /// </summary>
        public string ModifyUser { get; set; }
    }
    public class DepartmentTreeDTO 
    {
        public int? id { get; set; }
        public string text { get; set; }
        public string path { get; set; }
        public List<DepartmentTreeDTO> children { get; set; }
    }
}
