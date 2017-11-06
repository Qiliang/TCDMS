using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TCSOFT.DMS.MasterData.IServices;
using TCSOFT.DMS.MasterData.DTO.Distributor.Distributor;
using System.Collections.Generic;
using System.Linq;

namespace TCSOFT.DMS.MasterData.Services.Tests
{
    [TestClass]
    public class UnitTest5
    {
        IDistributorServices _IDistributorServices = new DistributorServices();
        [TestMethod]
        public void TestMethod1()
        {
            //查询经销商
            DistributorSearchDTO dto = new DistributorSearchDTO();
            dto.page = 1;
            dto.rows = 1;
            List<DistributorResultDTO> list = _IDistributorServices.GetDistributorList(dto);

            //经销商新增
            DistributorOperateDTO dto1 = new DistributorOperateDTO();
            dto1.DistributorID = Guid.NewGuid();
            dto1.DistributorCode = "csjxsTest";
            dto1.DistributorName = "测试经销商Test";
            dto1.InvoiceCode = "测试发票编号地址Test";
            dto1.DeliverCode = "测试送货编号地址Test";
            dto1.Office = "办事处";
            dto1.CSRNameReagent = "CRS用户名SJ";
            dto1.CSRNameD = "CRS用户名B";
            dto1.CSRNameB = "CRS用户名D";
            dto1.IsActive = true;
            dto1.CreateUser = "我";
            dto1.CreateTime = DateTime.Now;
            bool bl = _IDistributorServices.AddDistributor(dto1);
            Assert.IsTrue(bl);

            //查询经销商
            DistributorSearchDTO dto2 = new DistributorSearchDTO();
            dto2.SearchText = "测试经销商Test";
            dto2.page = 1;
            dto2.rows = 1;
            List<DistributorResultDTO> list1 = _IDistributorServices.GetDistributorList(dto2);
            Assert.IsNotNull(list1);

            //修改经销商
            DistributorOperateDTO dto3 = new DistributorOperateDTO();
            dto3.DistributorID = list1.Select(s => s.DistributorID).FirstOrDefault();
            dto3.DistributorCode = "csjxsTest";
            dto3.DistributorName = "修改测试经销商Test";
            dto3.InvoiceCode = "修改测试发票编号地址Test";
            dto3.DeliverCode = "修改测试送货编号地址Test";
            dto3.Office = "修改办事处";
            dto3.CSRNameReagent = "修改CRS用户名SJ";
            dto3.CSRNameD = "修改CRS用户名B";
            dto3.CSRNameB = "修改CRS用户名D";
            dto3.IsActive = true;
            dto3.ModifyUser = "你";
            dto3.ModifyTime = DateTime.Now;
            bool bl1 = _IDistributorServices.UpdateDistributor(dto3);
            Assert.IsTrue(bl1);

            //停启用经销商
            DistributorOperateDTO dto4 = new DistributorOperateDTO();
            dto4.DistributorID = list1.Select(s => s.DistributorID).FirstOrDefault();
            dto4.IsActive = true;
            dto4.ModifyUser = "你";
            dto4.ModifyTime = DateTime.Now;
            bool bl2 = _IDistributorServices.StartOrStopDistributor(dto4);
            Assert.IsTrue(bl2);


            //删除经销商
            DistributorOperateDTO dto5 = new DistributorOperateDTO();
            dto5.DistributorID = list1.Select(s => s.DistributorID).FirstOrDefault();
            bool bl3 = _IDistributorServices.DeleteDistributor(dto5);
            Assert.IsTrue(bl3);
        }
    }
}
