using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tools.Tests
{
    [TestClass]
    public class StringCleaner
    {
        [TestMethod]
        public void Clean_EmptyString_ReturnsEmptyString()
        {
            // Act
            var text = " De ne me Met ni dir .  ";
            var expectedResult = "DenemeMetnidir.";

            // Arrange
            var happened = StringHelper.Clean(text);
            Assert.AreEqual(expectedResult, happened);
        }

    }
}
