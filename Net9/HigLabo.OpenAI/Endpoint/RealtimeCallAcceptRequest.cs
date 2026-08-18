namespace HigLabo.OpenAI;

public class RealtimeCallAcceptRequest
{
    public string Type { get; set; } = "";
    public string Model { get; set; } = "";
    public string Instructions { get; set; } = "";
    public RealtimeAudioConfig? Audio { get; set; }
    public RealtimeReasoningConfig? Reasoning { get; set; }
    public int? Max_Output_Tokens { get; set; }
}

public class RealtimeAudioConfig
{
    public RealtimeAudioInputConfig? Input { get; set; }
    public RealtimeAudioOutputConfig? Output { get; set; }
}

public class RealtimeAudioInputConfig
{
    public RealtimeTurnDetectionConfig? Turn_Detection { get; set; }
}

public class RealtimeAudioOutputConfig
{
    public string? Voice { get; set; }
    public decimal? Speed { get; set; }
}

public class RealtimeTurnDetectionConfig
{
    public string Type { get; set; } = "";
    public bool Create_Response { get; set; }
    public bool Interrupt_Response { get; set; }
}

public class RealtimeReasoningConfig
{
    public string Effort { get; set; } = "";
}
