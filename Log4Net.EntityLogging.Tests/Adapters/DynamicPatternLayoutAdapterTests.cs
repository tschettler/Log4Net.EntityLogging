using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using log4net.Repository;
using Log4Net.EntityLogging.Adapters;
using Log4Net.EntityLogging.Attributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log4Net.EntityLogging.Tests.Adapters
{
    [TestClass]
    public class DynamicPatternLayoutAdapterTests
    {
        private static DynamicPatternLayoutAdapter sut;

        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            sut = new DynamicPatternLayoutAdapter();
        }

        [TestMethod]
        public void ConfigureLayout_WithAttribute_ShouldSetConversionPattern()
        {
            // Arrange
            var attribute = new DynamicPatternLayoutAttribute() { Pattern = "%test" };
            var layout = new DynamicPatternLayout();

            // Act
            sut.ConfigureLayout(layout, attribute);

            // Assert
            Assert.AreEqual(attribute.Pattern, layout.ConversionPattern);
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
            var attribute = new DynamicPatternLayoutAttribute() { Pattern = "%message" };

            // Act
            var layout = sut.Adapt(attribute);

            var result = layout.Format(new LoggingEvent(new LoggingEventData() { Message = message }));

            // Assert
            Assert.AreEqual(message, result.ToString());
        }
    }
}
