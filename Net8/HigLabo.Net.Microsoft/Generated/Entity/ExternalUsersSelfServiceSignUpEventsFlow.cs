using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/externalusersselfservicesignupeventsflow?view=graph-rest-1.0
    /// </summary>
    public partial class ExternalUsersSelfServiceSignUpEventsFlow
    {
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public AuthenticationConditions? Conditions { get; set; }
        public OnInteractiveAuthFlowStartHandler? OnInteractiveAuthFlowStart { get; set; }
        public OnAttributeCollectionHandler? OnAttributeCollection { get; set; }
        public OnAuthenticationMethodLoadStartHandler? OnAuthenticationMethodLoadStart { get; set; }
        public OnUserCreateStartHandler? OnUserCreateStart { get; set; }
    }
}
