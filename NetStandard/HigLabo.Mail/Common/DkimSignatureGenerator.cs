using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using HigLabo.Net;
using System.IO;

namespace HigLabo.Net.Smtp
{
    /// <summary>
    /// 
    /// </summary>
    public enum DkimCanonicalization
    {
        /// <summary>
        /// 
        /// </summary>
        Simple,
        /// <summary>
        /// 
        /// </summary>
        Relaxed
    }
    /// <summary>
    /// 
    /// </summary>
    public enum SigninAlgorithm
    {
        /// <summary>
        /// 
        /// </summary>
        RSASha1,
        /// <summary>
        /// 
        /// </summary>
        RSASha256
    }

    /// <summary>
    /// 
    /// </summary>
    public class DkimSignatureGenerator
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly String SignatureKey = "DKIM-Signature";
        /// <summary>
        /// 
        /// </summary>
        private readonly String _Domain;
        /// <summary>
        /// 
        /// </summary>
        private readonly String _Selector;
        /// <summary>
        /// 
        /// </summary>
        public DkimCanonicalization HeaderCanonicalization { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DkimCanonicalization BodyCanonicalization { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<String> HeaderKeys { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public SigninAlgorithm SigninAlgorithm { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Encoding Encoding { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public X509Certificate2 Certificate { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pfxFilePath"></param>
        /// <param name="pwd"></param>
        /// <param name="domain"></param>
        /// <param name="selector"></param>
        /// <param name="signHeaders"></param>
        public DkimSignatureGenerator(String pfxFilePath, String password, String domain, String selector, String[] headerKeys)
        {
            if (String.IsNullOrEmpty(domain) == true) throw new ArgumentException("Domain must not be null or empty.");
            if (String.IsNullOrEmpty(selector) == true) throw new ArgumentException("Selector must not be null or empty.");
            if (String.IsNullOrEmpty(pfxFilePath) == true) throw new ArgumentNullException("pfxFilePath must not be null.");

            Certificate = new X509Certificate2(pfxFilePath, password, X509KeyStorageFlags.Exportable);

            if (Certificate.HasPrivateKey == false)
            {
                throw new InvalidOperationException("This file does not has PrivateKey.FilePath is " + pfxFilePath);
            }
            _Domain = domain;
            _Selector = selector;
            this.HeaderKeys = new List<string>(headerKeys);
            if (this.HeaderKeys.Count == 0)
            {
                this.HeaderKeys.Add("From");
            }
            this.Encoding = Encoding.UTF8;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public String GenerateDkimHeaderValue(String body)
        {
            TimeSpan t = DateTime.Now.ToUniversalTime() - DateTime.SpecifyKind(DateTime.Parse("2000/01/01 00:00:00"), DateTimeKind.Utc);

            StringBuilder signatureValue = new StringBuilder();

            // 
            signatureValue.Append("v=1;");

            // algorithm 
            signatureValue.Append(" a=");
            signatureValue.Append(this.GetAlgorithmName());
            signatureValue.Append(";");

            // Canonicalization
            signatureValue.Append(" c=");
            signatureValue.Append(this.HeaderCanonicalization.ToString().ToLower());
            signatureValue.Append("/");
            signatureValue.Append(this.BodyCanonicalization.ToString().ToLower());
            signatureValue.Append(";");

            // signin domain
            signatureValue.Append(" d=");
            signatureValue.Append(this._Domain);
            signatureValue.Append(";");

            // public key location
            signatureValue.Append(" q=dns;");

            // selector
            signatureValue.Append(" s=");
            signatureValue.Append(this._Selector);
            signatureValue.Append(";");

            // time sent
            signatureValue.Append(" t=");
            signatureValue.Append((int)t.TotalSeconds);
            signatureValue.Append(";");

            // headers to signed
            signatureValue.Append(" h=");
            foreach (var key in this.HeaderKeys)
            {
                signatureValue.Append(key);
                signatureValue.Append(":");
            }
            signatureValue.Length--;
            signatureValue.Append(";");
            // hash of body
            signatureValue.Append(" bh=");
            signatureValue.Append(this.SignBody(body));
            signatureValue.Append(";");

            signatureValue.Append(" b=");

            // i=identity
            // not supported

            // l=body length
            // not supported

            // x=copied header fields
            // not supported

            return signatureValue.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="header"></param>
        /// <returns></returns>
        public string GenerateSignature(List<SmtpMailHeader> headers)
        {
            if (headers == null) throw new ArgumentNullException("header must not be null.");

            var headersText = this.CanonicalizeHeaders(headers);
            return Convert.ToBase64String(this.Sign(this.Encoding.GetBytes(headersText), this.SigninAlgorithm));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public String SignBody(String body)
        {
            var cb = this.CanonicalizeBody(body);

            return Convert.ToBase64String(DkimSignatureGenerator.Hash(Encoding.GetBytes(cb), this.SigninAlgorithm));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="algorithm"></param>
        /// <returns></returns>
        public Byte[] Sign(Byte[] data, SigninAlgorithm algorithm)
        {
            if (data == null)
            {
                throw new ArgumentNullException("Sign data.");
            }
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(this.Certificate.PrivateKey.ToXmlString(true));
                byte[] signature = rsa.SignData(data, GetHashName(this.SigninAlgorithm));
                return signature;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="algorithm"></param>
        /// <returns></returns>
        private String GetHashName(SigninAlgorithm algorithm)
        {
            switch (algorithm)
            {
                case SigninAlgorithm.RSASha1:
                    {
                        return "SHA1";
                    }
                case SigninAlgorithm.RSASha256:
                    {
                        return "SHA256";
                    }
                default:
                    {
                        throw new ArgumentException("Invalid SigningAlgorithm value", "algorithm");
                    }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private String GetAlgorithmName()
        {
            switch (this.SigninAlgorithm)
            {
                case SigninAlgorithm.RSASha1:
                    return "rsa-sha1";
                case SigninAlgorithm.RSASha256:
                    return "rsa-sha256";
                default:
                    throw new InvalidOperationException("Invalid SigninAlgorithm.");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="headers"></param>
        /// <param name="type"></param>
        /// <param name="headersToSign"></param>
        /// <returns></returns>
        public String CanonicalizeHeaders(List<SmtpMailHeader> headers)
        {
            if (headers == null) throw new ArgumentNullException("headers");

            var d = new Dictionary<String, SmtpMailHeader>();
            for (int i = 0; i < headers.Count; i++)
            {
                d[headers[i].Key] = headers[i];
            }
            if (this.HeaderKeys.Contains(DkimSignatureGenerator.SignatureKey) == false)
            {
                this.HeaderKeys.Add(DkimSignatureGenerator.SignatureKey);
            }

            ValidateHeaders(headers);

            var sb = new StringBuilder();

            switch (this.HeaderCanonicalization)
            {
                case DkimCanonicalization.Simple:
                    {
                        foreach (var key in this.HeaderKeys)
                        {
                            if (key == null)
                            {
                                continue;
                            }
                            var header = d[key];
                            sb.Append(key);
                            sb.Append(':');
                            sb.Append(' ');
                            sb.Append(header.Value);
                            sb.Append(MimeWriter.NewLine);
                        }
                        sb.Length -= MimeWriter.NewLine.Length;
                        break;
                    }
                case DkimCanonicalization.Relaxed:
                    {
                        foreach (var key in this.HeaderKeys)
                        {
                            if (key == null)
                            {
                                continue;
                            }

                            var header = d[key];
                            sb.Append(key.Trim());
                            sb.Append(':');
                            sb.Append(header.Value.Trim());

                            sb.Append(MimeWriter.NewLine);
                        }
                        sb.Length -= MimeWriter.NewLine.Length;
                        break;
                    }
                default:
                    {
                        throw new ArgumentException("Invalid canonicalization type.");
                    }
            }

            return sb.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="headers"></param>
        /// <param name="headersToSign"></param>
        private void ValidateHeaders(List<SmtpMailHeader> headers)
        {
            var d = new Dictionary<String, SmtpMailHeader>();
            for (int i = 0; i < headers.Count; i++)
            {
                d[headers[i].Key] = headers[i];
            }
            if (d.ContainsKey("From") == false) throw new InvalidOperationException("The From header must not be null.Please set From property of SmtpMessage object.");
            var invalidHeaders = this.HeaderKeys.Where(key => d.ContainsKey(key) == false).ToList();
            if (invalidHeaders.Count > 0) throw new ArgumentException("The following headers do not exist. " + String.Join(", ", invalidHeaders.ToArray()));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="body"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public String CanonicalizeBody(String body)
        {
            if (body == null)
            {
                body = string.Empty;
            }

            var sb = new StringBuilder(body.Length + MimeWriter.NewLine.Length);

            switch (this.BodyCanonicalization)
            {
                case DkimCanonicalization.Relaxed:
                    {
                        using (var reader = new StringReader(body))
                        {
                            string line;
                            int emptyLineCount = 0;

                            while ((line = reader.ReadLine()) != null)
                            {

                                if (line == string.Empty)
                                {
                                    emptyLineCount++;
                                    continue;
                                }

                                while (emptyLineCount > 0)
                                {
                                    sb.AppendLine();
                                    emptyLineCount--;
                                }
                                sb.AppendLine(line.TrimEnd());
                            }
                        }

                        break;
                    }
                case DkimCanonicalization.Simple:
                    {
                        using (var reader = new StringReader(body))
                        {
                            string line;
                            int emptyLineCount = 0;

                            while ((line = reader.ReadLine()) != null)
                            {
                                if (line == string.Empty)
                                {
                                    emptyLineCount++;
                                    continue;
                                }
                                while (emptyLineCount > 0)
                                {
                                    sb.AppendLine();
                                    emptyLineCount--;
                                }
                                sb.AppendLine(line);
                            }
                        }
                        if (sb.Length == 0)
                        {
                            sb.AppendLine();
                        }
                        break;
                    }
                default:
                    {
                        throw new ArgumentException("Invalid canonicalization type.");
                    }
            }

            return sb.ToString();

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="algorithm"></param>
        /// <returns></returns>
        public static Byte[] Hash(Byte[] data, SigninAlgorithm algorithm)
        {
            if (data == null)
            {
                throw new ArgumentNullException("Hash data.");
            }
            using (var hash = GetHash(algorithm))
            {
                return hash.ComputeHash(data);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="algorithm"></param>
        /// <returns></returns>
        private static HashAlgorithm GetHash(SigninAlgorithm algorithm)
        {
            switch (algorithm)
            {
                case SigninAlgorithm.RSASha1: return new SHA1Managed();
                case SigninAlgorithm.RSASha256: return new SHA256Managed();
                default: throw new ArgumentException("Invalid SigningAlgorithm value", "algorithm");
            }
        }
    }
}
