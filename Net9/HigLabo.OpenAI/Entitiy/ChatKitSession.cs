using static HigLabo.OpenAI.ChatKitSessionObject;

namespace HigLabo.OpenAI;
public class ChatKitSessionObject
{
    public class ChatkitConfiguration
    {
        public AutomaticThreadTitling Automatic_Thread_Titling { get; set; } = new AutomaticThreadTitling();
        public FileUpload File_Upload { get;set; } = new FileUpload();
        public History History { get; set; } = new History();
    }
    public class AutomaticThreadTitling
    {
        public bool Enabled { get; set; }
    }
    public class FileUpload
    {
        public bool Enabled { get; set; }
        public int Max_File_Size { get; set; }
        public int MaxFiles { get; set; }
    }
    public class History
    {
        public bool Enabled { get; set; }
        public int Recent_Threads { get; set; }
    }
    public string Id { get; set; } = "";
    public string Object { get; set; } = "";
    public string Client_Secret { get; set; } = "";
    public ChatKitWorkflow Workflow { get; set; } = new ChatKitWorkflow();
    public string User { get; set; } = "";
    public ChatKitRateLimits Rate_Limits { get; set; } = new ();
    public int Max_Requests_Per_1_Minute { get; set; }
    public string Status { get; set; } = "";
    public Int64 Expires_At { get; set; }
    public DateTimeOffset ExpireTime
    {
        get
        {
            return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Expires_At), TimeSpan.Zero);
        }
    }
    public ChatkitConfiguration ChatKit_Configuration { get; set; } = new ChatkitConfiguration();
}
public class ChatKitSessionResponse : RestApiResponse
{
    public string Id { get; set; } = "";
    public string Client_Secret { get; set; } = "";
    public Int64 Expires_At { get; set; }
    public ChatKitWorkflow Workflow { get; set; } = new ChatKitWorkflow();
    public string User { get; set; } = "";
    public ChatKitRateLimits Rate_Limits { get; set; } = new();
    public int Max_Requests_Per_1_Minute { get; set; }
    public string Status { get; set; } = "";
    public DateTimeOffset ExpireTime
    {
        get
        {
            return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Expires_At), TimeSpan.Zero);
        }
    }
    public ChatkitConfiguration ChatKit_Configuration { get; set; } = new ChatkitConfiguration();
}