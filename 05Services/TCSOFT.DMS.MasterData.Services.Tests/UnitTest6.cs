using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TCSOFT.DMS.MasterData.IServices;
using TCSOFT.DMS.MasterData.DTO.Product.ProductLine;
using System.Collections.Generic;
using System.Linq;
using TCSOFT.DMS.MasterData.DTO.Product.ProductSmallType;
using TCSOFT.DMS.MasterData.DTO.Product.ProductModel;
using TCSOFT.DMS.MasterData.DTO.Product.ProductType;

namespace TCSOFT.DMS.MasterData.Services.Tests
{
    [TestClass]
    public class UnitTest6
    {
        IProductServices _IProductServices = new ProductServices();
        [TestMethod]
        public void TestMethod1()
        {
            //查询产品线
            ProductLineSearchDTO dto = new ProductLineSearchDTO();
            List<ProductLineResultDTO> list = _IProductServices.GetProductLine(dto);

            //产品线新增
            ProductLineOperateDTO dto1 = new ProductLineOperateDTO();
            dto1.ProductLineName = "测试产品线Test";
            dto1.ProductLineNameAB = "cscpxTest";
            dto1.CreateUser = "我";
            dto1.CreateTime = DateTime.Now;
            bool bl = _IProductServices.AddProductLine(dto1);
            Assert.IsTrue(bl);

            //查询产品线
            ProductLineSearchDTO dto2 = new ProductLineSearchDTO();
            dto2.SearchText = "测试产品线Test";
            List<ProductLineResultDTO> list1 = _IProductServices.GetProductLine(dto2);

            //修改产品线
            ProductLineOperateDTO dto3 = new ProductLineOperateDTO();
            dto3.ProductLineID = list1.Select(s => s.ProductLineID).FirstOrDefault();
            dto3.ProductLineName = "修改测试产品线Test";
            dto3.ProductLineNameAB = "cscpxTest";
            dto3.ModifyUser = "你";
            dto3.ModifyTime = DateTime.Now;
            bool bl1 = _IProductServices.UpdateProductLine(dto3);
            Assert.IsTrue(bl1);

            //删除产品线
            ProductLineOperateDTO dto4 = new ProductLineOperateDTO();
            dto4.ProductLineID = list1.Select(s => s.ProductLineID).FirstOrDefault();
            bool bl2 = _IProductServices.DeleteProductLine(dto4);
            Assert.IsTrue(bl2);
        }

        [TestMethod]
        public void TestMethod2()
        {
            //查询产品小类
            ProductSmallTypeSearchDTO dto = new ProductSmallTypeSearchDTO();
            List<ProductSmallTypeResultDTO> list = _IProductServices.GetProductSmallType(dto);

            //查询产品线
            ProductLineSearchDTO dtoline = new ProductLineSearchDTO();
            List<ProductLineResultDTO> listline = _IProductServices.GetProductLine(dtoline);
            if (listline.Count() == 0) 
            {
                return;
            }
            //产品小类新增
            ProductSmallTypeOperateDTO dto1 = new ProductSmallTypeOperateDTO();
            dto1.ProductSmallTypeName = "测试产品小类Test";
            dto1.ProductLineID = listline.Select(s => s.ProductLineID).FirstOrDefault();
            dto1.IsActive = true;
            dto1.CreateUser = "我";
            dto1.CreateTime = DateTime.Now;
            bool bl = _IProductServices.AddProductSmallType(dto1);
            Assert.IsTrue(bl);

            //查询产品小类
            ProductSmallTypeSearchDTO dto2 = new ProductSmallTypeSearchDTO();
            dto2.SearchText = "测试产品小类Test";
            List<ProductSmallTypeResultDTO> list1 = _IProductServices.GetProductSmallType(dto2);

            //修改产品小类
            ProductSmallTypeOperateDTO dto3 = new ProductSmallTypeOperateDTO();
            dto3.ProductSmallTypeID = list1.Select(s => s.ProductSmallTypeID).FirstOrDefault();
            dto3.ProductSmallTypeName = "修改测试产品小类Test";
            dto3.ProductLineID = listline.Select(s => s.ProductLineID).FirstOrDefault();
            dto3.ModifyUser = "你";
            dto3.ModifyTime = DateTime.Now;
            bool bl1 = _IProductServices.UpdateProductSmallType(dto3);
            Assert.IsTrue(bl1);

            //停启用产品小类
            ProductSmallTypeOperateDTO dto4 = new ProductSmallTypeOperateDTO();
            dto4.ProductSmallTypeID = list1.Select(s => s.ProductSmallTypeID).FirstOrDefault();
            dto4.IsActive = true;
            dto4.ModifyUser = "你";
            dto4.ModifyTime = DateTime.Now;
            bool bl2 = _IProductServices.StopEnableProductSmallType(dto4);
            Assert.IsTrue(bl2);

            //删除产品小类
            ProductSmallTypeOperateDTO dto5 = new ProductSmallTypeOperateDTO();
            dto5.ProductSmallTypeID = list1.Select(s => s.ProductSmallTypeID).FirstOrDefault();
            bool bl3 = _IProductServices.DeleteProductSmallType(dto5);
            Assert.IsTrue(bl3);
        }

        [TestMethod]
        public void TestMethod3()
        {
            //查询产品型号
            ProductModelSearchDTO dto = new ProductModelSearchDTO();
            List<ProductModelResultDTO> list = _IProductServices.GetProductModel(dto);

            //产品型号新增
            ProductModelOperateDTO dto1 = new ProductModelOperateDTO();
            dto1.ProductModelName = "测试产品型号Test";
            dto1.IsActive = true;
            dto1.CreateUser = "我";
            dto1.CreateTime = DateTime.Now;
            bool bl = _IProductServices.AddProductModel(dto1);
            Assert.IsTrue(bl);

            //查询产品型号
            ProductModelSearchDTO dto2 = new ProductModelSearchDTO();
            dto2.SearchText = "测试产品型号Test";
            List<ProductModelResultDTO> list1 = _IProductServices.GetProductModel(dto2);

            //修改产品型号
            ProductModelOperateDTO dto3 = new ProductModelOperateDTO();
            dto3.ProductModelID = list1.Select(s => s.ProductModelID).FirstOrDefault();
            dto3.ProductModelName = "修改测试产品型号Test";
            dto3.ModifyUser = "你";
            dto3.ModifyTime = DateTime.Now;
            bool bl1 = _IProductServices.UpdateProductModel(dto3);
            Assert.IsTrue(bl1);

            //停启用产品型号
            ProductModelOperateDTO dto4 = new ProductModelOperateDTO();
            dto4.ProductModelID = list1.Select(s => s.ProductModelID).FirstOrDefault();
            dto4.IsActive = true;
            dto4.ModifyUser = "你";
            dto4.ModifyTime = DateTime.Now;
            bool bl2 = _IProductServices.StopEnableProductModel(dto4);
            Assert.IsTrue(bl2);

            //删除产品型号
            ProductModelOperateDTO dto5 = new ProductModelOperateDTO();
            dto5.ProductModelID = list1.Select(s => s.ProductModelID).FirstOrDefault();
            bool bl3 = _IProductServices.DeleteProductModel(dto5);
            Assert.IsTrue(bl3);
        }

        [TestMethod]
        public void TestMethod4()
        {
            //查询产品类型
            ProductTypeSearchDTO dto = new ProductTypeSearchDTO();
            List<ProductTypeResultDTO> list = _IProductServices.GetProductTypeList(dto);

            //产品类型新增
            ProductTypeOperateDTO dto1 = new ProductTypeOperateDTO();
            dto1.ProductTypeName = "测试产品类型Test";
            dto1.ProductTypeAB = "cscplxTest";
            dto1.OracleName = "ON测试产品类型Test";
            dto1.CreateUser = "我";
            dto1.CreateTime = DateTime.Now;
            bool bl = _IProductServices.AddProductType(dto1);
            Assert.IsTrue(bl);

            //查询产品类型
            ProductTypeSearchDTO dto2 = new ProductTypeSearchDTO();
            dto2.SearchText = "测试产品类型Test";
            List<ProductTypeResultDTO> list1 = _IProductServices.GetProductTypeList(dto2);

            //修改产品类型
            ProductTypeOperateDTO dto3 = new ProductTypeOperateDTO();
            dto3.ProductTypeID = list1.Select(s => s.ProductTypeID).FirstOrDefault();
            dto1.ProductTypeName = "修改测试产品类型Test";
            dto1.ProductTypeAB = "cscplxTest";
            dto1.OracleName = "修改ON测试产品类型Test";
            dto3.ModifyUser = "你";
            dto3.ModifyTime = DateTime.Now;
            bool bl1 = _IProductServices.UpdateProductType(dto3);
            Assert.IsTrue(bl1);

            //删除产品类型
            ProductTypeSearchDTO dto5 = new ProductTypeSearchDTO();
            dto5.ProductTypeID = list1.Select(s => s.ProductTypeID).FirstOrDefault();
            bool bl3 = _IProductServices.DeleteProductType(dto5);
            Assert.IsTrue(bl3);
        }
    }
}
