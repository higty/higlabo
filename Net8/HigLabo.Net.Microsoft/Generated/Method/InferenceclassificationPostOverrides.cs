using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/inferenceclassification-post-overrides?view=graph-rest-1.0
/// </summary>
public partial class InferenceClassificationPostOverridesParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Me_InferenceClassification_Overrides: return $"/me/inferenceClassification/overrides";
                case ApiPath.Users_Id_InferenceClassification_Overrides: return $"/users/{Id}/inferenceClassification/overrides";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum InferenceClassificationOverrideInferenceClassificationType
    {
        Focused,
        Other,
    }
    public enum ApiPath
    {
        Me_InferenceClassification_Overrides,
        Users_Id_InferenceClassification_Overrides,
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
    public InferenceClassificationOverrideInferenceClassificationType ClassifyAs { get; set; }
    public string? Id { get; set; }
    public EmailAddress? SenderEmailAddress { get; set; }
}
public partial class InferenceClassificationPostOverridesResponse : RestApiResponse
{
    public enum InferenceClassificationOverrideInferenceClassificationType
    {
        Focused,
        Other,
    }

    public InferenceClassificationOverrideInferenceClassificationType ClassifyAs { get; set; }
    public string? Id { get; set; }
    public EmailAddress? SenderEmailAddress { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/inferenceclassification-post-overrides?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/inferenceclassification-post-overrides?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<InferenceClassificationPostOverridesResponse> InferenceClassificationPostOverridesAsync()
    {
        var p = new InferenceClassificationPostOverridesParameter();
        return await this.SendAsync<InferenceClassificationPostOverridesParameter, InferenceClassificationPostOverridesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/inferenceclassification-post-overrides?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<InferenceClassificationPostOverridesResponse> InferenceClassificationPostOverridesAsync(CancellationToken cancellationToken)
    {
        var p = new InferenceClassificationPostOverridesParameter();
        return await this.SendAsync<InferenceClassificationPostOverridesParameter, InferenceClassificationPostOverridesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/inferenceclassification-post-overrides?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<InferenceClassificationPostOverridesResponse> InferenceClassificationPostOverridesAsync(InferenceClassificationPostOverridesParameter parameter)
    {
        return await this.SendAsync<InferenceClassificationPostOverridesParameter, InferenceClassificationPostOverridesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/inferenceclassification-post-overrides?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<InferenceClassificationPostOverridesResponse> InferenceClassificationPostOverridesAsync(InferenceClassificationPostOverridesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<InferenceClassificationPostOverridesParameter, InferenceClassificationPostOverridesResponse>(parameter, cancellationToken);
    }
}
