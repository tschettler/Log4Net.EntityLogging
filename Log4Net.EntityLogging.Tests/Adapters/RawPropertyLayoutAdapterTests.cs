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
    public class RawPropertyLayoutAdapterTests
    {
        private static RawPropertyLayoutAdapter sut;

        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            sut = new RawPropertyLayoutAdapter();
        }

        [TestMethod]
        public void ConfigureLayout_WithAttribute_ShouldSetKey()
        {
            // Arrange
            var attribute = new RawPropertyLayoutAttribute("test");
            var layout = new RawPropertyLayout();

            // Act
            sut.ConfigureLayout(layout, attribute);

            // Assert
            Assert.AreEqual(attribute.Key, layout.Key);
        }

        [TestMethod]
        public void AdaptLayoutShouldFormatEventWithAttributeKey()
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
            var key = "TestKey";
            var value = "Test Value";
            ThreadContext.Properties[key] = value;
            var message = "Test message";
            var attribute = new RawPropertyLayoutAttribute(key);

            // Act
            var layout = sut.Adapt(attribute);

            var eventData = new LoggingEventData() { Message = message };
            var result = layout.Format(new LoggingEvent(eventData));

            // Assert
            Assert.AreEqual(value, result.ToString());
        }
    }
}
