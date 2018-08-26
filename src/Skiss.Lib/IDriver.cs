namespace Skiss.Lib
{
    public interface IDriver
    {
        T Launch<T>(string task) 
            where T : Element<T>, new();
    }
}
