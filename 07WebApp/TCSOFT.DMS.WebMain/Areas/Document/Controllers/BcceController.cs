using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCSOFT.DMS.Document.DTO;
using TCSOFT.DMS.Document.DTO.Bcce;
using TCSOFT.DMS.Document.IServices;
using TCSOFT.DMS.Document.Services;
using TCSOFT.DMS.MasterData.DTO;

namespace TCSOFT.DMS.WebMain.Areas.Document.Controllers
{
    public class BcceController : Controller
    {
        IBcceService _BcceService = new BcceService();
        IUserService _UserService = new UserService();

        public ActionResult Query(BcceSearchDTO dto)
        {
            UserLoginDTO lng = Session["UserLoginInfo"] as UserLoginDTO;
            dto.UserInfo = lng.UserInfo();
            var result = _BcceService.Query(dto);
            return new JsonResult(result);
        }


        public ActionResult Add(BcceAddDTO dto)
        {
            UserLoginDTO lng = Session["UserLoginInfo"] as UserLoginDTO;
            dto.UserInfo = lng.UserInfo();
            dto.AttachmentIDs = new List<BcceAttachmentDTO>();
            HttpContext.Request.Files.AllKeys.Select(key => HttpContext.Request.Files[key]).Where(p => !string.IsNullOrEmpty(p.FileName)).ToList().ForEach(p =>
            {
                var att = new BcceAttachmentDTO
                {
                    AttachmentID = Guid.NewGuid(),
                    AttachmentName = p.FileName,
                    AttachmentSize = p.ContentLength,
                };
                p.SaveAs(Const.RealBccePath(att.AttachmentID.ToString()));
                dto.AttachmentIDs.Add(att);

            });
            //var pt = ProductManagementProvider.GetProductType(dto.ProductTypeID.Value);
            //var pr = ProductManagementProvider.GetOneProductLine(dto.ProductLineID.Value);
            //dto.ProductLineName = pr.Object.ProductLineName;
            //dto.ProductTypeName = pt.Object.ProductTypeName;

            var result = _BcceService.Add(dto);
            return new JsonResult(result);
        }

        public ActionResult Update(BcceUpdateDTO dto)
        {
            UserLoginDTO lng = Session["UserLoginInfo"] as UserLoginDTO;
            dto.UserInfo = lng.UserInfo();
            dto.AttachmentIDs = new List<BcceAttachmentDTO>();
            HttpContext.Request.Files.AllKeys.Select(key => HttpContext.Request.Files[key]).Where(p => !string.IsNullOrEmpty(p.FileName)).ToList().ForEach(p =>
            {
                var att = new BcceAttachmentDTO
                {
                    AttachmentID = Guid.NewGuid(),
                    AttachmentName = p.FileName,
                    AttachmentSize = p.ContentLength,
                };
                p.SaveAs(Const.RealBccePath(att.AttachmentID.ToString()));
                dto.AttachmentIDs.Add(att);

            });

            //var pt = ProductManagementProvider.GetProductType(dto.ProductTypeID.Value);
            //var pr = ProductManagementProvider.GetOneProductLine(dto.ProductLineID.Value);
            //dto.ProductLineName = pr.Object.ProductLineName;
            //dto.ProductTypeName = pt.Object.ProductTypeName;
            var result = _BcceService.Update(dto);
            return new JsonResult(result);
        }

        public ActionResult Download(Guid bcceID, Guid[] attIDs)
        {
            UserLoginDTO lng = Session["UserLoginInfo"] as UserLoginDTO;
            var bcce = _BcceService.Get(bcceID);
            if (bcce == null) return HttpNotFound();
            if (attIDs.Length > 1)
            {
                var temp = Path.GetTempFileName();
                ZipFile zipFile = ZipFile.Create(temp);
                zipFile.BeginUpdate();
                bcce.Attachments.Where(p => attIDs.Contains(p.AttachmentID)).ToList().ForEach(att =>
                {
                    var file = Const.RealBccePath(att.AttachmentID.ToString());
                    if (System.IO.File.Exists(file))
                        zipFile.Add(file, att.AttachmentName);
                });
                zipFile.CommitUpdate();
                zipFile.Close();
                _BcceService.Download(lng.UserInfo(), attIDs);
                return File(temp, "application/octet-stream", bcce.Title + ".zip");
            }
            else
            {
                var att = bcce.Attachments.Where(p => attIDs.Contains(p.AttachmentID)).FirstOrDefault();
                if (att == null) return HttpNotFound();
                var file = Const.RealBccePath(att.AttachmentID.ToString());
                _BcceService.Download(lng.UserInfo(), attIDs);
                return File(file, "application/octet-stream", att.AttachmentName);
            }

        }

        public ActionResult Delete(Guid id)
        {
            var result = _BcceService.Delete(id);
            return new JsonResult(result);
        }


    }
}