using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCSOFT.DMS.Document.DTO;
using TCSOFT.DMS.Document.DTO.Register;
using TCSOFT.DMS.MasterData.DTO;
using TCSOFT.DMS.WebMain.Common;
using TCSOFT.DMS.WebMain.Models.Provider;

namespace TCSOFT.DMS.WebMain.Areas.Document.Models.Provider
{
    public class RegisterProvider : BaseProvider
    {
        public static PageableDTO<RegisterResultDTO> Query(RegisterSearchDTO q)
        {
            return PostAPI<PageableDTO<RegisterResultDTO>>(WebConfiger.DocumentServicesUrl + "Register/Query", q);
        }

        public static RegisterResultDTO Get(string id)
        {
            return GetAPI<RegisterResultDTO>(WebConfiger.DocumentServicesUrl + "Register/Get?id=" + id);
        }

        public static DocumentResultDTO Add(RegisterAddDTO dto)
        {
            return PostAPI<DocumentResultDTO>(WebConfiger.DocumentServicesUrl + "Register/Add", dto);
        }

        public static DocumentResultDTO Update(RegisterUpdateDTO dto)
        {
            return PostAPI<DocumentResultDTO>(WebConfiger.DocumentServicesUrl + "Register/Update", dto);
        }

        public static DocumentResultDTO Delete(Guid id)
        {
            return DeleteAPI<DocumentResultDTO>(WebConfiger.DocumentServicesUrl + "Register/Delete?id=" + id);
        }

        public static List<ProductTypeResultDTO> ProductType(DocumentDTO dto)
        {
            return PostAPI<List<ProductTypeResultDTO>>(WebConfiger.DocumentServicesUrl + "Register/ProductType", dto);
        }

        public static RootNode ProductLine(DocumentDTO dto)
        {         
            return PostAPI<RootNode>(WebConfiger.DocumentServicesUrl + "Register/ProductLine", dto);
        }
    }
}