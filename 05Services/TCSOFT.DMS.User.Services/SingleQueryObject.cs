using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TCSOFT.DMS.UserApply.Entities;
using TCSOFT.DMS.UserApply.DTO.User.UserApply;
using TCSOFT.DMS.UserApply.DTO.User;

namespace TCSOFT.DMS.UserApply.Services
{
    internal class SingleQueryObject
    {
        private static TCDMS_UserApplyEntities _OBJ = null;
        public static TCDMS_UserApplyEntities GetObj()
        {
            if (_OBJ == null)
            {
                _OBJ = new TCDMS_UserApplyEntities();

                Mapper.Initialize(cfg =>
                {
                    cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                    //查询申请用户批次
                    cfg.CreateMap<UserApply_ApplyBatch, UserApplyBatchResultDTO>();

                    //查询申请用户
                    var userapply = cfg.CreateMap<UserApply_UserApplyInfo, UserApplyUserResultDTO>();
                    userapply.ForMember(p => p.ApplyUserAuthority, opt => opt.MapFrom(s => s.UserApply_UserApplyAuthority));
                    cfg.CreateMap<UserApply_UserApplyAuthority, UserApplyAuthority>();

                    //添加申请批次
                    cfg.CreateMap<BatchApplyOperateDTO, UserApply_ApplyBatch>();

                    //添加申请用户
                    cfg.CreateMap<UserApplyOperateDTO, UserApply_UserApplyInfo>();

                    var usapp = cfg.CreateMap<UserApply_UserApplyInfo, UserApplyOperateDTO>();
                    usapp.ForMember(p => p.ApplyUserAuthority, opt => opt.MapFrom(s => s.UserApply_UserApplyAuthority));
                });
            }

            return _OBJ;
        }
    }
}
