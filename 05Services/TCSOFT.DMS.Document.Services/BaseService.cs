using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCSOFT.DMS.Document.Entities;


namespace TCSOFT.DMS.Document.Services
{
    public abstract class BaseService
    {
        protected TCDMS_DocumentEntities document = new TCDMS_DocumentEntities();
        protected TCDMS_MasterDataEntities masterdata = new TCDMS_MasterDataEntities();
               
    }
}
