using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace TCSOFT.DMS.MasterData.Services
{
    using IServices;
    using Entities;
    using DTO.Distributor.DistributorServiceType;
    using DTO.Distributor.Distributor;
    using DTO.Distributor.DistributorType;
    using AutoMapper;
    using DTO.Distributor.DistributorAnnounceAuthority;
    using DTO.Distributor.DistributorAuthority;
    using TCSOFT.DMS.MasterData.DTO.Distributor.DistributorPriceAuthority;
    using TCSOFT.DMS.MasterData.DTO.Product.OKCPriceInfo;
    using TCSOFT.DMS.MasterData.DTO.ImportExcel;
    using System.Data.Entity.Core.Objects;
    public class DistributorServices : BaseServices, IDistributorServices, IImportDataServices
    {
        #region 经销商类别
        /// <summary>
        /// 得到所有经销商类别
        /// </summary>
        /// <returns></returns>
        public List<DistributorTypeResultDTO> GetDistributorType(DistributorTypeSearchDTO dto)
        {
            List<DistributorTypeResultDTO> result = null;
            var tcdmse = SingleQueryObject.GetObj();

            var pp = tcdmse.master_DistributorType.AsNoTracking().Where(p => p.DistributorTypeID != null);
            if (dto.DistributorTypeID != null)
            {
                pp = pp.Where(p => p.DistributorTypeID == dto.DistributorTypeID);
            }

            result = Mapper.Map<List<master_DistributorType>, List<DistributorTypeResultDTO>>(pp.ToList());

            return result;
        }

        /// <summary>
        /// 经销商类别新增
        /// </summary>
        /// <returns></returns>
        public bool AddDistributorType(DistributorTypeOperateDTO dto)
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                master_DistributorType distype = new master_DistributorType();
                Mapper.Map<DistributorTypeOperateDTO, master_DistributorType>(dto, distype);

                tcdmse.master_DistributorType.Add(distype);
                // 记录日志
                this.AddLog(tcdmse, new LogData
                {
                    CurrentLogType = LogType.ADD,
                    LogDetails = "新增经销商类别" + dto.DistributorTypeName,
                    OpratorName = dto.CreateUser
                });
                blResult = tcdmse.SaveChanges() > 0;
            }

            return blResult;
        }
        /// <summary>
        /// 经销商类别修改
        /// </summary>
        /// <returns></returns>
        public bool UpdateDistributorType(DistributorTypeOperateDTO dto)
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_DistributorType.Where(p => p.DistributorTypeID == dto.DistributorTypeID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在！");
                }
                pp.DistributorTypeName = dto.DistributorTypeName;
                pp.ModifyUser = dto.ModifyUser;
                pp.ModifyTime = dto.ModifyTime;

                blResult = tcdmse.SaveChanges() > 0;
            }

            return blResult;
        }
        /// <summary>
        /// 经销商类别删除
        /// </summary>
        /// <returns></returns>
        public bool DeleteDistributorType(DistributorTypeOperateDTO dto)
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_DistributorType.Where(p => p.DistributorTypeID == dto.DistributorTypeID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在！");
                }
                if (pp.master_DistributorInfo.Count > 0)
                {
                    throw new Exception("此条信息已使用不可删除！");
                }

                tcdmse.master_DistributorType.Remove(pp);
                // 记录日志
                this.AddLog(tcdmse, new LogData
                {
                    CurrentLogType = LogType.DELETE,
                    LogDetails = "删除经销商类别" + pp.DistributorTypeName,
                    OpratorName = dto.ModifyUser
                });
                blResult = tcdmse.SaveChanges() > 0;
            }

            return blResult;
        }
        #endregion

        #region 经销商服务类型
        /// <summary>
        /// 得到所有经销商服务类型
        /// </summary>
        /// <returns></returns>
        public List<DistributorServiceTypeResultDTO> GetDistributorServiceType(DistributorServiceTypeSearchDTO dto)
        {
            List<DistributorServiceTypeResultDTO> result = null;
            var tcdmse = SingleQueryObject.GetObj();

            var pp = tcdmse.master_DistributorServiceType.AsNoTracking().Where(p => p.DistributorServiceTypeID != null);

            if (dto.DistributorServiceTypeID != null)
            {
                pp = pp.Where(p => p.DistributorServiceTypeID == dto.DistributorServiceTypeID);
            }
            result = Mapper.Map<List<master_DistributorServiceType>, List<DistributorServiceTypeResultDTO>>(pp.ToList());

            return result;
        }
        /// <summary>
        /// 经销商服务类型新增
        /// </summary>
        /// <returns></returns>
        public bool AddDistributorServiceType(DistributorServiceTypeOperateDTO dto)
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                master_DistributorServiceType distype = new master_DistributorServiceType();
                Mapper.Map<DistributorServiceTypeOperateDTO, master_DistributorServiceType>(dto, distype);

                tcdmse.master_DistributorServiceType.Add(distype);
                // 记录日志
                this.AddLog(tcdmse, new LogData
                {
                    CurrentLogType = LogType.ADD,
                    LogDetails = "新增经销商服务类型" + dto.DistributorServiceTypeName,
                    OpratorName = dto.CreateUser
                });
                blResult = tcdmse.SaveChanges() > 0;
            }

            return blResult;
        }
        /// <summary>
        /// 经销商服务类型修改
        /// </summary>
        /// <returns></returns>
        public bool UpdateDistributorServiceType(DistributorServiceTypeOperateDTO dto)
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_DistributorServiceType.Where(p => p.DistributorServiceTypeID == dto.DistributorServiceTypeID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在！");
                }
                pp.DistributorServiceTypeName = dto.DistributorServiceTypeName;
                pp.ModifyUser = dto.ModifyUser;
                pp.ModifyTime = dto.ModifyTime;

                blResult = tcdmse.SaveChanges() > 0;
            }

            return blResult;
        }
        /// <summary>
        /// 经销商服务类型删除
        /// </summary>
        /// <returns></returns>
        public bool DeleteDistributorServiceType(DistributorServiceTypeOperateDTO dto)
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_DistributorServiceType.Where(p => p.DistributorServiceTypeID == dto.DistributorServiceTypeID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在！");
                }
                if (pp.master_DistributorInfo.Count > 0)
                {
                    throw new Exception("此条信息已使用不可删除！");
                }

                tcdmse.master_DistributorServiceType.Remove(pp);
                // 记录日志
                this.AddLog(tcdmse, new LogData
                {
                    CurrentLogType = LogType.DELETE,
                    LogDetails = "删除经销商服务类型" + pp.DistributorServiceTypeName,
                    OpratorName = dto.ModifyUser
                });
                blResult = tcdmse.SaveChanges() > 0;
            }

            return blResult;
        }
        #endregion

        #region 经销商管理
        /// <summary>
        /// 得到经销商信息
        /// </summary>
        /// <returns></returns>
        public List<DistributorResultDTO> GetDistributorList(DistributorSearchDTO dto)
        {
            List<DistributorResultDTO> result = null;
            var tcdmse = SingleQueryObject.GetObj();

            var pp = tcdmse.master_DistributorInfo.AsNoTracking().Where(p => p.DistributorID != null);
            if (dto.DistributorID != null)
            {
                pp = pp.Where(p => p.DistributorID == dto.DistributorID);
            }
            if (dto.DistributorTypeID != null)
            {
                pp = pp.Where(p => p.DistributorTypeID == dto.DistributorTypeID);
            }
            if (dto.DistributorServiceTypeID != null)
            {
                pp = pp.Where(p => p.DistributorServiceTypeID == dto.DistributorServiceTypeID);
            }
            if (!string.IsNullOrEmpty(dto.SearchText))
            {
                pp = pp.Where(p => p.DistributorCode.Contains(dto.SearchText) || p.DistributorName.Contains(dto.SearchText) || p.master_DistributorType.DistributorTypeName.Contains(dto.SearchText));
            }
            if (dto.IsActive != null)
            {
                pp = pp.Where(p => p.IsActive == dto.IsActive);
            }

            dto.Count = pp.Count();
            pp = pp.OrderByDescending(m => m.IsActive).ThenBy(m => m.DistributorID).Skip((dto.page - 1) * dto.rows).Take(dto.rows);

            result = Mapper.Map<List<master_DistributorInfo>, List<DistributorResultDTO>>(pp.ToList());

            return result;
        }
        /// <summary>
        /// 得到经销商信息(开头字符为查询条件)
        /// </summary>
        /// <returns></returns>
        public List<DistributorBaseDTO> GetDistributorBaseInfoByName(string DistributorName)
        {
            List<DistributorBaseDTO> result = null;
            var tcdmse = SingleQueryObject.GetObj();

            if (!string.IsNullOrEmpty(DistributorName))
            {
                result = tcdmse.master_DistributorInfo.AsNoTracking().Where(m => m.DistributorName.StartsWith(DistributorName)).Take(15).Select(m => new DistributorBaseDTO
                {
                    DistributorID = m.DistributorID,
                    DistributorName = m.DistributorName
                }).ToList();
            }

            return result;
        }
        /// <summary>
        /// 新增经销商信息
        /// </summary>
        /// <returns></returns>
        public bool AddDistributor(DistributorOperateDTO dto)
        {
            bool result = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var newitem = new master_DistributorInfo();
                newitem = Mapper.Map<DistributorOperateDTO, master_DistributorInfo>(dto);
                tcdmse.master_DistributorInfo.Add(newitem);

                // 记录日志
                this.AddLog(tcdmse, new LogData
                {
                    CurrentLogType = LogType.ADD,
                    LogDetails = "新增经销商" + dto.DistributorName,
                    OpratorName = dto.CreateUser
                });

                result = tcdmse.SaveChanges() > 0;
            }

            return result;
        }
        /// <summary>
        /// 修改经销商信息
        /// </summary>
        /// <returns></returns>
        public bool UpdateDistributor(DistributorOperateDTO dto)
        {
            bool result = false;
            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_DistributorInfo.Where(p => p.DistributorID == dto.DistributorID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在！");
                }
                dto.IsActive = pp.IsActive;
                dto.CreateTime = pp.CreateTime;
                dto.CreateUser = pp.CreateUser;
                Mapper.Map<DistributorOperateDTO, master_DistributorInfo>(dto, pp);
                result = tcdmse.SaveChanges() > 0;
            }

            return result;
        }
        /// <summary>
        /// 删除经销商信息
        /// </summary>
        /// <returns></returns>
        public bool DeleteDistributor(DistributorOperateDTO dto)
        {
            bool result = false;
            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_DistributorInfo.Where(p => p.DistributorID == dto.DistributorID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在！");
                }
                tcdmse.master_DistributorInfo.Remove(pp);

                // 记录日志
                this.AddLog(tcdmse, new LogData
                {
                    CurrentLogType = LogType.DELETE,
                    LogDetails = "删除经销商" + pp.DistributorName,
                    OpratorName = dto.ModifyUser
                });

                result = tcdmse.SaveChanges() > 0;
            }

            return result;
        }
        /// <summary>
        /// 停/启用经销商
        /// </summary>
        /// <returns></returns>
        public bool StartOrStopDistributor(DistributorOperateDTO dto)
        {
            bool result = false;
            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_DistributorInfo.Where(p => p.DistributorID == dto.DistributorID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在！");
                }

                pp.IsActive = dto.IsActive;
                pp.NoActiveTime = dto.NoActiveTime;
                pp.NoActiveReason = dto.NoActiveReason;
                pp.ModifyTime = dto.ModifyTime;
                pp.ModifyUser = dto.ModifyUser;

                var qq = pp.master_UserInfo;
                if (dto.IsActive == true)
                {
                    foreach (var q in qq)
                    {
                        q.IsActive = dto.IsActive;
                    }
                }
                else
                {
                    foreach (var q in qq)
                    {
                        if (q.master_DistributorInfo.Where(w => w.IsActive == true).Count() == 0)
                        {
                            q.IsActive = dto.IsActive;
                        }
                    }
                }

                if (dto.IsActive == false)
                {
                    // 记录日志
                    this.AddLog(tcdmse, new LogData
                    {
                        CurrentLogType = LogType.UNENABLE,
                        LogDetails = "停用经销商" + pp.DistributorName,
                        OpratorName = dto.ModifyUser
                    });
                }



                result = tcdmse.SaveChanges() > 0;
            }

            return result;
        }
        /// <summary>
        /// 经销商更名
        /// </summary>
        /// <returns></returns>
        public bool DistributorChangeName(DistributorChangeNameDTO dto)
        {
            bool result = false;
            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                System.Data.SqlClient.SqlParameter[] parameters = { new System.Data.SqlClient.SqlParameter("@OleDis",dto.OleDepID),
                                                                      new System.Data.SqlClient.SqlParameter("@NewDis",dto.NewDepID),
                                                                      new System.Data.SqlClient.SqlParameter("@IsOKCPrice",dto.OKCPrice),
                                                                      new System.Data.SqlClient.SqlParameter("@IsPrediction",dto.Prediction),
                                                                      new System.Data.SqlClient.SqlParameter("@IsMessaging",dto.Messaging),
                                                                      new System.Data.SqlClient.SqlParameter("@IsSales",dto.Sales),
                                                                      new System.Data.SqlClient.SqlParameter("@IsInformation",dto.Information),
                                                                      new System.Data.SqlClient.SqlParameter("@IsInventory",dto.Inventory),
                                                                      new System.Data.SqlClient.SqlParameter("@IsProfileBulletin",dto.ProfileBulletin),
                                                                      new System.Data.SqlClient.SqlParameter("@IsGeneralContract",dto.GeneralContract),
                                                                      new System.Data.SqlClient.SqlParameter("@IsLeaseContract",dto.LeaseContract),
                                                                      new System.Data.SqlClient.SqlParameter("@IsPriceStatus",dto.PriceStatus),
                                                                      new System.Data.SqlClient.SqlParameter("@IsMinimumOrderQuantity",dto.MinimumOrderQuantity),
                                                                      new System.Data.SqlClient.SqlParameter("@IsMinimumOrderAmount",dto.MinimumOrderAmount),
                                                                      new System.Data.SqlClient.SqlParameter("@IsReactionCupBalance",dto.ReactionCupBalance),
                                                                      new System.Data.SqlClient.SqlParameter("@IsFOCBalance",dto.FOCBalance),
                                                                      new System.Data.SqlClient.SqlParameter("@IsInventoryInitialInventory",dto.InventoryInitialInventory),
                                                                      new System.Data.SqlClient.SqlParameter("@IsOK",0)
                                                                  };
                parameters[17].Direction = System.Data.ParameterDirection.Output;
                var slt = tcdmse.Database.SqlQuery<object>("exec proc_DistributorChangeName @OleDis,@NewDis" +
                    ",@IsOKCPrice,@IsPrediction,@IsMessaging,@IsSales,@IsInformation,@IsInventory" +
                    ",@IsProfileBulletin,@IsGeneralContract,@IsLeaseContract,@IsPriceStatus,@IsMinimumOrderQuantity" +
                    ",@IsMinimumOrderAmount,@IsReactionCupBalance,@IsFOCBalance,@IsInventoryInitialInventory" +
                    ",@IsOK output", parameters);
                slt.ToList();
                result = parameters[17].Value.ToString() == "1" ? true : false;
            }

            return result;
        }
        #endregion

        #region 经销商授权
        /// <summary>
        /// 得到经销商授权信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public List<DistributorAuthorityResultDTO> GetDistributorAuthority(DistributorAuthoritySearchDTO dto)
        {
            List<DistributorAuthorityResultDTO> result = null;
            var tcdmse = SingleQueryObject.GetObj();

            var pp = tcdmse.master_DistributorInfo.AsNoTracking().Where(p => p.DistributorID != null);
            if (dto.DistributorID != null)
            {
                pp = pp.Where(p => p.DistributorID == dto.DistributorID);
            }
            if (!string.IsNullOrEmpty(dto.SearchText))
            {
                pp = pp.Where(p => p.DistributorName.Contains(dto.SearchText));
            }

            result = Mapper.Map<List<master_DistributorInfo>, List<DistributorAuthorityResultDTO>>(pp.ToList());

            return result;
        }
        /// <summary>
        /// 得到经销商授权付款条款信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public List<DistributorPaymentResultDTO> GetDistributorAuthorityPay(DistributorAuthoritySearchDTO dto)
        {
            List<DistributorPaymentResultDTO> result = null;
            var tcdmse = SingleQueryObject.GetObj();

            var pp = tcdmse.master_DistributorPayInfo.AsNoTracking().Where(p => p.DistributorPayID != null);
            if (dto.DistributorID != null)
            {
                pp = pp.Where(p => p.DistributorID == dto.DistributorID);
            }

            result = Mapper.Map<List<master_DistributorPayInfo>, List<DistributorPaymentResultDTO>>(pp.ToList());

            return result;
        }
        /// <summary>
        /// 得到经销商授权运输方式信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public List<DistributorTransportResultDTO> GetDistributorAuthorityTransport(DistributorAuthoritySearchDTO dto)
        {
            List<DistributorTransportResultDTO> result = null;
            var tcdmse = SingleQueryObject.GetObj();

            var pp = tcdmse.master_DistributorTransport.AsNoTracking().Where(p => p.DistributorTransportID != null);
            if (dto.DistributorID != null)
            {
                pp = pp.Where(p => p.DistributorID == dto.DistributorID);
            }

            result = Mapper.Map<List<master_DistributorTransport>, List<DistributorTransportResultDTO>>(pp.ToList());

            return result;
        }
        /// <summary>
        /// 得到经销商授权产品线信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public List<DistributorProductLineResultDTO> GetDistributorAuthorityProductLine(DistributorAuthoritySearchDTO dto)
        {
            List<DistributorProductLineResultDTO> result = null;
            var tcdmse = SingleQueryObject.GetObj();

            var pp = tcdmse.master_DistributorProductLineInfo.AsNoTracking().Where(p => p.DistributorProductLineID != null);
            if (dto.DistributorID != null)
            {
                pp = pp.Where(p => p.DistributorID == dto.DistributorID);
            }

            dto.Count = pp.Count();
            pp = pp.OrderByDescending(m => m.CreateTime).Skip((dto.page - 1) * dto.rows).Take(dto.rows);

            result = Mapper.Map<List<master_DistributorProductLineInfo>, List<DistributorProductLineResultDTO>>(pp.ToList());

            return result;
        }
        /// <summary>
        /// 得到经销商授权产品线区域信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public List<DistributorRegionResultDTO> GetDistributorAuthorityRegion(DistributorAuthoritySearchDTO dto)
        {
            List<DistributorRegionResultDTO> result = null;
            var tcdmse = SingleQueryObject.GetObj();

            var pp = tcdmse.master_DistributorRegionInfo.AsNoTracking().Where(p => (dto.DistributorProductID == null ||
            p.master_DistributorProductLineInfo.DistributorProductLineID == dto.DistributorProductID));

            dto.Count = pp.Count();
            pp = pp.OrderByDescending(m => m.CreateTime).Skip((dto.page - 1) * dto.rows).Take(dto.rows);

            result = Mapper.Map<List<master_DistributorRegionInfo>, List<DistributorRegionResultDTO>>(pp.ToList());

            return result;
        }
        /// <summary>
        /// 授权经销商订货权限
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool DistributorOrderGoodsAuthority(DistributorAuthorityOperateDTO dto)
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_DistributorInfo.Where(p => p.DistributorID == dto.DistributorID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("该经销商已不存在");
                }
                pp.IsOrderGoods = dto.IsOrderGoods;
                pp.ModifyTime = dto.ModifyTime;
                pp.ModifyUser = dto.ModifyUser;

                blResult = tcdmse.SaveChanges() > 0;
            }

            return blResult;
        }
        /// <summary>
        /// 授权经销商付款条款
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool DistributorPayAuthority(DistributorAuthorityOperateDTO dto)
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_DistributorInfo.Where(p => p.DistributorID == dto.DistributorID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("该经销商已不存在");
                }
                if (dto.PayIDlist != null)
                {
                    foreach (var pay in dto.PayIDlist)
                    {
                        master_DistributorPayInfo dispay = new master_DistributorPayInfo();
                        dispay.PayID = pay;
                        dispay.DistributorID = pp.DistributorID;
                        tcdmse.master_DistributorPayInfo.Add(dispay);

                        var qq = tcdmse.master_PaymentInfo.Where(q => q.PayID == pay).Select(s => s.PayName).FirstOrDefault();
                        // 记录日志
                        this.AddLog(tcdmse, new LogData
                        {
                            CurrentLogType = LogType.ADD,
                            LogDetails = "经销商授权 经销商：" + pp.DistributorName + "授权付款条款：" + qq,
                            OpratorName = dto.CreateUser
                        });
                    }
                }

                blResult = tcdmse.SaveChanges() > 0;
            }

            return blResult;
        }
        /// <summary>
        /// 授权经销商运输方式
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool DistributorTransportAuthority(DistributorAuthorityOperateDTO dto)
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_DistributorInfo.Where(p => p.DistributorID == dto.DistributorID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("该经销商已不存在");
                }
                if (dto.TransportIDlist != null)
                {
                    foreach (var tra in dto.TransportIDlist)
                    {
                        master_DistributorTransport distar = new master_DistributorTransport();
                        distar.TransportID = tra;
                        distar.DistributorID = pp.DistributorID;
                        tcdmse.master_DistributorTransport.Add(distar);

                        var qq = tcdmse.master_TransportInfo.Where(q => q.TransportID == tra).Select(s => s.TransportName).FirstOrDefault();
                        // 记录日志
                        this.AddLog(tcdmse, new LogData
                        {
                            CurrentLogType = LogType.ADD,
                            LogDetails = "经销商授权 经销商：" + pp.DistributorName + "授权运输方式：" + qq,
                            OpratorName = dto.CreateUser
                        });
                    }
                }

                blResult = tcdmse.SaveChanges() > 0;
            }

            return blResult;
        }
        /// <summary>
        /// 授权经销商产品线
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool DistributorProductLineAuthority(DistributorAuthorityOperateDTO dto)
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_DistributorInfo.Where(p => p.DistributorID == dto.DistributorID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("该经销商已不存在");
                }
                foreach (var line in dto.ProductLineRegion)
                {
                    master_DistributorProductLineInfo displine = new master_DistributorProductLineInfo();
                    displine.DistributorID = pp.DistributorID;
                    displine.ProductLineID = line.ProductLineID;
                    tcdmse.master_DistributorProductLineInfo.Add(displine);

                    var qq = tcdmse.master_ProductLine.Where(q => q.ProductLineID == line.ProductLineID).Select(s => s.ProductLineName).FirstOrDefault();
                    // 记录日志
                    this.AddLog(tcdmse, new LogData
                    {
                        CurrentLogType = LogType.ADD,
                        LogDetails = "经销商授权 经销商：" + pp.DistributorName + "授权产品线：" + qq,
                        OpratorName = dto.CreateUser
                    });
                }

                blResult = tcdmse.SaveChanges() > 0;
            }

            return blResult;
        }
        /// <summary>
        /// 授权经销商产品线区域
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool DistributorProductLineRegionAuthority(DistributorAuthorityOperateDTO dto)
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_AreaInfo.ToList();
                foreach (var line in dto.ProductLineRegion)
                {
                    foreach (var r in line.Regionlist)
                    {
                        master_DistributorRegionInfo dr = new master_DistributorRegionInfo();
                        dr.DistributorProductLineID = line.DistributorProductLineID;
                        dr.RegionID = r.RegionID;
                        dr.DistrictID = r.DistrictID;
                        dr.AreaID = pp.Where(p => p.AreaID == r.DistrictID).Select(s => s.AreaPID).FirstOrDefault();
                        dr.DepartID = pp.Where(p => p.AreaID == dr.AreaID).Select(s => s.DepartID).FirstOrDefault();

                        tcdmse.master_DistributorRegionInfo.Add(dr);

                        var qq = tcdmse.master_DistributorProductLineInfo.Where(q => q.DistributorProductLineID == line.DistributorProductLineID).Select(s => s.master_DistributorInfo.DistributorName).FirstOrDefault();
                        var ww = tcdmse.dict_RegionInfo.Where(w => w.RegionID == r.RegionID).Select(s => s.RegionName).FirstOrDefault();
                        // 记录日志
                        this.AddLog(tcdmse, new LogData
                        {
                            CurrentLogType = LogType.ADD,
                            LogDetails = "经销商授权 经销商：" + qq + "授权区域：" + ww,
                            OpratorName = dto.CreateUser
                        });
                    }
                }

                blResult = tcdmse.SaveChanges() > 0;
            }

            return blResult;
        }
        /// <summary>
        /// 删除经销商付款条款
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool DeleteDistributorPayAuthority(DistributorAuthorityOperateDTO dto)
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var qq = tcdmse.master_DistributorPayInfo.Where(p => p.DistributorPayID == dto.DistributorPayID).FirstOrDefault();

                var mm = qq.master_DistributorInfo.DistributorName;
                var ww = qq.master_PaymentInfo.PayName;

                tcdmse.master_DistributorPayInfo.Remove(qq);

                // 记录日志
                this.AddLog(tcdmse, new LogData
                {
                    CurrentLogType = LogType.DELETE,
                    LogDetails = "删除授权付款条款 经销商：" + mm + "授权付款条款：" + ww,
                    OpratorName = dto.ModifyUser
                });

                blResult = tcdmse.SaveChanges() > 0;
            }

            return blResult;
        }
        /// <summary>
        /// 删除经销商运输方式
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool DeleteDistributorTransportAuthority(DistributorAuthorityOperateDTO dto)
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var qq = tcdmse.master_DistributorTransport.Where(p => p.DistributorTransportID == dto.DistributorTransportID).FirstOrDefault();

                var mm = qq.master_DistributorInfo.DistributorName;
                var ww = qq.master_TransportInfo.TransportName;

                tcdmse.master_DistributorTransport.Remove(qq);

                // 记录日志
                this.AddLog(tcdmse, new LogData
                {
                    CurrentLogType = LogType.DELETE,
                    LogDetails = "删除授权运输方式 经销商：" + mm + "授权运输方式：" + ww,
                    OpratorName = dto.ModifyUser
                });

                blResult = tcdmse.SaveChanges() > 0;
            }

            return blResult;
        }
        /// <summary>
        /// 删除经销商产品线
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool DeleteDistributorProductLineAuthority(DistributorAuthorityOperateDTO dto)
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var qq = tcdmse.master_DistributorProductLineInfo.Where(p => p.DistributorProductLineID == dto.DistributorProductLineID).FirstOrDefault();

                var mm = qq.master_DistributorInfo.DistributorName;
                var ww = qq.master_ProductLine.ProductLineName;

                tcdmse.master_DistributorRegionInfo.RemoveRange(qq.master_DistributorRegionInfo);
                tcdmse.master_DistributorProductLineInfo.Remove(qq);

                // 记录日志
                this.AddLog(tcdmse, new LogData
                {
                    CurrentLogType = LogType.DELETE,
                    LogDetails = "删除授权产品线 经销商：" + mm + "授权产品线：" + ww,
                    OpratorName = dto.ModifyUser
                });

                blResult = tcdmse.SaveChanges() > 0;
            }

            return blResult;
        }
        /// <summary>
        /// 删除经销商产品线区域
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool DeleteDistributorProductLineRegionAuthority(DistributorAuthorityOperateDTO dto)
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var qq = tcdmse.master_DistributorRegionInfo.Where(p => p.DistributorRegionID == dto.DistributorRegionID).FirstOrDefault();

                var mm = qq.master_DistributorProductLineInfo.master_DistributorInfo.DistributorName;
                var ww = tcdmse.dict_RegionInfo.Where(w => w.RegionID == qq.RegionID).Select(s => s.RegionName).FirstOrDefault();

                tcdmse.master_DistributorRegionInfo.Remove(qq);

                // 记录日志
                this.AddLog(tcdmse, new LogData
                {
                    CurrentLogType = LogType.DELETE,
                    LogDetails = "删除授权区域 经销商：" + mm + "授权区域：" + ww,
                    OpratorName = dto.ModifyUser
                });

                blResult = tcdmse.SaveChanges() > 0;
            }

            return blResult;
        }
        #endregion

        #region 经销商公告授权
        /// <summary>
        /// 得到经销商公告授权信息
        /// </summary>
        /// <returns></returns>
        public List<DistributorAnnounceAuthorityResultDTO> GetDistributorAnnounceAuthorityList(DistributorAnnounceAuthoritySearchDTO dto)
        {
            List<DistributorAnnounceAuthorityResultDTO> result = null;
            var tcdmse = SingleQueryObject.GetObj();

            var pp = tcdmse.master_DistributorInfo.AsNoTracking().Where(p => p.DistributorID != null);
            if (!string.IsNullOrEmpty(dto.SearchText))
            {
                pp = pp.Where(p => p.DistributorName.Contains(dto.SearchText));
            }
            dto.Count = pp.Count();
            pp = pp.OrderBy(m => m.DistributorCode).Skip((dto.page - 1) * dto.rows).Take(dto.rows);
            result = Mapper.Map<List<master_DistributorInfo>, List<DistributorAnnounceAuthorityResultDTO>>(pp.ToList());

            return result;
        }
        /// <summary>
        /// 新增经销商公告授权
        /// </summary>
        /// <returns></returns>
        public bool AddDistributorAnnounceAuthority(DistributorAnnounceAuthorityOperateDTO dto)
        {
            bool result = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_DistributorInfo.AsNoTracking().Where(p => p.DistributorID == dto.DistributorID).FirstOrDefault();
                if (pp == null)
                {
                    pp = tcdmse.master_DistributorInfo.Where(p => p.DistributorName == dto.DistributorName).FirstOrDefault();
                    if (pp == null)
                    {
                        throw new Exception("经销商不存在！");
                    }
                }
                var remove = tcdmse.master_DistributorADInfo.Where(p => p.DistributorID == pp.DistributorID);
                tcdmse.master_DistributorADInfo.RemoveRange(remove);
                if (dto.ProductLineIDList.Count > 0)
                {
                    foreach (var id in dto.ProductLineIDList)
                    {
                        master_DistributorADInfo newitem = new master_DistributorADInfo();
                        newitem.DistributorID = pp.DistributorID;
                        newitem.ProductLineID = id;
                        newitem.CreateTime = dto.CreateTime;
                        newitem.CreateUser = dto.CreateUser;
                        tcdmse.master_DistributorADInfo.Add(newitem);
                    }
                }

                result = tcdmse.SaveChanges() > 0;
            }

            return result;
        }
        #endregion

        #region 经销商价格授权
        /// <summary>
        /// 得到经销商OKC信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public List<DistributorOKCProduct> GetDisOKCList(DistributorPriceAuthoritySearchDTO dto)
        {
            List<DistributorOKCProduct> result = null;
            var tcdmse = SingleQueryObject.GetObj();

            var pp = tcdmse.master_DistributorOKCInfo.AsNoTracking().Where(p => p.DistributorOKCID != null);

            if (dto.DistributorID != null)
            {
                pp = pp.Where(p => p.DistributorID == dto.DistributorID);
            }
            if (!string.IsNullOrEmpty(dto.SearchText))
            {
                pp = pp.Where(p => p.master_OKCInfo.OKCNO.Contains(dto.SearchText));
            }

            dto.Count = pp.Count();
            pp = pp.OrderBy(o => o.OKCID).Skip((dto.page - 1) * dto.rows).Take(dto.rows);

            result = Mapper.Map<List<master_DistributorOKCInfo>, List<DistributorOKCProduct>>(pp.ToList());

            return result;
        }
        #endregion
        /// <summary>
        /// 导入数据
        /// </summary>
        /// <param name="impdto"></param>
        /// <returns></returns>
        public bool ImportData(List<ExcelImportDataDTO> impdtolst)
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                foreach (var p in impdtolst)
                {
                    if (p is ExcelDistributorDTO) // 判断是否为经销商信息
                    {
                        ExcelDistributorDTO exrdt = p as ExcelDistributorDTO;
                        if (exrdt.UpLogic == 2)
                        {
                            var pp = tcdmse.master_DistributorInfo.Where(m => m.DistributorID == exrdt.DistributorID).FirstOrDefault();
                            pp.IsActive = exrdt.IsActiveStr == "是" ? true : false;
                            pp.DistributorCode = exrdt.DistributorCode;
                            pp.DistributorTypeID = exrdt.DistributorTypeID;
                            pp.DistributorServiceTypeID = exrdt.DistributorServiceTypeID;
                            pp.RegionID = exrdt.RegionID;
                            pp.InvoiceCode = exrdt.InvoiceCode;
                            pp.DeliverCode = exrdt.DeliverCode;
                            pp.CSRNameReagent = exrdt.CSRNameReagent;
                            pp.CSRNameD = exrdt.CSRNameD;
                            pp.CSRNameB = exrdt.CSRNameB;
                            pp.Office = exrdt.Office;
                            pp.ModifyUser = exrdt.Importer;
                            pp.ModifyTime = DateTime.Now;
                        }
                        else
                        {
                            master_DistributorInfo mprd = new master_DistributorInfo();
                            mprd.DistributorID = Guid.NewGuid();
                            mprd.IsActive = exrdt.IsActiveStr == "启用" ? true : false;
                            mprd.DistributorCode = exrdt.DistributorCode;
                            mprd.DistributorName = exrdt.DistributorName;
                            mprd.DistributorTypeID = exrdt.DistributorTypeID;
                            mprd.DistributorServiceTypeID = exrdt.DistributorServiceTypeID;
                            mprd.RegionID = exrdt.RegionID;
                            mprd.InvoiceCode = exrdt.InvoiceCode;
                            mprd.DeliverCode = exrdt.DeliverCode;
                            mprd.CSRNameReagent = exrdt.CSRNameReagent;
                            mprd.CSRNameD = exrdt.CSRNameD;
                            mprd.CSRNameB = exrdt.CSRNameB;
                            mprd.Office = exrdt.Office;
                            mprd.CreateUser = exrdt.Importer;
                            mprd.CreateTime = DateTime.Now;

                            tcdmse.master_DistributorInfo.Add(mprd);

                            // 记录日志
                            this.AddLog(tcdmse, new LogData
                            {
                                CurrentLogType = LogType.IMPORT,
                                LogDetails = "导入经销商" + exrdt.DistributorName,
                                OpratorName = exrdt.Importer
                            });
                        }
                        
                    }
                    if (p is ExcelDistributorADAuthorityDTO) // 判断是否为经销商公告授权
                    {
                        ExcelDistributorADAuthorityDTO exrdt = p as ExcelDistributorADAuthorityDTO;
                        tcdmse.master_DistributorADInfo.RemoveRange(tcdmse.master_DistributorADInfo.Where(m => m.DistributorID == exrdt.DistributorID));
                        if (exrdt.ProductLineIDList != null && exrdt.ProductLineIDList.Count() > 0)
                        {
                            foreach (var productlineid in exrdt.ProductLineIDList)
                            {
                                master_DistributorADInfo mprd = new master_DistributorADInfo();
                                mprd.DistributorID = exrdt.DistributorID;
                                mprd.ProductLineID = productlineid;
                                mprd.CreateUser = exrdt.Importer;
                                mprd.CreateTime = DateTime.Now;

                                tcdmse.master_DistributorADInfo.Add(mprd);
                            }
                            // 记录日志
                            this.AddLog(tcdmse, new LogData
                            {
                                CurrentLogType = LogType.IMPORT,
                                LogDetails = "导入经销商公告授权，经销商：" + exrdt.DistributorName + "，产品线：" + exrdt.ProductLineName,
                                OpratorName = exrdt.Importer
                            });
                        }
                    }
                    if (p is ExcelDistributorAuthorityDTO) // 判断是否为经销商授权
                    {
                        ExcelDistributorAuthorityDTO exrdt = p as ExcelDistributorAuthorityDTO;
                        var pp = tcdmse.master_DistributorInfo.FirstOrDefault(g => g.DistributorName == exrdt.DistributorName);
                        if (pp != null)
                        {
                            pp.IsOrderGoods = exrdt.IsOrderGoodsstr == "是" ? true : false;
                            //付款条款
                            pp.master_DistributorPayInfo.Clear();
                            tcdmse.master_PaymentInfo.Where(w => exrdt.PayNamelist.Contains(w.PayName)).ToList().ForEach(f =>
                            {
                                pp.master_DistributorPayInfo.Add(new master_DistributorPayInfo
                                {
                                    PayID = f.PayID,
                                    DistributorID = pp.DistributorID
                                });
                            });
                            
                            //运输方式
                            pp.master_DistributorTransport.Clear();
                            tcdmse.master_TransportInfo.Where(w => exrdt.TransportNamelist.Contains(w.TransportName)).ToList().ForEach(f =>
                            {
                                pp.master_DistributorTransport.Add(new master_DistributorTransport
                                {
                                    TransportID = f.TransportID,
                                    DistributorID = pp.DistributorID
                                });
                            });

                            //产品线
                            var productline = tcdmse.master_ProductLine.Where(w => exrdt.ProductLineNamelist.Contains(w.ProductLineName)).ToList();
                            //取得省份到部门
                            pp.master_DistributorProductLineInfo.Clear();

                            var prolineregin = tcdmse.vw_DepartToRegion.Where(w => exrdt.RegionNamelist.Contains(w.RegionName)).ToList();
                            productline.ForEach(f =>
                            {
                                master_DistributorProductLineInfo proline = new master_DistributorProductLineInfo();
                                pp.master_DistributorProductLineInfo.Add(proline);
                                proline.ProductLineID = f.ProductLineID;
                                proline.DistributorID = pp.DistributorID;
                                //产品线区域
                                List<master_DistributorRegionInfo> disregionlist = new List<master_DistributorRegionInfo>();
                                proline.master_DistributorRegionInfo = disregionlist;
                                prolineregin.ForEach(pf =>
                                {
                                    master_DistributorRegionInfo disregion = new master_DistributorRegionInfo();
                                    disregionlist.Add(disregion);
                                    disregion.RegionID = pf.RegionID;
                                    disregion.DistrictID = pf.districtid;
                                    disregion.AreaID = pf.AreaID;
                                    disregion.DepartID = pf.DepartID;
                                });
                            });

                            // 记录日志
                            this.AddLog(tcdmse, new LogData
                            {
                                CurrentLogType = LogType.IMPORT,
                                LogDetails = "导入经销商授权：经销商：" + exrdt.DistributorName
                                            + "；授权付款条款：" + exrdt.PayNamestr +
                                            "；授权运输方式：" + exrdt.TransportNamestr +
                                            "；授权产品线" + exrdt.ProductLineNamestr +
                                            "；授权区域" + exrdt.RegionNamestr,
                                OpratorName = exrdt.Importer
                            });
                        }
                    }
                }

                blResult = tcdmse.SaveChanges() > 0;
            }

            return blResult;
        }
    }
}
