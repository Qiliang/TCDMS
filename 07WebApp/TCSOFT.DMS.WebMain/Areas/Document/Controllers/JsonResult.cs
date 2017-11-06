using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TCSOFT.DMS.WebMain.Areas.Document.Controllers
{
    public class JsonResult : ActionResult
    {
        public object Data { get; private set; }
        public JsonResult(object data)
        {
            this.Data = data;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            HttpResponseBase response = context.HttpContext.Response;
            response.ContentType = "application/json";
            if (Data != null)
                response.Write(JsonConvert.SerializeObject(Data));
          
        }
    }
}