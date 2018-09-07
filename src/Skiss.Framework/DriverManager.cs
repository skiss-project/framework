namespace Skiss.Framework
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
                Guard.AgainstNull(value, nameof(value));
                currentDriver = value;
            }
        }
    }
}
