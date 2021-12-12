using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestProjectXtramile.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProjectXtramile.Extensions.Tests
{
    [TestClass()]
    public class ConvetDegreeTests
    {

        [TestMethod()]
        public void ToCelciusTest()
        {
            Assert.AreEqual(-273, ConvertDegrees.ToCelcius(0));
        }

        [TestMethod()]
        public void TofahrenheitTest()
        {
            Assert.AreEqual(-459.4, ConvertDegrees.Tofahrenheit(-273));
        }
    }
}