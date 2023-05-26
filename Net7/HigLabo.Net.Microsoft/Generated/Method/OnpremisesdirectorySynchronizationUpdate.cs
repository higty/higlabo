using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/onpremisesdirectorysynchronization-update?view=graph-rest-1.0
    /// </summary>
    public partial class OnpremisesdirectorySynchronizationUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Directory_OnPremisesSynchronization_Id: return $"/directory/onPremisesSynchronization/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Directory_OnPremisesSynchronization_Id,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public OnPremisesDirectorySynchronizationConfiguration? Configuration { get; set; }
        public OnPremisesDirectorySynchronizationFeature? Features { get; set; }
    }
    public partial class OnpremisesdirectorySynchronizationUpdateResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/onpremisesdirectorysynchronization-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/onpremisesdirectorysynchronization-update?view=graph-rest-1.0
        /// </summary>
        public async Task<OnpremisesdirectorySynchronizationUpdateResponse> OnpremisesdirectorySynchronizationUpdateAsync()
        {
            var p = new OnpremisesdirectorySynchronizationUpdateParameter();
            return await this.SendAsync<OnpremisesdirectorySynchronizationUpdateParameter, OnpremisesdirectorySynchronizationUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/onpremisesdirectorysynchronization-update?view=graph-rest-1.0
        /// </summary>
        public async Task<OnpremisesdirectorySynchronizationUpdateResponse> OnpremisesdirectorySynchronizationUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new OnpremisesdirectorySynchronizationUpdateParameter();
            return await this.SendAsync<OnpremisesdirectorySynchronizationUpdateParameter, OnpremisesdirectorySynchronizationUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/onpremisesdirectorysynchronization-update?view=graph-rest-1.0
        /// </summary>
        public async Task<OnpremisesdirectorySynchronizationUpdateResponse> OnpremisesdirectorySynchronizationUpdateAsync(OnpremisesdirectorySynchronizationUpdateParameter parameter)
        {
            return await this.SendAsync<OnpremisesdirectorySynchronizationUpdateParameter, OnpremisesdirectorySynchronizationUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/onpremisesdirectorysynchronization-update?view=graph-rest-1.0
        /// </summary>
        public async Task<OnpremisesdirectorySynchronizationUpdateResponse> OnpremisesdirectorySynchronizationUpdateAsync(OnpremisesdirectorySynchronizationUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OnpremisesdirectorySynchronizationUpdateParameter, OnpremisesdirectorySynchronizationUpdateResponse>(parameter, cancellationToken);
        }
    }
}
