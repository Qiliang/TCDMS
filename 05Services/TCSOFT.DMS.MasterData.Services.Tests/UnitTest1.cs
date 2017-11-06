using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TCSOFT.DMS.MasterData.DTO.RateDTO;
using System.Linq;
using TCSOFT.DMS.MasterData.DTO.AccountDate;
using TCSOFT.DMS.MasterData.DTO.Transport;
using TCSOFT.DMS.MasterData.DTO.Payment;
namespace TCSOFT.DMS.MasterData.Services.Tests
{
    [TestClass]
    public class UnitTest1
    {
        BaseInfoServices testservice = new BaseInfoServices();
        [TestMethod]
        public void TestMethod1()
        {
            #region 汇率
            //新增
            testservice.GetRateList();
            RateOperateDTO addRatedto = new RateOperateDTO();
            addRatedto.CreateTime = DateTime.Now;
            addRatedto.CreateUser = "测试人员001";
            addRatedto.Currency = "TestCurrencyTest";
            addRatedto.AprilRate = (decimal)6.12;
            addRatedto.AugustRate = (decimal)6.2;
            addRatedto.DecRate = (decimal)7.12;
            addRatedto.FebRate = (decimal)12.9001;
            addRatedto.JulyRate = (decimal)23.908;
            addRatedto.JuneRate = (decimal)12.9;
            addRatedto.MarchRate = (decimal)8.23;
            addRatedto.MayRate = (decimal)12;
            addRatedto.MonthRate = (decimal)7.098;
            addRatedto.NovRate = (decimal)10.98;
            addRatedto.OctRate = (decimal)7.90;
            addRatedto.RateBudget = (decimal)14;
            addRatedto.SepRate = (decimal)13.1;
            addRatedto.RateCode = "testratecode";
            addRatedto.RateYear = 2017;
            var addrateresult = testservice.AddRate(addRatedto);
            Assert.AreEqual(addrateresult, true);
            var ratelist = testservice.GetRateList();
            var ra = ratelist.Where(m => m.Currency == "TestCurrencyTest").FirstOrDefault();
            Assert.IsNotNull(ra);
            Assert.AreEqual(ra.RateCode, "testratecode");

            //修改
            addRatedto.RateID = ra.RateID;
            addRatedto.Currency = "TestCurrency";
            addRatedto.AprilRate = (decimal)6.12;
            addRatedto.AugustRate = (decimal)6.2;
            addRatedto.DecRate = (decimal)7.12;
            addRatedto.FebRate = (decimal)12.9001;
            addRatedto.JulyRate = (decimal)23.908;
            addRatedto.JuneRate = (decimal)12.9;
            addRatedto.MarchRate = (decimal)8.23;
            addRatedto.MayRate = (decimal)12;
            addRatedto.MonthRate = (decimal)7.098;
            addRatedto.NovRate = (decimal)10.98;
            addRatedto.OctRate = (decimal)7.90;
            addRatedto.RateBudget = (decimal)14;
            addRatedto.SepRate = (decimal)13.1;
            addRatedto.RateCode = "testratecodetest111";
            addRatedto.RateYear = 2017;

            var updaterateresult = testservice.UpdateRate(addRatedto);
            var ratelist2 = testservice.GetRateList();
            var ra2 = ratelist2.Where(m => m.RateID == ra.RateID).FirstOrDefault();
            Assert.AreEqual(ra2.Currency, "TestCurrency");

            //删除
            RateSearchDTO ratedeletedto = new RateSearchDTO();
            ratedeletedto.RateID = ra.RateID;
            testservice.DeleteRate(ratedeletedto);
            var ratelist3 = testservice.GetRateList();
            var ra3 = ratelist3.Where(m => m.RateID == ra.RateID).FirstOrDefault();
            Assert.IsNull(ra3);
            #endregion
        }
        [TestMethod]
        public void TestMethod2()
        {
            #region 关账日
            //新增
            testservice.GetAccountDateList();
            AccountDateOperateDTO adddto = new AccountDateOperateDTO();
            adddto.AccountDateBelongModel = "基础数据";
            adddto.AccountDateName = "单元测试关账日名称";
            var addresult = testservice.AddAccountDate(adddto);

            var resultlist1 = testservice.GetAccountDateList();
            var target = resultlist1.Where(m => m.AccountDateName == "单元测试关账日名称").FirstOrDefault();
            Assert.IsNotNull(target);

            //修改
            adddto.AccountDateID = target.AccountDateID;
            adddto.AccountDateName = "修改单元测试关账日名称";
            var updateresult = testservice.UpdateAccountDate(adddto);
            var resultlist2 = testservice.GetAccountDateList();
            target = resultlist2.Where(m => m.AccountDateName == "修改单元测试关账日名称").FirstOrDefault();
            Assert.IsNotNull(target);

            //删除
            AccountDateSearchDTO deletedto = new AccountDateSearchDTO();
            deletedto.AccountDateID = target.AccountDateID;
            var deleteresult = testservice.DeleteAccountDate(deletedto);
            var resultlist3 = testservice.GetAccountDateList();
            target = resultlist3.Where(m => m.AccountDateID == target.AccountDateID).FirstOrDefault();
            Assert.IsNull(target);
            #endregion
        }
        
        [TestMethod]
        public void TestMethod3()
        {
            #region 付款条款
            //新增
            PaymentSearchDTO searchdto = new PaymentSearchDTO();
            testservice.GetPaymentList(searchdto);
            PaymentOperateDTO adddto = new PaymentOperateDTO();
            adddto.PayName = "单元测试付款条款名称";
            var addresult = testservice.AddPayment(adddto);

            var resultlist1 = testservice.GetPaymentList(searchdto); ;
            var target = resultlist1.Where(m => m.PayName == "单元测试付款条款名称").FirstOrDefault();
            Assert.IsNotNull(target);

            //修改
            adddto.PayID = target.PayID;
            adddto.PayName = "修改单元测试付款条款名称";
            adddto.UpType = 1;
            var updateresult = testservice.UpdatePayment(adddto);
            var resultlist2 = testservice.GetPaymentList(searchdto);
            target = resultlist2.Where(m => m.PayName == "修改单元测试付款条款名称").FirstOrDefault();
            Assert.IsNotNull(target);

            //删除
            PaymentSearchDTO deletedto = new PaymentSearchDTO();
            deletedto.PayID = target.PayID;
            var deleteresult = testservice.DeletePayment(deletedto);
            var resultlist3 = testservice.GetPaymentList(searchdto);
            target = resultlist3.Where(m => m.PayID == target.PayID).FirstOrDefault();
            Assert.IsNull(target);
            #endregion
        }
    }
}
