using log4net.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log4Net.EntityLogging.Attributes
{
    public class RawPropertyLayoutAttribute : LayoutAttribute
    {
        public string Key { get; set; }

        public RawPropertyLayoutAttribute(string key)
        {
            Key = key;
        }
    }
}
