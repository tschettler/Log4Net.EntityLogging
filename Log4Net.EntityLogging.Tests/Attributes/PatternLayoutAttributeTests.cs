using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Log4Net.EntityLogging.Attributes;
using log4net.Layout.Pattern;
using NSubstitute;

namespace Log4Net.EntityLogging.Tests.Attributes
{
    /// <summary>
    /// Summary description for PatternLayoutAttributeTests
    /// </summary>
    [TestClass]
    public class PatternLayoutAttributeTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Ctor_WithInvalidConverterType_ShouldThrowArgumentException()
        {
            // Arrange
            var pattern = "%exception";
            var converterType = typeof(DateTime);

            // Act & Assert
            var attr = new PatternLayoutAttribute(pattern, converterType);
        }

        [TestMethod]
        public void Ctor_WithValidConverterType_ShouldAddConverter()
        {
            // Arrange
            var pattern = "%exception";
            var converter = Substitute.For<PatternLayoutConverter>().GetType();

            // Act
            var attr = new PatternLayoutAttribute(pattern, converter);

            // Assert
            Assert.IsTrue(attr.Converters.Count == 1);
        }
    }
}
