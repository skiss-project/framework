namespace Skiss.Tests
{
    using FluentAssertions;
    using NUnit.Framework;
    using Skiss.Lib;

    public class TypeActionTests
    {
        private TestElement continuation;

        private string text;

        private TypeActionForTest sut;

        [SetUp]
        public void Setup()
        {
            continuation = new TestElement();
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

        private class TypeActionForTest : TypeAction<TestElement>
        {
            public TypeActionForTest(TestElement continuation)
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
