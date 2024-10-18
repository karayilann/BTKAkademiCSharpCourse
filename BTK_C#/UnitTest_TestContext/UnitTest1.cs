using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest_TestContext
{
    [TestClass]
    public class UnitTest1
    {
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void StartTests()
        {
            TestContext.WriteLine("Bilgi keyine ait veri : " + TestContext.Properties["Info"]);
        }

        [TestMethod]
        public void TestMethod1()
        {
            TestContext.WriteLine("TestMethod1");
            TestContext.WriteLine("Testin Adı : {0} ", TestContext.TestName);
            TestContext.WriteLine("Testin Durumu : {0} ",TestContext.CurrentTestOutcome);
            TestContext.WriteLine("Testin Sınıfı : {0} ",TestContext.FullyQualifiedTestClassName);
            TestContext.Properties["Info"] = "This is a trial code";
        }

        [TestCleanup]
        public void LogTestProgress()
        {
            TestContext.WriteLine("Cleanup Test Durumu : " + TestContext.CurrentTestOutcome );
            TestContext.WriteLine("Bilgi keyine ait veri : " + TestContext.Properties["Info"]);

        }

    }
}
