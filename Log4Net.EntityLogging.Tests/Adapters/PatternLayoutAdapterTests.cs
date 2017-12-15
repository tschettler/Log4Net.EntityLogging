using log4net.Core;
using log4net.Layout;
using log4net.Util;
using Log4Net.EntityLogging.Adapters;
using Log4Net.EntityLogging.Attributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log4Net.EntityLogging.Tests.Adapters
{
    [TestClass]
    public class PatternLayoutAdapterTests
    {
        private static PatternLayoutAdapter sut;

        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            sut = new PatternLayoutAdapter();
        }

        [TestMethod]
        public void ConfigureLayout_WithAttribute_ShouldSetConversionPattern()
        {
            // Arrange
            var attribute = new PatternLayoutAttribute("%test");
            var layout = new PatternLayout();

            // Act
            sut.ConfigureLayout(layout, attribute);

            // Assert
            Assert.AreEqual(attribute.Pattern, layout.ConversionPattern);
        }

        [TestMethod]
        public void ConfigureLayout_WithAttributeAndConverter_ShouldAddConverter()
        {
            // Arrange            
            var attribute = new PatternLayoutAttribute("%test", typeof(TestPatternConverter));
            var layout = new PatternLayout();

            // Act
            sut.ConfigureLayout(layout, attribute);
            layout.ActivateOptions();

            using (var writer = new StringWriter())
            {
                layout.Format(writer, new LoggingEvent(new LoggingEventData() { Message = "123" }));

                // Assert
                Assert.AreEqual("Test", writer.ToString());
            }
        }

        [TestMethod]
        public void AdaptLayoutShouldFormatEventWithAttributePattern()
        {
            //var appender = Substitute.For<AppenderSkeleton>();
            //appender.When(a => a
            //.DoAppend(Arg.Any<LoggingEvent>()))
            //    .Do(c =>
            //    {
            //        var evt = c.Arg<LoggingEvent>();
            //    });

            //ILoggerRepository rep = LogManager.CreateRepository(Guid.NewGuid().ToString());
            //BasicConfigurator.Configure(rep, appender);

            // Arrange
            var message = "Test message";
            var attribute = new PatternLayoutAttribute("%message");

            // Act
            var layout = sut.Adapt(attribute);

            var result = layout.Format(new LoggingEvent(new LoggingEventData() { Message = message }));

            // Assert
            Assert.AreEqual(message, result.ToString());
        }
    }
}
