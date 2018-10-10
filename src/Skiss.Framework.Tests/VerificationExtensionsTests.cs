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

            void Action(object inparameter)
                => parameter = inparameter;

            VerificationExtensions.Now((object)null, Action);

            parameter.Should().BeNull();
        }

        [Test]
        public void Now_GivenAction_CallsActionOnSelf()
        {
            object self = new object();
            object element = null;

            void Action(object el)
                => element = el;

            VerificationExtensions.Now(self, Action);

            element.Should().BeSameAs(self);
        }

        [Test]
        public void Now_GivenAction_ReturnsSelf()
        {
            object self = new object();
            void Action(object el)
            {
            }

            VerificationExtensions.Now(self, Action).Should().BeSameAs(self);
        }
    }
}
