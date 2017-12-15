using log4net.Layout;
using log4net.Util;
using Log4Net.EntityLogging.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log4Net.EntityLogging.Adapters
{
    public class PatternLayoutAdapter : LayoutAdapter<PatternLayoutAttribute, PatternLayout>
    {
        public override void ConfigureLayout(PatternLayout layout, PatternLayoutAttribute attribute)
        {
            layout.ConversionPattern = attribute.Pattern;

            foreach(var converter in attribute.Converters)
            {
                var name = GetConverterName(converter);
                layout.AddConverter(name, converter);
            }
        }

        private string GetConverterName(Type type)
        {
            var typeName = type.Name.Replace("Converter", "").Replace("Pattern", "").ToLower();

            return typeName;
        }
    }
}
