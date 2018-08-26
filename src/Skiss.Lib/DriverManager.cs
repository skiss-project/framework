namespace Skiss.Lib
{
    public static class DriverManager
    {
        private static IDriver currentDriver = null;

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
