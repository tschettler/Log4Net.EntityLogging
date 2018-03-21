using log4net.Util;
using Log4Net.EntityLogging.Converters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.IO;

namespace Log4Net.EntityLogging.Tests.Converters
{
    [TestClass]
    public class AppSettingPatternConverterTests
    {
        [TestMethod]
        public void Convert_WithMissingAppSettingKey_ShouldReturnNullText()
        {
            // Arrange
            var key = "MissingKey";
            var sut = new AppSettingPatternConverter() { Option = key };

            // Act
            string result;
            using (var writer = new StringWriter())
            {
                sut.Format(writer, null);
                result = writer.ToString();
            }

            // Assert
            Assert.AreEqual(SystemInfo.NullText, result);
        }

        [TestMethod]
        public void Convert_WithAppSettingKey_ShouldReturnAppSettingValue()
        {
            // Arrange
            var key = "TestKey";
            var sut = new AppSettingPatternConverter() { Option = key };
            var expected = ConfigurationManager.AppSettings[key];

            // Act
            string result;
            using (var writer = new StringWriter())
            {
                sut.Format(writer, null);
                result = writer.ToString();
            }

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
