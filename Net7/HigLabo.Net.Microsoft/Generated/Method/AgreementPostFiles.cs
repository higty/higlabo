using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/agreement-post-files?view=graph-rest-1.0
    /// </summary>
    public partial class AgreementPostFilesParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? AgreementsId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Agreements_AgreementsId_Files: return $"/agreements/{AgreementsId}/files";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Agreements_AgreementsId_Files,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? DisplayName { get; set; }
        public AgreementFileData? FileData { get; set; }
        public string? FileName { get; set; }
        public bool? IsDefault { get; set; }
        public bool? IsMajorVersion { get; set; }
        public string? Language { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Id { get; set; }
        public AgreementFileVersion[]? Versions { get; set; }
    }
    public partial class AgreementPostFilesResponse : RestApiResponse
    {
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public AgreementFileData? FileData { get; set; }
        public string? FileName { get; set; }
        public string? Id { get; set; }
        public bool? IsDefault { get; set; }
        public bool? IsMajorVersion { get; set; }
        public string? Language { get; set; }
        public AgreementFileVersion[]? Versions { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/agreement-post-files?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/agreement-post-files?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AgreementPostFilesResponse> AgreementPostFilesAsync()
        {
            var p = new AgreementPostFilesParameter();
            return await this.SendAsync<AgreementPostFilesParameter, AgreementPostFilesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/agreement-post-files?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AgreementPostFilesResponse> AgreementPostFilesAsync(CancellationToken cancellationToken)
        {
            var p = new AgreementPostFilesParameter();
            return await this.SendAsync<AgreementPostFilesParameter, AgreementPostFilesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/agreement-post-files?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AgreementPostFilesResponse> AgreementPostFilesAsync(AgreementPostFilesParameter parameter)
        {
            return await this.SendAsync<AgreementPostFilesParameter, AgreementPostFilesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/agreement-post-files?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AgreementPostFilesResponse> AgreementPostFilesAsync(AgreementPostFilesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AgreementPostFilesParameter, AgreementPostFilesResponse>(parameter, cancellationToken);
        }
    }
}
