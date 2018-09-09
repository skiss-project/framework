// Copyright (c) Simon Wendel. All rights reserved.

namespace Skiss.Framework.Tests
{
    using System;
    using FluentAssertions;
    using NUnit.Framework;
    using Skiss.Framework;

    public class VerificationExtensionsTests
    {
        [Test]
        public void Now_GivenNullAction_ThrowsException()
        {
            Action now = () => VerificationExtensions.Now(new object(), null);

            now
                .Should().ThrowExactly<ArgumentNullException>()
                .Which.ParamName.Should().Be("action");
        }

        [Test]
        public void Now_GivenNullSelf_ShouldCallActionOnNull()
        {
            var parameter = new object();

            void action(object inparameter)
                => parameter = inparameter;

            VerificationExtensions.Now((object)null, action);

            parameter.Should().BeNull();
        }

        [Test]
        public void Now_GivenAction_CallsActionOnSelf()
        {
            object self = new object();
            object element = null;

            void action(object el) 
                => element = el;

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
