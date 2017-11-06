using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCSOFT.DMS.Fcpa.DTO;
using TCSOFT.DMS.Fcpa.DTO.Credential;
using TCSOFT.DMS.Fcpa.DTO.Fcpa;
using TCSOFT.DMS.MasterData.DTO;
using TCSOFT.DMS.WebMain.Areas.Fcpa.Models.Model;
using TCSOFT.DMS.WebMain.Areas.Fcpa.Models.Provider;

namespace TCSOFT.DMS.WebMain.Areas.Fcpa.Controllers
{
    public class DetailsController : Controller
    {
        public ActionResult Query(FcpaSearchDTO dto)
        {
            UserLoginDTO lng = Session["UserLoginInfo"] as UserLoginDTO;
            dto.UserInfo = lng.UserInfo();
            var result = FcpaProvider.Query(dto);
            return new JsonResult(result);
        }


        public ActionResult Export(FcpaSearchDTO dto)
        {
            dto.rows = int.MaxValue;
            dto.page = 1;
            UserLoginDTO lng = Session["UserLoginInfo"] as UserLoginDTO;
            dto.UserInfo = lng.UserInfo();
            var result = FcpaProvider.Query(dto);

            var headers = new List<ExcelHeaderModel>()
                {
                    new ExcelHeaderModel { Header="经销商", PropertyName="DistributorName", Width=40 },
                    new ExcelHeaderModel { Header="姓名", PropertyName="Name", Width=15 },
                    new ExcelHeaderModel { Header="部门", PropertyName="Department", Width=15 },
                    new ExcelHeaderModel { Header="职位", PropertyName="Title", Width=15 },
                    new ExcelHeaderModel { Header="培训状态", PropertyName="StatusDesc" , Width=10},
                    new ExcelHeaderModel { Header="培训完成日期", PropertyName="CompletedDate", Width=22 },
                    new ExcelHeaderModel { Header="在职状态", PropertyName="OffWorkDesc" , Width=22 },
                    new ExcelHeaderModel { Header="所属领域", PropertyName="DomainDesc", Width=22  },
                    new ExcelHeaderModel { Header="更新日期", PropertyName="UpdateDate", Width=22  },
                    new ExcelHeaderModel { Header="过期日期", PropertyName="ExpireDate" , Width=10 },
                    new ExcelHeaderModel { Header="备注", PropertyName="Remark" , Width=10 }
                };
            var buffer = result.rows.ToExcel(headers);
            return File(buffer, "application/vnd.ms-excel", string.Format("FCPA Training Record List({0}).xlsx", DateTime.Now.ToString("yyyyMMddHHmmss")));
        }
    }
}