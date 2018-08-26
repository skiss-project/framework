namespace Skiss.Lib.Tests
{
    using FluentAssertions;
    using NUnit.Framework;
    using Skiss.Lib;

    public class ReadActionTests
    {
        [Test]
        public void TextGetter_WhenCalled_CallsGetTextOnSubClass()
        {
            var sut = new ReadActionForTest();
            sut.Text.Should().Be("Great success!");
        }

        private class ReadActionForTest : ReadAction<CommonTestElement>
        {
            protected override string GetText()
            {
                return "Great success!";
            }
        }
    }
}
