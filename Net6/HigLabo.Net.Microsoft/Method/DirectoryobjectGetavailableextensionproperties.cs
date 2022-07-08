using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DirectoryobjectGetavailableextensionpropertiesParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.DirectoryObjects_GetAvailableExtensionProperties: return $"/directoryObjects/getAvailableExtensionProperties";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            DirectoryObjects_GetAvailableExtensionProperties,
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
        public bool? IsSyncedFromOnPremises { get; set; }
    }
    public partial class DirectoryobjectGetavailableextensionpropertiesResponse : RestApiResponse
    {
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
