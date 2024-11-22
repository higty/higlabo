using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/callrecords-mediastream?view=graph-rest-1.0
/// </summary>
public partial class CallrecordsMediastream
{
    public enum CallrecordsMediastreamCallRecordsAudioCodec
    {
        Unknown,
        Invalid,
        Cn,
        Pcma,
        Pcmu,
        AmrWide,
        G722,
        G7221,
        G7221c,
        G729,
        MultiChannelAudio,
        Muchv2,
        Opus,
        Satin,
        SatinFullband,
        RtAudio8,
        RtAudio16,
        Silk,
        SilkNarrow,
        SilkWide,
        Siren,
        XmsRTA,
        UnknownFutureValue,
    }
    public enum CallrecordsMediastreamCallRecordsMediaStreamDirection
    {
        CallerToCallee,
        CalleeToCaller,
    }
    public enum CallrecordsMediastreamCallRecordsVideoCodec
    {
        Unknown,
        Invalid,
        Av1,
        H263,
        H264,
        H264s,
        H264uc,
        H265,
        Rtvc1,
        RtVideo,
        Xrtvc1,
        UnknownFutureValue,
    }

    public CallrecordsMediastreamCallRecordsAudioCodec AudioCodec { get; set; }
    public Double? AverageAudioDegradation { get; set; }
    public string? AverageAudioNetworkJitter { get; set; }
    public Int64? AverageBandwidthEstimate { get; set; }
    public string? AverageJitter { get; set; }
    public Double? AveragePacketLossRate { get; set; }
    public Double? AverageRatioOfConcealedSamples { get; set; }
    public Double? AverageReceivedFrameRate { get; set; }
    public string? AverageRoundTripTime { get; set; }
    public Double? AverageVideoFrameLossPercentage { get; set; }
    public Double? AverageVideoFrameRate { get; set; }
    public Double? AverageVideoPacketLossRate { get; set; }
    public DateTimeOffset? EndDateTime { get; set; }
    public Double? LowFrameRateRatio { get; set; }
    public Double? LowVideoProcessingCapabilityRatio { get; set; }
    public string? MaxAudioNetworkJitter { get; set; }
    public string? MaxJitter { get; set; }
    public Double? MaxPacketLossRate { get; set; }
    public Double? MaxRatioOfConcealedSamples { get; set; }
    public string? MaxRoundTripTime { get; set; }
    public Int64? PacketUtilization { get; set; }
    public Double? PostForwardErrorCorrectionPacketLossRate { get; set; }
    public DateTimeOffset? StartDateTime { get; set; }
    public CallrecordsMediastreamCallRecordsMediaStreamDirection StreamDirection { get; set; }
    public string? StreamId { get; set; }
    public CallrecordsMediastreamCallRecordsVideoCodec VideoCodec { get; set; }
    public bool? WasMediaBypassed { get; set; }
}
