﻿namespace Skiss.Framework.Tests
{
    using FluentAssertions;
    using NUnit.Framework;
    using Skiss.Framework;

    public class MissingCapabilityExceptionTests
    {
        [Test]
        public void Constructor_GivenCapabilityAndElement_InitializesProperties()
        {
            var expectedCapability = Capability.Closable;
            var expectedElement = new object();

            var sut = new MissingCapabilityException(expectedCapability, expectedElement);

            sut.Capability.Should().Be(expectedCapability);
            sut.Element.Should().BeSameAs(expectedElement);
        }
    }
}