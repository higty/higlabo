namespace HigLabo.X;

public class XSettings
{
    public string AccessToken { get; set; } = "";
    public string ApiUrl { get; set; } = "https://api.x.com/2";
    public string UserAgent { get; set; } = "";

    public XSettings() { }
    public XSettings(string accessToken)
    {
        this.AccessToken = accessToken;
    }
}
