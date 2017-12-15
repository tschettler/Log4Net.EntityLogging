using log4net.Layout;
using Log4Net.EntityLogging.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log4Net.EntityLogging.Adapters
{
    public class RawPropertyLayoutAdapter : RawLayoutAdapter<RawPropertyLayoutAttribute, RawPropertyLayout>
    {
        public override void ConfigureLayout(RawPropertyLayout layout, RawPropertyLayoutAttribute attribute)
        {
            layout.Key = attribute.Key;
        }
    }
}
