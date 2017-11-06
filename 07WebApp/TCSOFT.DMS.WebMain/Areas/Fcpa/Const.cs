using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using TCSOFT.DMS.WebMain.Common;

namespace TCSOFT.DMS.WebMain.Areas.Fcpa
{
    public static class Const
    {

        public static string RealCredentialPath(string key)
        {
            string dir = Path.Combine(WebConfiger.FcpaFile, "Credentials");
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            return Path.Combine(dir, key);
        }

        public static string RealOrgMapPath(string key)
        {
            string dir = Path.Combine(WebConfiger.FcpaFile, "OrgMaps");
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            return Path.Combine(dir, key);
        }

        public static string RealTrainsPath(string key)
        {
            string dir = Path.Combine(WebConfiger.FcpaFile, "Trains");
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            return Path.Combine(dir, key);
        }
    }
}