using log4net.Layout;
using Log4Net.EntityLogging.Attributes;

namespace Log4Net.EntityLogging.Adapters
{
    public class DynamicPatternLayoutAdapter : LayoutAdapter<DynamicPatternLayoutAttribute, DynamicPatternLayout>
    {
        public override void ConfigureLayout(DynamicPatternLayout layout, DynamicPatternLayoutAttribute attribute)
        {
            layout.ConversionPattern = attribute.Pattern;
        }
    }
}
