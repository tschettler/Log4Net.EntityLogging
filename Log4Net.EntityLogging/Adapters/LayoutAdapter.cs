using log4net.Core;
using log4net.Layout;
using Log4Net.EntityLogging.Attributes;
using System;

namespace Log4Net.EntityLogging.Adapters
{
    public abstract class LayoutAdapter<TAttribute, TLayout> : RawLayoutAdapter<TAttribute, Layout2RawLayoutAdapter>
        where TAttribute : LayoutAttribute
        where TLayout : ILayout, IOptionHandler
    {
        public virtual void ConfigureLayout(TLayout layout, TAttribute attribute) { }

        public override IRawLayout Adapt(TAttribute attribute)
        {
            var layout = Activator.CreateInstance<TLayout>();
            ConfigureLayout(layout, attribute);

            layout.ActivateOptions();

            var rawLayout = new Layout2RawLayoutAdapter(layout);
            ConfigureLayout(rawLayout, attribute);

            return rawLayout;
        }
    }
}
