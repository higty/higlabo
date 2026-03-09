using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public partial class UsersMeParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
{
    internal static readonly UsersMeParameter Empty = new UsersMeParameter();

    string IRestApiParameter.HttpMethod { get; } = "GET";

    public List<UserField> UserFieldList { get; init; } = new();
    public string User_Fields { get; set; } = "";
    public string Expansions { get; set; } = "";
    public List<TweetField> TweetFieldList { get; init; } = new();
    public string Tweet_Fields { get; set; } = "";

    string IRestApiParameter.GetApiPath()
    {
        return "/users/me";
    }
    Dictionary<string, string> IQueryParameterProperty.CreateQueryParameter()
    {
        var d = new Dictionary<string, string>();
        QueryParameterBuilder.AddField(d, "user.fields", this.UserFieldList, this.User_Fields);
        QueryParameterBuilder.Add(d, "expansions", this.Expansions);
        QueryParameterBuilder.AddField(d, "tweet.fields", this.TweetFieldList, this.Tweet_Fields);
        return d;
    }
    public override object GetRequestBody()
    {
        return EmptyParameter;
    }
}
public partial class UsersMeResponse : XApiResult<XUser>
{
}
public partial class XClient
{
    public async ValueTask<UsersMeResponse> UsersMeAsync()
    {
        return await this.SendJsonAsync<UsersMeParameter, UsersMeResponse>(UsersMeParameter.Empty);
    }
    public async ValueTask<UsersMeResponse> UsersMeAsync(CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<UsersMeParameter, UsersMeResponse>(UsersMeParameter.Empty, cancellationToken);
    }
    public async ValueTask<UsersMeResponse> UsersMeAsync(UsersMeParameter parameter)
    {
        return await this.SendJsonAsync<UsersMeParameter, UsersMeResponse>(parameter);
    }
    public async ValueTask<UsersMeResponse> UsersMeAsync(UsersMeParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<UsersMeParameter, UsersMeResponse>(parameter, cancellationToken);
    }
}
