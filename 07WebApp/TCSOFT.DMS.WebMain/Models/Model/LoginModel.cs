using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCSOFT.DMS.WebMain.Models.Model
{
    using MasterData.DTO;
    public class LoginModel:LoginDTO
    {
        public string ValidateCode
        {
            get;
            set;
        }
    }
}