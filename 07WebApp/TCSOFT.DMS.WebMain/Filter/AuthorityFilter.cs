using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TCSOFT.DMS.WebMain.Filter
{
    using MasterData.DTO;
    public class AuthorityFilter : ActionFilterAttribute
    {
        public string AuthorityID
        {
            get;
            set;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
            {
                base.OnActionExecuting(filterContext);
                return;
            }

            // 判断session是否丢失
            if (filterContext.HttpContext.Session == null || filterContext.HttpContext.Session["UserLoginInfo"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Home",
                    action = "Index",
                    area = ""
                }));
                return;
            }

            // 判断是否拥有权限
            UserLoginDTO lng = (UserLoginDTO)filterContext.HttpContext.Session["UserLoginInfo"];
            var pp = lng.CurrentAuthorityList.Where(p => p.StructureID == AuthorityID).FirstOrDefault();
            if (AuthorityID == null || (pp != null && ((pp.BelongButton&1)==1)))
            {
                base.OnActionExecuting(filterContext);
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Common",
                    action = "NoAuthorityInfo",
                    area = ""
                }));
            }
        }
    }
}