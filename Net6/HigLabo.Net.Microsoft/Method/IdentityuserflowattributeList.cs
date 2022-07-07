using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IdentityuserflowattributeListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Identity_UserFlowAttributes,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Identity_UserFlowAttributes: return $"/identity/userFlowAttributes";
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
    }
    public partial class IdentityuserflowattributeListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/identityuserflowattribute?view=graph-rest-1.0
        /// </summary>
        public partial class IdentityUserFlowAttribute
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

        public IdentityUserFlowAttribute[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityuserflowattribute-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityuserflowattributeListResponse> IdentityuserflowattributeListAsync()
        {
            var p = new IdentityuserflowattributeListParameter();
            return await this.SendAsync<IdentityuserflowattributeListParameter, IdentityuserflowattributeListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityuserflowattribute-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityuserflowattributeListResponse> IdentityuserflowattributeListAsync(CancellationToken cancellationToken)
        {
            var p = new IdentityuserflowattributeListParameter();
            return await this.SendAsync<IdentityuserflowattributeListParameter, IdentityuserflowattributeListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityuserflowattribute-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityuserflowattributeListResponse> IdentityuserflowattributeListAsync(IdentityuserflowattributeListParameter parameter)
        {
            return await this.SendAsync<IdentityuserflowattributeListParameter, IdentityuserflowattributeListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityuserflowattribute-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityuserflowattributeListResponse> IdentityuserflowattributeListAsync(IdentityuserflowattributeListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IdentityuserflowattributeListParameter, IdentityuserflowattributeListResponse>(parameter, cancellationToken);
        }
    }
}
