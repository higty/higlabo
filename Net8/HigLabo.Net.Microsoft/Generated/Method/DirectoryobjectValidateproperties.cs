using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryobject-validateproperties?view=graph-rest-1.0
    /// </summary>
    public partial class DirectoryObjectValidatepropertiesParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.DirectoryObjects_ValidateProperties: return $"/directoryObjects/validateProperties";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            DirectoryObjects_ValidateProperties,
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
        public string? EntityType { get; set; }
        public string? DisplayName { get; set; }
        public string? MailNickname { get; set; }
        public Guid? OnBehalfOfUserId { get; set; }
    }
    public partial class DirectoryObjectValidatepropertiesResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryobject-validateproperties?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directoryobject-validateproperties?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DirectoryObjectValidatepropertiesResponse> DirectoryObjectValidatepropertiesAsync()
        {
            var p = new DirectoryObjectValidatepropertiesParameter();
            return await this.SendAsync<DirectoryObjectValidatepropertiesParameter, DirectoryObjectValidatepropertiesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directoryobject-validateproperties?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DirectoryObjectValidatepropertiesResponse> DirectoryObjectValidatepropertiesAsync(CancellationToken cancellationToken)
        {
            var p = new DirectoryObjectValidatepropertiesParameter();
            return await this.SendAsync<DirectoryObjectValidatepropertiesParameter, DirectoryObjectValidatepropertiesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directoryobject-validateproperties?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DirectoryObjectValidatepropertiesResponse> DirectoryObjectValidatepropertiesAsync(DirectoryObjectValidatepropertiesParameter parameter)
        {
            return await this.SendAsync<DirectoryObjectValidatepropertiesParameter, DirectoryObjectValidatepropertiesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directoryobject-validateproperties?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DirectoryObjectValidatepropertiesResponse> DirectoryObjectValidatepropertiesAsync(DirectoryObjectValidatepropertiesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DirectoryObjectValidatepropertiesParameter, DirectoryObjectValidatepropertiesResponse>(parameter, cancellationToken);
        }
    }
}
