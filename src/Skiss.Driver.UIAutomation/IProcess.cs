namespace Skiss.Driver.UIAutomation
{
    using System;

    internal interface IProcess
    {
        IntPtr MainWindowHandle { get; }
    }
}
