using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TCSOFT.DMS.MasterData.Services
{
    using AutoMapper;
    using DTO.Product.InstrumentType;
    using DTO.Product.ProductType;
    using DTO.Product.ProductSmallType;
    using IServices;
    using DTO.Product.ProductLine;
    using Entities;
    using DTO.Product.ProductPriceInfo;
    using DTO.Product.OKCPriceInfo;
    using DTO.Product.ProductInfo;
    using DTO.Product.ReagentInfo;
    using DTO.Product.ProductModel;
    using DTO.ImportExcel;
    public class ProductServices :BaseServices, IProductServices, IImportDataServices
    {
        #region 产品线
        /// <summary>
        /// 得到所有产品线信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public List<ProductLineResultDTO> GetProductLine(ProductLineSearchDTO dto)
        {
            List<ProductLineResultDTO> result = null;
            var tcdmse = SingleQueryObject.GetObj();

            var pp = tcdmse.master_ProductLine.AsNoTracking().Where(p => p.ProductLineID != null);
            if (dto != null)
            {
                if (dto.DistributorID != null)
                {
                    pp = pp.Where(p => p.master_DistributorProductLineInfo.Any(m => m.DistributorID == dto.DistributorID));
                }
                if (!string.IsNullOrEmpty(dto.SearchText))
                {
                    pp = pp.Where(p => p.ProductLineName.Contains(dto.SearchText) ||
                        p.ProductLineNameAB.Contains(dto.SearchText) ||
                        p.master_DepartmentInfo.DepartName.Contains(dto.SearchText)
                        );
                }
            }
            result = Mapper.Map<List<master_ProductLine>, List<ProductLineResultDTO>>(pp.ToList());

            return result;
        }
        /// <summary>
        /// 得到所有产品线基本信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public List<ProductLineBaseDTO> GetProductLineBaseInfo()
        {
            List<ProductLineBaseDTO> result = null;
            var tcdmse = SingleQueryObject.GetObj();

            result = tcdmse.master_ProductLine.AsNoTracking().Select(m => new ProductLineBaseDTO
            {
                ProductLineID = m.ProductLineID,
                ProductLineName = m.ProductLineName
            }).ToList();

            return result;
        }
        /// <summary>
        /// 得到一条产品线信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProductLineResultDTO GetOneProductLine(int id)
        {
            ProductLineResultDTO result = null;
            var tcdmse = SingleQueryObject.GetObj();

            var pp = tcdmse.master_ProductLine.AsNoTracking().Where(p => p.ProductLineID == id).FirstOrDefault();
            if (pp == null) 
            {
                throw new Exception("此条信息不存在！");
            }
            result = Mapper.Map<master_ProductLine, ProductLineResultDTO>(pp);

            return result;
        }
        /// <summary>
        /// 产品线新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool AddProductLine(ProductLineOperateDTO dto)
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var dumplicated = tcdmse.master_ProductLine.AsNoTracking().Where(p => p.ProductLineName == dto.ProductLineName).FirstOrDefault();
                if (dumplicated != null)
                {
                    throw new Exception("产品线不可同名！");
                }
                master_ProductLine proline = new master_ProductLine();
                Mapper.Map<ProductLineOperateDTO, master_ProductLine>(dto, proline);
                tcdmse.master_ProductLine.Add(proline);
                // 记录日志
                this.AddLog(tcdmse, new LogData
                {
                    CurrentLogType = LogType.ADD,
                    LogDetails = "新增产品线" + dto.ProductLineName,
                    OpratorName = dto.CreateUser
                });
                blResult = tcdmse.SaveChanges() > 0;
            }

            return blResult;
        }
        /// <summary>
        /// 产品线修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool UpdateProductLine(ProductLineOperateDTO dto)
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_ProductLine.Where(p => p.ProductLineID == dto.ProductLineID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在！");
                }
                var dumplicated = tcdmse.master_ProductLine.AsNoTracking().Where(p => p.ProductLineID!=pp.ProductLineID && p.ProductLineName == dto.ProductLineName).FirstOrDefault();
                if (dumplicated != null)
                {
                    throw new Exception("产品线不可同名！");
                }
                dto.CreateTime = pp.CreateTime;
                dto.CreateUser = pp.CreateUser;
                dto.IsActive = pp.IsActive;
                Mapper.Map<ProductLineOperateDTO, master_ProductLine>(dto, pp);

                blResult = tcdmse.SaveChanges() > 0;
            }

            return blResult;
        }
        /// <summary>
        /// 产品线删除
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool DeleteProductLine(ProductLineOperateDTO dto)
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_ProductLine.Where(p => p.ProductLineID == dto.ProductLineID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在！");
                }
                tcdmse.master_ProductLine.Remove(pp);
                // 记录日志
                this.AddLog(tcdmse, new LogData
                {
                    CurrentLogType = LogType.DELETE,
                    LogDetails = "删除产品线" + pp.ProductLineName,
                    OpratorName = dto.ModifyUser
                });
                blResult = tcdmse.SaveChanges() > 0;
            }

            return blResult;
        }
        /// <summary>
        /// 产品线停启用
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool StopEnableProductLine(ProductLineOperateDTO dto)
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_ProductLine.Where(p => p.ProductLineID == dto.ProductLineID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在！");
                }
                pp.IsActive = dto.IsActive;
                pp.ModifyUser = dto.ModifyUser;
                pp.ModifyTime = dto.ModifyTime;
                if (pp.IsActive==false)
                {
                    // 记录日志
                    this.AddLog(tcdmse, new LogData
                    {
                        CurrentLogType = LogType.UNENABLE,
                        LogDetails = "停用产品线" + pp.ProductLineName,
                        OpratorName = dto.ModifyUser
                    });
                }

                blResult = tcdmse.SaveChanges() > 0;
            }

            return blResult;
        }
        #endregion

        #region 产品小类
        /// <summary>
        /// 得到所有产品小类信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public List<ProductSmallTypeResultDTO> GetProductSmallType(ProductSmallTypeSearchDTO dto) 
        {
            List<ProductSmallTypeResultDTO> result = null;
            var tcdmse = SingleQueryObject.GetObj();

            var pp = tcdmse.master_ProductSmallType.AsNoTracking().Where(p => p.ProductSmallTypeID != null);
            if (dto != null)
            {
                if (dto.ProductLineID != null)
                {
                    pp = pp.Where(p => p.ProductLineID ==dto.ProductLineID);
                }
                if (!string.IsNullOrEmpty(dto.SearchText))
                {
                    pp = pp.Where(p => p.ProductSmallTypeName.Contains(dto.SearchText) ||
                        p.master_ProductLine.ProductLineName.Contains(dto.SearchText)
                        );
                }
            }
            result = Mapper.Map<List<master_ProductSmallType>, List<ProductSmallTypeResultDTO>>(pp.ToList());

            return result;
        }
        /// <summary>
        /// 得到产品小类基本信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public List<ProductSmallTypeBaseDTO> GetProductSmallTypeBaseInfo()
        {
            List<ProductSmallTypeBaseDTO> result = null;
            var tcdmse = SingleQueryObject.GetObj();

            result = tcdmse.master_ProductSmallType.AsNoTracking().Select(m => new ProductSmallTypeBaseDTO
            {
                ProductSmallTypeID = m.ProductSmallTypeID,
                ProductSmallTypeName = m.ProductSmallTypeName
            }).ToList();

            return result;
        }
        /// <summary>
        /// 得到一条产品小类信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProductSmallTypeResultDTO GetOneProductSmallType(int id) 
        {
            ProductSmallTypeResultDTO result = null;
            var tcdmse = SingleQueryObject.GetObj();

            var pp = tcdmse.master_ProductSmallType.AsNoTracking().Where(p => p.ProductSmallTypeID == id).FirstOrDefault();
            if (pp == null)
            {
                throw new Exception("此条信息不存在！");
            }
            result = Mapper.Map<master_ProductSmallType, ProductSmallTypeResultDTO>(pp);

            return result;
        }
        /// <summary>
        /// 产品小类新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool AddProductSmallType(ProductSmallTypeOperateDTO dto) 
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var dumplicated = tcdmse.master_ProductSmallType.AsNoTracking().Where(p => p.ProductSmallTypeName == dto.ProductSmallTypeName).FirstOrDefault();
                if (dumplicated != null)
                {
                    throw new Exception("产品小类不可同名！");
                }
                master_ProductSmallType prosmalltypr = new master_ProductSmallType();
                Mapper.Map<ProductSmallTypeOperateDTO, master_ProductSmallType>(dto, prosmalltypr);
                tcdmse.master_ProductSmallType.Add(prosmalltypr);
                // 记录日志
                this.AddLog(tcdmse, new LogData
                {
                    CurrentLogType = LogType.ADD,
                    LogDetails = "新增产品小类" + dto.ProductSmallTypeName,
                    OpratorName = dto.CreateUser
                });
                blResult = tcdmse.SaveChanges() > 0;
            }

            return blResult;
        }
        /// <summary>
        /// 产品小类修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool UpdateProductSmallType(ProductSmallTypeOperateDTO dto) 
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_ProductSmallType.Where(p => p.ProductSmallTypeID == dto.ProductSmallTypeID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在！");
                }
                var dumplicated = tcdmse.master_ProductSmallType.AsNoTracking().Where(p =>p.ProductSmallTypeID!=pp.ProductSmallTypeID && p.ProductSmallTypeName == dto.ProductSmallTypeName).FirstOrDefault();
                if (dumplicated != null)
                {
                    throw new Exception("产品小类不可同名！");
                }
                dto.CreateTime = pp.CreateTime;
                dto.CreateUser = pp.CreateUser;
                dto.IsActive = pp.IsActive;
                Mapper.Map<ProductSmallTypeOperateDTO, master_ProductSmallType>(dto, pp);

                blResult = tcdmse.SaveChanges() > 0;
            }

            return blResult;
        }
        /// <summary>
        /// 产品小类删除
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool DeleteProductSmallType(ProductSmallTypeOperateDTO dto)
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_ProductSmallType.Where(p => p.ProductSmallTypeID == dto.ProductSmallTypeID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在！");
                }
                if (pp.master_ProductInfo.Count > 0)
                {
                    throw new Exception("此条信息已被使用不可删除！");
                }
                tcdmse.master_ProductSmallType.Remove(pp);
                // 记录日志
                this.AddLog(tcdmse, new LogData
                {
                    CurrentLogType = LogType.DELETE,
                    LogDetails = "删除产品小类" + pp.ProductSmallTypeName,
                    OpratorName = dto.ModifyUser
                });
                blResult = tcdmse.SaveChanges() > 0;
            }

            return blResult;
        }
        /// <summary>
        /// 产品小类停启用
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool StopEnableProductSmallType(ProductSmallTypeOperateDTO dto)
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_ProductSmallType.Where(p => p.ProductSmallTypeID == dto.ProductSmallTypeID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在！");
                }
                pp.IsActive = dto.IsActive;
                pp.ModifyUser = dto.ModifyUser;
                pp.ModifyTime = dto.ModifyTime;
                if (pp.IsActive == false)
                {
                    // 记录日志
                    this.AddLog(tcdmse, new LogData
                    {
                        CurrentLogType = LogType.UNENABLE,
                        LogDetails = "停用产品小类" + pp.ProductSmallTypeName,
                        OpratorName = dto.ModifyUser
                    });
                }
                blResult = tcdmse.SaveChanges() > 0;
            }

            return blResult;
        }
        #endregion

        #region 产品型号(仪器型号)
        /// <summary>
        /// 得到所有产品型号信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public List<ProductModelResultDTO> GetProductModel(ProductModelSearchDTO dto)
        {
            List<ProductModelResultDTO> result = null;
            var tcdmse = SingleQueryObject.GetObj();

            var pp = tcdmse.master_ProductModel.AsNoTracking().Where(p => p.ProductModelID != null);
            if (dto != null)
            {
                if (!string.IsNullOrEmpty(dto.SearchText))
                {
                    pp = pp.Where(p => p.ProductModelName.Contains(dto.SearchText) ||
                        p.master_ProductLine.ProductLineName.Contains(dto.SearchText)
                        );
                }
            }
            result = Mapper.Map<List<master_ProductModel>, List<ProductModelResultDTO>>(pp.ToList());

            return result;
        }
        /// <summary>
        /// 得到一条产品型号信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProductModelResultDTO GetOneProductModel(int id)
        {
            ProductModelResultDTO result = null;
            var tcdmse = SingleQueryObject.GetObj();

            var pp = tcdmse.master_ProductModel.AsNoTracking().Where(p => p.ProductModelID == id).FirstOrDefault();
            if (pp == null)
            {
                throw new Exception("此条信息不存在！");
            }
            result = Mapper.Map<master_ProductModel, ProductModelResultDTO>(pp);

            return result;
        }
        /// <summary>
        /// 产品型号新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool AddProductModel(ProductModelOperateDTO dto)
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                master_ProductModel prosmalltypr = new master_ProductModel();
                Mapper.Map<ProductModelOperateDTO, master_ProductModel>(dto, prosmalltypr);
                tcdmse.master_ProductModel.Add(prosmalltypr);
                // 记录日志
                this.AddLog(tcdmse, new LogData
                {
                    CurrentLogType = LogType.ADD,
                    LogDetails = "新增仪器型号" + dto.ProductModelName,
                    OpratorName = dto.CreateUser
                });
                blResult = tcdmse.SaveChanges() > 0;
            }

            return blResult;
        }
        /// <summary>
        /// 产品型号修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool UpdateProductModel(ProductModelOperateDTO dto)
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_ProductModel.Where(p => p.ProductModelID == dto.ProductModelID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在！");
                }
                    dto.CreateTime = pp.CreateTime;
                    dto.CreateUser = pp.CreateUser;
                    dto.IsActive = pp.IsActive;
                Mapper.Map<ProductModelOperateDTO, master_ProductModel>(dto, pp);
                

                blResult = tcdmse.SaveChanges() > 0;
            }

            return blResult;
        }
        /// <summary>
        /// 产品型号删除
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool DeleteProductModel(ProductModelOperateDTO dto)
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_ProductModel.Where(p => p.ProductModelID == dto.ProductModelID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在！");
                }

                tcdmse.master_ProductModel.Remove(pp);
                // 记录日志
                this.AddLog(tcdmse, new LogData
                {
                    CurrentLogType = LogType.DELETE,
                    LogDetails = "删除仪器型号" + pp.ProductModelName,
                    OpratorName = dto.ModifyUser
                });
                blResult = tcdmse.SaveChanges() > 0;
            }

            return blResult;
        }
        /// <summary>
        /// 产品型号停启用
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool StopEnableProductModel(ProductModelOperateDTO dto)
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_ProductModel.Where(p => p.ProductModelID == dto.ProductModelID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在！");
                }
                    pp.IsActive = dto.IsActive;
                    pp.ModifyUser = dto.ModifyUser;
                    pp.ModifyTime = dto.ModifyTime;

                blResult = tcdmse.SaveChanges() > 0;
            }

            return blResult;
        }
        #endregion

        #region 维修产品清单
        /// <summary>
        /// 得到所有维修产品信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public List<ProductInfoResultDTO> GetMaintenanceInfo(ProductInfoSearchDTO dto)
        {
            List<ProductInfoResultDTO> result = null;
            var tcdmse = SingleQueryObject.GetObj();

            var pp = tcdmse.master_ProductInfo.AsNoTracking().Where(p => p.IsMaintenance == true);
            if (dto != null)
            {
                if (dto.ProductID != null)
                {
                    pp = pp.Where(p => p.ProductID == dto.ProductID);
                }
                else
                {
                    if (dto.ProductLineID != null)
                    {
                        pp = pp.Where(p => p.master_ProductLine.ProductLineID == dto.ProductLineID);
                    }
                    if (!string.IsNullOrEmpty(dto.SearchText))
                    {
                        pp = pp.Where(p => p.ArtNo.Contains(dto.SearchText) ||
                            p.ProductName.Contains(dto.SearchText) ||
                            p.master_ProductType.ProductTypeName.Contains(dto.SearchText) ||
                            p.master_ProductSmallType.ProductSmallTypeName.Contains(dto.SearchText));
                    }
                }
            }

            dto.Count = pp.Count();
            pp = pp.OrderByDescending(o => o.IsActive).ThenBy(o => o.ArtNo).ThenBy(o => o.ProductID).Skip((dto.page - 1) * dto.rows).Take(dto.rows);
            result = Mapper.Map<List<master_ProductInfo>, List<ProductInfoResultDTO>>(pp.ToList());

            return result;
        }
        /// <summary>
        /// 得到产品基本信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public List<ProductInfoBaseDTO> GetProductBaseInfo()
        {
            List<ProductInfoBaseDTO> result = null;
            var tcdmse = SingleQueryObject.GetObj();

            result = tcdmse.master_ProductInfo.AsNoTracking().Select(m => new ProductInfoBaseDTO
            {
                ProductID = m.ProductID,
                ArtNo = m.ArtNo,
                ProductLineID=m.ProductLineID,
                IsMaintenance=m.IsMaintenance
            }).ToList();

            return result;
        }
        /// <summary>
        /// 维修产品新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool AddMaintenanceInfo(ProductInfoOperateDTO dto)
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var dumplicated = tcdmse.master_ProductInfo.AsNoTracking().Where(p =>  p.ArtNo == dto.ArtNo).FirstOrDefault();
                if (dumplicated != null)
                {
                    throw new Exception("货号不可重复！");
                }
                master_ProductInfo proiofn = new master_ProductInfo();
                Mapper.Map<ProductInfoOperateDTO, master_ProductInfo>(dto, proiofn);
                tcdmse.master_ProductInfo.Add(proiofn);
                // 记录日志
                this.AddLog(tcdmse, new LogData
                {
                    CurrentLogType = LogType.ADD,
                    LogDetails = "新增维修产品" + dto.ProductName,
                    OpratorName = dto.CreateUser
                });

                blResult = tcdmse.SaveChanges() > 0;
            }

            return blResult;
        }
        /// <summary>
        /// 维修产品修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool UpdateMaintenanceInfo(ProductInfoOperateDTO dto)
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_ProductInfo.Where(p => p.ProductID == dto.ProductID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在！");
                }
                var dumplicated = tcdmse.master_ProductInfo.AsNoTracking().Where( p => p.ArtNo == dto.ArtNo && p.ProductID!=pp.ProductID).FirstOrDefault();
                if (dumplicated != null)
                {
                    throw new Exception("货号不可重复！");
                }
                dto.CreateUser = pp.CreateUser;
                dto.CreateTime = pp.CreateTime;
                dto.IsMaintenance = pp.IsMaintenance;
                dto.IsActive = pp.IsActive;
                dto.StopReason = pp.StopReason;
                Mapper.Map<ProductInfoOperateDTO, master_ProductInfo>(dto, pp);

                blResult = tcdmse.SaveChanges() > 0;
            }

            return blResult;
        }
        /// <summary>
        /// 维修产品删除
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool DeleteMaintenanceInfo(ProductInfoOperateDTO dto)
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_ProductInfo.Where(p => p.ProductID == dto.ProductID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在！");
                }
                if (pp.master_ProductPriceInfo.Count > 0)
                {
                    throw new Exception("此条信息已被使用不可删除！");
                }
                tcdmse.master_ProductInfo.Remove(pp);
                // 记录日志
                this.AddLog(tcdmse, new LogData
                {
                    CurrentLogType = LogType.DELETE,
                    LogDetails = "删除维修产品" + dto.ProductName,
                    OpratorName = dto.ModifyUser
                });
                blResult = tcdmse.SaveChanges() > 0;
            }

            return blResult;
        }
        /// <summary>
        /// 维修产品停启用
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool StopEnableMaintenanceInfo(ProductInfoOperateDTO dto) 
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_ProductInfo.Where(p => p.ProductID == dto.ProductID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在！");
                }
                if (pp.IsActive == null || pp.IsActive == false)
                {
                    pp.IsActive = true;
                    pp.StopReason = null;
                }
                else
                {
                    pp.IsActive = false;
                    pp.StopReason = dto.StopReason;
                }

                pp.ModifyUser = dto.ModifyUser;
                pp.ModifyTime = dto.ModifyTime;

                blResult = tcdmse.SaveChanges() > 0;
            }

            return blResult;
        }
        #endregion

        #region 维修产品价格
        /// <summary>
        /// 得到维修产品价格
        /// </summary>
        /// <returns></returns>
        public List<ProductPriceInfoResultDTO> GetMaintenancePrice(ProductPriceInfoSearchDTO dto)
        {
            List<ProductPriceInfoResultDTO> result = null;
            var tcdmse = SingleQueryObject.GetObj();
            var pp = from product in tcdmse.master_ProductInfo.AsNoTracking().Where(p => p.IsMaintenance == true &&
                (dto.ProductLineID == null ||
                p.ProductLineID == dto.ProductLineID) &&
                  (string.IsNullOrEmpty(dto.SearchText) ||
                  p.ArtNo.Contains(dto.SearchText) ||
                  p.ProductName.Contains(dto.SearchText)))
                     join price in tcdmse.master_ProductPriceInfo.AsNoTracking()
                     on product.ProductID equals price.ProductID into templist
                     from temp in templist.DefaultIfEmpty()
                     select new ProductPriceInfoResultDTO
                     {
                         Product = new ProductInfoResultDTO
                         {
                             IsActive = product.IsActive,
                             Is3C = product.Is3C,
                             ArtNo = product.ArtNo,
                             ProductID = product.ProductID,
                             ProductLineID = product.ProductLineID,
                             ProductLineName = product.master_ProductLine.ProductLineName,
                             ProductName = product.ProductName,
                         },
                         ProductPriceID = temp.ProductPriceID,
                         DNPPrice = temp.DNPPrice,
                         DNPPriceStart = temp.DNPPriceStart,
                         DNPPriceEnd = temp.DNPPriceEnd
                     };
            dto.Count = pp.Count();
            pp = pp.OrderBy(m => m.Product.ArtNo).Skip((dto.page - 1) * dto.rows).Take(dto.rows);

            result = pp.ToList();

            return result;
        }
        /// <summary>
        /// 修改维修产品价格
        /// </summary>
        /// <returns></returns>
        public bool UpdateMaintenancePrice(ProductPriceInfoOperateDTO dto)
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_ProductPriceInfo.Where(p => p.ProductPriceID == dto.ProductPriceID).FirstOrDefault();
                if (pp == null)
                {
                    master_ProductPriceInfo newitem = new master_ProductPriceInfo()
                    {
                        ProductID = dto.ProductID,
                        DNPPrice = dto.DNPPrice,
                        DNPPriceStart = dto.DNPPriceStart,
                        DNPPriceEnd = dto.DNPPriceEnd,
                        CreateTime = dto.ModifyTime,
                        CreateUser = dto.ModifyUser
                    };
                    tcdmse.master_ProductPriceInfo.Add(newitem);
                }
                else
                {
                    dto.ProductID = pp.ProductID;
                    dto.CreateUser = pp.CreateUser;
                    dto.CreateTime = pp.CreateTime;
                    Mapper.Map<ProductPriceInfoOperateDTO, master_ProductPriceInfo>(dto, pp);
                }
                

                blResult = tcdmse.SaveChanges() > 0;
            }

            return blResult;
        }
        /// <summary>
        /// 删除维修产品价格
        /// </summary>
        /// <returns></returns>
        public bool DeleteMaintenancePrice(ProductPriceInfoOperateDTO dto)
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_ProductPriceInfo.Where(p => p.ProductPriceID == dto.ProductPriceID).FirstOrDefault();
                if (pp == null) 
                {
                    throw new Exception("此条信息不存在！");
                }

                tcdmse.master_ProductPriceInfo.Remove(pp);

                blResult = tcdmse.SaveChanges() > 0;
            }

            return blResult;
        }
        #endregion

        #region 产品类型
        /// <summary>
        /// 得到产品类型
        /// </summary>
        /// <returns></returns>
        public List<ProductTypeResultDTO> GetProductTypeList(ProductTypeSearchDTO dto)
        {
            List<ProductTypeResultDTO> result = null;
            var tcdmse = SingleQueryObject.GetObj();

            var pp = tcdmse.master_ProductType.AsNoTracking().
                Where(p => (string.IsNullOrEmpty(dto.SearchText) ||
                (p.ProductTypeName.Contains(dto.SearchText) ||
                (p.OracleName.Contains(dto.SearchText)))));

            result = Mapper.Map<List<master_ProductType>, List<ProductTypeResultDTO>>(pp.ToList());

            return result;
        }
        /// <summary>
        /// 得到产品类型基本信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public List<ProductTypeBaseDTO> GetProductTypeBaseInfo()
        {
            List<ProductTypeBaseDTO> result = null;
            var tcdmse = SingleQueryObject.GetObj();

            result = tcdmse.master_ProductType.AsNoTracking().Select(m => new ProductTypeBaseDTO
            {
                ProductTypeID = m.ProductTypeID,
                ProductTypeName = m.ProductTypeName
            }).ToList();

            return result;
        }
        /// <summary>
        /// 得到一条产品类型
        /// </summary>
        /// <returns></returns>
        public ProductTypeResultDTO GetProductType(int id)
        {
            ProductTypeResultDTO result = null;
            var tcdmse = SingleQueryObject.GetObj();

            var pp = tcdmse.master_ProductType.AsNoTracking().
                Where(p =>p.ProductTypeID==id).FirstOrDefault();
            if (pp == null)
            {
                throw new Exception("此条信息不存在！");
            }
            result = Mapper.Map<master_ProductType, ProductTypeResultDTO>(pp);

            return result;
        }
        /// <summary>
        /// 新增产品类型
        /// </summary>
        /// <returns></returns>
        public bool AddProductType(ProductTypeOperateDTO dto)
        {
            bool result = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var dumplicated = tcdmse.master_ProductType.AsNoTracking().Where(p => p.ProductTypeName == dto.ProductTypeName).FirstOrDefault();
                if (dumplicated != null)
                {
                    throw new Exception("产品类型不可同名！");
                }
                var newitem = new master_ProductType();
                newitem = Mapper.Map<ProductTypeOperateDTO, master_ProductType>(dto);
                tcdmse.master_ProductType.Add(newitem);
                // 记录日志
                this.AddLog(tcdmse, new LogData
                {
                    CurrentLogType = LogType.ADD,
                    LogDetails = "新增产品类型" + dto.ProductTypeName,
                    OpratorName = dto.CreateUser
                });
                result = tcdmse.SaveChanges() > 0;
            }

            return result;
        }
        /// <summary>
        /// 修改产品类型
        /// </summary>
        /// <returns></returns>
        public bool UpdateProductType(ProductTypeOperateDTO dto)
        {
            bool result = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_ProductType.Where(p => p.ProductTypeID == dto.ProductTypeID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在！");
                }
                var dumplicated = tcdmse.master_ProductType.AsNoTracking().Where(p => p.ProductTypeName == dto.ProductTypeName && p.ProductTypeID!=pp.ProductTypeID).FirstOrDefault();
                if (dumplicated != null)
                {
                    throw new Exception("产品类型不可同名！");
                }
                dto.CreateTime = pp.CreateTime;
                dto.CreateUser = pp.CreateUser;
                Mapper.Map<ProductTypeOperateDTO, master_ProductType>(dto, pp);

                result = tcdmse.SaveChanges() > 0;
            }

            return result;
        }
        /// <summary>
        /// 删除产品类型
        /// </summary>
        /// <returns></returns>
        public bool DeleteProductType(ProductTypeSearchDTO dto)
        {
            bool result = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_ProductType.Where(p => p.ProductTypeID == dto.ProductTypeID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在！");
                }
                var used = pp.master_ProductInfo.FirstOrDefault();
                if (used != null)
                {
                    throw new Exception("此条信息已被使用不可删除！");
                }
                tcdmse.master_ProductType.Remove(pp);
                // 记录日志
                this.AddLog(tcdmse, new LogData
                {
                    CurrentLogType = LogType.DELETE,
                    LogDetails = "删除产品类型" + pp.ProductTypeName,
                    OpratorName = dto.ModifyUser
                });
                result = tcdmse.SaveChanges() > 0;
            }

            return result;
        }
        #endregion

        #region 仪器类型
        /// <summary>
        /// 得到仪器类型
        /// </summary>
        /// <returns></returns>
        public List<InstrumentTypeResultDTO> GetInstrumentTypeList()
        {
            List<InstrumentTypeResultDTO> result = null;
            var tcdmse = SingleQueryObject.GetObj();

            var pp = tcdmse.master_InstrumentType.AsNoTracking();

            result = Mapper.Map<List<master_InstrumentType>, List<InstrumentTypeResultDTO>>(pp.ToList());

            return result;
        }
        /// <summary>
        /// 得到一条仪器类型
        /// </summary>
        /// <returns></returns>
        public InstrumentTypeResultDTO GetInstrumentType(int id)
        {
            InstrumentTypeResultDTO result = null;
            var tcdmse = SingleQueryObject.GetObj();

            var pp = tcdmse.master_InstrumentType.AsNoTracking().
                Where(p => p.InstrumentTypeID == id).FirstOrDefault();
            if (pp == null)
            {
                throw new Exception("此条信息不存在！");
            }
            result = Mapper.Map<master_InstrumentType, InstrumentTypeResultDTO>(pp);

            return result;
        
        }
        /// <summary>
        /// 新增仪器类型
        /// </summary>
        /// <returns></returns>
        public bool AddInstrumentType(InstrumentTypeOperateDTO dto)
        {
            bool result = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var newitem = new master_InstrumentType();
                newitem = Mapper.Map<InstrumentTypeOperateDTO, master_InstrumentType>(dto);
                tcdmse.master_InstrumentType.Add(newitem);
                result = tcdmse.SaveChanges() > 0;
                // 记录日志
                this.AddLog(tcdmse, new LogData
                {
                    CurrentLogType = LogType.ADD,
                    LogDetails = "新增仪器类型" + dto.InstrumentTypeName,
                    OpratorName = dto.CreateUser
                });
            }

            return result;
        }
        /// <summary>
        /// 修改仪器类型
        /// </summary>
        /// <returns></returns>
        public bool UpdateInstrumentType(InstrumentTypeOperateDTO dto)
        {
            bool result = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_InstrumentType.Where(p => p.InstrumentTypeID == dto.InstrumentTypeID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在！");
                }

                dto.CreateTime = pp.CreateTime;
                dto.CreateUser = pp.CreateUser;
                Mapper.Map<InstrumentTypeOperateDTO, master_InstrumentType>(dto, pp);

                result = tcdmse.SaveChanges() > 0;
            }

            return result;
        }
        /// <summary>
        /// 删除仪器类型
        /// </summary>
        /// <returns></returns>
        public bool DeleteInstrumentType(InstrumentTypeSearchDTO dto)
        {
            bool result = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_InstrumentType.Where(p => p.InstrumentTypeID == dto.InstrumentTypeID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在！");
                }
                tcdmse.master_InstrumentType.Remove(pp);
                // 记录日志
                this.AddLog(tcdmse, new LogData
                {
                    CurrentLogType = LogType.DELETE,
                    LogDetails = "删除仪器类型" + pp.InstrumentTypeName,
                    OpratorName = dto.ModifyUser
                });
                result = tcdmse.SaveChanges() > 0;
            }

            return result;
        }
        #endregion

        #region 试剂产品清单
        /// <summary>
        /// 得到试剂产品清单
        /// </summary>
        /// <returns></returns>
        public List<ProductInfoResultDTO> GetReagentInfoList(ProductInfoSearchDTO dto)
        {
            List<ProductInfoResultDTO> result = null;
            var tcdmse = SingleQueryObject.GetObj();

            var pp = tcdmse.master_ProductInfo.AsNoTracking().Where(p => p.IsMaintenance == false);
            if (dto.ProductID != null) 
            {
                pp = pp.Where(p => p.ProductID == dto.ProductID);
            }
            if (dto.ProductLineID != null)
            {
                pp = pp.Where(p => p.ProductLineID == dto.ProductLineID);
            }
            if (!string.IsNullOrEmpty(dto.SearchText))
            {
                pp = pp.Where(p =>
                    (p.ArtNo.Contains(dto.SearchText) || p.ProductName.Contains(dto.SearchText) || p.ReagentSize.Contains(dto.SearchText)) ||
                    (p.master_ProductType.ProductTypeName.Contains(dto.SearchText)));
            }

            dto.Count = pp.Count();
            pp = pp.OrderByDescending(o => o.IsActive).ThenBy(o => o.ArtNo).ThenBy(o => o.ProductID).Skip((dto.page - 1) * dto.rows).Take(dto.rows);

            result = Mapper.Map<List<master_ProductInfo>, List<ProductInfoResultDTO>>(pp.ToList());

            return result;
        }
        /// <summary>
        /// 新增试剂产品
        /// </summary>
        /// <returns></returns>
        public bool AddReagentInfo(ProductInfoOperateDTO dto)
        {
            bool result = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_ProductInfo.Where(p => p.ArtNo == dto.ArtNo).FirstOrDefault();
                if (pp != null) 
                {
                    throw new Exception("货号不可重复！");
                }

                var ReagentInfo = new master_ProductInfo();
                ReagentInfo = Mapper.Map<ProductInfoOperateDTO, master_ProductInfo>(dto);
                tcdmse.master_ProductInfo.Add(ReagentInfo);
                // 记录日志
                this.AddLog(tcdmse, new LogData
                {
                    CurrentLogType = LogType.ADD,
                    LogDetails = "新增产品" + ReagentInfo.ProductName,
                    OpratorName = ReagentInfo.CreateUser
                });

                result = tcdmse.SaveChanges() > 0;
            }

            return result;
        }
        /// <summary>
        /// 修改试剂产品
        /// </summary>
        /// <returns></returns>
        public bool UpdateReagentInfo(ProductInfoOperateDTO dto)
        {
            bool result = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_ProductInfo.Where(p => p.ProductID == dto.ProductID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在！");
                }
                var qq = tcdmse.master_ProductInfo.Where(p => p.ProductID != dto.ProductID && p.ArtNo == dto.ArtNo).FirstOrDefault();
                if (qq != null)
                {
                    throw new Exception("货号不可重复！");
                }
                dto.IsActive = pp.IsActive;
                dto.IsMaintenance = pp.IsMaintenance;
                dto.StopReason = pp.StopReason;
                dto.CreateTime = pp.CreateTime;
                dto.CreateUser = pp.CreateUser;
                Mapper.Map<ProductInfoOperateDTO, master_ProductInfo>(dto, pp);

                result = tcdmse.SaveChanges() > 0;
            }

            return result;
        }
        /// <summary>
        /// 删除试剂产品
        /// </summary>
        /// <returns></returns>
        public bool DeleteReagentInfo(ProductInfoOperateDTO dto)
        {
            bool result = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_ProductInfo.Where(p => p.ProductID == dto.ProductID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在！");
                }
                if (pp.master_ProductOKCPriceInfo.Count > 0 || pp.master_ProductPriceInfo.Count>0)
                {
                    throw new Exception("此条信息已被使用不可删除！");
                }
                tcdmse.master_ProductInfo.Remove(pp);
                // 记录日志
                this.AddLog(tcdmse, new LogData
                {
                    CurrentLogType = LogType.DELETE,
                    LogDetails = "删除产品" + pp.ProductName,
                    OpratorName = dto.ModifyUser // 删除需要前台传入当前操作人给修改用户
                });

                result = tcdmse.SaveChanges() > 0;
            }

            return result;
        }
        /// <summary>
        /// 停/启用试剂产品
        /// </summary>
        /// <returns></returns>
        public bool StartOrStopReagentInfo(ProductInfoOperateDTO dto)
        {
            bool result = false;
            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_ProductInfo.Where(p => p.ProductID == dto.ProductID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在！");
                }

                pp.IsActive = dto.IsActive;
                pp.StopReason = dto.StopReason;
                pp.ModifyTime = dto.ModifyTime;
                pp.ModifyUser = dto.ModifyUser;
                result = tcdmse.SaveChanges() > 0;
            }

            return result;
        }
        #endregion

        #region 试剂产品价格
        /// <summary>
        /// 得到试剂产品价格
        /// </summary>
        /// <returns></returns>
        public List<ProductPriceInfoResultDTO> GetReagentPriceList(ProductPriceInfoSearchDTO dto)
        {
            List<ProductPriceInfoResultDTO> result = null;
            var tcdmse = SingleQueryObject.GetObj();
            var pp = from product in tcdmse.master_ProductInfo.AsNoTracking().Where(p => p.IsMaintenance == false &&
                (dto.ProductLineID == null ||
                p.ProductLineID == dto.ProductLineID) &&
                (string.IsNullOrEmpty(dto.SearchText) ||
                p.ArtNo.Contains(dto.SearchText) ||
                p.ProductName.Contains(dto.SearchText)))
                     join price in tcdmse.master_ProductPriceInfo.AsNoTracking()
                     on product.ProductID equals price.ProductID into templist
                     from temp in templist.DefaultIfEmpty()
                     select new ProductPriceInfoResultDTO
                     {
                         Product = new ProductInfoResultDTO
                         {
                             ArtNo = product.ArtNo,
                             ProductID = product.ProductID,
                             ProductLineID = product.ProductLineID,
                             ProductLineName = product.master_ProductLine.ProductLineName,
                             ProductName = product.ProductName,
                         },
                         ProductPriceID = temp.ProductPriceID,
                         DNPPrice = temp.DNPPrice,
                         DNPPriceStart = temp.DNPPriceStart,
                         DNPPriceEnd = temp.DNPPriceEnd
                     };

            dto.Count = pp.Count();
            pp = pp.OrderBy(m => m.Product.ArtNo).Skip((dto.page - 1) * dto.rows).Take(dto.rows);

            result = pp.ToList();

            return result;
        }
        /// <summary>
        /// 修改试剂产品价格
        /// </summary>
        /// <returns></returns>
        public bool UpdateReagentPrice(ProductPriceInfoOperateDTO dto)
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_ProductPriceInfo.Where(p => p.ProductPriceID == dto.ProductPriceID).FirstOrDefault();
                if (pp == null)
                {
                    master_ProductPriceInfo newitem = new master_ProductPriceInfo()
                    {
                        ProductID = dto.ProductID,
                        DNPPrice = dto.DNPPrice,
                        DNPPriceStart = dto.DNPPriceStart,
                        DNPPriceEnd = dto.DNPPriceEnd,
                        CreateTime = dto.ModifyTime,
                        CreateUser = dto.ModifyUser
                    };
                    tcdmse.master_ProductPriceInfo.Add(newitem);
                }
                else
                {
                    dto.ProductID = pp.ProductID;
                    dto.CreateUser = pp.CreateUser;
                    dto.CreateTime = pp.CreateTime;
                    Mapper.Map<ProductPriceInfoOperateDTO, master_ProductPriceInfo>(dto, pp);
                }
                
                blResult = tcdmse.SaveChanges() > 0;
            }

            return blResult;
        }
        /// <summary>
        /// 删除试剂产品价格
        /// </summary>
        /// <returns></returns>
        public bool DeleteReagentPrice(ProductPriceInfoOperateDTO dto)
        {
            bool blResult = false;

            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_ProductPriceInfo.Where(p => p.ProductPriceID == dto.ProductPriceID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在！");
                }
                tcdmse.master_ProductPriceInfo.Remove(pp);

                blResult = tcdmse.SaveChanges() > 0;
            }

            return blResult;
        }
        #endregion

        #region 产品特价
        /// <summary>
        /// 得到OKC信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public List<OKCPriceInfoResultDTO> GetOKCList(OKCPriceInfoSearchDTO dto)
        {
            List<OKCPriceInfoResultDTO> result = null;
            var tcdmse = SingleQueryObject.GetObj();

            var pp = tcdmse.master_OKCInfo.AsNoTracking().Where(p => p.OKCID != null);
            if (dto.OKCID != null) 
            {
                pp = pp.Where(p => p.OKCID == dto.OKCID);
            }
            if (dto.DistributorID != null)
            {
                pp = pp.Where(p => p.master_DistributorOKCInfo.Where(d => d.DistributorID == dto.DistributorID).Count() > 0);
            }
            if (!string.IsNullOrEmpty(dto.SearchText)) 
            {
                pp = pp.Where(p => p.OKCNO.Contains(dto.SearchText));
            }

            dto.Count = pp.Count();
            pp = pp.OrderBy(o => o.OKCNO).ThenBy(o => o.OKCID).Skip((dto.page - 1) * dto.rows).Take(dto.rows);

            result = Mapper.Map<List<master_OKCInfo>, List<OKCPriceInfoResultDTO>>(pp.ToList());

            return result;
        }
        /// <summary>
        /// 得到OKC产品价格
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public List<OKCProductResult> GetOKCPrice(OKCPriceInfoSearchDTO dto)
        {
            List<OKCProductResult> result = null;

            var tcdmse = SingleQueryObject.GetObj();

            var pp = tcdmse.master_ProductOKCPriceInfo.AsNoTracking().Where(p => p.ProductOKCPriceInfoID != null);

            if (dto.OKCID != null)
            {
                pp = pp.Where(p => p.OKCID == dto.OKCID);
            }
            if (!string.IsNullOrEmpty(dto.SearchText))
            {
                pp = pp.Where(p => p.master_ProductInfo.ArtNo.Contains(dto.SearchText) ||
                    p.master_ProductInfo.ProductName.Contains(dto.SearchText)
                    );
            }

            dto.Count = pp.Count();
            pp = pp.OrderBy(o => o.ProductOKCPriceInfoID).Skip((dto.page - 1) * dto.rows).Take(dto.rows);

            result = Mapper.Map<List<master_ProductOKCPriceInfo>, List<OKCProductResult>>(pp.ToList());

            return result;
        }
        /// <summary>
        /// 得到OKC经销商及最终客户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public List<OKCDistributorResult> GetOKCDistributor(OKCPriceInfoSearchDTO dto)
        {
            List<OKCDistributorResult> result = null;
            var tcdmse = SingleQueryObject.GetObj();

            var pp = tcdmse.master_DistributorOKCInfo.AsNoTracking().Where(p => p.DistributorOKCID != null);

            if (dto.OKCID != null)
            {
                pp = pp.Where(p => p.OKCID == dto.OKCID);
            }
            if (!string.IsNullOrEmpty(dto.SearchText))
            {
                pp = pp.Where(p => p.master_DistributorInfo.DistributorName.Contains(dto.SearchText));
            }

            dto.Count = pp.Count();
            pp = pp.OrderBy(o => o.DistributorOKCID).Skip((dto.page - 1) * dto.rows).Take(dto.rows);

            result = Mapper.Map<List<master_DistributorOKCInfo>, List<OKCDistributorResult>>(pp.ToList());

            return result;
        }
        /// <summary>
        /// 新增OKC号
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool AddOKC(OKCPriceInfoOperateDTO dto)
        {
            bool result = false;
            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_OKCInfo.Where(p => p.OKCNO == dto.OKCNO).FirstOrDefault();
                if (pp != null)
                {
                    throw new Exception("OKC号不可重复！");
                }
                master_OKCInfo okc = new master_OKCInfo();
                Mapper.Map<OKCPriceInfoOperateDTO, master_OKCInfo>(dto, okc);
                tcdmse.master_OKCInfo.Add(okc);

                result = tcdmse.SaveChanges() > 0;
            }
            return result;
        }
        /// <summary>
        /// 新增OKC产品特价
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool AddOKCProduct(OKCPriceInfoOperateDTO dto)
        {
            bool result = false;
            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                if (dto.ProductOKC != null) 
                {
                    foreach (var p in dto.ProductOKC)
                    {
                        master_ProductOKCPriceInfo okcpro = new master_ProductOKCPriceInfo();
                        Mapper.Map<OKCProductOperate, master_ProductOKCPriceInfo>(p, okcpro);
                        okcpro.OKCID = dto.OKCID;
                        tcdmse.master_ProductOKCPriceInfo.Add(okcpro);
                    }
                }

                result = tcdmse.SaveChanges() > 0;
            }
            return result;
        }
        /// <summary>
        /// 新增OKC经销商及最终客户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool AddOKCDepAndCus(OKCPriceInfoOperateDTO dto)
        {
            bool result = false;
            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                if (dto.DistributorOKC != null)
                {
                    foreach (var p in dto.DistributorOKC)
                    {
                        master_DistributorOKCInfo okcdepcus = new master_DistributorOKCInfo();
                        Mapper.Map<OKCDistributorOperate, master_DistributorOKCInfo>(p, okcdepcus);
                        okcdepcus.OKCID = dto.OKCID;
                        tcdmse.master_DistributorOKCInfo.Add(okcdepcus);

                        var pp = tcdmse.master_OKCInfo.Where(w => w.OKCID == dto.OKCID).Select(s => s.OKCNO).FirstOrDefault();
                        var qq = tcdmse.master_DistributorInfo.Where(w => p.DistributorID == w.DistributorID).Select(s => s.DistributorName).FirstOrDefault();
                        // 记录日志
                        this.AddLog(tcdmse, new LogData
                        {
                            CurrentLogType = LogType.ADD,
                            LogDetails = "新增OKC经销商：" + "经销商：" + qq + "；OKC：" + pp,
                            OpratorName = dto.CreateUser
                        });
                    }
                }

                result = tcdmse.SaveChanges() > 0;
            }
            return result;
        }
        /// <summary>
        /// 修改OKC
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool UpdateOKC(OKCPriceInfoOperateDTO dto)
        {
            bool result = false;
            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_OKCInfo.Where(p => p.OKCID == dto.OKCID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在！");
                }
                var qq = tcdmse.master_OKCInfo.Where(p => p.OKCID != dto.OKCID && p.OKCNO == dto.OKCNO);
                if (qq.Count() > 0) 
                {
                    throw new Exception("OKC号不可重复！");
                }
                pp.CreateTime = dto.CreateTime;
                pp.CreateUser = dto.CreateUser;
                Mapper.Map<OKCPriceInfoOperateDTO, master_OKCInfo>(dto, pp);

                result = tcdmse.SaveChanges() > 0;
            }
            return result;
        }
        /// <summary>
        /// 删除OKC
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool DeleteOKC(OKCPriceInfoOperateDTO dto)
        {
            bool result = false;
            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_OKCInfo.Where(p => p.OKCID == dto.OKCID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在！");
                }
                tcdmse.master_ProductOKCPriceInfo.RemoveRange(pp.master_ProductOKCPriceInfo);
                tcdmse.master_DistributorOKCInfo.RemoveRange(pp.master_DistributorOKCInfo);
                tcdmse.master_OKCInfo.Remove(pp);
                result = tcdmse.SaveChanges() > 0;
            }
            return result;
        }
        /// <summary>
        /// 删除OKC产品特价
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool DeleteOKCProduct(OKCPriceInfoOperateDTO dto)
        {
            bool result = false;
            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_ProductOKCPriceInfo.Where(p => p.ProductOKCPriceInfoID == dto.ProductOKCPriceInfoID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在！");
                }
                tcdmse.master_ProductOKCPriceInfo.Remove(pp);

                result = tcdmse.SaveChanges() > 0;
            }
            return result;
        }
        /// <summary>
        /// 删除OKC经销商及最终客户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool DeleteOKCDepAndCus(OKCPriceInfoOperateDTO dto)
        {
            bool result = false;
            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var pp = tcdmse.master_DistributorOKCInfo.Where(p => p.DistributorOKCID == dto.DistributorOKCID).FirstOrDefault();
                if (pp == null)
                {
                    throw new Exception("此条信息不存在！");
                }

                var mm = pp.master_OKCInfo.OKCNO;
                var ww = pp.master_DistributorInfo.DistributorName;

                tcdmse.master_DistributorOKCInfo.Remove(pp);

                // 记录日志
                this.AddLog(tcdmse, new LogData
                {
                    CurrentLogType = LogType.DELETE,
                    LogDetails = "删除OKC经销商：" + "经销商：" + ww + "；OKC：" + mm,
                    OpratorName = dto.ModifyUser
                });

                result = tcdmse.SaveChanges() > 0;
            }
            return result;
        }
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool OKCInfoInsert(OKCPriceInfoOperateDTO dto)
        {
            bool result = false;
            using (var tcdmse = new Entities.TCDMS_MasterDataEntities())
            {
                var OldPro = tcdmse.master_ProductInfo.Where(p => p.IsMaintenance == false && p.ArtNo == dto.OldArtNo).FirstOrDefault();
                if (OldPro == null) 
                {
                    throw new Exception("填写的旧货号为" + dto.OldArtNo + " ，旧OKC价格为" + dto.OldOKCPrice + "的产品特价中，旧货号不存在！");
                }
                var OldPrice = tcdmse.master_ProductOKCPriceInfo.Where(p => p.ProductID == OldPro.ProductID && p.ProductOKCPrice == dto.OldOKCPrice).FirstOrDefault();
                if (OldPrice == null)
                {
                    throw new Exception("填写的旧货号为" + dto.OldArtNo + " ，旧OKC价格为" + dto.OldOKCPrice + "的产品特价中，旧特价不存在！");
                }
                var NewPro = tcdmse.master_ProductInfo.Where(p => p.IsMaintenance == false && p.ArtNo == dto.NewArtNo).FirstOrDefault();
                if (NewPro == null)
                {
                    throw new Exception("填写的新货号为" + dto.NewArtNo + " ，新OKC价格为" + dto.NewOKCPrice + "的产品特价中，新货号不存在！");
                }
                var pp = tcdmse.master_ProductOKCPriceInfo.Where(p => p.ProductID == OldPro.ProductID && p.ProductOKCPrice == dto.OldOKCPrice);
                foreach (var q in pp)
                {
                    q.ProductID = NewPro.ProductID;
                    q.ProductOKCPrice = dto.NewOKCPrice;
                }

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
                    if (p is ExcelReagentProductDTO) // 判断是否为试剂产品
                    {
                        ExcelReagentProductDTO exrdt = p as ExcelReagentProductDTO;
                        
                        if (exrdt.UpLogic == 2)
                        {
                            var pp = tcdmse.master_ProductInfo.Where(m => m.ProductID == exrdt.ProductID).FirstOrDefault();
                            pp.ArtNo = exrdt.ArtNo;
                            pp.Is3C = false;
                            pp.IsActive = true;
                            pp.IsMaintenance = false;
                            pp.ModifyTime = DateTime.Now;
                            pp.ModifyUser = exrdt.Importer;
                            pp.ProductLineID = exrdt.ProductLineID;
                            pp.ProductName = exrdt.ProductName;
                            pp.ProductTypeID = exrdt.ProductTypeID;
                            pp.ReagentProject = exrdt.ReagentProject;
                            pp.ReagentSize = exrdt.ReagentSize;
                            pp.ReagentTest = exrdt.ReagentTest;
                            pp.RemarkDes = exrdt.RemarkDes;
                            pp.StopReason = null;
                        }
                        else
                        {
                            master_ProductInfo mprd = new master_ProductInfo();
                            mprd.ProductID = Guid.NewGuid();
                            mprd.ArtNo = exrdt.ArtNo;
                            mprd.ProductName = exrdt.ProductName;
                            mprd.ReagentSize = exrdt.ReagentSize;
                            mprd.ProductLineID = exrdt.ProductLineID;
                            mprd.ProductTypeID = exrdt.ProductTypeID;
                            mprd.ReagentProject = exrdt.ReagentProject;
                            mprd.ReagentTest = exrdt.ReagentTest;
                            mprd.RemarkDes = exrdt.RemarkDes;
                            mprd.Is3C = false;
                            mprd.IsActive = true;
                            mprd.IsMaintenance = false;
                            mprd.CreateUser = exrdt.Importer;
                            mprd.CreateTime = DateTime.Now;

                            tcdmse.master_ProductInfo.Add(mprd);
                            // 记录日志
                            this.AddLog(tcdmse, new LogData
                            {
                                CurrentLogType = LogType.IMPORT,
                                LogDetails = "导入产品" + exrdt.ProductName,
                                OpratorName = exrdt.Importer
                            });
                        }
                        
                    }

                    if (p is ExcelRepairProductDTO) // 判断是否为维修产品
                    {
                        ExcelRepairProductDTO exrdt = p as ExcelRepairProductDTO;
                        if (exrdt.UpLogic == 2)
                        {
                            var pp = tcdmse.master_ProductInfo.Where(m => m.ProductID == exrdt.ProductID).FirstOrDefault();
                            pp.ArtNo = exrdt.ArtNo;
                            pp.ProductName = exrdt.ProductName;
                            pp.ProductLineID = exrdt.ProductLineID;
                            pp.ProductTypeID = exrdt.ProductTypeID;
                            pp.ProductSmallTypeID = exrdt.ProductSmallTypeID;
                            pp.RemarkDes = exrdt.RemarkDes;
                            pp.Is3C = exrdt.Is3C;
                            pp.IsActive = exrdt.IsActive;
                            pp.IsMaintenance = true;
                            pp.ModifyTime = DateTime.Now;
                            pp.ModifyUser = exrdt.Importer;
                        }
                        else
                        {
                            master_ProductInfo mprd = new master_ProductInfo();
                            mprd.ProductID = Guid.NewGuid();
                            mprd.ArtNo = exrdt.ArtNo;
                            mprd.ProductName = exrdt.ProductName;
                            mprd.ProductLineID = exrdt.ProductLineID;
                            mprd.ProductTypeID = exrdt.ProductTypeID;
                            mprd.ProductSmallTypeID = exrdt.ProductSmallTypeID;
                            mprd.RemarkDes = exrdt.RemarkDes;
                            mprd.Is3C = exrdt.Is3C;
                            mprd.IsActive = exrdt.IsActive;
                            mprd.IsMaintenance = true;
                            mprd.CreateUser = exrdt.Importer;
                            mprd.CreateTime = DateTime.Now;

                            tcdmse.master_ProductInfo.Add(mprd);
                            // 记录日志
                            this.AddLog(tcdmse, new LogData
                            {
                                CurrentLogType = LogType.IMPORT,
                                LogDetails = "导入产品" + exrdt.ProductName,
                                OpratorName = exrdt.Importer
                            });
                        }
                        
                    }
                    if (p is ExcelRepairPriceDTO) // 判断是否为维修产品价格
                    {
                        ExcelRepairPriceDTO pst = p as ExcelRepairPriceDTO;
                        master_ProductPriceInfo newitem = new master_ProductPriceInfo();
                        newitem.DNPPrice = pst.DNPPrice;
                        newitem.DNPPriceStart = pst.DNPPriceStart;
                        newitem.DNPPriceEnd = pst.DNPPriceEnd;
                        newitem.ProductID = pst.ProductID;
                        newitem.CreateUser = pst.Importer;
                        newitem.CreateTime = DateTime.Now;

                        tcdmse.master_ProductPriceInfo.Add(newitem);
                        // 记录日志
                        this.AddLog(tcdmse, new LogData
                        {
                            CurrentLogType = LogType.IMPORT,
                            LogDetails = "导入产品价格 产品货号:" + pst.ArtNo,
                            OpratorName = pst.Importer
                        });
                    }
                    if (p is ExcelProductSpecialDTO) // 判断是否为试剂产品特价
                    {
                        ExcelProductSpecialDTO exprookc = p as ExcelProductSpecialDTO;
                        master_ProductOKCPriceInfo okcpro = new master_ProductOKCPriceInfo();
                        okcpro.master_ProductInfo = tcdmse.master_ProductInfo.FirstOrDefault(g => g.ArtNo == exprookc.ArtNo);
                        okcpro.ProductOKCPrice = decimal.Parse(exprookc.ProductOKCPrice);
                        okcpro.OKCID = exprookc.OKCID;
                        okcpro.CreateUser = exprookc.Importer;
                        okcpro.CreateTime = DateTime.Now;

                        tcdmse.master_ProductOKCPriceInfo.Add(okcpro);
                        // 记录日志
                        this.AddLog(tcdmse, new LogData
                        {
                            CurrentLogType = LogType.IMPORT,
                            LogDetails = "导入产品特价：货号为" + exprookc.ArtNo + "特价为" + exprookc.ProductOKCPrice,
                            OpratorName = exprookc.Importer
                        });
                    }
                    if (p is ExcelProductSmallClassDTO) // 判断是否为产品小类
                    {
                        ExcelProductSmallClassDTO pst = p as ExcelProductSmallClassDTO;
                        master_ProductSmallType newitem = new master_ProductSmallType();
                        newitem.ProductSmallTypeName = pst.ProductSmallTypeName;
                        newitem.master_ProductLine = tcdmse.master_ProductLine.FirstOrDefault(g => g.ProductLineName == pst.ProductLineName);
                        newitem.IsActive = true;
                        newitem.CreateUser = pst.Importer;
                        newitem.CreateTime = DateTime.Now;

                        tcdmse.master_ProductSmallType.Add(newitem);
                        // 记录日志
                        this.AddLog(tcdmse, new LogData
                        {
                            CurrentLogType = LogType.IMPORT,
                            LogDetails = "导入产品小类" + pst.ProductSmallTypeName,
                            OpratorName = pst.Importer
                        });
                    }
                    if (p is ExcelInstrumentModelDTO) // 判断是否为仪器类型
                    {
                        ExcelInstrumentModelDTO pst = p as ExcelInstrumentModelDTO;
                        master_ProductModel newitem = new master_ProductModel();
                        newitem.ProductModelName = pst.ProductModelName;
                        newitem.master_ProductLine = tcdmse.master_ProductLine.FirstOrDefault(g => g.ProductLineName == pst.ProductLineName);
                        newitem.IsActive = true;
                        newitem.CreateUser = pst.Importer;
                        newitem.CreateTime = DateTime.Now;

                        tcdmse.master_ProductModel.Add(newitem);
                        // 记录日志
                        this.AddLog(tcdmse, new LogData
                        {
                            CurrentLogType = LogType.IMPORT,
                            LogDetails = "导入仪器类型" + pst.ProductModelName,
                            OpratorName = pst.Importer
                        });
                    }
                    if (p is ExcelReagentPriceDTO)//判断产品价格 dr
                    {
                        ExcelReagentPriceDTO pst = p as ExcelReagentPriceDTO;
                        master_ProductPriceInfo newitme = new master_ProductPriceInfo();
                        newitme.ProductID = pst.ProductID;
                        newitme.DNPPrice =Convert.ToDecimal( pst.DNPPrice);
                        newitme.DNPPriceStart =Convert.ToDateTime( pst.DNPPriceStart);
                        newitme.DNPPriceEnd=Convert.ToDateTime(pst.DNPPriceEnd);
                        newitme.CreateTime=DateTime.Now;
                        newitme.CreateUser = pst.Importer;
                        tcdmse.master_ProductPriceInfo.Add(newitme);

                         //记录日志
                        this.AddLog(tcdmse, new LogData
                        {
                            CurrentLogType = LogType.IMPORT,
                            LogDetails = "导入产品价格 产品货号:" + pst.ArtNo + "：产品价格" + pst.DNPPrice,
                            OpratorName = pst.Importer
                        });
                       
                    }
                }

                blResult = tcdmse.SaveChanges() > 0;
            }

            return blResult;
        }
    }
}
