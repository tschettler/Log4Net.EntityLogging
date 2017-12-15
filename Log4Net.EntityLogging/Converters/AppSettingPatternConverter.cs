using log4net.Util;
using System.Configuration;
using System.IO;

namespace Log4Net.EntityLogging.Converters
{
    public class AppSettingPatternConverter : PatternConverter
    {
        protected override void Convert(TextWriter writer, object state)
        {
            var value = ConfigurationManager.AppSettings[Option];

            if (string.IsNullOrWhiteSpace(value))
            {
                value = SystemInfo.NullText;
            }

            writer.Write(value);
        }
    }
}
