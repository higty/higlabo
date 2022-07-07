using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DirectoryobjectDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DirectoryObjects_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DirectoryObjects_Id: return $"/directoryObjects/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string Id { get; set; }
    }
    public partial class DirectoryobjectDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryobject-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryobjectDeleteResponse> DirectoryobjectDeleteAsync()
        {
            var p = new DirectoryobjectDeleteParameter();
            return await this.SendAsync<DirectoryobjectDeleteParameter, DirectoryobjectDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryobject-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryobjectDeleteResponse> DirectoryobjectDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new DirectoryobjectDeleteParameter();
            return await this.SendAsync<DirectoryobjectDeleteParameter, DirectoryobjectDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryobject-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryobjectDeleteResponse> DirectoryobjectDeleteAsync(DirectoryobjectDeleteParameter parameter)
        {
            return await this.SendAsync<DirectoryobjectDeleteParameter, DirectoryobjectDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryobject-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryobjectDeleteResponse> DirectoryobjectDeleteAsync(DirectoryobjectDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DirectoryobjectDeleteParameter, DirectoryobjectDeleteResponse>(parameter, cancellationToken);
        }
    }
}
