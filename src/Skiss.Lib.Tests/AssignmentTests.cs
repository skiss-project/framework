namespace Skiss.Tests
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
            var expected = new TestElement();

            var driver = new Mock<IDriver>();
            driver.Setup(d => d.Launch<TestElement>(task)).Returns(expected);

            DriverManager.Current = driver.Object;

            var element = Assignment<TestElement>.Launch(task);

            element.Should().BeSameAs(expected);
            driver.VerifyAll();
        }

        private class TestElement : Element<TestElement>
        {
        }
    }
}
