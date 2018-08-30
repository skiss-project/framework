﻿namespace Skiss.Framework
{
    using System;

    public static class VerificationExtensions
    {
        public static T Now<T>(this T self, Action<T> action)
        {
            action(self);
            return self;
        }
    }
}