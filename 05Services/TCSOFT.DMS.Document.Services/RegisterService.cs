using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCSOFT.DMS.Document.DTO;
using TCSOFT.DMS.Document.DTO.Register;
using TCSOFT.DMS.Document.Entities;
using TCSOFT.DMS.Document.IServices;

namespace TCSOFT.DMS.Document.Services
{
    public class RegisterService : BaseService, IRegisterService
    {
        /// <summary>
        /// 查询列表
        /// </summary>          
        public PageableDTO<RegisterResultDTO> Query(RegisterSearchDTO q)
        {
            if (q.PublishDateTo.HasValue)
            {
                q.PublishDateTo = new DateTime(q.PublishDateTo.Value.Year, q.PublishDateTo.Value.Month, q.PublishDateTo.Value.Day, 23, 59, 59);
            }
            var token = q.UserInfo as UserInfoDTO;
            q.InitQuery("PublishDate", false);
            return document.Document_Register
                .Where(p => string.IsNullOrEmpty(q.Search) ? true : (p.ProductNo.Contains(q.Search) || p.Title.Contains(q.Search) || p.Publisher.Contains(q.Search)))//货号、标题、发布人
                .Where(p => q.PublishDateFrom.HasValue ? p.PublishDate >= q.PublishDateFrom : true)
                .Where(p => q.PublishDateTo.HasValue ? p.PublishDate <= q.PublishDateTo : true)
                .Where(p => q.ProductTypeID > 0 ? p.ProductTypeID == q.ProductTypeID : true)
                .Where(p => q.ProductLineID > 0 ? p.ProductLineID == q.ProductLineID : true)
                .Where(p => token.UserType != 2 ? true : token.ProductLineIDs.Contains(p.ProductLineID.Value))
                .Select(p => new RegisterResultDTO
                {
                    RegisterID = p.RegisterID,
                    ProductLineID = p.ProductLineID,
                    ProductTypeID = p.ProductTypeID,
                    ProductTypeName = p.ProductTypeName,
                    ProductLineName = p.ProductLineName,
                    ProductNo = p.ProductNo,
                    Title = p.Title,
                    ValidDate = p.ValidDate,
                    Publisher = p.Publisher,
                    PublishDate = p.PublishDate,
                    UpdateDate = p.UpdateDate,
                    IsDownload = p.Document_RegisterAttachment.All(att => att.Document_RegisterAttachmentDownload.Count > 0 && att.Document_RegisterAttachmentDownload.All(down => down.IsDownload == true && down.UserID==token.UserID)),
                    Attachments = p.Document_RegisterAttachment.Select(att => new RegisterAttachmentDTO
                    {
                        AttachmentID = att.AttachmentID,
                        AttachmentName = att.AttachmentName,
                        AttachmentSize = att.AttachmentSize
                    })

                }).ToPageable(q);
        }

        public RegisterResultDTO Get(Guid id)
        {
            var p = document.Document_Register.Find(id);
            return new RegisterResultDTO
            {
                RegisterID = p.RegisterID,
                ProductLineID = p.ProductLineID,
                ProductTypeID = p.ProductTypeID,
                ProductTypeName = p.ProductTypeName,
                ProductLineName = p.ProductLineName,
                ProductNo = p.ProductNo,
                Title = p.Title,
                ValidDate = p.ValidDate,
                Publisher = p.Publisher,
                PublishDate = p.PublishDate,
                UpdateDate = p.UpdateDate,
               // IsDownload = p.Document_RegisterAttachment.All(att => att.Document_RegisterAttachmentDownload.All(down => down.IsDownload == true)),
                Attachments = p.Document_RegisterAttachment.Select(att => new RegisterAttachmentDTO
                {
                    AttachmentID = att.AttachmentID,
                    AttachmentName = att.AttachmentName,
                    AttachmentSize = att.AttachmentSize
                })
            };
        }


        /// <summary>
        /// 添加
        /// </summary>     

        public DocumentResultDTO Add(RegisterAddDTO model)
        {
            try
            {
                var token = model.UserInfo as UserInfoDTO;
                var entity = new Document_Register
                {
                    RegisterID = Guid.NewGuid(),
                    ProductTypeID = model.ProductTypeID,
                    ProductTypeName = model.ProductTypeName,
                    ProductLineID = model.ProductLineID,
                    ProductLineName = model.ProductLineName,
                    ProductNo = model.ProductNo,
                    Title = model.Title,
                    ValidDate = model.ValidDate,
                    PublisherID = token.UserID,
                    Publisher = token.FullName,
                    PublishDate = DateTime.Now,
                    UpdateDate = null,
                };
                if (model.AttachmentIDs != null)
                {
                    document.Document_RegisterAttachment.AddRange(model.AttachmentIDs.Select(p => new Document_RegisterAttachment
                    {
                        AttachmentID = p.AttachmentID,
                        AttachmentName = p.AttachmentName,
                        AttachmentSize = p.AttachmentSize,
                        RegisterID = entity.RegisterID
                    }));
                    document.SaveChanges();
                }

                document.Document_Register.Add(entity);
                document.SaveChanges();
                return new DocumentResultDTO { success = true };
            }
            catch (Exception ex)
            {
                return new DocumentResultDTO { success = false, message = ex.Message };
            }


        }


        /// <summary>
        /// 修改
        /// </summary> 
        public DocumentResultDTO Update(RegisterUpdateDTO model)
        {
            try
            {
                var token = model.UserInfo as UserInfoDTO;
                var entity = document.Document_Register.FirstOrDefault(p => p.RegisterID == model.RegisterID);
                if (!string.IsNullOrWhiteSpace(model.Title)) entity.Title = model.Title;
                if (model.ProductTypeID.HasValue && !string.IsNullOrWhiteSpace(model.ProductTypeName))
                {
                    entity.ProductTypeID = model.ProductTypeID;
                    entity.ProductTypeName = model.ProductTypeName;
                }
                if (model.ProductLineID.HasValue && !string.IsNullOrWhiteSpace(model.ProductLineName))
                {
                    entity.ProductLineID = model.ProductLineID;
                    entity.ProductLineName = model.ProductLineName;
                }
                if (!string.IsNullOrWhiteSpace(model.ProductNo)) entity.ProductNo = model.ProductNo;
                if (model.ValidDate.HasValue) entity.ValidDate = model.ValidDate;
                entity.PublisherID = token.UserID;
                entity.Publisher = token.FullName;
                entity.UpdateDate = DateTime.Now;

                if (model.DeleteAttachmentIDs != null)
                {
                    model.DeleteAttachmentIDs.ForEach(p =>
                    {
                        var att = document.Document_RegisterAttachment.Find(p);
                        if (att == null) return;
                        document.Document_RegisterAttachmentDownload.RemoveRange(att.Document_RegisterAttachmentDownload);
                        document.Document_RegisterAttachment.Remove(att);
                    });
                }

                document.Document_RegisterAttachment.AddRange(model.AttachmentIDs.Select(p => new Document_RegisterAttachment
                {
                    AttachmentID = p.AttachmentID,
                    AttachmentName = p.AttachmentName,
                    AttachmentSize = p.AttachmentSize,
                    RegisterID = model.RegisterID
                }));
                document.SaveChanges();
                //entity.Document_RegisterAttachment.ToList().ForEach(att =>
                //{
                //    document.Document_RegisterAttachment.Remove(att);
                //});
                //if (model.AttachmentIDs != null)
                //{
                //    model.AttachmentIDs.Select(att => document.Document_RegisterAttachment.Find(att.AttachmentID)).ToList().ForEach(att =>
                //    {
                //        entity.Document_RegisterAttachment.Add(att);
                //    });
                //}
                document.SaveChanges();
                return new DocumentResultDTO { success = true };
            }
            catch (Exception ex)
            {
                return new DocumentResultDTO { success = false, message = ex.Message };
            }


        }


        /// <summary>
        /// 删除
        /// </summary> 
        public DocumentResultDTO Delete(Guid id)
        {
            try
            {
                var entity = document.Document_Register.FirstOrDefault(p => p.RegisterID == id);
                if (entity != null)
                {
                    entity.Document_RegisterAttachment.ToList().ForEach(att =>
                    {
                        document.Document_RegisterAttachmentDownload.RemoveRange(att.Document_RegisterAttachmentDownload);
                    });
                    document.Document_RegisterAttachment.RemoveRange(entity.Document_RegisterAttachment);
                    document.Document_Register.Remove(entity);
                    document.SaveChanges();
                }
                return new DocumentResultDTO { success = true };
            }
            catch (Exception ex)
            {
                return new DocumentResultDTO { success = false, message = ex.Message };
            }

        }


        /// <summary>
        /// 产品类型
        /// </summary>
        public List<ProductTypeResultDTO> ProductType()
        {
            string sql = "select ProductTypeID,ProductTypeName from master_ProductType";
            return masterdata.Database.SqlQuery<ProductTypeResultDTO>(sql).ToList();
        }

        /// <summary>
        /// 产品线
        /// </summary>           
        public RootNode ProductLine(DocumentDTO dto)
        {
            var token = dto.UserInfo;
            string sql = null;
            if (token.UserType == 2)
            {
                sql = "SELECT master_ProductLine.ProductLineID, master_ProductLine.DepartID, master_ProductLine.ProductLineName, master_DepartmentInfo.DepartName FROM master_ProductLine INNER JOIN master_DepartmentInfo ON master_ProductLine.DepartID = master_DepartmentInfo.DepartID where master_ProductLine.IsActive=1 "
                    + string.Format("  and master_ProductLine.ProductLineID in ({0})", string.Join(",", token.ProductLineIDs));
            }
            else
            {
                sql = "SELECT master_ProductLine.ProductLineID, master_ProductLine.DepartID, master_ProductLine.ProductLineName, master_DepartmentInfo.DepartName FROM master_ProductLine INNER JOIN master_DepartmentInfo ON master_ProductLine.DepartID = master_DepartmentInfo.DepartID where master_ProductLine.IsActive=1";
            }


            var productLines = masterdata.Database.SqlQuery<ProductLineResultDTO>(sql);
            RootNode root = new RootNode { children = new List<DepartNode>() };
            productLines.GroupBy(p => p.DepartID).ToList().ForEach(group =>
            {
                var first = group.First();
                var departNode = new DepartNode { id = first.DepartID, text = first.DepartName, children = new List<ProductLineNode>() };

                departNode.children.AddRange(group.Select(p => new ProductLineNode { id = p.ProductLineID, DepartID = p.DepartID, DepartName = p.DepartName, ProductLineID = p.ProductLineID, text = p.ProductLineName }));
                root.children.Add(departNode);
            });
            return root;
        }

        public DocumentResultDTO Download(UserInfoDTO userInfo, Guid[] ids)
        {
            document.Document_RegisterAttachmentDownload.AddRange(ids.Select(id =>
            new Document_RegisterAttachmentDownload
            {
                AttachmentID = id,
                IsDownload = true,
                UserID = userInfo.UserID
            }));

            document.SaveChanges();
            return new DocumentResultDTO { success = true };
        }
    }
}
