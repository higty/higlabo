namespace HigLabo.OpenAI
{
    public class UploadObject
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
        public string FileName { get; set; } = "";
        public int Bites { get; set; } 
        public string Purpose { get; set; } = "";
        public string Status { get; set; } = "";
        public Int64 Expires_At { get; set; }
        public DateTimeOffset ExpireTime
        {
            get
            {
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Expires_At), TimeSpan.Zero);
            }
        }
        public FileObject? File { get; set; }
    }
    public class UploadObjectResponse : RestApiResponse
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
        public string FileName { get; set; } = "";
        public int Bites { get; set; } 
        public string Purpose { get; set; } = "";
        public string Status { get; set; } = "";
        public Int64 Expires_At { get; set; }
        public DateTimeOffset ExpireTime
        {
            get
            {
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Expires_At), TimeSpan.Zero);
            }
        }
        public FileObject? File { get; set; }
    }
}
