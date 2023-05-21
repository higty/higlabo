using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/agreementfile-get?view=graph-rest-1.0
    /// </summary>
    public partial class AgreementfileGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? AgreementsId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Agreements_AgreementsId_File: return $"/agreements/{AgreementsId}/file";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            CreatedDateTime,
            DisplayName,
            FileData,
            FileName,
            Id,
            IsDefault,
            IsMajorVersion,
            Language,
            Localizations,
        }
        public enum ApiPath
        {
            Agreements_AgreementsId_File,
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
    public partial class AgreementfileGetResponse : RestApiResponse
    {
        public AgreementFile[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/agreementfile-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/agreementfile-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AgreementfileGetResponse> AgreementfileGetAsync()
        {
            var p = new AgreementfileGetParameter();
            return await this.SendAsync<AgreementfileGetParameter, AgreementfileGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/agreementfile-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AgreementfileGetResponse> AgreementfileGetAsync(CancellationToken cancellationToken)
        {
            var p = new AgreementfileGetParameter();
            return await this.SendAsync<AgreementfileGetParameter, AgreementfileGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/agreementfile-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AgreementfileGetResponse> AgreementfileGetAsync(AgreementfileGetParameter parameter)
        {
            return await this.SendAsync<AgreementfileGetParameter, AgreementfileGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/agreementfile-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AgreementfileGetResponse> AgreementfileGetAsync(AgreementfileGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AgreementfileGetParameter, AgreementfileGetResponse>(parameter, cancellationToken);
        }
    }
}
