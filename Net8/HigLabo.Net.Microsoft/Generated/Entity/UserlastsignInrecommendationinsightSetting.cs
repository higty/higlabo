using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/userlastsigninrecommendationinsightsetting?view=graph-rest-1.0
/// </summary>
public partial class UserlastsignInrecommendationinsightSetting
{
    public enum UserlastsignInrecommendationinsightSettingUserSignInRecommendationScope
    {
        Tenant,
        Application,
        UnknownFutureValue,
    }

    public string? RecommendationLookBackDuration { get; set; }
    public UserlastsignInrecommendationinsightSettingUserSignInRecommendationScope SignInScope { get; set; }
}
