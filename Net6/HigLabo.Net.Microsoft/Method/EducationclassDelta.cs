using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationclassDeltaParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Education_Classes_Delta,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Education_Classes_Delta: return $"/education/classes/delta";
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
    }
    public partial class EducationclassDeltaResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/educationclass-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationclassDeltaResponse> EducationclassDeltaAsync()
        {
            var p = new EducationclassDeltaParameter();
            return await this.SendAsync<EducationclassDeltaParameter, EducationclassDeltaResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationclass-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationclassDeltaResponse> EducationclassDeltaAsync(CancellationToken cancellationToken)
        {
            var p = new EducationclassDeltaParameter();
            return await this.SendAsync<EducationclassDeltaParameter, EducationclassDeltaResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationclass-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationclassDeltaResponse> EducationclassDeltaAsync(EducationclassDeltaParameter parameter)
        {
            return await this.SendAsync<EducationclassDeltaParameter, EducationclassDeltaResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationclass-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationclassDeltaResponse> EducationclassDeltaAsync(EducationclassDeltaParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationclassDeltaParameter, EducationclassDeltaResponse>(parameter, cancellationToken);
        }
    }
}
