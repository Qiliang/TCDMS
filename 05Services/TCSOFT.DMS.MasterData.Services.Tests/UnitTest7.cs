using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TCSOFT.DMS.MasterData.DTO.Common;
using TCSOFT.DMS.MasterData.DTO.Area;

namespace TCSOFT.DMS.MasterData.Services.Tests
{
    [TestClass]
    public class UnitTest7
    {
        RegionServices testservice = new RegionServices();
      
        [TestMethod]
        public void TestMethod1()
        {
            #region 大小区
            //新增
            AreaSearchDTO searchdto = new AreaSearchDTO();
            testservice.GetAreaTree(searchdto);
            AreaOperateDTO adddto = new AreaOperateDTO();
            adddto.AreaName = "单元测试大小区";
            var addresult = testservice.AddArea(adddto);

            var resultlist1 = testservice.GetAreaTree(searchdto);
            var target = resultlist1.Where(m => m.AreaName == "单元测试大小区").FirstOrDefault();
            Assert.IsNotNull(target);

            //修改
            adddto.AreaID = target.AreaID;
            adddto.AreaName = "修改单元测试大小区";
            var updateresult = testservice.UpdateArea(adddto);
            var resultlist2 = testservice.GetAreaTree(searchdto);
            target = resultlist2.Where(m => m.AreaName == "修改单元测试大小区").FirstOrDefault();
            Assert.IsNotNull(target);

            //删除
            AreaOperateDTO deletedto = new AreaOperateDTO();
            deletedto.AreaID = target.AreaID;
            var deleteresult = testservice.DeleteArea(deletedto);
            var resultlist3 = testservice.GetAreaTree(searchdto);
            target = resultlist3.Where(m => m.AreaID == target.AreaID).FirstOrDefault();
            Assert.IsNull(target);
            #endregion
        }
    }
}
