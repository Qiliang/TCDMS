using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.Document.DTO.Register
{
    public class RegisterUpdateDTO:RegisterAddDTO
    {
        public Guid RegisterID { get; set; }
    }
}
