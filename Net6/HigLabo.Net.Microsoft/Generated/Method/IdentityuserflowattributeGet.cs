using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityuserflowattribute-get?view=graph-rest-1.0
    /// </summary>
    public partial class IdentityUserflowattributeGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Identity_UserFlowAttributes_Id: return $"/identity/userFlowAttributes/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Identity_UserFlowAttributes_Id,
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
    public partial class IdentityUserflowattributeGetResponse : RestApiResponse
    {
        public enum IdentityUserFlowAttributeIdentityUserFlowAttributeDataType
        {
            String,
            Boolean,
            Int64,
            StringCollection,
            DateTime,
        }
        public enum IdentityUserFlowAttributeIdentityUserFlowAttributeType
        {
            BuiltIn,
            Custom,
            Required,
        }

        public IdentityUserFlowAttributeIdentityUserFlowAttributeDataType DataType { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public IdentityUserFlowAttributeIdentityUserFlowAttributeType UserFlowAttributeType { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityuserflowattribute-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityuserflowattribute-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityUserflowattributeGetResponse> IdentityUserflowattributeGetAsync()
        {
            var p = new IdentityUserflowattributeGetParameter();
            return await this.SendAsync<IdentityUserflowattributeGetParameter, IdentityUserflowattributeGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityuserflowattribute-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityUserflowattributeGetResponse> IdentityUserflowattributeGetAsync(CancellationToken cancellationToken)
        {
            var p = new IdentityUserflowattributeGetParameter();
            return await this.SendAsync<IdentityUserflowattributeGetParameter, IdentityUserflowattributeGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityuserflowattribute-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityUserflowattributeGetResponse> IdentityUserflowattributeGetAsync(IdentityUserflowattributeGetParameter parameter)
        {
            return await this.SendAsync<IdentityUserflowattributeGetParameter, IdentityUserflowattributeGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityuserflowattribute-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityUserflowattributeGetResponse> IdentityUserflowattributeGetAsync(IdentityUserflowattributeGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IdentityUserflowattributeGetParameter, IdentityUserflowattributeGetResponse>(parameter, cancellationToken);
        }
    }
}
