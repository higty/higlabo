namespace HigLabo.OpenAI
{
    public class FineTuningIntegrationObject
    {
        public string Type { get; set; } = "";
        public WaitAndBiaseObject Wandb { get; set; } = new();
    }
}
