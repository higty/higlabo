namespace HigLabo.OpenAI;
public class WebSearchTool : Tool
{
    public class UserLocation
    {
        public string Type { get; set; } = "";
        public string Country { get; set; } = "";
        public string City { get; set; } = "";
        public string Region { get; set; } = "";
        public string Timezone { get; set; } = "";
    }
    public class DomainFilters
    {
        public List<string> Allowed_Domains { get; init; } = new();
        public List<string> Blocked_Domains { get; init; } = new();
    }
    public class ImageSettings
    {
        public int? Max_Results { get; set; }
        public bool? Caption { get; set; }
    }
    public UserLocation? User_Location { get; set; }
    public DomainFilters? Filters { get; set; }
    public List<string>? Search_Content_Types { get; set; }
    public ImageSettings? Image_Settings { get; set; }

    public WebSearchTool()
        : base("web_search")
    {
    }
}
