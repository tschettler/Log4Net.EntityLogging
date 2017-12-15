using log4net.Appender;
using log4net.Core;
using log4net.Layout;
using log4net.Util;
using Log4Net.EntityLogging.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Reflection;

namespace Log4Net.EntityLogging
{
    /// <summary>
    /// A log4net appender that can be used with any entity
    /// </summary>
    /// <typeparam name="TEntity"> Type of entity </typeparam>
    public class EntityAppender<TEntity> : BufferingAppenderSkeleton where TEntity : class, new()
    {
        private static readonly Type declaringType = typeof(EntityAppender<TEntity>);

        protected ILayoutAdapterProvider LayoutAdapterProvider { get; set; }

        /// <summary>
        /// Used for providing layout options for entity properties
        /// </summary>
        protected static readonly Dictionary<PropertyInfo, IRawLayout> PropertyLayouts = new Dictionary<PropertyInfo, IRawLayout>();

        public EntityAppender() : this(new LayoutAdapterProvider())
        {
        }

        public EntityAppender(ILayoutAdapterProvider layoutAdapterProvider)
        {
            LayoutAdapterProvider = layoutAdapterProvider;
        }

        public override void ActivateOptions()
        {
            base.ActivateOptions();
            LoadPropertyLayout();
        }

        protected virtual void LoadPropertyLayout()
        {
            var properties = typeof(TEntity).GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);

            foreach (var property in properties)
            {
                var attr = GetLayoutAttribute(property);
                if (attr == null)
                {
                    continue;
                }

                var layout = LayoutAdapterProvider.GetLayout(attr);

                if (layout == null)
                {
                    continue;
                }

                PropertyLayouts[property] = layout;
            }
        }

        protected virtual LayoutAttribute GetLayoutAttribute(PropertyInfo property)
        {
            var attribute = property.GetCustomAttribute<LayoutAttribute>();
            return attribute;
        }

        /// <summary>
        /// Converts a logging event to a entity
        /// </summary>
        /// <param name="loggingEvent">Logging event</param>
        protected virtual TEntity ConvertToEntity(LoggingEvent loggingEvent)
        {
            var poco = new TEntity();

            foreach (var propertyLayout in PropertyLayouts)
            {
                var property = propertyLayout.Key;
                var layout = propertyLayout.Value;

                var value = layout.Format(loggingEvent);

                var propertyType = property.PropertyType;
                var valueType = value.GetType();

                try
                {
                    var convertedValue = ConvertValue(value, propertyType);

                    property.SetValue(poco, convertedValue, null);
                }
                catch { }
            }

            return poco;
        }

        protected virtual object ConvertValue(object value, Type propertyType)
        {
            var result = value;
            var valueType = value.GetType();

            var converter = TypeDescriptor.GetConverter(propertyType);

            // Convert to null if the value is one of log4net's predefined values
            if (value.Equals(SystemInfo.NullText) || value.Equals(SystemInfo.NotAvailableText))
            {
                result = propertyType.IsValueType ? Activator.CreateInstance(propertyType) : null;
            }
            else if (!(propertyType == valueType || propertyType.IsAssignableFrom(valueType))
                && converter.CanConvertFrom(valueType))
            {
                // if the value is of a different type, try to convert it
                result = converter.ConvertFrom(value);
            }

            return result;
        }

        protected override void SendBuffer(LoggingEvent[] events)
        {
            SendBuffer(null, events);
        }

        protected virtual void SendBuffer(DbTransaction transaction, LoggingEvent[] events)
        {
            var items = new List<TEntity>();

            foreach (var loggingEvent in events)
            {
                var item = ConvertToEntity(loggingEvent);

                items.Add(item);
            }

            Save(transaction, items);
        }

        protected virtual void Save(DbTransaction transaction, List<TEntity> items)
        {
        }
    }
}
