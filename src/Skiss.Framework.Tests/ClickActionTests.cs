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

    public class ClickActionTests
    {
        private object element;
        private CommonTestElement continuation;
        private ClickActionForTest sut;

        [SetUp]
        public void Setup()
        {
            element = new object();
            continuation = new CommonTestElement();
            sut = new ClickActionForTest(continuation);
        }

        [Test]
        public void Constructor_GivenNullContinuation_ThrowsException()
        {
            Action constructing = () => new ClickActionForTest(null);
            constructing.Should().ThrowExactly<ArgumentNullException>()
                .Which.ParamName.Should().Be("continuation");
        }

        [Test]
        public void Click_GivenCapabilityNotProvided_ThrowsException()
        {
            sut.HasCapabilityReturn = (false, element);

            Action clicking = () => sut.Click();

            var exception = clicking.Should().ThrowExactly<MissingCapabilityException>().And;
            exception.Capability.Should().Be(Capability.Clickable);
            exception.Element.Should().Be(element);
        }

        [Test]
        public void Click_GivenCapabilityProvided_CallsPerformClickOnSubClass()
        {
            sut.HasCapabilityReturn = (true, element);
            sut.Click();
            sut.ClickPerformed.Should().BeTrue();
        }

        [Test]
        public void Click_GivenContinuationProvided_ReturnsContinuation()
        {
            sut.HasCapabilityReturn = (true, element);
            sut.Click().Should().BeSameAs(continuation);
        }

        private class ClickActionForTest : ClickAction<CommonTestElement>
        {
            public ClickActionForTest(CommonTestElement continuation)
                : base(continuation)
            {
            }

            public bool ClickPerformed { get; private set; }

            public (bool, object) HasCapabilityReturn { get; set; }

            protected override (bool, object) HasCapability(Capability capability)
                => HasCapabilityReturn;

            protected override void PerformClick()
                => ClickPerformed = true;
        }
    }
}
