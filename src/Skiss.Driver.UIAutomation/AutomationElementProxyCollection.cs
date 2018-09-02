namespace Skiss.Driver.UIAutomation
{
    using System;
    using System.Collections;
    using System.Linq;
    using System.Windows.Automation;

    internal class AutomationElementProxyCollection : IAutomationElementCollection
    {
        private IList elements;

        public AutomationElementProxyCollection(AutomationElementCollection elements)
        {
            this.elements = elements
                .Cast<AutomationElement>()
                .Select(e => new AutomationElementProxy(e)) 
                .ToList<IAutomationElement>();
        }

        public int Count 
            => elements.Count;

        public bool IsSynchronized 
            => elements.IsSynchronized;

        public object SyncRoot 
            => elements.SyncRoot;

        public IAutomationElement this[int index] 
            => elements[index] as IAutomationElement;

        public void CopyTo(IAutomationElement[] array, int index) 
            => elements.CopyTo(array, index);

        public void CopyTo(Array array, int index) 
            => elements.CopyTo(array, index);

        public IEnumerator GetEnumerator() 
            => elements.GetEnumerator();
    }
}
