using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.UserApply.DTO.Common
{
    [Serializable]
    public class ResultDTO<T> : PagingDTO
    {
        public ResultDTO()
        {
            SubmitResult = false;
        }
        public Exception Exception { get; set; }

        public bool SubmitResult { get; set; }

        public string Message { get; set; }

        public T Object { get; set; }
    }
}
