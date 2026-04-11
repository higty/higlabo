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
    [TestMethod]
    public async Task TestMethod2()
    {
        var processor = new HtmlProcessor();
        var pTagConverter = new LineToPTagConverter();
        pTagConverter.IsProcess = line => line.StartsWith("<div class=\"source-code\">");
        processor.Converters.Add(pTagConverter);
        processor.Converters.Add(new BlobFileHtmlConverter(new FileExtensionProcessor()));

        var inputText = $"""
            <a href="https://higlaboappdev.blob.core.windows.net/tenant/dbb51892-2dd6-f61d-d33d-3a143d8dbdc7/chat-channel/d1ed3879-fe9d-9b29-2814-3a1ee5948b83/7cdb8744-a43d-d9b0-4927-3a208802e2df.mp4">Video</a>
            びっくりするひな鳥
            てすと1
            てすと2
            てすと3
            """;
        var html = await processor.GetHtmlAsync(inputText);

        Assert.AreEqual("<p>びっくりするひな鳥</p><p>てすと1</p><p>てすと2</p><p>てすと3</p>", html);
    }
}
