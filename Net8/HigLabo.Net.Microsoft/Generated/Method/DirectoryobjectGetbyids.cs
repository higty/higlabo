using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryobject-getbyids?view=graph-rest-1.0
    /// </summary>
    public partial class DirectoryObjectGetbyidsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.DirectoryObjects_GetByIds: return $"/directoryObjects/getByIds";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            DirectoryObjects_GetByIds,
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
        public String[]? Ids { get; set; }
        public String[]? Types { get; set; }
    }
    public partial class DirectoryObjectGetbyidsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryobject-getbyids?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directoryobject-getbyids?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DirectoryObjectGetbyidsResponse> DirectoryObjectGetbyidsAsync()
        {
            var p = new DirectoryObjectGetbyidsParameter();
            return await this.SendAsync<DirectoryObjectGetbyidsParameter, DirectoryObjectGetbyidsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directoryobject-getbyids?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DirectoryObjectGetbyidsResponse> DirectoryObjectGetbyidsAsync(CancellationToken cancellationToken)
        {
            var p = new DirectoryObjectGetbyidsParameter();
            return await this.SendAsync<DirectoryObjectGetbyidsParameter, DirectoryObjectGetbyidsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directoryobject-getbyids?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DirectoryObjectGetbyidsResponse> DirectoryObjectGetbyidsAsync(DirectoryObjectGetbyidsParameter parameter)
        {
            return await this.SendAsync<DirectoryObjectGetbyidsParameter, DirectoryObjectGetbyidsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directoryobject-getbyids?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DirectoryObjectGetbyidsResponse> DirectoryObjectGetbyidsAsync(DirectoryObjectGetbyidsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DirectoryObjectGetbyidsParameter, DirectoryObjectGetbyidsResponse>(parameter, cancellationToken);
        }
    }
}
