namespace Skiss.Lib
{
    public static class Assignment<T> where T : Element<T>, new()
    {
        public static T Launch(string task) => DriverManager.Current.Launch<T>(task);
    }
}
