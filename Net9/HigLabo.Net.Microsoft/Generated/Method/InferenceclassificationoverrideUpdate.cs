using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/inferenceclassificationoverride-update?view=graph-rest-1.0
/// </summary>
public partial class InferenceClassificationOverrideUpdateParameter : IRestApiParameter
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

    public enum InferenceClassificationOverrideUpdateParameterstring
    {
        Focused,
        Other,
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
    string IRestApiParameter.HttpMethod { get; } = "PATCH";
    public InferenceClassificationOverrideUpdateParameterstring ClassifyAs { get; set; }
}
public partial class InferenceClassificationOverrideUpdateResponse : RestApiResponse
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
/// https://learn.microsoft.com/en-us/graph/api/inferenceclassificationoverride-update?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/inferenceclassificationoverride-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<InferenceClassificationOverrideUpdateResponse> InferenceClassificationOverrideUpdateAsync()
    {
        var p = new InferenceClassificationOverrideUpdateParameter();
        return await this.SendAsync<InferenceClassificationOverrideUpdateParameter, InferenceClassificationOverrideUpdateResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/inferenceclassificationoverride-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<InferenceClassificationOverrideUpdateResponse> InferenceClassificationOverrideUpdateAsync(CancellationToken cancellationToken)
    {
        var p = new InferenceClassificationOverrideUpdateParameter();
        return await this.SendAsync<InferenceClassificationOverrideUpdateParameter, InferenceClassificationOverrideUpdateResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/inferenceclassificationoverride-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<InferenceClassificationOverrideUpdateResponse> InferenceClassificationOverrideUpdateAsync(InferenceClassificationOverrideUpdateParameter parameter)
    {
        return await this.SendAsync<InferenceClassificationOverrideUpdateParameter, InferenceClassificationOverrideUpdateResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/inferenceclassificationoverride-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<InferenceClassificationOverrideUpdateResponse> InferenceClassificationOverrideUpdateAsync(InferenceClassificationOverrideUpdateParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<InferenceClassificationOverrideUpdateParameter, InferenceClassificationOverrideUpdateResponse>(parameter, cancellationToken);
    }
}
