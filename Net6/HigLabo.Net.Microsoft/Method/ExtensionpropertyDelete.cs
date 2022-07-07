using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ExtensionpropertyDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Applications_ApplicationObjectId_ExtensionProperties_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Applications_ApplicationObjectId_ExtensionProperties_Id: return $"/applications/{ApplicationObjectId}/extensionProperties/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string ApplicationObjectId { get; set; }
        public string Id { get; set; }
    }
    public partial class ExtensionpropertyDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/extensionproperty-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ExtensionpropertyDeleteResponse> ExtensionpropertyDeleteAsync()
        {
            var p = new ExtensionpropertyDeleteParameter();
            return await this.SendAsync<ExtensionpropertyDeleteParameter, ExtensionpropertyDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/extensionproperty-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ExtensionpropertyDeleteResponse> ExtensionpropertyDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new ExtensionpropertyDeleteParameter();
            return await this.SendAsync<ExtensionpropertyDeleteParameter, ExtensionpropertyDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/extensionproperty-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ExtensionpropertyDeleteResponse> ExtensionpropertyDeleteAsync(ExtensionpropertyDeleteParameter parameter)
        {
            return await this.SendAsync<ExtensionpropertyDeleteParameter, ExtensionpropertyDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/extensionproperty-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ExtensionpropertyDeleteResponse> ExtensionpropertyDeleteAsync(ExtensionpropertyDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ExtensionpropertyDeleteParameter, ExtensionpropertyDeleteResponse>(parameter, cancellationToken);
        }
    }
}
