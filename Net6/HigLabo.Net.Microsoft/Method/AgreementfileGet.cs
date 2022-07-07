using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AgreementfileGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Agreements_AgreementsId_File,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Agreements_AgreementsId_File: return $"/agreements/{AgreementsId}/file";
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
    public partial class AgreementfileGetResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/agreementfile?view=graph-rest-1.0
        /// </summary>
        public partial class AgreementFile
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

        public AgreementFile[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/agreementfile-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AgreementfileGetResponse> AgreementfileGetAsync()
        {
            var p = new AgreementfileGetParameter();
            return await this.SendAsync<AgreementfileGetParameter, AgreementfileGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/agreementfile-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AgreementfileGetResponse> AgreementfileGetAsync(CancellationToken cancellationToken)
        {
            var p = new AgreementfileGetParameter();
            return await this.SendAsync<AgreementfileGetParameter, AgreementfileGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/agreementfile-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AgreementfileGetResponse> AgreementfileGetAsync(AgreementfileGetParameter parameter)
        {
            return await this.SendAsync<AgreementfileGetParameter, AgreementfileGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/agreementfile-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AgreementfileGetResponse> AgreementfileGetAsync(AgreementfileGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AgreementfileGetParameter, AgreementfileGetResponse>(parameter, cancellationToken);
        }
    }
}
