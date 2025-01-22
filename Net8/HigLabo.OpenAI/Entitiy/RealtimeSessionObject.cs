using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI;

public class RealtimeSessionObject
{
    public ClientSecret Client_Secret { get; set; } = new ClientSecret();
    public List<string> Modalities { get; set; } = new List<string>();
    public string Instructions { get; set; } = "";
    public string Voice { get; set; } = "";
    public string Input_Audio_Format { get; set; } = "";
    public string Output_Audio_Format { get; set; } = "";
    public InputAudioTranscription? Input_Audio_Transcription { get; set; }
    public TurnDetection? Turn_Detection { get; set; }
    public List<Tool>? Tools { get; set; } = new List<Tool>();
    public string Tool_Choice { get; set; } = "";
    public double Temperature { get; set; } = 0.8; // Default value
    public string? Max_Response_Output_Tokens { get; set; } = "inf";
    public int? GetMaxResponseOutputTokens()
    {
        if (int.TryParse(this.Max_Response_Output_Tokens, out var x))
        {
            return x;
        }
        return null;
    }

    public class ClientSecret
    {
        public string Value { get; set; } = "";
        public long Expires_At { get; set; }
        public DateTimeOffset ExpireTime
        {
            get
            {
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Expires_At), TimeSpan.Zero);
            }
        }
    }

    public class InputAudioTranscription
    {
        public string Model { get; set; } = "";
    }

    public class TurnDetection
    {
        public string Type { get; set; } = "";
        public double Threshold { get; set; } = 0.5; // Default value
        public int Prefix_Padding_Ms { get; set; } = 300; // Default value in milliseconds
        public int Silence_Duration_Ms { get; set; } = 500; // Default value in milliseconds
    }

    public class Tool
    {
        public string Type { get; set; } = "";
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public Dictionary<string, object> Parameters { get; set; } = new Dictionary<string, object>();
    }
}
public class RealtimeSessionObjectResponse: RestApiResponse
{
    public ClientSecret Client_Secret { get; set; } = new ClientSecret();
    public List<string> Modalities { get; set; } = new List<string>();
    public string Instructions { get; set; } = "";
    public string Voice { get; set; } = "";
    public string Input_Audio_Format { get; set; } = "";
    public string Output_Audio_Format { get; set; } = "";
    public InputAudioTranscription? Input_Audio_Transcription { get; set; }
    public TurnDetection? Turn_Detection { get; set; }
    public List<Tool>? Tools { get; set; } = new List<Tool>();
    public string Tool_Choice { get; set; } = "";
    public double Temperature { get; set; } = 0.8; // Default value
    public string? Max_Response_Output_Tokens { get; set; } = "inf";
    public int? GetMaxResponseOutputTokens()
    {
        if (int.TryParse(this.Max_Response_Output_Tokens, out var x))
        {
            return x;
        }
        return null;
    }

    public class ClientSecret
    {
        public string Value { get; set; } = "";
        public long Expires_At { get; set; }
        public DateTimeOffset ExpireTime
        {
            get
            {
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Expires_At), TimeSpan.Zero);
            }
        }
    }

    public class InputAudioTranscription
    {
        public string Model { get; set; } = "";
    }

    public class TurnDetection
    {
        public string Type { get; set; } = "";
        public double Threshold { get; set; } = 0.5; // Default value
        public int Prefix_Padding_Ms { get; set; } = 300; // Default value in milliseconds
        public int Silence_Duration_Ms { get; set; } = 500; // Default value in milliseconds
    }

    public class Tool
    {
        public string Type { get; set; } = "";
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public Dictionary<string, object> Parameters { get; set; } = new Dictionary<string, object>();
    }
}
