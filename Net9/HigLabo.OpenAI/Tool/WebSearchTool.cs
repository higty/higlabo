namespace HigLabo.OpenAI;
public class WebSearchTool : Tool
{
    public class UserLocation
    {
        public string Type { get; set; } = "";
        public string Country { get; set; } = "";
        public string City { get; set; } = "";
        public string Region { get; set; } = "";
    }
    public UserLocation? User_Location { get; set; }

    public WebSearchTool()
        : base("web_search")
    {
    }
}
