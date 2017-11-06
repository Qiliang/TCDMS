using System;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TCSOFT.DMS.MasterDataAPI.Controllers;
using TCSOFT.DMS.MasterData.DTO.Common;
using Newtonsoft.Json;
using System.Collections.Generic;
using TCSOFT.DMS.Common;
using TCSOFT.DMS.MasterData.DTO.RateDTO;

namespace TCSOFT.DMS.MasterDataAPI.Tests
{
    
    [TestClass]
    public class UnitTest6
    {
        RateController testcontroller = new RateController();
        [TestMethod]
        public void TestMethod1()
        {
            //汇率
            //新增
            testcontroller.GetRateList();
            RateOperateDTO adddto = new RateOperateDTO();
            adddto.CreateTime = DateTime.Now;
            adddto.CreateUser = "测试人员001";
            adddto.Currency = "TestCurrencyTest";
            adddto.AprilRate = (decimal)6.12;
            adddto.AugustRate = (decimal)6.2;
            adddto.DecRate = (decimal)7.12;
            adddto.FebRate = (decimal)12.9001;
            adddto.JulyRate = (decimal)23.908;
            adddto.JuneRate = (decimal)12.9;
            adddto.MarchRate = (decimal)8.23;
            adddto.MayRate = (decimal)12;
            adddto.MonthRate = (decimal)7.098;
            adddto.NovRate = (decimal)10.98;
            adddto.OctRate = (decimal)7.90;
            adddto.RateBudget = (decimal)14;
            adddto.SepRate = (decimal)13.1;
            adddto.RateCode = "testratecode";
            adddto.RateYear = 2017;
            var addresult = JsonConvert.DeserializeObject<bool>(testcontroller.AddRate(adddto).Content.ReadAsStringAsync().Result);
            var resultlist1 = JsonConvert.DeserializeObject<List<RateResultDTO>>(testcontroller.GetRateList().Content.ReadAsStringAsync().Result);
            var target = resultlist1.Where(m => m.Currency == "TestCurrencyTest").FirstOrDefault();
            Assert.IsNotNull(target);

            //修改
            adddto.RateID = target.RateID;
            adddto.Currency = "TestCurrency";
            adddto.AprilRate = (decimal)6.12;
            adddto.AugustRate = (decimal)6.2;
            adddto.DecRate = (decimal)7.12;
            adddto.FebRate = (decimal)12.9001;
            adddto.JulyRate = (decimal)23.908;
            adddto.JuneRate = (decimal)12.9;
            adddto.MarchRate = (decimal)8.23;
            adddto.MayRate = (decimal)12;
            adddto.MonthRate = (decimal)7.098;
            adddto.NovRate = (decimal)10.98;
            adddto.OctRate = (decimal)7.90;
            adddto.RateBudget = (decimal)14;
            adddto.SepRate = (decimal)13.1;
            adddto.RateCode = "testratecodetest111";
            adddto.RateYear = 2017;
            var updateresult = JsonConvert.DeserializeObject<bool>(testcontroller.UpdateRate(adddto).Content.ReadAsStringAsync().Result);
            var resultlist2 = JsonConvert.DeserializeObject<List<RateResultDTO>>(testcontroller.GetRateList().Content.ReadAsStringAsync().Result);
            target = resultlist2.Where(m => m.RateID == target.RateID && m.RateCode == "testratecodetest111").FirstOrDefault();
            Assert.IsNotNull(target);

            //删除
            RateSearchDTO deletedto = new RateSearchDTO();
            deletedto.RateID = target.RateID;
            var deletedtostr = TransformHelper.ConvertDTOTOBase64JsonString(deletedto);
            var deleteresult = JsonConvert.DeserializeObject<bool>(testcontroller.DeleteRate(deletedtostr).Content.ReadAsStringAsync().Result);
            var resultlist3 = JsonConvert.DeserializeObject<List<RateResultDTO>>(testcontroller.GetRateList().Content.ReadAsStringAsync().Result);
            target = resultlist3.Where(m => m.RateID == target.RateID).FirstOrDefault();
            Assert.IsNull(target);
        }
    }
}
