using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace Log4Net.EntityLogging.Tests
{
    /// <summary>
    /// Summary description for EntityAppenderTests
    /// </summary>
    [TestClass]
    public class EntityAppenderTests
    {
        [TestMethod]
        public void Ctor_WithoutParameter_ShoudSetDefaultLayoutAdapterProvider()
        {
            // Arrange
            var sut = new EntityAppender<object>();

            // Act
            var property = sut.GetType().GetProperty("LayoutAdapterProvider", BindingFlags.Instance | BindingFlags.NonPublic);
            var layoutAdapterProvider = property.GetValue(sut) as LayoutAdapterProvider;

            // Assert
            Assert.IsInstanceOfType(layoutAdapterProvider, typeof(LayoutAdapterProvider));
        }
    }
}
