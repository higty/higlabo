using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/application-removepassword?view=graph-rest-1.0
    /// </summary>
    public partial class ApplicationRemovepasswordParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Applications_Id_RemovePassword: return $"/applications/{Id}/removePassword";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Applications_Id_RemovePassword,
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
        public Guid? KeyId { get; set; }
    }
    public partial class ApplicationRemovepasswordResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/application-removepassword?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/application-removepassword?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ApplicationRemovepasswordResponse> ApplicationRemovepasswordAsync()
        {
            var p = new ApplicationRemovepasswordParameter();
            return await this.SendAsync<ApplicationRemovepasswordParameter, ApplicationRemovepasswordResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/application-removepassword?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ApplicationRemovepasswordResponse> ApplicationRemovepasswordAsync(CancellationToken cancellationToken)
        {
            var p = new ApplicationRemovepasswordParameter();
            return await this.SendAsync<ApplicationRemovepasswordParameter, ApplicationRemovepasswordResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/application-removepassword?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ApplicationRemovepasswordResponse> ApplicationRemovepasswordAsync(ApplicationRemovepasswordParameter parameter)
        {
            return await this.SendAsync<ApplicationRemovepasswordParameter, ApplicationRemovepasswordResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/application-removepassword?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ApplicationRemovepasswordResponse> ApplicationRemovepasswordAsync(ApplicationRemovepasswordParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ApplicationRemovepasswordParameter, ApplicationRemovepasswordResponse>(parameter, cancellationToken);
        }
    }
}
