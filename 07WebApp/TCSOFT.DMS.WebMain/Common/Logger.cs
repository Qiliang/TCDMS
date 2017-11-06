using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace TCSOFT.DMS.WebMain.Common
{
    public class Logger
    {
        private static string _LogPath = @"D:\dmslog.txt";
        public static void Init(string strLogPath)
        {
            _LogPath = strLogPath;
        }
        public static void WriteLog(string strLogContent)
        {
            using (StreamWriter sw = new StreamWriter(_LogPath, true))
            {
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss  ")+strLogContent);
                sw.Flush();
            }
        }
    }
}