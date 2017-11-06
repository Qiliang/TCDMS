using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace TCSOFT.DMS.MasterData.Services
{
    using DTO;
    using Entities;
    using DTO.Area;
    using DTO.Common;
    using DTO.User.UserApply;
    using DTO.Role;
    using DTO.User;
    using DTO.RateDTO;
    using DTO.AccountDate;
    using DTO.Transport;
    using DTO.Payment;
    using DTO.Distributor.DistributorType;
    using DTO.Distributor.Distributor;
    using DTO.Distributor.DistributorServiceType;
    using DTO.Product.ProductLine;
    using DTO.Product.ProductSmallType;
    using DTO.Product.MaintenanceInfo;
    using DTO.Product.ProductPriceInfo;
    using DTO.Product.ProductType;
    using DTO.Product.InstrumentType;
    using DTO.Product.ReagentInfo;
    using TCSOFT.DMS.MasterData.DTO.Product.ProductModel;
    using TCSOFT.DMS.MasterData.DTO.Product.ProductInfo;
    using TCSOFT.DMS.MasterData.DTO.Product.OKCPriceInfo;
    using TCSOFT.DMS.MasterData.DTO.Customer;
    using TCSOFT.DMS.MasterData.DTO.Distributor.DistributorAuthority;
    using TCSOFT.DMS.MasterData.DTO.Distributor.DistributorAnnounceAuthority;
    using TCSOFT.DMS.MasterData.DTO.Message;
    using TCSOFT.DMS.MasterData.DTO.CustomerAudit;
    using TCSOFT.DMS.MasterData.DTO.UsersStat;
    using TCSOFT.DMS.MasterData.DTO.Distributor.DistributorPriceAuthority;
    internal class SingleQueryObject
    {
        private static TCDMS_MasterDataEntities _OBJ = null;
        public static TCDMS_MasterDataEntities GetObj()
        {
            if (_OBJ == null)
            {
                _OBJ = new TCDMS_MasterDataEntities();

                Mapper.Initialize(cfg =>
                {
                    cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                    var mru = cfg.CreateMap<master_RoleAuthority, CurrentUserRoleAuthority>();
                    mru.ForMember(p => p.StructureID, opt => opt.MapFrom(s => s.StructureID));
                    mru.ForMember(p => p.RoleButtonAuthority, opt => opt.MapFrom(s => s.RoleButtonAuthority));

                    var muc = cfg.CreateMap<master_UserCustomerAuthority, CurrentUserCustomerAuthority>();
                    muc.ForMember(p => p.StructureID, opt => opt.MapFrom(s => s.StructureID));
                    muc.ForMember(p => p.UserButtonAuthority, opt => opt.MapFrom(s => s.UserButtonAuthority));

                    var muu = cfg.CreateMap<master_UserInfo, UserLoginDTO>();
                    muu.ForMember(p => p.CurrentUserCustomerAuthorityList, opt => opt.MapFrom(s => s.master_UserCustomerAuthority.ToList()));
                    muu.ForMember(p => p.CurrentRoleIDList, opt => opt.MapFrom(s => s.master_RoleInfo.Select(m => m.RoleID).ToList()));
                    muu.ForMember(p => p.DistributorIDlist, opt => opt.MapFrom(s => s.master_DistributorInfo.Select(sw => sw.DistributorID).ToList()));
                    muu.ForMember(p => p.DistributorNamelist, opt => opt.MapFrom(s => s.master_DistributorInfo.Select(sw => sw.DistributorName).ToList()));
                    muu.ForMember(p => p.Distributorstr, opt => opt.MapFrom(s => string.Join(",", s.master_DistributorInfo.Select(m => m.DistributorName).ToList())));

                    cfg.CreateMap<master_AreaInfo, AreaResultDTO>();
                    cfg.CreateMap<AreaOperateDTO, master_AreaInfo>();
                    var qyxz = cfg.CreateMap<master_AreaRegionInfo, AreaResultDTO>();
                    qyxz.ForMember(p => p.AreaName, opt => opt.MapFrom(s => s.dict_RegionInfo.RegionName));
                    qyxz.ForMember(p => p.AreaID, opt => opt.MapFrom(s => s.AreaRegionID));

                    var apptodto = cfg.CreateMap<master_CustomerApplyInfo, CustomerAuditResultDTO>();
                    apptodto.ForMember(p => p.DistributorName, opt => opt.MapFrom(s => s.master_DistributorInfo.DistributorName));

                    cfg.CreateMap<MessageOperateDTO, master_MessageStat>();
                    var msetodto = cfg.CreateMap<master_MessageStat, MessageResultDTO>();
                    msetodto.ForMember(p => p.DepartName, opt => opt.MapFrom(s => s.master_UserInfo.master_DepartmentInfo.DepartName));
                    msetodto.ForMember(p => p.FullName, opt => opt.MapFrom(s => s.master_UserInfo.FullName));
                    msetodto.ForMember(p => p.PhoneNumber, opt => opt.MapFrom(s => s.master_UserInfo.PhoneNumber));
                    msetodto.ForMember(p => p.UserType, opt => opt.MapFrom(s => s.master_UserInfo.UserType));
                    msetodto.ForMember(p => p.UserDistributorstr, opt => opt.MapFrom(s => string.Join(",", s.master_UserInfo.master_DistributorInfo.Select(m => m.DistributorName).ToList())));

                    cfg.CreateMap<UsersStatOperateDTO, master_UsersStat>();
                    var ustatodto = cfg.CreateMap<master_UsersStat, UsersStatResultDTO>();
                    ustatodto.ForMember(p => p.DepartName, opt => opt.MapFrom(s => s.master_UserInfo.master_DepartmentInfo.DepartName));
                    ustatodto.ForMember(p => p.FullName, opt => opt.MapFrom(s => s.master_UserInfo.FullName));
                    ustatodto.ForMember(p => p.PhoneNumber, opt => opt.MapFrom(s => s.master_UserInfo.PhoneNumber));
                    ustatodto.ForMember(p => p.UserType, opt => opt.MapFrom(s => s.master_UserInfo.UserType));
                    ustatodto.ForMember(p => p.UserDistributorstr, opt => opt.MapFrom(s => string.Join(",", s.master_UserInfo.master_DistributorInfo.Select(m => m.DistributorName).ToList())));

                    var distoannau = cfg.CreateMap<master_DistributorInfo, DistributorAnnounceAuthorityResultDTO>();
                    distoannau.ForMember(p => p.DistributorServiceTypeName, opt => opt.MapFrom(s => s.master_DistributorServiceType.DistributorServiceTypeName));
                    distoannau.ForMember(p => p.DistributorTypeName, opt => opt.MapFrom(s => s.master_DistributorType.DistributorTypeName));
                    distoannau.ForMember(p => p.RegionName, opt => opt.MapFrom(s => s.dict_RegionInfo.RegionName));
                    distoannau.ForMember(p => p.ProductLineList, opt => opt.MapFrom(s => s.master_DistributorADInfo.Select(m => m.master_ProductLine).ToList()));

                    cfg.CreateMap<DepartmentOperateDTO, master_DepartmentInfo>();
                    cfg.CreateMap<master_DepartmentInfo, DepartmentResultDTO>();

                    var ra = cfg.CreateMap<master_RoleInfo, RoleResultDTO>();
                    ra.ForMember(p => p.RoleAuthority, opt => opt.MapFrom(s => s.master_RoleAuthority));
                    cfg.CreateMap<RoleOperateDTO, master_RoleInfo>();
                    var raaut=cfg.CreateMap<master_RoleAuthority, RoleAuthorityDTO>();
                    raaut.ForMember(p => p.StructureName, opt => opt.MapFrom(s => s.dict_Structure.StructureName));

                    cfg.CreateMap<RateOperateDTO, master_RateInfo>();
                    cfg.CreateMap<master_RateInfo, RateResultDTO>();

                    cfg.CreateMap<AccountDateOperateDTO, master_AccountDateInfo>();
                    cfg.CreateMap<master_AccountDateInfo, AccountDateResultDTO>();

                    cfg.CreateMap<master_PaymentInfo, PaymentResultDTO>();
                    cfg.CreateMap<PaymentOperateDTO, master_PaymentInfo>();

                    cfg.CreateMap<RegionOperateDTO, dict_RegionInfo>();
                    cfg.CreateMap<dict_RegionInfo, RegionResultDTO>();

                    cfg.CreateMap<dict_Structure, StructureDTO>();
                    cfg.CreateMap<dict_ButtonInfo, ButtonDTO>();

                    cfg.CreateMap<common_LogInfo, LogDTO>();

                    cfg.CreateMap<UserOperate, master_UserInfo>();
                    var userinfo = cfg.CreateMap<master_UserInfo, UserResultDTO>();
                    userinfo.ForMember(p => p.DepartName, opt => opt.MapFrom(s => s.master_DepartmentInfo.DepartName));
                    userinfo.ForMember(p => p.UserAuthority, opt => opt.MapFrom(s => s.master_UserCustomerAuthority));
                    userinfo.ForMember(p => p.UserRolelist, opt => opt.MapFrom(s => s.master_RoleInfo.Select(rs=>rs.RoleID)));
                    userinfo.ForMember(p => p.UserRoleNamelist, opt => opt.MapFrom(s => s.master_RoleInfo.Select(rs => rs.RoleName)));
                    userinfo.ForMember(p => p.UserDistributorid, opt => opt.MapFrom(s => s.master_DistributorInfo.Select(ds => ds.DistributorID)));
                    userinfo.ForMember(p => p.UserDistributorNamelist, opt => opt.MapFrom(s => s.master_DistributorInfo.Select(ds => ds.DistributorName)));

                    var user = cfg.CreateMap<master_UserCustomerAuthority, StructureDTO>();
                    user.ForMember(p => p.BelongButton, opt => opt.MapFrom(s => s.UserButtonAuthority));
                    user.ForMember(p => p.StructureName, opt => opt.MapFrom(s => s.dict_Structure.StructureName));

                    cfg.CreateMap<master_TransportInfo, TransportResultDTO>();
                    cfg.CreateMap<TransportOperateDTO, master_TransportInfo>();

                    cfg.CreateMap<master_ProductType, ProductTypeResultDTO>();
                    cfg.CreateMap<ProductTypeOperateDTO, master_ProductType>();

                    cfg.CreateMap<master_InstrumentType, InstrumentTypeResultDTO>();
                    cfg.CreateMap<InstrumentTypeOperateDTO, master_InstrumentType>();

                    var ctore = cfg.CreateMap<master_CustomerInfo, CustomerResultDTO>();
                    ctore.ForMember(p => p.Auditor, opt => opt.MapFrom(s => _OBJ.master_CustomerApplyInfo.AsNoTracking().Where(p => p.CustomerApplyID == s.CustomerID).Select(m => m.Auditor).FirstOrDefault()));
                    ctore.ForMember(p => p.DistributorName, opt => opt.MapFrom(s => s.master_DistributorInfo.DistributorName));
                    cfg.CreateMap<CustomerOperateDTO, master_CustomerInfo>();
                    

                    cfg.CreateMap<DistributorOperateDTO, master_DistributorInfo>();
                    var dist = cfg.CreateMap<master_DistributorInfo, DistributorResultDTO>();
                    dist.ForMember(p => p.DistributorServiceTypeName, opt => opt.MapFrom(s => s.master_DistributorServiceType.DistributorServiceTypeName));
                    dist.ForMember(p => p.DistributorTypeName, opt => opt.MapFrom(s => s.master_DistributorType.DistributorTypeName));
                    dist.ForMember(p => p.RegionName, opt => opt.MapFrom(s => s.dict_RegionInfo.RegionName));

                    cfg.CreateMap<master_DistributorType, DistributorTypeResultDTO>();
                    cfg.CreateMap<DistributorTypeOperateDTO, master_DistributorType>();

                    cfg.CreateMap<AttachFileOperateDTO, common_AttachFileInfo>();
                    cfg.CreateMap<common_AttachFileInfo, AttachFileResultDTO>();

                    cfg.CreateMap<master_DistributorServiceType, DistributorServiceTypeResultDTO>();
                    cfg.CreateMap<DistributorServiceTypeOperateDTO, master_DistributorServiceType>();

                    cfg.CreateMap<FeedbackOperateDTO, master_FeedbackStat>();
                    var feedtore = cfg.CreateMap<master_FeedbackStat, FeedbackResultDTO>();
                    feedtore.ForMember(p => p.DepartName, opt => opt.MapFrom(s => s.master_UserInfo.master_DepartmentInfo.DepartName));
                    feedtore.ForMember(p => p.FullName, opt => opt.MapFrom(s => s.master_UserInfo.FullName));
                    feedtore.ForMember(p => p.PhoneNumber, opt => opt.MapFrom(s => s.master_UserInfo.PhoneNumber));
                    feedtore.ForMember(p => p.Email, opt => opt.MapFrom(s => s.master_UserInfo.Email));
                    feedtore.ForMember(p => p.UserType, opt => opt.MapFrom(s => s.master_UserInfo.UserType));
                    feedtore.ForMember(p => p.UserDistributorstr, opt => opt.MapFrom(s => string.Join(",",s.master_UserInfo.master_DistributorInfo.Select(m=>m.DistributorName).ToList())));
                    feedtore.ForMember(p => p.AttachFile, opt => opt.MapFrom(s => _OBJ.common_AttachFileInfo.Where(p=>p.BelongModule==1 && p.BelongModulePrimaryKey==(s.FeedbackStatID+"")).FirstOrDefault()));
                    //产品线
                    var proline = cfg.CreateMap<master_ProductLine, ProductLineResultDTO>();
                    proline.ForMember(p => p.DepartName, opt => opt.MapFrom(s => s.master_DepartmentInfo.DepartName));
                    cfg.CreateMap<ProductLineOperateDTO, master_ProductLine>();
                    //产品小类
                    var prosmatype = cfg.CreateMap<master_ProductSmallType, ProductSmallTypeResultDTO>();
                    prosmatype.ForMember(p => p.ProductLineName, opt => opt.MapFrom(s => s.master_ProductLine.ProductLineName));
                    cfg.CreateMap<ProductSmallTypeOperateDTO, master_ProductSmallType>();
                    //产品型号
                    var ss = cfg.CreateMap<master_ProductModel, ProductModelResultDTO>();
                    ss.ForMember(p => p.ProductLineName, opt => opt.MapFrom(s => s.master_ProductLine.ProductLineName));
                    cfg.CreateMap<ProductModelOperateDTO, master_ProductModel>();
                    //产品清单
                    var promain = cfg.CreateMap<master_ProductInfo, ProductInfoResultDTO>();
                    promain.ForMember(p => p.ProductLineName, opt => opt.MapFrom(s => s.master_ProductLine.ProductLineName));
                    promain.ForMember(p => p.ProductTypeName, opt => opt.MapFrom(s => s.master_ProductType.ProductTypeName));
                    promain.ForMember(p => p.ProductSmallTypeName, opt => opt.MapFrom(s => s.master_ProductSmallType.ProductSmallTypeName));
                    cfg.CreateMap<ProductInfoOperateDTO, master_ProductInfo>();

                    //产品价格
                    var proprice = cfg.CreateMap<master_ProductPriceInfo, ProductPriceInfoResultDTO>();
                    proprice.ForMember(p => p.Product, opt => opt.MapFrom(s => s.master_ProductInfo));
                    cfg.CreateMap<ProductPriceInfoOperateDTO, master_ProductPriceInfo>();

                    //OKC
                    var okc = cfg.CreateMap<master_OKCInfo, OKCPriceInfoResultDTO>();
                    //okc.ForMember(p => p.OKCProductList, opt => opt.MapFrom(s => s.master_ProductOKCPriceInfo));
                    //okc.ForMember(p => p.OKCDistributorList, opt => opt.MapFrom(s => s.master_DistributorOKCInfo));
                    //OKC产品特价
                    var okcpro = cfg.CreateMap<master_ProductOKCPriceInfo, OKCProductResult>();
                    okcpro.ForMember(p => p.ArtNo, opt => opt.MapFrom(s => s.master_ProductInfo.ArtNo));
                    okcpro.ForMember(p => p.ProductName, opt => opt.MapFrom(s => s.master_ProductInfo.ProductName));
                    okcpro.ForMember(p => p.ProductLineName, opt => opt.MapFrom(s => s.master_ProductInfo.master_ProductLine.ProductLineName));
                    //OKC经销商及最终客户
                    var okcdepcut = cfg.CreateMap<master_DistributorOKCInfo, OKCDistributorResult>();
                    okcdepcut.ForMember(p => p.DistributorName, opt => opt.MapFrom(s => s.master_DistributorInfo.DistributorName));
                    okcdepcut.ForMember(p => p.CustomerName, opt => opt.MapFrom(s => s.master_CustomerInfo.CustomerName));
                    cfg.CreateMap<OKCPriceInfoOperateDTO, master_OKCInfo>();
                    cfg.CreateMap<OKCProductOperate, master_ProductOKCPriceInfo>();
                    cfg.CreateMap<OKCDistributorOperate, master_DistributorOKCInfo>();
                    //经销商价格授权
                    var disokc = cfg.CreateMap<master_DistributorOKCInfo, DistributorOKCProduct>();
                    disokc.ForMember(p => p.OKCNO, opt => opt.MapFrom(s => s.master_OKCInfo.OKCNO));
                    disokc.ForMember(p => p.OKCStart, opt => opt.MapFrom(s => s.master_OKCInfo.OKCStart));
                    disokc.ForMember(p => p.OKCEnd, opt => opt.MapFrom(s => s.master_OKCInfo.OKCEnd));
                    //经销商授权
                    var disaut = cfg.CreateMap<master_DistributorInfo, DistributorAuthorityResultDTO>();
                    //disaut.ForMember(p => p.Paylist, opt => opt.MapFrom(s => s.master_DistributorPayInfo));
                    //disaut.ForMember(p => p.ProductLineRegion, opt => opt.MapFrom(s => s.master_DistributorProductLineInfo));
                    //disaut.ForMember(p => p.Transportlist, opt => opt.MapFrom(s => s.master_DistributorTransport));
                    var dispay = cfg.CreateMap<master_DistributorPayInfo, DistributorPaymentResultDTO>();
                    dispay.ForMember(p => p.PayName, opt => opt.MapFrom(s => s.master_PaymentInfo.PayName));
                    var distra = cfg.CreateMap<master_DistributorTransport, DistributorTransportResultDTO>();
                    distra.ForMember(p => p.TransportName, opt => opt.MapFrom(s => s.master_TransportInfo.TransportName));
                    var disproline = cfg.CreateMap<master_DistributorProductLineInfo, DistributorProductLineResultDTO>();
                    disproline.ForMember(p => p.ProductLineName, opt => opt.MapFrom(s => s.master_ProductLine.ProductLineName));
                    disproline.ForMember(p => p.DepartName, opt => opt.MapFrom(s => s.master_ProductLine.master_DepartmentInfo.DepartName));
                    //disproline.ForMember(p => p.Region, opt => opt.MapFrom(s => s.master_DistributorRegionInfo));
                    var disprolineregion = cfg.CreateMap<master_DistributorRegionInfo, DistributorRegionResultDTO>();
                    disprolineregion.ForMember(p => p.RegionName, opt => opt.MapFrom(s => _OBJ.dict_RegionInfo.AsNoTracking().Where(p => p.RegionID == s.RegionID).Select(m => m.RegionName).FirstOrDefault()));
                    disprolineregion.ForMember(p => p.SmallAreaName, opt => opt.MapFrom(s => _OBJ.master_AreaInfo.AsNoTracking().Where(p => p.AreaID == s.DistrictID).Select(m => m.AreaName).FirstOrDefault()));
                    disprolineregion.ForMember(p => p.LargeAreaName, opt => opt.MapFrom(s => _OBJ.master_AreaInfo.AsNoTracking().Where(p => p.AreaID == s.AreaID).Select(m => m.AreaName).FirstOrDefault()));
                    disprolineregion.ForMember(p => p.DepartName, opt => opt.MapFrom(s => _OBJ.master_DepartmentInfo.AsNoTracking().Where(p => p.DepartID == s.DepartID).Select(m => m.DepartName).FirstOrDefault()));

                    //日志
                    var log = cfg.CreateMap<common_LogInfo, LogDTO>();
                    //提醒
                    var Warning = cfg.CreateMap<common_WarningInfo, WarningDTO>();
                    cfg.CreateMap<WarningDTO, common_WarningInfo>();
                });
            }

            return _OBJ;
        }
    }
}
