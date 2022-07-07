using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IdentityuserflowattributeGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Identity_UserFlowAttributes_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Identity_UserFlowAttributes_Id: return $"/identity/userFlowAttributes/{Id}";
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
        public string Id { get; set; }
    }
    public partial class IdentityuserflowattributeGetResponse : RestApiResponse
    {
        public enum IdentityUserFlowAttributeIdentityUserFlowAttributeType
        {
            BuiltIn,
            Custom,
            Required,
        }
        public enum IdentityUserFlowAttributeIdentityUserFlowAttributeDataType
        {
            String,
            Boolean,
            Int64,
            StringCollection,
            DateTime,
        }

        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public IdentityUserFlowAttributeIdentityUserFlowAttributeType UserFlowAttributeType { get; set; }
        public IdentityUserFlowAttributeIdentityUserFlowAttributeDataType DataType { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityuserflowattribute-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityuserflowattributeGetResponse> IdentityuserflowattributeGetAsync()
        {
            var p = new IdentityuserflowattributeGetParameter();
            return await this.SendAsync<IdentityuserflowattributeGetParameter, IdentityuserflowattributeGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityuserflowattribute-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityuserflowattributeGetResponse> IdentityuserflowattributeGetAsync(CancellationToken cancellationToken)
        {
            var p = new IdentityuserflowattributeGetParameter();
            return await this.SendAsync<IdentityuserflowattributeGetParameter, IdentityuserflowattributeGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityuserflowattribute-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityuserflowattributeGetResponse> IdentityuserflowattributeGetAsync(IdentityuserflowattributeGetParameter parameter)
        {
            return await this.SendAsync<IdentityuserflowattributeGetParameter, IdentityuserflowattributeGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityuserflowattribute-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityuserflowattributeGetResponse> IdentityuserflowattributeGetAsync(IdentityuserflowattributeGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IdentityuserflowattributeGetParameter, IdentityuserflowattributeGetResponse>(parameter, cancellationToken);
        }
    }
}
