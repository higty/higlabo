using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityuserflowattribute-update?view=graph-rest-1.0
    /// </summary>
    public partial class IdentityUserflowattributeUpdateParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public string? Description { get; set; }
    }
    public partial class IdentityUserflowattributeUpdateResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityuserflowattribute-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityuserflowattribute-update?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityUserflowattributeUpdateResponse> IdentityUserflowattributeUpdateAsync()
        {
            var p = new IdentityUserflowattributeUpdateParameter();
            return await this.SendAsync<IdentityUserflowattributeUpdateParameter, IdentityUserflowattributeUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityuserflowattribute-update?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityUserflowattributeUpdateResponse> IdentityUserflowattributeUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new IdentityUserflowattributeUpdateParameter();
            return await this.SendAsync<IdentityUserflowattributeUpdateParameter, IdentityUserflowattributeUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityuserflowattribute-update?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityUserflowattributeUpdateResponse> IdentityUserflowattributeUpdateAsync(IdentityUserflowattributeUpdateParameter parameter)
        {
            return await this.SendAsync<IdentityUserflowattributeUpdateParameter, IdentityUserflowattributeUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityuserflowattribute-update?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityUserflowattributeUpdateResponse> IdentityUserflowattributeUpdateAsync(IdentityUserflowattributeUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IdentityUserflowattributeUpdateParameter, IdentityUserflowattributeUpdateResponse>(parameter, cancellationToken);
        }
    }
}
