using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TCSOFT.DMS.MasterData.DTO.Role;
using TCSOFT.DMS.Common;
using TCSOFT.DMS.MasterDataAPI.Controllers;
using Newtonsoft.Json;
using TCSOFT.DMS.MasterData.DTO.Common;
using System.Collections.Generic;
using System.Linq;

namespace TCSOFT.DMS.MasterDataAPI.Tests
{
    [TestClass]
    public class UnitTest19
    {
        RoleController testcontroller = new RoleController();
        [TestMethod]
        public void TestMethod1()
        {
            //角色管理
            //新增
            RoleSearchDTO adddto = new RoleSearchDTO();
            var searchdtostr = TransformHelper.ConvertDTOTOBase64JsonString(adddto);
            testcontroller.GetRoleList(searchdtostr);
            RoleOperateDTO adddtotest = new RoleOperateDTO();
            adddtotest.RoleName = "单元测试角色";
            var addresult = JsonConvert.DeserializeObject<ResultDTO<object>>(testcontroller.AddRole(adddtotest).Content.ReadAsStringAsync().Result);
            var resultlist1 = JsonConvert.DeserializeObject<List<RoleResultDTO>>(testcontroller.GetRoleList(searchdtostr).Content.ReadAsStringAsync().Result);
            var target = resultlist1.Where(m => m.RoleName == "单元测试角色").FirstOrDefault();
            Assert.IsNotNull(target);
            
            //修改
            adddtotest.RoleID = target.RoleID;
            adddtotest.RoleName = "修改成功的单元测试角色";
            var updateresult = JsonConvert.DeserializeObject<ResultDTO<object>>(testcontroller.UpdateRole(adddtotest).Content.ReadAsStringAsync().Result);
            var resultlist2 = JsonConvert.DeserializeObject<List<RoleResultDTO>>(testcontroller.GetRoleList(searchdtostr).Content.ReadAsStringAsync().Result);
            target = resultlist2.Where(m => m.RoleName == "修改成功的单元测试角色").FirstOrDefault();
            Assert.IsNotNull(target);

            //删除
            RoleSearchDTO deleteDto = new RoleSearchDTO();
            deleteDto.RoleID = target.RoleID;
            var deleteDtoster = TransformHelper.ConvertDTOTOBase64JsonString(deleteDto);
            var deleteresult = JsonConvert.DeserializeObject<ResultDTO<object>>(testcontroller.DeleteRole(deleteDtoster).Content.ReadAsStringAsync().Result);
            var resultlist3 = JsonConvert.DeserializeObject<List<RoleResultDTO>>(testcontroller.GetRoleList(searchdtostr).Content.ReadAsStringAsync().Result);
            target = resultlist3.Where(m => m.RoleID == target.RoleID).FirstOrDefault();
            Assert.IsNull(target);
        }
    }
}
