using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using HigLabo.Core;

namespace HigLabo.Security
{
    /// <summary>
    /// 文字列を暗号化・復号化する機能を提供します。
    /// </summary>
    public static class AesManagedExtensions
    {
        public static readonly AesManagedExtensionsSettings Settings = new AesManagedExtensionsSettings();

        public static Byte[] Encrypt(this AesManaged aes, Byte[] source, Byte[] key)
        {
            return Encrypt(aes, source, key, key);
        }
        public static Byte[] Encrypt(this AesManaged aes, Byte[] source, Byte[] key, Byte[] iv)
        {
            var bytesKey = ResizeBytesArray(key, aes.Key.Length);
            var bytesIv = ResizeBytesArray(iv, aes.IV.Length);

            using (var msOut = new MemoryStream())
            using (var cryptStreem = new CryptoStream(msOut, aes.CreateEncryptor(bytesKey, bytesIv), CryptoStreamMode.Write))
            {
                cryptStreem.Write(source, 0, source.Length);
                cryptStreem.FlushFinalBlock();
                return msOut.ToArray();
            }
        }
        public static Byte[] Decrypt(this AesManaged aes, Byte[] source, Byte[] key)
        {
            return Decrypt(aes, source, key, key);
        }
        public static Byte[] Decrypt(this AesManaged aes, Byte[] source, Byte[] key, Byte[] iv)
        {
            var bytesKey = ResizeBytesArray(key, aes.Key.Length);
            var bytesIv = ResizeBytesArray(iv, aes.IV.Length);
            using (var msIn = new MemoryStream(source))
            using (var cryptStreem = new CryptoStream(msIn, aes.CreateDecryptor(bytesKey, bytesIv), CryptoStreamMode.Read))
            {
                MemoryStream m = new MemoryStream();
                cryptStreem.CopyTo(m);
                return m.ToArray();
            }
        }
        public static String EncryptToBase64String(this AesManaged aes, String source, String key)
        {
            var bkey = Settings.KeyEncoding.GetBytes(key);
            var bb = aes.Encrypt(Settings.Encoding.GetBytes(source), bkey, bkey);
            return Convert.ToBase64String(bb);
        }
        public static String EncryptToHexString(this AesManaged aes, String source, String key)
        {
            var bkey = Settings.KeyEncoding.GetBytes(key);
            var bb = aes.Encrypt(Settings.Encoding.GetBytes(source), bkey, bkey);
            return ByteToHexString(bb);
        }
        public static String DecryptFromBase64String(this AesManaged aes, String source, String key)
        {
            var bkey = Settings.KeyEncoding.GetBytes(key);
            var bb = aes.Decrypt(Convert.FromBase64String(source), bkey, bkey);
            return Settings.Encoding.GetString(bb);
        }
        public static String DecryptFromHexString(this AesManaged aes, String source, String key)
        {
            var bkey = Settings.KeyEncoding.GetBytes(key);
            var bb = aes.Decrypt(HexStringToByte(source), bkey, bkey);
            return Settings.Encoding.GetString(bb);
        }

        private static byte[] ResizeBytesArray(byte[] bytes, int newSize)
        {
            var newBytes = new byte[newSize];
            if (bytes.Length <= newSize)
            {
                for (var i = 0; i < bytes.Length; i++)
                {
                    newBytes[i] = bytes[i];
                }
            }
            else
            {
                var pos = 0;
                foreach (var t in bytes)
                {
                    newBytes[pos++] ^= t;
                    if (pos >= newBytes.Length)
                    {
                        pos = 0;
                    }
                }
            }
            return newBytes;
        }
        private static byte[] HexStringToByte(string hex)
        {
            var j = 0;
            if (hex == null)
            {
                return null;
            }
            var bytes = new Byte[hex.Length / 2];
            for (var i = 0; i < hex.Length; i += 2)
            {
                bytes[j] = Byte.Parse(String.Concat(hex[i], hex[i + 1]), System.Globalization.NumberStyles.HexNumber);
                j++;
            }
            return bytes;
        }
        private static string ByteToHexString(byte[] bytes)
        {
            var sb = new StringBuilder();
            if (bytes != null)
            {
                for (var i = 0; i < bytes.Length; i++)
                {
                    sb.Append(bytes[i].ToString("X2"));
                }
            }
            return sb.ToString();
        }
    }
}
