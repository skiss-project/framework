namespace Skiss.Lib.Tests
{
    using FluentAssertions;
    using NUnit.Framework;
    using Skiss.Lib;

    public class ClickActionTests
    {
        private CommonTestElement continuation;

        private ClickActionForTest sut;

        [SetUp]
        public void Setup()
        {
            continuation = new CommonTestElement();
            sut = new ClickActionForTest(continuation);
        }

        [Test]
        public void Click_GivenContinuationProvided_ReturnsContinuation()
        {
            sut.Click().Should().BeSameAs(continuation);
        }

        [Test]
        public void Click_GivenPerformClickImplemented_CallsPerformClickOnSubClass()
        {
            sut.Click();
            sut.ClickPerformed.Should().BeTrue();
        }

        private class ClickActionForTest : ClickAction<CommonTestElement>
        {
            public ClickActionForTest(CommonTestElement continuation)
                : base(continuation)
            {
            }

            public bool ClickPerformed { get; private set; }

            protected override void PerformClick()
            {
                ClickPerformed = true;
            }
        }
    }
}
