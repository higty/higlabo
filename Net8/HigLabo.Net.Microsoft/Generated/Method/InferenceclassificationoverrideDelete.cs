using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/inferenceclassificationoverride-delete?view=graph-rest-1.0
/// </summary>
public partial class InferenceClassificationOverrideDeleteParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }
        public string? UsersId { get; set; }
        public string? OverridesId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Me_InferenceClassification_Overrides_Id: return $"/me/inferenceClassification/overrides/{Id}";
                case ApiPath.Users_Id_InferenceClassification_Overrides_Id: return $"/users/{UsersId}/inferenceClassification/overrides/{OverridesId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Me_InferenceClassification_Overrides_Id,
        Users_Id_InferenceClassification_Overrides_Id,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "DELETE";
}
public partial class InferenceClassificationOverrideDeleteResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/inferenceclassificationoverride-delete?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/inferenceclassificationoverride-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<InferenceClassificationOverrideDeleteResponse> InferenceClassificationOverrideDeleteAsync()
    {
        var p = new InferenceClassificationOverrideDeleteParameter();
        return await this.SendAsync<InferenceClassificationOverrideDeleteParameter, InferenceClassificationOverrideDeleteResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/inferenceclassificationoverride-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<InferenceClassificationOverrideDeleteResponse> InferenceClassificationOverrideDeleteAsync(CancellationToken cancellationToken)
    {
        var p = new InferenceClassificationOverrideDeleteParameter();
        return await this.SendAsync<InferenceClassificationOverrideDeleteParameter, InferenceClassificationOverrideDeleteResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/inferenceclassificationoverride-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<InferenceClassificationOverrideDeleteResponse> InferenceClassificationOverrideDeleteAsync(InferenceClassificationOverrideDeleteParameter parameter)
    {
        return await this.SendAsync<InferenceClassificationOverrideDeleteParameter, InferenceClassificationOverrideDeleteResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/inferenceclassificationoverride-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<InferenceClassificationOverrideDeleteResponse> InferenceClassificationOverrideDeleteAsync(InferenceClassificationOverrideDeleteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<InferenceClassificationOverrideDeleteParameter, InferenceClassificationOverrideDeleteResponse>(parameter, cancellationToken);
    }
}
