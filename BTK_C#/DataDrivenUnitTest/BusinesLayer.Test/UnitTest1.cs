using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BusinessLayer;

namespace BusinesLayer.Test
{
    [TestClass]
    public class UnitTest1
    {
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
            @"D:\\yazilimdosyalari\\yazilimdosyalari\\BTKAkademiCSharpCourse\\BTK_C#\\DataDrivenUnitTest\\BusinesLayer.Test\\UserData.xml",
            "Kulllanici",DataAccessMethod.Sequential)]
        [TestMethod]
        public void DataTest()
        {
            var manager = new UserManager();

            var result = manager.AddUser("", "", "");

            Assert.IsTrue(result);

        }
    }
}
