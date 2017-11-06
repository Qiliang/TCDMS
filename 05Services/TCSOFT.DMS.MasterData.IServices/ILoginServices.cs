using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.IServices
{
    using DTO;
    public interface ILoginServices
    {
        UserLoginDTO Login(LoginDTO lngdto); 
        short CheckPhoneNumber(string PhoneNumber);
        bool SaveDymicPassword(string PhoneNumber, string strDymicPassword, int intValidDate);
        bool SaveMessageLog(string PhoneNumber, string SendContent);
    }
}
