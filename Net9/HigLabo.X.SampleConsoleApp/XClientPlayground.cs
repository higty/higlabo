using System.Text.Json;

namespace HigLabo.X.SampleConsoleApp;

public class XClientPlayground
{
    public XClient XClient { get; set; } = new("");

    public async ValueTask ExecuteAsync()
    {
        SetSetting();
        await UsersMe();
        await UserByUsername();
        await TweetsSearchRecent();
        //await TweetsSearchStream();
        Console.WriteLine("■Completed");
    }
    private void SetSetting()
    {
        var bearerToken = File.ReadAllText("C:\\Dev\\HigLabo_X_ApiKey.txt").Trim();
        XClient = new XClient(new XSettings(bearerToken)
        {
            UserAgent = "HigLabo.X.SampleConsoleApp",
        });
    }

    private async ValueTask UsersMe()
    {
        var cl = XClient;
        var p = new UsersMeParameter();
        p.UserFieldList.Add(UserField.Id);
        p.UserFieldList.Add(UserField.Name);
        p.UserFieldList.Add(UserField.Username);
        p.UserFieldList.Add(UserField.CreatedAt);
        p.UserFieldList.Add(UserField.PublicMetrics);
        var res = await cl.UsersMeAsync(p);
        Console.WriteLine("■UsersMe");
        Console.WriteLine(JsonSerializer.Serialize(res.Data));
        Console.WriteLine();
    }
    private async ValueTask UserByUsername()
    {
        var cl = XClient;
        var p = new UserByUsernameParameter();
        p.Username = "XDevelopers";
        p.UserFieldList.Add(UserField.Id);
        p.UserFieldList.Add(UserField.Name);
        p.UserFieldList.Add(UserField.Username);
        p.UserFieldList.Add(UserField.Description);
        p.UserFieldList.Add(UserField.PublicMetrics);
        var res = await cl.UserByUsernameAsync(p);
        Console.WriteLine("■UserByUsername");
        Console.WriteLine(JsonSerializer.Serialize(res.Data));
        Console.WriteLine();
    }
    private async ValueTask TweetsSearchRecent()
    {
        var cl = XClient;
        var p = new TweetsSearchRecentParameter();
        p.Query = "(dotnet OR csharp) lang:en -is:retweet";
        p.Max_Results = 10;
        p.TweetFieldList.Add(TweetField.Id);
        p.TweetFieldList.Add(TweetField.Text);
        p.TweetFieldList.Add(TweetField.CreatedAt);
        p.TweetFieldList.Add(TweetField.AuthorId);
        p.TweetFieldList.Add(TweetField.PublicMetrics);
        p.Expansions = "author_id";
        p.UserFieldList.Add(UserField.Id);
        p.UserFieldList.Add(UserField.Name);
        p.UserFieldList.Add(UserField.Username);

        var res = await cl.TweetsSearchRecentAsync(p);
        Console.WriteLine("■TweetsSearchRecent");
        if (res.Data != null)
        {
            foreach (var item in res.Data)
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Created_At);
                Console.WriteLine(item.Text);
            }
        }
        Console.WriteLine();
    }
    private async ValueTask TweetsSearchStream()
    {
        var cl = XClient;
        var tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));

        Console.WriteLine("■TweetsSearchStream (30 seconds)");
        await foreach (var item in cl.TweetsSearchStreamAsync(tokenSource.Token))
        {
            if (item.Data == null) { continue; }
            Console.WriteLine("-------------------------------------");
            Console.WriteLine(item.Data.Id);
            Console.WriteLine(item.Data.Text);
            foreach (var rule in item.Matching_Rules)
            {
                Console.WriteLine($"rule: {rule.Tag} ({rule.Id})");
            }
        }
        Console.WriteLine();
    }
}
