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
    using Moq;
    using NUnit.Framework;

    public class ElementTests
    {
        private Mock<IDriver> driver;

        private string identifier;

        private ElementForTest sut;

        [SetUp]
        public void Setup()
        {
            var fixture = new Fixture();
            identifier = fixture.Create<string>();

            driver = new Mock<IDriver>();
            DriverManager.Current = driver.Object;

            sut = new ElementForTest();
        }

        [Test]
        public void FindTypable_GivenIdentifier_CallsDriver()
        {
            var typeAction = new TypeActionForTest(new ElementForTest());
            driver.Setup(d => d.FindTypable<ElementForTest>(identifier)).Returns(typeAction);

            sut.FindTypable(identifier).Should().BeSameAs(typeAction);
            driver.VerifyAll();
        }

        [Test]
        public void FindClickable_GivenIdentifier_CallsDriver()
        {
            var clickAction = new ClickActionForTest(new ElementForTest());
            driver.Setup(d => d.FindClickable<ElementForTest>(identifier)).Returns(clickAction);

            sut.FindClickable(identifier).Should().BeSameAs(clickAction);
            driver.VerifyAll();
        }

        [Test]
        public void FindReadable_GivenIdentifier_CallsDriver()
        {
            var readAction = new ReadActionForTest();

            driver.Setup(d => d.FindReadable<ElementForTest>(identifier)).Returns(readAction);

            sut.FindReadable(identifier).Should().BeSameAs(readAction);
            driver.VerifyAll();
        }

        [Test]
        public void Stop_WhenInvoked_CallsDriver()
        {
            driver.Setup(d => d.Stop());

            sut.Stop();

            driver.VerifyAll();
        }

        [Test]
        public void Kill_WhenInvoked_CallsDriver()
        {
            driver.Setup(d => d.Kill());

            sut.Kill();

            driver.VerifyAll();
        }

        private class ElementForTest : Element<ElementForTest>
        {
            public new TypeAction<ElementForTest> FindTypable(string identifier)
                => base.FindTypable(identifier);

            public new ClickAction<ElementForTest> FindClickable(string identifier)
                => base.FindClickable(identifier);

            public new ReadAction<ElementForTest> FindReadable(string identifier)
                => base.FindReadable(identifier);
        }

        private class ReadActionForTest : ReadAction<ElementForTest>
        {
            protected override string GetText()
                => throw new NotImplementedException();

            protected override (bool, object) HasCapability(Capability capability)
                => throw new NotImplementedException();
        }

        private class ClickActionForTest : ClickAction<ElementForTest>
        {
            public ClickActionForTest(ElementForTest continuation)
                : base(continuation)
            {
            }

            protected override (bool, object) HasCapability(Capability capability)
                => throw new NotImplementedException();

            protected override void PerformClick()
                => throw new NotImplementedException();
        }

        private class TypeActionForTest : TypeAction<ElementForTest>
        {
            public TypeActionForTest(ElementForTest continuation)
                : base(continuation)
            {
            }

            protected override (bool, object) HasCapability(Capability capability)
                => throw new NotImplementedException();

            protected override void PerformType(string text)
                => throw new NotImplementedException();
        }
    }
}
