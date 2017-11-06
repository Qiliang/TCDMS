using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace TCSOFT.DMS.WebMain.Common
{
    public class AboutWebSite
    {
        public string Version { get; set; }
        public string updatetime { get; set; }
        public string data { get; set; }
 
    }
    public class AboutWebSiteHelper
    {
        public static List<AboutWebSite> AboutWebSiteList{get;set;}  
        public static void Init(string xmlPath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlPath);
            XmlNodeList nodelist = doc.SelectNodes(@"root/verinfo");

            AboutWebSiteList = new List<AboutWebSite>();
            foreach (XmlNode node in nodelist)
            {
                AboutWebSite newitem = new AboutWebSite();
                XmlElement xe = (XmlElement)node;
                newitem.Version = xe.GetAttribute("ver");
                newitem.updatetime = xe.GetAttribute("updatetime");
                newitem.data = xe.InnerText;
                AboutWebSiteList.Add(newitem);
            }
        }
    }
}