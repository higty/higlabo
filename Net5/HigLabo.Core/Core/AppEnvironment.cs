using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Core
{
    public class AppEnvironment
    {
        private static AppEnvironment _Settings = new AppEnvironment();
        
        public static AppEnvironment Settings
        {
            get { return _Settings; }
        }

        public TypeConverter TypeConverter { get; set; }
        public Serializer JsonSerializer { get; set; }
        public Serializer XmlSerializer { get; set; }

        public AppEnvironment()
        {
            this.TypeConverter = new TypeConverter();
            //this.JsonSerializer = new JsonSerializer();
            this.XmlSerializer = new XmlSerializer();
        }
    }
}
