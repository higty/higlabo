using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationclassGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Education_Classes_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Education_Classes_Id: return $"/education/classes/{Id}";
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
    public partial class EducationclassGetResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationclass-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationclassGetResponse> EducationclassGetAsync()
        {
            var p = new EducationclassGetParameter();
            return await this.SendAsync<EducationclassGetParameter, EducationclassGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationclass-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationclassGetResponse> EducationclassGetAsync(CancellationToken cancellationToken)
        {
            var p = new EducationclassGetParameter();
            return await this.SendAsync<EducationclassGetParameter, EducationclassGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationclass-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationclassGetResponse> EducationclassGetAsync(EducationclassGetParameter parameter)
        {
            return await this.SendAsync<EducationclassGetParameter, EducationclassGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationclass-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationclassGetResponse> EducationclassGetAsync(EducationclassGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationclassGetParameter, EducationclassGetResponse>(parameter, cancellationToken);
        }
    }
}
