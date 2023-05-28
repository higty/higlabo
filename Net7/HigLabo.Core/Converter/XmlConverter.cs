using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace HigLabo.Core
{
    public class XmlConverter
    {
        private static class RegexList
        {
            public static Regex Sanitize = new Regex(@"&#x([0-9A-F]{1,2});");
        }
        public Boolean IsSanitize { get; set; }

        public XmlConverter()
        {
            this.IsSanitize = true;
        }
        public String Serialize(Object obj)
        {
            var sl = new System.Xml.Serialization.XmlSerializer(obj.GetType());
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);

            sl.Serialize(sw, obj);
            return SanitizeXml(sb.ToString());
        }
        public T Deserialize<T>(String text)
        {
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            var xmlText = text;
            if (this.IsSanitize == true)
            {
                xmlText = this.SanitizeXml(text);
            }
            return (T)serializer.Deserialize(new StringReader(xmlText));
        }
        public String SanitizeXml(String text)
        {
            if (text == null) { return null; }

            var sanitised = RegexList.Sanitize.Replace(text, new MatchEvaluator(match =>
            {
                var value = match.Groups[1].Value;

                int characterCode;
                if (int.TryParse(value, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out characterCode))
                {
                    if (characterCode >= char.MinValue && characterCode <= char.MaxValue)
                    {
                        return XmlConvert.IsXmlChar((char)characterCode) ? match.Value : string.Empty;
                    }
                }
                return match.Value;
            }));

            return sanitised;
        }
    }
}
