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

namespace TCSOFT.DMS.MasterDataAPI.Tests
{
    [TestClass]
    public class UnitTest4
    {
        DepartmentController testcontroller = new DepartmentController();
        [TestMethod]
        public void TestMethod1()
        {
            //部门
            //新增
            testcontroller.GetDepartmentList();
            DepartmentOperateDTO adddto = new DepartmentOperateDTO();
            adddto.DepartName = "单元测试部门";
            var addresult = JsonConvert.DeserializeObject<ResultDTO<object>>(testcontroller.AddDepartment(adddto).Content.ReadAsStringAsync().Result);
            var resultlist1 = JsonConvert.DeserializeObject<List<DepartmentResultDTO>>(testcontroller.GetDepartmentList().Content.ReadAsStringAsync().Result);
            var target = resultlist1.Where(m => m.DepartName == "单元测试部门").FirstOrDefault();
            Assert.IsNotNull(target);

            //修改
            adddto.DepartID = target.DepartID;
            adddto.DepartName = "修改单元测试部门";
            var updateresult = JsonConvert.DeserializeObject<ResultDTO<object>>(testcontroller.UpdateDepartment(adddto).Content.ReadAsStringAsync().Result);
            var resultlist2 = JsonConvert.DeserializeObject<List<DepartmentResultDTO>>(testcontroller.GetDepartmentList().Content.ReadAsStringAsync().Result);
            target = resultlist2.Where(m => m.DepartName == "修改单元测试部门").FirstOrDefault();
            Assert.IsNotNull(target);

            //删除
            DepartmentSearchDTO deletedto = new DepartmentSearchDTO();
            deletedto.DepartID = target.DepartID;
            var deletedtostr = TransformHelper.ConvertDTOTOBase64JsonString(deletedto);
            var deleteresultstr = testcontroller.DeleteDepartment(deletedtostr).Content.ReadAsStringAsync().Result;
            var deleteresult = JsonConvert.DeserializeObject<ResultDTO<object>>(deleteresultstr);
            var resultlist3= JsonConvert.DeserializeObject<List<DepartmentResultDTO>>(testcontroller.GetDepartmentList().Content.ReadAsStringAsync().Result);
            target = resultlist3.Where(m => m.DepartID == target.DepartID).FirstOrDefault();
            Assert.IsNull(target);
        }
    }
}
