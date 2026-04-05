using HigLaboApp.Core;
using System.Web;

namespace HigLabo.Html.Test;

[TestClass]
public sealed class Test1
{
    [TestMethod]
    public async Task TestMethod1()
    {
        var processor = new HtmlProcessor();
        processor.Converters.Add(new HigLaboAppLinkHtmlConverter());
        var html = await processor.GetHtmlAsync("""
            https://dribbble.com/shots/27040128-Dashboard-UI-Interior-Design-RoomSketch
            https://dribbble.com/shots/26495519-Real-Estate-Dashboard-Property-Listing-Map-UI
            """);

        Assert.AreEqual($"""
            <p><a href="{HttpUtility.HtmlAttributeEncode("https://dribbble.com/shots/27040128-Dashboard-UI-Interior-Design-RoomSketch")}" target="_blank">https://dribbble.com/shots/27040128-Dashboard-UI-Interior-Design-RoomSketch</a></p>
            <p><a href="{HttpUtility.HtmlAttributeEncode("https://dribbble.com/shots/26495519-Real-Estate-Dashboard-Property-Listing-Map-UI")}" target="_blank">https://dribbble.com/shots/26495519-Real-Estate-Dashboard-Property-Listing-Map-UI</a></p>
            """, html);
    }
}
