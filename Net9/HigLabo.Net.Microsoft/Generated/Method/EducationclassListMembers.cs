using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/educationclass-list-members?view=graph-rest-1.0
/// </summary>
public partial class EducationclassListMembersParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Education_Classes_Id_Members: return $"/education/classes/{Id}/members";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
        AccountEnabled,
        AssignedLicenses,
        AssignedPlans,
        BusinessPhones,
        CreatedBy,
        Department,
        DisplayName,
        ExternalSource,
        ExternalSourceDetail,
        GivenName,
        Id,
        Mail,
        MailingAddress,
        MailNickname,
        MiddleName,
        MobilePhone,
        OnPremisesInfo,
        PasswordPolicies,
        PasswordProfile,
        PreferredLanguage,
        PrimaryRole,
        ProvisionedPlans,
        RelatedContacts,
        ResidenceAddress,
        ShowInAddressList,
        Student,
        Surname,
        Teacher,
        UsageLocation,
        UserPrincipalName,
        UserType,
        Assignments,
        Classes,
        Schools,
        TaughtClasses,
        User,
        Rubrics,
    }
    public enum ApiPath
    {
        Education_Classes_Id_Members,
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
public partial class EducationclassListMembersResponse : RestApiResponse
{
    public EducationUser[]? Value { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/educationclass-list-members?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationclass-list-members?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationclassListMembersResponse> EducationclassListMembersAsync()
    {
        var p = new EducationclassListMembersParameter();
        return await this.SendAsync<EducationclassListMembersParameter, EducationclassListMembersResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationclass-list-members?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationclassListMembersResponse> EducationclassListMembersAsync(CancellationToken cancellationToken)
    {
        var p = new EducationclassListMembersParameter();
        return await this.SendAsync<EducationclassListMembersParameter, EducationclassListMembersResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationclass-list-members?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationclassListMembersResponse> EducationclassListMembersAsync(EducationclassListMembersParameter parameter)
    {
        return await this.SendAsync<EducationclassListMembersParameter, EducationclassListMembersResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationclass-list-members?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationclassListMembersResponse> EducationclassListMembersAsync(EducationclassListMembersParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<EducationclassListMembersParameter, EducationclassListMembersResponse>(parameter, cancellationToken);
    }
}
