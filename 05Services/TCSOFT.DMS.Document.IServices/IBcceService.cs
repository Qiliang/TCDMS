using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCSOFT.DMS.Document.DTO;
using TCSOFT.DMS.Document.DTO.Bcce;

namespace TCSOFT.DMS.Document.IServices
{
    public interface IBcceService
    {
        PageableDTO<BcceResultDTO> Query(BcceSearchDTO q);
        BcceResultDTO Get(Guid id);
        DocumentResultDTO Add(BcceAddDTO model);
        DocumentResultDTO Update(BcceUpdateDTO model);
        DocumentResultDTO Delete(Guid id);
        DocumentResultDTO Download(UserInfoDTO userInfo, Guid[] ids);
    }
}
