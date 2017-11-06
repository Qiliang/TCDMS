using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TCSOFT.DMS.Document.IServices;
using TCSOFT.DMS.Document.Services;

namespace TCSOFT.DMS.DocumentAPI.Controllers
{
    public class LssController : ApiController
    {
        ILssService _LssService = new LssService();
    }
}
