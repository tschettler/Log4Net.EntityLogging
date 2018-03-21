using System;

namespace Log4Net.EntityLogging.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public abstract class LayoutAttribute : Attribute
    {
    }
}
