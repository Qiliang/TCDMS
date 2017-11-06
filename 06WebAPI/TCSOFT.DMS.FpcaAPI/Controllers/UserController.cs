using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TCSOFT.DMS.Fcpa.IServices;
using TCSOFT.DMS.Fcpa.Services;

namespace TCSOFT.DMS.FpcaAPI.Controllers
{
    [RoutePrefix("api/Users")]
    public class UserController : ApiController
    {
        IUserService _UserService = new UserService();

        //[Route("Login"), HttpPost]
        //public dynamic Login(string userCode)
        //{         
        //    var token = Guid.NewGuid().ToString("N");
        //    var user = _UserService.GetUserInfo(userCode);
        //    if (user == null) return NotFound();
        //    TokeFilter.UserTokens.Add(token, user);
        //    return new { token = token, role = user.Role, name = user.FullName, phone = user.Phone };
        //}


       
    }
}
