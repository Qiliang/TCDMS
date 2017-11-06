using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TCSOFT.DMS.MasterDataAPI.Controllers;
using TCSOFT.DMS.MasterData.DTO.Product.ProductInfo;
using TCSOFT.DMS.Common;
using Newtonsoft.Json;
using TCSOFT.DMS.MasterData.DTO.Common;
using System.Collections.Generic;

namespace TCSOFT.DMS.MasterDataAPI.Tests
{
    [TestClass]
    public class UnitTest20
    {
        MaintenanceInfoController testcontroller = new MaintenanceInfoController();
        [TestMethod]
        public void TestMethod1()
        {
            //产品类型
            //新增
            ProductInfoSearchDTO searchdto = new ProductInfoSearchDTO();
            searchdto.page = 1;
            searchdto.rows = 1;
            var searchdtostr = TransformHelper.ConvertDTOTOBase64JsonString(searchdto);
            testcontroller.GetMaintenanceInfo(searchdtostr);
            ProductInfoOperateDTO adddto = new ProductInfoOperateDTO();
            adddto.ProductID = Guid.NewGuid();
            adddto.ArtNo = "单元测试维修产品货号";
            adddto.CreateTime = DateTime.Now;
            adddto.IsMaintenance = true;
            adddto.ProductName = "单元测试维修产品名称";
            var addresultstr = testcontroller.AddMaintenanceInfo(adddto).Content.ReadAsStringAsync().Result;
            var addresult = JsonConvert.DeserializeObject<ResultDTO<object>>(addresultstr);
            searchdto.rows = 10;
            searchdto.SearchText = "单元测试维修产品名称";
            searchdtostr = TransformHelper.ConvertDTOTOBase64JsonString(searchdto);
            var resultlist1str = testcontroller.GetMaintenanceInfo(searchdtostr).Content.ReadAsStringAsync().Result;
            var resultlist1 = JsonConvert.DeserializeObject<ResultDTO<List<ProductInfoResultDTO>>>(resultlist1str).Object;
            var target = resultlist1.Where(m => m.ProductName == "单元测试维修产品名称").FirstOrDefault();
            Assert.IsNotNull(target);

            //修改
            adddto.ProductID = target.ProductID;
            adddto.ProductName = "修改单元测试维修产品名称";
            adddto.IsMaintenance = true;
            adddto.UpType = 1;
            var updateresultstr = testcontroller.UpdateStopEnableMaintenanceInfo(adddto).Content.ReadAsStringAsync().Result;
            var updateresult = JsonConvert.DeserializeObject<ResultDTO<object>>(updateresultstr);
            searchdto.SearchText = "修改单元测试维修产品名称";
            searchdtostr = TransformHelper.ConvertDTOTOBase64JsonString(searchdto);
            var resultlist2str = testcontroller.GetMaintenanceInfo(searchdtostr).Content.ReadAsStringAsync().Result;
            var resultlist2 = JsonConvert.DeserializeObject<ResultDTO<List<ProductInfoResultDTO>>>(resultlist2str).Object;
            target = resultlist2.Where(m => m.ProductName == "修改单元测试维修产品名称").FirstOrDefault();
            Assert.IsNotNull(target);

            //删除
            ProductInfoOperateDTO deletedto = new ProductInfoOperateDTO();
            deletedto.ProductID = target.ProductID;
            var deletedtostr = TransformHelper.ConvertDTOTOBase64JsonString(deletedto);
            var deleteresultstr = testcontroller.DeleteMaintenanceInfo(deletedtostr).Content.ReadAsStringAsync().Result;
            var deleteresult = JsonConvert.DeserializeObject<ResultDTO<object>>(deleteresultstr);
            var resultlist3str = testcontroller.GetMaintenanceInfo(searchdtostr).Content.ReadAsStringAsync().Result;
            var resultlist3 = JsonConvert.DeserializeObject<ResultDTO<List<ProductInfoResultDTO>>>(resultlist3str).Object;
            target = resultlist3.Where(m => m.ProductID == target.ProductID).FirstOrDefault();
            Assert.IsNull(target);
        }
    }
}
