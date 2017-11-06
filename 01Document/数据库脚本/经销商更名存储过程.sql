--�����̸���
if exists (select *
            from  sysobjects
           where  id = object_id(N'proc_DistributorChangeName'))
drop proc proc_DistributorChangeName
go

create proc proc_DistributorChangeName
@OleDis varchar(100),	--�Ͼ�����ID
@NewDis varchar(100),	--�¾�����ID
@IsOKCPrice bit,		--OKC��
@IsPrediction bit,		--Ԥ������
@IsMessaging bit,		--��ʱ��Ϣ
@IsSales bit,			--��������
@IsInformation bit,		--��Ϣ��ʾ��
@IsInventory bit,		--�������
@IsProfileBulletin bit,	--���ļ��ϵͳ����
@IsGeneralContract bit,	--��ͨ��ͬ
@IsLeaseContract bit,	--���޺�ͬ
@IsPriceStatus bit,		--�۸�����/����״̬
@IsMinimumOrderQuantity bit,	--��Ͷ�����	
@IsMinimumOrderAmount bit,	--��С�������
@IsReactionCupBalance bit,	--��Ӧ�����
@IsFOCBalance bit,		-- FOC���
@IsInventoryInitialInventory bit, --������һ���µ����ݸ��Ƶ��¾����̵ĳ��ڿ��
@IsOK bit = 0 output
as
begin
	begin transaction

	declare @errorSun int = 0
	--OKC��
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
	--�۸�����/����״̬
	if @IsPriceStatus = 1
	begin
		set @errorSun=@errorSun+@@ERROR
	end
	--Ԥ������
	if @IsPrediction = 1
	begin
		set @errorSun=@errorSun+@@ERROR
	end
	--��ʱ��Ϣ
	if @IsMessaging = 1
	begin
		set @errorSun=@errorSun+@@ERROR
	end
	--��������
	if @IsSales = 1
	begin
		set @errorSun=@errorSun+@@ERROR
	end
	--�������
	if @IsInventory = 1
	begin
		set @errorSun=@errorSun+@@ERROR
	end
	--��ͨ��ͬ
	if @IsGeneralContract = 1
	begin
		set @errorSun=@errorSun+@@ERROR
	end
	--��Ͷ�����
	if @IsMinimumOrderQuantity = 1
	begin
		set @errorSun=@errorSun+@@ERROR
	end
	--��Ӧ�����
	if @IsReactionCupBalance = 1
	begin
		set @errorSun=@errorSun+@@ERROR
	end
	--��Ϣ��ʾ��
	if @IsInformation = 1
	begin
		set @errorSun=@errorSun+@@ERROR
	end
	--���ļ��ϵͳ����
	if @IsProfileBulletin = 1
	begin
		set @errorSun=@errorSun+@@ERROR
	end
	--���޺�ͬ
	if @IsLeaseContract = 1
	begin
		set @errorSun=@errorSun+@@ERROR
	end
	--��С�������
	if @IsMinimumOrderAmount = 1
	begin
		set @errorSun=@errorSun+@@ERROR
	end
	--FOC���
	if @IsFOCBalance = 1
	begin
		set @errorSun=@errorSun+@@ERROR
	end
	--������һ���µ����ݸ��Ƶ��¾����̵ĳ��ڿ��
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