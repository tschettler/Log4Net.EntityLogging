using log4net.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log4Net.EntityLogging.Attributes
{
    public class DynamicPatternLayoutAttribute : LayoutAttribute
    {
        public string Header { get; set; }

        public string Footer { get; set; }

        public string Pattern { get; set; }
    }
}
