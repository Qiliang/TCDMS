using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TCSOFT.DMS.MasterData.IServices;
using TCSOFT.DMS.MasterData.DTO.Common;
using System.Collections.Generic;

namespace TCSOFT.DMS.MasterData.Services.Tests
{
    [TestClass]
    public class UnitTest3
    {
        ICommonServices _ICommonServices = new CommonServices();
        [TestMethod]
        public void TestMethod1()
        {
            //查询反馈
            FeedbackSearchDTO dto = new FeedbackSearchDTO();
            dto.page = 1;
            dto.rows = 1;
            List<FeedbackResultDTO> list = _ICommonServices.GetFeedbackList(dto);
            //新增反馈
            FeedbackOperateDTO dto1 = new FeedbackOperateDTO();
            dto1.UserID = 1;
            dto1.FeedbackSystem = "基础数据";
            dto1.FeedbackModel = "区域管理";
            dto1.FeedbackStaus = 0;
            dto1.FeedbackDate = DateTime.Now;
            dto1.FeedbackContent = "测试";
            int bl = _ICommonServices.AddFeedback(dto1);
            Assert.AreNotEqual(bl, -1);

            //查询反馈
            FeedbackSearchDTO dto2 = new FeedbackSearchDTO();
            dto2.page = 1;
            dto2.rows = 1;
            List<FeedbackResultDTO> list1 = _ICommonServices.GetFeedbackList(dto2);
            //修改状态
            FeedbackOperateDTO dto3 = new FeedbackOperateDTO();
            dto3.FeedbackStatID = (list1[0]).FeedbackStatID;
            dto3.FeedbackStaus = 1;
            dto3.DealUser = "我";
            dto3.DealDatetime = DateTime.Now;
            bool bl1 = _ICommonServices.UpdateFeedback(dto3);
            Assert.IsTrue(bl1);
        }
    }
}
