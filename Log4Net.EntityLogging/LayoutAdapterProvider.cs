using log4net.Layout;
using Log4Net.EntityLogging.Adapters;
using Log4Net.EntityLogging.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Log4Net.EntityLogging
{
    public class LayoutAdapterProvider : ILayoutAdapterProvider
    {
        protected static List<IRawLayoutAdapter> LayoutAdapters { get; set; }

        static LayoutAdapterProvider()
        {
            LayoutAdapters = new List<IRawLayoutAdapter>();
            var assembly = typeof(LayoutAdapterProvider).Assembly;

            foreach (Type current in
                from t in assembly.GetTypes()
                where !t.IsAbstract && typeof(IRawLayoutAdapter).IsAssignableFrom(t)
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
    }
}
