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
    public interface IDriver
    {
        /// <summary>
        /// Start an assignment and resolve initial <see cref="Element{T}"/> to use as start
        /// of fluent chain of <see cref="ElementAction{T}"/> invocations.
        /// </summary>
        /// <param name="task">
        /// The name of the task, understood by the <see cref="IDriver"/> implementation.
        /// </param>
        /// <returns>An <see cref="Element{T}"/> for fluent action chaining.</returns>
        T Start<T>(string task)
            where T : Element<T>, new();

        /// <summary>
        /// Politely asks the assignment chain to halt and terminate.
        /// </summary>
        void Stop();

        /// <summary>
        /// Impolitely, and immediately, halts and terminates the assignment chain.
        /// </summary>
        void Kill();

        /// <summary>
        /// Locates an element which supports <see cref="TypeAction{T}"/>.
        /// </summary>
        /// <typeparam name="T">Type of element.</typeparam>
        /// <param name="identifier">Unique identifier of element.</param>
        /// <returns>A <see cref="TypeAction{T}"/> that can be used to "enter text".</returns>
        TypeAction<T> FindTypable<T>(string identifier)
            where T : Element<T>;

        /// <summary>
        /// Locates an element which supports <see cref="ClickAction{T}"/>.
        /// </summary>
        /// <typeparam name="T">Type of element.</typeparam>
        /// <param name="identifier">Unique identifier of element.</param>
        /// <returns>A <see cref="ClickAction{T}"/> that can be used to "click" or otherwise "invoke".</returns>
        ClickAction<T> FindClickable<T>(string identifier)
            where T : Element<T>;

        /// <summary>
        /// Locates an element which supports <see cref="ReadAction{T}"/>.
        /// </summary>
        /// <typeparam name="T">Type of element.</typeparam>
        /// <param name="identifier">Unique identifier of element.</param>
        /// <returns>A <see cref="ReadAction{T}"/> that can be used to read textual content.</returns>
        ReadAction<T> FindReadable<T>(string identifier)
            where T : Element<T>;
    }
}
