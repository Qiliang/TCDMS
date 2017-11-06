using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TCSOFT.DMS.WebMain.Areas.MasterData.Controllers
{
    using TCSOFT.DMS.MasterData.DTO.Common;
    using Areas.MasterData.Models.Provider;
    using Filter;
    using TCSOFT.DMS.WebMain.Models.Model;
    using TCSOFT.DMS.MasterData.DTO;
    using TCSOFT.DMS.MasterData.DTO.UsersStat;
    [AuthorityFilter()]
    public class MainController : BaseController
    {
        // GET: MasterData/Home
        public ActionResult Index()
        {
            // 记录用户统计信息【使用模块，进入时间】
            UsersStatOperateDTO dto=new UsersStatOperateDTO();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
             dto.UserID=user.UserID;
             dto.UseModel="基础数据";
             dto.UseModelTime = DateTime.Now;
             SystemProvider.AddUsersStat(dto);

            return View(GetStructure());
        }

    }
}