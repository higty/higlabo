/*
 * Reference from this article
 * http://blogs.msdn.com/b/musings_on_alm_and_software_development_processes/archive/2014/09/17/outputting-wadl-for-api-management-from-a-web-api-service.aspx
 * by Jeff Levinson
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web.Http;
using System.Web.Http.Description;
using System.Xml;

namespace HigLabo.Web.Mvc
{
    public class WadlXmlWriter
    {
        private static readonly Dictionary<Type, string> TypeMappings = new Dictionary<Type, string>()  
        {                 
            {typeof(string), "string" },
            {typeof(bool), "boolean" },
            {typeof(decimal), "decimal" },
            {typeof(float), "float" },
            {typeof(double), "double" },
            {typeof(int), "int" },
            {typeof(DateTime), "datetime" },
            {typeof(Guid), "guid" }
        };
        public String ServiceName { get; set; }
        public String Write(HttpConfiguration configuration)
        {
            return Write(configuration.Services.GetApiExplorer().ApiDescriptions);
        }
        public String Write(IEnumerable<ApiDescription> apiDescriptions)
        {
            StringBuilder sb = new StringBuilder();

            using (XmlWriter xw = XmlWriter.Create(new StringWriter(sb)))
            {
                xw.WriteStartElement("application", "http://wadl.dev.java.net/2009/02");
                xw.WriteStartElement("resources", "http://wadl.dev.java.net/2009/02");
                xw.WriteAttributeString("base", "https://" + this.ServiceName + ".azure-mobile.net");

                foreach (ApiDescription api in apiDescriptions)
                {
                    xw.WriteStartElement("resource", "http://wadl.dev.java.net/2009/02");
                    xw.WriteAttributeString("path", api.RelativePath);
                    xw.WriteStartElement("doc", "http://wadl.dev.java.net/2009/02");
                    xw.WriteAttributeString("title", api.Documentation);
                    xw.WriteEndElement();
                    xw.WriteStartElement("method", "http://wadl.dev.java.net/2009/02");
                    xw.WriteAttributeString("name", api.HttpMethod.Method);
                    xw.WriteStartElement("request", "http://wadl.dev.java.net/2009/02");

                    foreach (var param in api.ParameterDescriptions)
                    {
                        xw.WriteStartElement("param", "http://wadl.dev.java.net/2009/02");
                        xw.WriteAttributeString("name", param.Name);
                        xw.WriteAttributeString("style", "template");
                        xw.WriteStartAttribute("type");
                        xw.WriteQualifiedName(ToXmlTypeString(param.ParameterDescriptor.ParameterType) ?? "string", "http://www.w3.org/2001/XMLSchema");
                        xw.WriteEndAttribute();
                        xw.WriteAttributeString("required", "true");
                        xw.WriteEndElement();
                    }
                    xw.WriteEndElement(); // request
                    xw.WriteEndElement(); // method
                    xw.WriteEndElement(); //resource
                }
                xw.WriteEndElement(); //resources
                xw.WriteEndElement(); //application
            }
            return sb.ToString();
        }
        private static string ToXmlTypeString(Type type)
        {
            string typeString;
            if (TypeMappings.TryGetValue(type, out typeString))
            {
                return typeString;
            }
            return null;
        }
    }
}
