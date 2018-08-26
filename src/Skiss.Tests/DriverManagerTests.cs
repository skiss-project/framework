using System;
using FluentAssertions;
using NUnit.Framework;
using Skiss.Driver.UIAutomation;
using Skiss.Lib;

namespace Skiss.Tests
{
    public class DriverManagerTests
    {
        [Test]
        public void get_Current_GivenDriverNotSet_ThrowsException()
        {
            Action gettingTheUnsetDriver = () => { var d = DriverManager.Current; };
            gettingTheUnsetDriver.Should().ThrowExactly<NoDriverException>();
        }

        [Test]
        public void get_Current_GivenDriverSet_DoesNotThrowException()
        {
            var driver = new UIAutomationDriver();
            DriverManager.Current = driver;
            DriverManager.Current.Should().BeSameAs(driver);
        }
    }
}
