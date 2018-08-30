namespace Skiss.Framework.Tests
{
    using System;
    using FluentAssertions;
    using NUnit.Framework;

    public class ElementActionTests
    {
        [Test]
        public void MissingCapability_GivenCapabilityAndElement_ThrowsException()
        {
            var element = new object();
            var capability = Capability.Clickable;
            var sut = new ElementActionForTest();

            Action missingCapabilityCall = () => sut.MissingCapability(capability, element);

            var exception = missingCapabilityCall
                .Should().ThrowExactly<MissingCapabilityException>()
                .And;

            exception.Capability.Should().Be(capability);
            exception.Element.Should().BeSameAs(element);
        }
    
        private class ElementActionForTest : ElementAction<CommonTestElement>
        {
            public new void MissingCapability(Capability capability, object element) 
                => base.MissingCapability(capability, element);
        }
    }
}
