using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using TCSOFT.DMS.MasterDataAPI.Controllers;
using TCSOFT.DMS.MasterData.DTO.Product.ProductLine;
using TCSOFT.DMS.MasterData.DTO.Common;

namespace TCSOFT.DMS.MasterDataAPI.Tests
{
    [TestClass]
    public class UnitTest9
    {
        ProductLineController ProductLineController = new ProductLineController();
        [TestMethod]
        public void TestMethod1()
        {
            //查询
            ProductLineSearchDTO dto = new ProductLineSearchDTO();
            string dtostr = Common.TransformHelper.ConvertDTOTOBase64JsonString(dto);
            var pp = ProductLineController.GetProductLine(dtostr);

            //新增
            ProductLineOperateDTO dto1 = new ProductLineOperateDTO();
            dto1.ProductLineName = "测试产品线Test";
            dto1.ProductLineNameAB = "cscpxTest";
            dto1.CreateUser = "我";
            dto1.CreateTime = DateTime.Now;
            var pp1 = ProductLineController.AddProductLine(dto1);
            string strResult1 = pp1.Content.ReadAsStringAsync().Result;
            ResultDTO<object> bl = JsonConvert.DeserializeObject<ResultDTO<object>>(strResult1);
            Assert.IsTrue(bl.SubmitResult);

            //查询
            ProductLineSearchDTO dto2 = new ProductLineSearchDTO();
            dto2.SearchText = "测试产品线Test";
            string dto2str = Common.TransformHelper.ConvertDTOTOBase64JsonString(dto2);
            var pp2 = ProductLineController.GetProductLine(dto2str);
            string strResult2 = pp2.Content.ReadAsStringAsync().Result;
            List<ProductLineResultDTO> list1 = JsonConvert.DeserializeObject<List<ProductLineResultDTO>>(strResult2);

            //修改
            ProductLineOperateDTO dto3 = new ProductLineOperateDTO();
            dto3.UpType = 1;
            dto3.ProductLineID = list1.Select(s => s.ProductLineID).FirstOrDefault();
            dto3.ProductLineName = "修改测试产品线Test";
            dto3.ProductLineNameAB = "cscpxTest";
            dto3.ModifyUser = "你";
            dto3.ModifyTime = DateTime.Now;
            var pp3 = ProductLineController.UpdateStopEnableProductLine(dto3);
            string strResult3 = pp3.Content.ReadAsStringAsync().Result;
            ResultDTO<object> bl1 = JsonConvert.DeserializeObject<ResultDTO<object>>(strResult3);
            Assert.IsTrue(bl1.SubmitResult);

            //停启用
            ProductLineOperateDTO dto5 = new ProductLineOperateDTO();
            dto5.UpType = 2;
            dto5.ProductLineID = list1.Select(s => s.ProductLineID).FirstOrDefault();
            dto5.IsActive = true;
            dto5.ModifyUser = "你";
            dto5.ModifyTime = DateTime.Now;
            var pp5 = ProductLineController.UpdateStopEnableProductLine(dto5);
            string strResult5 = pp5.Content.ReadAsStringAsync().Result;
            ResultDTO<object> bl5 = JsonConvert.DeserializeObject<ResultDTO<object>>(strResult5);
            Assert.IsTrue(bl5.SubmitResult);

            //删除
            ProductLineOperateDTO dto4 = new ProductLineOperateDTO();
            dto4.ProductLineID = list1.Select(s => s.ProductLineID).FirstOrDefault();
            string dto4str = Common.TransformHelper.ConvertDTOTOBase64JsonString(dto4);
            var pp4 = ProductLineController.DeleteProductLine(dto4str);
            string strResult4 = pp4.Content.ReadAsStringAsync().Result;
            ResultDTO<object> bl2 = JsonConvert.DeserializeObject<ResultDTO<object>>(strResult4);
            Assert.IsTrue(bl2.SubmitResult);
        }
    }
}
