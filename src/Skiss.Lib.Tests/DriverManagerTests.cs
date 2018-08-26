namespace Skiss.Tests
{
    using System;
    using FluentAssertions;
    using NUnit.Framework;
    using Skiss.Driver.UIAutomation;
    using Skiss.Lib;

    public class DriverManagerTests
    {
        [Test]
        public void CurrentGetter_GivenDriverNotSet_ThrowsException()
        {
            DriverManager.Current = null;
            Action gettingTheUnsetDriver = () => { var d = DriverManager.Current; };
            gettingTheUnsetDriver.Should().ThrowExactly<NoDriverException>();
        }

        [Test]
        public void CurrentGetter_GivenDriverSet_DoesNotThrowException()
        {
            var driver = new UIAutomationDriver();
            DriverManager.Current = driver;
            DriverManager.Current.Should().BeSameAs(driver);
        }
    }
}
