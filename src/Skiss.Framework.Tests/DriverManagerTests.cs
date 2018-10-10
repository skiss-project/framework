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
    using Moq;
    using NUnit.Framework;
    using Skiss.Framework;

    public class DriverManagerTests
    {
        [Test]
        public void CurrentGetter_GivenDriverNotSet_ThrowsException()
        {
            DriverManager.Current = null;
            Action gettingTheUnsetDriver = () => { var d = DriverManager.Current; };
            gettingTheUnsetDriver.Should().ThrowExactly<NoDriverException>();
        }

        [Test]
        public void CurrentGetter_GivenDriverSet_DoesNotThrowException()
        {
            var driver = Mock.Of<IDriver>();
            DriverManager.Current = driver;
            DriverManager.Current.Should().BeSameAs(driver);
        }
    }
}
