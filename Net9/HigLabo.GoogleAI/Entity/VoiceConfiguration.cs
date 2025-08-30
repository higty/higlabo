namespace HigLabo.GoogleAI;
public class VoiceConfiguration
{
    public PreBuiltVoiceConfiguration? PreBuiltVoiceConfig { get; set; } 
}
public class PreBuiltVoiceConfiguration
{
    public string VoiceName { get; set; } = "";
}
public class MultiSpeakerVoiceConfiguration
{
    public List<SpeakerVoiceConfiguration> SpeakerVoiceConfigs { get; set; } = new();
}
public class SpeakerVoiceConfiguration
{
    public string Speaker { get; set; } = "";
    public VoiceConfiguration? VoiceConfig { get; set; }
}
