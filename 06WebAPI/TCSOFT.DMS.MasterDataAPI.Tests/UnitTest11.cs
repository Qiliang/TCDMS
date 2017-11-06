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
using TCSOFT.DMS.MasterData.DTO.Product.ProductSmallType;
using TCSOFT.DMS.MasterData.DTO.Common;
using TCSOFT.DMS.MasterData.DTO.Product.ProductLine;

namespace TCSOFT.DMS.MasterDataAPI.Tests
{
    [TestClass]
    public class UnitTest11
    {
        ProductSmallTypeController ProductSmallTypeController = new ProductSmallTypeController();
        ProductLineController ProductLineController = new ProductLineController();
        [TestMethod]
        public void TestMethod1()
        {
            //查询
            ProductSmallTypeSearchDTO dto = new ProductSmallTypeSearchDTO();
            string dtostr = Common.TransformHelper.ConvertDTOTOBase64JsonString(dto);
            var pp = ProductSmallTypeController.GetProductSmallType(dtostr);

            ProductLineSearchDTO dtoline = new ProductLineSearchDTO();
            string dtolinestr = Common.TransformHelper.ConvertDTOTOBase64JsonString(dtoline);
            var ppline = ProductLineController.GetProductLine(dtolinestr);
            string strResultline = ppline.Content.ReadAsStringAsync().Result;
            List<ProductLineResultDTO> listline = JsonConvert.DeserializeObject<List<ProductLineResultDTO>>(strResultline);
            if (listline.Count() == 0)
            {
                return;
            }
            //新增
            ProductSmallTypeOperateDTO dto1 = new ProductSmallTypeOperateDTO();
            dto1.ProductSmallTypeName = "测试产品小类Test";
            dto1.ProductLineID = listline.Select(s => s.ProductLineID).FirstOrDefault();
            dto1.IsActive = true;
            dto1.CreateUser = "我";
            dto1.CreateTime = DateTime.Now;
            var pp1 = ProductSmallTypeController.AddProductSmallType(dto1);
            string strResult1 = pp1.Content.ReadAsStringAsync().Result;
            ResultDTO<object> bl = JsonConvert.DeserializeObject<ResultDTO<object>>(strResult1);
            Assert.IsTrue(bl.SubmitResult);

            //查询
            ProductSmallTypeSearchDTO dto2 = new ProductSmallTypeSearchDTO();
            dto2.SearchText = "测试产品小类Test";
            string dto2str = Common.TransformHelper.ConvertDTOTOBase64JsonString(dto2);
            var pp2 = ProductSmallTypeController.GetProductSmallType(dto2str);
            string strResult2 = pp2.Content.ReadAsStringAsync().Result;
            List<ProductSmallTypeResultDTO> list1 = JsonConvert.DeserializeObject<List<ProductSmallTypeResultDTO>>(strResult2);

            //修改
            ProductSmallTypeOperateDTO dto3 = new ProductSmallTypeOperateDTO();
            dto3.UpType = 1;
            dto3.ProductSmallTypeID = list1.Select(s => s.ProductSmallTypeID).FirstOrDefault();
            dto3.ProductSmallTypeName = "修改测试产品小类Test";
            dto3.ProductLineID = listline.Select(s => s.ProductLineID).FirstOrDefault();
            dto3.ModifyUser = "你";
            dto3.ModifyTime = DateTime.Now;
            var pp3 = ProductSmallTypeController.UpdateStopEnableProductSmallType(dto3);
            string strResult3 = pp3.Content.ReadAsStringAsync().Result;
            ResultDTO<object> bl1 = JsonConvert.DeserializeObject<ResultDTO<object>>(strResult3);
            Assert.IsTrue(bl1.SubmitResult);

            //停启用
            ProductSmallTypeOperateDTO dto5 = new ProductSmallTypeOperateDTO();
            dto5.UpType = 2;
            dto5.ProductSmallTypeID = list1.Select(s => s.ProductSmallTypeID).FirstOrDefault();
            dto5.IsActive = true;
            dto5.ModifyUser = "你";
            dto5.ModifyTime = DateTime.Now;
            var pp5 = ProductSmallTypeController.UpdateStopEnableProductSmallType(dto5);
            string strResult5 = pp5.Content.ReadAsStringAsync().Result;
            ResultDTO<object> bl5 = JsonConvert.DeserializeObject<ResultDTO<object>>(strResult5);
            Assert.IsTrue(bl5.SubmitResult);

            //删除
            ProductSmallTypeOperateDTO dto4 = new ProductSmallTypeOperateDTO();
            dto4.ProductSmallTypeID = list1.Select(s => s.ProductSmallTypeID).FirstOrDefault();
            string dto4str = Common.TransformHelper.ConvertDTOTOBase64JsonString(dto4);
            var pp4 = ProductSmallTypeController.DeleteProductSmallType(dto4str);
            string strResult4 = pp4.Content.ReadAsStringAsync().Result;
            ResultDTO<object> bl2 = JsonConvert.DeserializeObject<ResultDTO<object>>(strResult4);
            Assert.IsTrue(bl2.SubmitResult);
        }
    }
}
