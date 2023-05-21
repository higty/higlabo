using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bitlockerrecoverykey-get?view=graph-rest-1.0
    /// </summary>
    public partial class BitlockerrecoverykeyGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? BitlockeryRecoveryKeyId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.InformationProtection_Bitlocker_RecoveryKeys_BitlockeryRecoveryKeyId: return $"/informationProtection/bitlocker/recoveryKeys/{BitlockeryRecoveryKeyId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            InformationProtection_Bitlocker_RecoveryKeys_BitlockeryRecoveryKeyId,
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
    public partial class BitlockerrecoverykeyGetResponse : RestApiResponse
    {
        public enum BitlockerRecoveryKeyVolumeType
        {
            OperatingSystemVolume,
            FixedDataVolume,
            RemovableDataVolume,
            UnknownFutureValue,
        }

        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? DeviceId { get; set; }
        public string? Id { get; set; }
        public string? Key { get; set; }
        public BitlockerRecoveryKeyVolumeType VolumeType { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bitlockerrecoverykey-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bitlockerrecoverykey-get?view=graph-rest-1.0
        /// </summary>
        public async Task<BitlockerrecoverykeyGetResponse> BitlockerrecoverykeyGetAsync()
        {
            var p = new BitlockerrecoverykeyGetParameter();
            return await this.SendAsync<BitlockerrecoverykeyGetParameter, BitlockerrecoverykeyGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bitlockerrecoverykey-get?view=graph-rest-1.0
        /// </summary>
        public async Task<BitlockerrecoverykeyGetResponse> BitlockerrecoverykeyGetAsync(CancellationToken cancellationToken)
        {
            var p = new BitlockerrecoverykeyGetParameter();
            return await this.SendAsync<BitlockerrecoverykeyGetParameter, BitlockerrecoverykeyGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bitlockerrecoverykey-get?view=graph-rest-1.0
        /// </summary>
        public async Task<BitlockerrecoverykeyGetResponse> BitlockerrecoverykeyGetAsync(BitlockerrecoverykeyGetParameter parameter)
        {
            return await this.SendAsync<BitlockerrecoverykeyGetParameter, BitlockerrecoverykeyGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bitlockerrecoverykey-get?view=graph-rest-1.0
        /// </summary>
        public async Task<BitlockerrecoverykeyGetResponse> BitlockerrecoverykeyGetAsync(BitlockerrecoverykeyGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BitlockerrecoverykeyGetParameter, BitlockerrecoverykeyGetResponse>(parameter, cancellationToken);
        }
    }
}
