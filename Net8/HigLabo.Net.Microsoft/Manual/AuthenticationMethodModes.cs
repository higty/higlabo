using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.Microsoft;

public enum AuthenticationMethodModes
{
    SoftwareOath,
    DeviceBasedPush,
    FederatedSingleFactor,
    TemporaryAccessPassMultiUse,
    TemporaryAccessPassOneTime,
    X509CertificateSingleFactor,
    WindowsHelloForBusiness,
    X509CertificateMultiFactor,
    Email,
    MicrosoftAuthenticatorPush,
    Sms,
    Fido2,
    UnknownFutureValue,
    FederatedMultiFactor,
}
