using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.Services
{
    using Entities;
    /// <summary>
    /// 日志类型
    /// </summary>
    public enum LogType
    {
        /// <summary>
        /// 新增
        /// </summary>
        ADD=1,
        /// <summary>
        /// 删除
        /// </summary>
        DELETE,
        /// <summary>
        /// 导入
        /// </summary>
        IMPORT,
        /// <summary>
        /// 停用
        /// </summary>
        UNENABLE
    }
    /// <summary>
    /// 日志数据
    /// </summary>
    public sealed class LogData
    {
        /// <summary>
        /// 日志详细
        /// </summary>
        public string LogDetails { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public string OpratorName { get; set; }
        /// <summary>
        /// 当前日志类型
        /// </summary>
        public LogType CurrentLogType { get; set; }
    }
    /// <summary>
    /// 服务基类
    /// </summary>
    public class BaseServices
    {
        /// <summary>
        /// 新增日志
        /// </summary>
        /// <param name="tcdmse">当前上下文数据集</param>
        /// <param name="lngdata">日志数据</param>
        protected void AddLog(TCDMS_MasterDataEntities tcdmse, LogData lngdata)
        {
            string strBelongFunc = null;

            switch (lngdata.CurrentLogType)
            {
                case LogType.ADD:
                    strBelongFunc = "新增";
                    break;
                case LogType.DELETE:
                    strBelongFunc = "删除";
                    break;
                case LogType.IMPORT:
                    strBelongFunc = "导入";
                    break;
                case LogType.UNENABLE:
                    strBelongFunc = "停用";
                    break;
            }

            tcdmse.common_LogInfo.Add(new common_LogInfo {
                            BelongModel = "基础数据",
                            BelongFunc = strBelongFunc,
                            LogDetails = lngdata.LogDetails,
                            LogDate = DateTime.Now,
                            OpratorName = lngdata.OpratorName
                        });
        }
    }
}
