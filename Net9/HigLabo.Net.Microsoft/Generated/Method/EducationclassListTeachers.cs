using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/educationclass-list-teachers?view=graph-rest-1.0
/// </summary>
public partial class EducationclassListTeachersParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Education_Classes_Id_Teachers: return $"/education/classes/{Id}/teachers";
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
        Education_Classes_Id_Teachers,
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
public partial class EducationclassListTeachersResponse : RestApiResponse
{
    public EducationUser[]? Value { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/educationclass-list-teachers?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationclass-list-teachers?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationclassListTeachersResponse> EducationclassListTeachersAsync()
    {
        var p = new EducationclassListTeachersParameter();
        return await this.SendAsync<EducationclassListTeachersParameter, EducationclassListTeachersResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationclass-list-teachers?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationclassListTeachersResponse> EducationclassListTeachersAsync(CancellationToken cancellationToken)
    {
        var p = new EducationclassListTeachersParameter();
        return await this.SendAsync<EducationclassListTeachersParameter, EducationclassListTeachersResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationclass-list-teachers?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationclassListTeachersResponse> EducationclassListTeachersAsync(EducationclassListTeachersParameter parameter)
    {
        return await this.SendAsync<EducationclassListTeachersParameter, EducationclassListTeachersResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationclass-list-teachers?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationclassListTeachersResponse> EducationclassListTeachersAsync(EducationclassListTeachersParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<EducationclassListTeachersParameter, EducationclassListTeachersResponse>(parameter, cancellationToken);
    }
}
