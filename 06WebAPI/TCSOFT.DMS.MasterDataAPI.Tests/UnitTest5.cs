using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using TCSOFT.DMS.MasterData.DTO.Common;
using TCSOFT.DMS.MasterDataAPI.Controllers;
using TCSOFT.DMS.MasterData.DTO.Distributor.DistributorServiceType;

namespace TCSOFT.DMS.MasterDataAPI.Tests
{
    [TestClass]
    public class UnitTest5
    {
        DistributorServiceTypeController DistributorServiceTypeController = new DistributorServiceTypeController();
        [TestMethod]
        public void TestMethod1()
        {
            //查询
            DistributorServiceTypeSearchDTO dto = new DistributorServiceTypeSearchDTO();
            string dtostr = Common.TransformHelper.ConvertDTOTOBase64JsonString(dto);
            var pp = DistributorServiceTypeController.GetDistributorServiceType(dtostr);

            //新增
            DistributorServiceTypeOperateDTO dto1 = new DistributorServiceTypeOperateDTO();
            dto1.DistributorServiceTypeName = "测试服务类型Test";
            dto1.CreateUser = "我";
            dto1.CreateTime = DateTime.Now;
            var pp1 = DistributorServiceTypeController.AddDistributorServiceType(dto1);
            string strResult1 = pp1.Content.ReadAsStringAsync().Result;
            ResultDTO<object> bl = JsonConvert.DeserializeObject<ResultDTO<object>>(strResult1);
            Assert.IsTrue(bl.SubmitResult);

            //查询
            DistributorServiceTypeSearchDTO dto2 = new DistributorServiceTypeSearchDTO();
            string dto2str = Common.TransformHelper.ConvertDTOTOBase64JsonString(dto2);
            var pp2 = DistributorServiceTypeController.GetDistributorServiceType(dto2str);
            string strResult2 = pp2.Content.ReadAsStringAsync().Result;
            List<DistributorServiceTypeResultDTO> list1 = JsonConvert.DeserializeObject<List<DistributorServiceTypeResultDTO>>(strResult2);

            //修改
            DistributorServiceTypeOperateDTO dto3 = new DistributorServiceTypeOperateDTO();
            dto3.DistributorServiceTypeID = list1.Where(p => p.DistributorServiceTypeName == "测试服务类型Test").Select(s => s.DistributorServiceTypeID).FirstOrDefault();
            dto3.DistributorServiceTypeName = "修改测试服务类型Test";
            dto3.ModifyUser = "你";
            dto3.ModifyTime = DateTime.Now;
            var pp3 = DistributorServiceTypeController.UpdateDistributorServiceType(dto3);
            string strResult3 = pp3.Content.ReadAsStringAsync().Result;
            ResultDTO<object> bl1 = JsonConvert.DeserializeObject<ResultDTO<object>>(strResult3);
            Assert.IsTrue(bl1.SubmitResult);

            //删除
            DistributorServiceTypeOperateDTO dto4 = new DistributorServiceTypeOperateDTO();
            dto4.DistributorServiceTypeID = list1.Where(p => p.DistributorServiceTypeName == "测试服务类型Test").Select(s => s.DistributorServiceTypeID).FirstOrDefault();
            string dto4str = Common.TransformHelper.ConvertDTOTOBase64JsonString(dto4);
            var pp4 = DistributorServiceTypeController.DeleteDistributorServiceType(dto4str);
            string strResult4 = pp4.Content.ReadAsStringAsync().Result;
            ResultDTO<object> bl2 = JsonConvert.DeserializeObject<ResultDTO<object>>(strResult4);
            Assert.IsTrue(bl2.SubmitResult);
        }
    }
}
