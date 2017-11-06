using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCSOFT.DMS.Fcpa.DTO;

namespace TCSOFT.DMS.WebMain.Areas.Fcpa.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Login()
        {
            var result = new { a = 1, b = 2 };
            return Json(result, JsonRequestBehavior.AllowGet);

        }

        private UserInfoDTO GetUser(string userCode)
        {
            throw new NotImplementedException();
          
            //var res = fcpa.fcpa_UserInfo.Where(p => p.UserCode == userCode).FirstOrDefault();
            //if (res == null)
            //    return null;
            //var user = new UserToken();
            //user.UserCode = res.UserCode;
            //user.FullName = res.FullName;
            //user.Phone = res.PhoneNumber;
            //user.DistributorIDs = string.IsNullOrEmpty(res.RelDistributor) ? new string[] { } : res.RelDistributor.Split(',');
            //user.Domain1 = res.Domain1.HasValue ? res.Domain1.Value : false;
            //user.Domain2 = res.Domain1.HasValue ? res.Domain2.Value : false;
            ////user.Departs = res.Where(p => p != null).Select(p => p.DepartID).Distinct().Cast<int>().ToArray();//1贝克曼 2临床诊断部 3生命科学部
            //user.Role = res.UserType.HasValue ? res.UserType.Value : 0;//res.Where(p => p != null).Select(p => p.RoleID).Distinct().Cast<int>().Min();
            //user.ActionTime = DateTime.Now;
            //return user;
        }

       
    }
}