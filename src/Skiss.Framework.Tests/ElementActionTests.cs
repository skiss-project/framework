// Skiss - A .NET framework for simple, kind of interactive, system specs
// Copyright (C) 2018  Simon Wendel
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

namespace Skiss.Framework.Tests
{
    using System;
    using AutoFixture;
    using FluentAssertions;
    using NUnit.Framework;

    public class ElementActionTests
    {
        private Capability capability;
        private object element;
        private ElementActionForTest sut;

        [SetUp]
        public void Setup()
        {
            var fixture = new Fixture();

            capability = fixture.Create<Capability>();
            element = fixture.Create<object>();

            sut = new ElementActionForTest();
        }

        [Test]
        public void EnsureCapability_GivenIdentifierDoesNotMatchCapability_ThrowsException()
        {
            sut.HasCapabilityReturn = (false, element);

            Action ensuring = () => sut.EnsureCapability(capability);

            var exception = ensuring
                .Should().ThrowExactly<MissingCapabilityException>()
                .And;

            exception.Capability.Should().Be(capability);
            exception.Element.Should().BeSameAs(element);
        }

        [Test]
        public void EnsureCapability_GivenIdentifierMatchesCapability_DoesNotThrowException()
        {
            sut.HasCapabilityReturn = (true, element);
            Action ensuring = () => sut.EnsureCapability(capability);
            ensuring.Should().NotThrow();
        }

        private class ElementActionForTest : ElementAction<CommonTestElement>
        {
            public (bool, object) HasCapabilityReturn { get; set; }

            public new void EnsureCapability(Capability capability)
                => base.EnsureCapability(capability);

            protected override (bool, object) HasCapability(Capability capability)
                => HasCapabilityReturn;
        }
    }
}
