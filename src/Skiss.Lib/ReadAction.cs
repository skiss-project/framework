namespace Skiss.Lib
{
    public abstract class ReadAction<T> : ElementAction<T> where T : Element<T>
    {
        public ReadAction()
        {
        }

        public string Text => GetText();

        protected abstract string GetText();
    }
}
