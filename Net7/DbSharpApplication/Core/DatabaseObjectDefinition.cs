using HigLabo.DbSharp.MetaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbSharpApplication
{
    public class DatabaseObjectDefinition
    {
        public String Name { get; set; }
        public DatabaseObjectType ObjectType { get; set; }
        public String BodyText { get; set; }

        public DatabaseObjectDefinition(DatabaseObject obj)
            : this(obj.Name, obj.ObjectType, obj.Body)
        {
        }
        public DatabaseObjectDefinition(String name, DatabaseObjectType objectType, String bodyText)
        {
            this.Name = name;
            this.ObjectType = objectType;
            this.BodyText = bodyText;
        }

        public List<DatabaseObjectDefinition> DependencyList { get; init; } = new List<DatabaseObjectDefinition>();
        public List<String> SelectTableList { get; init; } = new List<string>();
        public List<String> InsertTableList { get; init; } = new List<string>();
        public List<String> UpdateTableList { get; init; } = new List<string>();
        public List<String> DeleteTableList { get; init; } = new List<string>();
    }
}
