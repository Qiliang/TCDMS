using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCSOFT.DMS.Document.DTO;
using TCSOFT.DMS.Document.DTO.Lss;
using TCSOFT.DMS.Document.Entities;
using TCSOFT.DMS.Document.IServices;
using TCSOFT.DMS.Document.Services;

namespace TCSOFT.DMS.Document.Services
{
    public class LssService : BaseService, ILssService
    {
        /// <summary>
        /// 查询列表
        /// </summary>          
        public PageableDTO<LssResultDTO> Query(LssSearchDTO q)
        {
            if (q.PublishDateTo.HasValue)
            {
                q.PublishDateTo = new DateTime(q.PublishDateTo.Value.Year, q.PublishDateTo.Value.Month, q.PublishDateTo.Value.Day, 23, 59, 59);
            }
            if (q.UpdateDateTo.HasValue)
            {
                q.UpdateDateTo = new DateTime(q.UpdateDateTo.Value.Year, q.UpdateDateTo.Value.Month, q.UpdateDateTo.Value.Day, 23, 59, 59);
            }
            var token = q.UserInfo as UserInfoDTO;
            q.InitQuery("PublishDate", false);
            return document.Document_Lss
                .Where(p => string.IsNullOrEmpty(q.Search) ? true : (p.Title.Contains(q.Search) || p.Publisher.Contains(q.Search) || p.Document_LssTag.TagName.Contains(q.Search)))//货号、标题、发布人
                .Where(p => q.PublishDateFrom.HasValue ? p.PublishDate >= q.PublishDateFrom : true)
                .Where(p => q.PublishDateTo.HasValue ? p.PublishDate <= q.PublishDateTo : true)
                .Where(p => q.UpdateDateFrom.HasValue ? p.UpdateDate >= q.UpdateDateFrom : true)
                .Where(p => q.UpdateDateTo.HasValue ? p.UpdateDate <= q.UpdateDateTo : true)
                .Where(p => q.TagID > 0 ? p.TagID == q.TagID : true)
                //.Where(p => token.UserType != 2 ? true : token.ProductLineIDs.Contains(p.ProductLineID.Value))
                .Select(p => new LssResultDTO
                {
                    LssID = p.LssID,
                    TagID = p.TagID.Value,
                    TagName = p.Document_LssTag.TagName,
                    Title = p.Title,
                    EffectDate = p.EffectDate,
                    ValidDate = p.ValidDate,
                    Publisher = p.Publisher,
                    PublishDate = p.PublishDate,
                    UpdateDate = p.UpdateDate,
                    IsFavorite = p.Document_LssFavorite.Any(f => f.UserID == token.UserID && f.LssID == p.LssID),
                    IsDownload = p.Document_LssAttachment.All(att => att.Document_LssAttachmentDownload.Count > 0 && att.Document_LssAttachmentDownload.All(down => down.IsDownload == true && down.UserID == token.UserID)),
                    Attachments = p.Document_LssAttachment.Select(att => new LssAttachmentDTO
                    {
                        AttachmentID = att.AttachmentID,
                        AttachmentName = att.AttachmentName,
                        AttachmentSize = att.AttachmentSize
                    })

                }).ToPageable(q);
        }

        public LssResultDTO Get(Guid id)
        {
            var p = document.Document_Lss.Find(id);
            return new LssResultDTO
            {
                LssID = p.LssID,
                TagID = p.TagID.Value,
                TagName = p.Document_LssTag.TagName,

                Title = p.Title,
                ValidDate = p.ValidDate,
                EffectDate = p.EffectDate,
                Publisher = p.Publisher,
                PublishDate = p.PublishDate,
                UpdateDate = p.UpdateDate,
                //IsFavorite = p.Document_LssFavorite.Any(f => f.UserID == token.UserID),
                //IsDownload = p.Document_LssAttachment.All(att => att.Document_LssAttachmentDownload.Count > 0 && att.Document_LssAttachmentDownload.All(down => down.IsDownload == true && down.UserID == token.UserID)),
                Attachments = p.Document_LssAttachment.Select(att => new LssAttachmentDTO
                {
                    AttachmentID = att.AttachmentID,
                    AttachmentName = att.AttachmentName,
                    AttachmentSize = att.AttachmentSize
                })
            };
        }

        public DocumentResultDTO Favorite(UserInfoDTO userInfo, Guid id)
        {            
            if (document.Document_LssFavorite.Any(p => p.UserID == userInfo.UserID && p.LssID == id))
            {
                return new DocumentResultDTO { success = true };
            }
            document.Document_LssFavorite.Add(new Document_LssFavorite { UserID = userInfo.UserID, LssID = id, FavoriteDate = DateTime.Now, FavoriteID=Guid.NewGuid() });
            document.SaveChanges();
            return new DocumentResultDTO { success = true };
        }

        public DocumentResultDTO UnFavorite(UserInfoDTO userInfo, Guid id)
        {          
            var fav = document.Document_LssFavorite.FirstOrDefault(p => p.UserID == userInfo.UserID && p.LssID == id);
            if (fav != null) document.Document_LssFavorite.Remove(fav);         
            document.SaveChanges();
            return new DocumentResultDTO { success = true };
        }



        

        /// <summary>
        /// 添加
        /// </summary>     

        public DocumentResultDTO Add(LssAddDTO model)
        {
            try
            {
                var token = model.UserInfo as UserInfoDTO;
                var entity = new Document_Lss
                {
                    LssID = Guid.NewGuid(),
                    TagID = model.TagID,
                    Title = model.Title,
                    ValidDate = model.ValidDate,
                    EffectDate = model.EffectDate,
                    PublisherID = token.UserID,
                    Publisher = token.FullName,
                    PublishDate = DateTime.Now,
                    UpdateDate = null,
                };
                if (model.AttachmentIDs != null)
                {
                    document.Document_LssAttachment.AddRange(model.AttachmentIDs.Select(p => new Document_LssAttachment
                    {
                        AttachmentID = p.AttachmentID,
                        AttachmentName = p.AttachmentName,
                        AttachmentSize = p.AttachmentSize,
                        LssID = entity.LssID
                    }));

                }

                document.Document_Lss.Add(entity);
                document.SaveChanges();
                return new DocumentResultDTO { success = true };
            }
            catch (Exception ex)
            {
                return new DocumentResultDTO
                {
                    success = false,
                    message = ex.Message
                };
            }


        }


        /// <summary>
        /// 修改
        /// </summary> 
        public DocumentResultDTO Update(LssUpdateDTO model)
        {
            try
            {
                var token = model.UserInfo as UserInfoDTO;
                var entity = document.Document_Lss.FirstOrDefault(p => p.LssID == model.LssID);
                if (!string.IsNullOrWhiteSpace(model.Title)) entity.Title = model.Title;

                entity.LssID = Guid.NewGuid();
                entity.TagID = model.TagID;
                entity.Title = model.Title;
                entity.ValidDate = model.ValidDate;
                entity.EffectDate = model.EffectDate;
                entity.PublishDate = DateTime.Now;
                if (model.DeleteAttachmentIDs != null)
                {
                    model.DeleteAttachmentIDs.ForEach(p =>
                    {
                        var att = document.Document_LssAttachment.Find(p);
                        if (att == null) return;
                        document.Document_LssAttachmentDownload.RemoveRange(att.Document_LssAttachmentDownload);
                        document.Document_LssAttachment.Remove(att);
                    });
                }

                document.Document_LssAttachment.AddRange(model.AttachmentIDs.Select(p => new Document_LssAttachment
                {
                    AttachmentID = p.AttachmentID,
                    AttachmentName = p.AttachmentName,
                    AttachmentSize = p.AttachmentSize,
                    LssID = model.LssID
                }));
                entity.UpdateDate = DateTime.Now;

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
                var entity = document.Document_Lss.FirstOrDefault(p => p.LssID == id);
                if (entity != null)
                {
                    entity.Document_LssAttachment.ToList().ForEach(att =>
                    {
                        document.Document_LssAttachmentDownload.RemoveRange(att.Document_LssAttachmentDownload);
                    });
                    document.Document_LssAttachment.RemoveRange(entity.Document_LssAttachment);
                    document.Document_Lss.Remove(entity);
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
        /// 标签
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
                var departNode = new DepartNode { id = first.DepartID, DepartID = first.DepartID, text = first.DepartName, children = new List<ProductLineNode>() };

                departNode.children.AddRange(group.Select(p => new ProductLineNode { id = p.ProductLineID, DepartID = p.DepartID, DepartName = p.DepartName, ProductLineID = p.ProductLineID, text = p.ProductLineName }));
                root.children.Add(departNode);
                departNode.children.ForEach(pl =>
                {
                    pl.children = document.Document_LssTag.Where(p => p.ProductLineID == pl.ProductLineID).Select(p => new TagDTO
                    {
                        id = p.TagID,
                        text = p.TagName
                    }).ToList();
                    pl.children.ForEach(tag => ResTag(tag));
                });
            });

            return root;
        }

        private void ResTag(TagDTO tag)
        {
            var res = document.Document_LssTag.Where(p => p.ParentID == tag.id).Select(p => new TagDTO
            {
                id = p.TagID,
                text = p.TagName
            }).ToList();
            if (res.Count == 0) return;
            tag.children = res;
            foreach (var t in tag.children)
            {
                ResTag(t);
            }
        }

        //增加同级标签
        public DocumentResultDTO AddSiblingTag(int? tagID, int? productLineID, string tagName)
        {

            var tag = document.Document_LssTag.Find(tagID);
            if (productLineID.HasValue
                && document.Document_LssTag.Any(p => p.ProductLineID == p.ProductLineID && !p.ParentID.HasValue && tagName == p.TagName)
                )
            {
                return new DocumentResultDTO { success = false, message = "同一级别的标签内不允许有相同命名的标签" };
            }
            else if (!productLineID.HasValue
                && document.Document_LssTag.Any(p => p.ParentID == tag.ParentID && tagName == p.TagName))
            {
                return new DocumentResultDTO { success = false, message = "同一级别的标签内不允许有相同命名的标签" };
            }

            int? parentID = null;
            if (tag != null) parentID = tag.ParentID;
            document.Document_LssTag.Add(new Document_LssTag
            {
                ParentID = parentID,
                TagName = tagName,
                ProductLineID = productLineID
            });
            document.SaveChanges();
            return new DocumentResultDTO { success = true };

        }

        //增加子级标签
        public DocumentResultDTO AddChildTag(int? tagID, int? productLineID, string tagName)
        {
            var tag = document.Document_LssTag.Find(tagID);

            if (productLineID.HasValue
               && document.Document_LssTag.Any(p => p.ProductLineID == p.ProductLineID && !p.ParentID.HasValue && tagName == p.TagName)
               )
            {
                return new DocumentResultDTO { success = false, message = "同一级别的标签内不允许有相同命名的标签" };
            }
            else if (!productLineID.HasValue
                && document.Document_LssTag.Any(p => p.ParentID == tag.TagID && tagName == p.TagName))
            {
                return new DocumentResultDTO { success = false, message = "同一级别的标签内不允许有相同命名的标签" };
            }
            int? parentID = null;
            if (tag != null) parentID = tag.TagID;
            document.Document_LssTag.Add(new Document_LssTag
            {
                ParentID = parentID,
                TagName = tagName,
                ProductLineID = productLineID
            });
            document.SaveChanges();
            return new DocumentResultDTO { success = true };
        }

        //修改标签名称
        public DocumentResultDTO RenameTag(int tagID, string tagName)
        {
            var tag = document.Document_LssTag.Find(tagID);
            tag.TagName = tagName;
            document.SaveChanges();
            return new DocumentResultDTO { success = true };
        }

        //删除标签
        public DocumentResultDTO DeleteTag(int tagID)
        {
            var tag = document.Document_LssTag.Find(tagID);
            document.Document_LssTag.Remove(tag);
            document.SaveChanges();
            return new DocumentResultDTO { success = true };
        }


        public DocumentResultDTO Download(UserInfoDTO userInfo, Guid[] ids)
        {

            document.Document_LssAttachmentDownload.AddRange(ids.Select(id =>
             new Document_LssAttachmentDownload
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
