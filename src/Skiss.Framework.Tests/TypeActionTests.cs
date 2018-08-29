namespace Skiss.Framework.Tests
{
    using FluentAssertions;
    using NUnit.Framework;
    using Skiss.Framework;

    public class TypeActionTests
    {
        private CommonTestElement continuation;

        private string text;

        private TypeActionForTest sut;

        [SetUp]
        public void Setup()
        {
            continuation = new CommonTestElement();
            text = "Some typed text!";
            sut = new TypeActionForTest(continuation);
        }

        [Test]
        public void Type_GivenContinuationProvided_ReturnsContinuation()
        {
            sut.Type(text).Should().BeSameAs(continuation);
        }

        [Test]
        public void Type_GivenPerformTypeImplemented_CallsPerformTypeOnSubClass()
        {
            sut.Type(text);
            sut.TextTyped.Should().Be("Some typed text!");
        }

        private class TypeActionForTest : TypeAction<CommonTestElement>
        {
            public TypeActionForTest(CommonTestElement continuation)
                : base(continuation)
            {
            }

            public string TextTyped { get; private set; }

            protected override void PerformType(string text)
            {
                TextTyped = text;
            }
        }
    }
}
