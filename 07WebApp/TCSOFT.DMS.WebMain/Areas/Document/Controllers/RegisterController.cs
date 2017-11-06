using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCSOFT.DMS.Document.DTO;
using TCSOFT.DMS.Document.DTO.Register;
using TCSOFT.DMS.MasterData.DTO;
using TCSOFT.DMS.WebMain.Areas.Document.Models.Provider;

namespace TCSOFT.DMS.WebMain.Areas.Document.Controllers
{
    public class RegisterController : Controller
    {

        public ActionResult Query(RegisterSearchDTO dto)
        {
            UserLoginDTO lng = Session["UserLoginInfo"] as UserLoginDTO;
            dto.UserInfo = lng.UserInfo();
            var result = RegisterProvider.Query(dto);
            return new JsonResult(result);
        }


        public ActionResult Add(RegisterAddDTO dto)
        {
            UserLoginDTO lng = Session["UserLoginInfo"] as UserLoginDTO;
            dto.UserInfo = lng.UserInfo();
            var result = RegisterProvider.Add(dto);
            return new JsonResult(result);
        }

        public ActionResult Update(RegisterUpdateDTO dto)
        {
            UserLoginDTO lng = Session["UserLoginInfo"] as UserLoginDTO;
            dto.UserInfo = lng.UserInfo();
            var result = RegisterProvider.Update(dto);
            return new JsonResult(result);
        }

        public ActionResult Delete(Guid id)
        {
            var result = RegisterProvider.Delete(id);
            return new JsonResult(result);
        }

        public ActionResult ProductType()
        {
            UserLoginDTO lng = Session["UserLoginInfo"] as UserLoginDTO;
            DocumentDTO dto = new DocumentDTO { UserInfo = lng.UserInfo() };
            var result = RegisterProvider.ProductType(dto);
            result.Add(new ProductTypeResultDTO { ProductTypeID = 0, ProductTypeName = "全部" });
            return new JsonResult(result);
        }

        public ActionResult ProductLine()
        {
            UserLoginDTO lng = Session["UserLoginInfo"] as UserLoginDTO;
            DocumentDTO dto = new DocumentDTO { UserInfo = lng.UserInfo() };
            var result = RegisterProvider.ProductLine(dto);

            return new JsonResult(new List<RootNode> { result });
        }
    }
}