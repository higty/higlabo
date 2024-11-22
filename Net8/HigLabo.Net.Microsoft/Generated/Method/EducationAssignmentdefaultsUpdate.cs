using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/educationassignmentdefaults-update?view=graph-rest-1.0
/// </summary>
public partial class EducationAssignmentdefaultsUpdateParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Education_Classes_Id_AssignmentDefaults: return $"/education/classes/{Id}/assignmentDefaults";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum EducationAssignmentdefaultsUpdateParameterEducationAddedStudentAction
    {
        None,
        AssignIfOpen,
    }
    public enum EducationAssignmentdefaultsUpdateParameterEducationAddToCalendarOptions
    {
        None,
        StudentsAndPublisher,
        StudentsAndTeamOwners,
        UnknownFutureValue,
        StudentsOnly,
    }
    public enum ApiPath
    {
        Education_Classes_Id_AssignmentDefaults,
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
    public EducationAssignmentdefaultsUpdateParameterEducationAddedStudentAction AddedStudentAction { get; set; }
    public EducationAssignmentdefaultsUpdateParameterEducationAddToCalendarOptions AddToCalendarAction { get; set; }
    public TimeOnly? DueTime { get; set; }
    public string? NotificationChannelUrl { get; set; }
}
public partial class EducationAssignmentdefaultsUpdateResponse : RestApiResponse
{
    public enum EducationAssignmentDefaultsEducationAddedStudentAction
    {
        None,
        AssignIfOpen,
    }
    public enum EducationAssignmentDefaultsEducationAddToCalendarOptions
    {
        None,
        StudentsAndPublisher,
        StudentsAndTeamOwners,
        UnknownFutureValue,
        StudentsOnly,
    }

    public EducationAssignmentDefaultsEducationAddedStudentAction AddedStudentAction { get; set; }
    public EducationAssignmentDefaultsEducationAddToCalendarOptions AddToCalendarAction { get; set; }
    public TimeOnly? DueTime { get; set; }
    public string? Id { get; set; }
    public string? NotificationChannelUrl { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/educationassignmentdefaults-update?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationassignmentdefaults-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationAssignmentdefaultsUpdateResponse> EducationAssignmentdefaultsUpdateAsync()
    {
        var p = new EducationAssignmentdefaultsUpdateParameter();
        return await this.SendAsync<EducationAssignmentdefaultsUpdateParameter, EducationAssignmentdefaultsUpdateResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationassignmentdefaults-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationAssignmentdefaultsUpdateResponse> EducationAssignmentdefaultsUpdateAsync(CancellationToken cancellationToken)
    {
        var p = new EducationAssignmentdefaultsUpdateParameter();
        return await this.SendAsync<EducationAssignmentdefaultsUpdateParameter, EducationAssignmentdefaultsUpdateResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationassignmentdefaults-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationAssignmentdefaultsUpdateResponse> EducationAssignmentdefaultsUpdateAsync(EducationAssignmentdefaultsUpdateParameter parameter)
    {
        return await this.SendAsync<EducationAssignmentdefaultsUpdateParameter, EducationAssignmentdefaultsUpdateResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationassignmentdefaults-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationAssignmentdefaultsUpdateResponse> EducationAssignmentdefaultsUpdateAsync(EducationAssignmentdefaultsUpdateParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<EducationAssignmentdefaultsUpdateParameter, EducationAssignmentdefaultsUpdateResponse>(parameter, cancellationToken);
    }
}
