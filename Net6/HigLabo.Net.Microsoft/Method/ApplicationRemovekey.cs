using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ApplicationRemovekeyParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Applications_Id_RemoveKey: return $"/applications/{Id}/removeKey";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Applications_Id_RemoveKey,
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
        public string? Proof { get; set; }
    }
    public partial class ApplicationRemovekeyResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-removekey?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationRemovekeyResponse> ApplicationRemovekeyAsync()
        {
            var p = new ApplicationRemovekeyParameter();
            return await this.SendAsync<ApplicationRemovekeyParameter, ApplicationRemovekeyResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-removekey?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationRemovekeyResponse> ApplicationRemovekeyAsync(CancellationToken cancellationToken)
        {
            var p = new ApplicationRemovekeyParameter();
            return await this.SendAsync<ApplicationRemovekeyParameter, ApplicationRemovekeyResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-removekey?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationRemovekeyResponse> ApplicationRemovekeyAsync(ApplicationRemovekeyParameter parameter)
        {
            return await this.SendAsync<ApplicationRemovekeyParameter, ApplicationRemovekeyResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-removekey?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationRemovekeyResponse> ApplicationRemovekeyAsync(ApplicationRemovekeyParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ApplicationRemovekeyParameter, ApplicationRemovekeyResponse>(parameter, cancellationToken);
        }
    }
}
