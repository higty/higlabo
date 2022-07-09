using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AgreementListFilesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? AgreementsId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Agreements_AgreementsId: return $"/agreements/{AgreementsId}";
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
            Versions,
        }
        public enum ApiPath
        {
            Agreements_AgreementsId,
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
    public partial class AgreementListFilesResponse : RestApiResponse
    {
        public AgreementFileLocalization[]? Value { get; set; }
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
