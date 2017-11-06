using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCSOFT.DMS.Document.DTO;
using TCSOFT.DMS.Document.IServices;

namespace TCSOFT.DMS.Document.Services
{
    public class UserService : BaseService, IUserService
    {
        public int?[] GetProductLines(int userID)
        {
            string sql = "SELECT master_UserInfo.UserID,  master_UserInfo.UserCode,  master_ProductLine.ProductLineID,  master_UserInfo.FullName,       master_UserInfo.PhoneNumber,  master_UserInfo.Email,  master_UserInfo.UserType FROM    master_UserInfo INNER JOIN      master_DistributorUserInfo ON  master_UserInfo.UserID =  master_DistributorUserInfo.UserID INNER JOIN      master_DistributorInfo ON       master_DistributorUserInfo.DistributorID =  master_DistributorInfo.DistributorID INNER JOIN      master_DistributorProductLineInfo ON       master_DistributorInfo.DistributorID =  master_DistributorProductLineInfo.DistributorID INNER JOIN      master_ProductLine ON master_DistributorProductLineInfo.ProductLineID =  master_ProductLine.ProductLineID where master_UserInfo.IsActive=1 and master_ProductLine.IsActive=1";
            sql += "and master_UserInfo.UserID=@UserID";
            var res = masterdata.Database.SqlQuery<UserQueryDTO>(sql, new SqlParameter("@UserID", userID)).ToList();
            if (res.Count == 0) return new int?[] { };
            return res.Select(p => p.ProductLineID).ToArray();

        }
    }
}
