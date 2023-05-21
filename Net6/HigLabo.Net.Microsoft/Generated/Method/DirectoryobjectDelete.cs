using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryobject-delete?view=graph-rest-1.0
    /// </summary>
    public partial class DirectoryobjectDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.DirectoryObjects_Id: return $"/directoryObjects/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            DirectoryObjects_Id,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class DirectoryobjectDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryobject-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directoryobject-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryobjectDeleteResponse> DirectoryobjectDeleteAsync()
        {
            var p = new DirectoryobjectDeleteParameter();
            return await this.SendAsync<DirectoryobjectDeleteParameter, DirectoryobjectDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directoryobject-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryobjectDeleteResponse> DirectoryobjectDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new DirectoryobjectDeleteParameter();
            return await this.SendAsync<DirectoryobjectDeleteParameter, DirectoryobjectDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directoryobject-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryobjectDeleteResponse> DirectoryobjectDeleteAsync(DirectoryobjectDeleteParameter parameter)
        {
            return await this.SendAsync<DirectoryobjectDeleteParameter, DirectoryobjectDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directoryobject-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryobjectDeleteResponse> DirectoryobjectDeleteAsync(DirectoryobjectDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DirectoryobjectDeleteParameter, DirectoryobjectDeleteResponse>(parameter, cancellationToken);
        }
    }
}
