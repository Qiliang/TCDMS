using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using TCSOFT.DMS.WebMain.Common;

namespace TCSOFT.DMS.WebMain.Areas.Document
{
    public static class Const
    {
        public static string RealRegisterPath(string key)
        {
            string dir = Path.Combine(WebConfiger.DocumentFile, "Register");
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            return Path.Combine(dir, key);
        }

        public static string RealBccePath(string key)
        {
            string dir = Path.Combine(WebConfiger.DocumentFile, "Bcce");
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            return Path.Combine(dir, key);
        }

        public static string RealLssPath(string key)
        {
            string dir = Path.Combine(WebConfiger.DocumentFile, "Lss");
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            return Path.Combine(dir, key);
        }

        public static string RealCtsPath(string key)
        {
            string dir = Path.Combine(WebConfiger.DocumentFile, "Cts");
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            return Path.Combine(dir, key);
        }
    }
}