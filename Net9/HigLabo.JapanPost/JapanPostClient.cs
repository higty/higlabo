#nullable enable
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.JapanPost
{
    /// <summary>
    /// Japan Post: Token / CodeSearch / AddressZip API クライアント
    /// </summary>
    public sealed class JapanPostClient
    {
        private readonly HttpClient _http;

        public string Host { get; set; }
        public string? BearerToken { get; private set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string XForwardedFor { get; set; }
        /// <summary>
        /// 任意のUser-Agentを設定。空またはnullの場合は送信されません。
        /// </summary>
        public string? UserAgent { get; set; }

        public JapanPostClient(HttpClient httpClient, string host, string clientId, string clientSecret, string xForwardedFor)
        {
            _http = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            Host = string.IsNullOrWhiteSpace(host) ? "api.da.pf.japanpost.jp" : host;
            ClientId = clientId ?? throw new ArgumentNullException(nameof(clientId));
            ClientSecret = clientSecret ?? throw new ArgumentNullException(nameof(clientSecret));
            XForwardedFor = xForwardedFor ?? throw new ArgumentNullException(nameof(xForwardedFor));
        }

        public JapanPostClient(HttpClient httpClient, string host, string clientId, string clientSecret, string xForwardedFor, string bearerToken)
            : this(httpClient, host, clientId, clientSecret, xForwardedFor)
        {
            if (string.IsNullOrWhiteSpace(bearerToken))
                throw new ArgumentException("Bearer token cannot be null or empty.", nameof(bearerToken));
            BearerToken = bearerToken;
        }

        public void SetBearerToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                throw new ArgumentException("token cannot be null or empty.", nameof(token));
            BearerToken = token;
        }

        private void AddCommonHeaders(HttpRequestMessage req)
        {
            if (!string.IsNullOrWhiteSpace(UserAgent))
            {
                req.Headers.UserAgent.ParseAdd(UserAgent);
            }
            if (!string.IsNullOrWhiteSpace(BearerToken))
            {
                req.Headers.Authorization = new AuthenticationHeaderValue("Bearer", BearerToken);
            }
        }

        // ===== Token =====
        public async Task<TokenGetResponse> GetTokenAsync(CancellationToken cancellationToken = default)
        {
            var parameter = new TokenGetParameter
            {
                ClientId = ClientId,
                SecretKey = ClientSecret,
                XForwardedFor = XForwardedFor
            };
            return await GetTokenAsync(parameter, cancellationToken).ConfigureAwait(false);
        }

        public async Task<TokenGetResponse> GetTokenAsync(TokenGetParameter parameter, CancellationToken cancellationToken = default)
        {
            if (parameter is null) throw new ArgumentNullException(nameof(parameter));
            parameter.Validate();

            var url = $"https://{Host}/api/v1/j/token";

            using var req = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new StringContent(JsonSerializer.Serialize(parameter, JsonOptions), Encoding.UTF8, "application/json")
            };
            req.Headers.TryAddWithoutValidation("x-forwarded-for", parameter.XForwardedFor);
            AddCommonHeaders(req);

            using var res = await _http.SendAsync(req, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);

            if (!res.IsSuccessStatusCode)
            {
                var bodyText = await res.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                throw new JapanPostApiException(res.StatusCode, $"Token API returned {(int)res.StatusCode}. Body: {bodyText}");
            }

            var stream = await res.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
            var token = await JsonSerializer.DeserializeAsync<TokenGetResponse>(stream, JsonOptions, cancellationToken).ConfigureAwait(false)
                        ?? throw new JapanPostApiException(res.StatusCode, "Empty or invalid token JSON.");

            return token;
        }

        public async Task<string> RefreshBearerTokenAsync(CancellationToken cancellationToken = default)
        {
            var token = await GetTokenAsync(cancellationToken).ConfigureAwait(false);
            SetBearerToken(token.Token);
            return token.Token;
        }

        // ===== CodeSearch =====
        public async Task<CodeSearchResponse> SearchAsync(string code, CancellationToken cancellationToken = default)
        {
            var p = new CodeSearchParameter
            {
                SearchCode = code,
            };
            return await SearchAsync(p, cancellationToken).ConfigureAwait(false);
        }

        public async Task<CodeSearchResponse> SearchAsync(CodeSearchParameter parameter, CancellationToken cancellationToken = default)
        {
            if (parameter is null) throw new ArgumentNullException(nameof(parameter));
            parameter.Validate();

            if (string.IsNullOrWhiteSpace(BearerToken))
            {
                await RefreshBearerTokenAsync(cancellationToken).ConfigureAwait(false);
            }

            HttpRequestMessage CreateRequest()
            {
                var qp = new List<string>();
                if (parameter.Page is not null) qp.Add($"page={parameter.Page}");
                if (parameter.Limit is not null) qp.Add($"limit={parameter.Limit}");
                if (!string.IsNullOrEmpty(parameter.EcUid)) qp.Add($"ec_uid={Uri.EscapeDataString(parameter.EcUid)}");
                if (parameter.ChoikiType is not null) qp.Add($"choikitype={parameter.ChoikiType}");
                if (parameter.SearchType is not null) qp.Add($"searchtype={parameter.SearchType}");

                var query = qp.Count > 0 ? "?" + string.Join("&", qp) : string.Empty;
                var url = $"https://{Host}/api/v1/searchcode/{Uri.EscapeDataString(parameter.SearchCode)}{query}";
                var req = new HttpRequestMessage(HttpMethod.Get, url);
                AddCommonHeaders(req);
                return req;
            }

            using var res = await SendWithAuthRetryAsync(CreateRequest, cancellationToken).ConfigureAwait(false);
            var stream = await res.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
            var result = await JsonSerializer.DeserializeAsync<CodeSearchResponse>(stream, JsonOptions, cancellationToken).ConfigureAwait(false)
                         ?? throw new JapanPostApiException(res.StatusCode, "Empty or invalid JSON response.");
            return result;
        }

        // ===== AddressZip =====
        public async Task<AddressZipResponse> AddressZipAsync(AddressZipParameter parameter, CancellationToken cancellationToken = default)
        {
            if (parameter is null) throw new ArgumentNullException(nameof(parameter));
            parameter.Validate();

            if (string.IsNullOrWhiteSpace(BearerToken))
            {
                await RefreshBearerTokenAsync(cancellationToken).ConfigureAwait(false);
            }

            HttpRequestMessage CreateRequest()
            {
                var url = $"https://{Host}/api/v1/addresszip";
                if (!string.IsNullOrWhiteSpace(parameter.EcUid))
                {
                    url += $"?ec_uid={Uri.EscapeDataString(parameter.EcUid!)}";
                }

                var json = JsonSerializer.Serialize(parameter, JsonOptions);
                var req = new HttpRequestMessage(HttpMethod.Post, url)
                {
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                };
                AddCommonHeaders(req);
                return req;
            }

            using var res = await SendWithAuthRetryAsync(CreateRequest, cancellationToken).ConfigureAwait(false);
            var stream = await res.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
            var result = await JsonSerializer.DeserializeAsync<AddressZipResponse>(stream, JsonOptions, cancellationToken).ConfigureAwait(false)
                         ?? throw new JapanPostApiException(res.StatusCode, "Empty or invalid addresszip JSON.");
            return result;
        }

        private async Task<HttpResponseMessage> SendWithAuthRetryAsync(Func<HttpRequestMessage> createRequest, CancellationToken cancellationToken)
        {
            using var req1 = createRequest();
            var res1 = await _http.SendAsync(req1, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
            if (IsAuthExpired(res1))
            {
                res1.Dispose();
                await RefreshBearerTokenAsync(cancellationToken).ConfigureAwait(false);
                using var req2 = createRequest();
                AddCommonHeaders(req2);
                var res2 = await _http.SendAsync(req2, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                return res2;
            }
            return res1;
        }

        private static bool IsAuthExpired(HttpResponseMessage res)
        {
            var code = (int)res.StatusCode;
            return code == 401 || code == 403;
        }

        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            PropertyNameCaseInsensitive = true,
            ReadCommentHandling = JsonCommentHandling.Skip,
            AllowTrailingCommas = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
    }

    // ===== DTOs =====
    public sealed class AddressRecord
    {
        [JsonPropertyName("dgacode")] public string? DgaCode { get; set; }
        [JsonPropertyName("zip_code")] public string? ZipCode { get; set; }
        [JsonPropertyName("pref_code")] public string? PrefCode { get; set; }
        [JsonPropertyName("pref_name")] public string? PrefName { get; set; }
        [JsonPropertyName("pref_kana")] public string? PrefKana { get; set; }
        [JsonPropertyName("pref_roma")] public string? PrefRoma { get; set; }
        [JsonPropertyName("city_code")] public string? CityCode { get; set; }
        [JsonPropertyName("city_name")] public string? CityName { get; set; }
        [JsonPropertyName("city_kana")] public string? CityKana { get; set; }
        [JsonPropertyName("city_roma")] public string? CityRoma { get; set; }
        [JsonPropertyName("town_name")] public string? TownName { get; set; }
        [JsonPropertyName("town_kana")] public string? TownKana { get; set; }
        [JsonPropertyName("town_roma")] public string? TownRoma { get; set; }
        [JsonPropertyName("biz_name")] public string? BizName { get; set; }
        [JsonPropertyName("biz_kana")] public string? BizKana { get; set; }
        [JsonPropertyName("biz_roma")] public string? BizRoma { get; set; }
        [JsonPropertyName("block_name")] public string? BlockName { get; set; }
        [JsonPropertyName("other_name")] public string? OtherName { get; set; }
        [JsonPropertyName("address")] public string? Address { get; set; }
        [JsonPropertyName("longitude")] public double? Longitude { get; set; }
        [JsonPropertyName("latitude")] public double? Latitude { get; set; }
    }

    public sealed class CodeSearchParameter
    {
        public string SearchCode { get; init; } = string.Empty;
        public int? Page { get; init; }
        public int? Limit { get; init; }
        public string? EcUid { get; init; }
        public int? ChoikiType { get; init; }
        public int? SearchType { get; init; }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(SearchCode))
                throw new ArgumentException("SearchCode is required.", nameof(SearchCode));
            if (Limit is < 1 or > 1000)
                throw new ArgumentOutOfRangeException(nameof(Limit), "Limit must be between 1 and 1000.");
            if (ChoikiType is not null && ChoikiType is < 1 or > 2)
                throw new ArgumentOutOfRangeException(nameof(ChoikiType), "ChoikiType must be 1 or 2.");
            if (SearchType is not null && SearchType is < 1 or > 2)
                throw new ArgumentOutOfRangeException(nameof(SearchType), "SearchType must be 1 or 2.");
        }
    }

    public sealed class CodeSearchResponse
    {
        [JsonPropertyName("addresses")] public AddressRecord[]? Addresses { get; set; }
        [JsonPropertyName("searchtype")] public string? Searchtype { get; set; }
        [JsonPropertyName("limit")] public int? Limit { get; set; }
        [JsonPropertyName("count")] public int? Count { get; set; }
        [JsonPropertyName("page")] public int? Page { get; set; }
    }

    public sealed class AddressZipParameter
    {
        [JsonIgnore] public string? EcUid { get; init; }
        [JsonPropertyName("pref_code")] public string? PrefCode { get; init; }
        [JsonPropertyName("pref_name")] public string? PrefName { get; init; }
        [JsonPropertyName("pref_kana")] public string? PrefKana { get; init; }
        [JsonPropertyName("pref_roma")] public string? PrefRoma { get; init; }
        [JsonPropertyName("city_code")] public string? CityCode { get; init; }
        [JsonPropertyName("city_name")] public string? CityName { get; init; }
        [JsonPropertyName("city_kana")] public string? CityKana { get; init; }
        [JsonPropertyName("city_roma")] public string? CityRoma { get; init; }
        [JsonPropertyName("town_name")] public string? TownName { get; init; }
        [JsonPropertyName("town_kana")] public string? TownKana { get; init; }
        [JsonPropertyName("town_roma")] public string? TownRoma { get; init; }
        [JsonPropertyName("freeword")] public string? Freeword { get; init; }
        [JsonPropertyName("flg_getcity")] public int? FlgGetCity { get; init; }
        [JsonPropertyName("flg_getpref")] public int? FlgGetPref { get; init; }
        [JsonPropertyName("page")] public int? Page { get; init; }
        [JsonPropertyName("limit")] public int? Limit { get; init; }

        public void Validate()
        {
            if (Limit is < 1 or > 1000)
                throw new ArgumentOutOfRangeException(nameof(Limit), "Limit must be between 1 and 1000.");
            if (FlgGetCity is not null && FlgGetCity is < 0 or > 1)
                throw new ArgumentOutOfRangeException(nameof(FlgGetCity), "FlgGetCity must be 0 or 1.");
            if (FlgGetPref is not null && FlgGetPref is < 0 or > 1)
                throw new ArgumentOutOfRangeException(nameof(FlgGetPref), "FlgGetPref must be 0 or 1.");
        }
    }

    public sealed class AddressZipResponse
    {
        [JsonPropertyName("addresses")] public AddressRecord[]? Addresses { get; set; }
        [JsonPropertyName("level")] public int? Level { get; set; }
        [JsonPropertyName("limit")] public int? Limit { get; set; }
        [JsonPropertyName("count")] public int? Count { get; set; }
        [JsonPropertyName("page")] public int? Page { get; set; }
    }

    public sealed class TokenGetParameter
    {
        [JsonPropertyName("grant_type")] public string GrantType { get; set; } = "client_credentials";
        [JsonPropertyName("client_id")] public string ClientId { get; set; } = string.Empty;
        [JsonPropertyName("secret_key")] public string SecretKey { get; set; } = string.Empty;
        [JsonIgnore] public string XForwardedFor { get; set; } = string.Empty;

        public void Validate()
        {
            if (GrantType != "client_credentials")
                throw new ArgumentException("GrantType must be 'client_credentials'.", nameof(GrantType));
            if (string.IsNullOrWhiteSpace(ClientId))
                throw new ArgumentException("ClientId is required.", nameof(ClientId));
            if (string.IsNullOrWhiteSpace(SecretKey))
                throw new ArgumentException("SecretKey is required.", nameof(SecretKey));
            if (string.IsNullOrWhiteSpace(XForwardedFor))
                throw new ArgumentException("XForwardedFor is required.", nameof(XForwardedFor));
        }
    }

    public sealed class TokenGetResponse
    {
        [JsonPropertyName("scope")] public string Scope { get; set; } = string.Empty;
        [JsonPropertyName("token_type")] public string TokenType { get; set; } = string.Empty;
        [JsonPropertyName("expires_in")] public int ExpiresIn { get; set; }
        [JsonPropertyName("token")] public string Token { get; set; } = string.Empty;
    }

    public sealed class JapanPostApiException : Exception
    {
        public System.Net.HttpStatusCode StatusCode { get; }
        public JapanPostApiException(System.Net.HttpStatusCode statusCode, string message)
            : base(message) => StatusCode = statusCode;
    }
}
