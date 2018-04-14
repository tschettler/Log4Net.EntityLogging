using log4net.Layout;
using Log4Net.EntityLogging.Adapters;
using Log4Net.EntityLogging.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Log4Net.EntityLogging
{
    public class LayoutAdapterProvider : ILayoutAdapterProvider
    {
		private static TypeInfo LayoutAdapterTypeInfo = typeof(IRawLayoutAdapter).GetTypeInfo();

		protected static List<IRawLayoutAdapter> LayoutAdapters { get; set; }

        static LayoutAdapterProvider()
        {
            LayoutAdapters = new List<IRawLayoutAdapter>();
            var assembly = typeof(LayoutAdapterProvider).GetTypeInfo().Assembly;

            foreach (Type current in
                from t in assembly.GetTypes()
                where IsLayoutAdapter(t)
                select t)
            {
                var instance = Activator.CreateInstance(current) as IRawLayoutAdapter;
                LayoutAdapters.Add(instance);
            }
        }

        public IRawLayout GetLayout(LayoutAttribute attribute)
        {
            var adapter = LayoutAdapters.FirstOrDefault(a => a.CanAdapt(attribute));

            var layout = adapter?.Adapt(attribute);

            return layout;
        }

		private static bool IsLayoutAdapter(Type type)
		{
			var typeInfo = type.GetTypeInfo();
			return !typeInfo.IsAbstract && LayoutAdapterTypeInfo.IsAssignableFrom(typeInfo);
		}
    }
}
