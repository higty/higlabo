using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationuserListClassesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Education_Me_Classes,
            Education_Users_Id_Classes,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Education_Me_Classes: return $"/education/me/classes";
                    case ApiPath.Education_Users_Id_Classes: return $"/education/users/{Id}/classes";
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
    public partial class EducationuserListClassesResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-list-classes?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationuserListClassesResponse> EducationuserListClassesAsync()
        {
            var p = new EducationuserListClassesParameter();
            return await this.SendAsync<EducationuserListClassesParameter, EducationuserListClassesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-list-classes?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationuserListClassesResponse> EducationuserListClassesAsync(CancellationToken cancellationToken)
        {
            var p = new EducationuserListClassesParameter();
            return await this.SendAsync<EducationuserListClassesParameter, EducationuserListClassesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-list-classes?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationuserListClassesResponse> EducationuserListClassesAsync(EducationuserListClassesParameter parameter)
        {
            return await this.SendAsync<EducationuserListClassesParameter, EducationuserListClassesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-list-classes?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationuserListClassesResponse> EducationuserListClassesAsync(EducationuserListClassesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationuserListClassesParameter, EducationuserListClassesResponse>(parameter, cancellationToken);
        }
    }
}
