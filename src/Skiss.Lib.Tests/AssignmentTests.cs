namespace Skiss.Lib.Tests
{
    using AutoFixture;
    using FluentAssertions;
    using Moq;
    using NUnit.Framework;
    using Skiss.Lib;

    public class AssignmentTests
    {
        [Test]
        public void Launch_GivenDriverSet_LaunchesUsingDriver()
        {
            var fixture = new Fixture();
            var task = fixture.Create<string>();
            var expected = new CommonTestElement();

            var driver = new Mock<IDriver>();
            driver.Setup(d => d.Launch<CommonTestElement>(task)).Returns(expected);

            DriverManager.Current = driver.Object;

            var element = Assignment<CommonTestElement>.Launch(task);

            element.Should().BeSameAs(expected);
            driver.VerifyAll();
        }
    }
}
