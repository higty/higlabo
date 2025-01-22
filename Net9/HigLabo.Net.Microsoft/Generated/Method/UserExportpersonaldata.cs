using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/user-exportpersonaldata?view=graph-rest-1.0
/// </summary>
public partial class UserExportpersonaldataParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Users_Id_ExportPersonalData: return $"/users/{Id}/exportPersonalData";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Users_Id_ExportPersonalData,
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
    public string? StorageLocation { get; set; }
}
public partial class UserExportpersonaldataResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/user-exportpersonaldata?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-exportpersonaldata?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UserExportpersonaldataResponse> UserExportpersonaldataAsync()
    {
        var p = new UserExportpersonaldataParameter();
        return await this.SendAsync<UserExportpersonaldataParameter, UserExportpersonaldataResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-exportpersonaldata?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UserExportpersonaldataResponse> UserExportpersonaldataAsync(CancellationToken cancellationToken)
    {
        var p = new UserExportpersonaldataParameter();
        return await this.SendAsync<UserExportpersonaldataParameter, UserExportpersonaldataResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-exportpersonaldata?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UserExportpersonaldataResponse> UserExportpersonaldataAsync(UserExportpersonaldataParameter parameter)
    {
        return await this.SendAsync<UserExportpersonaldataParameter, UserExportpersonaldataResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-exportpersonaldata?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UserExportpersonaldataResponse> UserExportpersonaldataAsync(UserExportpersonaldataParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<UserExportpersonaldataParameter, UserExportpersonaldataResponse>(parameter, cancellationToken);
    }
}
