using log4net.Core;
using log4net.Layout;
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
    public class RawLayoutAdapterTests
    {
        [TestMethod]
        public void CanAdapt_WithValidType_ShouldReturnTrue()
        {
            // Arrange
            var sut = new RawPropertyLayoutAdapter();
            var attribute = new RawPropertyLayoutAttribute("test");

            // Act
            var result = sut.CanAdapt(attribute);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Adapt_WithLayoutAttribute_ShouldReturnIRawLayout()
        {
            // Arrange
            var sut = new RawPropertyLayoutAdapter();
            LayoutAttribute attribute = new RawPropertyLayoutAttribute("test");

            // Act
            var result = sut.Adapt(attribute);

            // Assert
            Assert.IsInstanceOfType(result, typeof(IRawLayout));
        }

        [TestMethod]
        public void CanAdapt_WithInvalidType_ShouldReturnFalse()
        {
            // Arrange
            var sut = new RawPropertyLayoutAdapter();
            var attribute = new ExceptionLayoutAttribute();

            // Act
            var result = sut.CanAdapt(attribute);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
