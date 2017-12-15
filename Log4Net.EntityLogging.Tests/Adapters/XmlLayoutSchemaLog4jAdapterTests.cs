using log4net.Layout;
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
    public class XmlLayoutSchemaLog4jAdapterTests
    {
        [TestMethod]
        public void ConfigureLayout_WithAttribute_ShouldSetVersion()
        {
            // Arrange
            var sut = new XmlLayoutSchemaLog4jAdapter();
            var attribute = new XmlLayoutSchemaLog4jAttribute() {Version = "1.2" };
            var layout = new XmlLayoutSchemaLog4j();

            // Act
            sut.ConfigureLayout(layout, attribute);

            // Assert
            Assert.AreEqual(attribute.Version, layout.Version);
        }

        [TestMethod]
        public void ConfigureLayout_WithAttribute_ShouldSetLocationInfo()
        {
            // Arrange
            var sut = new XmlLayoutSchemaLog4jAdapter();
            var attribute = new XmlLayoutSchemaLog4jAttribute() { LocationInfo = true };
            var layout = new XmlLayoutSchemaLog4j();

            // Act
            sut.ConfigureLayout(layout, attribute);

            // Assert
            Assert.AreEqual(attribute.LocationInfo, layout.LocationInfo);
        }
    }
}
