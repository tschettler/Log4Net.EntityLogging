using Log4Net.EntityLogging.Attributes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogTesting
{
    public class TestLogModel
    {
        [PatternLayout("%logger")]
        public string Logger { get; set; }

        [PatternLayout("%class")]
        public string Class { get; set; }

        [PatternLayout("%type")]
        public string Type { get; set; }

        [PatternLayout("%date")]
        public string Date { get; set; }

        [PatternLayout("%exception")]
        public string Exception { get; set; }

        [PatternLayout("%file")]
        public string File { get; set; }

        [PatternLayout("%location")]
        public string Location { get; set; }

        [PatternLayout("%line")]
        public string Line { get; set; }

        [PatternLayout("%message")]
        public string Message { get; set; }

        [PatternLayout("%method")]
        public string Method { get; set; }

        [PatternLayout("%level")]
        public string Level { get; set; }

        [PatternLayout("%timestamp")]
        public TimeSpan TimeStamp { get; set; }

        [PatternLayout("%stacktrace")]
        public string StackTrace { get; set; }

        [PatternLayout("%stacktracedetail")]
        public string StackTraceDetail { get; set; }

        [PatternLayout("%thread")]
        public string Thread { get; set; }

        [PatternLayout("%ndc")]
        public string Ndc { get; set; }

        [PatternLayout("%mdc")]
        public string Mdc { get; set; }

        [PatternLayout("%appdomain")]
        public string AppDomain { get; set; }

        [PatternLayout("%identity")]
        public string Identity { get; set; }

        [PatternLayout("%utcdate")]
        public DateTime UtcDate { get; set; }

        [PatternLayout("%username")]
        public string UserName { get; set; }

        [PatternLayout("%property{log4net:HostName}")]
        public string HostName { get; set; }

        [ExceptionLayout]
        public string RawException { get; set; }

        [RawPropertyLayout("log4net:HostName")]
        public string RawHostName { get; set; }

        [RawTimeStampLayout]
        public DateTime RawTimeStamp { get; set; }

        [RawUtcTimeStampLayout]
        public DateTime RawUtcTimeStamp { get; set; }

        [SimpleLayout]
        public string SimpleLayout { get; set; }

        [XmlLayout]
        public string XmlLayout { get; set; }

        [XmlLayoutSchemaLog4j]
        public string XmlLayoutSchemaLog4j { get; set; }
    }
}
