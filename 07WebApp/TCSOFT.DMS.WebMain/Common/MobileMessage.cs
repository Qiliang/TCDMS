using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Xml;

namespace TCSOFT.DMS.WebMain.Common
{
    public class MobileMessage
    {
        private static string _SendUrl = "http://sh2.cshxsp.com/sms.aspx";
        private static string _SendAccount = "jkwl013";
        private static string _SendPassword = "a153246";
        private static string _SendAction = "send";
        public static string SendMessage(List<string> strPhoneNumberList, string strMessageInfo, DateTime? dtTiming = null)
        {
            string strResult = null;
            try
            {
                string strTiming = dtTiming == null ? String.Empty : dtTiming.Value.ToString("yyyy-MM-dd HH:mm:ss");
                HttpWebRequest httpwebrq = (HttpWebRequest)WebRequest.Create(_SendUrl);
                httpwebrq.Method = "post";
                httpwebrq.Accept = "text/html, application/xhtml+xml, */*";
                httpwebrq.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
                httpwebrq.ServicePoint.Expect100Continue = false;
                string strPostdata = "action={0}&userid=&account={1}&password={2}&mobile={3}&content={4}&sendTime={5}&extno=";
                strPostdata = String.Format(strPostdata, _SendAction, _SendAccount, _SendPassword, String.Join(",", strPhoneNumberList.ToArray()), strMessageInfo, strTiming);
                byte[] buffer = Encoding.GetEncoding("utf-8").GetBytes(strPostdata);
                httpwebrq.ContentLength = buffer.Length;
                using (Stream dataStream = httpwebrq.GetRequestStream())
                {
                    dataStream.Write(buffer, 0, buffer.Length);
                    dataStream.Flush();
                }

                HttpWebResponse response = (HttpWebResponse)httpwebrq.GetResponse();
                XmlDocument xdm = new XmlDocument();
                xdm.Load(response.GetResponseStream());
                if (xdm.SelectSingleNode(@"returnsms/returnstatus").InnerText != "Success")
                {
                    strResult = xdm.SelectSingleNode(@"returnsms/message").InnerText;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("SendMessage Error:" + ex.Message);
            }

            return strResult;
        }
    }
}