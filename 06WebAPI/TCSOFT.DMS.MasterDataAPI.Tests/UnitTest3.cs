using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TCSOFT.DMS.MasterDataAPI.Controllers;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Collections.Generic;
using TCSOFT.DMS.MasterData.DTO.Distributor.DistributorType;
using Newtonsoft.Json;
using System.Linq;
using TCSOFT.DMS.MasterData.DTO.Common;

namespace TCSOFT.DMS.MasterDataAPI.Tests
{
    [TestClass]
    public class UnitTest3
    {
        DistributorTypeController DistributorTypeController = new DistributorTypeController();
        [TestMethod]
        public void TestMethod1()
        {
            //查询
            DistributorTypeSearchDTO dto = new DistributorTypeSearchDTO();
            string dtostr = Common.TransformHelper.ConvertDTOTOBase64JsonString(dto);
            var pp = DistributorTypeController.GetDepartmentList(dtostr);

            //新增
            DistributorTypeOperateDTO dto1 = new DistributorTypeOperateDTO();
            dto1.DistributorTypeName = "测试类别Test";
            dto1.CreateUser = "我";
            dto1.CreateTime = DateTime.Now;
            var pp1 = DistributorTypeController.AddDistributorType(dto1);
            string strResult1 = pp1.Content.ReadAsStringAsync().Result;
            ResultDTO<object> bl = JsonConvert.DeserializeObject<ResultDTO<object>>(strResult1);
            Assert.IsTrue(bl.SubmitResult);

            //查询
            DistributorTypeSearchDTO dto2 = new DistributorTypeSearchDTO();
            string dto2str = Common.TransformHelper.ConvertDTOTOBase64JsonString(dto2);
            var pp2 = DistributorTypeController.GetDepartmentList(dto2str);
            string strResult2 = pp2.Content.ReadAsStringAsync().Result;
            List<DistributorTypeResultDTO> list1 = JsonConvert.DeserializeObject<List<DistributorTypeResultDTO>>(strResult2);

            //修改
            DistributorTypeOperateDTO dto3 = new DistributorTypeOperateDTO();
            dto3.DistributorTypeID = list1.Where(p => p.DistributorTypeName == "测试类别Test").Select(s => s.DistributorTypeID).FirstOrDefault();
            dto3.DistributorTypeName = "修改测试类别Test";
            dto3.ModifyUser = "你";
            dto3.ModifyTime = DateTime.Now;
            var pp3 = DistributorTypeController.UpdateDistributorType(dto3);
            string strResult3 = pp3.Content.ReadAsStringAsync().Result;
            ResultDTO<object> bl1 = JsonConvert.DeserializeObject<ResultDTO<object>>(strResult3);
            Assert.IsTrue(bl1.SubmitResult);

            //删除
            DistributorTypeOperateDTO dto4 = new DistributorTypeOperateDTO();
            dto4.DistributorTypeID = list1.Where(p => p.DistributorTypeName == "测试类别Test").Select(s => s.DistributorTypeID).FirstOrDefault();
            string dto4str = Common.TransformHelper.ConvertDTOTOBase64JsonString(dto4);
            var pp4 = DistributorTypeController.DeleteDistributorType(dto4str);
            string strResult4 = pp4.Content.ReadAsStringAsync().Result;
            ResultDTO<object> bl2 = JsonConvert.DeserializeObject<ResultDTO<object>>(strResult4);
            Assert.IsTrue(bl2.SubmitResult);
        }
    }
}
