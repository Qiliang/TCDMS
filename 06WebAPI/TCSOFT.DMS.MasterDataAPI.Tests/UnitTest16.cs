using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TCSOFT.DMS.MasterDataAPI.Controllers;
using TCSOFT.DMS.MasterData.DTO.AccountDate;
using Newtonsoft.Json;
using TCSOFT.DMS.MasterData.DTO.Common;
using System.Collections.Generic;
using TCSOFT.DMS.Common;
using TCSOFT.DMS.MasterData.DTO.Product.ProductType;

namespace TCSOFT.DMS.MasterDataAPI.Tests
{
    [TestClass]
    public class UnitTest16
    {
        ProductTypeController testcontroller = new ProductTypeController();
        [TestMethod]
        public void TestMethod1()
        {
            //产品类型
            //新增
            ProductTypeSearchDTO searchdto = new ProductTypeSearchDTO();
            var searchdtostr = TransformHelper.ConvertDTOTOBase64JsonString(searchdto);
            testcontroller.GetProductTypeList(searchdtostr);
            ProductTypeOperateDTO adddto = new ProductTypeOperateDTO();
            adddto.ProductTypeName = "单元测试产品类型名称";
            var addresultstr = testcontroller.AddProductType(adddto).Content.ReadAsStringAsync().Result;
            var addresult = JsonConvert.DeserializeObject<ResultDTO<object>>(addresultstr);
            var resultlist1 = JsonConvert.DeserializeObject<List<ProductTypeResultDTO>>(testcontroller.GetProductTypeList(searchdtostr).Content.ReadAsStringAsync().Result);
            var target = resultlist1.Where(m => m.ProductTypeName == "单元测试产品类型名称").FirstOrDefault();
            Assert.IsNotNull(target);

            //修改
            adddto.ProductTypeID = target.ProductTypeID;
            adddto.ProductTypeName = "修改单元测试产品类型名称";
            var updateresultstr = testcontroller.UpdateProductType(adddto).Content.ReadAsStringAsync().Result;
            var updateresult = JsonConvert.DeserializeObject<ResultDTO<object>>(updateresultstr);

            var resultlist2str = testcontroller.GetProductTypeList(searchdtostr).Content.ReadAsStringAsync().Result;
            var resultlist2 = JsonConvert.DeserializeObject<List<ProductTypeResultDTO>>(resultlist2str);
            target = resultlist2.Where(m => m.ProductTypeName == "修改单元测试产品类型名称").FirstOrDefault();
            Assert.IsNotNull(target);

            //删除
            ProductTypeSearchDTO deletedto = new ProductTypeSearchDTO();
            deletedto.ProductTypeID = target.ProductTypeID;
            var deletedtostr = TransformHelper.ConvertDTOTOBase64JsonString(deletedto);
            var deleteresultstr = testcontroller.DeleteProductType(deletedtostr).Content.ReadAsStringAsync().Result;
            var deleteresult = JsonConvert.DeserializeObject<ResultDTO<object>>(deleteresultstr);
            var resultlist3str = testcontroller.GetProductTypeList(searchdtostr).Content.ReadAsStringAsync().Result;
            var resultlist3 = JsonConvert.DeserializeObject<List<ProductTypeResultDTO>>(resultlist3str);
            target = resultlist3.Where(m => m.ProductTypeID == target.ProductTypeID).FirstOrDefault();
            Assert.IsNull(target);
        }
    }
}
