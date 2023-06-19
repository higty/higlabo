using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/extensionproperty-get?view=graph-rest-1.0
    /// </summary>
    public partial class ExtensionpropertyGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ApplicationObjectId { get; set; }
            public string? ExtensionPropertyId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Applications_ApplicationObjectId_ExtensionProperties_ExtensionPropertyId: return $"/applications/{ApplicationObjectId}/extensionProperties/{ExtensionPropertyId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Applications_ApplicationObjectId_ExtensionProperties_ExtensionPropertyId,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
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
    }
    public partial class ExtensionpropertyGetResponse : RestApiResponse
    {
        public string? AppDisplayName { get; set; }
        public string? DataType { get; set; }
        public DateTimeOffset? DeletedDateTime { get; set; }
        public bool? IsSyncedFromOnPremises { get; set; }
        public string? Name { get; set; }
        public String[]? TargetObjects { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/extensionproperty-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/extensionproperty-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ExtensionpropertyGetResponse> ExtensionpropertyGetAsync()
        {
            var p = new ExtensionpropertyGetParameter();
            return await this.SendAsync<ExtensionpropertyGetParameter, ExtensionpropertyGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/extensionproperty-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ExtensionpropertyGetResponse> ExtensionpropertyGetAsync(CancellationToken cancellationToken)
        {
            var p = new ExtensionpropertyGetParameter();
            return await this.SendAsync<ExtensionpropertyGetParameter, ExtensionpropertyGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/extensionproperty-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ExtensionpropertyGetResponse> ExtensionpropertyGetAsync(ExtensionpropertyGetParameter parameter)
        {
            return await this.SendAsync<ExtensionpropertyGetParameter, ExtensionpropertyGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/extensionproperty-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ExtensionpropertyGetResponse> ExtensionpropertyGetAsync(ExtensionpropertyGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ExtensionpropertyGetParameter, ExtensionpropertyGetResponse>(parameter, cancellationToken);
        }
    }
}
