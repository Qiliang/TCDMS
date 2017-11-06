using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace TCSOFT.DMS.MasterData.Services
{
    using DTO.RateDTO;
    using MasterData.Entities;
    using MasterData.IServices;
    using DTO.AccountDate;
    using DTO.Transport;
    using DTO.Payment;
    using TCSOFT.DMS.MasterData.DTO.ImportExcel;
    public class BaseInfoServices : BaseServices, IImportDataServices, IBaseInfoServices
    {
        #region 汇率
        /// <summary>
        /// 得到所有汇率信息
        /// </summary>
        /// <returns></returns>
        public List<RateResultDTO> GetRateList()
        {
            List<RateResultDTO> result = null;
            var tcdmse = SingleQueryObject.GetObj();

            var pp = tcdmse.master_RateInfo.AsNoTracking();
            result = Mapper.Map<List<master_RateInfo>, List<RateResultDTO>>(pp.ToList());

            return result;
        }
        /// <summary>
        /// 得到一条汇率信息
        /// </summary>
        /// <returns></returns>
        public RateResultDTO GetRate(int id)
        {
            RateResultDTO result = null;
            var tcdmse = SingleQueryObject.GetObj();

            var pp = tcdmse.master_RateInfo.AsNoTracking().Where(p => p.RateID == id).FirstOrDefault();
            if (pp == null)
            {
                throw new Exception("此条信息不存在！");
            }
            result = Mapper.Map<master_RateInfo, RateResultDTO>(pp);

            return result;
        }
        /// <summary>
        /// 新增汇率信息
        /// </summary>
        /// <returns></returns>
        public bool AddRate(RateOperateDTO dto)
        {
            bool result = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var newitem = new master_RateInfo();
                newitem = Mapper.Map<RateOperateDTO, master_RateInfo>(dto);
                tcdmse.master_RateInfo.Add(newitem);
                result = tcdmse.SaveChanges() > 0;
            }

            return result;
        }
        /// <summary>
        /// 修改汇率信息
        /// </summary>
        /// <returns></returns>
        public bool UpdateRate(RateOperateDTO dto)
        {
            bool result = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_RateInfo.Where(p => p.RateID == dto.RateID).FirstOrDefault();

                if (pp == null)
                {
                    throw new Exception("此条信息不存在！");
                }
                dto.CreateTime = pp.CreateTime;
                dto.CreateUser = pp.CreateUser;
                Mapper.Map<RateOperateDTO, master_RateInfo>(dto, pp);
                result = tcdmse.SaveChanges() > 0;
            }

            return result;
        }
        /// <summary>
        /// 删除汇率信息
        /// </summary>
        /// <returns></returns>
        public bool DeleteRate(RateSearchDTO dto)
        {
            bool result = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_RateInfo.Where(p => p.RateID == dto.RateID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在！");
                }
                tcdmse.master_RateInfo.Remove(pp);
                result = tcdmse.SaveChanges() > 0;
            }

            return result;
        }
        #endregion
        #region 关账日
        /// <summary>
        /// 得到所有关账日信息
        /// </summary>
        /// <returns></returns>
        public List<AccountDateResultDTO> GetAccountDateList()
        {
            List<AccountDateResultDTO> result = null;
            var tcdmse = SingleQueryObject.GetObj();

            var pp = tcdmse.master_AccountDateInfo.AsNoTracking();
            result = Mapper.Map<List<master_AccountDateInfo>, List<AccountDateResultDTO>>(pp.OrderBy(o => o.AccountDateYear).ThenBy(o => o.CreateTime).ThenBy(o => o.AccountDateID).ToList());

            return result;
        }
        /// <summary>
        /// 得到一条关账日信息
        /// </summary>
        /// <returns></returns>
        public AccountDateResultDTO GetAccountDate(int id)
        {
            AccountDateResultDTO result = null;
            var tcdmse = SingleQueryObject.GetObj();

            var pp = tcdmse.master_AccountDateInfo.AsNoTracking().Where(p => p.AccountDateID == id).FirstOrDefault();

            if (pp == null)
            {
                throw new Exception("此条信息不存在！");
            }
            result = Mapper.Map<master_AccountDateInfo, AccountDateResultDTO>(pp);

            return result;
        }
        /// <summary>
        /// 新增关账日信息
        /// </summary>
        /// <returns></returns>
        public bool AddAccountDate(AccountDateOperateDTO dto)
        {
            bool result = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_AccountDateInfo.Where(p => p.AccountDateBelongModel == dto.AccountDateBelongModel && p.AccountDateYear == dto.AccountDateYear).FirstOrDefault();
                if (pp != null)
                {
                    throw new Exception("年份及模块不可重复！");
                }
                var newitem = new master_AccountDateInfo();
                newitem = Mapper.Map<AccountDateOperateDTO, master_AccountDateInfo>(dto);
                tcdmse.master_AccountDateInfo.Add(newitem);

                // 记录日志
                this.AddLog(tcdmse, new LogData
                {
                    CurrentLogType = LogType.ADD,
                    LogDetails = "新增关账日" + dto.AccountDateName,
                    OpratorName = dto.CreateUser
                });

                result = tcdmse.SaveChanges() > 0;
            }

            return result;
        }
        /// <summary>
        /// 修改关账日信息
        /// </summary>
        /// <returns></returns>
        public bool UpdateAccountDate(AccountDateOperateDTO dto)
        {
            bool result = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_AccountDateInfo.Where(p => p.AccountDateID == dto.AccountDateID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在！");
                }
                var qq = tcdmse.master_AccountDateInfo.Where(p => p.AccountDateID != dto.AccountDateID && p.AccountDateYear == dto.AccountDateYear && p.AccountDateBelongModel == dto.AccountDateBelongModel).FirstOrDefault();
                if (qq != null)
                {
                    throw new Exception("年份及模块不可重复！");
                }
                dto.CreateTime = pp.CreateTime;
                dto.CreateUser = pp.CreateUser;
                Mapper.Map<AccountDateOperateDTO, master_AccountDateInfo>(dto, pp);
                result = tcdmse.SaveChanges() > 0;
            }

            return result;
        }
        /// <summary>
        /// 删除关账日信息
        /// </summary>
        /// <returns></returns>
        public bool DeleteAccountDate(AccountDateSearchDTO dto)
        {
            bool result = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_AccountDateInfo.Where(p => p.AccountDateID == dto.AccountDateID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在！");
                }
                tcdmse.master_AccountDateInfo.Remove(pp);
                result = tcdmse.SaveChanges() > 0;
            }

            return result;
        }
      
        /// <summary>
        ///   //导入关帐日数据
        /// </summary>
        /// <param name="impdtolst"></param>
        /// <returns></returns>
        public bool ImportData(List<ExcelImportDataDTO> impdtolst)
        {
            bool blResult = false;
            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                foreach (var p in impdtolst)
                {
                    if (p is ExclCloseDataDTO)//判断是否是关帐日信息
                    {
                        ExclCloseDataDTO exrdt = p as ExclCloseDataDTO;
                        exrdt.AccountDateBelongModellist.ForEach(f =>
                        {
                            master_AccountDateInfo mprd = new master_AccountDateInfo();
                            mprd.AccountDateName = exrdt.AccountDateName;
                            mprd.AccountDateYear = Convert.ToInt16(exrdt.AccountDateYear);
                            mprd.AccountDatePlace = exrdt.AccountDatePlace;
                            //判断每个字符串传过来的值是否为空，如果为空，则当月日期为空。
                            if (!string.IsNullOrEmpty(exrdt.MonthDate))//一月
                            {
                                mprd.MonthDate = Convert.ToDateTime(exrdt.MonthDate);
                            }
                            else
                            {
                                mprd.MonthDate = null;
                            }

                            if (!string.IsNullOrEmpty(exrdt.FebDate))//二月
                            {
                                mprd.FebDate = Convert.ToDateTime(exrdt.FebDate);
                            }
                            else
                            {
                                mprd.FebDate = null;
                            }

                            if (!string.IsNullOrEmpty(exrdt.MarchDate))//三月
                            {
                                mprd.MarchDate = Convert.ToDateTime(exrdt.MarchDate);
                            }
                            else
                            {
                                mprd.MarchDate = null;
                            }

                            if (!string.IsNullOrEmpty(exrdt.AprilDate))//四月
                            {
                                mprd.AprilDate = Convert.ToDateTime(exrdt.AprilDate);
                            }
                            else
                            {
                                mprd.AprilDate = null;
                            }

                            if (!string.IsNullOrEmpty(exrdt.MayDate))//五月
                            {
                                mprd.MayDate = Convert.ToDateTime(exrdt.MayDate);
                            }
                            else
                            {
                                mprd.MayDate = null;
                            }


                            if (!string.IsNullOrEmpty(exrdt.JuneDate))//六月
                            {
                                mprd.JuneDate = Convert.ToDateTime(exrdt.JuneDate);
                            }
                            else
                            {
                                mprd.JuneDate = null;
                            }

                            if (!string.IsNullOrEmpty(exrdt.JulyDate))//七月
                            {
                                mprd.JulyDate = Convert.ToDateTime(exrdt.JulyDate);
                            }
                            else
                            {
                                mprd.JulyDate = null;
                            }

                            if (!string.IsNullOrEmpty(exrdt.AugustDate))//八月
                            {
                                mprd.AugustDate = Convert.ToDateTime(exrdt.AugustDate);
                            }
                            else
                            {
                                mprd.AugustDate = null;
                            }

                            if (!string.IsNullOrEmpty(exrdt.SepDate))//九月
                            {
                                mprd.SepDate = Convert.ToDateTime(exrdt.SepDate);
                            }
                            else
                            {
                                mprd.SepDate = null;
                            }

                            if (!string.IsNullOrEmpty(exrdt.OctDate))//十月
                            {
                                mprd.OctDate = Convert.ToDateTime(exrdt.OctDate);
                            }
                            else
                            {
                                mprd.OctDate = null;
                            }

                            if (!string.IsNullOrEmpty(exrdt.NovDate))//十一月
                            {
                                mprd.NovDate = Convert.ToDateTime(exrdt.NovDate);
                            }
                            else
                            {
                                mprd.NovDate = null;
                            }

                            if (!string.IsNullOrEmpty(exrdt.DecDate))//十二月
                            {
                                mprd.DecDate = Convert.ToDateTime(exrdt.DecDate);
                            }
                            else
                            {
                                mprd.DecDate = null;
                            }
                       
                          
                            mprd.CreateUser = p.Importer;
                            mprd.CreateTime = DateTime.Now;
                            mprd.ModifyTime = DateTime.Now;
                            mprd.ModifyUser = p.Importer;
                            mprd.AccountDateBelongModel = f;

                            tcdmse.master_AccountDateInfo.Add(mprd);
                        });
                    }
                }
                blResult = tcdmse.SaveChanges() > 0;
            }
            return blResult;
        }
        #endregion
        #region 运输方式
        /// <summary>
        /// 得到所有运输方式信息
        /// </summary>
        /// <returns></returns>
        public List<TransportResultDTO> GetTransport(TransportSearchDTO dto)
        {
            List<TransportResultDTO> result = null;
            var tcdmse = SingleQueryObject.GetObj();

            var pp = tcdmse.master_TransportInfo.AsNoTracking().Where(p => p.TransportID != null);
            if (dto.DistributorID != null)
            {
                pp = pp.Where(p => p.master_DistributorTransport.Any(m => m.DistributorID == dto.DistributorID));
            }
            result = Mapper.Map<List<master_TransportInfo>, List<TransportResultDTO>>(pp.ToList());

            return result;
        }
        /// <summary>
        /// 得到一条运输方式信息
        /// </summary>
        /// <returns></returns>
        public TransportResultDTO GetOneTransport(int id)
        {
            TransportResultDTO result = null;
            var tcdmse = SingleQueryObject.GetObj();

            var pp = tcdmse.master_TransportInfo.AsNoTracking().Where(p => p.TransportID == id).FirstOrDefault();
            if (pp != null)
            {
                result = Mapper.Map<master_TransportInfo, TransportResultDTO>(pp);
            }

            return result;
        }
        /// <summary>
        /// 运输方式新增
        /// </summary>
        /// <returns></returns>
        public bool AddTransport(TransportOperateDTO dto)
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                master_TransportInfo transport = new master_TransportInfo();
                var dumplicated = tcdmse.master_TransportInfo.AsNoTracking().Where(p => p.TransportName == dto.TransportName).FirstOrDefault();
                if (dumplicated != null)
                {
                    throw new Exception("运输方式名称不可同名！");
                }
                Mapper.Map<TransportOperateDTO, master_TransportInfo>(dto, transport);
                tcdmse.master_TransportInfo.Add(transport);
                // 记录日志
                this.AddLog(tcdmse, new LogData
                {
                    CurrentLogType = LogType.ADD,
                    LogDetails = "新增运输方式" + dto.TransportName,
                    OpratorName = dto.CreateUser
                });
                blResult = tcdmse.SaveChanges() > 0;
            }

            return blResult;
        }
        /// <summary>
        /// 运输方式修改
        /// </summary>
        /// <returns></returns>
        public bool UpdateTransport(TransportOperateDTO dto)
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_TransportInfo.Where(p => p.TransportID == dto.TransportID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在！");
                }

                var dumplicated = tcdmse.master_TransportInfo.AsNoTracking().Where(p => p.TransportName == dto.TransportName && p.TransportID != pp.TransportID).FirstOrDefault();
                if (dumplicated != null)
                {
                    throw new Exception("运输方式名称不可同名！");
                }
                if (pp != null)
                {
                    pp.TransportName = dto.TransportName;
                    pp.OrderType = dto.OrderType;
                    pp.ModifyUser = dto.ModifyUser;
                    pp.ModifyTime = dto.ModifyTime;
                }

                blResult = tcdmse.SaveChanges() > 0;
            }

            return blResult;
        }
        /// <summary>
        /// 运输方式停/启用
        /// </summary>
        /// <returns></returns>
        public bool StopEnableTransport(TransportOperateDTO dto)
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_TransportInfo.Where(p => p.TransportID == dto.TransportID).FirstOrDefault();
                if (pp != null)
                {
                    pp.TransportStatus = dto.TransportStatus;
                    pp.ModifyUser = dto.ModifyUser;
                    pp.ModifyTime = dto.ModifyTime;
                }

                blResult = tcdmse.SaveChanges() > 0;
            }

            return blResult;
        }
        #endregion
        #region 付款条款
        /// <summary>
        /// 得到所有付款条款信息
        /// </summary>
        /// <returns></returns>
        public List<PaymentResultDTO> GetPaymentList(PaymentSearchDTO dto)
        {
            List<PaymentResultDTO> result = null;
            var tcdmse = SingleQueryObject.GetObj();
            var pp = tcdmse.master_PaymentInfo.AsNoTracking().Where(p => p.PayID != null);
            if (dto.DistributorID != null)
            {
                pp = pp.Where(p => p.master_DistributorPayInfo.Any(m => m.DistributorID == dto.DistributorID));
            }
            if (!string.IsNullOrEmpty(dto.SearchText))
            {
                pp = pp.Where(p => (p.PayName.Contains(dto.SearchText) ||
                    (p.OracleName.Contains(dto.SearchText))));
            }

            result = Mapper.Map<List<master_PaymentInfo>, List<PaymentResultDTO>>(pp.ToList());

            return result;
        }
        /// <summary>
        /// 得到一条付款条款信息
        /// </summary>
        /// <returns></returns>
        public PaymentResultDTO GetPayment(int id)
        {
            PaymentResultDTO result = null;
            var tcdmse = SingleQueryObject.GetObj();

            var pp = tcdmse.master_PaymentInfo.AsNoTracking().Where(p => p.PayID == id).FirstOrDefault();
            if (pp == null)
            {
                throw new Exception("此条信息不存在！");
            }
            result = Mapper.Map<master_PaymentInfo, PaymentResultDTO>(pp);

            return result;
        }
        /// <summary>
        /// 新增付款条款信息
        /// </summary>
        /// <returns></returns>
        public bool AddPayment(PaymentOperateDTO dto)
        {
            bool result = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var dumplicated = tcdmse.master_PaymentInfo.AsNoTracking().Where(p => p.PayName == dto.PayName).FirstOrDefault();
                if (dumplicated != null)
                {
                    throw new Exception("付款条款不可同名！");
                }
                var newitem = new master_PaymentInfo();
                newitem = Mapper.Map<PaymentOperateDTO, master_PaymentInfo>(dto);
                tcdmse.master_PaymentInfo.Add(newitem);
                // 记录日志
                this.AddLog(tcdmse, new LogData
                {
                    CurrentLogType = LogType.ADD,
                    LogDetails = "新增付款条款" + dto.PayName,
                    OpratorName = dto.CreateUser
                });
                result = tcdmse.SaveChanges() > 0;
            }

            return result;
        }
        /// <summary>
        /// 修改付款条款信息
        /// </summary>
        /// <returns></returns>
        public bool UpdatePayment(PaymentOperateDTO dto)
        {
            bool result = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_PaymentInfo.Where(p => p.PayID == dto.PayID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在！");
                }
                var dumplicated = tcdmse.master_PaymentInfo.AsNoTracking().Where(p => p.PayName == dto.PayName && p.PayID!=pp.PayID).FirstOrDefault();
                if (dumplicated != null)
                {
                    throw new Exception("付款条款不可同名！");
                }
                dto.CreateTime = pp.CreateTime;
                dto.CreateUser = pp.CreateUser;
                Mapper.Map<PaymentOperateDTO, master_PaymentInfo>(dto, pp);

                result = tcdmse.SaveChanges() > 0;
            }

            return result;
        }
        /// <summary>
        /// 删除付款条款信息
        /// </summary>
        /// <returns></returns>
        public bool DeletePayment(PaymentSearchDTO dto)
        {
            bool result = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_PaymentInfo.Where(p => p.PayID == dto.PayID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在！");
                }
                tcdmse.master_PaymentInfo.Remove(pp);
                // 记录日志
                this.AddLog(tcdmse, new LogData
                {
                    CurrentLogType = LogType.DELETE,
                    LogDetails = "删除付款条款" + pp.PayName,
                    OpratorName = dto.ModifyUser
                });
                result = tcdmse.SaveChanges() > 0;
            }

            return result;
        }
        /// <summary>
        /// 停/启用付款条款信息
        /// </summary>
        /// <returns></returns>
        public bool StartOrStopPayment(PaymentOperateDTO dto)
        {
            bool result = false;
            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_PaymentInfo.Where(p => p.PayID == dto.PayID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在！");
                }
                if (pp.PayStatus == null || pp.PayStatus == false)
                {
                    pp.PayStatus = true;
                }
                else
                {
                    pp.PayStatus = false;
                }
                pp.ModifyTime = dto.ModifyTime;
                pp.ModifyUser = dto.ModifyUser;
                result = tcdmse.SaveChanges() > 0;
            }

            return result;
        }
        #endregion
    }
}
