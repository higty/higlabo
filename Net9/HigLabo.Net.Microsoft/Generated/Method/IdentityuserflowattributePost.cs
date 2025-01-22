using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/identityuserflowattribute-post?view=graph-rest-1.0
/// </summary>
public partial class IdentityUserflowAttributePostParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Identity_UserFlowAttributes: return $"/identity/userFlowAttributes";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum IdentityUserFlowAttributeIdentityUserFlowAttributeDataType
    {
        String,
        Boolean,
        Int64,
        StringCollection,
        DateTime,
    }
    public enum IdentityUserFlowAttributeIdentityUserFlowAttributeType
    {
        BuiltIn,
        Custom,
        Required,
    }
    public enum ApiPath
    {
        Identity_UserFlowAttributes,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "POST";
    public string? Id { get; set; }
    public string? DisplayName { get; set; }
    public string? Description { get; set; }
    public string? UserFlowAttributeType { get; set; }
    public string? DataType { get; set; }
}
public partial class IdentityUserflowAttributePostResponse : RestApiResponse
{
    public enum IdentityUserFlowAttributeIdentityUserFlowAttributeDataType
    {
        String,
        Boolean,
        Int64,
        StringCollection,
        DateTime,
    }
    public enum IdentityUserFlowAttributeIdentityUserFlowAttributeType
    {
        BuiltIn,
        Custom,
        Required,
    }

    public IdentityUserFlowAttributeIdentityUserFlowAttributeDataType DataType { get; set; }
    public string? Description { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public IdentityUserFlowAttributeIdentityUserFlowAttributeType UserFlowAttributeType { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/identityuserflowattribute-post?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityuserflowattribute-post?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<IdentityUserflowAttributePostResponse> IdentityUserflowAttributePostAsync()
    {
        var p = new IdentityUserflowAttributePostParameter();
        return await this.SendAsync<IdentityUserflowAttributePostParameter, IdentityUserflowAttributePostResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityuserflowattribute-post?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<IdentityUserflowAttributePostResponse> IdentityUserflowAttributePostAsync(CancellationToken cancellationToken)
    {
        var p = new IdentityUserflowAttributePostParameter();
        return await this.SendAsync<IdentityUserflowAttributePostParameter, IdentityUserflowAttributePostResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityuserflowattribute-post?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<IdentityUserflowAttributePostResponse> IdentityUserflowAttributePostAsync(IdentityUserflowAttributePostParameter parameter)
    {
        return await this.SendAsync<IdentityUserflowAttributePostParameter, IdentityUserflowAttributePostResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityuserflowattribute-post?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<IdentityUserflowAttributePostResponse> IdentityUserflowAttributePostAsync(IdentityUserflowAttributePostParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<IdentityUserflowAttributePostParameter, IdentityUserflowAttributePostResponse>(parameter, cancellationToken);
    }
}
