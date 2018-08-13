using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skiss.Driver.UIAutomation;
using Skiss.Lib;

namespace Skiss.Tests
{
    [TestClass]
    public class DriverManagerTests
    {
        [TestMethod]
        public void get_Current_GivenDriverNotSet_ThrowsException()
        {
            Action gettingTheUnsetDriver = () => { var d = DriverManager.Current; };
            Assert.ThrowsException<NoDriverException>(gettingTheUnsetDriver);
        }

        [TestMethod]
        public void get_Current_GivenDriverSet_DoesNotThrowException()
        {
            var driver = new UIAutomationDriver();
            DriverManager.Current = driver;
            Assert.AreSame(DriverManager.Current, driver);
        }
    }
}
