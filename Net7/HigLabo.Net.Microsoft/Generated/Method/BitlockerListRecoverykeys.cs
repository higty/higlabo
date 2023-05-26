using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bitlocker-list-recoverykeys?view=graph-rest-1.0
    /// </summary>
    public partial class BitlockerListRecoverykeysParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.InformationProtection_Bitlocker_RecoveryKeys: return $"/informationProtection/bitlocker/recoveryKeys";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            CreatedDateTime,
            DeviceId,
            Id,
            Key,
            VolumeType,
        }
        public enum ApiPath
        {
            InformationProtection_Bitlocker_RecoveryKeys,
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
    public partial class BitlockerListRecoverykeysResponse : RestApiResponse
    {
        public BitlockerRecoveryKey[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bitlocker-list-recoverykeys?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bitlocker-list-recoverykeys?view=graph-rest-1.0
        /// </summary>
        public async Task<BitlockerListRecoverykeysResponse> BitlockerListRecoverykeysAsync()
        {
            var p = new BitlockerListRecoverykeysParameter();
            return await this.SendAsync<BitlockerListRecoverykeysParameter, BitlockerListRecoverykeysResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bitlocker-list-recoverykeys?view=graph-rest-1.0
        /// </summary>
        public async Task<BitlockerListRecoverykeysResponse> BitlockerListRecoverykeysAsync(CancellationToken cancellationToken)
        {
            var p = new BitlockerListRecoverykeysParameter();
            return await this.SendAsync<BitlockerListRecoverykeysParameter, BitlockerListRecoverykeysResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bitlocker-list-recoverykeys?view=graph-rest-1.0
        /// </summary>
        public async Task<BitlockerListRecoverykeysResponse> BitlockerListRecoverykeysAsync(BitlockerListRecoverykeysParameter parameter)
        {
            return await this.SendAsync<BitlockerListRecoverykeysParameter, BitlockerListRecoverykeysResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bitlocker-list-recoverykeys?view=graph-rest-1.0
        /// </summary>
        public async Task<BitlockerListRecoverykeysResponse> BitlockerListRecoverykeysAsync(BitlockerListRecoverykeysParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BitlockerListRecoverykeysParameter, BitlockerListRecoverykeysResponse>(parameter, cancellationToken);
        }
    }
}
