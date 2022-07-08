using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DirectoryobjectGetbyidsParameter : IRestApiParameter
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
    public partial class DirectoryobjectGetbyidsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryobject-getbyids?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryobjectGetbyidsResponse> DirectoryobjectGetbyidsAsync()
        {
            var p = new DirectoryobjectGetbyidsParameter();
            return await this.SendAsync<DirectoryobjectGetbyidsParameter, DirectoryobjectGetbyidsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryobject-getbyids?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryobjectGetbyidsResponse> DirectoryobjectGetbyidsAsync(CancellationToken cancellationToken)
        {
            var p = new DirectoryobjectGetbyidsParameter();
            return await this.SendAsync<DirectoryobjectGetbyidsParameter, DirectoryobjectGetbyidsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryobject-getbyids?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryobjectGetbyidsResponse> DirectoryobjectGetbyidsAsync(DirectoryobjectGetbyidsParameter parameter)
        {
            return await this.SendAsync<DirectoryobjectGetbyidsParameter, DirectoryobjectGetbyidsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryobject-getbyids?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryobjectGetbyidsResponse> DirectoryobjectGetbyidsAsync(DirectoryobjectGetbyidsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DirectoryobjectGetbyidsParameter, DirectoryobjectGetbyidsResponse>(parameter, cancellationToken);
        }
    }
}
