using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TCSOFT.DMS.Document.DTO;
using TCSOFT.DMS.Document.DTO.Register;
using TCSOFT.DMS.Document.IServices;
using TCSOFT.DMS.Document.Services;

namespace TCSOFT.DMS.DocumentAPI.Controllers
{
    [RoutePrefix("api/Register")]
    public class RegisterController : ApiController
    {
        IRegisterService _RegisterService = new RegisterService();
        IUserService _UserService = new UserService();


        [Route("Query"), HttpPost]
        public PageableDTO<RegisterResultDTO> Query(RegisterSearchDTO q)
        {
            q.UserInfo.ProductLineIDs = _UserService.GetProductLines(q.UserInfo.UserID);
            return _RegisterService.Query(q);
        }
        [Route("Get"), HttpPost]
        public RegisterResultDTO Get(string id)
        {
            return _RegisterService.Get(id);
        }
        [Route("Add"), HttpPost]
        public DocumentResultDTO Add(RegisterAddDTO model)
        {
            return _RegisterService.Add(model);
        }

        [Route("Update"), HttpPost]
        public DocumentResultDTO Update(RegisterUpdateDTO model)
        {
            return _RegisterService.Update(model);

        }

        [Route("Delete"), HttpPost]
        public DocumentResultDTO Delete(Guid id)
        {
            return _RegisterService.Delete(id);
        }

        [Route("ProductType"), HttpPost]
        public List<ProductTypeResultDTO> ProductType(DocumentDTO dto)
        {
            return _RegisterService.ProductType();
        }

        [Route("ProductLine"), HttpPost]
        public RootNode ProductLine(DocumentDTO dto)
        {
            dto.UserInfo.ProductLineIDs = _UserService.GetProductLines(dto.UserInfo.UserID);
            return _RegisterService.ProductLine(dto);
        }
    }
}
