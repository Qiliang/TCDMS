using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCSOFT.DMS.Fcpa.DTO;
using TCSOFT.DMS.Fcpa.DTO.Alerm;

namespace TCSOFT.DMS.Fcpa.IServices
{
    public interface IAlermService
    {
        PageableDTO<AlermResultDTO> Query(AlermSearchDTO q);
    }
}
