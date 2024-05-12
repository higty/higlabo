using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    public class VectorStoreFileObject
    {
        public string Id { get; set; } = "";
        public string Object { get; set; } = "";
        public Int64 Created_At { get; set; }
        public DateTimeOffset CreateTime
        {
            get
            {
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Created_At), TimeSpan.Zero);
            }
        }
        public string Vector_Store_Id { get; set; } = "";
        public string Status { get; set; } = "";
        public Error? Last_Error { get; set; }

        public class Error
        {
            public string Code { get; set; } = "";
            public string Message { get; set; } = "";
        }
    }
    public class VectorStoreFileObjectResponse : RestApiResponse
    {
        public string Id { get; set; } = "";
        public new string Object { get; set; } = "";
        public Int64 Created_At { get; set; }
        public DateTimeOffset CreateTime
        {
            get
            {
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Created_At), TimeSpan.Zero);
            }
        }
        public string Vector_Store_Id { get; set; } = "";
        public string Status { get; set; } = "";
        public Error? Last_Error { get; set; }

        public class Error
        {
            public string Code { get; set; } = "";
            public string Message { get; set; } = "";
        }
    }
}
