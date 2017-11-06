using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using TCSOFT.DMS.MasterData.DTO.Product.ProductModel;
using TCSOFT.DMS.MasterData.DTO.Common;
using TCSOFT.DMS.MasterDataAPI.Controllers;

namespace TCSOFT.DMS.MasterDataAPI.Tests
{
    [TestClass]
    public class UnitTest13
    {
        ProductModelController ProductModelController = new ProductModelController();
        [TestMethod]
        public void TestMethod1()
        {
            //查询
            ProductModelSearchDTO dto = new ProductModelSearchDTO();
            string dtostr = Common.TransformHelper.ConvertDTOTOBase64JsonString(dto);
            var pp = ProductModelController.GetProductModel(dtostr);

            //新增
            ProductModelOperateDTO dto1 = new ProductModelOperateDTO();
            dto1.ProductModelName = "测试产品型号Test";
            dto1.IsActive = true;
            dto1.CreateUser = "我";
            dto1.CreateTime = DateTime.Now;
            var pp1 = ProductModelController.AddProductModel(dto1);
            string strResult1 = pp1.Content.ReadAsStringAsync().Result;
            ResultDTO<object> bl = JsonConvert.DeserializeObject<ResultDTO<object>>(strResult1);
            Assert.IsTrue(bl.SubmitResult);

            //查询
            ProductModelSearchDTO dto2 = new ProductModelSearchDTO();
            dto2.SearchText = "测试产品型号Test";
            string dto2str = Common.TransformHelper.ConvertDTOTOBase64JsonString(dto2);
            var pp2 = ProductModelController.GetProductModel(dto2str);
            string strResult2 = pp2.Content.ReadAsStringAsync().Result;
            List<ProductModelResultDTO> list1 = JsonConvert.DeserializeObject<List<ProductModelResultDTO>>(strResult2);

            //修改
            ProductModelOperateDTO dto3 = new ProductModelOperateDTO();
            dto3.UpType = 1;
            dto3.ProductModelID = list1.Select(s => s.ProductModelID).FirstOrDefault();
            dto3.ProductModelName = "修改测试产品型号Test";
            dto3.ModifyUser = "你";
            dto3.ModifyTime = DateTime.Now;
            var pp3 = ProductModelController.UpdateStopEnableProductModel(dto3);
            string strResult3 = pp3.Content.ReadAsStringAsync().Result;
            ResultDTO<object> bl1 = JsonConvert.DeserializeObject<ResultDTO<object>>(strResult3);
            Assert.IsTrue(bl1.SubmitResult);

            //停启用
            ProductModelOperateDTO dto5 = new ProductModelOperateDTO();
            dto5.UpType = 2;
            dto5.ProductModelID = list1.Select(s => s.ProductModelID).FirstOrDefault();
            dto5.IsActive = true;
            dto5.ModifyUser = "你";
            dto5.ModifyTime = DateTime.Now;
            var pp5 = ProductModelController.UpdateStopEnableProductModel(dto5);
            string strResult5 = pp5.Content.ReadAsStringAsync().Result;
            ResultDTO<object> bl5 = JsonConvert.DeserializeObject<ResultDTO<object>>(strResult5);
            Assert.IsTrue(bl5.SubmitResult);

            //删除
            ProductModelOperateDTO dto4 = new ProductModelOperateDTO();
            dto4.ProductModelID = list1.Select(s => s.ProductModelID).FirstOrDefault();
            string dto4str = Common.TransformHelper.ConvertDTOTOBase64JsonString(dto4);
            var pp4 = ProductModelController.DeleteProductModel(dto4str);
            string strResult4 = pp4.Content.ReadAsStringAsync().Result;
            ResultDTO<object> bl2 = JsonConvert.DeserializeObject<ResultDTO<object>>(strResult4);
            Assert.IsTrue(bl2.SubmitResult);
        }
    }
}
