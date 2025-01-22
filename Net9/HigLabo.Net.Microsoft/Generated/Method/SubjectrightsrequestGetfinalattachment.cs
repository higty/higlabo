using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/subjectrightsrequest-getfinalattachment?view=graph-rest-1.0
/// </summary>
public partial class SubjectrightsRequestGetfinalattachmentParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? SubjectRightsRequestId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Privacy_SubjectRightsRequests_SubjectRightsRequestId_GetFinalAttachment: return $"/privacy/subjectRightsRequests/{SubjectRightsRequestId}/getFinalAttachment";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Privacy_SubjectRightsRequests_SubjectRightsRequestId_GetFinalAttachment,
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
public partial class SubjectrightsRequestGetfinalattachmentResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/subjectrightsrequest-getfinalattachment?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/subjectrightsrequest-getfinalattachment?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SubjectrightsRequestGetfinalattachmentResponse> SubjectrightsRequestGetfinalattachmentAsync()
    {
        var p = new SubjectrightsRequestGetfinalattachmentParameter();
        return await this.SendAsync<SubjectrightsRequestGetfinalattachmentParameter, SubjectrightsRequestGetfinalattachmentResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/subjectrightsrequest-getfinalattachment?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SubjectrightsRequestGetfinalattachmentResponse> SubjectrightsRequestGetfinalattachmentAsync(CancellationToken cancellationToken)
    {
        var p = new SubjectrightsRequestGetfinalattachmentParameter();
        return await this.SendAsync<SubjectrightsRequestGetfinalattachmentParameter, SubjectrightsRequestGetfinalattachmentResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/subjectrightsrequest-getfinalattachment?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SubjectrightsRequestGetfinalattachmentResponse> SubjectrightsRequestGetfinalattachmentAsync(SubjectrightsRequestGetfinalattachmentParameter parameter)
    {
        return await this.SendAsync<SubjectrightsRequestGetfinalattachmentParameter, SubjectrightsRequestGetfinalattachmentResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/subjectrightsrequest-getfinalattachment?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SubjectrightsRequestGetfinalattachmentResponse> SubjectrightsRequestGetfinalattachmentAsync(SubjectrightsRequestGetfinalattachmentParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<SubjectrightsRequestGetfinalattachmentParameter, SubjectrightsRequestGetfinalattachmentResponse>(parameter, cancellationToken);
    }
}
