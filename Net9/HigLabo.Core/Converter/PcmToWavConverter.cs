using System.Text;

namespace HigLabo.Converter;

public class PcmToWavConverter
{
    private int _sampleRateHz;
    private short _channels;
    private short _bitsPerSample;

    public int SampleRateHz
    {
        get => _sampleRateHz;
        set
        {
            if (value <= 0)
                throw new InvalidOperationException("Sample rate must be a positive integer.");
            _sampleRateHz = value;
        }
    }

    public short Channels
    {
        get => _channels;
        set
        {
            if (value <= 0)
                throw new InvalidOperationException("Channels must be greater than 0.");
            _channels = value;
        }
    }

    public short BitsPerSample
    {
        get => _bitsPerSample;
        set
        {
            if (value != 8 && value != 16 && value != 24 && value != 32)
                throw new InvalidOperationException("Bits per sample must be 8, 16, 24, or 32.");
            _bitsPerSample = value;
        }
    }

    public PcmToWavConverter(int sampleRateHz, short channels, short bitsPerSample)
    {
        SampleRateHz = sampleRateHz;
        Channels = channels;
        BitsPerSample = bitsPerSample;
    }

    public byte[] Convert(byte[] pcmData)
    {
        int blockAlign = this.Channels * (this.BitsPerSample / 8);
        int byteRate = this.SampleRateHz * blockAlign;

        int alignedLength = pcmData.Length - (pcmData.Length % blockAlign);

        int dataChunkSize = alignedLength;
        int riffChunkSize = 36 + dataChunkSize;

        using (var ms = new MemoryStream(44 + dataChunkSize))
        using (var bw = new BinaryWriter(ms, Encoding.ASCII, leaveOpen: true))
        {
            // ---- RIFFヘッダー ----
            bw.Write(Encoding.ASCII.GetBytes("RIFF"));
            bw.Write(riffChunkSize);
            bw.Write(Encoding.ASCII.GetBytes("WAVE"));

            // ---- fmt チャンク ----
            bw.Write(Encoding.ASCII.GetBytes("fmt "));
            bw.Write(16);
            bw.Write((short)1);
            bw.Write(this.Channels);
            bw.Write(this.SampleRateHz);
            bw.Write(byteRate);
            bw.Write((short)blockAlign);
            bw.Write(this.BitsPerSample);

            // ---- data チャンク ----
            bw.Write(Encoding.ASCII.GetBytes("data"));
            bw.Write(dataChunkSize);
            bw.Write(pcmData, 0, alignedLength);

            bw.Flush();
            return ms.ToArray();
        }
    }

    /// <summary>
    /// Convert raw PCM Stream to WAV MemoryStream (positioned at 0).
    /// </summary>
    public Stream Convert(Stream pcmStream)
    {
        if (pcmStream == null) throw new ArgumentNullException(nameof(pcmStream));

        var wavStream = new MemoryStream();
        Convert(pcmStream, wavStream, resetOutputPosition: true);
        return wavStream;
    }

    /// <summary>
    /// Convert raw PCM Stream to WAV and write into provided output stream.
    /// Output stream MUST be seekable because header sizes are patched after writing.
    /// </summary>
    public void Convert(Stream pcmStream, Stream wavStream, bool resetOutputPosition = true)
    {
        if (pcmStream == null) throw new ArgumentNullException(nameof(pcmStream));
        if (wavStream == null) throw new ArgumentNullException(nameof(wavStream));
        if (!wavStream.CanSeek)
            throw new InvalidOperationException("Output stream must be seekable to finalize WAV header.");

        int blockAlign = this.Channels * (this.BitsPerSample / 8);
        int byteRate = this.SampleRateHz * blockAlign;

        long dataChunkSize;
        if (pcmStream.CanSeek)
        {
            // 入力長がわかる場合：先にサイズを計算し、その分だけ書く
            long pcmLen = pcmStream.Length - pcmStream.Position;
            long alignedLen = pcmLen - (pcmLen % blockAlign);
            dataChunkSize = alignedLen;

            WriteWavHeader(wavStream, (int)dataChunkSize, byteRate, blockAlign);

            CopyExactBytes(pcmStream, wavStream, alignedLen);
        }
        else
        {
            // 入力長が不明な場合：サイズ未定で仮ヘッダー→コピー→末尾切り詰め→サイズをパッチ
            long headerPos = wavStream.Position;
            WriteWavHeader(wavStream, 0, byteRate, blockAlign); // placeholder

            long dataStart = wavStream.Position;
            long copied = CopyAll(pcmStream, wavStream);

            long alignedLen = copied - (copied % blockAlign);
            dataChunkSize = alignedLen;

            // 末尾切り詰め（ブロック境界に合わせる）
            wavStream.SetLength(dataStart + alignedLen);

            // ヘッダーをパッチ
            PatchSizes(wavStream, (int)dataChunkSize);
        }

        if (resetOutputPosition)
        {
            wavStream.Position = 0;
        }
    }

    private void WriteWavHeader(Stream output, int dataChunkSize, int byteRate, int blockAlign)
    {
        using var bw = new BinaryWriter(output, Encoding.ASCII, leaveOpen: true);

        int riffChunkSize = 36 + dataChunkSize;

        // RIFF
        bw.Write(Encoding.ASCII.GetBytes("RIFF"));
        bw.Write(riffChunkSize);
        bw.Write(Encoding.ASCII.GetBytes("WAVE"));

        // fmt
        bw.Write(Encoding.ASCII.GetBytes("fmt "));
        bw.Write(16);                  // PCM
        bw.Write((short)1);            // AudioFormat = PCM
        bw.Write(this.Channels);
        bw.Write(this.SampleRateHz);
        bw.Write(byteRate);
        bw.Write((short)blockAlign);
        bw.Write(this.BitsPerSample);

        // data
        bw.Write(Encoding.ASCII.GetBytes("data"));
        bw.Write(dataChunkSize);
    }

    private void PatchSizes(Stream wavStream, int dataChunkSize)
    {
        long cur = wavStream.Position;

        // ChunkSize at offset 4 (little-endian int32)
        int riffChunkSize = 36 + dataChunkSize;
        wavStream.Position = 4;
        WriteInt32LE(wavStream, riffChunkSize);

        // Subchunk2Size at offset 40
        wavStream.Position = 40;
        WriteInt32LE(wavStream, dataChunkSize);

        wavStream.Position = cur;
    }

    private void WriteInt32LE(Stream s, int value)
    {
        Span<byte> b = stackalloc byte[4];
        b[0] = (byte)(value & 0xFF);
        b[1] = (byte)((value >> 8) & 0xFF);
        b[2] = (byte)((value >> 16) & 0xFF);
        b[3] = (byte)((value >> 24) & 0xFF);
        s.Write(b);
    }

    private static long CopyAll(Stream input, Stream output)
    {
        byte[] buffer = new byte[81920]; // 80KB
        long total = 0;
        int read;
        while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
        {
            output.Write(buffer, 0, read);
            total += read;
        }
        return total;
    }

    private static void CopyExactBytes(Stream input, Stream output, long bytesToCopy)
    {
        byte[] buffer = new byte[81920];
        long remaining = bytesToCopy;

        while (remaining > 0)
        {
            int toRead = (int)Math.Min(buffer.Length, remaining);
            int read = input.Read(buffer, 0, toRead);
            if (read == 0) break;
            output.Write(buffer, 0, read);
            remaining -= read;
        }
    }
}
