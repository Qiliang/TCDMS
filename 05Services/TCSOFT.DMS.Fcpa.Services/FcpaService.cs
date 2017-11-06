using AutoMapper;
using NPOI.HSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TCSOFT.DMS.Fcpa.DTO;
using TCSOFT.DMS.Fcpa.DTO.Credential;
using TCSOFT.DMS.Fcpa.DTO.Fcpa;
using TCSOFT.DMS.Fcpa.DTO.Org;
using TCSOFT.DMS.Fcpa.Entities;
using TCSOFT.DMS.Fcpa.IServices;
using TCSOFT.DMS.Fcpa.Services.Jobs;

namespace TCSOFT.DMS.Fcpa.Services
{
    public class FcpaService : BaseService, IFcpaService
    {
        public CredentialResultDTO Get(string id)
        {
            var p = fcpa.fcpa_CredentialInfo.Find(new Guid(id));
            Mapper.Initialize(m => m.CreateMap<fcpa_DistributorInfo, DistributorResultDTO>());
            return new CredentialResultDTO
            {
                ID = p.ID,
                Distributor = Mapper.Map<fcpa_DistributorInfo, DistributorResultDTO>(p.fcpa_DistributorInfo),
                DistributorName = p.fcpa_DistributorInfo.DistributorName,
                Certificate = p.Certificate,
                Status = p.Status,
                Name = p.Name,
                Department = p.Department,
                Title = p.Title,
                CompletedDate = p.CompletedDate,
                OffWork = p.OffWork,
                OffWorkDate = p.OffWorkDate,
                Domain1 = p.Domain1,
                Domain2 = p.Domain2,
                Domain = p.Domain1 + "," + p.Domain2,
                UpdateDate = p.UpdateDate,
                ExpireDate = p.ExpireDate,
                Remark = p.Remark,
                StatusDesc = Const.Status(p.Status),
                OffWorkDesc = Const.Offwork(p.OffWork, p.OffWorkDate),
                DomainDesc = Const.Domain(p.Domain1, p.Domain2)
            };
        }

        public PageableDTO<CredentialResultDTO> Query(FcpaSearchDTO q)
        {
            var token = q.UserInfo;
            q.InitQuery("ID");
            var status = q.Status.ToIntArray();
            var offworks = q.OffWork.ToBoolArray();
            var areas = q.Area.ToStringArray();
            q.UserDistributorIDs = string.Join(",", token.DistributorIDs);
            var queryable = fcpa.fcpa_CredentialInfo.Where(p =>
                 (string.IsNullOrEmpty(q.Status) ? true : status.Any(a => p.Status == a))
                 && (q.Year.HasValue ? p.UpdateDate.HasValue && p.UpdateDate.Value.Year == q.Year : true)
                 && (q.Year.HasValue ? p.UpdateDate.HasValue && p.UpdateDate.Value.Year == q.Year : true)
                 && (string.IsNullOrEmpty(q.Area) ? true : areas.Any(a => p.fcpa_DistributorInfo.AreaName == a))
                 && (string.IsNullOrEmpty(q.Region) ? true : p.fcpa_DistributorInfo.RegionName.Contains(q.Region))
                 && (string.IsNullOrEmpty(q.DistributorName) ? true : p.fcpa_DistributorInfo.DistributorName.Contains(q.DistributorName))
                 && (string.IsNullOrEmpty(q.Name) ? true : p.Name.Contains(q.Name))
                 && (string.IsNullOrEmpty(q.Department) ? true : p.Department.Contains(q.Department))
                 && (string.IsNullOrEmpty(q.Title) ? true : p.Title.Contains(q.Title))
                 && (q.CompletedDateFrom.HasValue ? p.CompletedDate >= q.CompletedDateFrom : true)
                 && (q.CompletedDateTo.HasValue ? p.CompletedDate <= q.CompletedDateTo : true)
                 && (q.UpdateDateFrom.HasValue ? p.UpdateDate >= q.UpdateDateFrom : true)
                 && (q.UpdateDateTo.HasValue ? p.UpdateDate <= q.UpdateDateTo : true)
                 && (string.IsNullOrEmpty(q.OffWork) ? true : offworks.Any(a => p.OffWork.HasValue && p.OffWork.Value == a))
                 && (q.Domain1.HasValue ? p.Domain1 == q.Domain1 : true)
                 && (q.Domain2.HasValue ? p.Domain2 == q.Domain2 : true)
                 && (string.IsNullOrEmpty(q.Remark) ? true : p.Remark.Contains(q.Remark))
            )
            .Where(p => token.Role == 0 ? true : q.UserDistributorIDs.Contains(p.fcpa_DistributorInfo.DistributorID))
            .Where(p => string.IsNullOrEmpty(q.DistributorID) ? true : q.DistributorID.Contains(p.fcpa_DistributorInfo.DistributorID));
            var res = queryable.ToPageable(q);

            Mapper.Initialize(m => m.CreateMap<fcpa_DistributorInfo, DistributorResultDTO>());
            var resultList = res.rows.Select(p => new CredentialResultDTO
            {
                ID = p.ID,
                Distributor = Mapper.Map<fcpa_DistributorInfo, DistributorResultDTO>(p.fcpa_DistributorInfo),
                DistributorName = p.fcpa_DistributorInfo.DistributorName,
                Certificate = p.Certificate,
                Status = p.Status,
                Name = p.Name,
                Department = p.Department,
                Title = p.Title,
                CompletedDate = p.CompletedDate,
                OffWork = p.OffWork,
                OffWorkDate = p.OffWorkDate,
                Domain1 = p.Domain1,
                Domain2 = p.Domain2,
                Domain = p.Domain1 + "," + p.Domain2,
                UpdateDate = p.UpdateDate,
                ExpireDate = p.ExpireDate,
                Remark = p.Remark,
                StatusDesc = Const.Status(p.Status),
                OffWorkDesc = Const.Offwork(p.OffWork, p.OffWorkDate),
                DomainDesc = Const.Domain(p.Domain1, p.Domain2)
            }).ToList();

            return new PageableDTO<CredentialResultDTO>
            {
                rows = resultList,
                total = res.total

            };
        }

        public IEnumerable<DistributorDTO> Distributors(UserInfoDTO userInfo)
        {
            var distributorIDs = userInfo.DistributorIDs;
            return fcpa.fcpa_DistributorInfo.Where(p => distributorIDs.Contains(p.DistributorID))
                .Select(p =>
            new DistributorDTO
            {
                DistributorID = p.DistributorID,
                DistributorName = p.DistributorName,
                AreaName = p.AreaName
            });
        }

        public OperateResultDTO Add(CredentialOperateDTO model)
        {
            var credential = new fcpa_CredentialInfo() { ID = model.ID };
            fcpa.fcpa_CredentialInfo.Add(credential);
            return AddOrUpdate(model, credential, false);
        }

        public OperateResultDTO Update(CredentialOperateDTO model)
        {
            var credential = fcpa.fcpa_CredentialInfo.Find(model.ID);
            if (credential == null) return new OperateResultDTO { message = "记录不存在", success = false };
            return AddOrUpdate(model, credential, true);
        }

        private OperateResultDTO AddOrUpdate(CredentialOperateDTO model, fcpa_CredentialInfo credential, bool update)
        {
            var distributor = fcpa.fcpa_DistributorInfo.Find(model.DistributorID);
            var caUser = fcpa.fcpa_CredentialInfo.Where(p => p.fcpa_DistributorInfo.DistributorID == distributor.DistributorID && p.Name == model.Name).Count();
            if (update)
            {
                if (caUser > 1) return new OperateResultDTO { message = string.Format("'{0}'已经存在,不要重复添加", model.Name), success = false };
            }
            else
            {
                if (caUser > 0) return new OperateResultDTO { message = string.Format("'{0}'已经存在,不要重复添加", model.Name), success = false };
            }


            credential.fcpa_DistributorInfo = distributor;
            credential.Name = model.Name;
            credential.Department = model.Department;
            credential.Title = model.Title;
            credential.CompletedDate = model.CompletedDate;
            credential.ExpireDate = model.ExpireDate;
            credential.OffWork = model.OffWork;
            credential.OffWorkDate = model.OffWorkDate;
            credential.Domain1 = model.Domain1;
            credential.Domain2 = model.Domain2;
            credential.Remark = model.Remark;
            credential.UpdateDate = DateTime.Now;
            credential.Certificate = model.Certificate;
            StatusJob.StatusChange(credential);

            fcpa.SaveChanges();
            return new OperateResultDTO { success = true };
        }


        public OperateResultDTO AddOrgMap(OrgMapAddDTO dto)
        {
            try
            {
                var orgInfo = fcpa.fcpa_DistributorInfo.Find(dto.DistributorID);
                if (orgInfo == null) return new OperateResultDTO { success = false, message = "选择的经销商不存在" };
                orgInfo.OrgMap = dto.DistributorID;
                orgInfo.OrgMapFile = dto.OrgMapFile;
                orgInfo.Trains = dto.DistributorID;
                orgInfo.Status = 0;
                orgInfo.Domain1 = dto.Domain1;
                orgInfo.Domain2 = dto.Domain2;
                orgInfo.OrgMapUpdateTime = DateTime.Now;
                orgInfo.TrainsUpdateTime = DateTime.Now;
                orgInfo.ShouldNum = ReadExcel(dto.TrainsRealPath, orgInfo, dto);
                fcpa.SaveChanges();
                return new OperateResultDTO { success = true };
            }
            catch (Exception e)
            {
                return new OperateResultDTO { success = false, message = e.Message };
            }

        }

        public int ReadExcel(string path, fcpa_DistributorInfo distributor, OrgMapAddDTO dto)
        {
            //string path = @"C: \Users\XQL\Desktop\励志\须参加FCPA培训人员名单.xls";
            int num = 0;
            using (Stream steam = System.IO.File.OpenRead(path))
            {
                var workbook = new HSSFWorkbook(steam);
                var sheet = workbook.GetSheetAt(0);
                if (sheet.GetRow(1).Cells.Count < 2) throw new ArgumentException("经销商公司名称不能为空");
                string distributorName = sheet.GetRow(1).GetCell(1).StringCellValue;
                var distributorInFile = fcpa.fcpa_DistributorInfo.Where(p => p.DistributorName == distributorName).FirstOrDefault();
                if (distributorInFile == null) throw new ArgumentException("经销商公司名称不存在");
                if (distributorInFile.DistributorID != distributor.DistributorID) throw new ArgumentException("选择的经销商与文件中的名称不一致");
                for (int i = 7; i < sheet.LastRowNum; i++)
                {
                    var row = sheet.GetRow(i);
                    var name = row.GetCell(0).StringCellValue;
                    var department = row.GetCell(1).StringCellValue;
                    var title = row.GetCell(2).StringCellValue;
                    if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(department) || string.IsNullOrWhiteSpace(title)) continue;
                    var caUser = fcpa.fcpa_CredentialInfo.Where(p => p.fcpa_DistributorInfo.DistributorID == distributor.DistributorID && p.Name == name).FirstOrDefault();
                    if (caUser != null) throw new ArgumentException("培训名单中人员与现有人员重复");
                    fcpa.fcpa_CredentialInfo.Add(new fcpa_CredentialInfo
                    {
                        ID = Guid.NewGuid(),
                        Name = name.Trim(),
                        Department = department.Trim(),
                        Title = title.Trim(),
                        OffWork = false,
                        Status = 3,//未完成
                        Domain1 = dto.Domain1,
                        Domain2 = dto.Domain2,
                        UpdateDate = DateTime.Now,
                        fcpa_DistributorInfo = distributor
                    });
                    num++;
                }
                if (num < 3) throw new ArgumentException("培训人员不得小于3，请重新上传");
                fcpa.SaveChanges();
            }
            return num;

        }



    }
}
