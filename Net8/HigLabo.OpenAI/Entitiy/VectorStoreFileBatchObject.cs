using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI;

public class VectorStoreFileBatchObject
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
    public FileCount FileCounts { get; set; } = new();

    public class FileCount
    {
        public int In_Progress { get; set; }
        public int Completed { get; set; }
        public int Failed { get; set; }
        public int Cancelled { get; set; }
        public int Total { get; set; }
    }
}
public class VectorStoreFileBatchObjectResponse: RestApiResponse
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
    public FileCount FileCounts { get; set; } = new();

    public class FileCount
    {
        public int In_Progress { get; set; }
        public int Completed { get; set; }
        public int Failed { get; set; }
        public int Cancelled { get; set; }
        public int Total { get; set; }
    }
}
