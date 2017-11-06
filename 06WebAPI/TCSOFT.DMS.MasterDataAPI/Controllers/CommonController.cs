using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace TCSOFT.DMS.MasterDataAPI.Controllers
{
    using MasterData.DTO;
    using MasterData.IServices;
    using MasterData.Services;
    using TCSOFT.DMS.MasterData.DTO.Common;
    /// <summary>
    /// 公共服务
    /// </summary>
    public class CommonController : ApiController
    {
        /// <summary>
        /// 定义公共数据接口
        /// </summary>
        ICommonServices _ICommonServices = null;
        /// <summary>
        /// 构造并实现公共数据接口
        /// </summary>
        public CommonController()
        {
            _ICommonServices = new CommonServices();
        }

        /// <summary>
        /// 取得公共信息
        /// </summary>
        /// <param name="type">类型：1 结构信息；2 按钮信息</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetAllCommonInfo(int type)
        {
            HttpResponseMessage result = new HttpResponseMessage();
            string strcontent = null;
            switch (type)
            {
                case 1:// 取得所有结构
                    List<StructureDTO> structure = _ICommonServices.GetAllStructure();
                    strcontent = JsonConvert.SerializeObject(structure);
                    break;
                case 2:
                    List<ButtonDTO> buttons = _ICommonServices.GetAllButton();
                    strcontent = JsonConvert.SerializeObject(buttons);
                    break;
                case 3:
                    break;
                default:
                    break;
            }

            result.Content = new StringContent(strcontent,System.Text.Encoding.GetEncoding("UTF-8"),"application/json");

            return result;
        }
        /// <summary>
        /// 通过所属模块取得日志
        /// </summary>
        /// <param name="BelongModel">模块名</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetAllLogByBelongModel(string BelongModel)
        {
            List<LogDTO> logs = _ICommonServices.GetAllLogByBelongModel(BelongModel);

            HttpResponseMessage result = new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(logs),
                    System.Text.Encoding.GetEncoding("UTF-8"),
                    "application/json")
            };

            return result;
        }

        /// <summary>
        /// 获取权限
        /// </summary>
        /// <param name="strIdlst">用户或者角色ID(多个用|相隔)</param>
        /// <param name="type">1：用户类型 2：角色类型</param>
        /// <param name="roletype">0：系统管理员 1：贝克曼 2：经销商</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetAuthority(string strIdlst, int type, int? roletype)
        {
            List<CurrentAuthorityDTO> resultAuthority = null;
            switch (type)
            {
                case 1:
                    if (strIdlst!=null)
                    {
                        resultAuthority = _ICommonServices.GetUserAuthority(int.Parse(strIdlst));
                    }
                    break;
                case 2:
                    if (strIdlst != null)
                    {
                        var arrstr = strIdlst.Split('|').ToList();
                        
                        List<int> intIdLst = new List<int>();
                        arrstr.ForEach(g => {
                            if (g != "")
                            {
                                intIdLst.Add(int.Parse(g));
                            }
                        });
                        resultAuthority = _ICommonServices.GetRoleAuthority(intIdLst);
                    }
                    else if (roletype != null)
                    {
                        resultAuthority = _ICommonServices.GetRoleTypeAuthority(roletype.Value);
                    }
                    break;
            }

            HttpResponseMessage result = new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(resultAuthority),
                    System.Text.Encoding.GetEncoding("UTF-8"),
                    "application/json")
            };

            return result;
        }

        /// <summary>
        /// 取得管理员信息
        /// </summary>
        /// <param name="asdto">管理员查询对象</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetAllAdminInfo(string asdto)
        {
            AdminSearchDTO asdtos = Common.TransformHelper.ConvertBase64JsonStringToDTO<AdminSearchDTO>(asdto);
            List<AdminDTO> admins = _ICommonServices.GetAdminInfo(asdtos);

            HttpResponseMessage result = new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(admins),
                    System.Text.Encoding.GetEncoding("UTF-8"),
                    "application/json")
            };

            return result;
        }
    }
}