using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneMamUserWipemanagedappregistrationsbydevicetagParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Users_UsersId_WipeManagedAppRegistrationsByDeviceTag,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Users_UsersId_WipeManagedAppRegistrationsByDeviceTag: return $"/users/{UsersId}/wipeManagedAppRegistrationsByDeviceTag";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? DeviceTag { get; set; }
        public string UsersId { get; set; }
    }
    public partial class IntuneMamUserWipemanagedappregistrationsbydevicetagResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-user-wipemanagedappregistrationsbydevicetag?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamUserWipemanagedappregistrationsbydevicetagResponse> IntuneMamUserWipemanagedappregistrationsbydevicetagAsync()
        {
            var p = new IntuneMamUserWipemanagedappregistrationsbydevicetagParameter();
            return await this.SendAsync<IntuneMamUserWipemanagedappregistrationsbydevicetagParameter, IntuneMamUserWipemanagedappregistrationsbydevicetagResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-user-wipemanagedappregistrationsbydevicetag?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamUserWipemanagedappregistrationsbydevicetagResponse> IntuneMamUserWipemanagedappregistrationsbydevicetagAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneMamUserWipemanagedappregistrationsbydevicetagParameter();
            return await this.SendAsync<IntuneMamUserWipemanagedappregistrationsbydevicetagParameter, IntuneMamUserWipemanagedappregistrationsbydevicetagResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-user-wipemanagedappregistrationsbydevicetag?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamUserWipemanagedappregistrationsbydevicetagResponse> IntuneMamUserWipemanagedappregistrationsbydevicetagAsync(IntuneMamUserWipemanagedappregistrationsbydevicetagParameter parameter)
        {
            return await this.SendAsync<IntuneMamUserWipemanagedappregistrationsbydevicetagParameter, IntuneMamUserWipemanagedappregistrationsbydevicetagResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-user-wipemanagedappregistrationsbydevicetag?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamUserWipemanagedappregistrationsbydevicetagResponse> IntuneMamUserWipemanagedappregistrationsbydevicetagAsync(IntuneMamUserWipemanagedappregistrationsbydevicetagParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneMamUserWipemanagedappregistrationsbydevicetagParameter, IntuneMamUserWipemanagedappregistrationsbydevicetagResponse>(parameter, cancellationToken);
        }
    }
}
