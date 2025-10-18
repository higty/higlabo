using System;
using System.Security.Cryptography;
using System.Text.Json;

namespace HigLabo.Core;

public class JwksKey
{
    public string kty { get; set; } = "RSA";
    public string kid { get; set; } = "";
    public string use { get; set; } = "sig";
    public string alg { get; set; } = "RS256";
    public string n { get; set; } = "";
    public string e { get; set; } = "";
}

public class Jwks
{
    public List<JwksKey> keys { get; set; } = new();
}

public static class JwksGenerator
{
    public static string CreateJwksJson(RSA rsa, string keyId)
    {
        var parameters = rsa.ExportParameters(false);

        string n = Base64UrlEncode(parameters.Modulus!);
        string e = Base64UrlEncode(parameters.Exponent!);

        var jwk = new JwksKey
        {
            kid = keyId,
            n = n,
            e = e
        };

        var jwks = new Jwks { keys = new List<JwksKey> { jwk } };

        return JsonSerializer.Serialize(jwks, new JsonSerializerOptions { WriteIndented = true });
    }

    private static string Base64UrlEncode(byte[] input)
    {
        return Convert.ToBase64String(input)
            .Replace("+", "-")
            .Replace("/", "_")
            .TrimEnd('=');
    }
}