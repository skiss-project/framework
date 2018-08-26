using Skiss.Lib;

namespace Skiss.Driver.UIAutomation
{
    public class UIAutomationDriver : IDriver
    {
        public T Launch<T>(string task) where T : Element<T>, new()
        {
            throw new System.NotImplementedException();
        }
    }
}
