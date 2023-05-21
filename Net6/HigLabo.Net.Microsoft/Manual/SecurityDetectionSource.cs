using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.Microsoft
{
    public enum SecurityDetectionSource
    {
        Unknown,
        MicrosoftDefenderForEndpoint,
        Antivirus,
        SmartScreen,
        CustomTi,
        MicrosoftDefenderForOffice365,
        AutomatedInvestigation,
        MicrosoftThreatExperts,
        CustomDetection,
        MicrosoftDefenderForIdentity,
        CloudAppSecurity,
        Microsoft365Defender,
        AzureAdIdentityProtection,
        Manual,
        MicrosoftDataLossPrevention,
        AppGovernancePolicy,
        AppGovernanceDetection,
        UnknownFutureValue,
    }
}
