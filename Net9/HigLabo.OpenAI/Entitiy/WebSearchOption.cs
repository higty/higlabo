namespace HigLabo.OpenAI;
public class WebSearchOption
{
    public class UserLocation
    {
        public string Approximate { get; set; } = "";
        public string Type { get; set; } = "";
    }
    public string? Search_Context_Size { get; set; }
    public UserLocation? User_Location { get; set; }
}
