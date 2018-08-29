namespace Skiss.Framework.Tests
{
    using FluentAssertions;
    using NUnit.Framework;
    using Skiss.Framework;

    public class VerificationExtensionsTests
    {
        [Test]
        public void Now_GivenAction_CallsActionOnSelf()
        {
            object self = new object();
            object element = null;
            void action(object el) => element = el;

            VerificationExtensions.Now(self, action);

            element.Should().BeSameAs(self);
        }

        [Test]
        public void Now_GivenAction_ReturnsSelf()
        {
            object self = new object();
            void action(object el)
            {
            }

            VerificationExtensions.Now(self, action).Should().BeSameAs(self);
        }
    }
}
