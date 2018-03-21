using log4net.Layout;
using Log4Net.EntityLogging.Attributes;

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
