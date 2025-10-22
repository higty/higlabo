# HigLabo
HigLabo library provide features 

1. OpenAI client library
2. Object Mapper(fastest in the world)
3. DbSharp(DAL generator)
4. And other.(Mail, Ftp, Rss, Twitter...etc)

I added .NET Standard version at 2020/07/03.
It was moved from https://github.com/higty/higlabo.netstandard repository.



## HigLabo.OpenAI
2025-03-14 Support Responses API endpoint, and web search, file search and more. 

※Breaking change. The endpoint of ChatCompletions are all changed to ChatCompletionCreate. Please see latest sample code.
https://github.com/higty/higlabo/blob/master/Net9/HigLabo.OpenAI.SampleConsoleApp/OpenAIPlayground.cs

2025-10-08 updated. Support video generation by Sora2.

2025-08-24 updated. Support conversation, eval, certificate endpoints.

2025-01-22 updated. Support .NET9.

2024-08-23 updated. Support administration api endpoint.

2024-06-05 updated. Support vector store chunking strategy.

2024-05-07 updated. Support usage information on chat completion.

2024-04-22 updated. Support Groq. You can use llama, mixtral, gemma

2024-04-20 updated. This release include fie search and vector store endpoint.

2024-04-17 updated. This release include Batch endpoint.

See article.
https://www.codeproject.com/Articles/5372480/Csharp-OpenAI-library-that-support-Assistants-API

See sample code.
https://github.com/higty/higlabo/blob/master/Net8/HigLabo.OpenAI.SampleConsoleApp/OpenAIPlayground.cs

Set up: HigLabo.OpenAI from Nuget, and also add HigLabo.Core, HigLabo.NewtonsoftJson.
I test against latest version of these three packages.

How to use? It is easy to use!
```
var cl = new OpenAIClient("API Key");
var p = new ResponseCreateParameter();
p.Model = "gpt-4o";
p.Input.AddUserMessage($"How to enjoy coffee near by Shibuya? Please search shop list from web.");
p.Tools = [];
p.Tools.Add(new ToolObject("web_search_preview"));
var result = new ResponseStreamResult();
await foreach (string text in cl.ResponseCreateStreamAsync(p, result, CancellationToken.None))
{
    Console.Write(text);
}
foreach (var item in result.ContentList)
{
    if (item.Annotations != null)
    {
        foreach (var annotation in item.Annotations)
        {
            Console.WriteLine(annotation.Title);
            Console.WriteLine(annotation.Url);
        }
    }
}

```

```
var cl = new OpenAIClient("API Key"); // OpenAI
--var cl = new OpenAIClient(new AzureSettings("API KEY", "https://tinybetter-work-for-our-future.openai.azure.com/", "MyDeploymentName"));
--var cl = new OpenAIClient(new GroqSettings("API Key")); // Groq, llama, mixtral, gemma
var result = new ChatCompletionStreamResult();
await foreach (string text in cl.ChatCompletionCreateStreamAsync("How to enjoy coffee?", "gpt-4", result, CancellationToken.None))
{
    Console.Write(text);
}
Console.WriteLine();
Console.WriteLine("***********************");
Console.WriteLine("Finish reason: " + result.GetFinishReason());
```

```
var p = new RunCreateParameter();
p.Assistant_Id = assistantId;
p.Thread_Id = threadId;
var result = new AssistantMessageStreamResult();
await foreach (string text in cl.RunCreateStreamAsync(p, result, CancellationToken.None))
{
    Console.Write(text);
}
Console.WriteLine();
// You can get each server sent event data by these property.
Console.WriteLine(JsonConvert.SerializeObject(result.Thread));
Console.WriteLine(JsonConvert.SerializeObject(result.Run));
Console.WriteLine(JsonConvert.SerializeObject(result.RunStep));
Console.WriteLine(JsonConvert.SerializeObject(result.Message));

```

Generate new image from other uploaded image and save generated image to local folder.
```
var p = new ResponseCreateParameter();
p.Model = "gpt-5";
p.Input.AddUserMessage("Please change this image to anime-inspired look style and generate new image.");
p.Input[0].AddImage("image/png", File.ReadAllBytes(Path.Combine(Environment.CurrentDirectory, "Image", "Mt_Tsurugi.jpg")));
p.Tools = [];
p.Tools.Add(new Tool("image_generation"));

Console.WriteLine("Generateing...");
var res = await cl.ResponseCreateAsync(p, CancellationToken.None);
foreach (var output in res.Output)
{
    switch (output.Type)
    {
        case "message":
            foreach (var content in output.Content)
            {
                if (content.Type == "output_text")
                {
                    Console.WriteLine(content.Text);
                }
            }
            break;
        case "image_generation_call":
            Console.WriteLine(output.Revised_Prompt);
            var imageData = Convert.FromBase64String(output.Result);
            var folderPath = Path.Combine(Environment.CurrentDirectory, "Generated");
            if (Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            var filePath = Path.Combine(Environment.CurrentDirectory, "Generated", $"Image_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.png");
            File.WriteAllBytes(filePath, imageData);
            Console.WriteLine("File is saved to");
            Console.WriteLine(filePath);
            break;
        default: break;
    }
}
```

```
var cl = OpenAIClient;

var p = new VideoCreateParameter();
p.Prompt = "A baby and a fluffy kitten playing together on a soft carpet in a sunlit living room, morning light streaming through curtains, natural colors, heartwarming and gentle atmosphere, cinematic depth of field, ultra-realistic style.";
p.Model = "sora-2";
var job = await cl.VideoCreateAsync(p);
Console.WriteLine("Job started.");
while (true)
{
    //10 seconds interval
    Thread.Sleep(10 * 1000);

    var res = await cl.VideoRetrieveAsync(job.Id);
    if (res.Status == "completed")
    {
        var stream = await cl.VideoContentGetAsync(job.Id);
        var filePath = Path.Combine(Environment.CurrentDirectory, $"video_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.mp4");
        File.WriteAllBytes(filePath, stream.ToByteArray());
        break;
    }
    else if (res.Status == "failed")
    {
        Console.WriteLine("Job failed.");
        break;
    }
    else
    {
        Console.WriteLine($"{DateTimeOffset.Now.ChangeTimeZone(9).ToIso8601String()} Job status is " + res.Status + ". Waiting...");
    }
}
```

## HigLabo.GoogleAI
2025-03-17 Support Imagen model image generation. You can generate image by imagen model.

2025-03-15 Support Gemini2.0 Flash experimental model. You can generate image from code.

2025-01-22 updated. Support .NET9.

```
var cl = new GoogleAIClient("API KEY");
var p = new ModelsGenerateContentParameter();
p.Model = ModelNames.Gemini_2_0_Flash_Exp;
p.AddUserMessage("Hi, can you create a 3d rendered image of a cat with wings and a top hat flying over a happy futuristic scificity with lots of greenery?");
p.GenerationConfig = new();
p.GenerationConfig.ResponseModalities = ["Text", "Image"];
p.Stream = false;

var res = await cl.GenerateContentAsync(p);

foreach (var candidate in res.Candidates)
{
    foreach (var part in candidate.Content.Parts)
    {
        if (part.Text != null)
        {
            Console.WriteLine(part.Text);
        }
        if (part.InlineData != null)
        {
            using (var stream = part.InlineData.GetStream())
            {
                using (var bitmap = new Bitmap(stream))
                {
                    string outputPath = Path.Combine(Environment.CurrentDirectory, "Image", $"GeneratedImage_{DateTimeOffset.Now.ToString("yyyyMMdd_HHmmss")}.jpg");
                    bitmap.Save(outputPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
        }
    }
}

```


## HigLabo.Anthropic
HigLabo.Anthropic is a C# library of Anthropic Claude AI.
2014-04-07 updated. It support tool feature.

You can use it like this. Really easy and intuitive.
```
var cl = new AhtnropicClient("API KEY");
var result = new MessagesStreamResult();
await foreach (string text in cl.MessagesStreamAsync("How to enjoy coffee?", ModelNames.Claude3Opus, result, CancellationToken.None))
{
    Console.Write(text);
}
if (result.MessageDelta != null)
{
    Console.WriteLine("StopReason: " + result.MessageDelta.Delta.Stop_Reason);
    Console.WriteLine("Usage: " + result.MessageDelta.Usage.Output_Tokens);
}
```

## HigLabo.Mapper
A mapper library like AutoMapper,EmitMapper,FastMapper,ExpressMapper..etc.
I posted article to CodeProject.
https://www.codeproject.com/Articles/5275388/HigLabo-Mapper-Creating-Fastest-Object-Mapper-in-t

You can map object out of box without configuration.
You can also customize completely as you can with AddPostAction,ReplaceMap method.

I completely rewrite HigLabo.Mapper. Now, HigLabo.Mapper is fastest mapper library in the world.

Performance test at 2024/02/02.
![image](https://github.com/higty/higlabo/assets/10071037/a739220e-605f-44dd-bf60-b0d4784fe76c)
Note) Mapperly is fast because it does not create new instance. That only pass reference. It does not map property values. Mapperly looks fastest but it is not on the test Address, Customer.
HigLabo.Mapper is fastest than any other library. Only Address to AddressDTO is slower than Mapperly.


HigLabo.Mapper (version3.0.0 or later) is used expression tree. It generate il code on runtime, so it is nealy fast as handy code.


## DbSharp
2025-02-04 Refine DbSharpApplication.

A code generator to call stored procedure on database(SQL server, MySQL)

Article
https://www.higlabo.ai/blog/higty-tech/dbsharpapplication-japanese-tutorial

https://www.codeproject.com/Articles/776811/DbSharp-DAL-Generator-Tool-on-NET-Core

Download link for DbSharpApplication (version: 9.1.0.1)
https://static.tinybetter.com/higlabo/DbSharpApplication/DbSharpApplication_9_1_0_1.zip


## HigLabo.Web
RazorRenderer class get html from .cshtml file.

You can use it by 
```Program.cs
var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
services.AddHttpContextAccessor();
services.AddScoped<RazorRenderer>();

var app = builder.Build();
app.MapGet("/portal", (RazorRenderer renderer) => await context.WriteHtmlAsync("/Pages/Portal.cshtml"));
app.MapGet("/task/list", (RazorRenderer renderer) => await context.WriteHtmlAsync("/Pages/TaskList.cshtml", new TaskListModel()));
```

## HigLabo.Mime
A library of Mime parser. Fastest parser in the world for MIME format. It is used for HigLabo.Mail.

## HigLabo.Mail
A mail library of SMTP,POP3,IMAP.

https://www.codeproject.com/Articles/399207/Understanding-the-Insides-of-the-SMTP-Mail-Protoco
https://www.codeproject.com/Articles/404066/Understanding-the-insides-of-the-POP-mail-protoco
https://www.codeproject.com/Articles/411018/Understanding-the-insides-of-the-IMAP-mail-protoco

## HigLabo.Data.XXX
A library for database access.

## HigLabo.Converter
Converter library for Base64,QueryString,QuotedPrintable,Rfc2047,ModifiedUtf7,ISO8601...etc.



