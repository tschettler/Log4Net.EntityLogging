namespace Log4Net.EntityLogging.Attributes
{
    public class XmlLayoutAttribute : LayoutAttribute
    {
        public bool LocationInfo { get; set; }

        public string Prefix { get; set; }

        public bool Base64EncodeMessage { get; set; }

        public bool Base64EncodeProperties { get; set; }
    }
}
