using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HigLabo.OpenAI.BatchObject;

namespace HigLabo.OpenAI
{
    public class BatchObject
    {
        public string Id { get; set; } = "";
        public string Object { get; set; } = "";
        public string Endpoint { get; set; } = "";
        public Error? Errors { get; set; }
        public string Input_File_Id { get; set; } = "";
        public string Completion_Window { get; set; } = "";
        public string Status { get; set; } = "";
        public string Output_File_Id { get; set; } = "";
        public string Error_File_Id { get; set; } = "";
        public Int64? Created_At { get; set; }
        public DateTimeOffset? CreateTime
        {
            get
            {
                if (this.Created_At == null) { return null; }
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Created_At.Value), TimeSpan.Zero);
            }
        }
        public Int64? In_Progress_At { get; set; }
        public DateTimeOffset? InProgressTime
        {
            get
            {
                if (this.In_Progress_At == null) { return null; }
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.In_Progress_At.Value), TimeSpan.Zero);
            }
        }
        public Int64? Expires_At { get; set; }
        public DateTimeOffset? ExpiresTime
        {
            get
            {
                if (this.Expires_At == null) { return null; }
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Expires_At.Value), TimeSpan.Zero);
            }
        }
        public Int64? Finalizing_At { get; set; }
        public DateTimeOffset? FinalizingTime
        {
            get
            {
                if (this.Finalizing_At == null) { return null; }
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Finalizing_At.Value), TimeSpan.Zero);
            }
        }
        public Int64? Completed_At { get; set; }
        public DateTimeOffset? CompleteTime
        {
            get
            {
                if (this.Completed_At == null) { return null; }
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Completed_At.Value), TimeSpan.Zero);
            }
        }
        public Int64? Failed_At { get; set; }
        public DateTimeOffset? FailedTime
        {
            get
            {
                if (this.Failed_At == null) { return null; }
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Failed_At.Value), TimeSpan.Zero);
            }
        }
        public Int64? Expired_At { get; set; }
        public DateTimeOffset? ExpiredTime
        {
            get
            {
                if (this.Expired_At == null) { return null; }
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Expired_At.Value), TimeSpan.Zero);
            }
        }
        public Int64? Cancelling_At { get; set; }
        public DateTimeOffset? CancellingTime
        {
            get
            {
                if (this.Cancelling_At == null) { return null; }
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Cancelling_At.Value), TimeSpan.Zero);
            }
        }
        public Int64? Cancelled_At { get; set; }
        public DateTimeOffset? CancelledTime
        {
            get
            {
                if (this.Cancelled_At == null) { return null; }
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Cancelled_At.Value), TimeSpan.Zero);
            }
        }
        public RequestCount Request_Counts { get; set; } = new();

        public class Error
        {
            public string Object { get; set; } = "";
            public List<ErrorData> Data { get; set; } = new();
        }
        public class ErrorData
        {
            public string Code { get; set; } = "";
            public string Message { get; set; } = "";
            public string? Param { get; set; }
            public int? Line { get; set; }
        }
        public class RequestCount
        {
            public int Total { get; set; }
            public int Completed { get; set; }
            public int Failed { get; set; }
        }

        public override string ToString()
        {
            return $"{this.Id}";
        }
    }
    public class BatchObjectResponse: RestApiResponse
    {
        public string Id { get; set; } = "";
        public string Object { get; set; } = "";
        public string Endpoint { get; set; } = "";
        public Error? Errors { get; set; }
        public string Input_File_Id { get; set; } = "";
        public string Completion_Window { get; set; } = "";
        public string Status { get; set; } = "";
        public string Output_File_Id { get; set; } = "";
        public string Error_File_Id { get; set; } = "";
        public Int64? Created_At { get; set; }
        public DateTimeOffset? CreateTime
        {
            get
            {
                if (this.Created_At == null) { return null; }
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Created_At.Value), TimeSpan.Zero);
            }
        }
        public Int64? In_Progress_At { get; set; }
        public DateTimeOffset? InProgressTime
        {
            get
            {
                if (this.In_Progress_At == null) { return null; }
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.In_Progress_At.Value), TimeSpan.Zero);
            }
        }
        public Int64? Expires_At { get; set; }
        public DateTimeOffset? ExpiresTime
        {
            get
            {
                if (this.Expires_At == null) { return null; }
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Expires_At.Value), TimeSpan.Zero);
            }
        }
        public Int64? Finalizing_At { get; set; }
        public DateTimeOffset? FinalizingTime
        {
            get
            {
                if (this.Finalizing_At == null) { return null; }
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Finalizing_At.Value), TimeSpan.Zero);
            }
        }
        public Int64? Completed_At { get; set; }
        public DateTimeOffset? CompleteTime
        {
            get
            {
                if (this.Completed_At == null) { return null; }
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Completed_At.Value), TimeSpan.Zero);
            }
        }
        public Int64? Failed_At { get; set; }
        public DateTimeOffset? FailedTime
        {
            get
            {
                if (this.Failed_At == null) { return null; }
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Failed_At.Value), TimeSpan.Zero);
            }
        }
        public Int64? Expired_At { get; set; }
        public DateTimeOffset? ExpiredTime
        {
            get
            {
                if (this.Expired_At == null) { return null; }
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Expired_At.Value), TimeSpan.Zero);
            }
        }
        public Int64? Cancelling_At { get; set; }
        public DateTimeOffset? CancellingTime
        {
            get
            {
                if (this.Cancelling_At == null) { return null; }
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Cancelling_At.Value), TimeSpan.Zero);
            }
        }
        public Int64? Cancelled_At { get; set; }
        public DateTimeOffset? CancelledTime
        {
            get
            {
                if (this.Cancelled_At == null) { return null; }
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Cancelled_At.Value), TimeSpan.Zero);
            }
        }
        public RequestCount Request_Counts { get; set; } = new();

        public override string ToString()
        {
            return $"{this.Id}";
        }
    }
}
