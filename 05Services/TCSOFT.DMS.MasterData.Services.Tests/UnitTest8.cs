using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TCSOFT.DMS.MasterData.DTO.Message;
using System.Collections.Generic;
using TCSOFT.DMS.MasterData.DTO.UsersStat;

namespace TCSOFT.DMS.MasterData.Services.Tests
{
    [TestClass]
    public class UnitTest8
    {
        SystemServices testservice = new SystemServices();
        [TestMethod]
        public void TestMethod1()
        {
            #region 短信统计
            //新增
            MessageSearchDTO searchdto = new MessageSearchDTO();
            searchdto.page = 1;
            searchdto.rows = 1;
            testservice.GetMessageStatList(searchdto);

            List<MessageOperateDTO> dtolist = new List<MessageOperateDTO>();
            dtolist.Add(new MessageOperateDTO
            {
                MessageType = -1,
                SendTime = DateTime.Now,
                UserID = 1
            });
            var addresult = testservice.AddMessageStat(dtolist);

            searchdto.rows = 20;
            var resultlist1 = testservice.GetMessageStatList(searchdto);
            var target = resultlist1.Where(m => m.MessageType == -1).FirstOrDefault();
            Assert.IsNotNull(target);
            //删除
            MessageResultDTO deletedto = new MessageResultDTO();
            deletedto.MessageStatID = target.MessageStatID;
            var deleteresult = testservice.DeleteMessageStat(deletedto);
            var resultlist3 = testservice.GetMessageStatList(searchdto);
            target = resultlist3.Where(m => m.MessageStatID == target.MessageStatID).FirstOrDefault();
            Assert.IsNull(target);
            #endregion
        }
        [TestMethod]
        public void TestMethod2()
        {
            #region 用户统计
            //新增
            UsersStatSearchDTO searchdto = new UsersStatSearchDTO();
            searchdto.page = 1;
            searchdto.rows = 1;
            testservice.GetUsersStatList(searchdto);

            UsersStatOperateDTO adddto = new UsersStatOperateDTO();
            adddto.UserID = 1;
            adddto.UseModel = "单元测试模块";
            adddto.UseModelTime = DateTime.Now;
            var addresult = testservice.AddUsersStat(adddto);

            searchdto.rows = 20;
            var resultlist1 = testservice.GetUsersStatList(searchdto);
            var target = resultlist1.Where(m => m.UseModel == "单元测试模块").FirstOrDefault();
            Assert.IsNotNull(target);
            //删除
            UsersStatResultDTO deletedto = new UsersStatResultDTO();
            deletedto.UsersStatID = target.UsersStatID;
            var deleteresult = testservice.DeleteUsersStat(deletedto);
            var resultlist3 = testservice.GetUsersStatList(searchdto);
            target = resultlist3.Where(m => m.UsersStatID == target.UsersStatID).FirstOrDefault();
            Assert.IsNull(target);
            #endregion
        }
    }
}
