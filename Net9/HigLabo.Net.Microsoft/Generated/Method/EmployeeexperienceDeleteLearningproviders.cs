using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/employeeexperience-delete-learningproviders?view=graph-rest-1.0
/// </summary>
public partial class EmployeeexperienceDeleteLearningProvidersParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? LearningProviderId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.EmployeeExperience_LearningProviders_LearningProviderId_ref: return $"/employeeExperience/learningProviders/{LearningProviderId}/$ref";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        EmployeeExperience_LearningProviders_LearningProviderId_ref,
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
public partial class EmployeeexperienceDeleteLearningProvidersResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/employeeexperience-delete-learningproviders?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/employeeexperience-delete-learningproviders?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EmployeeexperienceDeleteLearningProvidersResponse> EmployeeexperienceDeleteLearningProvidersAsync()
    {
        var p = new EmployeeexperienceDeleteLearningProvidersParameter();
        return await this.SendAsync<EmployeeexperienceDeleteLearningProvidersParameter, EmployeeexperienceDeleteLearningProvidersResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/employeeexperience-delete-learningproviders?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EmployeeexperienceDeleteLearningProvidersResponse> EmployeeexperienceDeleteLearningProvidersAsync(CancellationToken cancellationToken)
    {
        var p = new EmployeeexperienceDeleteLearningProvidersParameter();
        return await this.SendAsync<EmployeeexperienceDeleteLearningProvidersParameter, EmployeeexperienceDeleteLearningProvidersResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/employeeexperience-delete-learningproviders?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EmployeeexperienceDeleteLearningProvidersResponse> EmployeeexperienceDeleteLearningProvidersAsync(EmployeeexperienceDeleteLearningProvidersParameter parameter)
    {
        return await this.SendAsync<EmployeeexperienceDeleteLearningProvidersParameter, EmployeeexperienceDeleteLearningProvidersResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/employeeexperience-delete-learningproviders?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EmployeeexperienceDeleteLearningProvidersResponse> EmployeeexperienceDeleteLearningProvidersAsync(EmployeeexperienceDeleteLearningProvidersParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<EmployeeexperienceDeleteLearningProvidersParameter, EmployeeexperienceDeleteLearningProvidersResponse>(parameter, cancellationToken);
    }
}
