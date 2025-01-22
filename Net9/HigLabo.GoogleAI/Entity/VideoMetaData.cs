namespace HigLabo.GoogleAI;

public class VideoMetaData
{
    public class Offset
    {
        public int Seconds { get; set; }
        public int Nanos { get; set; }
    }
    public Offset StartOffset { get; set; } = new();
    public Offset EndOffset { get; set; } = new();
}
