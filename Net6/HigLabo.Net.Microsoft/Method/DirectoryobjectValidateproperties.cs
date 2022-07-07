using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DirectoryobjectValidatepropertiesParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DirectoryObjects_ValidateProperties,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DirectoryObjects_ValidateProperties: return $"/directoryObjects/validateProperties";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? EntityType { get; set; }
        public string? DisplayName { get; set; }
        public string? MailNickname { get; set; }
        public Guid? OnBehalfOfUserId { get; set; }
    }
    public partial class DirectoryobjectValidatepropertiesResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryobject-validateproperties?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryobjectValidatepropertiesResponse> DirectoryobjectValidatepropertiesAsync()
        {
            var p = new DirectoryobjectValidatepropertiesParameter();
            return await this.SendAsync<DirectoryobjectValidatepropertiesParameter, DirectoryobjectValidatepropertiesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryobject-validateproperties?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryobjectValidatepropertiesResponse> DirectoryobjectValidatepropertiesAsync(CancellationToken cancellationToken)
        {
            var p = new DirectoryobjectValidatepropertiesParameter();
            return await this.SendAsync<DirectoryobjectValidatepropertiesParameter, DirectoryobjectValidatepropertiesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryobject-validateproperties?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryobjectValidatepropertiesResponse> DirectoryobjectValidatepropertiesAsync(DirectoryobjectValidatepropertiesParameter parameter)
        {
            return await this.SendAsync<DirectoryobjectValidatepropertiesParameter, DirectoryobjectValidatepropertiesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryobject-validateproperties?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryobjectValidatepropertiesResponse> DirectoryobjectValidatepropertiesAsync(DirectoryobjectValidatepropertiesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DirectoryobjectValidatepropertiesParameter, DirectoryobjectValidatepropertiesResponse>(parameter, cancellationToken);
        }
    }
}
