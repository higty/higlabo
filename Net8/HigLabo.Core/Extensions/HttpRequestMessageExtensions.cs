﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core;

public static class HttpRequestMessageExtensions
{
    public static async ValueTask<HttpRequestMessage> CloneAsync(this HttpRequestMessage request)
    {
        var clone = new HttpRequestMessage(request.Method, request.RequestUri);
        clone.Version = request.Version;
        if (request.Content != null)
        {
            clone.Content = await request.Content.CloneAsync().ConfigureAwait(false);
        }

        foreach (KeyValuePair<string, object?> prop in request.Options)
        {
            clone.Options.TryAdd(prop.Key, prop.Value);
        }
        foreach (KeyValuePair<string, IEnumerable<string>> header in request.Headers)
        {
            clone.Headers.TryAddWithoutValidation(header.Key, header.Value);
        }
        return clone;
    }
    public static async ValueTask<HttpContent?> CloneAsync(this HttpContent content)
    {
        if (content == null) return null;

        var ms = new MemoryStream();
        await content.CopyToAsync(ms).ConfigureAwait(false);
        ms.Position = 0;

        var clone = new StreamContent(ms);
        foreach (KeyValuePair<string, IEnumerable<string>> header in content.Headers)
        {
            clone.Headers.Add(header.Key, header.Value);
        }
        return clone;
    }
}
