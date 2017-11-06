using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCSOFT.DMS.MasterData.DTO.Common;

namespace TCSOFT.DMS.WebMain.Models.Model
{
    [Serializable]
    public class ResultData<T> : PagingDTO
    {
        public ResultData()
        {
            SubmitResult = false;
        }
        public Exception Exception { get; set; }

        public bool SubmitResult { get; set; }

        public string Message { get; set; }

        public T Object { get; set; }
    }
}