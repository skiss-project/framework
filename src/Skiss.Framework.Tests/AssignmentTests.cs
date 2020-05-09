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
    using Skiss.Framework;

    public class AssignmentTests
    {
        [Test]
        public void Start_GivenNullTask_ThrowsException()
        {
            Action starting = () => Assignment<CommonTestElement>.Start(null);
            starting.Should().ThrowExactly<ArgumentNullException>()
                .Which.ParamName.Should().Be("task");
        }

        [Test]
        public void Start_GivenDriverSet_LaunchesUsingDriver()
        {
            var fixture = new Fixture();
            var task = fixture.Create<string>();
            var expected = new CommonTestElement();

            var driver = new Mock<IDriver>();
            driver.Setup(d => d.Start<CommonTestElement>(task)).Returns(expected);

            DriverManager.Current = driver.Object;

            var element = Assignment<CommonTestElement>.Start(task);

            element.Should().BeSameAs(expected);
            driver.VerifyAll();
        }
    }
}
