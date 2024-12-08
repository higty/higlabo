using System.Text.RegularExpressions;

namespace HigLabo.Core;
public class PTHHMMSSConverter
{
    public static Regex PTHHMMSS = new Regex(@"PT(?:(\d+)H)?(?:(\d+)M)?(?:(\d+)S)?");

    public TimeSpan? Parse(string value)
    {
        var m = PTHHMMSS.Match(value);
        if (m.Success)
        {
            int hours = m.Groups[1].Success ? int.Parse(m.Groups[1].Value) : 0;
            int minutes = m.Groups[2].Success ? int.Parse(m.Groups[2].Value) : 0;
            int seconds = m.Groups[3].Success ? int.Parse(m.Groups[3].Value) : 0;
            return new TimeSpan(hours, minutes, seconds);
        }
        return null;
    }
}
