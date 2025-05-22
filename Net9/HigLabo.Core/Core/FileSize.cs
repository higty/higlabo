using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core;

public class FileSize
{
    public const decimal _1024 = 1024;
    public static string GetFileSizeText(Int64 fileSize)
    {
        return GetFileSizeText((decimal)fileSize);
    }
    public static string GetFileSizeText(decimal fileSize)
    {
        if (fileSize < 1000) { return $"{fileSize.ToString("##0")}B"; }
        else if (fileSize < 1000 * _1024) { return $"{(fileSize / _1024).ToString("#,##0.000")}KB"; }
        else if (fileSize < 1000 * _1024 * _1024) { return $"{(fileSize / (_1024 * _1024)).ToString("#,##0.000")}MB"; }
        else { return $"{(fileSize / (_1024 * _1024 * _1024)).ToString("#,##0.000")}GB"; }
    }
}
