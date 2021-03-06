﻿// Skiss - A .NET framework for simple, kind of interactive, system specs
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

    public class TypeActionTests
    {
        private CommonTestElement continuation;
        private string text;
        private object element;
        private TypeActionForTest sut;

        [SetUp]
        public void Setup()
        {
            continuation = new CommonTestElement();
            text = "Some typed text!";
            element = new object();
            sut = new TypeActionForTest(continuation);
        }

        [Test]
        public void Constructor_GivenNullContinuation_ThrowsException()
        {
            Action constructing = () => new TypeActionForTest(null);

            constructing.Should().ThrowExactly<ArgumentNullException>()
                .Which.ParamName.Should().Be("continuation");
        }

        [Test]
        public void Type_GivenNullText_ThrowsException()
        {
            Action typing = () => sut.Type(null);

            typing.Should().ThrowExactly<ArgumentNullException>()
                .Which.ParamName.Should().Be("text");
        }

        [Test]
        public void Type_GivenCapabilityNotProvided_ThrowsException()
        {
            sut.HasCapabilityReturn = (false, element);

            Action typing = () => sut.Type(text);

            var exception = typing.Should().ThrowExactly<MissingCapabilityException>().And;
            exception.Capability.Should().Be(Capability.Typable);
            exception.Element.Should().Be(element);
        }

        [Test]
        public void Type_GivenCapabilityProvided_CallsPerformTypeOnSubClass()
        {
            sut.HasCapabilityReturn = (true, element);
            sut.Type(text);
            sut.TextTyped.Should().Be(text);
        }

        [Test]
        public void Type_GivenContinuationProvided_ReturnsContinuation()
        {
            sut.HasCapabilityReturn = (true, element);
            sut.Type(text).Should().BeSameAs(continuation);
        }

        private class TypeActionForTest : TypeAction<CommonTestElement>
        {
            public TypeActionForTest(CommonTestElement continuation)
                : base(continuation)
            {
            }

            public string TextTyped { get; private set; }

            public (bool, object) HasCapabilityReturn { get; set; }

            protected override (bool, object) HasCapability(Capability capability)
                => HasCapabilityReturn;

            protected override void PerformType(string text)
                => TextTyped = text;
        }
    }
}
