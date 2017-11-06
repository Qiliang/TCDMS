using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCSOFT.DMS.Fcpa.Entities;

namespace TCSOFT.DMS.Fcpa.Services
{
    public abstract class BaseService
    {
        protected TCDMS_FCPAEntities fcpa = new TCDMS_FCPAEntities();
        protected TCDMS_MasterDataEntities masterdata = new TCDMS_MasterDataEntities();
               
    }
}
