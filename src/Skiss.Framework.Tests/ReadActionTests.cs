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
    using FluentAssertions;
    using NUnit.Framework;
    using Skiss.Framework;

    public class ReadActionTests
    {
        private ReadActionForTest sut;

        [SetUp]
        public void Setup()
        {
            sut = new ReadActionForTest();
        }

        [Test]
        public void TextGetter_GivenCapabilityNotProvided_ThrowsException()
        {
            var element = new object();
            sut.HasCapabilityReturn = (false, element);

            Action getting = () => { var t = sut.Text; };

            var exception = getting.Should().ThrowExactly<MissingCapabilityException>().And;
            exception.Capability.Should().Be(Capability.Readable);
            exception.Element.Should().Be(element);
        }

        [Test]
        public void TextGetter_GivenCapabilityProvided_CallsGetTextOnSubClass()
        {
            sut.HasCapabilityReturn = (true, new object());
            sut.Text.Should().Be("Great success!");
        }

        private class ReadActionForTest : ReadAction<CommonTestElement>
        {
            public (bool, object) HasCapabilityReturn { get; set; }

            protected override (bool, object) HasCapability(Capability capability)
                => HasCapabilityReturn;

            protected override string GetText()
            {
                return "Great success!";
            }
        }
    }
}
