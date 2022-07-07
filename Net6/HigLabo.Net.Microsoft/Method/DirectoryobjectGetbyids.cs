using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DirectoryobjectGetbyidsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DirectoryObjects_GetByIds,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DirectoryObjects_GetByIds: return $"/directoryObjects/getByIds";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
