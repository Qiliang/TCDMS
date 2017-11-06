using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TCSOFT.DMS.MasterDataAPI.Controllers;
using TCSOFT.DMS.MasterData.DTO.AccountDate;
using Newtonsoft.Json;
using TCSOFT.DMS.MasterData.DTO.Common;
using System.Collections.Generic;
using TCSOFT.DMS.Common;
using TCSOFT.DMS.MasterData.DTO.Message;

namespace TCSOFT.DMS.MasterDataAPI.Tests
{
    [TestClass]
    public class UnitTest12
    {
        MessageStatController testcontroller = new MessageStatController();
        [TestMethod]
        public void TestMethod1()
        {
            //短信统计
            //新增
            MessageSearchDTO searchdto = new MessageSearchDTO();
            searchdto.page = 1;
            searchdto.rows = 1;
            var searchdtostr = TransformHelper.ConvertDTOTOBase64JsonString(searchdto);
            testcontroller.GetMessageStatList(searchdtostr);
            List<MessageOperateDTO> dtolist = new List<MessageOperateDTO>();
            dtolist.Add(new MessageOperateDTO
            {
                MessageType = -1,
                SendTime = DateTime.Now,
                UserID = 1
            });
            var addresult = testcontroller.AddMessageStat(dtolist);
            searchdto.rows = 20;
            var resultlist1 = JsonConvert.DeserializeObject<ResultDTO<List<MessageResultDTO>>>(testcontroller.GetMessageStatList(searchdtostr).Content.ReadAsStringAsync().Result).Object;
            var target = resultlist1.Where(m => m.MessageType == -1).FirstOrDefault();
            Assert.IsNotNull(target);
          
            //删除
            MessageResultDTO deletedto = new MessageResultDTO();
            deletedto.MessageStatID = target.MessageStatID;
            var deletedtostr = TransformHelper.ConvertDTOTOBase64JsonString(deletedto);
            var deleteresult= testcontroller.DeleteMessageStat(deletedtostr);
            var resultlist3 = JsonConvert.DeserializeObject<ResultDTO<List<MessageResultDTO>>>(testcontroller.GetMessageStatList(searchdtostr).Content.ReadAsStringAsync().Result).Object;
            target = resultlist3.Where(m => m.MessageStatID == target.MessageStatID).FirstOrDefault();
            Assert.IsNull(target);
        }
    }
}
