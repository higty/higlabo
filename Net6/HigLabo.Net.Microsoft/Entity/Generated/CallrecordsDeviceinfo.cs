using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/callrecords-deviceinfo?view=graph-rest-1.0
    /// </summary>
    public partial class CallrecordsDeviceinfo
    {
        public string? CaptureDeviceDriver { get; set; }
        public string? CaptureDeviceName { get; set; }
        public Double? CaptureNotFunctioningEventRatio { get; set; }
        public Double? CpuInsufficentEventRatio { get; set; }
        public Double? DeviceClippingEventRatio { get; set; }
        public Double? DeviceGlitchEventRatio { get; set; }
        public Int32? HowlingEventCount { get; set; }
        public Double? InitialSignalLevelRootMeanSquare { get; set; }
        public Double? LowSpeechLevelEventRatio { get; set; }
        public Double? LowSpeechToNoiseEventRatio { get; set; }
        public Double? MicGlitchRate { get; set; }
        public Int32? ReceivedNoiseLevel { get; set; }
        public Int32? ReceivedSignalLevel { get; set; }
        public string? RenderDeviceDriver { get; set; }
        public string? RenderDeviceName { get; set; }
        public Double? RenderMuteEventRatio { get; set; }
        public Double? RenderNotFunctioningEventRatio { get; set; }
        public Double? RenderZeroVolumeEventRatio { get; set; }
        public Int32? SentNoiseLevel { get; set; }
        public Int32? SentSignalLevel { get; set; }
        public Double? SpeakerGlitchRate { get; set; }
    }
}
