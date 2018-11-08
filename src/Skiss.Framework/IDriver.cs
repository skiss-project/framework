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

namespace Skiss.Framework
{
    public interface IDriver
    {
        T Start<T>(string task)
            where T : Element<T>, new();

        void Stop();

        void Kill();

        TypeAction<T> FindTypable<T>(string identifier)
            where T : Element<T>;

        ClickAction<T> FindClickable<T>(string identifier)
            where T : Element<T>;

        ReadAction<T> FindReadable<T>(string identifier)
            where T : Element<T>;
    }
}
