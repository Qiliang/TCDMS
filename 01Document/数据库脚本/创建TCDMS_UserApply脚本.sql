if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.UserApply_UserApplyAuthority') and o.name = 'FK_MASTER_U_REFERENCE_MASTER_U1')
alter table dbo.UserApply_UserApplyAuthority
   drop constraint FK_MASTER_U_REFERENCE_MASTER_U1
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.UserApply_UserApplyInfo') and o.name = 'FK_USERAPPL_REFERENCE_USERAPPL')
alter table dbo.UserApply_UserApplyInfo
   drop constraint FK_USERAPPL_REFERENCE_USERAPPL
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.UserApply_ApplyBatch')
            and   type = 'U')
   drop table dbo.UserApply_ApplyBatch
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.UserApply_UserApplyAuthority')
            and   type = 'U')
   drop table dbo.UserApply_UserApplyAuthority
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.UserApply_UserApplyInfo')
            and   type = 'U')
   drop table dbo.UserApply_UserApplyInfo
go

/*==============================================================*/
/* Table: UserApply_ApplyBatch                                  */
/*==============================================================*/
create table dbo.UserApply_ApplyBatch (
   BatchID              uniqueidentifier     not null,
   BatchName            nvarchar(50)         null,
   ApplyUser            nvarchar(50)         null,
   ApplyUserPhone       varchar(15)          null,
   ApplyUserEamil       varchar(50)          null,
   AuditStatus          smallint             null,
   ApplyTime            datetime             null,
   DistributorID        varchar(200)         null,
   Status               smallint             null,
   CreateUser           nvarchar(50)         null,
   CreateTime           datetime             null,
   ModifyUser           nvarchar(50)         null,
   ModifyTime           datetime             null,
   constraint PK_USERAPPLY_APPLYBATCH primary key (BatchID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.UserApply_ApplyBatch') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'UserApply_ApplyBatch' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   'UserApply_ApplyBatch', 
   'user', 'dbo', 'table', 'UserApply_ApplyBatch'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.UserApply_ApplyBatch')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AuditStatus')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'UserApply_ApplyBatch', 'column', 'AuditStatus'

end


execute sp_addextendedproperty 'MS_Description', 
   '0：待审核 1：审核失败 2：审核通过 3：已保存',
   'user', 'dbo', 'table', 'UserApply_ApplyBatch', 'column', 'AuditStatus'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.UserApply_ApplyBatch')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Status')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'UserApply_ApplyBatch', 'column', 'Status'

end


execute sp_addextendedproperty 'MS_Description', 
   '1、批次 2、单个',
   'user', 'dbo', 'table', 'UserApply_ApplyBatch', 'column', 'Status'
go

/*==============================================================*/
/* Table: UserApply_UserApplyAuthority                          */
/*==============================================================*/
create table dbo.UserApply_UserApplyAuthority (
   UserAppLyAuthorityID int                  identity,
   UserApplyID          int                  null,
   StructureID          varchar(24)          null,
   AppyUserButtonAuthority int                  null,
   IsAdopt              bit                  null,
   constraint PK_USERAPPLY_USERAPPLYAUTHORIT primary key (UserAppLyAuthorityID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.UserApply_UserApplyAuthority') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'UserApply_UserApplyAuthority' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '用户申请权限信息', 
   'user', 'dbo', 'table', 'UserApply_UserApplyAuthority'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.UserApply_UserApplyAuthority')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'StructureID')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'UserApply_UserApplyAuthority', 'column', 'StructureID'

end


execute sp_addextendedproperty 'MS_Description', 
   '形如001或001001',
   'user', 'dbo', 'table', 'UserApply_UserApplyAuthority', 'column', 'StructureID'
go

/*==============================================================*/
/* Table: UserApply_UserApplyInfo                               */
/*==============================================================*/
create table dbo.UserApply_UserApplyInfo (
   UserApplyID          int                  identity,
   BatchID              uniqueidentifier     null,
   UserChangeID         int                  null,
   UserApplyName        nvarchar(50)         null,
   UserApplyTelNumber   varchar(15)          null,
   UserApplyEmail       varchar(50)          null,
   UserApplyType        smallint             null,
   DistributorIDList    varchar(200)         null,
   UserApplyTime        datetime             null,
   AuditStatus          smallint             null,
   AuditRoleIDList      varchar(100)         null,
   AuditFalseReason     nvarchar(3000)       null,
   CreateUser           nvarchar(50)         null,
   CreateTime           datetime             null,
   ModifyUser           nvarchar(50)         null,
   ModifyTime           datetime             null,
   constraint PK_USERAPPLY_USERAPPLYINFO primary key (UserApplyID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.UserApply_UserApplyInfo') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'UserApply_UserApplyInfo' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '用户申请信息', 
   'user', 'dbo', 'table', 'UserApply_UserApplyInfo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.UserApply_UserApplyInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UserApplyType')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'UserApply_UserApplyInfo', 'column', 'UserApplyType'

end


execute sp_addextendedproperty 'MS_Description', 
   '0:贝克曼 1:经销商',
   'user', 'dbo', 'table', 'UserApply_UserApplyInfo', 'column', 'UserApplyType'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.UserApply_UserApplyInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AuditStatus')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'UserApply_UserApplyInfo', 'column', 'AuditStatus'

end


execute sp_addextendedproperty 'MS_Description', 
   '0：待审核 1：审核失败 2：审核通过 3：已保存',
   'user', 'dbo', 'table', 'UserApply_UserApplyInfo', 'column', 'AuditStatus'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.UserApply_UserApplyInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AuditRoleIDList')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'UserApply_UserApplyInfo', 'column', 'AuditRoleIDList'

end


execute sp_addextendedproperty 'MS_Description', 
   '审核角色ID，以逗号分隔（每个角色审核完后，删除对应的角色ID)
   以逗号开头和逗号结尾形如：,1,11,2,3,',
   'user', 'dbo', 'table', 'UserApply_UserApplyInfo', 'column', 'AuditRoleIDList'
go

alter table dbo.UserApply_UserApplyAuthority
   add constraint FK_MASTER_U_REFERENCE_MASTER_U1 foreign key (UserApplyID)
      references dbo.UserApply_UserApplyInfo (UserApplyID)
go

alter table dbo.UserApply_UserApplyInfo
   add constraint FK_USERAPPL_REFERENCE_USERAPPL foreign key (BatchID)
      references dbo.UserApply_ApplyBatch (BatchID)
go
