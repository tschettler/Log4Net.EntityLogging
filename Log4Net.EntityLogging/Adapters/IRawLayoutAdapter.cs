using log4net.Layout;
using Log4Net.EntityLogging.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log4Net.EntityLogging.Adapters
{
    public interface IRawLayoutAdapter
    {
        bool CanAdapt(LayoutAttribute attribute);

        IRawLayout Adapt(LayoutAttribute attribute);
    }

    public interface IRawLayoutAdapter<TAttribute, TRawLayout> : IRawLayoutAdapter
        where TAttribute : LayoutAttribute
        where TRawLayout : IRawLayout
    {
        void ConfigureLayout(TRawLayout layout, TAttribute attribute);

        IRawLayout Adapt(TAttribute attribute);
    }
}
