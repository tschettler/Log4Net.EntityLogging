using log4net.Layout;
using Log4Net.EntityLogging.Adapters;
using Log4Net.EntityLogging.Attributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Log4Net.EntityLogging.Tests.Adapters
{
    [TestClass]
    public class XmlLayoutAdapterTests
    {
        [TestMethod]
        public void ConfigureLayout_WithAttribute_ShouldSetPrefix()
        {
            // Arrange
            var sut = new XmlLayoutAdapter();
            var attribute = new XmlLayoutAttribute() { Prefix = "Test" };
            var layout = new XmlLayout();

            // Act
            sut.ConfigureLayout(layout, attribute);

            // Assert
            Assert.AreEqual(attribute.Prefix, layout.Prefix);
        }

        [TestMethod]
        public void ConfigureLayout_WithAttribute_ShouldSetLocationInfo()
        {
            // Arrange
            var sut = new XmlLayoutAdapter();
            var attribute = new XmlLayoutAttribute() { LocationInfo = true };
            var layout = new XmlLayout();

            // Act
            sut.ConfigureLayout(layout, attribute);

            // Assert
            Assert.AreEqual(attribute.LocationInfo, layout.LocationInfo);
        }

        [TestMethod]
        public void ConfigureLayout_WithAttribute_ShouldSetBase64EncodeMessage()
        {
            // Arrange
            var sut = new XmlLayoutAdapter();
            var attribute = new XmlLayoutAttribute() { Base64EncodeMessage = true };
            var layout = new XmlLayout();

            // Act
            sut.ConfigureLayout(layout, attribute);

            // Assert
            Assert.AreEqual(attribute.Base64EncodeMessage, layout.Base64EncodeMessage);
        }


        [TestMethod]
        public void ConfigureLayout_WithAttribute_ShouldSetBase64EncodeProperties()
        {
            // Arrange
            var sut = new XmlLayoutAdapter();
            var attribute = new XmlLayoutAttribute() { Base64EncodeProperties = true };
            var layout = new XmlLayout();

            // Act
            sut.ConfigureLayout(layout, attribute);

            // Assert
            Assert.AreEqual(attribute.Base64EncodeProperties, layout.Base64EncodeProperties);
        }

    }
}
