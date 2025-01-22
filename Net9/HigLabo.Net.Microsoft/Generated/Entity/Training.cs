using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/training?view=graph-rest-1.0
/// </summary>
public partial class Training
{
    public enum TrainingTrainingAvailabilityStatus
    {
        Unknown,
        NotAvailable,
        Available,
        Archive,
        Delete,
        UnknownFutureValue,
    }
    public enum TrainingSimulationContentSource
    {
        Unknown,
        Global,
        Tenant,
        UnknownFutureValue,
    }
    public enum TrainingTrainingType
    {
        Unknown,
        Phishing,
        UnknownFutureValue,
    }

    public TrainingTrainingAvailabilityStatus AvailabilityStatus { get; set; }
    public EmailIdentity? CreatedBy { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? Description { get; set; }
    public string? DisplayName { get; set; }
    public Int32? DurationInMinutes { get; set; }
    public bool? HasEvaluation { get; set; }
    public string? Id { get; set; }
    public EmailIdentity? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedDateTime { get; set; }
    public Simulation? Source { get; set; }
    public String[]? SupportedLocales { get; set; }
    public String[]? Tags { get; set; }
    public TrainingTrainingType Type { get; set; }
    public TrainingLanguageDetail[]? LanguageDetails { get; set; }
}
