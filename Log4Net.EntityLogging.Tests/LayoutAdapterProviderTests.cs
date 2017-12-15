using log4net.Layout;
using Log4Net.EntityLogging.Adapters;
using Log4Net.EntityLogging.Attributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Log4Net.EntityLogging.Tests
{
    [TestClass]
    public class LayoutAdapterProviderTests
    {
        [TestMethod]
        public void Cctor_ShouldLoadAllLayoutAdapters()
        {
            // Arrange

            // Act
            var property = typeof(LayoutAdapterProvider).GetProperty("LayoutAdapters", BindingFlags.Static | BindingFlags.NonPublic);
            var layoutAdapters = property.GetValue(null) as List<IRawLayoutAdapter>;

            // Assert
            Assert.IsTrue(layoutAdapters.Count > 0);
        }

        [TestMethod]
        public void GetLayout_WithPatternLayoutAttribute_ShouldReturnLayout2RawLayout()
        {
            // Arrange
            var sut = new LayoutAdapterProvider();
            var attribute = new PatternLayoutAttribute("%message");

            // Act
            var result = sut.GetLayout(attribute);

            // Assert
            Assert.IsInstanceOfType(result, typeof(Layout2RawLayoutAdapter));
        }

        [TestMethod]
        public void GetLayout_WithDynamcPatternLayoutAttribute_ShouldReturnLayout2RawLayout()
        {
            // Arrange
            var sut = new LayoutAdapterProvider();
            var attribute = new DynamicPatternLayoutAttribute() { Pattern = "%message" };

            // Act
            var result = sut.GetLayout(attribute);

            // Assert
            Assert.IsInstanceOfType(result, typeof(Layout2RawLayoutAdapter));
        }

        [TestMethod]
        public void GetLayout_WithExceptionLayoutAttribute_ShouldReturnLayout2RawLayout()
        {
            // Arrange
            var sut = new LayoutAdapterProvider();
            var attribute = new ExceptionLayoutAttribute();

            // Act
            var result = sut.GetLayout(attribute);

            // Assert
            Assert.IsInstanceOfType(result, typeof(Layout2RawLayoutAdapter));
        }

        [TestMethod]
        public void GetLayout_WithSimpleLayoutAttribute_ShouldReturnLayout2RawLayout()
        {
            // Arrange
            var sut = new LayoutAdapterProvider();
            var attribute = new SimpleLayoutAttribute();

            // Act
            var result = sut.GetLayout(attribute);

            // Assert
            Assert.IsInstanceOfType(result, typeof(Layout2RawLayoutAdapter));
        }

        [TestMethod]
        public void GetLayout_WithXmlLayoutAttribute_ShouldReturnLayout2RawLayout()
        {
            // Arrange
            var sut = new LayoutAdapterProvider();
            var attribute = new XmlLayoutAttribute();

            // Act
            var result = sut.GetLayout(attribute);

            // Assert
            Assert.IsInstanceOfType(result, typeof(Layout2RawLayoutAdapter));
        }


        [TestMethod]
        public void GetLayout_WithXmlLayoutSchemaLog4jAttribute_ShouldReturnLayout2RawLayout()
        {
            // Arrange
            var sut = new LayoutAdapterProvider();
            var attribute = new XmlLayoutSchemaLog4jAttribute();

            // Act
            var result = sut.GetLayout(attribute);

            // Assert
            Assert.IsInstanceOfType(result, typeof(Layout2RawLayoutAdapter));
        }

        [TestMethod]
        public void GetLayout_WithRawTimeStampLayoutAttribute_ShouldReturnRawTimeStampLayout()
        {
            // Arrange
            var sut = new LayoutAdapterProvider();
            var attribute = new RawTimeStampLayoutAttribute();

            // Act
            var result = sut.GetLayout(attribute);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RawTimeStampLayout));
        }

        [TestMethod]
        public void GetLayout_WithRawUtcTimeStampLayoutAttribute_ShouldReturnRawUtcTimeStampLayout()
        {
            // Arrange
            var sut = new LayoutAdapterProvider();
            var attribute = new RawUtcTimeStampLayoutAttribute();

            // Act
            var result = sut.GetLayout(attribute);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RawUtcTimeStampLayout));
        }

        [TestMethod]
        public void GetLayout_WithRawPropertyLayoutAttribute_ShouldReturnRawPropertyLayout()
        {
            // Arrange
            var sut = new LayoutAdapterProvider();
            var attribute = new RawPropertyLayoutAttribute("log4net:HostName");

            // Act
            var result = sut.GetLayout(attribute);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RawPropertyLayout));
        }

        [TestMethod]
        public void GetLayout_WithNullAttribute_ShouldReturnNull()
        {
            // Arrange
            var sut = new LayoutAdapterProvider();
            LayoutAttribute attribute = null;

            // Act
            var result = sut.GetLayout(attribute);

            // Assert
            Assert.IsNull(result);
        }
    }
}
