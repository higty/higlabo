using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/trainingsetting?view=graph-rest-1.0
/// </summary>
public partial class TrainingSetting
{
    public enum TrainingSettingTrainingSettingType
    {
        MicrosoftCustom,
        MicrosoftManaged,
        NoTraining,
        Custom,
        UnknownFutureValue,
    }

    public TrainingSettingTrainingSettingType SettingType { get; set; }
}
