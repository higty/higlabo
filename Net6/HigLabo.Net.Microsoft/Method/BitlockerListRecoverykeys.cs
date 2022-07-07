using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class BitlockerListRecoverykeysParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            InformationProtection_Bitlocker_RecoveryKeys,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.InformationProtection_Bitlocker_RecoveryKeys: return $"/informationProtection/bitlocker/recoveryKeys";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/bitlockerrecoverykey?view=graph-rest-1.0
        /// </summary>
        public partial class BitlockerRecoveryKey
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

        public BitlockerRecoveryKey[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bitlocker-list-recoverykeys?view=graph-rest-1.0
        /// </summary>
        public async Task<BitlockerListRecoverykeysResponse> BitlockerListRecoverykeysAsync()
        {
            var p = new BitlockerListRecoverykeysParameter();
            return await this.SendAsync<BitlockerListRecoverykeysParameter, BitlockerListRecoverykeysResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bitlocker-list-recoverykeys?view=graph-rest-1.0
        /// </summary>
        public async Task<BitlockerListRecoverykeysResponse> BitlockerListRecoverykeysAsync(CancellationToken cancellationToken)
        {
            var p = new BitlockerListRecoverykeysParameter();
            return await this.SendAsync<BitlockerListRecoverykeysParameter, BitlockerListRecoverykeysResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bitlocker-list-recoverykeys?view=graph-rest-1.0
        /// </summary>
        public async Task<BitlockerListRecoverykeysResponse> BitlockerListRecoverykeysAsync(BitlockerListRecoverykeysParameter parameter)
        {
            return await this.SendAsync<BitlockerListRecoverykeysParameter, BitlockerListRecoverykeysResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bitlocker-list-recoverykeys?view=graph-rest-1.0
        /// </summary>
        public async Task<BitlockerListRecoverykeysResponse> BitlockerListRecoverykeysAsync(BitlockerListRecoverykeysParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BitlockerListRecoverykeysParameter, BitlockerListRecoverykeysResponse>(parameter, cancellationToken);
        }
    }
}
