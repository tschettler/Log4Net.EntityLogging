using log4net.Layout;
using Log4Net.EntityLogging.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log4Net.EntityLogging.Adapters
{
    public abstract class RawLayoutAdapter<TAttribute, TRawLayout> : IRawLayoutAdapter<TAttribute, TRawLayout>
        where TAttribute : LayoutAttribute
        where TRawLayout : IRawLayout
    {
        public virtual void ConfigureLayout(TRawLayout layout, TAttribute attribute) { }

        public virtual IRawLayout Adapt(LayoutAttribute attribute)
        {
            return Adapt(attribute as TAttribute);
        }

        public virtual IRawLayout Adapt(TAttribute attribute)
        {
            var layout = Activator.CreateInstance<TRawLayout>();
            ConfigureLayout(layout, attribute);
            return layout;
        }

        public virtual bool CanAdapt(LayoutAttribute attribute)
        {
            return attribute is TAttribute;
        }
    }
}
