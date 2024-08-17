namespace HigLabo.OpenAI
{
    public class ProjectObject
    {
        public string Id { get; set; } = "";
        public string Object { get; set; } = "";
        public string Name { get; set; } = "";
        public Int64 Created_At { get; set; }
        public DateTimeOffset CreateTime
        {
            get
            {
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Created_At), TimeSpan.Zero);
            }
        }
        public Int64 Archived_At { get; set; }
        public DateTimeOffset ArchiveTime
        {
            get
            {
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Archived_At), TimeSpan.Zero);
            }
        }
        public string Status { get; set; } = "";
    }
    public class ProjectObjectResponse : RestApiResponse
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public Int64 Created_At { get; set; }
        public DateTimeOffset CreateTime
        {
            get
            {
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Created_At), TimeSpan.Zero);
            }
        }
        public Int64 Archived_At { get; set; }
        public DateTimeOffset ArchiveTime
        {
            get
            {
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Archived_At), TimeSpan.Zero);
            }
        }
        public string Status { get; set; } = "";
    }
}
