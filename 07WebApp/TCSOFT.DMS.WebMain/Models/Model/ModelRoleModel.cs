using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCSOFT.DMS.WebMain.Models.Model
{
    class ModelRoleModel
    {
        static ModelRoleModel() 
        {
            ModelRolelist = new List<ModelRole>() { 
                new ModelRole() { ModelID = "095",ModelName = "基础数据",RoleID = 2 },
                new ModelRole() { ModelID = "005",ModelName = "订购系统（贝克曼）",RoleID = 3 },
                new ModelRole() { ModelID = "100",ModelName = "订购系统（经销商）",RoleID = 3 },
                new ModelRole() { ModelID = "015",ModelName = "销售库存（贝克曼）",RoleID = 4 },
                new ModelRole() { ModelID = "105",ModelName = "销售库存（经销商）",RoleID = 4 },
                new ModelRole() { ModelID = "035",ModelName = "评估系统（贝克曼）",RoleID = 5 },
                new ModelRole() { ModelID = "115",ModelName = "评估系统（经销商）",RoleID = 5 },
                new ModelRole() { ModelID = "065",ModelName = "资料文档（贝克曼）",RoleID = 6 },
                new ModelRole() { ModelID = "130",ModelName = "资料文档（经销商）",RoleID = 6 },
                new ModelRole() { ModelID = "055",ModelName = "公告发布（贝克曼）",RoleID = 7 },
                new ModelRole() { ModelID = "125",ModelName = "公告发布（经销商）",RoleID = 7 },
                new ModelRole() { ModelID = "045",ModelName = "CF贝克曼",RoleID = 8 },
                new ModelRole() { ModelID = "120",ModelName = "CF经销商",RoleID = 8 },
                new ModelRole() { ModelID = "025",ModelName = "ScoreCard贝克曼",RoleID = 9 },
                new ModelRole() { ModelID = "110",ModelName = "ScoreCard经销商",RoleID = 9 },
                new ModelRole() { ModelID = "075",ModelName = "FCPA贝克曼",RoleID = 10 },
                new ModelRole() { ModelID = "135",ModelName = "FCPA经销商",RoleID = 10 },
                new ModelRole() { ModelID = "080",ModelName = "报表系统",RoleID = 11 },
                new ModelRole() { ModelID = "085",ModelName = "合同管理系统",RoleID = 12 },
                new ModelRole() { ModelID = "090",ModelName = "租赁管理系统",RoleID = 13 },
            };
        }
        public static List<ModelRole> ModelRolelist { get; set; }
    }
    /// <summary>
    /// 模块   对应的   角色
    /// </summary>
    class ModelRole 
    {
        /// <summary>
        /// 模块ID
        /// </summary>
        public string ModelID { get; set; }
        /// <summary>
        /// 模块Name
        /// </summary>
        public string ModelName { get; set; }
        /// <summary>
        /// 角色ID
        /// </summary>
        public int RoleID { get; set; }
    }
}