namespace HigLabo.OpenAI;
public class CertificateObject
{
    public class CertificateDetail
    {
        public string Content { get; set; } = "";
        public Int64 Expiresd { get; set; }
        public DateTimeOffset ExpiresTime
        {
            get
            {
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Expiresd), TimeSpan.Zero);
            }
        }
        public Int64 ValidAt { get; set; }
        public DateTimeOffset ValidTime
        {
            get
            {
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.ValidAt), TimeSpan.Zero);
            }
        }
    }
    public string Id { get; set; } = "";
    public string Object { get; set; } = "";
    public string Name { get; set; } = "";
    public bool Active { get; set; }
    public Int64 Created { get; set; }
    public DateTimeOffset CreateTime
    {
        get
        {
            return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Created), TimeSpan.Zero);
        }
    }

}
public class CertificateObjectResponse: RestApiResponse
{
    public class CertificateDetail
    {
        public string Content { get; set; } = "";
        public Int64 Expiresd { get; set; }
        public DateTimeOffset ExpiresTime
        {
            get
            {
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Expiresd), TimeSpan.Zero);
            }
        }
        public Int64 ValidAt { get; set; }
        public DateTimeOffset ValidTime
        {
            get
            {
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.ValidAt), TimeSpan.Zero);
            }
        }
    }
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public bool Active { get; set; }
    public Int64 Created { get; set; }
    public DateTimeOffset CreateTime
    {
        get
        {
            return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Created), TimeSpan.Zero);
        }
    }

}
