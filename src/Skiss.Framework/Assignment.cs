namespace Skiss.Framework
{
    public static class Assignment<T> where T : Element<T>, new()
    {
        public static T Start(string task) => DriverManager.Current.Start<T>(task);
    }
}
