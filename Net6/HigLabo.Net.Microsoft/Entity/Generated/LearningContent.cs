using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/learningcontent?view=graph-rest-1.0
    /// </summary>
    public partial class LearningContent
    {
        public String[]? AdditionalTags { get; set; }
        public string? ContentWebUrl { get; set; }
        public String[]? Contributors { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? Duration { get; set; }
        public string? ExternalId { get; set; }
        public string? Format { get; set; }
        public string? Id { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsPremium { get; set; }
        public bool? IsSearchable { get; set; }
        public string? LanguageTag { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public Int32? NumberOfPages { get; set; }
        public String[]? SkillTags { get; set; }
        public string? SourceName { get; set; }
        public string? ThumbnailWebUrl { get; set; }
        public string? Title { get; set; }
    }
}
