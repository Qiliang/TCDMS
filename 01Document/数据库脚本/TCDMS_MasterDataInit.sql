-- TCDMS MasterData数据初始化

-- 1、初始化按钮信息---
insert into dict_ButtonInfo
select 1,'btnView',N'查看',null,0,null,1
union
select 2,'btnSearch',N'搜索','ClickSearch();',1,'search.ico',2
union
select 4,'btnAdd',N'新增','ClickAdd();',1,'add.ico',3
union
select 8,'btnModify',N'修改','ClickModify();',1,'modify.ico',4
union
select 16,'btnDel',N'删除','ClickDel();',1,'del.ico',5
union
select 32,'btnAudit',N'审核','ClickAudit();',1,'audit.ico',6
union
select 64,'btnActived',N'停/启用','ClickActived();',1,'active.ico',7
union
select 128,'btnImport',N'导入','ClickImport();',1,'import.ico',8
union
select 256,'btnExport',N'导出','ClickExport();',1,'export.ico',9
union
select 512,'btnInsert',N'插入','ClickInsert();',1,'Insert.ico',10
union
select 1024,'btnChange',N'更名','ClickChange();',1,'Change.ico',11
union
select 2048,'btnAuthority',N'授权','ClickAuthority();',1,'Authority.ico',12
union
select 4096,'btnUpload',N'上传','ClickUpload();',1,'Upload.ico',13


go

-- 2、初始化结构信息---
insert into dict_Structure(StructureID,ParentStructureID,StructureName,IsVisible,BelongButton,IndexCode,DesImage,URL,Description)
select '005',null,N'订购系统（贝克曼）',1,1,20,'Main_Order-1.png',null,null
union
select '005001','005',N'试剂订单处理',1,1,25,'',null,N'采购试剂产品'
union
select '005002','005',N'配件订单处理',1,1,30,'',null,N'采购配件产品'
union
select '005003','005',N'发货管理',1,1,35,'',null,N'发货管理'
union
select '005004','005',N'订单情况一览',1,1,40,'',null,N'订单情况一览'
union
select '005005','005',N'FOC管理',1,1,45,'',null,N'FOC'
union
select '005006','005',N'订单规则设置',1,1,50,'',null,N'订单规则设置'
union
select '015',null,N'销售库存（贝克曼）',1,1,60,'Main_SalesInventory-1.png',null,null
union
select '015001','015',N'Submission Summary',1,1,65,'',null,null
union
select '015002','015',N'提交状态',1,1,70,'',null,null
union
select '015003','015',N'销售数据',1,1,75,'',null,null
union
select '015004','015',N'库存数据',1,1,80,'',null,null
union
select '025',null,N'ScoreCard贝克曼',1,1,100,'Main_ScoreCard-1.png',null,null
union
select '025001','025',N'Funnel',1,1,105,'',null,null
union
select '025002','025',N'Inventory',1,1,110,'',null,null
union
select '025003','025',N'Payment',1,1,115,'',null,null
union
select '025004','025',N'Booking',1,1,120,'',null,null
union
select '035',null,N'评估系统（贝克曼）',1,1,140,'Main_Evaluate-1.png',null,null
union
select '035001','035',N'年初计划（销售）',1,1,145,'',null,null
union
select '035002','035',N'年初计划（地区经理）',1,1,146,'',null,null
union
select '035003','035',N'年初计划（大区经理）',1,1,147,'',null,null
union
select '035004','035',N'年中评估（销售）',1,1,148,'',null,null
union
select '035005','035',N'年中评估（LSS）',1,1,149,'',null,null
union
select '035006','035',N'年中评估（CTS）',1,1,150,'',null,null
union
select '035007','035',N'年中评估（地区经理）',1,1,151,'',null,null
union
select '035008','035',N'年中评估（质量）',1,1,152,'',null,null
union
select '035009','035',N'年中评估（大区经理）',1,1,153,'',null,null
union
select '035010','035',N'全年评估（销售）',1,1,154,'',null,null
union
select '035011','035',N'全年评估（LSS）',1,1,155,'',null,null
union
select '035012','035',N'全年评估（CTS）',1,1,156,'',null,null
union
select '035013','035',N'全年评估（地区经理）',1,1,157,'',null,null
union
select '035014','035',N'全年评估（质量）',1,1,158,'',null,null
union
select '035015','035',N'全年评估（大区经理）',1,1,159,'',null,null
union
select '035016','035',N'全年评估（总经理）',1,1,160,'',null,null
union
select '035017','035',N'公式设置',1,1,161,'',null,null
union
select '045',null,N'CF贝克曼',1,1,180,'Main_CustomerFeedback-1.png',null,null
union
select '045001','045',N'安装信息',1,1,185,'',null,null
union
select '045002','045',N'问题类型设置',1,1,186,'',null,null
union
select '045003','045',N'调查信息设置',1,1,187,'',null,null
union
select '045004','045',N'赔偿信息设置',1,1,188,'',null,null
union
select '045005','045',N'流程配置',1,1,189,'',null,null
union
select '045006','045',N'邮件配置',1,1,190,'',null,null
union
select '045007','045',N'CF审核',1,1,191,'',null,null
union
select '045008','045',N'CF分析',1,1,192,'',null,null
union
select '055',null,N'公告发布（贝克曼）',1,1,220,'Main_Announcement-1.png',null,null
union
select '055001','055',N'即时消息',1,1,225,'',null,null
union
select '055002','055',N'信息提示栏',1,1,226,'',null,null
union
select '065',null,N'资料文档（贝克曼）',1,1,260,'Main_Document-1.png',null,null
union
select '065001','065',N'注册证',1,1,265,'',null,null
union
select '065002','065',N'LSS应用资料',1,1,266,'',null,null
union
select '065003','065',N'维修技术支持资料',1,1,267,'',null,null
union
select '065004','065',N'生命科学仪器报价',1,1,268,'',null,null
union
select '065005','065',N'颗粒特性仪器报价',1,1,269,'',null,null
union
select '065006','065',N'BCCE资质文件',1,1,270,'',null,null
union
select '075',null,N'FCPA贝克曼',1,1,300,'Main_FCPA-1.png',null,null
union
select '075001','075',N'Dashboard',1,1,305,'',null,null
union
select '075002','075',N'明细列表',1,1,306,'',null,null
union
select '075003','075',N'用户管理',1,1,307,'',null,null
union
select '075004','075',N'提醒管理',1,1,308,'',null,null
union
select '075005','075',N'组织架构图',1,1,309,'',null,null
union
select '080',null,N'报表系统',1,1,320,'Main_Report-1.png',null,null
union
select '080001','080',N'Submission Summary',1,1,325,'',null,null
union
select '080002','080',N'Sell-through',1,1,326,'',null,null
union
select '080003','080',N'inventory report',1,1,327,'',null,null
union
select '080004','080',N'inventory turns',1,1,328,'',null,null
union
select '080005','080',N'inventory turns trend',1,1,329,'',null,null
union
select '080006','080',N'经销商配置',1,1,330,'',null,null
union
select '080007','080',N'ASP discount',1,1,331,'',null,null
union
select '080008','080',N'区域配置',1,1,332,'',null,null
union
select '080009','080',N'数据源',1,1,333,'',null,null
union
select '080010','080',N'Inv Turns Setting',1,1,334,'',null,null
union
select '085',null,N'合同管理系统',1,1,340,'Main_Contract-1.png',null,null
union
select '085001','085',N'外贸信息管理',1,1,345,'',null,null
union
select '085002','085',N'外购产品管理',1,1,346,'',null,null
union
select '085003','085',N'外购供应商管理',1,1,347,'',null,null
union
select '085004','085',N'订货人管理',1,1,348,'',null,null
union
select '085005','085',N'地区经理管理',1,1,349,'',null,null
union
select '085006','085',N'销售代表管理',1,1,350,'',null,null
union
select '085007','085',N'制定供应商管理',1,1,351,'',null,null
union
select '085008','085',N'促销计划管理',1,1,352,'',null,null
union
select '085009','085',N'Budget管理',1,1,353,'',null,null
union
select '085010','085',N'Forecast管理',1,1,354,'',null,null
union
select '085011','085',N'已归档合同',1,1,355,'',null,null
union
select '085012','085',N'数据生成',1,1,356,'',null,null
union
select '085013','085',N'报表分析',1,1,357,'',null,null
union
select '090',null,N'租赁管理系统',1,1,360,'Main_Lease-1.png',null,null
union
select '090001','090',N'价格管理',1,1,365,'',null,null
union
select '090002','090',N'仪器管理',1,1,366,'',null,null
union
select '090003','090',N'合同管理',1,1,367,'',null,null
union
select '090004','090',N'贝克曼统计',1,1,368,'',null,null
union
select '090005','090',N'经销商统计',1,1,369,'',null,null
union
select '090006','090',N'E-BOX监控',1,1,370,'',null,null
union
select '090007','090',N'仪器项目监控',1,1,371,'',null,null
union
select '090008','090',N'经销商关系',1,1,372,'',null,null
union
select '090009','090',N'仪器项目配置',1,1,373,'',null,null
union
select '090010','090',N'仪器数据验证',1,1,374,'',null,null
union
select '095',null,N'基础数据',1,1,380,'Main_Basicdata-1.png','/MasterData/Main/Index',null
union
select '095001','095',N'区域管理',1,1,381,'',null,null
union
select '095001001','095001',N'行政区域',1,29,382,'','/MasterData/AreaRegion/Region',null 
union
select '095001002','095001',N'大区小区',1,29,383,'','/MasterData/AreaRegion/Area',null 
union
select '095002','095',N'基本信息',1,1,390,'',null,null
union
select '095002001','095002',N'汇率管理',1,269,391,'','/MasterData/BaseInfo/Rate',null
union
select '095002002','095002',N'运输方式',1,77,392,'','/MasterData/BaseInfo/Transportation',null
union
select '095002003','095002',N'付款条款',1,351,393,'','/MasterData/BaseInfo/Payment',null
union
select '095002004','095002',N'关账日',1,397,394,'','/MasterData/BaseInfo/ClosingDate',null
union
select '095003','095',N'产品管理',1,1,400,'',null,null
union
select '095003001','095003',N'产品线',1,95,401,'','/MasterData/ProductManagement/ProductLine',null
union
select '095003002','095003',N'仪器类型',1,29,402,'','/MasterData/ProductManagement/InstrumentType',null
union
select '095003003','095003',N'仪器型号',1,479,403,'','/MasterData/ProductManagement/InstrumentModel',null
union
select '095003004','095003',N'产品小类',1,479,404,'','/MasterData/ProductManagement/ProductSmallclass',null
union
select '095003005','095003',N'产品类型',1,29,405,'','/MasterData/ProductManagement/ProductType',null
union
select '095003006','095003',N'试剂产品清单',1,479,406,'','/MasterData/ProductManagement/ReagentProductList',null
union
select '095003007','095003',N'维修产品清单',1,479,407,'','/MasterData/ProductManagement/RepairProductList',null
union
select '095003008','095003',N'试剂产品价格',1,411,408,'','/MasterData/ProductManagement/ReagentProductPrice',null
union
select '095003009','095003',N'试剂产品特价',1,927,409,'','/MasterData/ProductManagement/ProductSpecial',null
union
select '095003010','095003',N'维修产品价格',1,411,410,'','/MasterData/ProductManagement/RepairProductPrice',null
union
select '095004','095',N'经销商管理',1,1,420,'',null,null
union
select '095004001','095004',N'经销商类别',1,29,421,'','/MasterData/Distributor/DistributorType',null
union
select '095004002','095004',N'经销商服务类型',1,29,422,'','/MasterData/Distributor/DistributorServiceType',null
union
select '095004004','095004',N'经销商信息管理',1,5599,423,'','/MasterData/Distributor/DistributorManagement',null
union
select '095004005','095004',N'经销商授权',1,2435,424,'','/MasterData/Distributor/DistributorAuthority',null
union
select '095004006','095004',N'经销商公告授权',1,2435,425,'','/MasterData/Distributor/DistributorAnnouncementAuthority',null
union
select '095004007','095004',N'经销商价格授权',1,2051,426,'','/MasterData/Distributor/DistributorPriceAuthority',null
union
select '095005','095',N'客户字典',1,1,430,'',null,null
union
select '095005001','095005',N'客户信息',1,479,431,'','/MasterData/Customer/Customer',null
union
select '095005002','095005',N'客户审核',1,35,432,'','/MasterData/Customer/CustomerAudit',null
union
select '095006','095',N'用户权限',1,1,440,'',null,null
union
select '095006001','095006',N'用户管理',1,479,441,'','/MasterData/UserAuthority/UserInfo',null
union
select '095006002','095006',N'用户审核',1,35,442,'','/MasterData/UserAuthority/UserAudit',null
union
select '095006003','095006',N'模板管理',1,287,443,'','/MasterData/UserAuthority/RoleInfo',null
union
select '095006004','095006',N'组织架构',1,29,444,'','/MasterData/UserAuthority/DepartmentInfo',null
union
select '095007','095',N'系统配置',1,1,450,'',null,null
union
select '095007001','095007',N'模块管理员配置',1,9,451,'','/MasterData/System/ModularSysEmail',null
union
select '095007002','095007',N'客户管理员配置',1,21,452,'','/MasterData/System/CustomerSysEmail',null
union
select '095007003','095007',N'运维管理员配置',1,9,453,'','/MasterData/System/OperationSysEmail',null
union
select '095007004','095007',N'短信统计',1,273,454,'','/MasterData/System/MessageStatistics',null
union
select '095007005','095007',N'用户统计',1,275,455,'','/MasterData/System/UsersStatistics',null
union
select '095007006','095007',N'反馈信息',1,267,456,'','/MasterData/System/FeedbackManagement',null
union
select '095007007','095007',N'日志管理',1,3,457,'','/MasterData/System/LogManagement',null
union
select '100',null,N'订购系统（经销商）',1,1,1,'Main_OrderDistributor-1.png',null,null
union
select '100001','100',N'试剂订单',1,1,5,'',null,null
union
select '100002','100',N'订单发货查询',1,1,6,'',null,null
union
select '100003','100',N'产品价格查看',1,1,7,'',null,null
union
select '100004','100',N'FOC查询',1,1,8,'',null,null
union
select '100005','100',N'配件订单',1,1,9,'',null,null
union
select '100006','100',N'订单情况一览',1,1,10,'',null,null
union
select '105',null,N'销售库存（经销商）',1,1,40,'Main_SalesInventoryDistributor-1.png',null,null
union
select '105001','105',N'销售上传',1,1,45,'',null,null
union
select '105002','105',N'库存上传',1,1,46,'',null,null
union
select '105003','105',N'预测上传',1,1,47,'',null,null
union
select '110',null,N'ScoreCard经销商',1,1,80,'Main_ScoreCardDistributor-1.png',null,null
union
select '110001','110',N'经销商查看',1,1,85,'',null,null
union
select '110002','110',N'Performance',1,1,86,'',null,null
union
select '110003','110',N'Growth',1,1,87,'',null,null
union
select '110004','110',N'PL',1,1,88,'',null,null
union
select '115',null,N'评估系统（经销商）',1,1,120,'Main_Evaluate-1.png',null,null
union
select '115001','115',N'公式查看',1,1,125,'',null,null
union
select '115002','115',N'评估确认',1,1,126,'',null,null
union
select '115003','115',N'结果查看',1,1,127,'',null,null
union
select '120',null,N'CF经销商',1,1,160,'Main_CustomerFeedback-1.png',null,null
union
select '120001','120',N'CF填报',1,1,165,'',null,null
union
select '120002','120',N'已结案CF',1,1,166,'',null,null
union
select '125',null,N'公告发布（经销商）',1,1,200,'Main_Announcement-1.png',null,null
union
select '125001','125',N'即时消息',1,1,205,'',null,null
union
select '125002','125',N'信息提示栏',1,1,206,'',null,null
union
select '130',null,N'资料文档（经销商）',1,1,240,'Main_Document-1.png',null,null
union
select '130001','130',N'注册证',1,1,245,'',null,null
union
select '130002','130',N'LSS应用资料',1,1,246,'',null,null
union
select '130003','130',N'维修技术支持资料',1,1,247,'',null,null
union
select '130004','130',N'生命科学仪器报价',1,1,248,'',null,null
union
select '130005','130',N'颗粒特性仪器报价',1,1,249,'',null,null
union
select '130006','130',N'BCCE资质文件',1,1,250,'',null,null
union
select '135',null,N'FCPA经销商',1,1,280,'Main_FCPA-1.png',null,null
union
select '135001','135',N'FCPA证书',1,1,285,'',null,null
union
select '135002','135',N'FCPA组织架构图',1,1,286,'',null,null
union
select '900',null,N'用户管理',1,1,999,'Main_User-1.png','/User/Main/Index',null
go

-- 初始化角色信息(初始化角色不可删除)
set identity_insert master_RoleInfo ON 
go

insert into master_RoleInfo(RoleID,RoleName,RoleIntroduction,IsActive,RoleType)
select 1,N'系统管理员',N'内置系统管理员,拥有所有权限',1,0
union
select 2,N'基础数据模块管理员',N'贝克曼基础数据模块管理员，拥有所有贝克曼基础数据模块权限',1,0
union
select 3,N'订购系统模块管理员',N'贝克曼订购系统模块管理员，拥有所有贝克曼订购系统模块权限',1,0
union
select 4,N'销售库存模块管理员',N'贝克曼销售库存模块管理员，拥有所有贝克曼销售库存模块权限',1,0
union
select 5,N'评估系统模块管理员',N'贝克曼评估系统模块管理员，拥有所有贝克曼评估系统模块权限',1,0
union
select 6,N'资料文档模块管理员',N'贝克曼资料文档模块管理员，拥有所有贝克曼资料文档模块权限',1,0
union
select 7,N'公告发布模块管理员',N'贝克曼公告发布模块管理员，拥有所有贝克曼公告发布模块权限',1,0
union
select 8,N'CF模块管理员',N'贝克曼CF模块管理员，拥有所有贝克曼CF模块权限',1,0
union
select 9,N'ScoreCard模块管理员',N'贝克曼ScoreCard模块管理员，拥有所有贝克曼ScoreCard模块权限',1,0
union
select 10,N'FCPA模块管理员',N'贝克曼FCPA模块管理员，拥有所有贝克曼FCPA模块权限',1,0
union
select 11,N'报表系统模块管理员',N'贝克曼报表系统模块管理员，拥有所有贝克曼报表系统模块权限',1,0
union
select 12,N'合同管理模块管理员',N'贝克曼合同管理模块管理员，拥有所有贝克曼合同管理模块权限',1,0
union
select 13,N'租赁管理模块管理员',N'贝克曼租赁管理模块管理员，拥有所有贝克曼租赁管理模块权限',1,0
union
select 98,N'客户管理员',N'审核所有客户',1,0
union
select 99,N'运维管理员',N'运维管理员',1,0

go

set identity_insert master_RoleInfo OFF

go

--初始化部门信息
insert into master_DepartmentInfo(DepartName,DepartPath)
select N'贝克曼','/1/'

go

-- 初始化用户信息
set identity_insert master_UserInfo ON 
go

insert into master_UserInfo(UserID,DepartID,FullName,PhoneNumber,DynamicPassword,EffectiveTtime,Email,IsActive)
select 1,1,N'系统管理员','13166144432','123','2018-12-30','jimmy.shang@tcsoft.net.cn',1

go
set identity_insert master_UserInfo OFF

go

-- 初始化用户角色信息
insert into master_UserRoleInfo
select 1,1

go

-- 初始化角色权限
--系统管理员权限
insert into master_RoleAuthority(RoleID,StructureID,RoleButtonAuthority)
select 1,StructureID,BelongButton from dict_Structure
union
select 2,StructureID,BelongButton from dict_Structure where StructureID like '095%'
union
select 3,StructureID,BelongButton from dict_Structure where StructureID like '005%' or StructureID like '100%' or StructureID='095' or StructureID='095006' or StructureID='095006002'
union
select 4,StructureID,BelongButton from dict_Structure where StructureID like '015%' or StructureID like '105%' or StructureID='095' or StructureID='095006' or StructureID='095006002'
union
select 9,StructureID,BelongButton from dict_Structure where StructureID like '025%' or StructureID like '110%' or StructureID='095' or StructureID='095006' or StructureID='095006002'
union
select 5,StructureID,BelongButton from dict_Structure where StructureID like '035%' or StructureID like '115%' or StructureID='095' or StructureID='095006' or StructureID='095006002'
union
select 8,StructureID,BelongButton from dict_Structure where StructureID like '045%' or StructureID like '120%' or StructureID='095' or StructureID='095006' or StructureID='095006002'
union
select 7,StructureID,BelongButton from dict_Structure where StructureID like '055%' or StructureID like '125%' or StructureID='095' or StructureID='095006' or StructureID='095006002'
union
select 6,StructureID,BelongButton from dict_Structure where StructureID like '065%' or StructureID like '130%' or StructureID='095' or StructureID='095006' or StructureID='095006002'
union
select 10,StructureID,BelongButton from dict_Structure where StructureID like '075%' or StructureID like '135%' or StructureID='095' or StructureID='095006' or StructureID='095006002'
union
select 11,StructureID,BelongButton from dict_Structure where StructureID like '080%' or StructureID='095' or StructureID='095006' or StructureID='095006002'
union
select 12,StructureID,BelongButton from dict_Structure where StructureID like '085%' or StructureID='095' or StructureID='095006' or StructureID='095006002'
union
select 13,StructureID,BelongButton from dict_Structure where StructureID like '090%' or StructureID='095' or StructureID='095006' or StructureID='095006002'
union
select 98,StructureID,BelongButton from dict_Structure where StructureID like '095005%' or StructureID='095'
union
select 99,StructureID,BelongButton from dict_Structure where StructureID like '095007007%'or StructureID='095'or StructureID='095007'

go

-- 初始化用户权限
--系统管理员权限
insert into master_UserCustomerAuthority(UserID,StructureID,UserButtonAuthority)
select 1,StructureID,BelongButton from dict_Structure
go