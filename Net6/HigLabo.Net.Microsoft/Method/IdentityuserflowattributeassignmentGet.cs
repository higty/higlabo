using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IdentityUserflowattributeAssignmentGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string B2xUserFlowsId { get; set; }
            public string UserAttributeAssignmentsId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Identity_B2xUserFlows_Id_UserAttributeAssignments_Id: return $"/identity/b2xUserFlows/{B2xUserFlowsId}/userAttributeAssignments/{UserAttributeAssignmentsId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Identity_B2xUserFlows_Id_UserAttributeAssignments_Id,
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
    public partial class IdentityUserflowattributeAssignmentGetResponse : RestApiResponse
    {
        public enum IdentityUserFlowAttributeAssignmentIdentityUserFlowAttributeInputType
        {
            TextBox,
            DateTimeDropdown,
            RadioSingleSelect,
            DropdownSingleSelect,
            EmailBox,
            CheckboxMultiSelect,
        }

        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public bool? IsOptional { get; set; }
        public bool? RequiresVerification { get; set; }
        public UserAttributeValuesItem[]? UserAttributeValues { get; set; }
        public IdentityUserFlowAttributeAssignmentIdentityUserFlowAttributeInputType UserInputType { get; set; }
        public IdentityUserFlowAttribute? UserAttribute { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityuserflowattributeassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityUserflowattributeAssignmentGetResponse> IdentityUserflowattributeAssignmentGetAsync()
        {
            var p = new IdentityUserflowattributeAssignmentGetParameter();
            return await this.SendAsync<IdentityUserflowattributeAssignmentGetParameter, IdentityUserflowattributeAssignmentGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityuserflowattributeassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityUserflowattributeAssignmentGetResponse> IdentityUserflowattributeAssignmentGetAsync(CancellationToken cancellationToken)
        {
            var p = new IdentityUserflowattributeAssignmentGetParameter();
            return await this.SendAsync<IdentityUserflowattributeAssignmentGetParameter, IdentityUserflowattributeAssignmentGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityuserflowattributeassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityUserflowattributeAssignmentGetResponse> IdentityUserflowattributeAssignmentGetAsync(IdentityUserflowattributeAssignmentGetParameter parameter)
        {
            return await this.SendAsync<IdentityUserflowattributeAssignmentGetParameter, IdentityUserflowattributeAssignmentGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityuserflowattributeassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityUserflowattributeAssignmentGetResponse> IdentityUserflowattributeAssignmentGetAsync(IdentityUserflowattributeAssignmentGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IdentityUserflowattributeAssignmentGetParameter, IdentityUserflowattributeAssignmentGetResponse>(parameter, cancellationToken);
        }
    }
}
