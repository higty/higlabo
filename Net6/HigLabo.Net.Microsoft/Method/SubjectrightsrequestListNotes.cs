using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SubjectrightsrequestListNotesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? SubjectRightsRequestId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Privacy_SubjectRightsRequests_SubjectRightsRequestId_Notes: return $"/privacy/subjectRightsRequests/{SubjectRightsRequestId}/notes";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Privacy_SubjectRightsRequests_SubjectRightsRequestId_Notes,
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
    public partial class SubjectrightsrequestListNotesResponse : RestApiResponse
    {
        public AuthoredNote[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/subjectrightsrequest-list-notes?view=graph-rest-1.0
        /// </summary>
        public async Task<SubjectrightsrequestListNotesResponse> SubjectrightsrequestListNotesAsync()
        {
            var p = new SubjectrightsrequestListNotesParameter();
            return await this.SendAsync<SubjectrightsrequestListNotesParameter, SubjectrightsrequestListNotesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/subjectrightsrequest-list-notes?view=graph-rest-1.0
        /// </summary>
        public async Task<SubjectrightsrequestListNotesResponse> SubjectrightsrequestListNotesAsync(CancellationToken cancellationToken)
        {
            var p = new SubjectrightsrequestListNotesParameter();
            return await this.SendAsync<SubjectrightsrequestListNotesParameter, SubjectrightsrequestListNotesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/subjectrightsrequest-list-notes?view=graph-rest-1.0
        /// </summary>
        public async Task<SubjectrightsrequestListNotesResponse> SubjectrightsrequestListNotesAsync(SubjectrightsrequestListNotesParameter parameter)
        {
            return await this.SendAsync<SubjectrightsrequestListNotesParameter, SubjectrightsrequestListNotesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/subjectrightsrequest-list-notes?view=graph-rest-1.0
        /// </summary>
        public async Task<SubjectrightsrequestListNotesResponse> SubjectrightsrequestListNotesAsync(SubjectrightsrequestListNotesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SubjectrightsrequestListNotesParameter, SubjectrightsrequestListNotesResponse>(parameter, cancellationToken);
        }
    }
}
