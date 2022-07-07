using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationschoolListClassesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Education_Schools_EducationSchoolId_Classes,
            Ttps__Graphmicrosoftcom_V10_Groups,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Education_Schools_EducationSchoolId_Classes: return $"/education/schools/{EducationSchoolId}/classes";
                    case ApiPath.Ttps__Graphmicrosoftcom_V10_Groups: return $"/ttps://graph.microsoft.com/v1.0/groups";
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
        public string EducationSchoolId { get; set; }
    }
    public partial class EducationschoolListClassesResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/educationclass?view=graph-rest-1.0
        /// </summary>
        public partial class EducationClass
        {
            public enum EducationClassEducationExternalSource
            {
                Sis,
                Manual,
            }

            public string? Id { get; set; }
            public string? DisplayName { get; set; }
            public string? MailNickname { get; set; }
            public string? Description { get; set; }
            public IdentitySet? CreatedBy { get; set; }
            public string? ClassCode { get; set; }
            public string? ExternalName { get; set; }
            public string? ExternalId { get; set; }
            public EducationClassEducationExternalSource ExternalSource { get; set; }
            public string? ExternalSourceDetail { get; set; }
            public string? Grade { get; set; }
            public EducationTerm? Term { get; set; }
        }

        public EducationClass[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationschool-list-classes?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationschoolListClassesResponse> EducationschoolListClassesAsync()
        {
            var p = new EducationschoolListClassesParameter();
            return await this.SendAsync<EducationschoolListClassesParameter, EducationschoolListClassesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationschool-list-classes?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationschoolListClassesResponse> EducationschoolListClassesAsync(CancellationToken cancellationToken)
        {
            var p = new EducationschoolListClassesParameter();
            return await this.SendAsync<EducationschoolListClassesParameter, EducationschoolListClassesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationschool-list-classes?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationschoolListClassesResponse> EducationschoolListClassesAsync(EducationschoolListClassesParameter parameter)
        {
            return await this.SendAsync<EducationschoolListClassesParameter, EducationschoolListClassesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationschool-list-classes?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationschoolListClassesResponse> EducationschoolListClassesAsync(EducationschoolListClassesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationschoolListClassesParameter, EducationschoolListClassesResponse>(parameter, cancellationToken);
        }
    }
}
