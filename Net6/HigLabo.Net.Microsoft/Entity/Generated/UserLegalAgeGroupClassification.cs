
namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/user?view=graph-rest-1.0
    /// </summary>
    public enum UserLegalAgeGroupClassification
    {
        Null,
        MinorWithOutParentalConsent,
        MinorWithParentalConsent,
        MinorNoParentalConsentRequired,
        NotAdult,
        Adult,
    }
}
