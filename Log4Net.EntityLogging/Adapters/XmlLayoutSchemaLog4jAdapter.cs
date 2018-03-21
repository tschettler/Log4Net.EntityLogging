using log4net.Layout;
using Log4Net.EntityLogging.Attributes;

namespace Log4Net.EntityLogging.Adapters
{
    public class XmlLayoutSchemaLog4jAdapter : LayoutAdapter<XmlLayoutSchemaLog4jAttribute, XmlLayoutSchemaLog4j>
    {
        public override void ConfigureLayout(XmlLayoutSchemaLog4j layout, XmlLayoutSchemaLog4jAttribute attribute)
        {
            layout.LocationInfo = attribute.LocationInfo;
            layout.Version = attribute.Version;
        }
    }
}
