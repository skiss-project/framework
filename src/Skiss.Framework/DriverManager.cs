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

namespace Skiss.Framework
{
    public static class DriverManager
    {
        private static IDriver currentDriver = null;

        /// <summary>
        /// Gets or sets the current <see cref="IDriver"/> implementation.
        /// </summary>
        /// <value>
        /// The current <see cref="IDriver"/> implementation used for finding <see cref="Element{T}"/>
        /// objects and their <see cref="ElementAction{T}"/> capabilities.
        /// </value>
        /// <exception cref="NoDriverException">
        /// Thrown when invoking get before implementation has been set.
        /// </exception>
        /// <remarks>
        /// <see cref="Element{T}"/> and <see cref="ElementAction{T}"/> will not work
        /// without setting <see cref="DriverManager.Current"/>.
        /// </remarks>
        public static IDriver Current
        {
            get
            {
                if (currentDriver == null)
                {
                    throw new NoDriverException();
                }

                return currentDriver;
            }

            set
            {
                currentDriver = value;
            }
        }
    }
}
