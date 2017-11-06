using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCSOFT.DMS.Fcpa.DTO.Alerm;
using TCSOFT.DMS.MasterData.DTO;
using TCSOFT.DMS.WebMain.Areas.Fcpa.Models.Model;
using TCSOFT.DMS.WebMain.Areas.Fcpa.Models.Provider;

namespace TCSOFT.DMS.WebMain.Areas.Fcpa.Controllers
{
    public class AlermController : Controller
    {
        public ActionResult Query(AlermSearchDTO dto)
        {
            UserLoginDTO lng = Session["UserLoginInfo"] as UserLoginDTO;
            dto.UserInfo = lng.UserInfo();
            var result = AlermdProvider.Query(dto);
            return new JsonResult(result);
        }

        public ActionResult Export(AlermSearchDTO dto)
        {
            UserLoginDTO lng = Session["UserLoginInfo"] as UserLoginDTO;
            dto.UserInfo = lng.UserInfo();
            dto.rows = int.MaxValue;
            dto.page = 1;
            var result = AlermdProvider.Query(dto);

            var headers = new List<ExcelHeaderModel>()
                {
                    new ExcelHeaderModel { Header="用户代号", PropertyName="UserCode", Width=15 },
                    new ExcelHeaderModel { Header="用户名称", PropertyName="FullName", Width=15 },
                    new ExcelHeaderModel { Header="手机号", PropertyName="PhoneNumber", Width=15 },
                    new ExcelHeaderModel { Header="邮箱", PropertyName="Email", Width=15 },
                    new ExcelHeaderModel { Header="所属领域", PropertyName="DomainDesc" , Width=10},
                    new ExcelHeaderModel { Header="角色", PropertyName="RoleDesc", Width=22 },
                    new ExcelHeaderModel { Header="关联经销商", PropertyName="RelDistributorDesc" , Width=40 },
                    new ExcelHeaderModel { Header="提醒日期", PropertyName="DomainDesc", Width=22  },
                    new ExcelHeaderModel { Header="更新日期", PropertyName="AlarmTime", Width=22  }
                };
            var buffer = result.rows.ToExcel(headers);
            return File(buffer, "application/vnd.ms-excel", string.Format("FCPA Warning List({ 0}).xlsx", DateTime.Now.ToString("yyyyMMddHHmmss")));
        }
    }
}