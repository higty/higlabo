using System.Text.RegularExpressions;

namespace HigLabo.Core;

public enum ColorBrightnessType
{
    Unknown,
    Light,
    Dark,
}
public static class ColorBrightnessTypeAnalyzer
{
    private static class RegexList
    {
        public static readonly Regex HexColorCode = new Regex("^#([0-9a-fA-F]{2})([0-9a-fA-F]{2})([0-9a-fA-F]{2})$");
        public static readonly Regex RgbColorCode = new Regex("^rgb\\(([0-9a-fA-F]{2}),([0-9a-fA-F]{2}),([0-9a-fA-F]{2})\\)$");
    }
    public static ColorBrightnessType GetColorBrightnessType(String hexColorCode)
    {
        var luminance = GetLuminance(hexColorCode);
        if (luminance == null) { return ColorBrightnessType.Unknown; }
        if (luminance > 0.179)
        {
            return ColorBrightnessType.Light;
        }
        else
        {
            return ColorBrightnessType.Dark;
        }
    }
    private static IEnumerable<Regex> GetRegexList()
    {
        yield return RegexList.HexColorCode;
        yield return RegexList.RgbColorCode;
    }
    /// <summary>
    /// Acceptable #000000-#ffffff
    /// </summary>
    /// <param name="hexColorCode"></param>
    /// <returns></returns>
    public static Double? GetLuminance(String hexColorCode)
    {
        foreach (var item in GetRegexList())
        {
            var m = item.Match(hexColorCode);
            if (m.Success && m.Groups.Count == 4)
            {
                var red = Convert.ToInt32(m.Groups[1].Value, 16);
                var green = Convert.ToInt32(m.Groups[2].Value, 16);
                var blue = Convert.ToInt32(m.Groups[3].Value, 16);
                var luminance = GetLuminance(red, green, blue);
                return luminance;
            }
        }
        return null;
    }
    private static Double GetLuminance(Int32 red, Int32 green, Int32 blue)
    {
        var r = GetLuminanceBaseValue(red);
        var g = GetLuminanceBaseValue(green);
        var b = GetLuminanceBaseValue(blue);
        var L = 0.2126 * r + 0.7152 * g + 0.0722 * b;
        return L;
    }
    private static Double GetLuminanceBaseValue(Int32 color)
    {
        Double c = color;
        c = c / 255.0;
        if (c <= 0.03928)
        {
            c = c / 12.92;
        }
        else
        {
            c = Math.Pow((c + 0.055) / 1.055, 2.4);
        }
        return c;
    }
}
