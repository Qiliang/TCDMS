--组织架构
if exists (select *
            from  sysobjects
           where  id = object_id(N'trigger_Logmaster_DepartmentInfo'))
drop trigger trigger_Logmaster_DepartmentInfo
go


create trigger trigger_Logmaster_DepartmentInfo
on master_DepartmentInfo
for update
as
begin
	--日志表 对应字段变量
	declare @LogDetails nvarchar(1000),
	@LogDate datetime,
	@OpratorName nvarchar(50),
	@BelongModel nvarchar(100)=N'基础数据',
	@BelongFunc nvarchar(100)=N'修改'
	--监控表对应字段变量
	declare @DepartName nvarchar(100)

	--更新的表字段变量
	declare @NewDepartName nvarchar(100)

	select @NewDepartName=DepartName from inserted
	
	select @DepartName=DepartName from deleted
	--判断是否修改
	if isnull(@NewDepartName,'')<>isnull(@DepartName,'')
		set @LogDetails=isnull(@LogDetails,'')+'部门名称由'+isnull(@DepartName,'')+'变更为'+isnull(@NewDepartName,'')
	
	select @LogDate=ModifyTime from inserted
	select @OpratorName=ModifyUser from inserted
	
	insert into common_LogInfo values(@BelongModel,@BelongFunc,@LogDetails,@LogDate,@OpratorName)
end

go


--大小区
if exists (select *
            from  sysobjects
           where  id = object_id(N'trigger_Logmaster_AreaInfo'))
drop trigger trigger_Logmaster_AreaInfo
go


create trigger trigger_Logmaster_AreaInfo
on master_AreaInfo
for update
as
begin
	--日志表 对应字段变量
	declare @LogDetails nvarchar(1000),
	@LogDate datetime,
	@OpratorName nvarchar(50),
	@BelongModel nvarchar(100)=N'基础数据',
	@BelongFunc nvarchar(100)=N'修改'
	--监控表对应字段变量
	declare @AreaName nvarchar(100)

	--更新的表字段变量
	declare @NewAreaName nvarchar(100)

	select @NewAreaName=AreaName from inserted
	
	select @AreaName=AreaName from deleted

	set @LogDetails='大小区名称'+@AreaName+'：'
	--判断是否修改
	if isnull(@NewAreaName,'')<>isnull(@AreaName,'')
		set @LogDetails=isnull(@LogDetails,'')+'大小区名称由'+isnull(@AreaName,'')+'变更为'+isnull(@NewAreaName,'')
	
	select @LogDate=ModifyTime from inserted
	select @OpratorName=ModifyUser from inserted
	
	insert into common_LogInfo values(@BelongModel,@BelongFunc,@LogDetails,@LogDate,@OpratorName)
end

go



--经销商信息
if exists (select *
            from  sysobjects
           where  id = object_id(N'trigger_Logmaster_DistributorInfo'))
drop trigger trigger_Logmaster_DistributorInfo
go


create trigger trigger_Logmaster_DistributorInfo
on master_DistributorInfo
for update
as
begin
	--日志表 对应字段变量
	declare @LogDetails nvarchar(1000),
	@LogDate datetime,
	@OpratorName nvarchar(50),
	@BelongModel nvarchar(100)=N'基础数据',
	@BelongFunc nvarchar(100)=N'修改'
	--监控表对应字段变量
	declare @DistributorName nvarchar(100),
	@DistributorServiceTypeID nvarchar(100),
	@DistributorTypeID nvarchar(100),
	@RegionID nvarchar(100),
	@InvoiceCode nvarchar(100),
	@DeliverCode nvarchar(100),
	@CSRNameReagent nvarchar(100),
	@CSRNameD nvarchar(100),
	@CSRNameB nvarchar(100),
	@Office nvarchar(100),
	@IsOrderGoods nvarchar(100),
	@IsActive nvarchar(100)

	--更新的表字段变量
	declare @NewDistributorName nvarchar(100),
	@NewDistributorServiceTypeID nvarchar(100),
	@NewDistributorTypeID nvarchar(100),
	@NewRegionID nvarchar(100),
	@NewInvoiceCode nvarchar(100),
	@NewDeliverCode nvarchar(100),
	@NewCSRNameReagent nvarchar(100),
	@NewCSRNameD nvarchar(100),
	@NewCSRNameB nvarchar(100),
	@NewOffice nvarchar(100),
	@NewIsOrderGoods nvarchar(100),
	@NewIsActive nvarchar(100)

	select @NewDistributorName=DistributorName from inserted
	select @NewDistributorServiceTypeID=DistributorServiceTypeID from inserted
	select @NewDistributorTypeID=DistributorTypeID from inserted
	select @NewRegionID=RegionID from inserted
	select @NewInvoiceCode=InvoiceCode from inserted
	select @NewDeliverCode=DeliverCode from inserted
	select @NewCSRNameReagent=CSRNameReagent from inserted
	select @NewCSRNameD=CSRNameD from inserted
	select @NewCSRNameB=CSRNameB from inserted
	select @NewOffice=Office from inserted
	select @NewIsOrderGoods=IsOrderGoods from inserted
	select @NewIsActive=IsActive from inserted
	
	select @DistributorName=DistributorName from deleted
	select @DistributorServiceTypeID=DistributorServiceTypeID from deleted
	select @DistributorTypeID=DistributorTypeID from deleted
	select @RegionID=RegionID from deleted
	select @InvoiceCode=InvoiceCode from deleted
	select @DeliverCode=DeliverCode from deleted
	select @CSRNameReagent=CSRNameReagent from deleted
	select @CSRNameD=CSRNameD from deleted
	select @CSRNameB=CSRNameB from deleted
	select @Office=Office from deleted
	select @IsOrderGoods=IsOrderGoods from deleted
	select @IsActive=IsActive from deleted

	set @LogDetails='经销商名称'+@DistributorName+'：'
	--判断是否修改
	if isnull(@NewDistributorName,'')<>isnull(@DistributorName,'')
		set @LogDetails=isnull(@LogDetails,'')+'经销商名称由'+isnull(@DistributorName,'')+'变更为'+isnull(@NewDistributorName,'')

	if isnull(@NewDistributorServiceTypeID,'')<>isnull(@DistributorServiceTypeID,'')
	begin
		select top 1 @NewDistributorServiceTypeID=DistributorServiceTypeName from master_DistributorServiceType
		where DistributorServiceTypeID=(select DistributorServiceTypeID from inserted)

		select top 1 @DistributorServiceTypeID=DistributorServiceTypeName from master_DistributorServiceType
		where DistributorServiceTypeID=(select DistributorServiceTypeID from deleted)

		set @LogDetails=isnull(@LogDetails,'')+'经销商服务类型由'+isnull(@DistributorServiceTypeID,'')+'变更为'+isnull(@NewDistributorServiceTypeID,'')
	end

	if isnull(@NewDistributorTypeID,'')<>isnull(@DistributorTypeID,'')
	begin
		select top 1 @NewDistributorTypeID=DistributorTypeName from master_DistributorType
		where DistributorTypeID=(select DistributorTypeID from inserted)

		select top 1 @DistributorTypeID=DistributorTypeName from master_DistributorType
		where DistributorTypeID=(select DistributorTypeID from deleted)
		set @LogDetails=isnull(@LogDetails,'')+'经销商类别由'+isnull(@DistributorTypeID,'')+'变更为'+isnull(@NewDistributorTypeID,'')
	end

	if isnull(@NewRegionID,'')<>isnull(@RegionID,'')
	begin
		select top 1 @NewRegionID=RegionName from dict_RegionInfo
		where RegionID=(select RegionID from inserted)

		select top 1 @RegionID=RegionName from dict_RegionInfo
		where RegionID=(select RegionID from deleted)
		set @LogDetails=isnull(@LogDetails,'')+'注册省份由'+isnull(@RegionID,'')+'变更为'+isnull(@NewRegionID,'')
	end

	if isnull(@NewInvoiceCode,'')<>isnull(@InvoiceCode,'')
		set @LogDetails=isnull(@LogDetails,'')+'发货地址编号由'+isnull(@InvoiceCode,'')+'变更为'+isnull(@NewInvoiceCode,'')

	if isnull(@NewDeliverCode,'')<>isnull(@DeliverCode,'')
		set @LogDetails=isnull(@LogDetails,'')+'送货地址编号由'+isnull(@DeliverCode,'')+'变更为'+isnull(@NewDeliverCode,'')

	if isnull(@NewCSRNameReagent,'')<>isnull(@CSRNameReagent,'')
		set @LogDetails=isnull(@LogDetails,'')+'CSR用户名（试剂）由'+isnull(@CSRNameReagent,'')+'变更为'+isnull(@NewCSRNameReagent,'')

	if isnull(@NewCSRNameD,'')<>isnull(@CSRNameD,'')
		set @LogDetails=isnull(@LogDetails,'')+'CSR用户名(维修D部)由'+isnull(@CSRNameD,'')+'变更为'+isnull(@NewCSRNameD,'')

	if isnull(@NewCSRNameB,'')<>isnull(@CSRNameB,'')
		set @LogDetails=isnull(@LogDetails,'')+'CSR用户名(维修B部)由'+isnull(@CSRNameB,'')+'变更为'+isnull(@NewCSRNameB,'')

	if isnull(@NewOffice,'')<>isnull(@Office,'')
		set @LogDetails=isnull(@LogDetails,'')+'办事处由'+isnull(@Office,'')+'变更为'+isnull(@NewOffice,'')

	if isnull(@NewIsOrderGoods,0)<>isnull(@IsOrderGoods,0)
	begin
		select @NewIsOrderGoods=case when isnull(@NewIsOrderGoods,0) = '0' then '否'
						    when isnull(@NewIsOrderGoods,0) = '1' then '是'
							end

		select @IsOrderGoods=case when isnull(@IsOrderGoods,0) = '0' then '否'
						    when isnull(@IsOrderGoods,0) = '1' then '是'
							end

		set @LogDetails=isnull(@LogDetails,'')+'订货权限由'+isnull(@IsOrderGoods,'')+'变更为'+isnull(@NewIsOrderGoods,'')
	end

	select @LogDate=ModifyTime from inserted
	select @OpratorName=ModifyUser from inserted
	
	if @IsActive=@NewIsActive
		insert into common_LogInfo values(@BelongModel,@BelongFunc,@LogDetails,@LogDate,@OpratorName)
end

go

--关账日
if exists (select *
            from  sysobjects
           where  id = object_id(N'trigger_Logmaster_AccountDateInfo'))
drop trigger trigger_Logmaster_AccountDateInfo
go


create trigger trigger_Logmaster_AccountDateInfo
on master_AccountDateInfo
for update
as
begin
	--日志表 对应字段变量
	declare @LogDetails nvarchar(1000),
	@LogDate datetime,
	@OpratorName nvarchar(50),
	@BelongModel nvarchar(100)=N'基础数据',
	@BelongFunc nvarchar(100)=N'修改'
	--监控表对应字段变量
	declare @AccountDateName nvarchar(100),
	@AccountDateYear nvarchar(100),
	@AccountDatePlace nvarchar(100),
	@AccountDateBelongModel nvarchar(100),
	@MonthDate nvarchar(100),
	@FebDate nvarchar(100),
	@MarchDate nvarchar(100),
	@AprilDate nvarchar(100),
	@MayDate nvarchar(100),
	@JuneDate nvarchar(100),
	@JulyDate nvarchar(100),
	@AugustDate nvarchar(100),
	@SepDate nvarchar(100),
	@OctDate nvarchar(100),
	@NovDate nvarchar(100),
	@DecDate nvarchar(100)

	--更新的表字段变量
	declare @NewAccountDateName nvarchar(100),
	@NewAccountDateYear nvarchar(100),
	@NewAccountDatePlace nvarchar(100),
	@NewAccountDateBelongModel nvarchar(100),
	@NewMonthDate nvarchar(100),
	@NewFebDate nvarchar(100),
	@NewMarchDate nvarchar(100),
	@NewAprilDate nvarchar(100),
	@NewMayDate nvarchar(100),
	@NewJuneDate nvarchar(100),
	@NewJulyDate nvarchar(100),
	@NewAugustDate nvarchar(100),
	@NewSepDate nvarchar(100),
	@NewOctDate nvarchar(100),
	@NewNovDate nvarchar(100),
	@NewDecDate nvarchar(100)

	select @NewAccountDateName=AccountDateName from inserted
	select @NewAccountDateYear=AccountDateYear from inserted
	select @NewAccountDatePlace=AccountDatePlace from inserted
	select @NewAccountDateBelongModel=AccountDateBelongModel from inserted
	select @NewMonthDate=convert(char(10),MonthDate,111) from inserted
	select @NewFebDate=convert(char(10),FebDate,111) from inserted
	select @NewMarchDate=convert(char(10),MarchDate,111) from inserted
	select @NewAprilDate=convert(char(10),AprilDate,111) from inserted
	select @NewMayDate=convert(char(10),MayDate,111) from inserted
	select @NewJuneDate=convert(char(10),JuneDate,111) from inserted
	select @NewJulyDate=convert(char(10),JulyDate,111) from inserted
	select @NewAugustDate=convert(char(10),AugustDate,111) from inserted
	select @NewSepDate=convert(char(10),SepDate,111) from inserted
	select @NewOctDate=convert(char(10),OctDate,111) from inserted
	select @NewNovDate=convert(char(10),NovDate,111) from inserted
	select @NewDecDate=convert(char(10),DecDate,111) from inserted
	
	select @AccountDateName=AccountDateName from deleted
	select @AccountDateYear=AccountDateYear from deleted
	select @AccountDatePlace=AccountDatePlace from deleted
	select @AccountDateBelongModel=AccountDateBelongModel from deleted
	select @MonthDate=convert(char(10),MonthDate,111) from deleted
	select @FebDate=convert(char(10),FebDate,111) from deleted
	select @MarchDate=convert(char(10),MarchDate,111) from deleted
	select @AprilDate=convert(char(10),AprilDate,111) from deleted
	select @MayDate=convert(char(10),MayDate,111) from deleted
	select @JuneDate=convert(char(10),JuneDate,111) from deleted
	select @JulyDate=convert(char(10),JulyDate,111) from deleted
	select @AugustDate=convert(char(10),AugustDate,111) from deleted
	select @SepDate=convert(char(10),SepDate,111) from deleted
	select @OctDate=convert(char(10),OctDate,111) from deleted
	select @NovDate=convert(char(10),NovDate,111) from deleted
	select @DecDate=convert(char(10),DecDate,111) from deleted

	set @LogDetails='关账日名称'+@AccountDateName+'：'
	--判断是否修改
	if isnull(@NewAccountDateName,'')<>isnull(@AccountDateName,'')
		set @LogDetails=isnull(@LogDetails,'')+'关账日名称由'+isnull(@AccountDateName,'')+'变更为'+isnull(@NewAccountDateName,'')

	if isnull(@NewAccountDateYear,'')<>isnull(@AccountDateYear,'')
		set @LogDetails=isnull(@LogDetails,'')+'年份由'+isnull(@AccountDateYear,'')+'变更为'+isnull(@NewAccountDateYear,'')

	if isnull(@NewAccountDatePlace,'')<>isnull(@AccountDatePlace,'')
		set @LogDetails=isnull(@LogDetails,'')+'送货地点由'+isnull(@AccountDatePlace,'')+'变更为'+isnull(@NewAccountDatePlace,'')

	if isnull(@NewAccountDateBelongModel,'')<>isnull(@AccountDateBelongModel,'')
		set @LogDetails=isnull(@LogDetails,'')+'模块由'+isnull(@AccountDateBelongModel,'')+'变更为'+isnull(@NewAccountDateBelongModel,'')

	if isnull(@NewMonthDate,'')<>isnull(@MonthDate,'')
		set @LogDetails=isnull(@LogDetails,'')+'一月日期由'+isnull(@MonthDate,'')+'变更为'+isnull(@NewMonthDate,'')

	if isnull(@NewFebDate,'')<>isnull(@FebDate,'')
		set @LogDetails=isnull(@LogDetails,'')+'二月日期由'+isnull(@FebDate,'')+'变更为'+isnull(@NewFebDate,'')

	if isnull(@NewMarchDate,'')<>isnull(@MarchDate,'')
		set @LogDetails=isnull(@LogDetails,'')+'三月日期由'+isnull(@MarchDate,'')+'变更为'+isnull(@NewMarchDate,'')

	if isnull(@NewAprilDate,'')<>isnull(@AprilDate,'')
		set @LogDetails=isnull(@LogDetails,'')+'四月日期由'+isnull(@AprilDate,'')+'变更为'+isnull(@NewAprilDate,'')

	if isnull(@NewMayDate,'')<>isnull(@MayDate,'')
		set @LogDetails=isnull(@LogDetails,'')+'五月日期由'+isnull(@MayDate,'')+'变更为'+isnull(@NewMayDate,'')

	if isnull(@NewJuneDate,'')<>isnull(@JuneDate,'')
		set @LogDetails=isnull(@LogDetails,'')+'六月日期由'+isnull(@JuneDate,'')+'变更为'+isnull(@NewJuneDate,'')

	if isnull(@NewJulyDate,'')<>isnull(@JulyDate,'')
		set @LogDetails=isnull(@LogDetails,'')+'七月日期由'+isnull(@JulyDate,'')+'变更为'+isnull(@NewJulyDate,'')

	if isnull(@NewAugustDate,'')<>isnull(@AugustDate,'')
		set @LogDetails=isnull(@LogDetails,'')+'八月日期由'+isnull(@AugustDate,'')+'变更为'+isnull(@NewAugustDate,'')

	if isnull(@NewSepDate,'')<>isnull(@SepDate,'')
		set @LogDetails=isnull(@LogDetails,'')+'九月日期由'+isnull(@SepDate,'')+'变更为'+isnull(@NewSepDate,'')

	if isnull(@NewOctDate,'')<>isnull(@OctDate,'')
		set @LogDetails=isnull(@LogDetails,'')+'十月日期由'+isnull(@OctDate,'')+'变更为'+isnull(@NewOctDate,'')

	if isnull(@NewNovDate,'')<>isnull(@NovDate,'')
		set @LogDetails=isnull(@LogDetails,'')+'十一月日期由'+isnull(@NovDate,'')+'变更为'+isnull(@NewNovDate,'')

	if isnull(@NewDecDate,'')<>isnull(@DecDate,'')
		set @LogDetails=isnull(@LogDetails,'')+'十二月日期由'+isnull(@DecDate,'')+'变更为'+isnull(@NewDecDate,'')
	
	select @LogDate=ModifyTime from inserted
	select @OpratorName=ModifyUser from inserted
	
	insert into common_LogInfo values(@BelongModel,@BelongFunc,@LogDetails,@LogDate,@OpratorName)
end

go



--用户信息
if exists (select *
            from  sysobjects
           where  id = object_id(N'trigger_Logmaster_UserInfo'))
drop trigger trigger_Logmaster_UserInfo
go


create trigger trigger_Logmaster_UserInfo
on master_UserInfo
for update
as
begin
	--日志表 对应字段变量
	declare @LogDetails nvarchar(1000),
	@LogDate datetime,
	@OpratorName nvarchar(50),
	@BelongModel nvarchar(100)=N'基础数据',
	@BelongFunc nvarchar(100)=N'修改'
	--监控表对应字段变量
	declare @UserCode nvarchar(100),
	@FullName nvarchar(100),
	@PhoneNumber nvarchar(100),
	@StopTime nvarchar(100),
	@Email nvarchar(100),
	@UserType nvarchar(100),
	@DepartID nvarchar(100),
	@IsActive nvarchar(100)

	--更新的表字段变量
	declare @NewUserCode nvarchar(100),
	@NewFullName nvarchar(100),
	@NewPhoneNumber nvarchar(100),
	@NewStopTime nvarchar(100),
	@NewEmail nvarchar(100),
	@NewUserType nvarchar(100),
	@NewDepartID nvarchar(100),
	@NewIsActive nvarchar(100)

	select @NewUserCode=UserCode from inserted
	select @NewFullName=FullName from inserted
	select @NewPhoneNumber=PhoneNumber from inserted
	select @NewStopTime=convert(char(10),StopTime,111) from inserted
	select @NewEmail=Email from inserted
	select @NewUserType=UserType from inserted
	select @NewDepartID=DepartID from inserted
	select @NewIsActive=IsActive from inserted
	
	select @UserCode=UserCode from deleted
	select @FullName=FullName from deleted
	select @PhoneNumber=PhoneNumber from deleted
	select @StopTime=convert(char(10),StopTime,111) from deleted
	select @Email=Email from deleted
	select @UserType=UserType from deleted
	select @DepartID=DepartID from deleted
	select @IsActive=IsActive from deleted

	set @LogDetails='用户名'+@FullName+'：'
	--判断是否修改
	if isnull(@NewUserCode,'')<>isnull(@UserCode,'')
		set @LogDetails=isnull(@LogDetails,'')+'用户编号由'+isnull(@UserCode,'')+'变更为'+isnull(@NewUserCode,'')

	if isnull(@NewFullName,'')<>isnull(@FullName,'')
		set @LogDetails=isnull(@LogDetails,'')+'用户名由'+isnull(@FullName,'')+'变更为'+isnull(@NewFullName,'')

	if isnull(@NewPhoneNumber,'')<>isnull(@PhoneNumber,'')
		set @LogDetails=isnull(@LogDetails,'')+'手机号点由'+isnull(@PhoneNumber,'')+'变更为'+isnull(@NewPhoneNumber,'')

	if isnull(@NewStopTime,'')<>isnull(@StopTime,'')
		set @LogDetails=isnull(@LogDetails,'')+'到期日期由'+isnull(@StopTime,'')+'变更为'+isnull(@NewStopTime,'')

	if isnull(@NewEmail,'')<>isnull(@Email,'')
		set @LogDetails=isnull(@LogDetails,'')+'邮箱由'+isnull(@Email,'')+'变更为'+isnull(@NewEmail,'')

	if isnull(@NewUserType,'')<>isnull(@UserType,'')
	begin
		select @UserType=case when @UserType = '0' then '系统管理员'
						    when @UserType = '1' then '贝克曼'
							when @UserType = '2' then '经销商'
							end

		select @NewUserType=case when @NewUserType = '0' then '系统管理员'
						    when @NewUserType = '1' then '贝克曼'
							when @NewUserType = '2' then '经销商'
							end

		set @LogDetails=isnull(@LogDetails,'')+'用户类型由'+isnull(@UserType,'')+'变更为'+isnull(@NewUserType,'')
	end

	if isnull(@NewDepartID,'')<>isnull(@DepartID,'')
	begin
		select top 1 @NewDepartID=DepartName from master_DepartmentInfo
		where DepartID=(select DepartID from inserted)

		select top 1 @DepartID=DepartName from master_DepartmentInfo
		where DepartID=(select DepartID from deleted)

		set @LogDetails=isnull(@LogDetails,'')+'部门由'+isnull(@DepartID,'')+'变更为'+isnull(@NewDepartID,'')
	end
	
	select @LogDate=ModifyTime from inserted
	select @OpratorName=ModifyUser from inserted
	
	if @IsActive=@NewIsActive
		insert into common_LogInfo values(@BelongModel,@BelongFunc,@LogDetails,@LogDate,@OpratorName)
end

go
--运输方式
if exists (select *
            from  sysobjects
           where  id = object_id(N'trigger_Logmaster_TransportInfo'))
drop trigger trigger_Logmaster_TransportInfo

go

create trigger trigger_Logmaster_TransportInfo
on master_TransportInfo
for update
as
begin
	--日志表 对应字段变量
	declare @LogDetails nvarchar(1000),
	@LogDate datetime,
	@OpratorName nvarchar(50),
	@BelongModel nvarchar(100)=N'基础数据',
	@BelongFunc nvarchar(100)=N'修改'
	--监控表对应字段变量
	declare @TransportName nvarchar(100),
	@OrderType nvarchar(100),
	@IsActive nvarchar(100)

	--更新的表字段变量
	declare @NewTransportName nvarchar(100),
	@NewOrderType nvarchar(100),
	@NewIsActive nvarchar(100)

	select @NewTransportName=TransportName from inserted
	select @NewOrderType=OrderType from inserted
	select @NewIsActive=TransportStatus from inserted
	
	select @TransportName=TransportName from deleted
	select @OrderType=OrderType from deleted
	select @IsActive=TransportStatus from deleted

	set @LogDetails=isnull(@LogDetails,'')+'运输方式'+isnull(@TransportName,'')+':'
	--判断是否修改
	if isnull(@NewTransportName,'')<>isnull(@TransportName,'')
		set @LogDetails=isnull(@LogDetails,'')+'运输方式由'+isnull(@TransportName,'')+'变更为'+isnull(@NewTransportName,'')+','
	
	if isnull(@NewOrderType,'')<>isnull(@OrderType,'')
		set @LogDetails=isnull(@LogDetails,'')+'订单类型由'+isnull(@OrderType,'')+'变更为'+isnull(@NewOrderType,'')+','
	
	set @LogDetails=SUBSTRING(@LogDetails,1,LEN(@LogDetails)-1)
	select @LogDate=ModifyTime from inserted
	select @OpratorName=ModifyUser from inserted
	
	if @IsActive=@NewIsActive
		insert into common_LogInfo values(@BelongModel,@BelongFunc,@LogDetails,@LogDate,@OpratorName)
end

go

--付款条款
if exists (select *
            from  sysobjects
           where  id = object_id(N'trigger_Logmaster_PaymentInfo'))
drop trigger trigger_Logmaster_PaymentInfo
go

create trigger trigger_Logmaster_PaymentInfo
on master_PaymentInfo
for update
as
begin
	--日志表 对应字段变量
	declare @LogDetails nvarchar(1000),
	@LogDate datetime,
	@OpratorName nvarchar(50),
	@BelongModel nvarchar(100)=N'基础数据',
	@BelongFunc nvarchar(100)=N'修改'
	--监控表对应字段变量
	declare @PayName nvarchar(100),
	@OracleName nvarchar(100),
	@PayStartTime nvarchar(100),
	@PayEndTime nvarchar(100),
	@IsActive nvarchar(100)

	--更新的表字段变量
	declare @NewPayName nvarchar(100),
	@NewOracleName nvarchar(100),
	@NewPayStartTime nvarchar(100),
	@NewPayEndTime nvarchar(100),
	@NewIsActive nvarchar(100)

	select @NewPayName=PayName from inserted
	select @NewOracleName=OracleName from inserted
	select @NewPayStartTime=CONVERT(CHAR(10), PayStartTime, 111) from inserted
	select @NewPayEndTime=CONVERT(CHAR(10), PayEndTime, 111) from inserted 
	select @NewIsActive=PayStatus from inserted
	
	select @PayName=PayName from deleted
	select @OracleName=OracleName from deleted
	select @PayStartTime=CONVERT(CHAR(10), PayStartTime, 111) from deleted 
	select @PayEndTime=CONVERT(CHAR(10), PayEndTime, 111) from deleted  
	select @IsActive=PayStatus from deleted

	set @LogDetails=isnull(@LogDetails,'')+'付款条款'+isnull(@PayName,'')+':'
	--判断是否修改
	if isnull(@NewPayName,'')<>isnull(@PayName,'')
		set @LogDetails=isnull(@LogDetails,'')+'付款条款由'+isnull(@PayName,'')+'变更为'+isnull(@NewPayName,'')+','
	
	if isnull(@NewOracleName,'')<>isnull(@OracleName,'')
		set @LogDetails=isnull(@LogDetails,'')+'Oracle Name由'+isnull(@OracleName,'')+'变更为'+isnull(@NewOracleName,'')+','

	if isnull(@NewPayStartTime,'')<>isnull(@PayStartTime,'')
		set @LogDetails=isnull(@LogDetails,'')+'开始时间由'+isnull(@PayStartTime,'')+'变更为'+isnull(@NewPayStartTime,'')+','

	if isnull(@NewPayEndTime,'')<>isnull(@PayEndTime,'')
		set @LogDetails=isnull(@LogDetails,'')+'结束时间由'+isnull(@PayEndTime,'')+'变更为'+isnull(@NewPayEndTime,'')+','

	set @LogDetails=SUBSTRING(@LogDetails,1,LEN(@LogDetails)-1)
	select @LogDate=ModifyTime from inserted
	select @OpratorName=ModifyUser from inserted
	
	if @IsActive=@NewIsActive
		insert into common_LogInfo values(@BelongModel,@BelongFunc,@LogDetails,@LogDate,@OpratorName)
end

go

--产品类型
if exists (select *
            from  sysobjects
           where  id = object_id(N'trigger_Logmaster_ProductType'))
drop trigger trigger_Logmaster_ProductType

go

create trigger trigger_Logmaster_ProductType
on master_ProductType
for update
as
begin
	--日志表 对应字段变量
	declare @LogDetails nvarchar(1000),
	@LogDate datetime,
	@OpratorName nvarchar(50),
	@BelongModel nvarchar(100)=N'基础数据',
	@BelongFunc nvarchar(100)=N'修改'
	--监控表对应字段变量
	declare @ProductTypeName nvarchar(100),
	@ProductTypeAB nvarchar(100),
	@OracleName nvarchar(100)

	--更新的表字段变量
	declare @NewProductTypeName nvarchar(100),
	@NewProductTypeAB nvarchar(100),
	@NewOracleName nvarchar(100)

	select @NewProductTypeName=ProductTypeName from inserted
	select @NewOracleName=OracleName from inserted
	select @NewProductTypeAB=ProductTypeAB from inserted
	
	select @ProductTypeName=ProductTypeName from deleted
	select @OracleName=OracleName from deleted
	select @ProductTypeAB=ProductTypeAB from deleted 

	set @LogDetails=isnull(@LogDetails,'')+'产品类型'+isnull(@ProductTypeName,'')+':'
	--判断是否修改
	if isnull(@NewProductTypeName,'')<>isnull(@ProductTypeName,'')
		set @LogDetails=isnull(@LogDetails,'')+'产品类型名称由'+isnull(@ProductTypeName,'')+'变更为'+isnull(@NewProductTypeName,'')+','

	if isnull(@NewProductTypeAB,'')<>isnull(@ProductTypeAB,'')
		set @LogDetails=isnull(@LogDetails,'')+'缩写由'+isnull(@ProductTypeAB,'')+'变更为'+isnull(@NewProductTypeAB,'')+','

	if isnull(@NewOracleName,'')<>isnull(@OracleName,'')
		set @LogDetails=isnull(@LogDetails,'')+'Oracle Name由'+isnull(@OracleName,'')+'变更为'+isnull(@NewOracleName,'')+','

	set @LogDetails=SUBSTRING(@LogDetails,1,LEN(@LogDetails)-1)
	select @LogDate=ModifyTime from inserted
	select @OpratorName=ModifyUser from inserted
	
	insert into common_LogInfo values(@BelongModel,@BelongFunc,@LogDetails,@LogDate,@OpratorName)
end

go
--仪器类型
if exists (select *
            from  sysobjects
           where  id = object_id(N'trigger_Logmaster_InstrumentType'))
drop trigger trigger_Logmaster_InstrumentType

go

create trigger trigger_Logmaster_InstrumentType
on master_InstrumentType
for update
as
begin
	--日志表 对应字段变量
	declare @LogDetails nvarchar(1000),
	@LogDate datetime,
	@OpratorName nvarchar(50),
	@BelongModel nvarchar(100)=N'基础数据',
	@BelongFunc nvarchar(100)=N'修改'
	--监控表对应字段变量
	declare @InstrumentTypeName nvarchar(100)

	--更新的表字段变量
	declare @NewInstrumentTypeName nvarchar(100)

	select @NewInstrumentTypeName=InstrumentTypeName from inserted
	
	select @InstrumentTypeName=InstrumentTypeName from deleted

	set @LogDetails=isnull(@LogDetails,'')+'仪器类型'+isnull(@InstrumentTypeName,'')+':'
	--判断是否修改
	if isnull(@NewInstrumentTypeName,'')<>isnull(@InstrumentTypeName,'')
		set @LogDetails=isnull(@LogDetails,'')+'仪器类型名称由'+isnull(@InstrumentTypeName,'')+'变更为'+isnull(@NewInstrumentTypeName,'')

	select @LogDate=ModifyTime from inserted
	select @OpratorName=ModifyUser from inserted
	
	insert into common_LogInfo values(@BelongModel,@BelongFunc,@LogDetails,@LogDate,@OpratorName)
end

go
--仪器型号
if exists (select *
            from  sysobjects
           where  id = object_id(N'trigger_Logmaster_ProductModel'))
drop trigger trigger_Logmaster_ProductModel
go


create trigger trigger_Logmaster_ProductModel
on master_ProductModel
for update
as
begin
	--日志表 对应字段变量
	declare @LogDetails nvarchar(1000),
	@LogDate datetime,
	@OpratorName nvarchar(50),
	@BelongModel nvarchar(100)=N'基础数据',
	@BelongFunc nvarchar(100)=N'修改'
	--监控表对应字段变量
	declare @ProductModelName nvarchar(100),
	@ProductLineName nvarchar(100),
	@IsActive nvarchar(100)

	--更新的表字段变量
	declare @NewProductModelName nvarchar(100),
	@NewProductLineName nvarchar(100),
	@NewIsActive nvarchar(100)

	select @NewProductModelName=ProductModelName from inserted
	select @NewProductLineName=ProductLineName from master_ProductLine where ProductLineID= (select ProductLineID from inserted)
	select @NewIsActive=IsActive from inserted

	
	select @ProductModelName=ProductModelName from deleted
	select @ProductLineName=ProductLineName from master_ProductLine where ProductLineID= (select ProductLineID from deleted)
	select @IsActive=IsActive from deleted

	set @LogDetails=isnull(@LogDetails,'')+'仪器型号'+isnull(@ProductModelName,'')+':'
	--判断是否修改
	if isnull(@NewProductModelName,'')<>isnull(@ProductModelName,'')
		set @LogDetails=isnull(@LogDetails,'')+'仪器型号由'+isnull(@ProductModelName,'')+'变更为'+isnull(@NewProductModelName,'')+','

	if isnull(@NewProductLineName,'')<>isnull(@ProductLineName,'')
		set @LogDetails=isnull(@LogDetails,'')+'产品线由'+isnull(@ProductLineName,'')+'变更为'+isnull(@NewProductLineName,'')+','

	set @LogDetails=SUBSTRING(@LogDetails,1,LEN(@LogDetails)-1)
	select @LogDate=ModifyTime from inserted
	select @OpratorName=ModifyUser from inserted
	
	if @IsActive=@NewIsActive
		insert into common_LogInfo values(@BelongModel,@BelongFunc,@LogDetails,@LogDate,@OpratorName)
end

go
--产品线
if exists (select *
            from  sysobjects
           where  id = object_id(N'trigger_Logmaster_ProductLine'))
drop trigger trigger_Logmaster_ProductLine

go

create trigger trigger_Logmaster_ProductLine
on master_ProductLine
for update
as
begin
	--日志表 对应字段变量
	declare @LogDetails nvarchar(1000),
	@LogDate datetime,
	@OpratorName nvarchar(50),
	@BelongModel nvarchar(100)=N'基础数据',
	@BelongFunc nvarchar(100)=N'修改'
	--监控表对应字段变量
	declare @ProductLineName nvarchar(100),
	@ProductLineNameAB nvarchar(100),
	@DepartName nvarchar(100),
	@IsActive nvarchar(100)

	--更新的表字段变量
	declare @NewProductLineName nvarchar(100),
	@NewProductLineNameAB nvarchar(100),
	@NewDepartName nvarchar(100),
	@NewIsActive nvarchar(100)

	select @NewProductLineName=ProductLineName from inserted
	select @NewProductLineNameAB=ProductLineNameAB from inserted
	select @NewDepartName=DepartName from master_DepartmentInfo where DepartID= (select DepartID from inserted)
	select @NewIsActive=IsActive from inserted

	select @ProductLineName=ProductLineName from deleted
	select @ProductLineNameAB=ProductLineNameAB from deleted
	select @DepartName=DepartName from master_DepartmentInfo where DepartID= (select DepartID from deleted)
	select @IsActive=IsActive from deleted

	set @LogDetails=isnull(@LogDetails,'')+'产品线'+isnull(@ProductLineName,'')+':'
	--判断是否修改
	if isnull(@NewProductLineName,'')<>isnull(@ProductLineName,'')
		set @LogDetails=isnull(@LogDetails,'')+'产品线名称由'+isnull(@ProductLineName,'')+'变更为'+isnull(@NewProductLineName,'')+','

	if isnull(@NewProductLineNameAB,'')<>isnull(@ProductLineNameAB,'')
		set @LogDetails=isnull(@LogDetails,'')+'缩写由'+isnull(@ProductLineNameAB,'')+'变更为'+isnull(@NewProductLineNameAB,'')+','

	if isnull(@NewDepartName,'')<>isnull(@DepartName,'')
		set @LogDetails=isnull(@LogDetails,'')+'部门由'+isnull(@DepartName,'')+'变更为'+isnull(@NewDepartName,'')+','

	set @LogDetails=SUBSTRING(@LogDetails,1,LEN(@LogDetails)-1)
	select @LogDate=ModifyTime from inserted
	select @OpratorName=ModifyUser from inserted
	
	if @IsActive=@NewIsActive
		insert into common_LogInfo values(@BelongModel,@BelongFunc,@LogDetails,@LogDate,@OpratorName)
end

go
--产品小类
if exists (select *
            from  sysobjects
           where  id = object_id(N'trigger_Logmaster_ProductSmallType'))
drop trigger trigger_Logmaster_ProductSmallType

go

create trigger trigger_Logmaster_ProductSmallType
on master_ProductSmallType
for update
as
begin
	--日志表 对应字段变量
	declare @LogDetails nvarchar(1000),
	@LogDate datetime,
	@OpratorName nvarchar(50),
	@BelongModel nvarchar(100)=N'基础数据',
	@BelongFunc nvarchar(100)=N'修改'
	--监控表对应字段变量
	declare @ProductLineName nvarchar(100),
	@ProductSmallTypeName nvarchar(100),
	@IsActive nvarchar(100)

	--更新的表字段变量
	declare @NewProductLineName nvarchar(100),
	@NewProductSmallTypeName nvarchar(100),
	@NewIsActive nvarchar(100)

	select @NewProductSmallTypeName=ProductSmallTypeName from inserted
	select @NewProductLineName=ProductLineName from master_ProductLine where ProductLineID= (select ProductLineID from inserted)
	select @NewIsActive=IsActive from inserted
	
	select @ProductSmallTypeName=ProductSmallTypeName from deleted
	select @ProductLineName=ProductLineName from master_ProductLine where ProductLineID= (select ProductLineID from deleted)
	select @IsActive=IsActive from deleted

	set @LogDetails=isnull(@LogDetails,'')+'产品线'+isnull(@ProductLineName,'')+':'
	--判断是否修改
	if isnull(@NewProductLineName,'')<>isnull(@ProductLineName,'')
		set @LogDetails=isnull(@LogDetails,'')+'产品线由'+isnull(@ProductLineName,'')+'变更为'+isnull(@NewProductLineName,'')+','

	if isnull(@NewProductSmallTypeName,'')<>isnull(@ProductSmallTypeName,'')
		set @LogDetails=isnull(@LogDetails,'')+'产品小类由'+isnull(@ProductSmallTypeName,'')+'变更为'+isnull(@NewProductSmallTypeName,'')+','

    set @LogDetails=SUBSTRING(@LogDetails,1,LEN(@LogDetails)-1)
	select @LogDate=ModifyTime from inserted
	select @OpratorName=ModifyUser from inserted
	
	if @IsActive=@NewIsActive
		insert into common_LogInfo values(@BelongModel,@BelongFunc,@LogDetails,@LogDate,@OpratorName)
end

go
--产品清单
if exists (select *
            from  sysobjects
           where  id = object_id(N'trigger_Logmaster_ProductInfo'))
drop trigger trigger_Logmaster_ProductInfo

go

create trigger trigger_Logmaster_ProductInfo
on master_ProductInfo
for update
as
begin
	--日志表 对应字段变量
	declare @LogDetails nvarchar(1000),
	@LogDate datetime,
	@OpratorName nvarchar(50),
	@BelongModel nvarchar(100)=N'基础数据',
	@BelongFunc nvarchar(100)=N'修改'
	--监控表对应字段变量
	declare @ProductName nvarchar(100),
	@ReagentSize nvarchar(100),
	@ProductTypeName nvarchar(100),
	@ProductLineName nvarchar(100),
	@ReagentProject nvarchar(100),
	@ReagentTest nvarchar(100),
	@RemarkDes nvarchar(100),
	@ProductSmallTypeName nvarchar(100),
	@Is3CStr nvarchar(100),
	@IsActive nvarchar(100)

	--更新的表字段变量
	declare @NewProductName nvarchar(100),
	@NewReagentSize nvarchar(100),
	@NewProductTypeName nvarchar(100),
	@NewProductLineName nvarchar(100),
	@NewReagentProject nvarchar(100),
	@NewReagentTest nvarchar(100),
	@NewRemarkDes nvarchar(100),
	@NewProductSmallTypeName nvarchar(100),
	@NewIs3CStr nvarchar(100),
	@NewIsActive nvarchar(100)

	select @NewProductName=ProductName from inserted
	select @NewReagentSize=ReagentSize from inserted
	select @NewProductTypeName=ProductTypeName from master_ProductType where ProductTypeID= (select ProductTypeID from inserted)
	select @NewProductLineName=ProductLineName from master_ProductLine where ProductLineID= (select ProductLineID from inserted)
	select @NewReagentProject=ReagentProject from inserted
	select @NewReagentTest=ReagentTest from inserted
	select @NewRemarkDes=RemarkDes from inserted
	select @NewProductSmallTypeName=ProductSmallTypeName from master_ProductSmallType where ProductSmallTypeID= (select ProductSmallTypeID from inserted)
	select @NewIsActive=IsActive from inserted
	select @NewIs3CStr=case when Is3C = 1 then '是'
						    when Is3C = 0 then '否'
							end  from inserted

	select @ProductName=ProductName from deleted
	select @ReagentSize=ReagentSize from deleted
	select @ProductTypeName=ProductTypeName from master_ProductType where ProductTypeID= (select ProductTypeID from deleted)
	select @ProductLineName=ProductLineName from master_ProductLine where ProductLineID= (select ProductLineID from deleted)
	select @ReagentProject=ReagentProject from deleted
	select @ReagentTest=ReagentTest from deleted
	select @RemarkDes=RemarkDes from deleted
	select @ProductSmallTypeName=ProductSmallTypeName from master_ProductSmallType where ProductSmallTypeID= (select ProductSmallTypeID from deleted)
	select @IsActive=IsActive from deleted
	select @Is3CStr=case when Is3C = 1 then '是'
						    when Is3C = 0 then '否'
							end  from deleted

    set @LogDetails=isnull(@LogDetails,'')+'产品'+isnull(@ProductName,'')+':'
	--判断是否修改
	if isnull(@NewProductName,'')<>isnull(@ProductName,'')
		set @LogDetails=isnull(@LogDetails,'')+'产品名称由'+isnull(@ProductName,'')+'变更为'+isnull(@NewProductName,'')+','

	if isnull(@NewReagentSize,'')<>isnull(@ReagentSize,'')
		set @LogDetails=isnull(@LogDetails,'')+'规格由'+isnull(@ReagentSize,'')+'变更为'+isnull(@NewReagentSize,'')+','

	if isnull(@NewProductTypeName,'')<>isnull(@ProductTypeName,'')
		set @LogDetails=isnull(@LogDetails,'')+'产品类型由'+isnull(@ProductTypeName,'')+'变更为'+isnull(@NewProductTypeName,'')+','

	if isnull(@NewProductSmallTypeName,'')<>isnull(@ProductSmallTypeName,'')
		set @LogDetails=isnull(@LogDetails,'')+'产品小类由'+isnull(@ProductSmallTypeName,'')+'变更为'+isnull(@NewProductSmallTypeName,'')+','

	if isnull(@NewProductLineName,'')<>isnull(@ProductLineName,'')
		set @LogDetails=isnull(@LogDetails,'')+'产品线由'+isnull(@ProductLineName,'')+'变更为'+isnull(@NewProductLineName,'')+','

	if isnull(@NewReagentProject,'')<>isnull(@ReagentProject,'')
		set @LogDetails=isnull(@LogDetails,'')+'项目由'+isnull(@ReagentProject,'')+'变更为'+isnull(@NewReagentProject,'')+','

	if isnull(@NewReagentTest,'')<>isnull(@ReagentTest,'')
		set @LogDetails=isnull(@LogDetails,'')+'测试数由'+isnull(@ReagentTest,'')+'变更为'+isnull(@NewReagentTest,'')+','

	if isnull(@NewIs3CStr,'')<>isnull(@Is3CStr,'')
		set @LogDetails=isnull(@LogDetails,'')+'3C产品由'+isnull(@Is3CStr,'')+'变更为'+isnull(@NewIs3CStr,'')+','

	if isnull(@NewRemarkDes,'')<>isnull(@RemarkDes,'')
		set @LogDetails=isnull(@LogDetails,'')+'备注由'+isnull(@RemarkDes,'')+'变更为'+isnull(@NewRemarkDes,'')+','

	set @LogDetails=SUBSTRING(@LogDetails,1,LEN(@LogDetails)-1)
	select @LogDate=ModifyTime from inserted
	select @OpratorName=ModifyUser from inserted
	
	if @IsActive=@NewIsActive
		insert into common_LogInfo values(@BelongModel,@BelongFunc,@LogDetails,@LogDate,@OpratorName)
end

go
--经销商类别
if exists (select *
            from  sysobjects
           where  id = object_id(N'trigger_Logmaster_DistributorType'))
drop trigger trigger_Logmaster_DistributorType

go

create trigger trigger_Logmaster_DistributorType
on master_DistributorType
for update
as
begin
	--日志表 对应字段变量
	declare @LogDetails nvarchar(1000),
	@LogDate datetime,
	@OpratorName nvarchar(50),
	@BelongModel nvarchar(100)=N'基础数据',
	@BelongFunc nvarchar(100)=N'修改'
	--监控表对应字段变量
	declare @DistributorTypeName nvarchar(100)

	--更新的表字段变量
	declare @NewDistributorTypeName nvarchar(100)

	select @NewDistributorTypeName=DistributorTypeName from inserted

	select @DistributorTypeName=DistributorTypeName from deleted
	
	set @LogDetails=isnull(@LogDetails,'')+'经销商类别'+isnull(@DistributorTypeName,'')+':'
	--判断是否修改
	if isnull(@NewDistributorTypeName,'')<>isnull(@DistributorTypeName,'')
		set @LogDetails=isnull(@LogDetails,'')+'经销商类别名称由'+isnull(@DistributorTypeName,'')+'变更为'+isnull(@NewDistributorTypeName,'')

	select @LogDate=ModifyTime from inserted
	select @OpratorName=ModifyUser from inserted
	
	insert into common_LogInfo values(@BelongModel,@BelongFunc,@LogDetails,@LogDate,@OpratorName)
end

go
--经销商服务类型
if exists (select *
            from  sysobjects
           where  id = object_id(N'trigger_Logmaster_DistributorServiceType'))
drop trigger trigger_Logmaster_DistributorServiceType

go

create trigger trigger_Logmaster_DistributorServiceType
on master_DistributorServiceType
for update
as
begin
	--日志表 对应字段变量
	declare @LogDetails nvarchar(1000),
	@LogDate datetime,
	@OpratorName nvarchar(50),
	@BelongModel nvarchar(100)=N'基础数据',
	@BelongFunc nvarchar(100)=N'修改'
	--监控表对应字段变量
	declare @DistributorServiceTypeName nvarchar(100)

	--更新的表字段变量
	declare @NewDistributorServiceTypeName nvarchar(100)

	select @NewDistributorServiceTypeName=DistributorServiceTypeName from inserted

	select @DistributorServiceTypeName=DistributorServiceTypeName from deleted
	
	set @LogDetails=isnull(@LogDetails,'')+'经销商服务类型'+isnull(@DistributorServiceTypeName,'')+':'
	--判断是否修改
	if isnull(@NewDistributorServiceTypeName,'')<>isnull(@DistributorServiceTypeName,'')
		set @LogDetails=isnull(@LogDetails,'')+'经销商服务类型由'+isnull(@DistributorServiceTypeName,'')+'变更为'+isnull(@NewDistributorServiceTypeName,'')

	select @LogDate=ModifyTime from inserted
	select @OpratorName=ModifyUser from inserted
	
	insert into common_LogInfo values(@BelongModel,@BelongFunc,@LogDetails,@LogDate,@OpratorName)
end

go
--客户信息
if exists (select *
            from  sysobjects
           where  id = object_id(N'trigger_Logmaster_CustomerInfo'))
drop trigger trigger_Logmaster_CustomerInfo

go

create trigger trigger_Logmaster_CustomerInfo
on master_CustomerInfo
for update
as
begin
	--日志表 对应字段变量
	declare @LogDetails nvarchar(1000),
	@LogDate datetime,
	@OpratorName nvarchar(50),
	@BelongModel nvarchar(100)=N'基础数据',
	@BelongFunc nvarchar(100)=N'修改'
	--监控表对应字段变量
	declare @Province nvarchar(100),
	@City nvarchar(100),
	@Country nvarchar(100),
	@OracleNO nvarchar(100),
	@OracleName nvarchar(100),
	@CustomerName nvarchar(100),
	@XSWNO nvarchar(100),
	@IsActive nvarchar(100)

	--更新的表字段变量
	declare @NewProvince nvarchar(100),
	@NewCity nvarchar(100),
	@NewCountry nvarchar(100),
	@NewOracleNO nvarchar(100),
	@NewOracleName nvarchar(100),
	@NewCustomerName nvarchar(100),
	@NewXSWNO nvarchar(100),
	@NewIsActive nvarchar(100)

	select @NewProvince=Province from inserted
	select @NewCity=City from inserted
	select @NewCountry=Country from inserted
	select @NewOracleNO=OracleNO from inserted
	select @NewOracleName=OracleName from inserted
	select @NewCustomerName=CustomerName from inserted
	select @NewXSWNO=XSWNO from inserted
	select @NewIsActive=IsActive from inserted

	select @Province=Province from deleted
	select @City=City from deleted
	select @Country=Country from deleted
	select @OracleNO=OracleNO from deleted
	select @OracleName=OracleName from deleted
	select @CustomerName=CustomerName from deleted
	select @XSWNO=XSWNO from deleted
	select @IsActive=IsActive from deleted
	
	set @LogDetails=isnull(@LogDetails,'')+'客户'+isnull(@CustomerName,'')+':'
	--判断是否修改
	if isnull(@NewProvince,'')<>isnull(@Province,'')
		set @LogDetails=isnull(@LogDetails,'')+'省份由'+isnull(@Province,'')+'变更为'+isnull(@NewProvince,'')+','

	if isnull(@NewCity,'')<>isnull(@City,'')
		set @LogDetails=isnull(@LogDetails,'')+'城市由'+isnull(@City,'')+'变更为'+isnull(@NewCity,'')+','

	if isnull(@NewCountry,'')<>isnull(@Country,'')
		set @LogDetails=isnull(@LogDetails,'')+'县区由'+isnull(@Country,'')+'变更为'+isnull(@NewCountry,'')+','

	if isnull(@NewOracleNO,'')<>isnull(@OracleNO,'')
		set @LogDetails=isnull(@LogDetails,'')+'OracleNO由'+isnull(@OracleNO,'')+'变更为'+isnull(@NewOracleNO,'')+','

	if isnull(@NewOracleName,'')<>isnull(@OracleName,'')
		set @LogDetails=isnull(@LogDetails,'')+'OracleName由'+isnull(@OracleName,'')+'变更为'+isnull(@NewOracleName,'')+','

	if isnull(@NewCustomerName,'')<>isnull(@CustomerName,'')
		set @LogDetails=isnull(@LogDetails,'')+'客户名由'+isnull(@CustomerName,'')+'变更为'+isnull(@NewCustomerName,'')+','

	if isnull(@NewXSWNO,'')<>isnull(@XSWNO,'')
		set @LogDetails=isnull(@LogDetails,'')+'XSW编号由'+isnull(@XSWNO,'')+'变更为'+isnull(@NewXSWNO,'')+','

	set @LogDetails=SUBSTRING(@LogDetails,1,LEN(@LogDetails)-1)
	select @LogDate=ModifyTime from inserted
	select @OpratorName=ModifyUser from inserted
	
	if @IsActive=@NewIsActive
		insert into common_LogInfo values(@BelongModel,@BelongFunc,@LogDetails,@LogDate,@OpratorName)
end

go