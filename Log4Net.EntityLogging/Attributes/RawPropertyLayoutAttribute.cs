namespace Log4Net.EntityLogging.Attributes
{
    public class RawPropertyLayoutAttribute : LayoutAttribute
    {
        public string Key { get; set; }

        public RawPropertyLayoutAttribute(string key)
        {
            Key = key;
        }
    }
}
