﻿namespace Skiss.Framework
{
    using System;

    public abstract class Element<T> where T : Element<T>
    {
        public void End() => DriverManager.Current.End();

        protected TypeAction<T> FindTypable(string identifier) => DriverManager.Current.FindTypable<T>(identifier);

        protected ClickAction<T> FindClickable(string identifier) => DriverManager.Current.FindClickable<T>(identifier);

        protected ReadAction<T> FindReadable(string identifier) => DriverManager.Current.FindReadable<T>(identifier);
    }
}