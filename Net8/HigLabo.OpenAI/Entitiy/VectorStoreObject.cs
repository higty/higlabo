using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI;

public class VectorStoreObject
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
    public string Name { get; set; } = "";
    public int Bytes { get; set; }
    public FileCount FileCounts { get; set; } = new();
    public string Status { get; set; } = "";
    public ExpirationPolicy Expires_After { get; set; } = new();
    public Int64? Expires_At { get; set; }
    public DateTimeOffset? ExpiredTime
    {
        get
        {
            if (this.Expires_At == null) { return null; }
            return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Expires_At.Value), TimeSpan.Zero);
        }
    }
    public Int64? Last_Active_At { get; set; }
    public DateTimeOffset? LastActiveTime
    {
        get
        {
            if (this.Last_Active_At == null) { return null; }
            return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Last_Active_At.Value), TimeSpan.Zero);
        }
    }
    public object? MetaData { get; set; }

    public class FileCount
    {
        public int In_Progress { get; set; }
        public int Completed { get; set; }
        public int Failed { get; set; }
        public int Cancelled { get; set; }
        public int Total { get; set; }
    }
    public class ExpirationPolicy
    {
        public string Anchor { get; set; } = "";
        public int Days { get; set; }
    }
}
public class VectorStoreObjectResponse : RestApiResponse
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
    public string Name { get; set; } = "";
    public int Bytes { get; set; }
    public FileCount FileCounts { get; set; } = new();
    public string Status { get; set; } = "";
    public ExpirationPolicy Expires_After { get; set; } = new();
    public Int64? Expires_At { get; set; }
    public DateTimeOffset? ExpiredTime
    {
        get
        {
            if (this.Expires_At == null) { return null; }
            return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Expires_At.Value), TimeSpan.Zero);
        }
    }
    public Int64? Last_Active_At { get; set; }
    public DateTimeOffset? LastActiveTime
    {
        get
        {
            if (this.Last_Active_At == null) { return null; }
            return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Last_Active_At.Value), TimeSpan.Zero);
        }
    }
    public object? MetaData { get; set; }

    public class FileCount
    {
        public int In_Progress { get; set; }
        public int Completed { get; set; }
        public int Failed { get; set; }
        public int Cancelled { get; set; }
        public int Total { get; set; }
    }
    public class ExpirationPolicy
    {
        public string Anchor { get; set; } = "";
        public int Days { get; set; }
    }
}