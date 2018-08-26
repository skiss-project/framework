namespace Skiss.Lib
{
    public abstract class TypeAction<T> : ElementAction<T> where T : Element<T>
    {
        private readonly T continuation;

        public TypeAction(T continuation)
        {
            this.continuation = continuation;
        }

        public T Type(string text)
        {
            PerformType(text);
            return continuation;
        }

        protected abstract void PerformType(string text);
    }
}
