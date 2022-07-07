using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DirectoryPostAdministrativeunitsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Directory_AdministrativeUnits,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Directory_AdministrativeUnits: return $"/directory/administrativeUnits";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
    }
    public partial class DirectoryPostAdministrativeunitsResponse : RestApiResponse
    {
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public string? Visibility { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directory-post-administrativeunits?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryPostAdministrativeunitsResponse> DirectoryPostAdministrativeunitsAsync()
        {
            var p = new DirectoryPostAdministrativeunitsParameter();
            return await this.SendAsync<DirectoryPostAdministrativeunitsParameter, DirectoryPostAdministrativeunitsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directory-post-administrativeunits?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryPostAdministrativeunitsResponse> DirectoryPostAdministrativeunitsAsync(CancellationToken cancellationToken)
        {
            var p = new DirectoryPostAdministrativeunitsParameter();
            return await this.SendAsync<DirectoryPostAdministrativeunitsParameter, DirectoryPostAdministrativeunitsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directory-post-administrativeunits?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryPostAdministrativeunitsResponse> DirectoryPostAdministrativeunitsAsync(DirectoryPostAdministrativeunitsParameter parameter)
        {
            return await this.SendAsync<DirectoryPostAdministrativeunitsParameter, DirectoryPostAdministrativeunitsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directory-post-administrativeunits?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryPostAdministrativeunitsResponse> DirectoryPostAdministrativeunitsAsync(DirectoryPostAdministrativeunitsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DirectoryPostAdministrativeunitsParameter, DirectoryPostAdministrativeunitsResponse>(parameter, cancellationToken);
        }
    }
}
