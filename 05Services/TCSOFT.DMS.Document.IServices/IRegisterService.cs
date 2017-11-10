using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCSOFT.DMS.Document.DTO;
using TCSOFT.DMS.Document.DTO.Register;

namespace TCSOFT.DMS.Document.IServices
{
    public interface IRegisterService
    {
        PageableDTO<RegisterResultDTO> Query(RegisterSearchDTO q);
        RegisterResultDTO Get(Guid id);
        DocumentResultDTO Add(RegisterAddDTO model);
        DocumentResultDTO Update(RegisterUpdateDTO model);
        DocumentResultDTO Delete(Guid id);
        List<ProductTypeResultDTO> ProductType();
        RootNode ProductLine(DocumentDTO dto);
        DocumentResultDTO Download(UserInfoDTO userInfo, Guid[] ids);
    }
}
