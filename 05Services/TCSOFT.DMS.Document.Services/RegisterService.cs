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
            var token = q.UserInfo as UserInfoDTO;
            q.InitQuery("PublishDate", false);
            return document.Document_Register
                .Where(p => string.IsNullOrEmpty(q.Search) ? true : (p.ProductNo.Contains(q.Search) || p.Title.Contains(q.Search) || p.Publisher.Contains(q.Search)))//货号、标题、发布人
                .Where(p => q.PublishDateFrom.HasValue ? p.PublishDate >= q.PublishDateFrom : true)
                .Where(p => q.PublishDateTo.HasValue ? p.PublishDate <= q.PublishDateTo : true)
                .Where(p => q.ProductTypeID>0 ? p.ProductTypeID == q.ProductTypeID : true)
                .Where(p => q.ProductLineID>0 ? p.ProductLineID == q.ProductLineID : true)
                .Where(p => token.UserType != 2 ? true : token.ProductLineIDs.Contains(p.ProductLineID))
                .Select(p => new RegisterResultDTO
                {
                    RegisterID = p.RegisterID,
                    ProductTypeName = p.ProductTypeName,
                    ProductLineName = p.ProductLineName,
                    ProductNo = p.ProductNo,
                    Title = p.Title,
                    ValidDate = p.ValidDate,
                    Publisher = p.Publisher,
                    PublishDate = p.PublishDate,
                    UpdateDate = p.UpdateDate,
                    IsDownload = p.Document_RegisterAttachment.All(att => att.Document_RegisterAttachmentDownload.All(down => down.IsDownload == true)),
                    Attachments = p.Document_RegisterAttachment.Select(att => new RegisterAttachmentDTO
                    {
                        AttachmentID = att.AttachmentID,
                        AttachmentName = att.AttachmentName,
                        AttachmentSize = att.AttachmentSize
                    })

                }).ToPageable(q);
        }

        public RegisterResultDTO Get(string id)
        {
            var p = document.Document_Register.Find(new Guid(id));
            return new RegisterResultDTO
            {
                RegisterID = p.RegisterID,
                ProductTypeName = p.ProductTypeName,
                ProductLineName = p.ProductLineName,
                ProductNo = p.ProductNo,
                Title = p.Title,
                ValidDate = p.ValidDate,
                Publisher = p.Publisher,
                PublishDate = p.PublishDate,
                UpdateDate = p.UpdateDate,
                IsDownload = p.Document_RegisterAttachment.All(att => att.Document_RegisterAttachmentDownload.All(down => down.IsDownload == true)),
                Attachments = p.Document_RegisterAttachment.Select(att => new RegisterAttachmentDTO
                {
                    AttachmentID = att.AttachmentID,
                    AttachmentName = att.AttachmentName,
                    AttachmentSize = att.AttachmentSize
                })
            };
        }

        ///// <summary>
        ///// 上传
        ///// </summary>       
        //public IHttpActionResult Upload(RegisterAttachmentDTO dto)
        //{
        //    HttpFileCollection files = HttpContext.Current.Request.Files;
        //    Guid id = Guid.NewGuid();
        //    foreach (string key in files.AllKeys)
        //    {
        //        HttpPostedFile file = files[key];
        //        if (string.IsNullOrEmpty(file.FileName)) continue;
        //        file.SaveAs(Const.RealRegisterPath(id.ToString()));
        //        document.Document_RegisterAttachment.Add(new Document_RegisterAttachment
        //        {
        //            AttachmentID = id,
        //            AttachmentName = file.FileName,
        //            AttachmentSize = file.ContentLength
        //        });
        //        document.SaveChanges();
        //        return Ok(id);
        //    }
        //    return BadRequest();
        //}

        /// <summary>
        /// 下载
        /// </summary>  
        //[Route("Download"), HttpGet]
        //public HttpResponseMessage Download([FromUri]Guid RegisterID, [FromUri]Guid[] AttIDs)
        //{
        //    var token = User as UserToken;
        //    var register = document.Document_Register.Find(RegisterID);
        //    if (register == null) return new HttpResponseMessage(HttpStatusCode.NoContent);
        //    if (AttIDs == null || AttIDs.Length == 0) return new HttpResponseMessage(HttpStatusCode.NoContent);
        //    var temp = Path.GetTempFileName();
        //    ZipFile zipFile = ZipFile.Create(temp);
        //    zipFile.BeginUpdate();
        //    foreach (var att in document.Document_RegisterAttachment.Where(p => AttIDs.Contains(p.AttachmentID)).ToList())
        //    {
        //        if (!File.Exists(Const.RealRegisterPath(att.AttachmentID.ToString()))) return new HttpResponseMessage(HttpStatusCode.NotFound);
        //        zipFile.Add(Const.RealRegisterPath(att.AttachmentID.ToString()), att.AttachmentName);
        //        att.Document_RegisterAttachmentDownload.Add(new Document_RegisterAttachmentDownload
        //        {
        //            AttachmentID = att.AttachmentID,
        //            IsDownload = true,
        //            UserID = token.UserID
        //        });
        //    }
        //    zipFile.CommitUpdate();
        //    zipFile.Close();

        //    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
        //    response.Content = new ByteArrayContent(File.ReadAllBytes(temp));
        //    response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
        //    response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
        //    {
        //        FileName = string.Format("{0}).zip", register.Title)
        //    };
        //    document.SaveChanges();
        //    return response;
        //}



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
                    model.AttachmentIDs.Select(att => document.Document_RegisterAttachment.Find(att)).ToList().ForEach(att =>
                    {
                        entity.Document_RegisterAttachment.Add(att);
                    });
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

                entity.Document_RegisterAttachment.ToList().ForEach(att =>
                {
                    document.Document_RegisterAttachment.Remove(att);
                });
                if (model.AttachmentIDs != null)
                {
                    model.AttachmentIDs.Select(att => document.Document_RegisterAttachment.Find(att)).ToList().ForEach(att =>
                    {
                        entity.Document_RegisterAttachment.Add(att);
                    });
                }
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
            try { 
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

        ///// <summary>
        ///// 导出
        ///// </summary>  
        //[Route("Export"), HttpGet, HttpPost]
        //public HttpResponseMessage Export(RegisterQueryModel q)
        //{
        //    if (q == null) q = new RegisterQueryModel();
        //    var result = Query(q).List;
        //    try
        //    {
        //        var views = new List<ExcelView>()
        //        {
        //            new ExcelView { Header="产品类型", PropertyName="ProductTypeName", Width=15 },
        //            new ExcelView { Header="产品线", PropertyName="ProductLineName", Width=15 },
        //            new ExcelView { Header="货号", PropertyName="ProductNo", Width=15 },
        //            new ExcelView { Header="标题", PropertyName="Title", Width=15 },
        //            new ExcelView { Header="有效期", PropertyName="ValidDate" , Width=22},
        //            new ExcelView { Header="发布人", PropertyName="Publisher", Width=15 },
        //            new ExcelView { Header="发布日期", PropertyName="PublishDate" , Width=22 },
        //            new ExcelView { Header="更新日期", PropertyName="UpdateDate", Width=22  }
        //        };


        //        return result.ToExcel(views, "注册证({0}).xlsx");

        //    }
        //    catch (Exception e)
        //    {
        //        return new HttpResponseMessage(HttpStatusCode.NoContent);
        //    }
        //}


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
                    + string.Format("  and master_ProductLine.ProductLineID in ({0})", string.Join(",", token.ProductLineIDs.Where(p => p.HasValue)));
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
    }
}
