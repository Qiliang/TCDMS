using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TCSOFT.DMS.MasterDataAPI.Controllers;
using TCSOFT.DMS.MasterData.DTO.AccountDate;
using Newtonsoft.Json;
using TCSOFT.DMS.MasterData.DTO.Common;
using System.Collections.Generic;
using TCSOFT.DMS.Common;

namespace TCSOFT.DMS.MasterDataAPI.Tests
{
    [TestClass]
    public class UnitTest8
    {
        AccountDateController testcontroller = new AccountDateController(); 
        [TestMethod]
        public void TestMethod1()
        {
            //关账日
            //新增
            testcontroller.GetAccountDateList();
            AccountDateOperateDTO adddto = new AccountDateOperateDTO();
            adddto.AccountDateBelongModel = "基础数据";
            adddto.AccountDateName = "单元测试关账日名称";
            var addresult = JsonConvert.DeserializeObject<ResultDTO<object>>(testcontroller.AddAccountDate(adddto).Content.ReadAsStringAsync().Result);
            var resultlist1 = JsonConvert.DeserializeObject<List<AccountDateResultDTO>>(testcontroller.GetAccountDateList().Content.ReadAsStringAsync().Result);
            var target = resultlist1.Where(m => m.AccountDateName == "单元测试关账日名称").FirstOrDefault();
            Assert.IsNotNull(target);

            //修改
            adddto.AccountDateID = target.AccountDateID;
            adddto.AccountDateName = "修改单元测试关账日名称";
            var updateresult = JsonConvert.DeserializeObject<ResultDTO<object>>(testcontroller.UpdateAccountDate(adddto).Content.ReadAsStringAsync().Result);
            var resultlist2 = JsonConvert.DeserializeObject<List<AccountDateResultDTO>>(testcontroller.GetAccountDateList().Content.ReadAsStringAsync().Result);
            target = resultlist2.Where(m => m.AccountDateName == "修改单元测试关账日名称").FirstOrDefault();
            Assert.IsNotNull(target);

            //删除
            AccountDateSearchDTO deletedto = new AccountDateSearchDTO();
            deletedto.AccountDateID = target.AccountDateID;
            var deletedtostr = TransformHelper.ConvertDTOTOBase64JsonString(deletedto);
            var deleteresult = JsonConvert.DeserializeObject<ResultDTO<object>>(testcontroller.DeleteAccountDate(deletedtostr).Content.ReadAsStringAsync().Result);
            var resultlist3 = JsonConvert.DeserializeObject<List<AccountDateResultDTO>>(testcontroller.GetAccountDateList().Content.ReadAsStringAsync().Result);
            target = resultlist3.Where(m => m.AccountDateID == target.AccountDateID).FirstOrDefault();
            Assert.IsNull(target);
        }
    }
}
