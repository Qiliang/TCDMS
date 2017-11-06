using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCSOFT.DMS.Fcpa.Entities;

namespace TCSOFT.DMS.Fcpa.Services
{
    public static class Const
    {


        public static string Status(int? status)
        {
            if (status == 0) return "已完成";
            if (status == 1) return "新更新";
            if (status == 2) return "快过期";
            if (status == 3) return "未完成";
            if (status == 4) return "已过期";
            if (status == 5) return "不更新";
            return string.Empty;
        }

        public static string Domain(bool? domain1, bool? domain2)
        {
            return string.Join(",", new string[] {
                domain1.HasValue && domain1.Value?" 临床诊断":string.Empty,
                domain2.HasValue && domain2.Value?"生命科学":string.Empty
            }.Where(p => !string.IsNullOrEmpty(p)));
        }

        public static string Offwork(bool? offWork, DateTime? offWorkDate)
        {
            if (offWork == true)
            {
                if (offWorkDate.HasValue)
                    return "离职,离职日期" + offWorkDate.Value.ToString("yyyy/MM/dd");
                else
                    return "离职";
            }
            else
            {
                return "在职";
            }
        }

        public static string Role(int? role)
        {
            //系统管理员0   贝克曼1   经销商2
            if (role == 0) return "系统管理员";
            if (role == 1) return "贝克曼";
            if (role == 2) return "经销商";
            return string.Empty;

        }

        public static string RelDistributor(string id, TCDMS_FCPAEntities fcpa)
        {
            if (string.IsNullOrEmpty(id)) return string.Empty;
            string[] ids = id.Split(',');
            return string.Join(",", fcpa.fcpa_DistributorInfo.Where(p => ids.Contains(p.DistributorID)).Select(p => p.DistributorName));
        }


        //public static string RealCredentialPath(string key)
        //{
        //    return HttpContext.Current.Server.MapPath("~/App_Data/Credentials/" + key);
        //}

        //public static string RealOrgMapPath(string key)
        //{
        //    return HttpContext.Current.Server.MapPath("~/App_Data/OrgMaps/" + key);
        //}

        //public static string RealTrainsPath(string key)
        //{
        //    return HttpContext.Current.Server.MapPath("~/App_Data/Trains/" + key);
        //}
    }
}