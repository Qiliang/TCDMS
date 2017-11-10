using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCSOFT.DMS.Document.DTO;
using TCSOFT.DMS.Document.DTO.Bcce;
using TCSOFT.DMS.Document.Entities;
using TCSOFT.DMS.Document.IServices;

namespace TCSOFT.DMS.Document.Services
{
    public class BcceService:BaseService,IBcceService
    {
        /// <summary>
        /// 查询列表
        /// </summary>          
        public PageableDTO<BcceResultDTO> Query(BcceSearchDTO q)
        {
            if (q.PublishDateTo.HasValue)
            {
                q.PublishDateTo = new DateTime(q.PublishDateTo.Value.Year, q.PublishDateTo.Value.Month, q.PublishDateTo.Value.Day, 23, 59, 59);
            }
            var token = q.UserInfo as UserInfoDTO;
            q.InitQuery("PublishDate", false);
            return document.Document_Bcce
                .Where(p => string.IsNullOrEmpty(q.Search) ? true : (p.ProductNo.Contains(q.Search) || p.Title.Contains(q.Search) || p.Publisher.Contains(q.Search)))//货号、标题、发布人
                .Where(p => q.PublishDateFrom.HasValue ? p.PublishDate >= q.PublishDateFrom : true)
                .Where(p => q.PublishDateTo.HasValue ? p.PublishDate <= q.PublishDateTo : true)
                //.Where(p => token.UserType != 2 ? true : token.ProductLineIDs.Contains(p.ProductLineID.Value))
                .Select(p => new BcceResultDTO
                {
                    BcceID = p.BcceID,
                    //ProductLineID = p.ProductLineID,
                    //ProductTypeID = p.ProductTypeID,
                    //ProductTypeName = p.ProductTypeName,
                    //ProductLineName = p.ProductLineName,
                    ProductNo = p.ProductNo,
                    Title = p.Title,
                    ValidDate = p.ValidDate,
                    Publisher = p.Publisher,
                    PublishDate = p.PublishDate,
                    UpdateDate = p.UpdateDate,
                    IsDownload = p.Document_BcceAttachment.All(att => att.Document_BcceAttachmentDownload.Count>0 && att.Document_BcceAttachmentDownload.All(down => down.IsDownload == true && down.UserID==token.UserID)),
                    Attachments = p.Document_BcceAttachment.Select(att => new BcceAttachmentDTO
                    {
                        AttachmentID = att.AttachmentID,
                        AttachmentName = att.AttachmentName,
                        AttachmentSize = att.AttachmentSize
                    })

                }).ToPageable(q);
        }

        public BcceResultDTO Get(Guid id)
        {
            var p = document.Document_Bcce.Find(id);
            return new BcceResultDTO
            {
                BcceID = p.BcceID,
                //ProductLineID = p.ProductLineID,
                //ProductTypeID = p.ProductTypeID,
                //ProductTypeName = p.ProductTypeName,
                //ProductLineName = p.ProductLineName,
                ProductNo = p.ProductNo,
                Title = p.Title,
                ValidDate = p.ValidDate,
                Publisher = p.Publisher,
                PublishDate = p.PublishDate,
                UpdateDate = p.UpdateDate,
                IsDownload = p.Document_BcceAttachment.All(att => att.Document_BcceAttachmentDownload.All(down => down.IsDownload == true)),
                Attachments = p.Document_BcceAttachment.Select(att => new BcceAttachmentDTO
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

        public DocumentResultDTO Add(BcceAddDTO model)
        {
            try
            {
                var token = model.UserInfo as UserInfoDTO;
                var entity = new Entities.Document_Bcce
                {
                    BcceID = Guid.NewGuid(),
                    //ProductTypeID = model.ProductTypeID,
                    //ProductTypeName = model.ProductTypeName,
                    //ProductLineID = model.ProductLineID,
                    //ProductLineName = model.ProductLineName,
                    ProductNo = model.ProductNo,
                    Title = model.Title,
                    ValidDate = model.ValidDate,
                    PublisherID = token.UserID,
                    Publisher = token.FullName,
                    PublishDate = DateTime.Now,
                    UpdateDate = null,
                };

                document.Document_BcceAttachment.AddRange(model.AttachmentIDs.Select(p => new Document_BcceAttachment
                {
                    AttachmentID = p.AttachmentID,
                    AttachmentName = p.AttachmentName,
                    AttachmentSize = p.AttachmentSize,
                    BcceID = entity.BcceID
                }));
                document.SaveChanges();
                if (model.AttachmentIDs != null)
                {
                    model.AttachmentIDs.Select(att => document.Document_BcceAttachment.Find(att.AttachmentID)).ToList().ForEach(att =>
                    {
                        entity.Document_BcceAttachment.Add(att);
                    });
                }

                document.Document_Bcce.Add(entity);
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
        public DocumentResultDTO Update(BcceUpdateDTO model)
        {
            try
            {
                var token = model.UserInfo as UserInfoDTO;
                var entity = document.Document_Bcce.FirstOrDefault(p => p.BcceID == model.BcceID);
                if (!string.IsNullOrWhiteSpace(model.Title)) entity.Title = model.Title;
                //if (model.ProductTypeID.HasValue && !string.IsNullOrWhiteSpace(model.ProductTypeName))
                //{
                //    entity.ProductTypeID = model.ProductTypeID;
                //    entity.ProductTypeName = model.ProductTypeName;
                //}
                //if (model.ProductLineID.HasValue && !string.IsNullOrWhiteSpace(model.ProductLineName))
                //{
                //    entity.ProductLineID = model.ProductLineID;
                //    entity.ProductLineName = model.ProductLineName;
                //}
                if (!string.IsNullOrWhiteSpace(model.ProductNo)) entity.ProductNo = model.ProductNo;
                if (model.ValidDate.HasValue) entity.ValidDate = model.ValidDate;
                entity.PublisherID = token.UserID;
                entity.Publisher = token.FullName;
                entity.UpdateDate = DateTime.Now;

                if (model.DeleteAttachmentIDs != null)
                {
                    model.DeleteAttachmentIDs.ForEach(p =>
                    {
                        var att = document.Document_BcceAttachment.Find(p);
                        if (att == null) return;
                        document.Document_BcceAttachmentDownload.RemoveRange(att.Document_BcceAttachmentDownload);
                        document.Document_BcceAttachment.Remove(att);
                    });
                }

                document.Document_BcceAttachment.AddRange(model.AttachmentIDs.Select(p => new Document_BcceAttachment
                {
                    AttachmentID = p.AttachmentID,
                    AttachmentName = p.AttachmentName,
                    AttachmentSize = p.AttachmentSize,
                    BcceID = model.BcceID
                }));
                document.SaveChanges();
                //entity.Document_BcceAttachment.ToList().ForEach(att =>
                //{
                //    document.Document_BcceAttachment.Remove(att);
                //});
                //if (model.AttachmentIDs != null)
                //{
                //    model.AttachmentIDs.Select(att => document.Document_BcceAttachment.Find(att.AttachmentID)).ToList().ForEach(att =>
                //    {
                //        entity.Document_BcceAttachment.Add(att);
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
                var entity = document.Document_Bcce.FirstOrDefault(p => p.BcceID == id);
                if (entity != null)
                {
                    entity.Document_BcceAttachment.ToList().ForEach(att =>
                    {
                        document.Document_BcceAttachmentDownload.RemoveRange(att.Document_BcceAttachmentDownload);
                    });
                    document.Document_BcceAttachment.RemoveRange(entity.Document_BcceAttachment);
                    document.Document_Bcce.Remove(entity);
                    document.SaveChanges();
                }
                return new DocumentResultDTO { success = true };
            }
            catch (Exception ex)
            {
                return new DocumentResultDTO { success = false, message = ex.Message };
            }

        }

        public DocumentResultDTO Download(UserInfoDTO userInfo, Guid[] ids)
        {
            document.Document_BcceAttachmentDownload.AddRange(ids.Select(id =>
            new Document_BcceAttachmentDownload
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
