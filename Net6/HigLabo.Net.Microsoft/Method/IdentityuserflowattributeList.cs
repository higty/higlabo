using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityuserflowattribute-list?view=graph-rest-1.0
    /// </summary>
    public partial class IdentityUserflowattributeListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Identity_UserFlowAttributes: return $"/identity/userFlowAttributes";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            DataType,
            Description,
            DisplayName,
            Id,
            UserFlowAttributeType,
        }
        public enum ApiPath
        {
            Identity_UserFlowAttributes,
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
    public partial class IdentityUserflowattributeListResponse : RestApiResponse
    {
        public IdentityUserFlowAttribute[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityuserflowattribute-list?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityuserflowattribute-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityUserflowattributeListResponse> IdentityUserflowattributeListAsync()
        {
            var p = new IdentityUserflowattributeListParameter();
            return await this.SendAsync<IdentityUserflowattributeListParameter, IdentityUserflowattributeListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityuserflowattribute-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityUserflowattributeListResponse> IdentityUserflowattributeListAsync(CancellationToken cancellationToken)
        {
            var p = new IdentityUserflowattributeListParameter();
            return await this.SendAsync<IdentityUserflowattributeListParameter, IdentityUserflowattributeListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityuserflowattribute-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityUserflowattributeListResponse> IdentityUserflowattributeListAsync(IdentityUserflowattributeListParameter parameter)
        {
            return await this.SendAsync<IdentityUserflowattributeListParameter, IdentityUserflowattributeListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityuserflowattribute-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityUserflowattributeListResponse> IdentityUserflowattributeListAsync(IdentityUserflowattributeListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IdentityUserflowattributeListParameter, IdentityUserflowattributeListResponse>(parameter, cancellationToken);
        }
    }
}
