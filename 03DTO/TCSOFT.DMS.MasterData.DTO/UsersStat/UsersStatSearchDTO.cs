using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.UsersStat
{
    using TCSOFT.DMS.MasterData.DTO.Common;
    public class UsersStatSearchDTO:PagingDTO
    {
        /// <summary>
        /// 模糊查询
        /// </summary>
        public string SearchText { get; set; }
        /// <summary>
        /// 用户类型
        /// </summary>
        public int? UserType
        {
            get
            {
                int? result = null;
                if (!string.IsNullOrEmpty(SearchText))
                {
                    if ("系统管理员".Contains(SearchText))
                    {
                        result = 0;
                    }
                    else if ("贝克曼".Contains(SearchText))
                    {
                        result = 2;
                    }
                    else if ("经销商".Contains(SearchText))
                    {
                        result = 2;
                    }
                }
                return result;
            }
        }
    }
}
