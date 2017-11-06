using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TCSOFT.DMS.MasterDataAPI.Controllers;
using TCSOFT.DMS.MasterData.DTO.AccountDate;
using Newtonsoft.Json;
using TCSOFT.DMS.MasterData.DTO.Common;
using System.Collections.Generic;
using TCSOFT.DMS.Common;
using TCSOFT.DMS.MasterData.DTO.UsersStat;

namespace TCSOFT.DMS.MasterDataAPI.Tests
{
    [TestClass]
    public class UnitTest14
    {
        UsersStatController testcontroller = new UsersStatController();
        [TestMethod]
        public void TestMethod1()
        {
            //用户统计
            //新增
            UsersStatSearchDTO searchdto = new UsersStatSearchDTO();
            searchdto.page = 1;
            searchdto.rows = 1;
            var searchdtostr = TransformHelper.ConvertDTOTOBase64JsonString(searchdto);
            testcontroller.GetUsersStatList(searchdtostr);
            UsersStatOperateDTO adddto = new UsersStatOperateDTO();
            adddto.UseModel = "单元测试用户统计";
            adddto.UseModelTime = DateTime.Now;
            searchdto.rows = 20;
            searchdtostr = TransformHelper.ConvertDTOTOBase64JsonString(searchdto);
            var addresult= testcontroller.AddUsersStat(adddto);
            var resultlist1 = JsonConvert.DeserializeObject<ResultDTO<List<UsersStatResultDTO>>>(testcontroller.GetUsersStatList(searchdtostr).Content.ReadAsStringAsync().Result).Object;
            var target = resultlist1.Where(m => m.UseModel == "单元测试用户统计").FirstOrDefault();
            Assert.IsNotNull(target);

            //删除
            UsersStatResultDTO deletedto = new UsersStatResultDTO();
            deletedto.UsersStatID = target.UsersStatID;
            var deletedtostr = TransformHelper.ConvertDTOTOBase64JsonString(deletedto);
            var deleteresult = testcontroller.DeleteUsersStat(deletedtostr);
            var resultlist3 = JsonConvert.DeserializeObject<ResultDTO<List<UsersStatResultDTO>>>(testcontroller.GetUsersStatList(searchdtostr).Content.ReadAsStringAsync().Result).Object;
            target = resultlist3.Where(m => m.UsersStatID == target.UsersStatID).FirstOrDefault();
            Assert.IsNull(target);
        }
    }
}
