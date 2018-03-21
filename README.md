# Log4Net.EntityLogging
[![tschettler MyGet Build Status](https://www.myget.org/BuildSource/Badge/tschettler?identifier=beefcb91-8b27-49a5-9843-9817e292fec9)](https://www.myget.org/) ![NuGet](https://img.shields.io/nuget/v/Log4Net.EntityLogging.svg)


Log4Net library that allows logging to entities.

## Setup

### Installation
```
Install-Package Log4Net.EntityLogging
```

### Logging Entity
Create an entity with properties to be filled with the logging event properties. Use layout attributes to autofill property values based on the logging event. See [log4net.Layout.PatternLayout](https://logging.apache.org/log4net/release/sdk/html/T_log4net_Layout_PatternLayout.htm) for a list of available conversion patterns. Following is an example entity:

```cs
    public class LoggingEntity
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
```

### Entity Appender
Create the appender that will populate the entity. Override the `Save` method to perform custom save logic.

```cs
    public class LoggingEntityAppender : EntityAppender<LoggingEntity>
    {
        protected override void Save(List<LogEntity> items)
        {
            // Save entity logic
        }
    }
```

### Appender Configuration
Configure the appender for use in log4net, just as you would any other appender.

```xml
  <log4net debug="false">
    <appender name="EntityAppender" type="LoggingEntityAppender">
      <bufferSize value="0"/>
      <threshold value="INFO"/>
    </appender>
    <root>
      <priority value="ALL"/>
      <appender-ref ref="EntityAppender"/>
    </root>
  </log4net>
```

## Layout Attributes
Following are the layout attributes available:
- `DynamicPatternLayoutAttribute`
- `ExceptionLayoutAttribute`
- `PatternLayoutAttribute`
- `RawPropertyLayoutAttribute`
- `RawTimeStampLayoutAttribute`
- `RawUtcTimeStampLayoutAttribute`
- `SimpleLayoutAttribute`
- `XmlLayoutAttribute`
- `XmlLayoutSchemaLog4jAttribute`

## License

MIT © [Travis Schettler](https://github.com/tschettler)