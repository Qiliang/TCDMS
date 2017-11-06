using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace TCSOFT.DMS.Common
{
    /// <summary>
    /// 转换工具
    /// </summary>
    public class TransformHelper
    {
        /// <summary>
        /// DTO转换成base64json字符串
        /// </summary>
        /// <param name="DTOobj"></param>
        /// <returns></returns>
        public static string ConvertDTOTOBase64JsonString(object DTOobj)
        {
            string strResult = null;

            strResult = JsonConvert.SerializeObject(DTOobj);
            strResult = Convert.ToBase64String(Encoding.UTF8.GetBytes(strResult));


            return strResult;
        }

        /// <summary>
        /// base64json字符串转换成DTO
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="base64Jsonstr"></param>
        /// <returns></returns>
        public static T ConvertBase64JsonStringToDTO<T>(string base64Jsonstr)
        {
            base64Jsonstr = base64Jsonstr.Replace(" ", "+");
            T result = default(T);

            result = JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(Convert.FromBase64String(base64Jsonstr)));

            return result;
        }
    }
}
