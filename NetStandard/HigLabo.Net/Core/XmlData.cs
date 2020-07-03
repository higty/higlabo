using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Net
{
    /// <summary>
    /// 
    /// </summary>
    public class XmlData : Dictionary<String, String>
    {
        private const int DefaultIndent = 2;

        /// <summary>
        /// 
        /// </summary>
        public String XmlDeclaration { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String RootElementName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public XmlData Child { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<XmlAttribute> Attributes { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public XmlData()
            : this(String.Empty)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rootElementName"></param>
        public XmlData(String rootElementName)
        {
            XmlDeclaration = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?>";
            RootElementName = rootElementName;
            Attributes = new List<XmlAttribute>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return CreateXmlText(this, 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string CreateAttributeText(XmlData data)
        {
            if (data.Attributes.Count > 0)
            {
                return " " + String.Join(" ", data.Attributes.Select(a => a.ToString()).ToArray());
            }
            return String.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="indent"></param>
        /// <returns></returns>
        private String CreateXmlText(XmlData data, int indent)
        {
            var sb = new StringBuilder(1024);

            if (indent == 0)
            {
                sb.AppendLine(data.XmlDeclaration);
            }

            sb.AppendFormat("{0}<{1}{2}>", new String(' ', indent), data.RootElementName, CreateAttributeText(data));
            sb.AppendLine();
            foreach (var key in data.Keys)
            {
                sb.AppendFormat("{0}<{1}>{2}</{1}>", new String(' ', indent + DefaultIndent), key, data[key]);
                sb.AppendLine();
            }
            if (data.Child != null)
            {
                sb.AppendLine(CreateXmlText(data.Child, indent + DefaultIndent));
            }
            sb.AppendFormat("{0}</{1}>", new String(' ', indent), data.RootElementName);

            return sb.ToString();
        }
    }
}