using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationassignmentdefaultsGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Education_Classes_Id_AssignmentDefaults,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Education_Classes_Id_AssignmentDefaults: return $"/education/classes/{Id}/assignmentDefaults";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
        public string Id { get; set; }
    }
    public partial class EducationassignmentdefaultsGetResponse : RestApiResponse
    {
        public enum EducationAssignmentDefaultsEducationAddedStudentAction
        {
            None,
            AssignIfOpen,
        }
        public enum EducationAssignmentDefaultsEducationAddToCalendarOptions
        {
            None,
            StudentsAndPublisher,
            StudentsAndTeamOwners,
            UnknownFutureValue,
            StudentsOnly,
        }

        public string? Id { get; set; }
        public EducationAssignmentDefaultsEducationAddedStudentAction AddedStudentAction { get; set; }
        public EducationAssignmentDefaultsEducationAddToCalendarOptions AddToCalendarAction { get; set; }
        public TimeOnly? DueTime { get; set; }
        public string? NotificationChannelUrl { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignmentdefaults-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentdefaultsGetResponse> EducationassignmentdefaultsGetAsync()
        {
            var p = new EducationassignmentdefaultsGetParameter();
            return await this.SendAsync<EducationassignmentdefaultsGetParameter, EducationassignmentdefaultsGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignmentdefaults-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentdefaultsGetResponse> EducationassignmentdefaultsGetAsync(CancellationToken cancellationToken)
        {
            var p = new EducationassignmentdefaultsGetParameter();
            return await this.SendAsync<EducationassignmentdefaultsGetParameter, EducationassignmentdefaultsGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignmentdefaults-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentdefaultsGetResponse> EducationassignmentdefaultsGetAsync(EducationassignmentdefaultsGetParameter parameter)
        {
            return await this.SendAsync<EducationassignmentdefaultsGetParameter, EducationassignmentdefaultsGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignmentdefaults-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentdefaultsGetResponse> EducationassignmentdefaultsGetAsync(EducationassignmentdefaultsGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationassignmentdefaultsGetParameter, EducationassignmentdefaultsGetResponse>(parameter, cancellationToken);
        }
    }
}
