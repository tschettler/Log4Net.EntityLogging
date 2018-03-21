namespace Log4Net.EntityLogging.Attributes
{
    public class DynamicPatternLayoutAttribute : LayoutAttribute
    {
        public string Header { get; set; }

        public string Footer { get; set; }

        public string Pattern { get; set; }
    }
}
