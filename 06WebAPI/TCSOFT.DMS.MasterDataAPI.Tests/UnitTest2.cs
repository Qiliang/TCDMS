using System;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TCSOFT.DMS.MasterDataAPI.Tests
{
    using TCSOFT.DMS.MasterDataAPI.Controllers;
    using TCSOFT.DMS.MasterData.DTO.Area;
    using TCSOFT.DMS.Common;
    using Newtonsoft.Json;
    using TCSOFT.DMS.MasterData.DTO.Common;
    using System.Collections.Generic;
    [TestClass]
    public class UnitTest2
    {
        AreaController testcontroller = new AreaController();
        [TestMethod]
        public void TestMethod1()
        {
            //大小区
            //新增
            AreaSearchDTO searchdto = new AreaSearchDTO();
            var searchdtostr = TransformHelper.ConvertDTOTOBase64JsonString(searchdto);
            testcontroller.GetAreaTree(searchdtostr);
            AreaOperateDTO adddto = new AreaOperateDTO();
            adddto.AreaName = "单元测试大小区";
            var addresult = JsonConvert.DeserializeObject<ResultDTO<object>>(testcontroller.AddArea(adddto).Content.ReadAsStringAsync().Result);
            var resultlist1 = JsonConvert.DeserializeObject<List<AreaResultDTO>>(testcontroller.GetAreaTree(searchdtostr).Content.ReadAsStringAsync().Result);
            var target = resultlist1.Where(m => m.AreaName == "单元测试大小区").FirstOrDefault();
            Assert.IsNotNull(target);
          
            //修改
            adddto.AreaID = target.AreaID;
            adddto.AreaName = "修改单元测试大小区";
            var updateresult = JsonConvert.DeserializeObject<ResultDTO<object>>(testcontroller.UpdateArea(adddto).Content.ReadAsStringAsync().Result);
            var resultlist2 = JsonConvert.DeserializeObject<List<AreaResultDTO>>(testcontroller.GetAreaTree(searchdtostr).Content.ReadAsStringAsync().Result);
            target = resultlist2.Where(m => m.AreaName == "修改单元测试大小区").FirstOrDefault();
            Assert.IsNotNull(target);

            //删除
            AreaOperateDTO deletedto = new AreaOperateDTO();
            deletedto.AreaID = target.AreaID;
            var deletedtostr = TransformHelper.ConvertDTOTOBase64JsonString(deletedto);
            var deleteresult = JsonConvert.DeserializeObject<bool>(testcontroller.DeleteArea(deletedtostr).Content.ReadAsStringAsync().Result);
            var resultlist3 = JsonConvert.DeserializeObject<List<AreaResultDTO>>(testcontroller.GetAreaTree(searchdtostr).Content.ReadAsStringAsync().Result);
            target = resultlist3.Where(m => m.AreaID == target.AreaID).FirstOrDefault();
            Assert.IsNull(target);
        }
    }
}
