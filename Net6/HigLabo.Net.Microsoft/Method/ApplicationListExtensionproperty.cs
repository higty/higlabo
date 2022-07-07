using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ApplicationListExtensionpropertyParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Applications_ApplicationObjectId_ExtensionProperties,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Applications_ApplicationObjectId_ExtensionProperties: return $"/applications/{ApplicationObjectId}/extensionProperties";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string ApplicationObjectId { get; set; }
    }
    public partial class ApplicationListExtensionpropertyResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/application-list-extensionproperty?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationListExtensionpropertyResponse> ApplicationListExtensionpropertyAsync()
        {
            var p = new ApplicationListExtensionpropertyParameter();
            return await this.SendAsync<ApplicationListExtensionpropertyParameter, ApplicationListExtensionpropertyResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-list-extensionproperty?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationListExtensionpropertyResponse> ApplicationListExtensionpropertyAsync(CancellationToken cancellationToken)
        {
            var p = new ApplicationListExtensionpropertyParameter();
            return await this.SendAsync<ApplicationListExtensionpropertyParameter, ApplicationListExtensionpropertyResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-list-extensionproperty?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationListExtensionpropertyResponse> ApplicationListExtensionpropertyAsync(ApplicationListExtensionpropertyParameter parameter)
        {
            return await this.SendAsync<ApplicationListExtensionpropertyParameter, ApplicationListExtensionpropertyResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-list-extensionproperty?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationListExtensionpropertyResponse> ApplicationListExtensionpropertyAsync(ApplicationListExtensionpropertyParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ApplicationListExtensionpropertyParameter, ApplicationListExtensionpropertyResponse>(parameter, cancellationToken);
        }
    }
}
