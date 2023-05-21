using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityuserflowattribute-delete?view=graph-rest-1.0
    /// </summary>
    public partial class IdentityUserflowattributeDeleteParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class IdentityUserflowattributeDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityuserflowattribute-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityuserflowattribute-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityUserflowattributeDeleteResponse> IdentityUserflowattributeDeleteAsync()
        {
            var p = new IdentityUserflowattributeDeleteParameter();
            return await this.SendAsync<IdentityUserflowattributeDeleteParameter, IdentityUserflowattributeDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityuserflowattribute-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityUserflowattributeDeleteResponse> IdentityUserflowattributeDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IdentityUserflowattributeDeleteParameter();
            return await this.SendAsync<IdentityUserflowattributeDeleteParameter, IdentityUserflowattributeDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityuserflowattribute-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityUserflowattributeDeleteResponse> IdentityUserflowattributeDeleteAsync(IdentityUserflowattributeDeleteParameter parameter)
        {
            return await this.SendAsync<IdentityUserflowattributeDeleteParameter, IdentityUserflowattributeDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityuserflowattribute-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityUserflowattributeDeleteResponse> IdentityUserflowattributeDeleteAsync(IdentityUserflowattributeDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IdentityUserflowattributeDeleteParameter, IdentityUserflowattributeDeleteResponse>(parameter, cancellationToken);
        }
    }
}
