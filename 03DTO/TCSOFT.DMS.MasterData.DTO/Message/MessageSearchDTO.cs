using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.Message
{
    using TCSOFT.DMS.MasterData.DTO.Common;
    public class MessageSearchDTO:PagingDTO
    {
        /// <summary>
        /// 模糊查询
        /// </summary>
        public string  SearchText { get; set; }
    }
}
