using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/subjectrightsrequest-list?view=graph-rest-1.0
    /// </summary>
    public partial class SubjectrightsrequestListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Privacy_SubjectRightsRequests: return $"/privacy/subjectRightsRequests";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            AssignedTo,
            ClosedDateTime,
            CreatedBy,
            CreatedDateTime,
            DataSubject,
            DataSubjectType,
            Description,
            DisplayName,
            History,
            Insight,
            InternalDueDateTime,
            LastModifiedBy,
            LastModifiedDateTime,
            Regulations,
            Stages,
            Status,
            Type,
            Notes,
            Team,
        }
        public enum ApiPath
        {
            Privacy_SubjectRightsRequests,
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
    public partial class SubjectrightsrequestListResponse : RestApiResponse
    {
        public SubjectRightsRequest[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/subjectrightsrequest-list?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/subjectrightsrequest-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SubjectrightsrequestListResponse> SubjectrightsrequestListAsync()
        {
            var p = new SubjectrightsrequestListParameter();
            return await this.SendAsync<SubjectrightsrequestListParameter, SubjectrightsrequestListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/subjectrightsrequest-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SubjectrightsrequestListResponse> SubjectrightsrequestListAsync(CancellationToken cancellationToken)
        {
            var p = new SubjectrightsrequestListParameter();
            return await this.SendAsync<SubjectrightsrequestListParameter, SubjectrightsrequestListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/subjectrightsrequest-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SubjectrightsrequestListResponse> SubjectrightsrequestListAsync(SubjectrightsrequestListParameter parameter)
        {
            return await this.SendAsync<SubjectrightsrequestListParameter, SubjectrightsrequestListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/subjectrightsrequest-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SubjectrightsrequestListResponse> SubjectrightsrequestListAsync(SubjectrightsrequestListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SubjectrightsrequestListParameter, SubjectrightsrequestListResponse>(parameter, cancellationToken);
        }
    }
}
