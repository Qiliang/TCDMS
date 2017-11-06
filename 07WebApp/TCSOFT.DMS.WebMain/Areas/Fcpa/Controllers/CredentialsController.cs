using NPOI.HSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCSOFT.DMS.Fcpa.DTO;
using TCSOFT.DMS.Fcpa.DTO.Credential;
using TCSOFT.DMS.Fcpa.DTO.Fcpa;
using TCSOFT.DMS.Fcpa.DTO.Org;
using TCSOFT.DMS.MasterData.DTO;
using TCSOFT.DMS.WebMain.Areas.Fcpa.Models.Model;
using TCSOFT.DMS.WebMain.Areas.Fcpa.Models.Provider;

namespace TCSOFT.DMS.WebMain.Areas.Fcpa.Controllers
{
    public class CredentialsController : Controller
    {
        public ActionResult Query(FcpaSearchDTO dto)
        {
            UserLoginDTO lng = Session["UserLoginInfo"] as UserLoginDTO;
            dto.UserInfo = lng.UserInfo();
            var result = FcpaProvider.Query(dto);
            return new JsonResult(result);
        }

        public ActionResult Distributors()
        {
            UserLoginDTO lng = Session["UserLoginInfo"] as UserLoginDTO;
            var result = FcpaProvider.Distributors(lng.UserInfo());
            return new JsonResult(result);
        }

        public ActionResult Add()
        {
            var result = AddOrUpdate();
            return new JsonResult(result);
        }


        public ActionResult Update()
        {
            var result = AddOrUpdate();
            return new JsonResult(result);
        }

        public ActionResult Download(string id)
        {
            var dto = FcpaProvider.Get(id);
            string path = Const.RealCredentialPath(id);
            return File(path, "application/octet-stream", string.Format("{0}.pdf", dto.Name));
        }

        public ActionResult AddOrgMap()
        {

            var files = HttpContext.Request.Files;
            var requestParams = HttpContext.Request.Params;
            if (string.IsNullOrEmpty(requestParams.Get("DistributorID"))) return this.HttpNotFound();
            var distributorID = requestParams.Get("DistributorID");
            files["OrgMap"].SaveAs(Const.RealOrgMapPath(distributorID));
            files["Trains"].SaveAs(Const.RealTrainsPath(distributorID));
            var dto = new OrgMapAddDTO
            {
                DistributorID = distributorID,
                OrgMap = distributorID,
                OrgMapFile = files["OrgMap"].FileName,
                Trains = distributorID,
                Status = 0,
                Domain1 = requestParams["Domain1"].TryBool(),
                Domain2 = requestParams["Domain2"].TryBool(),
                OrgMapUpdateTime = DateTime.Now,
                TrainsUpdateTime = DateTime.Now,
                OrgMapRealPath = Const.RealOrgMapPath(distributorID),
                TrainsRealPath = Const.RealTrainsPath(distributorID)
            };

            var result = FcpaProvider.AddOrgMap(dto);
            return new JsonResult(result);

        }



        private OperateResultDTO AddOrUpdate()
        {
            var request = HttpContext.Request;
            var files = request.Files;

            CredentialOperateDTO model = new CredentialOperateDTO
            {
                ID = string.IsNullOrEmpty(request.Params["ID"]) ? Guid.NewGuid() : Guid.Parse(request.Params["ID"]),
                DistributorID = request.Params["DistributorID"],
                Name = request.Params["Name"],
                Department = request.Params["Department"],
                Title = request.Params["Title"],
                CompletedDate = DateTime.Parse(request.Params["CompletedDate"]),
                ExpireDate = DateTime.Parse(request.Params["ExpireDate"]),
                OffWork = bool.Parse(request.Params["OffWork"]),
                Domain1 = request.Params["Domain1"].ToBool(),
                Domain2 = request.Params["Domain2"].ToBool(),
                Remark = request.Params["Remark"],
            };

            if (model.OffWork)
                model.OffWorkDate = DateTime.Parse(request.Params["OffWorkDate"]);

            if (files.AllKeys.Contains("Certificate") && !string.IsNullOrEmpty(files["Certificate"].FileName))
            {
                files["Certificate"].SaveAs(Const.RealCredentialPath(model.ID.ToString()));
                model.Certificate = model.ID.ToString();
            }
            if (string.IsNullOrEmpty(request.Params["ID"]))
            {
                return FcpaProvider.Add(model);
            }
            else
            {
                return FcpaProvider.Update(model);
            }

        }
    }
}