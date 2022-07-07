using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IdentityuserflowattributePostParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public string? UserFlowAttributeType { get; set; }
        public string? DataType { get; set; }
    }
    public partial class IdentityuserflowattributePostResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/identityuserflowattribute-post?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityuserflowattributePostResponse> IdentityuserflowattributePostAsync()
        {
            var p = new IdentityuserflowattributePostParameter();
            return await this.SendAsync<IdentityuserflowattributePostParameter, IdentityuserflowattributePostResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityuserflowattribute-post?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityuserflowattributePostResponse> IdentityuserflowattributePostAsync(CancellationToken cancellationToken)
        {
            var p = new IdentityuserflowattributePostParameter();
            return await this.SendAsync<IdentityuserflowattributePostParameter, IdentityuserflowattributePostResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityuserflowattribute-post?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityuserflowattributePostResponse> IdentityuserflowattributePostAsync(IdentityuserflowattributePostParameter parameter)
        {
            return await this.SendAsync<IdentityuserflowattributePostParameter, IdentityuserflowattributePostResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityuserflowattribute-post?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityuserflowattributePostResponse> IdentityuserflowattributePostAsync(IdentityuserflowattributePostParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IdentityuserflowattributePostParameter, IdentityuserflowattributePostResponse>(parameter, cancellationToken);
        }
    }
}
