using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationuserListTaughtclassesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Education_Me_TaughtClasses,
            Education_Users_EducationUserId_TaughtClasses,
            Ttps__Graphmicrosoftcom_V10_Groups,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Education_Me_TaughtClasses: return $"/education/me/taughtClasses";
                    case ApiPath.Education_Users_EducationUserId_TaughtClasses: return $"/education/users/{EducationUserId}/taughtClasses";
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
        public string EducationUserId { get; set; }
    }
    public partial class EducationuserListTaughtclassesResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-list-taughtclasses?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationuserListTaughtclassesResponse> EducationuserListTaughtclassesAsync()
        {
            var p = new EducationuserListTaughtclassesParameter();
            return await this.SendAsync<EducationuserListTaughtclassesParameter, EducationuserListTaughtclassesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-list-taughtclasses?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationuserListTaughtclassesResponse> EducationuserListTaughtclassesAsync(CancellationToken cancellationToken)
        {
            var p = new EducationuserListTaughtclassesParameter();
            return await this.SendAsync<EducationuserListTaughtclassesParameter, EducationuserListTaughtclassesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-list-taughtclasses?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationuserListTaughtclassesResponse> EducationuserListTaughtclassesAsync(EducationuserListTaughtclassesParameter parameter)
        {
            return await this.SendAsync<EducationuserListTaughtclassesParameter, EducationuserListTaughtclassesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-list-taughtclasses?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationuserListTaughtclassesResponse> EducationuserListTaughtclassesAsync(EducationuserListTaughtclassesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationuserListTaughtclassesParameter, EducationuserListTaughtclassesResponse>(parameter, cancellationToken);
        }
    }
}
