namespace Skiss.Tests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using FluentAssertions;
    using NUnit.Framework;
    using Skiss.Driver.UIAutomation;
    using Skiss.Lib;

    [SuppressMessage(
        "StyleCop.CSharp.NamingRules", 
        "SA1300:ElementMustBeginWithUpperCaseLetter", 
        Justification = "Testing a getter here, the actual name is get_Current")]
    public class DriverManagerTests
    {
        [Test]
        public void get_Current_GivenDriverNotSet_ThrowsException()
        {
            DriverManager.Current = null;
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
