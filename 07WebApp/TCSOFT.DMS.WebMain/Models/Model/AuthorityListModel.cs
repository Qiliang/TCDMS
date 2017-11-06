using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCSOFT.DMS.WebMain.Models.Model
{
    using DMS.MasterData.DTO;
    public class AuthorityListModel
    {
        /// <summary>
        /// 第一级
        /// </summary>
        public StructureDTO LevelOne { get; set; }
        /// <summary>
        /// 第二级
        /// </summary>
        public StructureDTO LevelTWO { get; set; }
        /// <summary>
        /// 第三级
        /// </summary>
        public StructureDTO LevelThree { get; set; }
        /// <summary>
        /// 是否选中（有权限）
        /// </summary>
        public bool IsChecked { get; set; }
        /// <summary>
        /// 第三级ID
        /// </summary>
        public string ID
        {
            get
            {
                string id = string.Empty;
                if (LevelThree != null)
                {
                    id = LevelThree.StructureID;
                }
                else if (LevelTWO != null)
                {
                    id = LevelTWO.StructureID;
                }
                else if (LevelOne != null)
                {
                    id = LevelOne.StructureID;
                }
                return id;
            }
        }
        /// <summary>
        /// 第一级描述名
        /// </summary>
        public string LevelOneDes
        {
            get
            {
                return LevelOne != null ? LevelOne.StructureName : string.Empty;
            }
        }
        /// <summary>
        /// 第二级描述名
        /// </summary>
        public string LevelTWODes
        {
            get
            {
                return LevelTWO != null ? LevelTWO.StructureName : string.Empty;
            }
        }
        /// <summary>
        /// 第三级描述名
        /// </summary>
        public string LevelThreeDes
        {
            get
            {
                return LevelThree != null ? LevelThree.StructureName : string.Empty;
            }
        }
    }
}