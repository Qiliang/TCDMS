using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TCSOFT.DMS.MasterData.IServices;
using TCSOFT.DMS.MasterData.DTO.Product.ProductInfo;
using System.Collections.Generic;
using System.Linq;
using TCSOFT.DMS.MasterData.DTO.Product.ProductPriceInfo;
using TCSOFT.DMS.MasterData.DTO.Product.InstrumentType;

namespace TCSOFT.DMS.MasterData.Services.Tests
{
    [TestClass]
    public class UnitTest9
    {
        IProductServices _IProductServices = new ProductServices();
        [TestMethod]
        public void TestMethod1()
        {
            //查询试剂产品
            ProductInfoSearchDTO dto = new ProductInfoSearchDTO();
            dto.page = 1;
            dto.rows = 1;
            List<ProductInfoResultDTO> list = _IProductServices.GetReagentInfoList(dto);

            //产品试剂产品
            ProductInfoOperateDTO dto1 = new ProductInfoOperateDTO();
            dto1.ProductID = Guid.NewGuid();
            dto1.ArtNo = "测试货号Test";
            dto1.ProductName = "测试试剂产品Test";
            dto1.RemarkDes = "测试备注Test";
            dto1.ReagentTest = "测试测试数Test";
            dto1.ReagentSize = "测试规格Test";
            dto1.ReagentProject = "测试项目Test";
            dto1.IsMaintenance = false;
            dto1.IsActive = true;
            dto1.CreateUser = "我";
            dto1.CreateTime = DateTime.Now;
            bool bl = _IProductServices.AddReagentInfo(dto1);
            Assert.IsTrue(bl);

            //查询试剂产品
            ProductInfoSearchDTO dto2 = new ProductInfoSearchDTO();
            dto2.SearchText = "测试试剂产品Test";
            dto2.page = 1;
            dto2.rows = 1;
            List<ProductInfoResultDTO> list1 = _IProductServices.GetReagentInfoList(dto2);

            //修改试剂产品
            ProductInfoOperateDTO dto3 = new ProductInfoOperateDTO();
            dto3.ProductID = list1.Select(s => s.ProductID).FirstOrDefault();
            dto3.ArtNo = "修改测试货号Test";
            dto3.ProductName = "修改测试试剂产品Test";
            dto3.RemarkDes = "修改测试备注Test";
            dto3.ReagentTest = "修改测试测试数Test";
            dto3.ReagentSize = "修改测试规格Test";
            dto3.ReagentProject = "修改测试项目Test";
            dto3.IsMaintenance = false;
            dto3.IsActive = true;
            dto1.ModifyUser = "你";
            dto1.ModifyTime = DateTime.Now;
            bool bl1 = _IProductServices.UpdateReagentInfo(dto3);
            Assert.IsTrue(bl1);

            //停启用试剂产品
            ProductInfoOperateDTO dto4 = new ProductInfoOperateDTO();
            dto4.ProductID = list1.Select(s => s.ProductID).FirstOrDefault();
            dto4.IsActive = true;
            dto4.ModifyUser = "你";
            dto4.ModifyTime = DateTime.Now;
            bool bl2 = _IProductServices.StartOrStopReagentInfo(dto4);
            Assert.IsTrue(bl2);

            //删除试剂产品
            ProductInfoOperateDTO dto5 = new ProductInfoOperateDTO();
            dto5.ProductID = list1.Select(s => s.ProductID).FirstOrDefault();
            bool bl3 = _IProductServices.DeleteReagentInfo(dto5);
            Assert.IsTrue(bl3);
        }

        [TestMethod]
        public void TestMethod2()
        {
            //查询仪器类型
            List<InstrumentTypeResultDTO> list = _IProductServices.GetInstrumentTypeList();

            //新增仪器类型
            InstrumentTypeOperateDTO dto1 = new InstrumentTypeOperateDTO();
            dto1.InstrumentTypeName = "测试仪器类型Test";
            dto1.CreateUser = "我";
            dto1.CreateTime = DateTime.Now;
            bool bl = _IProductServices.AddInstrumentType(dto1);
            Assert.IsTrue(bl);

            //查询仪器类型
            List<InstrumentTypeResultDTO> list1 = _IProductServices.GetInstrumentTypeList();
            list1 = list1.Where(p => p.InstrumentTypeName == "测试仪器类型Test").ToList();

            //修改仪器类型
            InstrumentTypeOperateDTO dto3 = new InstrumentTypeOperateDTO();
            dto3.InstrumentTypeID = list1.Select(s => s.InstrumentTypeID).FirstOrDefault();
            dto3.InstrumentTypeName = "测试仪器类型Test";
            dto3.ModifyUser = "你";
            dto3.ModifyTime = DateTime.Now;
            bool bl1 = _IProductServices.UpdateInstrumentType(dto3);
            Assert.IsTrue(bl1);

            //删除仪器类型
            InstrumentTypeSearchDTO dto5 = new InstrumentTypeSearchDTO();
            dto5.InstrumentTypeID = list1.Select(s => s.InstrumentTypeID).FirstOrDefault();
            bool bl3 = _IProductServices.DeleteInstrumentType(dto5);
            Assert.IsTrue(bl3);
        }
    }
}
