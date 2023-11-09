using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    public class RunObject
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
        public string Thread_Id { get; set; } = "";
        public string Status { get; set; } = "";
        public object? Required_Action { get; set; }
        public object? Last_Error { get; set; }
        public Int64 Expires_At { get; set; }
        public DateTimeOffset ExpireTime
        {
            get
            {
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Expires_At), TimeSpan.Zero);
            }
        }
        public Int64 Started_At { get; set; }
        public DateTimeOffset StartTime
        {
            get
            {
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Started_At), TimeSpan.Zero);
            }
        }
        public Int64 Cancelled_At { get; set; }
        public DateTimeOffset CancelTime
        {
            get
            {
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Cancelled_At), TimeSpan.Zero);
            }
        }
        public Int64 Failed_At { get; set; }
        public DateTimeOffset FailTime
        {
            get
            {
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Failed_At), TimeSpan.Zero);
            }
        }
        public Int64 Completed_At { get; set; }
        public DateTimeOffset CompleteTime
        {
            get
            {
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Completed_At), TimeSpan.Zero);
            }
        }
        public string Model { get; set; } = "";
        public string Instructions { get; set; } = "";
        public List<ToolObject> Tools { get; set; } = new();
        public List<string>? File_Ids { get; set; }
        public string MetaData { get; set; } = "";
    }
    public class RunObjectResponse: RestApiResponse
    {
        public string Id { get; set; } = "";
        public Int64 Created_At { get; set; }
        public DateTimeOffset CreateTime
        {
            get
            {
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Created_At), TimeSpan.Zero);
            }
        }
        public string Thread_Id { get; set; } = "";
        public string Status { get; set; } = "";
        public object? Required_Action { get; set; }
        public object? Last_Error { get; set; }
        public Int64 Expires_At { get; set; }
        public DateTimeOffset ExpireTime
        {
            get
            {
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Expires_At), TimeSpan.Zero);
            }
        }
        public Int64 Started_At { get; set; }
        public DateTimeOffset StartTime
        {
            get
            {
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Started_At), TimeSpan.Zero);
            }
        }
        public Int64 Cancelled_At { get; set; }
        public DateTimeOffset CancelTime
        {
            get
            {
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Cancelled_At), TimeSpan.Zero);
            }
        }
        public Int64 Failed_At { get; set; }
        public DateTimeOffset FailTime
        {
            get
            {
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Failed_At), TimeSpan.Zero);
            }
        }
        public Int64 Completed_At { get; set; }
        public DateTimeOffset CompleteTime
        {
            get
            {
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Completed_At), TimeSpan.Zero);
            }
        }
        public string Model { get; set; } = "";
        public string Instructions { get; set; } = "";
        public List<ToolObject> Tools { get; set; } = new();
        public List<string>? File_Ids { get; set; }
        public string MetaData { get; set; } = "";
    }
}
