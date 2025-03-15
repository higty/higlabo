using HigLabo.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        //await GenerateContentAsStream();
        //await GenerateContentAsStream1();
        //await GenerateContentThinkingAsStream1();
        await GenerateContentGroundingAsStream();
        //await GenerateContentFunctionCallingAsStream();

        //await GenerateSensitiveImage();
        //await SendImage();
        //await GenerateImage();
        //await RefineImage();
        //await MergeImage();
        //await GenerateMindMap();
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
        await foreach (var item in cl.GenerateContentStreamAsync("How to enjoy Japan?", ModelNames.Gemini_2_0_Flash_Exp))
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
        p.GenerationConfig = new();
        p.GenerationConfig.Temperature = 0.8;

        var result = new GenerateContentStreamResult();
        await foreach (var item in cl.GenerateContentStreamAsync(p, result, CancellationToken.None))
        {
            Console.Write(item);
        }
        Console.WriteLine("***********************");
    }
    private async ValueTask GenerateContentThinkingAsStream()
    {
        var cl = GoogleAIClient;

        var p = new ModelsGenerateContentParameter();
        p.Model = ModelNames.Gemini_2_0_Flash_Thinking_Exp_01_21;
        var path = Path.Combine(Environment.CurrentDirectory, "Image", "CircleAndTriangle.png");
        p.AddMessage("What’s the area of the overlapping region?", "image/png", File.ReadAllBytes(path));

        var result = new GenerateContentStreamResult();
        await foreach (var item in cl.GenerateContentStreamAsync(p, result, CancellationToken.None))
        {
            Console.Write(item);
        }
        Console.WriteLine("***********************");
    }
    private async ValueTask GenerateContentThinkingAsStream1()
    {
        var cl = GoogleAIClient;

        var p = new ModelsGenerateContentParameter();
        p.Model = ModelNames.Gemini_2_0_Flash_Thinking_Exp_01_21;
        //https://happylilac.net/jhs-math3_01-02-01.pdf
        //より引用
        var language = "Japanese";
        var path = Path.Combine(Environment.CurrentDirectory, "Image", "Factorization.png");
        p.AddMessage($"Solve these question and list up answers. Explain the step after list up answer. Please answer by {language}.", "image/png", File.ReadAllBytes(path));

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
        p.Model = ModelNames.Gemini_2_0_Flash_Exp;
        p.AddMessage(ChatMessageRole.User, "Please tell me how to go to Aomori from Tokyo.");
        p.Tools = new();
        var tool = new GoogleSearchTool();
        p.Tools.Add(tool);

        var result = new GenerateContentStreamResult();
        await foreach (var item in cl.GenerateContentStreamAsync(p, result, CancellationToken.None))
        {
            Console.Write(item);
        }
        foreach (var candidate in result.Candidates)
        {
            foreach (var part in candidate.Content.Parts)
            {
                if (part.Text != null)
                {
                    Console.WriteLine(part.Text);
                }
            }
            if (candidate.GroundingMetaData != null)
            {
                foreach (var chunk in candidate.GroundingMetaData.GroundingChunks)
                {
                    Console.WriteLine(chunk.Web.Title);
                    Console.WriteLine(chunk.Web.Uri);
                }
            }
        }
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
        p.Model = ModelNames.Gemini_2_0_Pro_Exp_02_05;
        var path = Path.Combine(Environment.CurrentDirectory, "Image", "KamuiCape.jpg");
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
    private async ValueTask GenerateImage()
    {
        var cl = GoogleAIClient;

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
                    Console.WriteLine(part.InlineData.MimeType);
                    using (var stream = part.InlineData.GetStream())
                    {
                        using (var bitmap = new Bitmap(stream))
                        {
                            // 画像を表示または保存する
                            string outputPath = Path.Combine(Environment.CurrentDirectory, "Image", $"GeneratedImage_{DateTimeOffset.Now.ToString("yyyyMMdd_HHmmss")}.jpg");
                            bitmap.Save(outputPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                            Console.WriteLine($"Image is saved at {outputPath}");
                        }

                    }
                }
            }
        }
    }
    private async ValueTask GenerateSensitiveImage()
    {
        var cl = GoogleAIClient;

        var p = new ModelsGenerateContentParameter();
        p.Model = ModelNames.Gemini_2_0_Flash_Exp;
        p.AddUserMessage("A beautiful young woman with large, expressive brown eyes and long, dark hair with blue highlights, wearing ornate jewelry and a colorful dress with floral patterns, soft lighting, vibrant colors, detailed illustration.");
        p.SafetySettings = new();
        //If comment out this line, you sometimes fail to generate image due to image safety.
        p.SafetySettings.Add(new SafetySetting(SafetyCategory.Harm_Category_Sexually_Explicit, Threshold.Block_None));
        p.GenerationConfig = new();
        p.GenerationConfig.ResponseModalities = ["Text", "Image"];

        var result = new GenerateContentStreamResult();
        await foreach (var item in cl.GenerateContentStreamAsync(p, result, CancellationToken.None))
        {
            Console.Write(item);
        }

        foreach (var candidate in result.Candidates)
        {
            foreach (var part in candidate.Content.Parts)
            {
                if (part.Text != null)
                {
                    Console.WriteLine(part.Text);
                }
                if (part.InlineData != null)
                {
                    Console.WriteLine(part.InlineData.MimeType);
                    using (var stream = part.InlineData.GetStream())
                    {
                        using (var bitmap = new Bitmap(stream))
                        {
                            // 画像を表示または保存する
                            string outputPath = Path.Combine(Environment.CurrentDirectory, "Image", $"SensitiveImage_{DateTimeOffset.Now.ToString("yyyyMMdd_HHmmss")}.jpg");
                            bitmap.Save(outputPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                            Console.WriteLine($"Image is saved at {outputPath}");
                        }

                    }
                }
            }
            if (candidate.FinishReason != null)
            {
                Console.WriteLine("Finish reason: " + candidate.FinishReason.ToStringFromEnum());
            }
        }
    }

    private async ValueTask RefineImage()
    {
        var cl = GoogleAIClient;

        var p = new ModelsGenerateContentParameter();
        p.Model = ModelNames.Gemini_2_0_Flash_Exp;
        var path = Path.Combine(Environment.CurrentDirectory, "Image", "Table.jpg");
        p.AddMessage("Remove plant behind the table and remove coffee cup on table.", "image/jpeg", File.ReadAllBytes(path));
        p.GenerationConfig = new();
        p.GenerationConfig.ResponseModalities = ["Text", "Image"];
        p.Stream = false;

        Console.WriteLine(path);
        Console.WriteLine("Refine image started...");
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
                    Console.WriteLine(part.InlineData.MimeType);
                    using (var stream = part.InlineData.GetStream())
                    {
                        using (var bitmap = new Bitmap(stream))
                        {
                            // 画像を表示または保存する
                            string outputPath = Path.Combine(Environment.CurrentDirectory, "Image", $"Table_Refined_{DateTimeOffset.Now.ToString("yyyyMMdd_HHmmss")}.jpg");
                            bitmap.Save(outputPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                            Console.WriteLine($"Image is saved at {outputPath}");
                        }

                    }
                }
            }
        }
    }
    private async ValueTask MergeImage()
    {
        var cl = GoogleAIClient;

        var p = new ModelsGenerateContentParameter();
        p.Model = ModelNames.Gemini_2_0_Flash_Exp;
        var content = new Content();
        var prompt = "Remove plant behind table in first image. After that, put second image's plant on the table.";
        content.Parts.Add(new ContentPart(prompt));
        {
            var part = new ContentPart(new InlineData("image/jpeg", Convert.ToBase64String(File.ReadAllBytes(Path.Combine(Environment.CurrentDirectory, "Image", "Table.jpg")))));
            content.Parts.Add(part);
        }
        {
            var part = new ContentPart(new InlineData("image/jpeg", Convert.ToBase64String(File.ReadAllBytes(Path.Combine(Environment.CurrentDirectory, "Image", "Plant.jpg")))));
            content.Parts.Add(part);
        }
        p.Contents.Add(content);

        p.GenerationConfig = new();
        p.GenerationConfig.ResponseModalities = ["Text", "Image"];
        p.Stream = false;

        Console.WriteLine(prompt);
        Console.WriteLine("Merge images started...sometimes success, sometimes goes wrong...");
        var res = await cl.GenerateContentAsync(p);

        foreach (var candidate in res.Candidates)
        {
            foreach (var part in candidate.Content.Parts)
            {
                if (part.InlineData != null)
                {
                    Console.WriteLine(part.InlineData.MimeType);
                    using (var stream = part.InlineData.GetStream())
                    {
                        using (var bitmap = new Bitmap(stream))
                        {
                            // 画像を表示または保存する
                            string outputPath = Path.Combine(Environment.CurrentDirectory, "Image", $"Table_Refined_{DateTimeOffset.Now.ToString("yyyyMMdd_HHmmss")}.jpg");
                            bitmap.Save(outputPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                            Console.WriteLine($"Image is saved at {outputPath}");
                        }

                    }
                }
            }
        }
    }

    private async ValueTask GenerateMindMap()
    {
        Console.WriteLine("GenerateMindMap started...");

        var cl = GoogleAIClient;
        var sb = new StringBuilder();
        await foreach (var item in cl.GenerateContentStreamAsync("Generate 5 branch mind map of saas service for PR strategy. Please output mind map data only.", ModelNames.Gemini_2_0_Flash_Exp))
        {
            Console.Write(item);
            sb.Append(item);
        }

        var p = new ModelsGenerateContentParameter();
        p.Model = ModelNames.Gemini_2_0_Flash_Exp;
        p.AddUserMessage("Generate mind map image from below text in English.\n\n" + sb.ToString());
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
                    Console.WriteLine(part.InlineData.MimeType);
                    using (var stream = part.InlineData.GetStream())
                    {
                        using (var bitmap = new Bitmap(stream))
                        {
                            // 画像を表示または保存する
                            string outputPath = Path.Combine(Environment.CurrentDirectory, "Image", $"MindMap_{DateTimeOffset.Now.ToString("yyyyMMdd_HHmmss")}.png");
                            bitmap.Save(outputPath, System.Drawing.Imaging.ImageFormat.Png);
                            Console.WriteLine($"Image is saved at {outputPath}");
                        }

                    }
                }
            }
        }
        //This does not work as we expected. Wrong mind map generated. But it may help to improve your imagination.

    }
}
