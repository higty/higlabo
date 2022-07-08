using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IdentityUserflowattributePostParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public string? UserFlowAttributeType { get; set; }
        public string? DataType { get; set; }
    }
    public partial class IdentityUserflowattributePostResponse : RestApiResponse
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
        public async Task<IdentityUserflowattributePostResponse> IdentityUserflowattributePostAsync()
        {
            var p = new IdentityUserflowattributePostParameter();
            return await this.SendAsync<IdentityUserflowattributePostParameter, IdentityUserflowattributePostResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityuserflowattribute-post?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityUserflowattributePostResponse> IdentityUserflowattributePostAsync(CancellationToken cancellationToken)
        {
            var p = new IdentityUserflowattributePostParameter();
            return await this.SendAsync<IdentityUserflowattributePostParameter, IdentityUserflowattributePostResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityuserflowattribute-post?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityUserflowattributePostResponse> IdentityUserflowattributePostAsync(IdentityUserflowattributePostParameter parameter)
        {
            return await this.SendAsync<IdentityUserflowattributePostParameter, IdentityUserflowattributePostResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityuserflowattribute-post?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityUserflowattributePostResponse> IdentityUserflowattributePostAsync(IdentityUserflowattributePostParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IdentityUserflowattributePostParameter, IdentityUserflowattributePostResponse>(parameter, cancellationToken);
        }
    }
}
