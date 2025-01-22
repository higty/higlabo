using HigLabo.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.GoogleAI.SampleConsoleApp;

public class GoogleAIClientPlayground
{
    public GoogleAIClient GoogleAIClient { get; set; } = new();

    public async ValueTask ExecuteAsync()
    {
        SetSetting();
        //await ModelsList();
        //await Embedding();
        //await GenerateContent();
        await GenerateContentAsStream();
        //await GenerateContentAsStream1();
        //await GenerateContentGroundingAsStream();
        //await GenerateContentFunctionCallingAsStream();
        //await SendImage();
        Console.WriteLine("■Completed");

    }
    private void SetSetting()
    {
        var apiKey = File.ReadAllText("C:\\Dev\\GoogleAIApiKey.txt");
        GoogleAIClient = new GoogleAIClient(apiKey);
    }

    private async ValueTask ModelsList()
    {
        var cl = GoogleAIClient;

        var p = new ModelsListParameter();

        var res = await cl.ListAsync(p);
        foreach (var item in res.Models)
        {
            Console.WriteLine(item.Name);
        }
        Console.WriteLine("---------------");
        Console.WriteLine();

        var iRes = res as IRestApiResponse;
        Console.WriteLine(iRes.RequestBodyText);
        Console.WriteLine();
        Console.WriteLine(iRes.ResponseBodyText);
    }
    private async ValueTask Embedding()
    {
        var cl = GoogleAIClient;

        var p = new ModelsEmbedContentParameter();
        p.Model = ModelNames.TextEmbedding_004;
        p.SetText("How to enjoy Japan?");

        var res = await cl.EmbedContentAsync(p);
        var iRes = res as IRestApiResponse;
        Console.WriteLine(iRes.RequestBodyText);
        Console.WriteLine();
        Console.WriteLine(iRes.ResponseBodyText);
    }

    private async ValueTask GenerateContent()
    {
        var cl = GoogleAIClient;

        var p = new ModelsGenerateContentParameter();
        p.Model = ModelNames.Gemini_1_5_Pro_Latest;
        p.AddMessage(ChatMessageRole.User, "How to enjoy Japan?");
        p.Stream = false;

        var res = await cl.GenerateContentAsync(p);

        foreach (var candidate in res.Candidates)
        {
            foreach (var part in candidate.Content.Parts)
            {
                Console.WriteLine(part.Text);
            }
        }
        var iRes = res as IRestApiResponse;
        Console.WriteLine(iRes.RequestBodyText);
        Console.WriteLine();
        Console.WriteLine(iRes.ResponseBodyText);
    }
    private async ValueTask GenerateContentAsStream()
    {
        var cl = GoogleAIClient;

        var p = new ModelsGenerateContentParameter();
        p.Model = ModelNames.Gemini_1_5_Pro_Latest;

        await foreach (var item in cl.GenerateContentStreamAsync("How to enjoy Japan?", ModelNames.Gemini_1_5_Pro_Latest))
        {
            Console.Write(item);
        }
        Console.WriteLine("***********************");
    }
    private async ValueTask GenerateContentAsStream1()
    {
        var cl = GoogleAIClient;

        var p = new ModelsGenerateContentParameter();
        p.Model = ModelNames.Gemini_1_5_Pro_Latest;
        p.AddMessage(ChatMessageRole.User, "How to enjoy Japan?");

        var result = new GenerateContentStreamResult();
        await foreach (var item in cl.GenerateContentStreamAsync(p, result, CancellationToken.None))
        {
            Console.Write(item);
        }
        Console.WriteLine("***********************");
    }
    private async ValueTask GenerateContentGroundingAsStream()
    {
        var cl = GoogleAIClient;

        var p = new ModelsGenerateContentParameter();
        p.Model = ModelNames.Gemini_1_5_Pro_Latest;
        p.AddMessage(ChatMessageRole.User, "Please tell me how to go to Aomori from Tokyo.");
        p.Tools = new();
        var tool = new GoogleSearchRetrievalTool();
        p.Tools.Add(tool);

        var result = new GenerateContentStreamResult();
        await foreach (var item in cl.GenerateContentStreamAsync(p, result, CancellationToken.None))
        {
            Console.Write(item);
        }
        Console.WriteLine("***********************");
    }
    private async ValueTask GenerateContentFunctionCallingAsStream()
    {
        var cl = GoogleAIClient;

        var p = new ModelsGenerateContentParameter();
        p.Model = ModelNames.Gemini_1_5_Pro_Latest;
        p.AddMessage(ChatMessageRole.User, "Please list up 10 vegetable.");

        var function = new Function();
        var f = new FunctionDeclaration();
        f.Name = "BodyTextCandidate";
        f.Description = "Get description of given item list.";
        f.Parameters = new
        {
            type = "object",
            properties = new
            {
                TextList = new
                {
                    type = "array",
                    description = "Item name list as string array.",
                    items = new { type = "string" }
                }
            },
            required = new[] { "TextList" },
        };
        function.FunctionDeclarations.Add(f);
        p.Tools = new List<Tool>();
        p.Tools.Add(function);

        var result = new GenerateContentStreamResult();
        await foreach (var item in cl.GenerateContentStreamAsync(p, result, CancellationToken.None))
        {
            Console.Write(item);
        }
        var functionCall = result.GetFunctionCall();
        if (functionCall != null)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("FunctionName: " + functionCall.Name);
            Console.WriteLine("Arguments: " + functionCall.Args);
        }
        Console.WriteLine("***********************");
    }

    /// <summary>
    /// That does not work yet.
    /// </summary>
    /// <returns></returns>
    private async ValueTask GenerateAnswer()
    {
        var cl = GoogleAIClient;

        var p = new ModelsGenerateAnswerParameter();
        p.Model = ModelNames.Gemini_1_5_Pro_Latest;
        p.AddMessage(ChatMessageRole.User, "How to enjoy Japan?");
        p.AnswerStyle = AnswerStyle.Abstractive;
        p.InlinePassages = new GroundingPassages();
        var passage = new GroundingPassage();
        passage.Id = "123";
        passage.Content = new Content(ChatMessageRole.User, "You must go to Shiarakawago in Gifu prefecture.");
        p.InlinePassages.Passages.Add(passage);
        p.Stream = false;

        var res = await cl.GenerateAnswerAsync(p);

        foreach (var part in res.Answer.Content.Parts)
        {
            Console.WriteLine(part.Text);
        }
        var iRes = res as IRestApiResponse;
        Console.WriteLine(iRes.RequestBodyText);
        Console.WriteLine();
        Console.WriteLine(iRes.ResponseBodyText);
    }

    private async ValueTask SendImage()
    {
        var cl = GoogleAIClient;

        var p = new ModelsGenerateContentParameter();
        p.Model = ModelNames.Gemini_Pro_Vision;
        var path = Path.Combine(Environment.CurrentDirectory, "Image", "Jougakura_Bridge.jpg");
        p.AddMessage("What is this picture?", "image/jpeg", File.ReadAllBytes(path));
        p.Stream = false;

        var res = await cl.GenerateContentAsync(p);

        foreach (var candidate in res.Candidates)
        {
            foreach (var part in candidate.Content.Parts)
            {
                Console.WriteLine(part.Text);
            }
        }
        var iRes = res as IRestApiResponse;
        Console.WriteLine();
        Console.WriteLine(iRes.ResponseBodyText);
    }
}
