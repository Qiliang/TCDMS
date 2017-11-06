using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TCSOFT.DMS.Common;
using TCSOFT.DMS.MasterData.DTO.Common;
using TCSOFT.DMS.MasterData.DTO.User;
using TCSOFT.DMS.MasterData.IServices;
using TCSOFT.DMS.MasterData.Services;

namespace TCSOFT.DMS.MasterDataAPI.Controllers
{
    public class UsersByAuthoritedController : ApiController
    {
        IUserAuthorityServices _lUserAuthorityServices = null;
        public UsersByAuthoritedController()
        {
            _lUserAuthorityServices = new UserAuthorityServices();
        }

        /// <summary>
        /// 得到已授权用户模块
        /// </summary>
        /// <param name="UsersByAuthoritedSearchDTO"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetUsersByAuthorited(string UsersByAuthoritedSearchDTO)
        {
            ResultDTO<List<UsersByAuthoritedResultDTO>> resultdto = new ResultDTO<List<UsersByAuthoritedResultDTO>>();

            try
            {
                UsersByAuthoritedSearchDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<UsersByAuthoritedSearchDTO>(UsersByAuthoritedSearchDTO);
                List<UsersByAuthoritedResultDTO> user = _lUserAuthorityServices.GetUsersByAuthorited(dto);
                resultdto.Object = user;
                resultdto.Count = dto.Count;
                resultdto.rows = dto.rows;
            }
            catch (Exception ex)
            {
                resultdto.SubmitResult = false;
                resultdto.Message = ex.Message;
            }
            
            HttpResponseMessage result = new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(resultdto),
                    System.Text.Encoding.GetEncoding("UTF-8"),
                    "application/json")
            };

            return result;
        }
    }
}
