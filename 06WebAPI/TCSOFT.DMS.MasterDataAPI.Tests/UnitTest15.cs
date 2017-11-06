using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TCSOFT.DMS.MasterDataAPI.Controllers;
using TCSOFT.DMS.MasterData.DTO.Product.InstrumentType;
using Newtonsoft.Json;
using TCSOFT.DMS.MasterData.DTO.Common;
using TCSOFT.DMS.MasterData.DTO.AccountDate;
using System.Collections.Generic;
using TCSOFT.DMS.Common;

namespace TCSOFT.DMS.MasterDataAPI.Tests
{
    [TestClass]
    public class UnitTest15
    {
        InstrumentTypeController testcontroller = new InstrumentTypeController();
        [TestMethod]
        public void TestMethod1()
        {
            //仪器类型
            //新增
            testcontroller.GetInstrumentTypeList();
            InstrumentTypeOperateDTO adddto = new InstrumentTypeOperateDTO();
            adddto.InstrumentTypeName = "单元测试钢材";
            adddto.CreateTime =DateTime.Now;
            var addresult = JsonConvert.DeserializeObject<ResultDTO<object>>(testcontroller.AddInstrumentType(adddto).Content.ReadAsStringAsync().Result);
            var resultlist1 = JsonConvert.DeserializeObject<List<InstrumentTypeResultDTO>>(testcontroller.GetInstrumentTypeList().Content.ReadAsStringAsync().Result);
            var target = resultlist1.Where(m => m.InstrumentTypeName == "单元测试钢材").FirstOrDefault();
            Assert.IsNotNull(target);

            //修改
            adddto.InstrumentTypeID = target.InstrumentTypeID;
            adddto.InstrumentTypeName = "修改单元测试仪器类型名称";
            var updateresult = JsonConvert.DeserializeObject<ResultDTO<object>>(testcontroller.UpdateInstrumentType(adddto).Content.ReadAsStringAsync().Result);
            var resultlist2 = JsonConvert.DeserializeObject<List<InstrumentTypeResultDTO>>(testcontroller.GetInstrumentTypeList().Content.ReadAsStringAsync().Result);
            target = resultlist2.Where(m => m.InstrumentTypeName == "修改单元测试仪器类型名称").FirstOrDefault();
            Assert.IsNotNull(target);

            //删除
            InstrumentTypeSearchDTO deletedto = new InstrumentTypeSearchDTO();
            deletedto.InstrumentTypeID = target.InstrumentTypeID;
            var deletedtostr = TransformHelper.ConvertDTOTOBase64JsonString(deletedto);
            var deleteresult = JsonConvert.DeserializeObject<ResultDTO<object>>(testcontroller.DeleteProductType(deletedtostr).Content.ReadAsStringAsync().Result);
            var resultlist3 = JsonConvert.DeserializeObject<List<InstrumentTypeResultDTO>>(testcontroller.GetInstrumentTypeList().Content.ReadAsStringAsync().Result);
            target = resultlist3.Where(m => m.InstrumentTypeID == target.InstrumentTypeID).FirstOrDefault();
            Assert.IsNull(target);

        }
    }
}
