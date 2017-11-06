using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.Services
{
    using AutoMapper;
    using TCSOFT.DMS.MasterData.DTO.Customer;
    using TCSOFT.DMS.MasterData.DTO.CustomerAudit;
    using TCSOFT.DMS.MasterData.DTO.ImportExcel;
    using TCSOFT.DMS.MasterData.Entities;
    using TCSOFT.DMS.MasterData.IServices;
    public class CustomerServices : BaseServices,ICustomerServices, IImportDataServices
    {
        #region 客户信息
        /// <summary>
        /// 得到客户信息列表（查询）
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public List<CustomerResultDTO> GetCustomerList(CustomerSearchDTO dto)
        {
            List<CustomerResultDTO> result = null;
            var tcdmse = SingleQueryObject.GetObj();

            var pp = tcdmse.master_CustomerInfo.AsNoTracking().Where(p => p.CustomerID != null);
            if (dto.CustomerID != null)
            {
                pp = pp.Where(p => p.CustomerID == dto.CustomerID);
            }
            else
            {
                if (!string.IsNullOrEmpty(dto.Province))
                {
                    pp = pp.Where(p => p.Province == dto.Province);
                    if (!string.IsNullOrEmpty(dto.City))
                    {
                        pp = pp.Where(p => p.City == dto.City);
                        if (!string.IsNullOrEmpty(dto.Country))
                        {
                            pp = pp.Where(p => p.Country == dto.Country);
                        }
                    }
                }
                if (!string.IsNullOrEmpty(dto.SearchText))
                {
                    pp = pp.Where(p => p.CustomerName.Contains(dto.SearchText) ||
                        p.master_DistributorInfo.DistributorName.Contains(dto.SearchText));
                }
            }
            dto.Count = pp.Count();
            pp = pp.OrderBy(m => m.CustomerName).ThenBy(m => m.CustomerID).Skip((dto.page - 1) * dto.rows).Take(dto.rows);
            result = Mapper.Map<List<master_CustomerInfo>, List<CustomerResultDTO>>(pp.ToList());

            return result;
        }
        /// <summary>
        /// 得到相似客户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public List<CustomerResultDTO> GetSimilarCustomerList(CustomerSearchDTO dto)
        {
            List<CustomerResultDTO> result = null;
            var tcdmse = SingleQueryObject.GetObj();

            var all = tcdmse.master_CustomerInfo.AsNoTracking().Where(p => p.CustomerID != null);
            if (!string.IsNullOrEmpty(dto.SearchText))
            {
                List<string> dict = new List<string>();
                int count = (int)Math.Ceiling(dto.SearchText.Length / 2.0);
                for (int i = 1; i <= count; i++)
                {
                    if (i == count)
                    {
                        dict.Add(dto.SearchText.Substring((i - 1) * 2));
                    }
                    else
                    {
                        dict.Add(dto.SearchText.Substring((i - 1) * 2, 2));
                    }
                }
                var filted = tcdmse.master_CustomerInfo.AsNoTracking().Where(p => p.CustomerID == null);
                foreach (var di in dict)
                {
                    filted = filted.Union(all.Where(p => p.CustomerName.Contains(di)));
                }
                dto.Count = filted.Count();
                filted = filted.OrderBy(m => m.CustomerName).ThenBy(m => m.CustomerID).Skip((dto.page - 1) * dto.rows).Take(dto.rows);
                result = Mapper.Map<List<master_CustomerInfo>, List<CustomerResultDTO>>(filted.ToList());
            }

            return result;
        }
        /// <summary>
        /// 新增客户信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool AddCustomer(CustomerOperateDTO dto)
        {
            bool result = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                master_CustomerInfo newitem = new master_CustomerInfo();

                Mapper.Map<CustomerOperateDTO, master_CustomerInfo>(dto, newitem);
                tcdmse.master_CustomerInfo.Add(newitem);
                // 记录日志
                this.AddLog(tcdmse, new LogData
                {
                    CurrentLogType = LogType.ADD,
                    LogDetails = "新增客户" + dto.CustomerName,
                    OpratorName = dto.CreateUser
                });
                result = tcdmse.SaveChanges() > 0;
            }

            return result;
        }
        /// <summary>
        /// 修改客户信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool UpdateCustomer(CustomerOperateDTO dto)
        {
            bool result = false;
            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_CustomerInfo.Where(p => p.CustomerID == dto.CustomerID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在！");
                }

                dto.CreateTime = pp.CreateTime;
                dto.CreateUser = pp.CreateUser;
                dto.NoActiveTime = pp.NoActiveTime;
                dto.NoActiveReason = pp.NoActiveReason;
                Mapper.Map<CustomerOperateDTO, master_CustomerInfo>(dto, pp);

                result = tcdmse.SaveChanges() > 0;
            }

            return result;
        }
        /// <summary>
        /// 删除客户信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool DeleteCustomer(CustomerOperateDTO dto)
        {
            bool result = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_CustomerInfo.Where(p => p.CustomerID == dto.CustomerID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在！");
                }
                tcdmse.master_CustomerInfo.Remove(pp);
                // 记录日志
                this.AddLog(tcdmse, new LogData
                {
                    CurrentLogType = LogType.DELETE,
                    LogDetails = "删除客户" + pp.CustomerName,
                    OpratorName = dto.ModifyUser
                });
                result = tcdmse.SaveChanges() > 0;
            }

            return result;
        }
        /// <summary>
        /// 停启用客户信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool ChangeStatusCustomer(CustomerOperateDTO dto)
        {
            bool result = false;
            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_CustomerInfo.Where(p => p.CustomerID == dto.CustomerID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在！");
                }
                if (pp.IsActive == null || pp.IsActive == false)
                {
                    pp.IsActive = true;
                    pp.NoActiveReason = null;
                    pp.NoActiveTime = null;
                }
                else
                {
                    pp.IsActive = false;
                    pp.NoActiveReason = dto.NoActiveReason;
                    pp.NoActiveTime = dto.NoActiveTime;
                }
                pp.ModifyTime = dto.ModifyTime;
                pp.ModifyUser = dto.ModifyUser;
                result = tcdmse.SaveChanges() > 0;
            }

            return result;
        }
        #endregion

        #region 客户审核
        /// <summary>
        /// 得到客户审核列表(查询)
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public List<CustomerAuditResultDTO> GetCustomerAuditList(CustomerAuditSearchDTO dto)
        {
            List<CustomerAuditResultDTO> result = null;
            var tcdmse = SingleQueryObject.GetObj();

            var pp = tcdmse.master_CustomerApplyInfo.AsNoTracking().Where(p => p.CustomerApplyID != null);
            if (dto.Status != null)
            {
                pp = pp.Where(p => p.Status == dto.Status);
            }

            if (!string.IsNullOrEmpty(dto.SearchText))
            {
                pp = pp.Where(p => p.CustomerName.Contains(dto.SearchText) ||
                    p.master_DistributorInfo.DistributorName.Contains(dto.SearchText));

            }
            dto.Count = pp.Count();
            pp = pp.OrderBy(m => m.CustomerName).ThenBy(m => m.CustomerApplyID).Skip((dto.page - 1) * dto.rows).Take(dto.rows);

            result = Mapper.Map<List<master_CustomerApplyInfo>, List<CustomerAuditResultDTO>>(pp.ToList());

            return result;
        }
        /// <summary>
        /// 客户信息审核成功
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool CustomerAuditSuccess(CustomerAuditOperateDTO dto)
        {
            bool result = false;
            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_CustomerApplyInfo.Where(p => p.CustomerApplyID == dto.CustomerApplyID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条申请信息不存在！");
                }
                pp.Auditor = dto.Auditor;
                pp.AuditReason = null;
                pp.AuditTime = dto.AuditTime;
                pp.ModifyTime = dto.ModifyTime;
                pp.ModifyUser = dto.ModifyUser;
                pp.Status = dto.Status;

                master_CustomerInfo newitem = new master_CustomerInfo()
                {
                    City = pp.City,
                    Country = pp.Country,
                    CreateTime = dto.ModifyTime,
                    CreateUser = dto.ModifyUser,
                    CustomerID = pp.CustomerApplyID,
                    CustomerName = pp.CustomerName,
                    DistributorID = pp.DistributorID,
                    IsActive = true,
                    Province = pp.Province,
                };

                tcdmse.master_CustomerInfo.Add(newitem);
                // 记录日志
                this.AddLog(tcdmse, new LogData
                {
                    CurrentLogType = LogType.ADD,
                    LogDetails = "新增客户" + newitem.CustomerName,
                    OpratorName = newitem.CreateUser
                });
                result = tcdmse.SaveChanges() > 0;
            }

            return result;
        }
        /// <summary>
        /// 客户信息审核失败
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool CustomerAuditFail(CustomerAuditOperateDTO dto)
        {
            bool result = false;
            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_CustomerApplyInfo.Where(p => p.CustomerApplyID == dto.CustomerApplyID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条申请信息不存在！");
                }
                pp.Auditor = dto.Auditor;
                pp.AuditTime = dto.AuditTime;
                pp.AuditReason = dto.AuditReason;
                pp.ModifyTime = dto.ModifyTime;
                pp.ModifyUser = dto.ModifyUser;
                pp.Status = dto.Status;

                result = tcdmse.SaveChanges() > 0;
            }

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
                    if (p is ExcelCustomerInfoDTO) 
                    {
                        ExcelCustomerInfoDTO exrdt = p as ExcelCustomerInfoDTO;
                        if (exrdt.UpLogic == 2)
                        {
                            var pp = tcdmse.master_CustomerInfo.Where(m => m.CustomerID == exrdt.CustomerID).FirstOrDefault();
                            pp.master_DistributorInfo = tcdmse.master_DistributorInfo.FirstOrDefault(g => g.DistributorName == exrdt.DistributorName);
                            pp.CustomerName = exrdt.CustomerName;
                            pp.Province = exrdt.Province;
                            pp.City = exrdt.City;
                            pp.OracleNO = exrdt.OracleNO;
                            pp.OracleName = exrdt.OracleName;
                            pp.XSWNO = exrdt.XSWNO;
                            pp.IsActive = true;
                            pp.ModifyUser = exrdt.Importer;
                            pp.ModifyTime = DateTime.Now;
                        }
                        else
                        {
                            master_CustomerInfo mprd = new master_CustomerInfo();
                            mprd.CustomerID = Guid.NewGuid();
                            mprd.master_DistributorInfo = tcdmse.master_DistributorInfo.FirstOrDefault(g => g.DistributorName == exrdt.DistributorName);
                            mprd.CustomerName = exrdt.CustomerName;
                            mprd.Province = exrdt.Province;
                            mprd.City = exrdt.City;
                            mprd.OracleNO = exrdt.OracleNO;
                            mprd.OracleName = exrdt.OracleName;
                            mprd.XSWNO = exrdt.XSWNO;
                            mprd.IsActive = true;
                            mprd.CreateUser = exrdt.Importer;
                            mprd.CreateTime = DateTime.Now;

                            tcdmse.master_CustomerInfo.Add(mprd);
                            // 记录日志
                            this.AddLog(tcdmse, new LogData
                            {
                                CurrentLogType = LogType.IMPORT,
                                LogDetails = "导入客户" + exrdt.CustomerName,
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
