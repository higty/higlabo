using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AgreementListFilesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Agreements_AgreementsId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Agreements_AgreementsId: return $"/agreements/{AgreementsId}";
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
        public string AgreementsId { get; set; }
    }
    public partial class AgreementListFilesResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/agreementfilelocalization?view=graph-rest-1.0
        /// </summary>
        public partial class AgreementFileLocalization
        {
            public DateTimeOffset? CreatedDateTime { get; set; }
            public string? DisplayName { get; set; }
            public AgreementFileData? FileData { get; set; }
            public string? FileName { get; set; }
            public string? Id { get; set; }
            public bool? IsDefault { get; set; }
            public bool? IsMajorVersion { get; set; }
            public string? Language { get; set; }
        }

        public AgreementFileLocalization[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/agreement-list-files?view=graph-rest-1.0
        /// </summary>
        public async Task<AgreementListFilesResponse> AgreementListFilesAsync()
        {
            var p = new AgreementListFilesParameter();
            return await this.SendAsync<AgreementListFilesParameter, AgreementListFilesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/agreement-list-files?view=graph-rest-1.0
        /// </summary>
        public async Task<AgreementListFilesResponse> AgreementListFilesAsync(CancellationToken cancellationToken)
        {
            var p = new AgreementListFilesParameter();
            return await this.SendAsync<AgreementListFilesParameter, AgreementListFilesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/agreement-list-files?view=graph-rest-1.0
        /// </summary>
        public async Task<AgreementListFilesResponse> AgreementListFilesAsync(AgreementListFilesParameter parameter)
        {
            return await this.SendAsync<AgreementListFilesParameter, AgreementListFilesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/agreement-list-files?view=graph-rest-1.0
        /// </summary>
        public async Task<AgreementListFilesResponse> AgreementListFilesAsync(AgreementListFilesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AgreementListFilesParameter, AgreementListFilesResponse>(parameter, cancellationToken);
        }
    }
}
