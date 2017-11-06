using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCSOFT.DMS.WebMain.Areas.MasterData.Models.Provider
{
    using DMS.Common;
    using DMS.MasterData.DTO.Distributor.Distributor;
    using DMS.MasterData.DTO.Distributor.DistributorAnnounceAuthority;
    using DMS.MasterData.DTO.Distributor.DistributorAuthority;
    using DMS.MasterData.DTO.Distributor.DistributorServiceType;
    using DMS.MasterData.DTO.Distributor.DistributorType;
    using DMS.WebMain.Areas.MasterData.Models.Model.Distributor;
    using DMS.WebMain.Common;
    using DMS.WebMain.Models.Model;
    using DMS.WebMain.Models.Provider;
    using TCSOFT.DMS.MasterData.DTO.Area;
    using TCSOFT.DMS.MasterData.DTO.Distributor.DistributorPriceAuthority;
    using TCSOFT.DMS.MasterData.DTO.ImportExcel;
    using TCSOFT.DMS.MasterData.DTO.Product.OKCPriceInfo;
    public class DistributorProvider : BaseProvider
    {
        #region 经销商信息
        /// <summary>
        /// 得到所有经销商信息
        /// </summary>
        /// <returns></returns>
        public static ResultData<List<DistributorModel>> GetDistributorList(DistributorSearchDTO dto, string strSaveDir = "")
        {
            ResultData<List<DistributorModel>> result = null;

            result = GetAPI<ResultData<List<DistributorModel>>>(WebConfiger.MasterDataServicesUrl + "DistributorManagerment?DistributorSearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));
            if (strSaveDir != "")
            {
                foreach (var f in result.Object)
                {
                    var pp = System.IO.Directory.GetFiles(strSaveDir, f.DistributorID.Value.ToString("N") + ".*", System.IO.SearchOption.AllDirectories);
                    foreach (string p in pp)
                    {
                        f.IsAtt = true;
                    }
                }
            }
            
            return result;
        }
        /// <summary>
        /// 得到一条经销商信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<DistributorModel> GetOneDistributor(DistributorSearchDTO dto)
        {
            ResultData<DistributorModel> result = new ResultData<DistributorModel>();

            var pp = GetAPI<ResultData<List<DistributorModel>>>(WebConfiger.MasterDataServicesUrl + "DistributorManagerment?DistributorSearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));
            if (pp.Object != null && pp.Object.Count > 0)
            {
                result.Object = pp.Object.First();
                result.SubmitResult = true;
            }
            else
            {
                result.Message = "此条信息不存在！";
                result.SubmitResult = false;
            }

            return result;
        }
        /// <summary>
        /// 新增经销商信息
        /// </summary>
        /// <returns></returns>
        public static ResultData<object> AddDistributor(DistributorOperateDTO dto)
        {
            ResultData<object> result = null;

            result = PostAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "DistributorManagerment", dto);

            return result;
        }
        /// <summary>
        /// 修改经销商信息
        /// </summary>
        /// <returns></returns>
        public static ResultData<object> UpdateDistributor(DistributorOperateDTO dto)
        {
            ResultData<object> result = null;

            result = PutAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "DistributorManagerment", dto);

            return result;
        }
        /// <summary>
        /// 删除经销商信息
        /// </summary>
        /// <returns></returns>
        public static ResultData<object> DeleteDistributor(DistributorOperateDTO dto)
        {
            ResultData<object> result = null;

            result = DeleteAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "DistributorManagerment?DistributorOperateDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return result;
        }
        /// <summary>
        /// 停启用经销商信息
        /// </summary>
        /// <returns></returns>
        public static ResultData<object> StartOrStopDistributor(DistributorOperateDTO dto)
        {
            ResultData<object> result = null;

            result = PutAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "DistributorManagerment", dto);

            return result;
        }
        /// <summary>
        /// 经销商更名
        /// </summary>
        /// <returns></returns>
        public static ResultData<object> ChangeNameDistributor(DistributorChangeNameDTO dto)
        {
            ResultData<object> result = null;

            result = PostAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "DistributorChangeName", dto);

            return result;
        }
        /// <summary>
        /// 导入经销商
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> ImportDistributor(List<ExcelDistributorDTO> dto)
        {
            return PostAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "ImportData", new { Data = TransformHelper.ConvertDTOTOBase64JsonString(dto), Type = 6 });
        }
        #endregion

        #region 经销商类别
        /// <summary>
        /// 得到经销商类别
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static List<DistributorTypeResultDTO> GetDistributorTypeList(DistributorTypeSearchDTO dto)
        {
            List<DistributorTypeResultDTO> result = null;

            result = GetAPI<List<DistributorTypeResultDTO>>(WebConfiger.MasterDataServicesUrl + "DistributorType?DistributorTypeSearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return result;
        }
        /// <summary>
        /// 得到一条经销商类别
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static ResultData<DistributorTypeResultDTO> GetDistributorType(DistributorTypeSearchDTO dto)
        {
            ResultData<DistributorTypeResultDTO> result = new ResultData<DistributorTypeResultDTO>();

            var resultlist = GetAPI<List<DistributorTypeResultDTO>>(WebConfiger.MasterDataServicesUrl + "DistributorType?DistributorTypeSearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            if (resultlist.Count > 0)
            {
                result.Object = resultlist.First();
                result.SubmitResult = true;
            }
            else
            {
                result.Message = "此条信息不存在！";
            }

            return result;
        }
        /// <summary>
        /// 经销商类别新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> AddDistributorType(DistributorTypeOperateDTO dto)
        {
            ResultData<object> result = null;

            result = PostAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "DistributorType", dto);

            return result;
        }
        /// <summary>
        /// 经销商类别修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> UpdateDistributorType(DistributorTypeOperateDTO dto)
        {
            ResultData<object> result = null;

            result = PutAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "DistributorType", dto);

            return result;
        }
        /// <summary>
        /// 经销商类别删除
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> DeleteDistributorType(DistributorTypeOperateDTO dto)
        {
            ResultData<object> blResult = DeleteAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "DistributorType?DistributorTypeOperateDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return blResult;
        }
        #endregion

        #region 经销商服务类型
        /// <summary>
        /// 得到经销商服务类型
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static List<DistributorServiceTypeResultDTO> GetDistributorServiceTypeList(DistributorServiceTypeSearchDTO dto)
        {
            List<DistributorServiceTypeResultDTO> result = null;

            result = GetAPI<List<DistributorServiceTypeResultDTO>>(WebConfiger.MasterDataServicesUrl + "DistributorServiceType?DistributorServiceTypeSearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return result;
        }
        /// <summary>
        /// 得到一条经销商服务类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static ResultData<DistributorServiceTypeResultDTO> GetDistributorServiceType(DistributorServiceTypeSearchDTO dto)
        {
            ResultData<DistributorServiceTypeResultDTO> result = new ResultData<DistributorServiceTypeResultDTO>();

            var resultlist = GetAPI<List<DistributorServiceTypeResultDTO>>(WebConfiger.MasterDataServicesUrl + "DistributorServiceType?DistributorServiceTypeSearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            if (resultlist.Count > 0)
            {
                result.Object = resultlist.First();
                result.SubmitResult = true;
            }
            else
            {
                result.Message = "此条信息不存在！";
            }

            return result;
        }
        /// <summary>
        /// 经销商服务类型新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> AddDistributorServiceType(DistributorServiceTypeOperateDTO dto)
        {
            ResultData<object> result = null;

            result = PostAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "DistributorServiceType", dto);

            return result;
        }
        /// <summary>
        /// 经销商服务类型修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> UpdateDistributorServiceType(DistributorServiceTypeOperateDTO dto)
        {
            ResultData<object> result = null;

            result = PutAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "DistributorServiceType", dto);

            return result;
        }
        /// <summary>
        /// 经销商服务类型删除
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> DeleteDistributorServiceType(DistributorServiceTypeOperateDTO dto)
        {
            ResultData<object> blResult = DeleteAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "DistributorServiceType?DistributorServiceTypeOperateDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return blResult;
        }
        #endregion

        #region 经销商授权
        /// <summary>
        /// 得到经销商授权信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static List<DistributorAuthorityResultDTO> GetDistributorAuthority(DistributorAuthoritySearchDTO dto)
        {
            List<DistributorAuthorityResultDTO> result = null;

            result = GetAPI<List<DistributorAuthorityResultDTO>>(WebConfiger.MasterDataServicesUrl + "DistributorAuthority?DistributorAuthoritySearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return result;
        }
        /// <summary>
        /// 经销商授权信息
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="ProductLineID"></param>
        /// <returns></returns>
        public static DistributorAuthorityResultDTO GetOneDistributorAuthority(DistributorAuthoritySearchDTO dto)
        {
            DistributorAuthorityResultDTO result = null;

            var pp = GetAPI<List<DistributorAuthorityResultDTO>>(WebConfiger.MasterDataServicesUrl + "DistributorAuthority?DistributorAuthoritySearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));
            result = pp.FirstOrDefault();

            return result;
        }
        /// <summary>
        /// 得到经销商授权付款条款
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static List<DistributorPaymentResultDTO> GetDistributorAuthorityPay(DistributorAuthoritySearchDTO dto)
        {
            List<DistributorPaymentResultDTO> result = null;

            result = GetAPI<List<DistributorPaymentResultDTO>>(WebConfiger.MasterDataServicesUrl + "DistributorAuthorityPay?DistributorAuthoritySearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return result;
        }
        /// <summary>
        /// 得到经销商授权运输方式
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static List<DistributorTransportResultDTO> GetDistributorAuthorityTransport(DistributorAuthoritySearchDTO dto)
        {
            List<DistributorTransportResultDTO> result = null;

            result = GetAPI<List<DistributorTransportResultDTO>>(WebConfiger.MasterDataServicesUrl + "DistributorAuthorityTransport?DistributorAuthoritySearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return result;
        }
        /// <summary>
        /// 得到经销商授权产品线
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<List<DistributorProductLineResultDTO>> GetDistributorAuthorityProductLine(DistributorAuthoritySearchDTO dto)
        {
            ResultData<List<DistributorProductLineResultDTO>> result = null;

            result = GetAPI<ResultData<List<DistributorProductLineResultDTO>>>(WebConfiger.MasterDataServicesUrl + "DistributorAuthorityProductLine?DistributorAuthoritySearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return result;
        }
        /// <summary>
        /// 得到经销商授权产品线区域
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<List<DistributorRegionResultDTO>> GetDistributorAuthorityRegion(DistributorAuthoritySearchDTO dto)
        {
            ResultData<List<DistributorRegionResultDTO>> result = null;

            result = GetAPI<ResultData<List<DistributorRegionResultDTO>>>(WebConfiger.MasterDataServicesUrl + "DistributorAuthorityRegion?DistributorAuthoritySearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return result;
        }
        /// <summary>
        /// 大小区显示/小区省份显示
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static List<AreaResultDTO> GetArea(AreaSearchDTO dto)
        {
            List<AreaResultDTO> arealist = null;

            arealist = GetAPI<List<AreaResultDTO>>(WebConfiger.MasterDataServicesUrl + "Area?AreaSearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));
            foreach (var a in arealist) 
            {
                foreach (var b in a.children)
                {
                    b.children.ForEach(f => { f.Ckid = true; });
                }
            }


            return arealist;
        }
        /// <summary>
        /// 授权经销商付款条款
        /// </summary>
        /// <returns></returns>
        public static ResultData<object> DistributorPayAuthority(DistributorAuthorityModel dto)
        {
            ResultData<object> result = null;
            DistributorAuthorityOperateDTO disdto = new DistributorAuthorityOperateDTO();
            disdto = dto;
            disdto.PayIDlist = dto.PayID;

            result = PostAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "DistributorAuthority", disdto);

            return result;
        }
        /// <summary>
        /// 授权经销商运输方式
        /// </summary>
        /// <returns></returns>
        public static ResultData<object> DistributorTransportAuthority(DistributorAuthorityModel dto)
        {
            ResultData<object> result = null;
            DistributorAuthorityOperateDTO disdto = new DistributorAuthorityOperateDTO();
            disdto = dto;
            disdto.TransportIDlist = new List<int>() { dto.TransportID.Value };

            result = PostAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "DistributorAuthority", disdto);

            return result;
        }
        /// <summary>
        /// 授权经销商产品线
        /// </summary>
        /// <returns></returns>
        public static ResultData<object> DistributorProductLineAuthority(DistributorAuthorityModel dto)
        {
            ResultData<object> result = null;
            DistributorAuthorityOperateDTO disdto = new DistributorAuthorityOperateDTO();
            disdto = dto;
            disdto.ProductLineRegion = new List<DistributorProductLineOperateDTO>() { 
                new DistributorProductLineOperateDTO(){ProductLineID = dto.ProductLineID.Value}
            };
            result = PostAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "DistributorAuthority", disdto);

            return result;
        }
        /// <summary>
        /// 授权经销商授权产品线区域
        /// </summary>
        /// <returns></returns>
        public static ResultData<object> DistributorProductLineRegionAuthority(DistributorAuthorityModel dto)
        {
            ResultData<object> result = null;
            DistributorAuthorityOperateDTO disdto = new DistributorAuthorityOperateDTO();
            disdto = dto;
            disdto.ProductLineRegion = new List<DistributorProductLineOperateDTO>();
            DistributorProductLineOperateDTO dp=new DistributorProductLineOperateDTO();
            dp.DistributorProductLineID = dto.DistributorProductLineID.Value;
            dp.Regionlist = new List<DistributorRegionOperateDTO>();
            disdto.ProductLineRegion.Add(dp);
            var ass = dto.AuthorityRegion.Split('|').ToList();
            ass.ForEach(f => {
                if (f != "") 
                {
                    DistributorRegionOperateDTO dr = new DistributorRegionOperateDTO();
                    var s = f.Split(',').ToList();
                    dr.RegionID = int.Parse(s[0]);
                    dr.DistrictID = int.Parse(s[1]);
                    dp.Regionlist.Add(dr);
                }
            });

            result = PostAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "DistributorAuthority", disdto);

            return result;
        }
        /// <summary>
        /// 修改经销商授权
        /// </summary>
        /// <returns></returns>
        public static ResultData<object> UpdataDistributorAuthority(DistributorAuthorityOperateDTO dto)
        {
            ResultData<object> result = null;

            result = PutAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "DistributorAuthority", dto);

            return result;
        }
        /// <summary>
        /// 删除经销商信息
        /// </summary>
        /// <returns></returns>
        public static ResultData<object> DeleteDistributorAuthority(DistributorAuthorityOperateDTO dto)
        {
            ResultData<object> result = null;

            result = DeleteAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "DistributorAuthority?DistributorAuthorityOperateDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return result;
        }
        /// <summary>
        /// 导入经销商授权
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> ImportDistributorAuthority(List<ExcelDistributorAuthorityDTO> dto)
        {
            return PostAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "ImportData", new { Data = TransformHelper.ConvertDTOTOBase64JsonString(dto), Type = 7 });
        }
        #endregion

        #region 经销商公告授权
        /// <summary>
        /// 得到经销商公告授权
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<List<DistributorAnnounceAuthorityModel>> GetDistributorAnnounceAuthorityList(DistributorAnnounceAuthoritySearchDTO dto)
        {
            ResultData<List<DistributorAnnounceAuthorityModel>> result = null;

            result = GetAPI<ResultData<List<DistributorAnnounceAuthorityModel>>>(WebConfiger.MasterDataServicesUrl + "DistributorAnnounceAuthority?DistributorAnnounceAuthoritySearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return result;
        }
        /// <summary>
        /// 新增经销商公告授权
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> AddDistributorAnnounceAuthority(DistributorAnnounceAuthorityOperateDTO dto)
        {
            dto.ProductLineIDList = dto.ProductLineIDList.Where(p => p.HasValue).ToList();
            ResultData<object> result = null;

            result = PostAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "DistributorAnnounceAuthority", dto);

            return result;
        }
        /// <summary>
        /// 导入经销商公告授权
        /// </summary>
        /// <param name="regentprdlist"></param>
        /// <returns></returns>
        public static ResultData<object> ImportDistributorAnnounceAuthority(List<ExcelDistributorADAuthorityDTO> implist)
        {
            return PostAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "ImportData", new { Data = TransformHelper.ConvertDTOTOBase64JsonString(implist), Type = 8 });
        }
        #endregion

        #region 经销商价格授权
        /// <summary>
        /// 得到经销商OKC信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<List<DistributorOKCProduct>> GetDisOKCList(DistributorPriceAuthoritySearchDTO dto)
        {
            ResultData<List<DistributorOKCProduct>> result = null;

            result = GetAPI<ResultData<List<DistributorOKCProduct>>>(WebConfiger.MasterDataServicesUrl + "DistributorPriceAuthority?DistributorPriceAuthoritySearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return result;
        }
        #endregion
    }
}