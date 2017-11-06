using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TCSOFT.DMS.MasterData.IServices;
using TCSOFT.DMS.MasterData.DTO;
using System.Collections.Generic;
using TCSOFT.DMS.MasterData.DTO.Common;

namespace TCSOFT.DMS.MasterData.Services.Tests
{
    [TestClass]
    public class UnitTest2
    {
        ICommonServices _ICommonServices = new CommonServices();
        [TestMethod]
        public void TestMethod1()
        {
            //取得所有模块
            List<StructureDTO> list = _ICommonServices.GetAllStructure();
            Assert.IsNotNull(list);

            //取得所有功能按钮
            List<ButtonDTO> list1 = _ICommonServices.GetAllButton();
            Assert.IsNotNull(list1);

            //取得取得用户权限
            //用户名为系统管理员的权限
            List<CurrentAuthorityDTO> list2 = _ICommonServices.GetUserAuthority(1);
            Assert.IsNotNull(list2);

            //取得角色权限
            //角色为系统管理员的权限
            List<CurrentAuthorityDTO> list3 = _ICommonServices.GetRoleAuthority(new List<int> { 1 });
            Assert.IsNotNull(list3);

            //取得角色类型权限
            //类型为系统管理员的权限
            List<CurrentAuthorityDTO> list4 = _ICommonServices.GetRoleTypeAuthority(0);
            Assert.IsNotNull(list4);

            //取得所有管理员信息
            //系统管理员的信息
            AdminSearchDTO dto = new AdminSearchDTO();
            dto.RoleIdList = new List<int>() { 0 };
            List<AdminDTO> list5 = _ICommonServices.GetAdminInfo(dto);
            Assert.IsNotNull(list5);
        }
    }
}
