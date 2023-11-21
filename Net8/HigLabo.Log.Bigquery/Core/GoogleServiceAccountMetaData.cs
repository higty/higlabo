using Google.Apis.Auth.OAuth2;
using Google.Apis.Bigquery.v2;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyBetter.Core
{
    public class GoogleServiceAccountMetaData
    {
        public String Project_ID { get; set; } = "";
        public String Private_Key_ID { get; set; } = "";
        public String Private_Key { get; set; } = "";
        public String Client_Email { get; set; } = "";
        public String Client_ID { get; set; } = "";
        public String Auth_Uri { get; set; } = "";
        public String Token_Uri { get; set; } = "";
        public String Auth_Provider_X509_Cert_Url { get; set; } = "";
        public String Client_X509_Cert_Url { get; set; } = "";

        public BigqueryService CreateBigqueryService(String applicationName)
        {
            var data = this;
            var credential = new ServiceAccountCredential(new ServiceAccountCredential.Initializer(data.Client_Email)
            {
                Scopes = new[]
                {
                    BigqueryService.Scope.Bigquery,
                    BigqueryService.Scope.BigqueryInsertdata,
                }
            }.FromPrivateKey(data.Private_Key));
            var sv = new BigqueryService(new BaseClientService.Initializer
            {
                ApplicationName = applicationName,
                HttpClientInitializer = credential,
            });
            return sv;
        }
    }
}
