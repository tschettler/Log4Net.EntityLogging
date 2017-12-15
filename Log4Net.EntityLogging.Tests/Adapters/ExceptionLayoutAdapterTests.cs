using log4net;
using log4net.Core;
using log4net.Layout;
using log4net.Repository;
using Log4Net.EntityLogging.Adapters;
using Log4Net.EntityLogging.Attributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log4Net.EntityLogging.Tests.Adapters
{
    [TestClass]
    public class ExceptionLayoutAdapterTests
    {
        private static ExceptionLayoutAdapter sut;

        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            sut = new ExceptionLayoutAdapter();
        }

        [TestMethod]
        public void AdaptLayoutShouldCorrectlyFormatEvent()
        {
            // Arrange
            var attribute = new ExceptionLayoutAttribute();
            var repository = LogManager.CreateRepository(Guid.NewGuid().ToString());
            var exception = new Exception("An error occurred");

            // Act
            var layout = sut.Adapt(attribute);

            var result = layout.Format(new LoggingEvent(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, repository, "TestLogger", Level.Error, "Error occurred", exception));

            // Assert
            var expected = $"{exception.GetType().FullName}: {exception.Message}";
            Assert.AreEqual(expected, result);
        }
    }
}
