using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TCSOFT.DMS.Common.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private class TestDTO
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public bool Sex { get; set; }
            public Guid ID { get; set; }
        }
        [TestMethod]
        public void TestMethod1()
        {
            var testdto = new TestDTO();
            testdto.Name = "测试姓名";
            testdto.Age = 25;
            testdto.Sex = true;
            testdto.ID = Guid.Parse("A4F3F091-541C-470F-BBF9-222684B2719F");
            var Transformstr=TransformHelper.ConvertDTOTOBase64JsonString(testdto);

            var TransformedDTO = TransformHelper.ConvertBase64JsonStringToDTO<TestDTO>(Transformstr);
            Assert.AreEqual(testdto.Name, TransformedDTO.Name);
            Assert.AreEqual(testdto.Age, TransformedDTO.Age);
            Assert.AreEqual(testdto.Sex, TransformedDTO.Sex);
            Assert.AreEqual(testdto.ID, TransformedDTO.ID);
        }
    }
}
