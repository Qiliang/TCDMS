using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCSOFT.DMS.Document.DTO;
using TCSOFT.DMS.Document.DTO.Register;
using TCSOFT.DMS.Document.IServices;
using TCSOFT.DMS.Document.Services;
using TCSOFT.DMS.MasterData.DTO;
using TCSOFT.DMS.WebMain.Areas.MasterData.Models.Provider;

namespace TCSOFT.DMS.WebMain.Areas.Document.Controllers
{
    public class RegisterController : Controller
    {

        IRegisterService _RegisterService = new RegisterService();
        IUserService _UserService = new UserService();

        public ActionResult Query(RegisterSearchDTO dto)
        {
            UserLoginDTO lng = Session["UserLoginInfo"] as UserLoginDTO;
            dto.UserInfo = lng.UserInfo();
            var result = _RegisterService.Query(dto);
            return new JsonResult(result);
        }


        public ActionResult Add(RegisterAddDTO dto)
        {
            UserLoginDTO lng = Session["UserLoginInfo"] as UserLoginDTO;
            dto.UserInfo = lng.UserInfo();
            dto.AttachmentIDs = new List<RegisterAttachmentDTO>();
            HttpContext.Request.Files.AllKeys.Select(key => HttpContext.Request.Files[key]).Where(p => !string.IsNullOrEmpty(p.FileName)).ToList().ForEach(p =>
            {
                var att = new RegisterAttachmentDTO
                {
                    AttachmentID = Guid.NewGuid(),
                    AttachmentName = p.FileName,
                    AttachmentSize = p.ContentLength,
                };
                p.SaveAs(Const.RealBccePath(att.AttachmentID.ToString()));
                dto.AttachmentIDs.Add(att);

            });
            var pt = ProductManagementProvider.GetProductType(dto.ProductTypeID.Value);
            var pr = ProductManagementProvider.GetOneProductLine(dto.ProductLineID.Value);
            dto.ProductLineName = pr.Object.ProductLineName;
            dto.ProductTypeName = pt.Object.ProductTypeName;
            var result = _RegisterService.Add(dto);
            return new JsonResult(result);
        }

        public ActionResult Update(RegisterUpdateDTO dto)
        {
            UserLoginDTO lng = Session["UserLoginInfo"] as UserLoginDTO;
            dto.UserInfo = lng.UserInfo();
            dto.AttachmentIDs = new List<RegisterAttachmentDTO>();
            HttpContext.Request.Files.AllKeys.Select(key => HttpContext.Request.Files[key]).Where(p => !string.IsNullOrEmpty(p.FileName)).ToList().ForEach(p =>
            {
                var att = new RegisterAttachmentDTO
                {
                    AttachmentID = Guid.NewGuid(),
                    AttachmentName = p.FileName,
                    AttachmentSize = p.ContentLength,
                };
                p.SaveAs(Const.RealRegisterPath(att.AttachmentID.ToString()));
                dto.AttachmentIDs.Add(att);

            });

            var pt = ProductManagementProvider.GetProductType(dto.ProductTypeID.Value);
            var pr = ProductManagementProvider.GetOneProductLine(dto.ProductLineID.Value);
            dto.ProductLineName = pr.Object.ProductLineName;
            dto.ProductTypeName = pt.Object.ProductTypeName;
            var result = _RegisterService.Update(dto);
            return new JsonResult(result);
        }

        public ActionResult Download(Guid registerID, Guid[] attIDs)
        {
            UserLoginDTO lng = Session["UserLoginInfo"] as UserLoginDTO;
        
            var register = _RegisterService.Get(registerID);
            if (register == null) return HttpNotFound();
            if (attIDs.Length > 1)
            {
                var temp = Path.GetTempFileName();
                ZipFile zipFile = ZipFile.Create(temp);
                zipFile.BeginUpdate();
                register.Attachments.Where(p => attIDs.Contains(p.AttachmentID)).ToList().ForEach(att =>
                {
                    var file = Const.RealRegisterPath(att.AttachmentID.ToString());
                    if (System.IO.File.Exists(file))
                        zipFile.Add(file, att.AttachmentName);
                });
                zipFile.CommitUpdate();
                zipFile.Close();
                _RegisterService.Download(lng.UserInfo(), attIDs);
                return File(temp, "application/octet-stream", register.Title+".zip");
            }
            else
            {
                var att = register.Attachments.Where(p => attIDs.Contains(p.AttachmentID)).FirstOrDefault();
                if(att==null) return HttpNotFound();
                var file = Const.RealRegisterPath(att.AttachmentID.ToString());
                _RegisterService.Download(lng.UserInfo(), attIDs);
                return File(file, "application/octet-stream", att.AttachmentName);
            }

        }

        public ActionResult Delete(Guid id)
        {
            var result = _RegisterService.Delete(id);
            return new JsonResult(result);
        }

        public ActionResult ProductType()
        {
            UserLoginDTO lng = Session["UserLoginInfo"] as UserLoginDTO;
            DocumentDTO dto = new DocumentDTO { UserInfo = lng.UserInfo() };
            var result = _RegisterService.ProductType();
            result.Add(new ProductTypeResultDTO { ProductTypeID = 0, ProductTypeName = "全部" });
            return new JsonResult(result);
        }

        public ActionResult ProductLine()
        {
            UserLoginDTO lng = Session["UserLoginInfo"] as UserLoginDTO;
            DocumentDTO dto = new DocumentDTO { UserInfo = lng.UserInfo() };
            var result = _RegisterService.ProductLine(dto);

            return new JsonResult(new List<RootNode> { result });
        }
    }
}