namespace HigLabo.Bing
{
    public class TranslationAnswer
    {
        public Attribution[]? Attributions { get; set; } 
        public LinkAttribution[]? ContractualRules { get; set;} 
        public string Id { get; set; } = "";
        public string InLanguage { get; set; } = "";
        public string OriginalText { get; set; } = "";
        public string TranslatedLanguageName { get; set; } = "";
        public string TranslatedText { get; set; } = "";
    }
}
