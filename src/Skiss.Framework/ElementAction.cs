namespace Skiss.Framework
{
    public abstract class ElementAction<T> where T : Element<T>
    {
        protected void MissingCapability(Capability capability, object element) 
            => throw new MissingCapabilityException(capability, element);
    }
}
