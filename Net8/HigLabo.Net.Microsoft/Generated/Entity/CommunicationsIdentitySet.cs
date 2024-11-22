using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/communicationsidentityset?view=graph-rest-1.0
/// </summary>
public partial class CommunicationsIdentitySet
{
    public enum CommunicationsIdentitySetEndpointType
    {
        Default,
        Voicemail,
        SkypeForBusiness,
        SkypeForBusinessVoipPhone,
        UnknownFutureValue,
    }

    public CommunicationsApplicationIdentity? Application { get; set; }
    public CommunicationsApplicationInstanceIdentity? ApplicationInstance { get; set; }
    public CommunicationsUserIdentity? AssertedIdentity { get; set; }
    public AzureCommunicationServicesUserIdentity? AzureCommunicationServicesUser { get; set; }
    public CommunicationsEncryptedIdentity? Encrypted { get; set; }
    public CommunicationsIdentitySetEndpointType EndpointType { get; set; }
    public CommunicationsGuestIdentity? Guest { get; set; }
    public CommunicationsUserIdentity? OnPremises { get; set; }
    public CommunicationsPhoneIdentity? Phone { get; set; }
    public CommunicationsUserIdentity? User { get; set; }
}
