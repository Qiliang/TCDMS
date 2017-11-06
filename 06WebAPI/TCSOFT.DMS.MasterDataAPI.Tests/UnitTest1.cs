using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TCSOFT.DMS.MasterDataAPI.Controllers;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using TCSOFT.DMS.MasterData.DTO.Common;
using System.Collections.Generic;

namespace TCSOFT.DMS.MasterDataAPI.Tests
{
    [TestClass]
    public class UnitTest1
    {
        CommonController CommonController = new CommonController();
        [TestMethod]
        public void TestMethod1()
        {
            //取得公共信息
            var pp = CommonController.GetAllCommonInfo(1);
            Assert.IsTrue(pp.IsSuccessStatusCode);

            //获取权限
            var pp1 = CommonController.GetAuthority("1", 1, 0);
            Assert.IsTrue(pp1.IsSuccessStatusCode);

            //取得管理员信息
            AdminSearchDTO dto = new AdminSearchDTO();
            dto.RoleIdList = new List<int> { 1 };
            string dtostr = Common.TransformHelper.ConvertDTOTOBase64JsonString(dto);
            var pp2 = CommonController.GetAllAdminInfo(dtostr);
            Assert.IsTrue(pp2.IsSuccessStatusCode);
        }
    }
}
