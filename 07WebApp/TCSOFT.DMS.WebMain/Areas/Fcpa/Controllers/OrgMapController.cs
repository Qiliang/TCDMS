using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCSOFT.DMS.Fcpa.DTO.Org;
using TCSOFT.DMS.MasterData.DTO;
using TCSOFT.DMS.WebMain.Areas.Fcpa.Models.Model;
using TCSOFT.DMS.WebMain.Areas.Fcpa.Models.Provider;

namespace TCSOFT.DMS.WebMain.Areas.Fcpa.Controllers
{
    public class OrgMapController : Controller
    {
        public ActionResult Query(OrgSearchDTO dto)
        {           
            UserLoginDTO lng = Session["UserLoginInfo"] as UserLoginDTO;
            dto.UserInfo = lng.UserInfo();
            var result = OrgMapProvider.Query(dto);
            return new JsonResult(result);
        }

        public ActionResult Export(OrgSearchDTO dto)
        {
            UserLoginDTO lng = Session["UserLoginInfo"] as UserLoginDTO;
            dto.UserInfo = lng.UserInfo();
            dto.rows = int.MaxValue;
            dto.page = 1;    
            var result = OrgMapProvider.Query(dto);

            var headers = new List<ExcelHeaderModel>()
                {
                     new ExcelHeaderModel { Header="公司", PropertyName="DistributorName", Width=40 },
                     new ExcelHeaderModel { Header="状态", PropertyName="Status" , Width=10},
                     new ExcelHeaderModel { Header="组织架构图更新日期", PropertyName="OrgMapUpdateTime", Width=22 },
                     new ExcelHeaderModel { Header="培训人员名单更新日期", PropertyName="TrainsUpdateTime" , Width=22 },
                     new ExcelHeaderModel { Header="应参与培训的人员人数", PropertyName="ValidNum", Width=25  },
                     new ExcelHeaderModel { Header="实际证书效期内的人员人数", PropertyName="ShouldNum", Width=25  },
                     new ExcelHeaderModel { Header="完成率", PropertyName="Rate" , Width=10 }
                };
            var buffer = result.rows.ToExcel(headers);
            return File(buffer, "application/vnd.ms-excel", string.Format("FCPA Training Record List({0}).xlsx", DateTime.Now.ToString("yyyyMMddHHmmss")));
        }

        public ActionResult DownloadOrg(string id)
        {
            var dto = OrgMapProvider.Get(id);
            string path = Const.RealOrgMapPath(id);
            return File(path, "application/octet-stream", string.Format("{0}.doc", dto.OrgMapFile));
        }

        public ActionResult DownloadTrains(string id)
        {
            var dto = OrgMapProvider.Get(id);
            string path = Const.RealTrainsPath(id);
            return File(path, "application/octet-stream", string.Format(string.Format("{0}.xlsx", dto.DistributorName)));
        }
   

        //[Route("DownloadOrgAll"), HttpPost, HttpGet]
        //public HttpResponseMessage DownloadOrgAll()
        //{
        //    //var distributorInfo = fcpa.fcpa_DistributorInfo.Find(id);
        //    //if (distributorInfo == null) new HttpResponseMessage(HttpStatusCode.NotFound);
        //    var temp = Path.GetTempFileName();
        //    try
        //    {
        //        ZipFile zipFile = ZipFile.Create(temp);
        //        zipFile.BeginUpdate();
        //        fcpa.fcpa_DistributorInfo.Where(p => !string.IsNullOrEmpty(p.OrgMap)).ToList().ForEach(distributorInfo =>
        //        {

        //            var file = Const.RealOrgMapPath(distributorInfo.OrgMap);
        //            if (File.Exists(file))
        //                zipFile.Add(Const.RealOrgMapPath(distributorInfo.OrgMap), string.Format("{0}{1}", distributorInfo.DistributorName, Path.GetExtension(distributorInfo.OrgMapFile)));
        //        });
        //        zipFile.CommitUpdate();
        //        zipFile.Close();

        //        HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
        //        response.Content = new ByteArrayContent(File.ReadAllBytes(temp));
        //        response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
        //        response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
        //        {
        //            FileName = Path.GetFileName(string.Format("{0}.zip", "全部证书"))
        //        };
        //        return response;
        //    }
        //    finally
        //    {

        //    }

        //}


    }
}