using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TCSOFT.DMS.MasterDataAPI.Controllers;
using TCSOFT.DMS.MasterData.DTO.Customer;
using Newtonsoft.Json;
using System.Linq;
using TCSOFT.DMS.MasterData.DTO.Common;
using System.Collections.Generic;
using TCSOFT.DMS.Common;

namespace TCSOFT.DMS.MasterDataAPI.Tests
{
    [TestClass]
    public class UnitTest17
    {
        CustomerInfoController testcontroller = new CustomerInfoController();
        [TestMethod]
        public void TestMethod1()
        {
            //客户信息.戴锐
            //新增

            CustomerSearchDTO adddto = new CustomerSearchDTO();
            adddto.page = 1;
            adddto.rows = 1;

           var  dtostr = TransformHelper.ConvertDTOTOBase64JsonString(adddto);
            testcontroller.GetCustomerList(dtostr);
            CustomerOperateDTO adddtotest = new CustomerOperateDTO();
            adddtotest.CustomerName = "单元测试客户名称001";
            adddtotest.CustomerID = Guid.NewGuid();
            var addresult = JsonConvert.DeserializeObject<ResultDTO<object>>(testcontroller.AddCustomer(adddtotest).Content.ReadAsStringAsync().Result);
            adddto.rows = 10;
            adddto.SearchText = "单元测试客户名称001";
            dtostr = TransformHelper.ConvertDTOTOBase64JsonString(adddto);
            var resultlist1 = JsonConvert.DeserializeObject<ResultDTO<List<CustomerResultDTO>>>(testcontroller.GetCustomerList(dtostr).Content.ReadAsStringAsync().Result).Object;
            var target = resultlist1.Where(m => m.CustomerName == "单元测试客户名称001").FirstOrDefault();
            Assert.IsNotNull(target);

            //修改
            adddtotest.CustomerID = target.CustomerID;
            adddtotest.CustomerName = "修改单元测试客户名称的002";
            adddtotest.UpType = 1;
            var updateresult = JsonConvert.DeserializeObject<ResultDTO<object>>(testcontroller.UpdateCustomer(adddtotest).Content.ReadAsStringAsync().Result);
            adddto.SearchText = "修改单元测试客户名称的002";
            dtostr = TransformHelper.ConvertDTOTOBase64JsonString(adddto);
            var resultlist2 = JsonConvert.DeserializeObject<ResultDTO<List<CustomerResultDTO>>>(testcontroller.GetCustomerList(dtostr).Content.ReadAsStringAsync().Result).Object;
            target = resultlist2.Where(m => m.CustomerName == "修改单元测试客户名称的002").FirstOrDefault();
            Assert.IsNotNull(target);

            //删除
            CustomerSearchDTO deletedto = new CustomerSearchDTO();
            deletedto.CustomerID = target.CustomerID;
            var deletedtostr = TransformHelper.ConvertDTOTOBase64JsonString(deletedto);
            var deleteresult = JsonConvert.DeserializeObject<ResultDTO<object>>(testcontroller.DeleteCustomer(deletedtostr).Content.ReadAsStringAsync().Result);
            var resultlist3 = JsonConvert.DeserializeObject<ResultDTO<List<CustomerResultDTO>>>(testcontroller.GetCustomerList(dtostr).Content.ReadAsStringAsync().Result).Object;
            target = resultlist3.Where(m => m.CustomerID == target.CustomerID).FirstOrDefault();
            Assert.IsNull(target);

            //停用


        }
    }
}
