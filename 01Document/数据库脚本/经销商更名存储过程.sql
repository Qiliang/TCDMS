--经销商更名
if exists (select *
            from  sysobjects
           where  id = object_id(N'proc_DistributorChangeName'))
drop proc proc_DistributorChangeName
go

create proc proc_DistributorChangeName
@OleDis varchar(100),	--老经销商ID
@NewDis varchar(100),	--新经销商ID
@IsOKCPrice bit,		--OKC价
@IsPrediction bit,		--预测数据
@IsMessaging bit,		--即时消息
@IsSales bit,			--销售数据
@IsInformation bit,		--信息提示栏
@IsInventory bit,		--库存数据
@IsProfileBulletin bit,	--中文简介系统公告
@IsGeneralContract bit,	--普通合同
@IsLeaseContract bit,	--租赁合同
@IsPriceStatus bit,		--价格启用/禁用状态
@IsMinimumOrderQuantity bit,	--最低订货量	
@IsMinimumOrderAmount bit,	--最小订单金额
@IsReactionCupBalance bit,	--反应杯余额
@IsFOCBalance bit,		-- FOC余额
@IsInventoryInitialInventory bit, --库存最后一个月的数据复制到新经销商的初期库存
@IsOK bit = 0 output
as
begin
	begin transaction

	declare @errorSun int = 0
	--OKC价
	if @IsOKCPrice = 1
	begin
		insert master_DistributorOKCInfo(DistributorID,OKCID)
		(
			select @NewDis as DistributorID,OKCID 
			from master_DistributorOKCInfo a
			where DistributorID=@OleDis and not EXISTS(
			select OKCID 
			from master_DistributorOKCInfo b
			where DistributorID=@NewDis and a.OKCID=b.OKCID)
		)

		set @errorSun=@errorSun+@@ERROR
	end
	--价格启用/禁用状态
	if @IsPriceStatus = 1
	begin
		set @errorSun=@errorSun+@@ERROR
	end
	--预测数据
	if @IsPrediction = 1
	begin
		set @errorSun=@errorSun+@@ERROR
	end
	--即时消息
	if @IsMessaging = 1
	begin
		set @errorSun=@errorSun+@@ERROR
	end
	--销售数据
	if @IsSales = 1
	begin
		set @errorSun=@errorSun+@@ERROR
	end
	--库存数据
	if @IsInventory = 1
	begin
		set @errorSun=@errorSun+@@ERROR
	end
	--普通合同
	if @IsGeneralContract = 1
	begin
		set @errorSun=@errorSun+@@ERROR
	end
	--最低订货量
	if @IsMinimumOrderQuantity = 1
	begin
		set @errorSun=@errorSun+@@ERROR
	end
	--反应杯余额
	if @IsReactionCupBalance = 1
	begin
		set @errorSun=@errorSun+@@ERROR
	end
	--信息提示栏
	if @IsInformation = 1
	begin
		set @errorSun=@errorSun+@@ERROR
	end
	--中文简介系统公告
	if @IsProfileBulletin = 1
	begin
		set @errorSun=@errorSun+@@ERROR
	end
	--租赁合同
	if @IsLeaseContract = 1
	begin
		set @errorSun=@errorSun+@@ERROR
	end
	--最小订单金额
	if @IsMinimumOrderAmount = 1
	begin
		set @errorSun=@errorSun+@@ERROR
	end
	--FOC余额
	if @IsFOCBalance = 1
	begin
		set @errorSun=@errorSun+@@ERROR
	end
	--库存最后一个月的数据复制到新经销商的初期库存
	if @IsInventoryInitialInventory = 1
	begin
		set @errorSun=@errorSun+@@ERROR
	end

	if @errorSun<>0
	begin
		rollback transaction
		set @IsOK=0
	end
	else
	begin
		commit transaction
		set @IsOK=1
	end
end
go