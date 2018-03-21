using log4net.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Log4Net.EntityLogging.Attributes
{
    public class PatternLayoutAttribute : LayoutAttribute
    {
        public List<Type> Converters { get; protected set; }

        public string Pattern { get; protected set; }

        public PatternLayoutAttribute(string pattern, params Type[] converters)
        {
            Pattern = pattern;

            ValidateConverters(converters);

            Converters = new List<Type>(converters);
        }

        private void ValidateConverters(IEnumerable<Type> converters)
        {
            var invalidConverters = converters.Where(c => !IsPatternConverter(c));
            if (invalidConverters.Any())
            {
                var invalidConverterNames = string.Join(", ", invalidConverters.Select(c => c.FullName));
                throw new ArgumentException($"Invalid pattern layout converters found: {invalidConverterNames}", nameof(converters));
            }
        }

        private bool IsPatternConverter(Type type)
        {
            var valid = typeof(PatternConverter).IsAssignableFrom(type);
            return valid;
        }
    }
}
