using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    public class ModelObject
    {
        public string Id { get; set; } = "";
        public string Object { get; set; } = "";
        public Int64 Created { get; set; }
        public DateTimeOffset CreateTime
        {
            get
            {
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Created), TimeSpan.Zero);
            }
        }
        public string Owned_By { get; set; } = "";

        public override string ToString()
        {
            return $"{this.Id}";
        }
    }
    public class ModelObjectResponse : RestApiResponse
    {
        public string Id { get; set; } = "";
        public Int64 Created { get; set; }
        public DateTimeOffset CreateTime
        {
            get
            {
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Created), TimeSpan.Zero);
            }
        }
        public string Owned_By { get; set; } = "";

        public override string ToString()
        {
            return $"{this.Id}";
        }
    }
}
