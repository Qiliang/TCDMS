using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TCSOFT.DMS.MasterData.IServices;
using TCSOFT.DMS.MasterData.DTO.Distributor.DistributorType;
using System.Collections.Generic;
using TCSOFT.DMS.MasterData.DTO.Distributor.DistributorServiceType;
using System.Linq;

namespace TCSOFT.DMS.MasterData.Services.Tests
{
    
    [TestClass]
    public class UnitTest4
    {
        IDistributorServices _IDistributorServices = new DistributorServices();
        [TestMethod]
        public void TestMethod1()
        {
            //查询经销商类别
            DistributorTypeSearchDTO dto=new DistributorTypeSearchDTO();
            List<DistributorTypeResultDTO> list = _IDistributorServices.GetDistributorType(dto);

            //经销商类别新增
            DistributorTypeOperateDTO dto1 = new DistributorTypeOperateDTO();
            dto1.DistributorTypeName = "测试类别Test";
            dto1.CreateUser = "我";
            dto1.CreateTime = DateTime.Now;
            bool bl = _IDistributorServices.AddDistributorType(dto1);
            Assert.IsTrue(bl);

            //查询经销商类别
            DistributorTypeSearchDTO dto2 = new DistributorTypeSearchDTO();
            List<DistributorTypeResultDTO> list1 = _IDistributorServices.GetDistributorType(dto2);

            //修改经销商类别
            DistributorTypeOperateDTO dto3 = new DistributorTypeOperateDTO();
            dto3.DistributorTypeID = list1.Where(p => p.DistributorTypeName == "测试类别Test").Select(s => s.DistributorTypeID).FirstOrDefault();
            dto3.DistributorTypeName = "修改测试类别Test";
            dto3.ModifyUser = "你";
            dto3.ModifyTime = DateTime.Now;
            bool bl1 = _IDistributorServices.UpdateDistributorType(dto3);
            Assert.IsTrue(bl1);

            //删除经销商类别
            DistributorTypeOperateDTO dto4 = new DistributorTypeOperateDTO();
            dto4.DistributorTypeID = list1.Where(p => p.DistributorTypeName == "测试类别Test").Select(s => s.DistributorTypeID).FirstOrDefault();
            bool bl2 = _IDistributorServices.DeleteDistributorType(dto4);
            Assert.IsTrue(bl2);
        }

        [TestMethod]
        public void TestMethod2()
        {
            //查询经销商服务类型
            DistributorServiceTypeSearchDTO dto = new DistributorServiceTypeSearchDTO();
            List<DistributorServiceTypeResultDTO> list = _IDistributorServices.GetDistributorServiceType(dto);

            //经销商服务类型新增
            DistributorServiceTypeOperateDTO dto1 = new DistributorServiceTypeOperateDTO();
            dto1.DistributorServiceTypeName = "测试服务类型Test";
            dto1.CreateUser = "我";
            dto1.CreateTime = DateTime.Now;
            bool bl = _IDistributorServices.AddDistributorServiceType(dto1);
            Assert.IsTrue(bl);

            //查询经销商服务类型
            DistributorServiceTypeSearchDTO dto2 = new DistributorServiceTypeSearchDTO();
            List<DistributorServiceTypeResultDTO> list1 = _IDistributorServices.GetDistributorServiceType(dto2);

            //修改经销商服务类型
            DistributorServiceTypeOperateDTO dto3 = new DistributorServiceTypeOperateDTO();
            dto3.DistributorServiceTypeID = list1.Where(p => p.DistributorServiceTypeName == "测试服务类型Test").Select(s => s.DistributorServiceTypeID).FirstOrDefault();
            dto3.DistributorServiceTypeName = "修改测试服务类型Test";
            dto3.ModifyUser = "你";
            dto3.ModifyTime = DateTime.Now;
            bool bl1 = _IDistributorServices.UpdateDistributorServiceType(dto3);
            Assert.IsTrue(bl1);

            //删除经销商服务类型
            DistributorServiceTypeOperateDTO dto4 = new DistributorServiceTypeOperateDTO();
            dto4.DistributorServiceTypeID = list1.Where(p => p.DistributorServiceTypeName == "测试服务类型Test").Select(s => s.DistributorServiceTypeID).FirstOrDefault();
            bool bl2 = _IDistributorServices.DeleteDistributorServiceType(dto4);
            Assert.IsTrue(bl2);
        }
    }
}
