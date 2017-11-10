using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCSOFT.DMS.Document.DTO;
using TCSOFT.DMS.Document.DTO.Lss;
using TCSOFT.DMS.Document.IServices;
using TCSOFT.DMS.Document.Services;
using TCSOFT.DMS.MasterData.DTO;
using TCSOFT.DMS.WebMain.Areas.MasterData.Models.Provider;

namespace TCSOFT.DMS.WebMain.Areas.Document.Controllers
{
    public class LssController : Controller
    {

        ILssService _LssService = new LssService();
        IUserService _UserService = new UserService();

        public ActionResult Query(LssSearchDTO dto)
        {
            UserLoginDTO lng = Session["UserLoginInfo"] as UserLoginDTO;
            dto.UserInfo = lng.UserInfo();
            var result = _LssService.Query(dto);
            return new JsonResult(result);
        }

        public ActionResult Favorite(Guid id)
        {
            UserLoginDTO lng = Session["UserLoginInfo"] as UserLoginDTO;
            var result = _LssService.Favorite(lng.UserInfo(), id);
            return new JsonResult(result);
        }

        public ActionResult UnFavorite(Guid id)
        {
            UserLoginDTO lng = Session["UserLoginInfo"] as UserLoginDTO;
            var result = _LssService.UnFavorite(lng.UserInfo(), id);
            return new JsonResult(result);
        }
        public ActionResult Upload()
        {
            return Json(new { Ok=true });
        }

        public ActionResult Add(LssAddDTO dto)
        {
            UserLoginDTO lng = Session["UserLoginInfo"] as UserLoginDTO;
            dto.UserInfo = lng.UserInfo();
            if (!dto.EffectDate.HasValue) dto.EffectDate = DateTime.Now;
            dto.AttachmentIDs = new List<LssAttachmentDTO>();
            HttpContext.Request.Files.AllKeys.Select(key => HttpContext.Request.Files[key]).Where(p => !string.IsNullOrEmpty(p.FileName)).ToList().ForEach(p =>
            {
                var att = new LssAttachmentDTO
                {
                    AttachmentID = Guid.NewGuid(),
                    AttachmentName = p.FileName,
                    AttachmentSize = p.ContentLength,
                };
                p.SaveAs(Const.RealBccePath(att.AttachmentID.ToString()));
                dto.AttachmentIDs.Add(att);

            });

            var result = _LssService.Add(dto);
            return new JsonResult(result);
        }

        public ActionResult Update(LssUpdateDTO dto)
        {
            UserLoginDTO lng = Session["UserLoginInfo"] as UserLoginDTO;
            dto.UserInfo = lng.UserInfo();
            if (!dto.EffectDate.HasValue) dto.EffectDate = DateTime.Now;
            dto.AttachmentIDs = new List<LssAttachmentDTO>();
            HttpContext.Request.Files.AllKeys.Select(key => HttpContext.Request.Files[key]).Where(p => !string.IsNullOrEmpty(p.FileName)).ToList().ForEach(p =>
            {
                var att = new LssAttachmentDTO
                {
                    AttachmentID = Guid.NewGuid(),
                    AttachmentName = p.FileName,
                    AttachmentSize = p.ContentLength,
                };
                p.SaveAs(Const.RealLssPath(att.AttachmentID.ToString()));
                dto.AttachmentIDs.Add(att);

            });

            var result = _LssService.Update(dto);
            return new JsonResult(result);
        }

        public ActionResult Download(Guid lssID, Guid[] attIDs)
        {
            UserLoginDTO lng = Session["UserLoginInfo"] as UserLoginDTO;

            var lss = _LssService.Get(lssID);
            if (lss == null) return HttpNotFound();
            if (attIDs.Length > 1)
            {
                var temp = Path.GetTempFileName();
                ZipFile zipFile = ZipFile.Create(temp);
                zipFile.BeginUpdate();
                lss.Attachments.Where(p => attIDs.Contains(p.AttachmentID)).ToList().ForEach(att =>
                {
                    var file = Const.RealLssPath(att.AttachmentID.ToString());
                    if (System.IO.File.Exists(file))
                        zipFile.Add(file, att.AttachmentName);
                });
                zipFile.CommitUpdate();
                zipFile.Close();
                _LssService.Download(lng.UserInfo(), attIDs);
                return File(temp, "application/octet-stream", lss.Title + ".zip");
            }
            else
            {
                var att = lss.Attachments.Where(p => attIDs.Contains(p.AttachmentID)).FirstOrDefault();
                if (att == null) return HttpNotFound();
                var file = Const.RealLssPath(att.AttachmentID.ToString());
                _LssService.Download(lng.UserInfo(), attIDs);
                return File(file, "application/octet-stream", att.AttachmentName);
            }

        }

        public ActionResult Delete(Guid id)
        {
            var result = _LssService.Delete(id);
            return new JsonResult(result);
        }

        public ActionResult ProductLine()
        {
            UserLoginDTO lng = Session["UserLoginInfo"] as UserLoginDTO;
            DocumentDTO dto = new DocumentDTO { UserInfo = lng.UserInfo() };
            var result = _LssService.ProductLine(dto);

            return new JsonResult(new List<RootNode> { result });
        }

        public ActionResult AddChildTag(int? tagID, int? productLineID, string tagName)
        {
            UserLoginDTO lng = Session["UserLoginInfo"] as UserLoginDTO;
            DocumentDTO dto = new DocumentDTO { UserInfo = lng.UserInfo() };
            var result = _LssService.AddChildTag(tagID, productLineID, tagName);
            return new JsonResult(result);
        }

        public ActionResult AddSiblingTag(int? tagID, int? productLineID, string tagName)
        {
            UserLoginDTO lng = Session["UserLoginInfo"] as UserLoginDTO;
            DocumentDTO dto = new DocumentDTO { UserInfo = lng.UserInfo() };
            var result = _LssService.AddSiblingTag(tagID, productLineID, tagName);
            return new JsonResult(result);
        }

        public ActionResult RenameTag(int tagID, string tagName)
        {
            UserLoginDTO lng = Session["UserLoginInfo"] as UserLoginDTO;
            DocumentDTO dto = new DocumentDTO { UserInfo = lng.UserInfo() };
            var result = _LssService.RenameTag(tagID, tagName);
            return new JsonResult(result);
        }

        public ActionResult DeleteTag(int tagID)
        {
            UserLoginDTO lng = Session["UserLoginInfo"] as UserLoginDTO;
            DocumentDTO dto = new DocumentDTO { UserInfo = lng.UserInfo() };
            var result = _LssService.DeleteTag(tagID);
            return new JsonResult(result);
        }
    }
}
