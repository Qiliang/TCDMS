using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TCSOFT.DMS.WebMain.Areas.MasterData.Controllers
{
    using DMS.MasterData.DTO;
    using Common;
    using TCSOFT.DMS.WebMain.Filter;
    [AuthorityFilter]
    /// <summary>
    /// 控制器基类
    /// </summary>
    public class BaseController : Controller
    {
        /// <summary>
        /// 获取对应模块功能权限
        /// </summary>
        /// <param name="strStructureID"></param>
        /// <returns></returns>
        protected List<ButtonDTO> GetAuthority(string strStructureID)
        {
            List<ButtonDTO> Result = new List<ButtonDTO>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            var pp = user.CurrentAuthorityList.Where(p => p.StructureID == strStructureID).FirstOrDefault();
            if (pp != null)
            {
                int UserBelongButton = pp.BelongButton;

                GlobalStaticData.ButtonInfo.ForEach(g =>
                {
                    if (g.IsVisible && (g.ButtonID & UserBelongButton) == g.ButtonID)
                    {
                        Result.Add(g);
                    }
                });

                Result.OrderBy(t => t.IndexCode);
            }

            return Result;
        }

        /// <summary>
        /// 获取对应模块权限
        /// </summary>
        /// <returns></returns>
        protected List<StructureDTO> GetStructure()
        {
            List<StructureDTO> Result = new List<StructureDTO>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            var pp = user.CurrentAuthorityList.Where(m=>(m.BelongButton&1)==1).Select(g=>g.StructureID).ToList();

            Result = GlobalStaticData.StructureInfo.Where(p => p.StructureID.StartsWith("095") && p.StructureID!="095" && p.IsVisible && pp.Contains(p.StructureID)
                && pp.Where(g => g == p.ParentStructureID).FirstOrDefault() != null).ToList();
            Result.OrderBy(g => new { g.StructureID, g.IndexCode });

            return Result;
        }
    }
}