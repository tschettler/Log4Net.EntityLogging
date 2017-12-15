using log4net.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log4Net.EntityLogging.Attributes
{
    public class XmlLayoutSchemaLog4jAttribute : LayoutAttribute
    {
        public bool LocationInfo { get; set; }

        public string Version { get; set; } = "1.2";
    }
}
