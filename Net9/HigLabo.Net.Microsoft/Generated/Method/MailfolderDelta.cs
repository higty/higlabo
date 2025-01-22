using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/mailfolder-delta?view=graph-rest-1.0
/// </summary>
public partial class MailFolderDeltaParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Me_MailFolders_Delta: return $"/me/mailFolders/delta";
                case ApiPath.Users_Id_MailFolders_Delta: return $"/users/{Id}/mailFolders/delta";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Me_MailFolders_Delta,
        Users_Id_MailFolders_Delta,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "GET";
    public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
    IQueryParameter IQueryParameterProperty.Query
    {
        get
        {
            return this.Query;
        }
    }
}
public partial class MailFolderDeltaResponse : RestApiResponse<MailFolder>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/mailfolder-delta?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/mailfolder-delta?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<MailFolderDeltaResponse> MailFolderDeltaAsync()
    {
        var p = new MailFolderDeltaParameter();
        return await this.SendAsync<MailFolderDeltaParameter, MailFolderDeltaResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/mailfolder-delta?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<MailFolderDeltaResponse> MailFolderDeltaAsync(CancellationToken cancellationToken)
    {
        var p = new MailFolderDeltaParameter();
        return await this.SendAsync<MailFolderDeltaParameter, MailFolderDeltaResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/mailfolder-delta?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<MailFolderDeltaResponse> MailFolderDeltaAsync(MailFolderDeltaParameter parameter)
    {
        return await this.SendAsync<MailFolderDeltaParameter, MailFolderDeltaResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/mailfolder-delta?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<MailFolderDeltaResponse> MailFolderDeltaAsync(MailFolderDeltaParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<MailFolderDeltaParameter, MailFolderDeltaResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/mailfolder-delta?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<MailFolder> MailFolderDeltaEnumerateAsync(MailFolderDeltaParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<MailFolderDeltaParameter, MailFolderDeltaResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<MailFolder>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
