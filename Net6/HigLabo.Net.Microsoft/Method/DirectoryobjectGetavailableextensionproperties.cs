using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DirectoryobjectGetavailableextensionpropertiesParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DirectoryObjects_GetAvailableExtensionProperties,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DirectoryObjects_GetAvailableExtensionProperties: return $"/directoryObjects/getAvailableExtensionProperties";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public bool? IsSyncedFromOnPremises { get; set; }
    }
    public partial class DirectoryobjectGetavailableextensionpropertiesResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/extensionproperty?view=graph-rest-1.0
        /// </summary>
        public partial class ExtensionProperty
        {
            public string? AppDisplayName { get; set; }
            public string? DataType { get; set; }
            public DateTimeOffset? DeletedDateTime { get; set; }
            public bool? IsSyncedFromOnPremises { get; set; }
            public string? Name { get; set; }
            public String[]? TargetObjects { get; set; }
        }

        public ExtensionProperty[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryobject-getavailableextensionproperties?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryobjectGetavailableextensionpropertiesResponse> DirectoryobjectGetavailableextensionpropertiesAsync()
        {
            var p = new DirectoryobjectGetavailableextensionpropertiesParameter();
            return await this.SendAsync<DirectoryobjectGetavailableextensionpropertiesParameter, DirectoryobjectGetavailableextensionpropertiesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryobject-getavailableextensionproperties?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryobjectGetavailableextensionpropertiesResponse> DirectoryobjectGetavailableextensionpropertiesAsync(CancellationToken cancellationToken)
        {
            var p = new DirectoryobjectGetavailableextensionpropertiesParameter();
            return await this.SendAsync<DirectoryobjectGetavailableextensionpropertiesParameter, DirectoryobjectGetavailableextensionpropertiesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryobject-getavailableextensionproperties?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryobjectGetavailableextensionpropertiesResponse> DirectoryobjectGetavailableextensionpropertiesAsync(DirectoryobjectGetavailableextensionpropertiesParameter parameter)
        {
            return await this.SendAsync<DirectoryobjectGetavailableextensionpropertiesParameter, DirectoryobjectGetavailableextensionpropertiesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryobject-getavailableextensionproperties?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryobjectGetavailableextensionpropertiesResponse> DirectoryobjectGetavailableextensionpropertiesAsync(DirectoryobjectGetavailableextensionpropertiesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DirectoryobjectGetavailableextensionpropertiesParameter, DirectoryobjectGetavailableextensionpropertiesResponse>(parameter, cancellationToken);
        }
    }
}
