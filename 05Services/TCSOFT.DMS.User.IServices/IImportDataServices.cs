using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCSOFT.DMS.UserApply.DTO.ImportExcel;

namespace TCSOFT.DMS.UserApply.IServices
{
    public interface IImportDataServices
    {
        /// <summary>
        /// 导入数据
        /// </summary>
        /// <param name="impdto"></param>
        /// <returns></returns>
        bool ImportData(List<ExcelImportDataDTO> impdtolst);
    }
}
