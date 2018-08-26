namespace Skiss.Tests
{
    using FluentAssertions;
    using NUnit.Framework;
    using Skiss.Lib;

    public class ClickActionTests
    {
        private TestElement continuation;

        private ClickActionForTest sut;

        [SetUp]
        public void Setup()
        {
            continuation = new TestElement();
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

        private class ClickActionForTest : ClickAction<TestElement>
        {
            public ClickActionForTest(TestElement continuation)
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
