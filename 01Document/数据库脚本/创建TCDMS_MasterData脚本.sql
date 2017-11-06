if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.master_AreaAdmin') and o.name = 'FK_MASTECE_MASTER_U')
alter table dbo.master_AreaAdmin
   drop constraint FK_MASTECE_MASTER_U
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.master_AreaAdmin') and o.name = 'FK_MASTER_A_REFTER_A')
alter table dbo.master_AreaAdmin
   drop constraint FK_MASTER_A_REFTER_A
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.master_AreaInfo') and o.name = 'FK_MASTENCE_MASTER_D')
alter table dbo.master_AreaInfo
   drop constraint FK_MASTENCE_MASTER_D
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.master_AreaRegionInfo') and o.name = 'FK_MASTER_A_REFERENCE_DICT_REG')
alter table dbo.master_AreaRegionInfo
   drop constraint FK_MASTER_A_REFERENCE_DICT_REG
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.master_AreaRegionInfo') and o.name = 'FK_MASTER_A_REFERENCE_MASTER_A')
alter table dbo.master_AreaRegionInfo
   drop constraint FK_MASTER_A_REFERENCE_MASTER_A
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.master_CustomerApplyInfo') and o.name = 'FK_MASTER_C_REFERENCE_MASTER_DAPPLY')
alter table dbo.master_CustomerApplyInfo
   drop constraint FK_MASTER_C_REFERENCE_MASTER_DAPPLY
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.master_CustomerInfo') and o.name = 'FK_MASTER_C_REFERENCE_MASTER_DCUS')
alter table dbo.master_CustomerInfo
   drop constraint FK_MASTER_C_REFERENCE_MASTER_DCUS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.master_DistributorADInfo') and o.name = 'FK_MASSTER_D')
alter table dbo.master_DistributorADInfo
   drop constraint FK_MASSTER_D
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.master_DistributorADInfo') and o.name = 'FK_ME_MASTER_P')
alter table dbo.master_DistributorADInfo
   drop constraint FK_ME_MASTER_P
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.master_DistributorInfo') and o.name = 'FK_MASTER_D_REFERENCE_MASTER_D')
alter table dbo.master_DistributorInfo
   drop constraint FK_MASTER_D_REFERENCE_MASTER_D
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.master_DistributorInfo') and o.name = 'FK_MASTER_D_REFERENCE_MASTER_D1')
alter table dbo.master_DistributorInfo
   drop constraint FK_MASTER_D_REFERENCE_MASTER_D1
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.master_DistributorInfo') and o.name = 'FK_MASTER_D_REFERENCE_DICT_REG')
alter table dbo.master_DistributorInfo
   drop constraint FK_MASTER_D_REFERENCE_DICT_REG
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.master_DistributorOKCInfo') and o.name = 'FK_MASTER_D_REFERENCE_MASTER_DOKC')
alter table dbo.master_DistributorOKCInfo
   drop constraint FK_MASTER_D_REFERENCE_MASTER_DOKC
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.master_DistributorOKCInfo') and o.name = 'FK_MASERENE_MASTER_C')
alter table dbo.master_DistributorOKCInfo
   drop constraint FK_MASERENE_MASTER_C
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.master_DistributorOKCInfo') and o.name = 'FK_MASTER_D_REFERENCE_MASTER_OOKC')
alter table dbo.master_DistributorOKCInfo
   drop constraint FK_MASTER_D_REFERENCE_MASTER_OOKC
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.master_DistributorPayInfo') and o.name = 'FK_MASTER_D_REFERENCE_MASTER_DPAY')
alter table dbo.master_DistributorPayInfo
   drop constraint FK_MASTER_D_REFERENCE_MASTER_DPAY
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.master_DistributorPayInfo') and o.name = 'FK_MASTER_D_REFERENCE_MASTER_P')
alter table dbo.master_DistributorPayInfo
   drop constraint FK_MASTER_D_REFERENCE_MASTER_P
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.master_DistributorProductLineInfo') and o.name = 'FK_MASTER_D_REFERENCE_MASTER_DPROLINE')
alter table dbo.master_DistributorProductLineInfo
   drop constraint FK_MASTER_D_REFERENCE_MASTER_DPROLINE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.master_DistributorProductLineInfo') and o.name = 'FK_MASTER_D_REFERENCE_MASTER_PLINE')
alter table dbo.master_DistributorProductLineInfo
   drop constraint FK_MASTER_D_REFERENCE_MASTER_PLINE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.master_DistributorRegionInfo') and o.name = 'FK_MASTER_D_REFER_D')
alter table dbo.master_DistributorRegionInfo
   drop constraint FK_MASTER_D_REFER_D
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.master_DistributorTransport') and o.name = 'FK_MTER_D')
alter table dbo.master_DistributorTransport
   drop constraint FK_MTER_D
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.master_DistributorTransport') and o.name = 'FK_MASTASTER_T')
alter table dbo.master_DistributorTransport
   drop constraint FK_MASTASTER_T
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.master_DistributorUserInfo') and o.name = 'FK_MASTER_D_REFERENCE_MASTER_D2')
alter table dbo.master_DistributorUserInfo
   drop constraint FK_MASTER_D_REFERENCE_MASTER_D2
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.master_DistributorUserInfo') and o.name = 'FK_MASTER_D_REFERENCE_MASTER_U')
alter table dbo.master_DistributorUserInfo
   drop constraint FK_MASTER_D_REFERENCE_MASTER_U
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.master_FeedbackStat') and o.name = 'FK_MASTER_F_REFERENCE_MASTER_UFEEDBACK')
alter table dbo.master_FeedbackStat
   drop constraint FK_MASTER_F_REFERENCE_MASTER_UFEEDBACK
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.master_MessageStat') and o.name = 'FK_MASTER_M_REFERENCE_MASTER_USTAT')
alter table dbo.master_MessageStat
   drop constraint FK_MASTER_M_REFERENCE_MASTER_USTAT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.master_ProductInfo') and o.name = 'FK_MASTER_P_REFERENCE_MASTER_PLINE')
alter table dbo.master_ProductInfo
   drop constraint FK_MASTER_P_REFERENCE_MASTER_PLINE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.master_ProductInfo') and o.name = 'FK_MAS_ProductSmall')
alter table dbo.master_ProductInfo
   drop constraint FK_MAS_ProductSmall
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.master_ProductInfo') and o.name = 'FK_MASSTER_P')
alter table dbo.master_ProductInfo
   drop constraint FK_MASSTER_P
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.master_ProductLine') and o.name = 'FK_MASRENTER_D')
alter table dbo.master_ProductLine
   drop constraint FK_MASRENTER_D
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.master_ProductModel') and o.name = 'FK_MASTER_P_REFERENCE_MASTER_PMODEL')
alter table dbo.master_ProductModel
   drop constraint FK_MASTER_P_REFERENCE_MASTER_PMODEL
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.master_ProductOKCPriceInfo') and o.name = 'FK_MASTER_P_REFERENCE_MASTER_PProductOKCPriceInfo')
alter table dbo.master_ProductOKCPriceInfo
   drop constraint FK_MASTER_P_REFERENCE_MASTER_PProductOKCPriceInfo
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.master_ProductOKCPriceInfo') and o.name = 'FK_MASTER_P_REFERENCE_MASTER_O')
alter table dbo.master_ProductOKCPriceInfo
   drop constraint FK_MASTER_P_REFERENCE_MASTER_O
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.master_ProductPriceInfo') and o.name = 'FK_MASTER_P_REFERENCE_MASTER_PPRICE')
alter table dbo.master_ProductPriceInfo
   drop constraint FK_MASTER_P_REFERENCE_MASTER_PPRICE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.master_ProductSmallType') and o.name = 'FK_MASTER_P_REFERENCE_MASTER_P_SMALL')
alter table dbo.master_ProductSmallType
   drop constraint FK_MASTER_P_REFERENCE_MASTER_P_SMALL
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.master_RoleAuthority') and o.name = 'FK_MASTERENCER_R')
alter table dbo.master_RoleAuthority
   drop constraint FK_MASTERENCER_R
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.master_RoleAuthority') and o.name = 'FK_MAST_DICT_STR')
alter table dbo.master_RoleAuthority
   drop constraint FK_MAST_DICT_STR
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.master_UserCustomerAuthority') and o.name = 'FK_MASTCE_DICT_STR')
alter table dbo.master_UserCustomerAuthority
   drop constraint FK_MASTCE_DICT_STR
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.master_UserCustomerAuthority') and o.name = 'FK_MASTSTER_U')
alter table dbo.master_UserCustomerAuthority
   drop constraint FK_MASTSTER_U
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.master_UserInfo') and o.name = 'FK_MASTSTER_D')
alter table dbo.master_UserInfo
   drop constraint FK_MASTSTER_D
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.master_UserRoleInfo') and o.name = 'FK_MASTER_U_REFERENCE_MASTER_U')
alter table dbo.master_UserRoleInfo
   drop constraint FK_MASTER_U_REFERENCE_MASTER_U
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.master_UserRoleInfo') and o.name = 'FK_MASTER_U_REFERENCE_MASTER_R')
alter table dbo.master_UserRoleInfo
   drop constraint FK_MASTER_U_REFERENCE_MASTER_R
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.master_UsersStat') and o.name = 'FK_MASTER_U_REFERENCE_MASTER_USERSTAT')
alter table dbo.master_UsersStat
   drop constraint FK_MASTER_U_REFERENCE_MASTER_USERSTAT
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.vw_DepartToRegion')
            and   type = 'V')
   drop view dbo.vw_DepartToRegion
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.common_AttachFileInfo')
            and   type = 'U')
   drop table dbo.common_AttachFileInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.common_LogInfo')
            and   type = 'U')
   drop table dbo.common_LogInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.common_WarningInfo')
            and   type = 'U')
   drop table dbo.common_WarningInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.dict_ButtonInfo')
            and   type = 'U')
   drop table dbo.dict_ButtonInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.dict_RegionInfo')
            and   type = 'U')
   drop table dbo.dict_RegionInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.dict_Structure')
            and   type = 'U')
   drop table dbo.dict_Structure
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.master_AccountDateInfo')
            and   type = 'U')
   drop table dbo.master_AccountDateInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.master_AreaAdmin')
            and   type = 'U')
   drop table dbo.master_AreaAdmin
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.master_AreaInfo')
            and   type = 'U')
   drop table dbo.master_AreaInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.master_AreaRegionInfo')
            and   type = 'U')
   drop table dbo.master_AreaRegionInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.master_CustomerApplyInfo')
            and   type = 'U')
   drop table dbo.master_CustomerApplyInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.master_CustomerInfo')
            and   type = 'U')
   drop table dbo.master_CustomerInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.master_DepartmentInfo')
            and   type = 'U')
   drop table dbo.master_DepartmentInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.master_DistributorADInfo')
            and   type = 'U')
   drop table dbo.master_DistributorADInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.master_DistributorInfo')
            and   type = 'U')
   drop table dbo.master_DistributorInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.master_DistributorOKCInfo')
            and   type = 'U')
   drop table dbo.master_DistributorOKCInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.master_DistributorPayInfo')
            and   type = 'U')
   drop table dbo.master_DistributorPayInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.master_DistributorProductLineInfo')
            and   type = 'U')
   drop table dbo.master_DistributorProductLineInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.master_DistributorRegionInfo')
            and   type = 'U')
   drop table dbo.master_DistributorRegionInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.master_DistributorServiceType')
            and   type = 'U')
   drop table dbo.master_DistributorServiceType
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.master_DistributorTransport')
            and   type = 'U')
   drop table dbo.master_DistributorTransport
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.master_DistributorType')
            and   type = 'U')
   drop table dbo.master_DistributorType
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.master_DistributorUserInfo')
            and   type = 'U')
   drop table dbo.master_DistributorUserInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.master_FeedbackStat')
            and   type = 'U')
   drop table dbo.master_FeedbackStat
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.master_InstrumentType')
            and   type = 'U')
   drop table dbo.master_InstrumentType
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.master_MessageStat')
            and   type = 'U')
   drop table dbo.master_MessageStat
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.master_OKCInfo')
            and   type = 'U')
   drop table dbo.master_OKCInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.master_PaymentInfo')
            and   type = 'U')
   drop table dbo.master_PaymentInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.master_ProductInfo')
            and   type = 'U')
   drop table dbo.master_ProductInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.master_ProductLine')
            and   type = 'U')
   drop table dbo.master_ProductLine
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.master_ProductModel')
            and   type = 'U')
   drop table dbo.master_ProductModel
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.master_ProductOKCPriceInfo')
            and   type = 'U')
   drop table dbo.master_ProductOKCPriceInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.master_ProductPriceInfo')
            and   type = 'U')
   drop table dbo.master_ProductPriceInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.master_ProductSmallType')
            and   type = 'U')
   drop table dbo.master_ProductSmallType
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.master_ProductType')
            and   type = 'U')
   drop table dbo.master_ProductType
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.master_RateInfo')
            and   type = 'U')
   drop table dbo.master_RateInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.master_RoleAuthority')
            and   type = 'U')
   drop table dbo.master_RoleAuthority
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.master_RoleInfo')
            and   type = 'U')
   drop table dbo.master_RoleInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.master_TransportInfo')
            and   type = 'U')
   drop table dbo.master_TransportInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.master_UserCustomerAuthority')
            and   type = 'U')
   drop table dbo.master_UserCustomerAuthority
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.master_UserInfo')
            and   type = 'U')
   drop table dbo.master_UserInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.master_UserRoleInfo')
            and   type = 'U')
   drop table dbo.master_UserRoleInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.master_UsersStat')
            and   type = 'U')
   drop table dbo.master_UsersStat
go

/*==============================================================*/
/* Table: common_AttachFileInfo                                 */
/*==============================================================*/
create table dbo.common_AttachFileInfo (
   AttachFileID         uniqueidentifier     not null,
   AttachFileName       varchar(40)          null,
   AttachFileSrcName    nvarchar(100)        null,
   AttachFileExtentionName varchar(20)          null,
   BelongModule         smallint             null,
   BelongModulePrimaryKey varchar(40)          null,
   CreateUser           nvarchar(50)         null,
   CreateTime           datetime             null,
   ModifyUser           nvarchar(50)         null,
   ModifyTime           datetime             null,
   constraint PK_COMMON_ATTACHFILEINFO primary key (AttachFileID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.common_AttachFileInfo') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'common_AttachFileInfo' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '所有附件信息', 
   'user', 'dbo', 'table', 'common_AttachFileInfo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.common_AttachFileInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'BelongModule')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'common_AttachFileInfo', 'column', 'BelongModule'

end


execute sp_addextendedproperty 'MS_Description', 
   '1:反馈',
   'user', 'dbo', 'table', 'common_AttachFileInfo', 'column', 'BelongModule'
go

/*==============================================================*/
/* Table: common_LogInfo                                        */
/*==============================================================*/
create table dbo.common_LogInfo (
   LogIndex             bigint               identity,
   BelongModel          nvarchar(100)        null,
   BelongFunc           nvarchar(100)        null,
   LogDetails           nvarchar(1000)       null,
   LogDate              Datetime             null,
   OpratorName          nvarchar(50)         null,
   constraint PK_COMMON_LOGINFO primary key (LogIndex)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.common_LogInfo') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'common_LogInfo' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '详细记录每个模块的日志信息', 
   'user', 'dbo', 'table', 'common_LogInfo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.common_LogInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LogIndex')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'common_LogInfo', 'column', 'LogIndex'

end


execute sp_addextendedproperty 'MS_Description', 
   '日志流水号',
   'user', 'dbo', 'table', 'common_LogInfo', 'column', 'LogIndex'
go

/*==============================================================*/
/* Table: common_WarningInfo                                    */
/*==============================================================*/
create table dbo.common_WarningInfo (
   WarningID            uniqueidentifier     not null,
   BelongModule         nvarchar(100)        null,
   MappingID            uniqueidentifier     null,
   WarningInfo          nvarchar(1000)       null,
   UserID               int                  null,
   constraint PK_COMMON_WARNINGINFO primary key (WarningID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.common_WarningInfo') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'common_WarningInfo' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '提醒信息，记录每个用户的提醒信息，查看后即删除', 
   'user', 'dbo', 'table', 'common_WarningInfo'
go

/*==============================================================*/
/* Table: dict_ButtonInfo                                       */
/*==============================================================*/
create table dbo.dict_ButtonInfo (
   ButtonID             int                  not null,
   ButtonName           varchar(50)          null,
   ButtonValue          nvarchar(50)         null,
   ButtonJavascript     varchar(1500)        null,
   IsVisible            bit                  null default 1,
   IconName             varchar(50)          null,
   IndexCode            int                  null,
   constraint PK_DICT_BUTTONINFO primary key (ButtonID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.dict_ButtonInfo') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'dict_ButtonInfo' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '功能按钮信息', 
   'user', 'dbo', 'table', 'dict_ButtonInfo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.dict_ButtonInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ButtonID')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'dict_ButtonInfo', 'column', 'ButtonID'

end


execute sp_addextendedproperty 'MS_Description', 
   '以二进制依次显示，不可删除，仅新增和修改',
   'user', 'dbo', 'table', 'dict_ButtonInfo', 'column', 'ButtonID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.dict_ButtonInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IsVisible')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'dict_ButtonInfo', 'column', 'IsVisible'

end


execute sp_addextendedproperty 'MS_Description', 
   '是否显示',
   'user', 'dbo', 'table', 'dict_ButtonInfo', 'column', 'IsVisible'
go

/*==============================================================*/
/* Table: dict_RegionInfo                                       */
/*==============================================================*/
create table dbo.dict_RegionInfo (
   RegionID             int                  identity,
   RegionPID            int                  null,
   RegionName           nvarchar(50)         null,
   RegionCode           varchar(20)          null,
   RegionLevel          int                  null,
   CreateUser           nvarchar(50)         null,
   CreateTime           datetime             null,
   ModifyUser           nvarchar(50)         null,
   ModifyTime           datetime             null,
   constraint PK_DICT_REGIONINFO primary key (RegionID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.dict_RegionInfo') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'dict_RegionInfo' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '行政区域信息', 
   'user', 'dbo', 'table', 'dict_RegionInfo'
go

/*==============================================================*/
/* Table: dict_Structure                                        */
/*==============================================================*/
create table dbo.dict_Structure (
   StructureID          varchar(24)          not null,
   ParentStructureID    varchar(24)          null,
   StructureName        nvarchar(100)        null,
   IsVisible            bit                  null,
   IndexCode            int                  null,
   URL                  varchar(200)         null,
   BelongButton         int                  null,
   DesImage             varchar(50)          null,
   Description          nvarchar(200)        null,
   constraint PK_DICT_STRUCTURE primary key (StructureID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.dict_Structure') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'dict_Structure' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '系统结构信息', 
   'user', 'dbo', 'table', 'dict_Structure'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.dict_Structure')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'StructureID')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'dict_Structure', 'column', 'StructureID'

end


execute sp_addextendedproperty 'MS_Description', 
   '形如001或001001',
   'user', 'dbo', 'table', 'dict_Structure', 'column', 'StructureID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.dict_Structure')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IndexCode')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'dict_Structure', 'column', 'IndexCode'

end


execute sp_addextendedproperty 'MS_Description', 
   '仅用来显示排序使用',
   'user', 'dbo', 'table', 'dict_Structure', 'column', 'IndexCode'
go

/*==============================================================*/
/* Table: master_AccountDateInfo                                */
/*==============================================================*/
create table dbo.master_AccountDateInfo (
   AccountDateID        int                  identity,
   AccountDateName      nvarchar(50)         null,
   AccountDateYear      smallint             null,
   AccountDatePlace     nvarchar(50)         null,
   AccountDateBelongModel nvarchar(100)        null,
   MonthDate            datetime             null,
   FebDate              datetime             null,
   MarchDate            datetime             null,
   AprilDate            datetime             null,
   MayDate              datetime             null,
   JuneDate             datetime             null,
   JulyDate             datetime             null,
   AugustDate           datetime             null,
   SepDate              datetime             null,
   OctDate              datetime             null,
   NovDate              datetime             null,
   DecDate              datetime             null,
   CreateUser           nvarchar(50)         null,
   CreateTime           datetime             null,
   ModifyUser           nvarchar(50)         null,
   ModifyTime           datetime             null,
   constraint PK_MASTER_ACCOUNTDATEINFO primary key (AccountDateID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.master_AccountDateInfo') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'master_AccountDateInfo' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '关账日信息', 
   'user', 'dbo', 'table', 'master_AccountDateInfo'
go

/*==============================================================*/
/* Table: master_AreaAdmin                                      */
/*==============================================================*/
create table dbo.master_AreaAdmin (
   UserID               int                  not null,
   AreaID               int                  not null,
   constraint PK_MASTER_AREAADMIN primary key (UserID, AreaID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.master_AreaAdmin') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'master_AreaAdmin' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '区域管理员', 
   'user', 'dbo', 'table', 'master_AreaAdmin'
go

/*==============================================================*/
/* Table: master_AreaInfo                                       */
/*==============================================================*/
create table dbo.master_AreaInfo (
   AreaID               int                  identity,
   DepartID             int                  null,
   AreaPID              int                  null,
   AreaName             nvarchar(50)         null,
   AreaPath             varchar(100)         null,
   CreateUser           nvarchar(50)         null,
   CreateTime           datetime             null,
   ModifyUser           nvarchar(50)         null,
   ModifyTime           datetime             null,
   constraint PK_MASTER_AREAINFO primary key (AreaID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.master_AreaInfo') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'master_AreaInfo' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '大区小区信息', 
   'user', 'dbo', 'table', 'master_AreaInfo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.master_AreaInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DepartID')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'master_AreaInfo', 'column', 'DepartID'

end


execute sp_addextendedproperty 'MS_Description', 
   '部门ID',
   'user', 'dbo', 'table', 'master_AreaInfo', 'column', 'DepartID'
go

/*==============================================================*/
/* Table: master_AreaRegionInfo                                 */
/*==============================================================*/
create table dbo.master_AreaRegionInfo (
   AreaRegionID         int                  identity,
   AreaID               int                  null,
   RegionID             int                  null,
   constraint PK_MASTER_AREAREGIONINFO primary key (AreaRegionID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.master_AreaRegionInfo') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'master_AreaRegionInfo' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '区域省份信息', 
   'user', 'dbo', 'table', 'master_AreaRegionInfo'
go

/*==============================================================*/
/* Table: master_CustomerApplyInfo                              */
/*==============================================================*/
create table dbo.master_CustomerApplyInfo (
   CustomerApplyID      uniqueidentifier     not null,
   DistributorID        uniqueidentifier     null,
   CustomerName         nvarchar(100)        null,
   Province             nvarchar(50)         null,
   City                 nvarchar(50)         null,
   Country              nvarchar(50)         null,
   ApplyTime            datetime             null,
   Status               smallint             null,
   AuditTime            datetime             null,
   Auditor              nvarchar(50)         null,
   AuditReason          nvarchar(3000)       null,
   CreateUser           nvarchar(50)         null,
   CreateTime           datetime             null,
   ModifyUser           nvarchar(50)         null,
   ModifyTime           datetime             null,
   constraint PK_MASTER_CUSTOMERAPPLYINFO primary key (CustomerApplyID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.master_CustomerApplyInfo') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'master_CustomerApplyInfo' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '客户申请信息', 
   'user', 'dbo', 'table', 'master_CustomerApplyInfo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.master_CustomerApplyInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CustomerApplyID')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'master_CustomerApplyInfo', 'column', 'CustomerApplyID'

end


execute sp_addextendedproperty 'MS_Description', 
   '客户系统ID',
   'user', 'dbo', 'table', 'master_CustomerApplyInfo', 'column', 'CustomerApplyID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.master_CustomerApplyInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Status')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'master_CustomerApplyInfo', 'column', 'Status'

end


execute sp_addextendedproperty 'MS_Description', 
   '0：待审核 1：审核失败 2：审核通过',
   'user', 'dbo', 'table', 'master_CustomerApplyInfo', 'column', 'Status'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.master_CustomerApplyInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AuditReason')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'master_CustomerApplyInfo', 'column', 'AuditReason'

end


execute sp_addextendedproperty 'MS_Description', 
   '审核失败原因',
   'user', 'dbo', 'table', 'master_CustomerApplyInfo', 'column', 'AuditReason'
go

/*==============================================================*/
/* Table: master_CustomerInfo                                   */
/*==============================================================*/
create table dbo.master_CustomerInfo (
   CustomerID           uniqueidentifier     not null,
   DistributorID        uniqueidentifier     null,
   CustomerName         nvarchar(100)        null,
   Province             nvarchar(50)         null,
   City                 nvarchar(50)         null,
   Country              nvarchar(50)         null,
   OracleNO             varchar(30)          null,
   NoActiveTime         datetime             null,
   NoActiveReason       nvarchar(3000)       null,
   OracleName           varchar(50)          null,
   XSWNO                varchar(30)          null,
   IsActive             bit                  null,
   CreateUser           nvarchar(50)         null,
   CreateTime           datetime             null,
   ModifyUser           nvarchar(50)         null,
   ModifyTime           datetime             null,
   constraint PK_MASTER_CUSTOMERINFO primary key (CustomerID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.master_CustomerInfo') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'master_CustomerInfo' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '客户信息', 
   'user', 'dbo', 'table', 'master_CustomerInfo'
go

/*==============================================================*/
/* Table: master_DepartmentInfo                                 */
/*==============================================================*/
create table dbo.master_DepartmentInfo (
   DepartID             int                  identity,
   DepartParentID       int                  null,
   DepartPath           varchar(50)          null,
   DepartName           nvarchar(100)        null,
   DepartIntroduction   nvarchar(300)        null,
   CreateUser           nvarchar(50)         null,
   CreateTime           datetime             null,
   ModifyUser           nvarchar(50)         null,
   ModifyTime           datetime             null,
   constraint PK_MASTER_DEPARTMENTINFO primary key (DepartID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.master_DepartmentInfo') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'master_DepartmentInfo' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '部门信息', 
   'user', 'dbo', 'table', 'master_DepartmentInfo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.master_DepartmentInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DepartID')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'master_DepartmentInfo', 'column', 'DepartID'

end


execute sp_addextendedproperty 'MS_Description', 
   '部门ID',
   'user', 'dbo', 'table', 'master_DepartmentInfo', 'column', 'DepartID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.master_DepartmentInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DepartPath')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'master_DepartmentInfo', 'column', 'DepartPath'

end


execute sp_addextendedproperty 'MS_Description', 
   '形如：/1/',
   'user', 'dbo', 'table', 'master_DepartmentInfo', 'column', 'DepartPath'
go

/*==============================================================*/
/* Table: master_DistributorADInfo                              */
/*==============================================================*/
create table dbo.master_DistributorADInfo (
   AdAuhtorityID        int                  identity,
   DistributorID        uniqueidentifier     null,
   ProductLineID        int                  null,
   CreateUser           nvarchar(50)         null,
   CreateTime           datetime             null,
   ModifyUser           nvarchar(50)         null,
   ModifyTime           datetime             null,
   constraint PK_MASTER_DISTRIBUTORADINFO primary key (AdAuhtorityID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.master_DistributorADInfo') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'master_DistributorADInfo' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '经销商公告授权', 
   'user', 'dbo', 'table', 'master_DistributorADInfo'
go

/*==============================================================*/
/* Table: master_DistributorInfo                                */
/*==============================================================*/
create table dbo.master_DistributorInfo (
   DistributorID        uniqueidentifier     not null,
   DistributorServiceTypeID int                  null,
   DistributorTypeID    int                  null,
   RegionID             int                  null,
   DistributorCode      varchar(50)          null,
   DistributorName      nvarchar(100)        null,
   IsActive             bit                  null,
   NoActiveTime         datetime             null,
   NoActiveReason       nvarchar(3000)       null,
   InvoiceCode          varchar(50)          null,
   DeliverCode          varchar(50)          null,
   CSRNameReagent       nvarchar(100)        null,
   CSRNameD             nvarchar(100)        null,
   IsOrderGoods         bit                  null,
   CSRNameB             nvarchar(100)        null,
   Office               nvarchar(100)        null,
   CreateUser           nvarchar(50)         null,
   CreateTime           datetime             null,
   ModifyUser           nvarchar(50)         null,
   ModifyTime           datetime             null,
   constraint PK_MASTER_DISTRIBUTORINFO primary key (DistributorID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.master_DistributorInfo') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'master_DistributorInfo' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '经销商信息', 
   'user', 'dbo', 'table', 'master_DistributorInfo'
go

/*==============================================================*/
/* Table: master_DistributorOKCInfo                             */
/*==============================================================*/
create table dbo.master_DistributorOKCInfo (
   DistributorOKCID     int                  identity,
   DistributorID        uniqueidentifier     null,
   OKCID                int                  null,
   CustomerID           uniqueidentifier     null,
   constraint PK_MASTER_DISTRIBUTOROKCINFO primary key (DistributorOKCID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.master_DistributorOKCInfo') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'master_DistributorOKCInfo' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '经销商OKC信息', 
   'user', 'dbo', 'table', 'master_DistributorOKCInfo'
go

/*==============================================================*/
/* Table: master_DistributorPayInfo                             */
/*==============================================================*/
create table dbo.master_DistributorPayInfo (
   DistributorPayID     int                  identity,
   DistributorID        uniqueidentifier     null,
   PayID                int                  null,
   CreateUser           nvarchar(50)         null,
   CreateTime           datetime             null,
   ModifyUser           nvarchar(50)         null,
   ModifyTime           datetime             null,
   constraint PK_MASTER_DISTRIBUTORPAYINFO primary key (DistributorPayID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.master_DistributorPayInfo') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'master_DistributorPayInfo' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '经销商付款条款', 
   'user', 'dbo', 'table', 'master_DistributorPayInfo'
go

/*==============================================================*/
/* Table: master_DistributorProductLineInfo                     */
/*==============================================================*/
create table dbo.master_DistributorProductLineInfo (
   DistributorProductLineID int                  identity,
   DistributorID        uniqueidentifier     null,
   ProductLineID        int                  null,
   CreateUser           nvarchar(50)         null,
   CreateTime           datetime             null,
   ModifyUser           nvarchar(50)         null,
   ModifyTime           datetime             null,
   constraint PK_MASTER_DISTRIBUTORPRODUCTLI primary key (DistributorProductLineID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.master_DistributorProductLineInfo') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'master_DistributorProductLineInfo' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '经销商授权产品线信息', 
   'user', 'dbo', 'table', 'master_DistributorProductLineInfo'
go

/*==============================================================*/
/* Table: master_DistributorRegionInfo                          */
/*==============================================================*/
create table dbo.master_DistributorRegionInfo (
   DistributorRegionID  int                  identity,
   DistributorProductLineID int                  null,
   DepartID             int                  null,
   AreaID               int                  null,
   DistrictID           int                  null,
   RegionID             int                  null,
   CreateUser           nvarchar(50)         null,
   CreateTime           datetime             null,
   ModifyUser           nvarchar(50)         null,
   ModifyTime           datetime             null,
   constraint PK_MASTER_DISTRIBUTORREGIONINF primary key (DistributorRegionID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.master_DistributorRegionInfo') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'master_DistributorRegionInfo' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '经销商授权区域信息', 
   'user', 'dbo', 'table', 'master_DistributorRegionInfo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.master_DistributorRegionInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DepartID')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'master_DistributorRegionInfo', 'column', 'DepartID'

end


execute sp_addextendedproperty 'MS_Description', 
   '部门ID',
   'user', 'dbo', 'table', 'master_DistributorRegionInfo', 'column', 'DepartID'
go

/*==============================================================*/
/* Table: master_DistributorServiceType                         */
/*==============================================================*/
create table dbo.master_DistributorServiceType (
   DistributorServiceTypeID int                  identity,
   DistributorServiceTypeName nvarchar(50)         null,
   CreateUser           nvarchar(50)         null,
   CreateTime           datetime             null,
   ModifyUser           nvarchar(50)         null,
   ModifyTime           datetime             null,
   constraint PK_MASTER_DISTRIBUTORSERVICETY primary key (DistributorServiceTypeID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.master_DistributorServiceType') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'master_DistributorServiceType' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '经销商服务类型', 
   'user', 'dbo', 'table', 'master_DistributorServiceType'
go

/*==============================================================*/
/* Table: master_DistributorTransport                           */
/*==============================================================*/
create table dbo.master_DistributorTransport (
   DistributorTransportID int                  identity,
   DistributorID        uniqueidentifier     null,
   TransportID          int                  null,
   CreateUser           nvarchar(50)         null,
   CreateTime           datetime             null,
   ModifyUser           nvarchar(50)         null,
   ModifyTime           datetime             null,
   constraint PK_MASTER_DISTRIBUTORTRANSPORT primary key (DistributorTransportID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.master_DistributorTransport') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'master_DistributorTransport' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '经销商运输方式', 
   'user', 'dbo', 'table', 'master_DistributorTransport'
go

/*==============================================================*/
/* Table: master_DistributorType                                */
/*==============================================================*/
create table dbo.master_DistributorType (
   DistributorTypeID    int                  identity,
   DistributorTypeName  nvarchar(50)         null,
   CreateUser           nvarchar(50)         null,
   CreateTime           datetime             null,
   ModifyUser           nvarchar(50)         null,
   ModifyTime           datetime             null,
   constraint PK_MASTER_DISTRIBUTORTYPE primary key (DistributorTypeID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.master_DistributorType') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'master_DistributorType' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '经销商类别', 
   'user', 'dbo', 'table', 'master_DistributorType'
go

/*==============================================================*/
/* Table: master_DistributorUserInfo                            */
/*==============================================================*/
create table dbo.master_DistributorUserInfo (
   DistributorID        uniqueidentifier     not null,
   UserID               int                  not null,
   constraint PK_MASTER_DISTRIBUTORUSERINFO primary key (DistributorID, UserID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.master_DistributorUserInfo') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'master_DistributorUserInfo' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '经销商用户信息', 
   'user', 'dbo', 'table', 'master_DistributorUserInfo'
go

/*==============================================================*/
/* Table: master_FeedbackStat                                   */
/*==============================================================*/
create table dbo.master_FeedbackStat (
   FeedbackStatID       int                  identity,
   UserID               int                  null,
   FeedbackDate         datetime             null,
   FeedbackStaus        smallint             null,
   FeedbackSystem       nvarchar(100)        null,
   FeedbackModel        nvarchar(100)        null,
   FeedbackContent      nvarchar(3000)       null,
   DealUser             nvarchar(50)         null,
   DealDatetime         datetime             null,
   constraint PK_MASTER_FEEDBACKSTAT primary key (FeedbackStatID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.master_FeedbackStat') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'master_FeedbackStat' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '反馈统计信息', 
   'user', 'dbo', 'table', 'master_FeedbackStat'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.master_FeedbackStat')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FeedbackStaus')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'master_FeedbackStat', 'column', 'FeedbackStaus'

end


execute sp_addextendedproperty 'MS_Description', 
   '0:待处理 1:已处理',
   'user', 'dbo', 'table', 'master_FeedbackStat', 'column', 'FeedbackStaus'
go

/*==============================================================*/
/* Table: master_InstrumentType                                 */
/*==============================================================*/
create table dbo.master_InstrumentType (
   InstrumentTypeID     int                  identity,
   InstrumentTypeName   nvarchar(50)         null,
   CreateUser           nvarchar(50)         null,
   CreateTime           datetime             null,
   ModifyUser           nvarchar(50)         null,
   ModifyTime           datetime             null,
   constraint PK_MASTER_INSTRUMENTTYPE primary key (InstrumentTypeID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.master_InstrumentType') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'master_InstrumentType' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '仪器类型', 
   'user', 'dbo', 'table', 'master_InstrumentType'
go

/*==============================================================*/
/* Table: master_MessageStat                                    */
/*==============================================================*/
create table dbo.master_MessageStat (
   MessageStatID        int                  identity,
   UserID               int                  null,
   MessageType          smallint             null,
   SendTime             datetime             null,
   constraint PK_MASTER_MESSAGESTAT primary key (MessageStatID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.master_MessageStat') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'master_MessageStat' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '短信统计信息', 
   'user', 'dbo', 'table', 'master_MessageStat'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.master_MessageStat')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MessageType')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'master_MessageStat', 'column', 'MessageType'

end


execute sp_addextendedproperty 'MS_Description', 
   '0:登陆短信 1:用户申请通知 ',
   'user', 'dbo', 'table', 'master_MessageStat', 'column', 'MessageType'
go

/*==============================================================*/
/* Table: master_OKCInfo                                        */
/*==============================================================*/
create table dbo.master_OKCInfo (
   OKCID                int                  identity,
   OKCNO                nvarchar(30)         null,
   OKCStart             datetime             null,
   OKCEnd               datetime             null,
   CreateUser           nvarchar(50)         null,
   CreateTime           datetime             null,
   ModifyUser           nvarchar(50)         null,
   ModifyTime           datetime             null,
   constraint PK_MASTER_OKCINFO primary key (OKCID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.master_OKCInfo') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'master_OKCInfo' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '产品OKC信息', 
   'user', 'dbo', 'table', 'master_OKCInfo'
go

/*==============================================================*/
/* Table: master_PaymentInfo                                    */
/*==============================================================*/
create table dbo.master_PaymentInfo (
   PayID                int                  identity,
   PayName              nvarchar(30)         null,
   OracleName           varchar(50)          null,
   PayStartTime         datetime             null,
   PayEndTime           datetime             null,
   PayStatus            bit                  null,
   CreateUser           nvarchar(50)         null,
   CreateTime           datetime             null,
   ModifyUser           nvarchar(50)         null,
   ModifyTime           datetime             null,
   constraint PK_MASTER_PAYMENTINFO primary key (PayID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.master_PaymentInfo') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'master_PaymentInfo' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '付款条款', 
   'user', 'dbo', 'table', 'master_PaymentInfo'
go

/*==============================================================*/
/* Table: master_ProductInfo                                    */
/*==============================================================*/
create table dbo.master_ProductInfo (
   ProductID            uniqueidentifier     not null,
   ProductLineID        int                  null,
   ProductSmallTypeID   int                  null,
   ProductTypeID        int                  null,
   ArtNo                nvarchar(50)         null,
   ReagentProject       nvarchar(30)         null,
   ReagentSize          varchar(50)          null,
   ReagentTest          nvarchar(30)         null,
   RemarkDes            nvarchar(300)        null,
   Is3C                 bit                  null,
   IsActive             bit                  null,
   ProductName          nvarchar(200)        null,
   IsMaintenance        bit                  null,
   StopReason           nvarchar(500)        null,
   CreateUser           nvarchar(50)         null,
   CreateTime           datetime             null,
   ModifyUser           nvarchar(50)         null,
   ModifyTime           datetime             null,
   constraint PK_MASTER_PRODUCTINFO primary key (ProductID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.master_ProductInfo') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'master_ProductInfo' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '产品信息', 
   'user', 'dbo', 'table', 'master_ProductInfo'
go

/*==============================================================*/
/* Table: master_ProductLine                                    */
/*==============================================================*/
create table dbo.master_ProductLine (
   ProductLineID        int                  identity,
   DepartID             int                  null,
   ProductLineName      nvarchar(50)         null,
   IsActive             bit                  null,
   ProductLineNameAB    varchar(20)          null,
   CreateUser           nvarchar(50)         null,
   CreateTime           datetime             null,
   ModifyUser           nvarchar(50)         null,
   ModifyTime           datetime             null,
   constraint PK_MASTER_PRODUCTLINE primary key (ProductLineID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.master_ProductLine') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'master_ProductLine' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '产品线', 
   'user', 'dbo', 'table', 'master_ProductLine'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.master_ProductLine')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DepartID')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'master_ProductLine', 'column', 'DepartID'

end


execute sp_addextendedproperty 'MS_Description', 
   '部门ID',
   'user', 'dbo', 'table', 'master_ProductLine', 'column', 'DepartID'
go

/*==============================================================*/
/* Table: master_ProductModel                                   */
/*==============================================================*/
create table dbo.master_ProductModel (
   ProductModelID       int                  identity,
   ProductLineID        int                  null,
   ProductModelName     nvarchar(50)         null,
   IsActive             bit                  null,
   CreateUser           nvarchar(50)         null,
   CreateTime           datetime             null,
   ModifyUser           nvarchar(50)         null,
   ModifyTime           datetime             null,
   constraint PK_MASTER_PRODUCTMODEL primary key (ProductModelID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.master_ProductModel') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'master_ProductModel' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '产品型号(仪器型号)', 
   'user', 'dbo', 'table', 'master_ProductModel'
go

/*==============================================================*/
/* Table: master_ProductOKCPriceInfo                            */
/*==============================================================*/
create table dbo.master_ProductOKCPriceInfo (
   ProductOKCPriceInfoID int                  identity,
   ProductID            uniqueidentifier     null,
   OKCID                int                  null,
   ProductOKCPrice      decimal(20,10)       null,
   CreateUser           nvarchar(50)         null,
   CreateTime           datetime             null,
   ModifyUser           nvarchar(50)         null,
   ModifyTime           datetime             null,
   constraint PK_MASTER_PRODUCTOKCPRICEINFO primary key (ProductOKCPriceInfoID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.master_ProductOKCPriceInfo') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'master_ProductOKCPriceInfo' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '产品特价信息', 
   'user', 'dbo', 'table', 'master_ProductOKCPriceInfo'
go

/*==============================================================*/
/* Table: master_ProductPriceInfo                               */
/*==============================================================*/
create table dbo.master_ProductPriceInfo (
   ProductPriceID       int                  identity,
   ProductID            uniqueidentifier     null,
   DNPPrice             decimal(20,10)       null,
   DNPPriceStart        datetime             null,
   DNPPriceEnd          datetime             null,
   CreateUser           nvarchar(50)         null,
   CreateTime           datetime             null,
   ModifyUser           nvarchar(50)         null,
   ModifyTime           datetime             null,
   constraint PK_MASTER_PRODUCTPRICEINFO primary key (ProductPriceID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.master_ProductPriceInfo') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'master_ProductPriceInfo' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '产品价格信息', 
   'user', 'dbo', 'table', 'master_ProductPriceInfo'
go

/*==============================================================*/
/* Table: master_ProductSmallType                               */
/*==============================================================*/
create table dbo.master_ProductSmallType (
   ProductSmallTypeID   int                  identity,
   ProductLineID        int                  null,
   ProductSmallTypeName nvarchar(50)         null,
   IsActive             bit                  null,
   CreateUser           nvarchar(50)         null,
   CreateTime           datetime             null,
   ModifyUser           nvarchar(50)         null,
   ModifyTime           datetime             null,
   constraint PK_MASTER_PRODUCTSMALLTYPE primary key (ProductSmallTypeID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.master_ProductSmallType') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'master_ProductSmallType' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '产品小类', 
   'user', 'dbo', 'table', 'master_ProductSmallType'
go

/*==============================================================*/
/* Table: master_ProductType                                    */
/*==============================================================*/
create table dbo.master_ProductType (
   ProductTypeID        int                  identity,
   ProductTypeName      nvarchar(50)         null,
   OracleName           varchar(50)          null,
   ProductTypeAB        varchar(20)          null,
   CreateUser           nvarchar(50)         null,
   CreateTime           datetime             null,
   ModifyUser           nvarchar(50)         null,
   ModifyTime           datetime             null,
   constraint PK_MASTER_PRODUCTTYPE primary key (ProductTypeID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.master_ProductType') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'master_ProductType' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '产品类型', 
   'user', 'dbo', 'table', 'master_ProductType'
go

/*==============================================================*/
/* Table: master_RateInfo                                       */
/*==============================================================*/
create table dbo.master_RateInfo (
   RateID               int                  identity,
   Currency             varchar(20)          null,
   RateCode             varchar(20)          null,
   RateYear             smallint             null,
   RateBudget           decimal(20,10)       null,
   MonthRate            decimal(20,10)       null,
   FebRate              decimal(20,10)       null,
   MarchRate            decimal(20,10)       null,
   AprilRate            decimal(20,10)       null,
   MayRate              decimal(20,10)       null,
   JuneRate             decimal(20,10)       null,
   JulyRate             decimal(20,10)       null,
   AugustRate           decimal(20,10)       null,
   SepRate              decimal(20,10)       null,
   OctRate              decimal(20,10)       null,
   NovRate              decimal(20,10)       null,
   DecRate              decimal(20,10)       null,
   CreateUser           nvarchar(50)         null,
   CreateTime           datetime             null,
   ModifyUser           nvarchar(50)         null,
   ModifyTime           datetime             null,
   constraint PK_MASTER_RATEINFO primary key (RateID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.master_RateInfo') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'master_RateInfo' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '汇率信息', 
   'user', 'dbo', 'table', 'master_RateInfo'
go

/*==============================================================*/
/* Table: master_RoleAuthority                                  */
/*==============================================================*/
create table dbo.master_RoleAuthority (
   RoleAuthorityID      int                  identity,
   RoleID               int                  null,
   StructureID          varchar(24)          null,
   RoleButtonAuthority  int                  null,
   constraint PK_MASTER_ROLEAUTHORITY primary key (RoleAuthorityID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.master_RoleAuthority') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'master_RoleAuthority' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '角色权限', 
   'user', 'dbo', 'table', 'master_RoleAuthority'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.master_RoleAuthority')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'StructureID')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'master_RoleAuthority', 'column', 'StructureID'

end


execute sp_addextendedproperty 'MS_Description', 
   '形如001或001001',
   'user', 'dbo', 'table', 'master_RoleAuthority', 'column', 'StructureID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.master_RoleAuthority')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'RoleButtonAuthority')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'master_RoleAuthority', 'column', 'RoleButtonAuthority'

end


execute sp_addextendedproperty 'MS_Description', 
   '二进制权限',
   'user', 'dbo', 'table', 'master_RoleAuthority', 'column', 'RoleButtonAuthority'
go

/*==============================================================*/
/* Table: master_RoleInfo                                       */
/*==============================================================*/
create table dbo.master_RoleInfo (
   RoleID               int                  identity,
   RoleName             nvarchar(100)        null,
   RoleIntroduction     nvarchar(100)        null,
   IsActive             bit                  null,
   RoleType             smallint             null,
   CreateUser           nvarchar(50)         null,
   CreateTime           datetime             null,
   ModifyUser           nvarchar(50)         null,
   ModifyTime           datetime             null,
   constraint PK_MASTER_ROLEINFO primary key (RoleID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.master_RoleInfo') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'master_RoleInfo' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '角色信息', 
   'user', 'dbo', 'table', 'master_RoleInfo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.master_RoleInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IsActive')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'master_RoleInfo', 'column', 'IsActive'

end


execute sp_addextendedproperty 'MS_Description', 
   '1:启用 0:停用',
   'user', 'dbo', 'table', 'master_RoleInfo', 'column', 'IsActive'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.master_RoleInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'RoleType')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'master_RoleInfo', 'column', 'RoleType'

end


execute sp_addextendedproperty 'MS_Description', 
   '0:系统管理员1:贝克曼 2：经销商 ',
   'user', 'dbo', 'table', 'master_RoleInfo', 'column', 'RoleType'
go

/*==============================================================*/
/* Table: master_TransportInfo                                  */
/*==============================================================*/
create table dbo.master_TransportInfo (
   TransportID          int                  identity,
   TransportStatus      bit                  null,
   TransportName        nvarchar(30)         null,
   OrderType            nvarchar(30)         null,
   CreateUser           nvarchar(50)         null,
   CreateTime           datetime             null,
   ModifyUser           nvarchar(50)         null,
   ModifyTime           datetime             null,
   constraint PK_MASTER_TRANSPORTINFO primary key (TransportID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.master_TransportInfo') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'master_TransportInfo' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '运输方式', 
   'user', 'dbo', 'table', 'master_TransportInfo'
go

/*==============================================================*/
/* Table: master_UserCustomerAuthority                          */
/*==============================================================*/
create table dbo.master_UserCustomerAuthority (
   UserCustomerAuthorityID int                  identity,
   StructureID          varchar(24)          null,
   UserID               int                  null,
   UserButtonAuthority  int                  null,
   constraint PK_MASTER_USERCUSTOMERAUTHORIT primary key (UserCustomerAuthorityID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.master_UserCustomerAuthority') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'master_UserCustomerAuthority' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '用户自定义权限', 
   'user', 'dbo', 'table', 'master_UserCustomerAuthority'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.master_UserCustomerAuthority')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'StructureID')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'master_UserCustomerAuthority', 'column', 'StructureID'

end


execute sp_addextendedproperty 'MS_Description', 
   '形如001或001001',
   'user', 'dbo', 'table', 'master_UserCustomerAuthority', 'column', 'StructureID'
go

/*==============================================================*/
/* Table: master_UserInfo                                       */
/*==============================================================*/
create table dbo.master_UserInfo (
   UserID               int                  identity,
   DepartID             int                  null,
   UserCode             varchar(50)          null,
   FullName             nvarchar(100)        null,
   PhoneNumber          varchar(15)          null,
   DynamicPassword      varchar(10)          null,
   EffectiveTtime       datetime             null,
   StopTime             datetime             null,
   Email                varchar(50)          null,
   UserType             smallint             null,
   AuditName            nvarchar(100)        null,
   IsActive             bit                  null,
   NoActiveTime         datetime             null,
   CreateUser           nvarchar(50)         null,
   CreateTime           datetime             null,
   ModifyUser           nvarchar(50)         null,
   ModifyTime           datetime             null,
   constraint PK_MASTER_USERINFO primary key (UserID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.master_UserInfo') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'master_UserInfo' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '用户信息', 
   'user', 'dbo', 'table', 'master_UserInfo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.master_UserInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DepartID')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'master_UserInfo', 'column', 'DepartID'

end


execute sp_addextendedproperty 'MS_Description', 
   '部门ID',
   'user', 'dbo', 'table', 'master_UserInfo', 'column', 'DepartID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.master_UserInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UserType')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'master_UserInfo', 'column', 'UserType'

end


execute sp_addextendedproperty 'MS_Description', 
   '0:系统管理员1:贝克曼 2：经销商 ',
   'user', 'dbo', 'table', 'master_UserInfo', 'column', 'UserType'
go

/*==============================================================*/
/* Table: master_UserRoleInfo                                   */
/*==============================================================*/
create table dbo.master_UserRoleInfo (
   RoleID               int                  not null,
   UserID               int                  not null,
   constraint PK_MASTER_USERROLEINFO primary key (RoleID, UserID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.master_UserRoleInfo') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'master_UserRoleInfo' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '用户角色信息', 
   'user', 'dbo', 'table', 'master_UserRoleInfo'
go

/*==============================================================*/
/* Table: master_UsersStat                                      */
/*==============================================================*/
create table dbo.master_UsersStat (
   UsersStatID          int                  identity,
   UserID               int                  null,
   UseModel             nvarchar(100)        null,
   UseModelTime         datetime             null,
   constraint PK_MASTER_USERSSTAT primary key (UsersStatID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.master_UsersStat') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'master_UsersStat' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '用户统计信息', 
   'user', 'dbo', 'table', 'master_UsersStat'
go

/*==============================================================*/
/* View: vw_DepartToRegion                                      */
/*==============================================================*/
create view dbo.vw_DepartToRegion as
select dict_RegionInfo.RegionName,dict_RegionInfo.RegionID,
district.AreaName districtname,district.AreaID districtid,
area.AreaName,area.AreaID,
master_DepartmentInfo.DepartName,master_DepartmentInfo.DepartID
from dict_RegionInfo
inner join master_AreaRegionInfo on(master_AreaRegionInfo.RegionID=dict_RegionInfo.RegionID)
inner join master_AreaInfo district on(master_AreaRegionInfo.AreaID=district.AreaID)
inner join master_AreaInfo  area on(district.AreaPID = area.AreaID)
inner join master_DepartmentInfo on(master_DepartmentInfo.DepartID=area.DepartID)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.vw_DepartToRegion') and minor_id = 0)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'view', 'vw_DepartToRegion'

end


execute sp_addextendedproperty 'MS_Description', 
   '部门到大区到小区到省份',
   'user', 'dbo', 'view', 'vw_DepartToRegion'
go

alter table dbo.master_AreaAdmin
   add constraint FK_MASTECE_MASTER_U foreign key (UserID)
      references dbo.master_UserInfo (UserID)
go

alter table dbo.master_AreaAdmin
   add constraint FK_MASTER_A_REFTER_A foreign key (AreaID)
      references dbo.master_AreaInfo (AreaID)
go

alter table dbo.master_AreaInfo
   add constraint FK_MASTENCE_MASTER_D foreign key (DepartID)
      references dbo.master_DepartmentInfo (DepartID)
go

alter table dbo.master_AreaRegionInfo
   add constraint FK_MASTER_A_REFERENCE_DICT_REG foreign key (RegionID)
      references dbo.dict_RegionInfo (RegionID)
go

alter table dbo.master_AreaRegionInfo
   add constraint FK_MASTER_A_REFERENCE_MASTER_A foreign key (AreaID)
      references dbo.master_AreaInfo (AreaID)
go

alter table dbo.master_CustomerApplyInfo
   add constraint FK_MASTER_C_REFERENCE_MASTER_DAPPLY foreign key (DistributorID)
      references dbo.master_DistributorInfo (DistributorID)
go

alter table dbo.master_CustomerInfo
   add constraint FK_MASTER_C_REFERENCE_MASTER_DCUS foreign key (DistributorID)
      references dbo.master_DistributorInfo (DistributorID)
go

alter table dbo.master_DistributorADInfo
   add constraint FK_MASSTER_D foreign key (DistributorID)
      references dbo.master_DistributorInfo (DistributorID)
go

alter table dbo.master_DistributorADInfo
   add constraint FK_ME_MASTER_P foreign key (ProductLineID)
      references dbo.master_ProductLine (ProductLineID)
go

alter table dbo.master_DistributorInfo
   add constraint FK_MASTER_D_REFERENCE_MASTER_D foreign key (DistributorServiceTypeID)
      references dbo.master_DistributorServiceType (DistributorServiceTypeID)
go

alter table dbo.master_DistributorInfo
   add constraint FK_MASTER_D_REFERENCE_MASTER_D1 foreign key (DistributorTypeID)
      references dbo.master_DistributorType (DistributorTypeID)
go

alter table dbo.master_DistributorInfo
   add constraint FK_MASTER_D_REFERENCE_DICT_REG foreign key (RegionID)
      references dbo.dict_RegionInfo (RegionID)
go

alter table dbo.master_DistributorOKCInfo
   add constraint FK_MASTER_D_REFERENCE_MASTER_DOKC foreign key (DistributorID)
      references dbo.master_DistributorInfo (DistributorID)
go

alter table dbo.master_DistributorOKCInfo
   add constraint FK_MASERENE_MASTER_C foreign key (CustomerID)
      references dbo.master_CustomerInfo (CustomerID)
go

alter table dbo.master_DistributorOKCInfo
   add constraint FK_MASTER_D_REFERENCE_MASTER_OOKC foreign key (OKCID)
      references dbo.master_OKCInfo (OKCID)
go

alter table dbo.master_DistributorPayInfo
   add constraint FK_MASTER_D_REFERENCE_MASTER_DPAY foreign key (DistributorID)
      references dbo.master_DistributorInfo (DistributorID)
go

alter table dbo.master_DistributorPayInfo
   add constraint FK_MASTER_D_REFERENCE_MASTER_P foreign key (PayID)
      references dbo.master_PaymentInfo (PayID)
go

alter table dbo.master_DistributorProductLineInfo
   add constraint FK_MASTER_D_REFERENCE_MASTER_DPROLINE foreign key (DistributorID)
      references dbo.master_DistributorInfo (DistributorID)
go

alter table dbo.master_DistributorProductLineInfo
   add constraint FK_MASTER_D_REFERENCE_MASTER_PLINE foreign key (ProductLineID)
      references dbo.master_ProductLine (ProductLineID)
go

alter table dbo.master_DistributorRegionInfo
   add constraint FK_MASTER_D_REFER_D foreign key (DistributorProductLineID)
      references dbo.master_DistributorProductLineInfo (DistributorProductLineID)
go

alter table dbo.master_DistributorTransport
   add constraint FK_MTER_D foreign key (DistributorID)
      references dbo.master_DistributorInfo (DistributorID)
go

alter table dbo.master_DistributorTransport
   add constraint FK_MASTASTER_T foreign key (TransportID)
      references dbo.master_TransportInfo (TransportID)
go

alter table dbo.master_DistributorUserInfo
   add constraint FK_MASTER_D_REFERENCE_MASTER_D2 foreign key (DistributorID)
      references dbo.master_DistributorInfo (DistributorID)
go

alter table dbo.master_DistributorUserInfo
   add constraint FK_MASTER_D_REFERENCE_MASTER_U foreign key (UserID)
      references dbo.master_UserInfo (UserID)
go

alter table dbo.master_FeedbackStat
   add constraint FK_MASTER_F_REFERENCE_MASTER_UFEEDBACK foreign key (UserID)
      references dbo.master_UserInfo (UserID)
go

alter table dbo.master_MessageStat
   add constraint FK_MASTER_M_REFERENCE_MASTER_USTAT foreign key (UserID)
      references dbo.master_UserInfo (UserID)
go

alter table dbo.master_ProductInfo
   add constraint FK_MASTER_P_REFERENCE_MASTER_PLINE foreign key (ProductLineID)
      references dbo.master_ProductLine (ProductLineID)
go

alter table dbo.master_ProductInfo
   add constraint FK_MAS_ProductSmall foreign key (ProductSmallTypeID)
      references dbo.master_ProductSmallType (ProductSmallTypeID)
go

alter table dbo.master_ProductInfo
   add constraint FK_MASSTER_P foreign key (ProductTypeID)
      references dbo.master_ProductType (ProductTypeID)
go

alter table dbo.master_ProductLine
   add constraint FK_MASRENTER_D foreign key (DepartID)
      references dbo.master_DepartmentInfo (DepartID)
go

alter table dbo.master_ProductModel
   add constraint FK_MASTER_P_REFERENCE_MASTER_PMODEL foreign key (ProductLineID)
      references dbo.master_ProductLine (ProductLineID)
go

alter table dbo.master_ProductOKCPriceInfo
   add constraint FK_MASTER_P_REFERENCE_MASTER_PProductOKCPriceInfo foreign key (ProductID)
      references dbo.master_ProductInfo (ProductID)
go

alter table dbo.master_ProductOKCPriceInfo
   add constraint FK_MASTER_P_REFERENCE_MASTER_O foreign key (OKCID)
      references dbo.master_OKCInfo (OKCID)
go

alter table dbo.master_ProductPriceInfo
   add constraint FK_MASTER_P_REFERENCE_MASTER_PPRICE foreign key (ProductID)
      references dbo.master_ProductInfo (ProductID)
go

alter table dbo.master_ProductSmallType
   add constraint FK_MASTER_P_REFERENCE_MASTER_P_SMALL foreign key (ProductLineID)
      references dbo.master_ProductLine (ProductLineID)
go

alter table dbo.master_RoleAuthority
   add constraint FK_MASTERENCER_R foreign key (RoleID)
      references dbo.master_RoleInfo (RoleID)
go

alter table dbo.master_RoleAuthority
   add constraint FK_MAST_DICT_STR foreign key (StructureID)
      references dbo.dict_Structure (StructureID)
go

alter table dbo.master_UserCustomerAuthority
   add constraint FK_MASTCE_DICT_STR foreign key (StructureID)
      references dbo.dict_Structure (StructureID)
go

alter table dbo.master_UserCustomerAuthority
   add constraint FK_MASTSTER_U foreign key (UserID)
      references dbo.master_UserInfo (UserID)
go

alter table dbo.master_UserInfo
   add constraint FK_MASTSTER_D foreign key (DepartID)
      references dbo.master_DepartmentInfo (DepartID)
go

alter table dbo.master_UserRoleInfo
   add constraint FK_MASTER_U_REFERENCE_MASTER_U foreign key (UserID)
      references dbo.master_UserInfo (UserID)
go

alter table dbo.master_UserRoleInfo
   add constraint FK_MASTER_U_REFERENCE_MASTER_R foreign key (RoleID)
      references dbo.master_RoleInfo (RoleID)
go

alter table dbo.master_UsersStat
   add constraint FK_MASTER_U_REFERENCE_MASTER_USERSTAT foreign key (UserID)
      references dbo.master_UserInfo (UserID)
go
