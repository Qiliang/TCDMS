using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace TCSOFT.DMS.WebMain.Common
{
    public class WebConfiger
    {
        public static string MasterDataServicesUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["MasterDataServices"];
            }
        }
        public static string UserServicesUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["UserServices"];
            }
        }
        public static string FcpaServicesUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["FcpaServices"];
            }
        }
        public static string FcpaFile
        {
            get
            {
                return ConfigurationManager.AppSettings["FcpaFile"];
            }
        }

        public static string DocumentServicesUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["DocumentServices"];
            }
        }
        public static string DocumentFile
        {
            get
            {
                return ConfigurationManager.AppSettings["DocumentFile"];
            }
        }

        public static string ShortMessage
        {
            get
            {
                return ConfigurationManager.AppSettings["ShortMessage"];
            }
        }

        public static string NoUserMessage
        {
            get
            {
                return ConfigurationManager.AppSettings["NoUserMessage"];
            }
        }

        public static string NoAuthMessage
        {
            get
            {
                return ConfigurationManager.AppSettings["NoAuthMessage"];
            }
        }

        public static string UserApplyEmailMessage
        {
            get
            {
                return ConfigurationManager.AppSettings["UserApplyEmailMessage"];
            }
        }

        public static string UserApplyShortMessage
        {
            get
            {
                return ConfigurationManager.AppSettings["UserApplyShortMessage"];
            }
        }

        public static string UserAuditPassEmailMessage
        {
            get
            {
                return ConfigurationManager.AppSettings["UserAuditPassEmailMessage"];
            }
        }

        public static string UserAuditPassShortMessage
        {
            get
            {
                return ConfigurationManager.AppSettings["UserAuditPassShortMessage"];
            }
        }

        public static string UserAuditRefuseEmailMessage
        {
            get
            {
                return ConfigurationManager.AppSettings["UserAuditRefuseEmailMessage"];
            }
        }

        public static string UserAuditRefuseShortMessage
        {
            get
            {
                return ConfigurationManager.AppSettings["UserAuditRefuseShortMessage"];
            }
        }
        public static string ProblemFeedbackMessage
        {
            get
            {
                return ConfigurationManager.AppSettings["ProblemFeedbackMessage"];
            }
        }

        public static string EmailServer
        {
            get
            {
                return ConfigurationManager.AppSettings["EmailServer"];
            }
        }

        public static string EmailPort
        {
            get
            {
                return ConfigurationManager.AppSettings["EmailPort"];
            }
        }

        public static string EmailAccount
        {
            get
            {
                return ConfigurationManager.AppSettings["EmailAccount"];
            }
        }

        public static string EmailAmtPassword
        {
            get
            {
                return ConfigurationManager.AppSettings["EmailAmtPassword"];
            }
        }
    }
}