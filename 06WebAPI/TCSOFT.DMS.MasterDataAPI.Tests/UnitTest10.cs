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
using TCSOFT.DMS.MasterData.DTO.Payment;

namespace TCSOFT.DMS.MasterDataAPI.Tests
{
    [TestClass]
    public class UnitTest10
    {
        PaymentController testcontroller = new PaymentController();
        [TestMethod]
        public void TestMethod1()
        {
            //付款条款
            //新增
            PaymentSearchDTO searchdto = new PaymentSearchDTO();
            var searchdtostr = TransformHelper.ConvertDTOTOBase64JsonString(searchdto);
            testcontroller.GetPaymentList(searchdtostr);
            PaymentOperateDTO adddto = new PaymentOperateDTO();
            adddto.PayName = "单元测试付款条款名称";
            var addresult = JsonConvert.DeserializeObject<ResultDTO<object>>(testcontroller.AddPayment(adddto).Content.ReadAsStringAsync().Result);
            var resultlist1 = JsonConvert.DeserializeObject<List<PaymentResultDTO>>(testcontroller.GetPaymentList(searchdtostr).Content.ReadAsStringAsync().Result);
            var target = resultlist1.Where(m => m.PayName == "单元测试付款条款名称").FirstOrDefault();
            Assert.IsNotNull(target);

            //修改
            adddto.PayID = target.PayID;
            adddto.PayName = "修改单元测试付款条款名称";
            adddto.UpType = 1;
            var updateresult = JsonConvert.DeserializeObject<ResultDTO<object>>(testcontroller.UpdatePayment(adddto).Content.ReadAsStringAsync().Result);
            var resultlist2 = JsonConvert.DeserializeObject<List<PaymentResultDTO>>(testcontroller.GetPaymentList(searchdtostr).Content.ReadAsStringAsync().Result);
            target = resultlist2.Where(m => m.PayName == "修改单元测试付款条款名称").FirstOrDefault();
            Assert.IsNotNull(target);

            //删除
            PaymentSearchDTO deletedto = new PaymentSearchDTO();
            deletedto.PayID = target.PayID;
            var deletedtostr = TransformHelper.ConvertDTOTOBase64JsonString(deletedto);
            var deleteresult = JsonConvert.DeserializeObject<ResultDTO<object>>(testcontroller.DeletePayment(deletedtostr).Content.ReadAsStringAsync().Result);
            var resultlist3 = JsonConvert.DeserializeObject<List<PaymentResultDTO>>(testcontroller.GetPaymentList(searchdtostr).Content.ReadAsStringAsync().Result);
            target = resultlist3.Where(m => m.PayID == target.PayID).FirstOrDefault();
            Assert.IsNull(target);
        }
    }
}
