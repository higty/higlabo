using System;
using System.IO;
using System.Text;

namespace HigLabo.Core;

public static class StreamExtensions
{
    public static byte[] ToByteArray(this Stream stream)
    {
        using var ms = new MemoryStream();
        stream.CopyTo(ms);
        return ms.ToArray();
    }

    public static void Write(this Stream stream, byte[] data)
    {
        stream.Write(data, 0, data.Length);
    }

    public static async ValueTask<Stream> ConvertEncodingStreamAsync(this Stream sourceStream, Encoding sourceEncoding, Encoding targetEncoding)
    {
        if (sourceStream == null) throw new ArgumentNullException(nameof(sourceStream));
        if (sourceEncoding == null) throw new ArgumentNullException(nameof(sourceEncoding));
        if (targetEncoding == null) throw new ArgumentNullException(nameof(targetEncoding));

        if (sourceStream.CanSeek)
        {
            sourceStream.Position = 0;
        }

        using var reader = new StreamReader(
            sourceStream,
            sourceEncoding,
            detectEncodingFromByteOrderMarks: true,
            leaveOpen: true);

        var text = await reader.ReadToEndAsync();

        var targetBytes = targetEncoding.GetBytes(text);
        var targetStream = new MemoryStream(targetBytes, writable: false);
        targetStream.Position = 0;
        return targetStream;
    }
}
