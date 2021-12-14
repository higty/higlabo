using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;

namespace HigLabo.Net.Mail
{
    /// <summary>
    /// 
    /// </summary>
    internal class Cryptography
    {
        /// <summary>
        /// MD5ダイジェストに従って文字列を変換します。
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static String ToMd5DigestString(String text)
        {
            Byte[] bb = null;
            StringBuilder sb = new StringBuilder(64);

            bb = Encoding.UTF8.GetBytes(text);
            MD5 md5 = new MD5CryptoServiceProvider();
            bb = md5.ComputeHash(bb);
            for (int i = 0; i < bb.Length; i++)
            {
                sb.Append(bb[i].ToString("X2"));
            }
            return sb.ToString().ToLower();
        }
        /// <summary>
        /// Cram-MD5に従って文字列を変換します。
        /// </summary>
        /// <param name="text"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static String ToCramMd5String(String text, String key)
        {
            StringBuilder sb = new StringBuilder(128);
            Byte[] bb = null;
            HMACMD5 md5 = new HMACMD5(Encoding.UTF8.GetBytes(key));
            // Base64デコードしたチャレンジコードに対してパスワードをキーとしたHMAC-MD5ハッシュ値を計算する
            bb = md5.ComputeHash(Convert.FromBase64String(text));
            // 計算したHMAC-MD5ハッシュ値のbyte[]を16進表記の文字列に変換する
            for (int i = 0; i < bb.Length; i++)
            {
                sb.Append(bb[i].ToString("x02"));
            }
            return sb.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="signingCertificate"></param>
        /// <param name="encryptionCertificate"></param>
        /// <returns></returns>
        internal static byte[] GetSignature(Byte[] message, X509Certificate2 signingCertificate, X509Certificate2 encryptionCertificate)
        {
            throw new NotSupportedException();
            //SignedCms signedCms = new SignedCms(new ContentInfo(message), true);

            //CmsSigner cmsSigner = new CmsSigner(SubjectIdentifierType.IssuerAndSerialNumber, signingCertificate);
            //cmsSigner.IncludeOption = X509IncludeOption.WholeChain;

            //if (encryptionCertificate != null)
            //{
            //    cmsSigner.Certificates.Add(encryptionCertificate);
            //}

            //Pkcs9SigningTime signingTime = new Pkcs9SigningTime();
            //cmsSigner.SignedAttributes.Add(signingTime);

            //signedCms.ComputeSignature(cmsSigner, false);

            //return signedCms.Encode();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="encryptionCertificates"></param>
        /// <returns></returns>
        internal static byte[] EncryptMessage(Byte[] message, X509Certificate2Collection encryptionCertificates)
        {
            EnvelopedCms envelopedCms = new EnvelopedCms(new ContentInfo(message));

            CmsRecipientCollection recipients = new CmsRecipientCollection(SubjectIdentifierType.IssuerAndSerialNumber, encryptionCertificates);

            envelopedCms.Encrypt(recipients);

            return envelopedCms.Encode();
        }
    }
}
