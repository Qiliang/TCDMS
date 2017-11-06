using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Text;


namespace TCSOFT.DMS.WebMain.Models.Provider
{
    /// <summary>
    /// API基本操作
    /// </summary>
    public class BaseProvider
    {
        /// <summary>
        /// API 查询请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ApiUrl"></param>
        /// <param name="strReturnType"></param>
        /// <returns></returns>
        protected static T GetAPI<T>(string ApiUrl, string strReturnType = "application/json")
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.ExpectContinue = false;
            HttpResponseMessage responseMessage = httpClient.GetAsync(ApiUrl).Result;
            responseMessage.EnsureSuccessStatusCode();

            string strResult = responseMessage.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<T>(strResult);
        }

        /// <summary>
        /// API 删除请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ApiUrl"></param>
        /// <param name="strReturnType"></param>
        /// <returns></returns>
        protected static T DeleteAPI<T>(string ApiUrl, string strReturnType = "application/json")
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.ExpectContinue = false;
            HttpResponseMessage responseMessage = httpClient.DeleteAsync(ApiUrl).Result;
            responseMessage.EnsureSuccessStatusCode();

            string strResult = responseMessage.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<T>(strResult);
        }

        /// <summary>
        /// API 新增请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ApiUrl"></param>
        /// <param name="paramvalue"></param>
        /// <param name="strReturnType"></param>
        /// <returns></returns>
        protected static T PostAPI<T>(string ApiUrl,object paramvalue, string strReturnType = "application/json")
        {
            var requestJson = JsonConvert.SerializeObject(paramvalue);
            HttpContent httpContent = new StringContent(requestJson);  
            httpContent.Headers.ContentType = new MediaTypeHeaderValue(strReturnType);
            HttpClientHandler handler = new HttpClientHandler();
            handler.AutomaticDecompression = System.Net.DecompressionMethods.GZip;

            HttpClient httpClient = new HttpClient(handler);
            HttpResponseMessage response = httpClient.PostAsync(ApiUrl, httpContent).Result;
            response.EnsureSuccessStatusCode();
           
            string strResult = response.Content.ReadAsStringAsync().Result;
            
            return JsonConvert.DeserializeObject<T>(strResult);
        }

        /// <summary>
        /// API 修改请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ApiUrl"></param>
        /// <param name="paramvalue"></param>
        /// <param name="strReturnType"></param>
        /// <returns></returns>
        protected static T PutAPI<T>(string ApiUrl, object paramvalue, string strReturnType = "application/json")
        {
            var requestJson = JsonConvert.SerializeObject(paramvalue);
            HttpContent httpContent = new StringContent(requestJson);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue(strReturnType);
            HttpClientHandler handler = new HttpClientHandler();
            handler.AutomaticDecompression = System.Net.DecompressionMethods.GZip;

            HttpClient httpClient = new HttpClient(handler);
            HttpResponseMessage response = httpClient.PutAsync(ApiUrl, httpContent).Result;
            response.EnsureSuccessStatusCode();

            string strResult = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<T>(strResult);
        }
    }
}