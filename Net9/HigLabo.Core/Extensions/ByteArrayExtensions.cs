using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core;

public static class ByteArrayExtensions
{
    public static Boolean HasUTF8ByteOrderMark(this byte[] data)
    {
        var bom = new byte[] { 0xEF, 0xBB, 0xBF };
        return data[0] == bom[0] && data[1] == bom[1] && data[2] == bom[2];
    }
    public static string CreateBase64FileString(this byte[] data, string contentType)
    {
        return $"data:{contentType};base64," + Convert.ToBase64String(data);
    }
}
