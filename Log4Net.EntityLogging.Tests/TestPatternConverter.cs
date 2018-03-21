using log4net.Util;
using System.IO;

namespace Log4Net.EntityLogging.Tests
{
    internal class TestPatternConverter : PatternConverter
    {
        protected override void Convert(TextWriter writer, object state)
        {
            var value = "Test";

            writer.Write(value);
        }
    }
}
