using FluentScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCSOFT.DMS.Fcpa.Entities;

namespace TCSOFT.DMS.Fcpa.Services.Jobs
{
    /// <summary>
    /// 
    //0 已完成：未过期的证书（不含新更新、快过期）；--job更新
    //1 已更新：在一个月内刚更新的证书（0天≤“系统日期－培训完成日期”≤28天）；--
    //2 快过期：一个月内要过期的证书（0天≤“（过期日期－系统日期”≤28天）；
    //3 未完成：没有上传证书或没有填写培训完成日期的证书；
    //4 已过期：过期日期＜系统日期，过期后的证书标记成红色；
    //5 不更新：标记为离职的人员，无需再更新证书，离职员工标记成灰色；--手动更新
    /// 
    /// </summary>     
    public class StatusJob : IJob
    {
        public void Execute()
        {       
          
            using (var fcpa = new TCDMS_FCPAEntities())
            {
                fcpa.fcpa_CredentialInfo.ToList().ForEach(item =>
                {
                    StatusChange(item);
                });

                fcpa.SaveChanges();

            }
        }

        public static void StatusChange(fcpa_CredentialInfo item)
        {
            DateTime now = DateTime.Now.Date;
            if (!item.OffWork.HasValue) item.OffWork = false;
            if (item.OffWork == true)
            {
                item.Status = 5;
            }
            else if (item.OffWork == false)
            {
                //有证书的情况
                if (!string.IsNullOrEmpty(item.Certificate) && item.CompletedDate.HasValue && item.ExpireDate.HasValue)
                {
                    if (item.ExpireDate < now) item.Status = 4;
                    else if (item.ExpireDate.Value.AddDays(-28) <= now) item.Status = 2;
                    else if (item.CompletedDate.Value.AddDays(28) >= now) item.Status = 1;
                    else item.Status = 0;
                }
                else
                {
                    item.Status = 3;
                }
            }
        }
    }
}