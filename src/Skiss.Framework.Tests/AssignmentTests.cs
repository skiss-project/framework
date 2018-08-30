namespace Skiss.Framework.Tests
{
    using AutoFixture;
    using FluentAssertions;
    using Moq;
    using NUnit.Framework;
    using Skiss.Framework;

    public class AssignmentTests
    {
        [Test]
        public void Start_GivenDriverSet_LaunchesUsingDriver()
        {
            var fixture = new Fixture();
            var task = fixture.Create<string>();
            var expected = new CommonTestElement();

            var driver = new Mock<IDriver>();
            driver.Setup(d => d.Start<CommonTestElement>(task)).Returns(expected);

            DriverManager.Current = driver.Object;

            var element = Assignment<CommonTestElement>.Start(task);

            element.Should().BeSameAs(expected);
            driver.VerifyAll();
        }
    }
}
