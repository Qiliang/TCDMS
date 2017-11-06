using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using TCSOFT.DMS.MasterDataAPI.Controllers;
using TCSOFT.DMS.MasterData.DTO.Common;
using TCSOFT.DMS.MasterData.DTO.Distributor.Distributor;

namespace TCSOFT.DMS.MasterDataAPI.Tests
{
    [TestClass]
    public class UnitTest7
    {
        DistributorManagermentController DistributorManagermentController = new DistributorManagermentController();
        [TestMethod]
        public void TestMethod1()
        {
            //查询
            DistributorSearchDTO dto = new DistributorSearchDTO();
            dto.page = 1;
            dto.rows = 1;
            string dtostr = Common.TransformHelper.ConvertDTOTOBase64JsonString(dto);
            var pp = DistributorManagermentController.GetDistributorList(dtostr);

            //新增
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
            var pp1 = DistributorManagermentController.AddDistributor(dto1);
            string strResult1 = pp1.Content.ReadAsStringAsync().Result;
            ResultDTO<object> bl = JsonConvert.DeserializeObject<ResultDTO<object>>(strResult1);
            Assert.IsTrue(bl.SubmitResult);

            //查询
            DistributorSearchDTO dto2 = new DistributorSearchDTO();
            dto2.SearchText = "测试经销商Test";
            dto2.page = 1;
            dto2.rows = 1;
            string dto2str = Common.TransformHelper.ConvertDTOTOBase64JsonString(dto2);
            var pp2 = DistributorManagermentController.GetDistributorList(dto2str);
            string strResult2 = pp2.Content.ReadAsStringAsync().Result;
            ResultDTO<List<DistributorResultDTO>> result=JsonConvert.DeserializeObject<ResultDTO<List<DistributorResultDTO>>>(strResult2);
            List<DistributorResultDTO> list1 = result.Object;

            //修改
            DistributorOperateDTO dto3 = new DistributorOperateDTO();
            dto3.UpType = 1;
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
            var pp3 = DistributorManagermentController.UpdateDistributor(dto3);
            string strResult3 = pp3.Content.ReadAsStringAsync().Result;
            ResultDTO<object> bl1 = JsonConvert.DeserializeObject<ResultDTO<object>>(strResult3);
            Assert.IsTrue(bl1.SubmitResult);

            //停启用经销商
            DistributorOperateDTO dto4 = new DistributorOperateDTO();
            dto4.UpType = 2;
            dto4.DistributorID = list1.Select(s => s.DistributorID).FirstOrDefault();
            dto4.IsActive = true;
            dto4.ModifyUser = "你";
            dto4.ModifyTime = DateTime.Now;
            var pp4 = DistributorManagermentController.UpdateDistributor(dto4);
            string strResult4 = pp4.Content.ReadAsStringAsync().Result;
            ResultDTO<object> bl2 = JsonConvert.DeserializeObject<ResultDTO<object>>(strResult4);
            Assert.IsTrue(bl2.SubmitResult);

            //删除
            DistributorOperateDTO dto5 = new DistributorOperateDTO();
            dto5.DistributorID = list1.Select(s => s.DistributorID).FirstOrDefault();
            string dto4str = Common.TransformHelper.ConvertDTOTOBase64JsonString(dto5);
            var pp5 = DistributorManagermentController.DeleteDistributor(dto4str);
            string strResult5 = pp5.Content.ReadAsStringAsync().Result;
            ResultDTO<object> bl3 = JsonConvert.DeserializeObject<ResultDTO<object>>(strResult5);
            Assert.IsTrue(bl3.SubmitResult);
        }
    }
}
