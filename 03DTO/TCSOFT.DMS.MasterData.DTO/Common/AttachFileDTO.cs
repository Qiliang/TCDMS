using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.Common
{
    public class AttachFileOperateDTO:OperateDTO
    {
        /// <summary>
        /// 附件ID
        /// </summary>
        public Guid? AttachFileID { get; set; }
        /// <summary>
        /// 附件名
        /// </summary>
        public string AttachFileName { get; set; }
        /// <summary>
        /// 原始名
        /// </summary>
        public string AttachFileSrcName { get; set; }
        /// <summary>
        /// 扩展名
        /// </summary>
        public string AttachFileExtentionName { get; set; }
        /// <summary>
        /// 所属模块
        /// </summary>
        public short? BelongModule { get; set; }
        /// <summary>
        /// 所属模块主键
        /// </summary>
        public string BelongModulePrimaryKey { get; set; }
    }
    public class AttachFileResultDTO 
    {
        /// <summary>
        /// 附件ID
        /// </summary>
        public Guid? AttachFileID { get; set; }
        /// <summary>
        /// 附件名
        /// </summary>
        public string AttachFileName { get; set; }
        /// <summary>
        /// 原始名
        /// </summary>
        public string AttachFileSrcName { get; set; }
        /// <summary>
        /// 扩展名
        /// </summary>
        public string AttachFileExtentionName { get; set; }
        /// <summary>
        /// 所属模块
        /// </summary>
        public short? BelongModule { get; set; }
        /// <summary>
        /// 所属模块主键
        /// </summary>
        public string BelongModulePrimaryKey { get; set; }
    }
    public class AttachFileSearchDTO
    {
        /// <summary>
        /// 附件ID
        /// </summary>
        public Guid? AttachFileID { get; set; }
        /// <summary>
        /// 所属模块
        /// </summary>
        public short? BelongModule { get; set; }
        /// <summary>
        /// 所属模块主键
        /// </summary>
        public string BelongModulePrimaryKey { get; set; }
    }
}
