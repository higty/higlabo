using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/payload?view=graph-rest-1.0
/// </summary>
public partial class Payload
{
    public enum PayloadPayloadBrand
    {
        Unknown,
        Other,
        AmericanExpress,
        CapitalOne,
        Dhl,
        DocuSign,
        Dropbox,
        Facebook,
        FirstAmerican,
        Microsoft,
        Netflix,
        Scotiabank,
        SendGrid,
        StewartTitle,
        Tesco,
        WellsFargo,
        SyrinxCloud,
        Adobe,
        Teams,
        Zoom,
        UnknownFutureValue,
    }
    public enum PayloadPayloadComplexity
    {
        Unknown,
        Low,
        Medium,
        High,
        UnknownFutureValue,
    }
    public enum PayloadPayloadIndustry
    {
        Unknown,
        Other,
        Banking,
        BusinessServices,
        ConsumerServices,
        Education,
        Energy,
        Construction,
        Consulting,
        FinancialServices,
        Government,
        Hospitality,
        Insurance,
        Legal,
        CourierServices,
        IT,
        Healthcare,
        Manufacturing,
        Retail,
        Telecom,
        RealEstate,
        UnknownFutureValue,
    }
    public enum PayloadPayloadDeliveryPlatform
    {
        Unknown,
        Sms,
        Email,
        Teams,
        UnknownFutureValue,
    }
    public enum PayloadSimulationAttackType
    {
        Unknown,
        Social,
        Cloud,
        Endpoint,
        UnknownFutureValue,
    }
    public enum PayloadSimulationContentSource
    {
        Unknown,
        Global,
        Tenant,
        UnknownFutureValue,
    }
    public enum PayloadSimulationContentStatus
    {
        Unknown,
        Draft,
        Ready,
        Archive,
        Delete,
        UnknownFutureValue,
    }
    public enum PayloadSimulationAttackTechnique
    {
        Unknown,
        CredentialHarvesting,
        AttachmentMalware,
        DriveByUrl,
        LinkInAttachment,
        LinkToMalwareFile,
        UnknownFutureValue,
        OAuthConsentGrant,
    }
    public enum PayloadPayloadTheme
    {
        Unknown,
        Other,
        AccountActivation,
        AccountVerification,
        Billing,
        CleanUpMail,
        Controversial,
        DocumentReceived,
        Expense,
        Fax,
        FinanceReport,
        IncomingMessages,
        Invoice,
        ItemReceived,
        LoginAlert,
        MailReceived,
        Password,
        Payment,
        Payroll,
        PersonalizedOffer,
        Quarantine,
        RemoteWork,
        ReviewMessage,
        SecurityUpdate,
        ServiceSuspended,
        SignatureRequired,
        UpgradeMailboxStorage,
        VerifyMailbox,
        Voicemail,
        Advertisement,
        EmployeeEngagement,
        UnknownFutureValue,
    }

    public PayloadPayloadBrand Brand { get; set; }
    public PayloadPayloadComplexity Complexity { get; set; }
    public EmailIdentity? CreatedBy { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? Description { get; set; }
    public PayloadDetail? Detail { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public PayloadPayloadIndustry Industry { get; set; }
    public bool? IsAutomated { get; set; }
    public bool? IsControversial { get; set; }
    public bool? IsCurrentEvent { get; set; }
    public string? Language { get; set; }
    public EmailIdentity? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedDateTime { get; set; }
    public String[]? PayloadTags { get; set; }
    public PayloadPayloadDeliveryPlatform Platform { get; set; }
    public Double? PredictedCompromiseRate { get; set; }
    public Simulation? SimulationAttackType { get; set; }
    public PayloadSimulationContentSource Source { get; set; }
    public PayloadSimulationContentStatus Status { get; set; }
    public Simulation? Technique { get; set; }
    public PayloadPayloadTheme Theme { get; set; }
}
