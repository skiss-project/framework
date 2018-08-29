namespace Skiss.Framework
{
    public abstract class ClickAction<T> : ElementAction<T> where T : Element<T>
    {
        private readonly T continuation;

        public ClickAction(T continuation)
        {
            this.continuation = continuation;
        }

        public T Click()
        {
            PerformClick();
            return continuation;
        }

        protected abstract void PerformClick();
    }
}