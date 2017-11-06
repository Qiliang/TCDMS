using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

namespace TCSOFT.DMS.MasterData.Services
{
    using DTO;
    using Entities;
    using IServices;
    public class LoginServices : ILoginServices
    {
        public UserLoginDTO Login(LoginDTO lngdto)
        {
            UserLoginDTO result = null;

            //var pp = from p in SingleQueryObject.GetObj().master_UserInfo.AsNoTracking()
            //         where (p.IsActive ?? false) &&
            //                p.EffectiveTtime >= DateTime.Now &&
            //                p.PhoneNumber == lngdto.PhoneNumber &&
            //                p.DynamicPassword == lngdto.DynamicPassword &&
            //                (p.StopTime??DateTime.MaxValue)>=DateTime.Today
            //         select p;
            var pp = from p in SingleQueryObject.GetObj().master_UserInfo.AsNoTracking()
                     where (p.IsActive ?? false) &&                            
                            p.PhoneNumber == lngdto.PhoneNumber                           
                     select p;
            result = Mapper.Map<UserLoginDTO>(pp.FirstOrDefault());

            return result;
        }

        public short CheckPhoneNumber(string PhoneNumber)
        {
            short result = 0;

            var pp = SingleQueryObject.GetObj().master_UserInfo.AsNoTracking().Where(p => p.PhoneNumber == PhoneNumber).FirstOrDefault();

            if(pp == null) // 无手机号
            {
                result =1;
            }
            else if(pp.master_RoleInfo.Count()==0 && pp.master_UserCustomerAuthority.Count()==0) // 无权限
            {
                result = 2;
            }
            else if (!(pp.IsActive??false)) // 停用
            {
                result = 3;
            }
            else if (pp.StopTime < DateTime.Now) //用户到期时间
            {
                result = 4;
            }

            return result;
        }

        public bool SaveDymicPassword(string PhoneNumber, string strDymicPassword, int intValidDate)
        {
            bool blResult = false;

            using (var dmse = new TCDMS_MasterDataEntities())
            {
                var pp = dmse.master_UserInfo.Where(p => p.PhoneNumber == PhoneNumber && (p.IsActive ?? false)).FirstOrDefault();
                if (pp != null)
                {
                    pp.DynamicPassword = strDymicPassword;
                    pp.EffectiveTtime = DateTime.Now.AddSeconds(intValidDate);
                }

                blResult = dmse.SaveChanges() > 0;
            }

            return blResult;
        }

        public bool SaveMessageLog(string PhoneNumber, string SendContent)
        {
            bool result = false;

            return result;
        }
    }
}
