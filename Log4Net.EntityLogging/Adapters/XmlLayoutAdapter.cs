using log4net.Layout;
using Log4Net.EntityLogging.Attributes;

namespace Log4Net.EntityLogging.Adapters
{
    public class XmlLayoutAdapter : LayoutAdapter<XmlLayoutAttribute, XmlLayout>
    {
        public override void ConfigureLayout(XmlLayout layout, XmlLayoutAttribute attribute)
        {
            layout.LocationInfo = attribute.LocationInfo;
            layout.Base64EncodeMessage = attribute.Base64EncodeMessage;
            layout.Base64EncodeProperties = attribute.Base64EncodeProperties;
            layout.Prefix = attribute.Prefix;
        }
    }
}
