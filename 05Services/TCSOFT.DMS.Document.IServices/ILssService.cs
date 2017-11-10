using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCSOFT.DMS.Document.DTO;
using TCSOFT.DMS.Document.DTO.Lss;

namespace TCSOFT.DMS.Document.IServices
{
    public interface ILssService
    {
        PageableDTO<LssResultDTO> Query(LssSearchDTO q);
        LssResultDTO Get(Guid id);
        DocumentResultDTO Favorite(UserInfoDTO userInfo, Guid id);
        DocumentResultDTO UnFavorite(UserInfoDTO userInfo, Guid id);
        DocumentResultDTO Add(LssAddDTO model);
        DocumentResultDTO Update(LssUpdateDTO model);
        DocumentResultDTO Delete(Guid id);
        RootNode ProductLine(DocumentDTO dto);
        DocumentResultDTO AddSiblingTag(int? tagID, int? productLineID, string tagName);
        DocumentResultDTO AddChildTag(int? tagID, int? productLineID, string tagName);
        DocumentResultDTO RenameTag(int tagID, string tagName);
        DocumentResultDTO DeleteTag(int tagID);
        DocumentResultDTO Download(UserInfoDTO userInfo, Guid[] ids);
    }
}
