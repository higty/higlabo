See article
https://www.codeproject.com/Articles/5372480/Csharp-OpenAI-library-that-support-Assistants-API

How to use?
Download via Nuget

HigLabo.OpenAI

All source code is 
https://github.com/higty/higlabo/tree/master/Net7

HigLabo.OpenAI is that.

You can see sample code at
https://github.com/higty/higlabo/blob/master/Net7/HigLabo.OpenAI.SampleConsoleApp/OpenAIPlayground.cs
 

The main class is OpenAIClient. You create OpenAIClient class for OpenAI API.

C#
var apiKey = "your api key of OpenAI";
var client = new OpenAIClient(apiKey);
For Azure endpoint.

C#
var apiKey = "your api key of OpenAI";
var client = new OpenAIClient(new AzureSettings(apiKey, "https://tinybetter-work-for-our-future.openai.azure.com/", "MyDeploymentName"));
Call ChatCompletion endpoint.

C#
var p = new ChatCompletionsParameter();
var theme = "How to enjoy coffee";
p.Messages.Add(new ChatMessage(ChatMessageRole.User
    , $"Can you provide me with some ideas for blog posts about {theme}?"));
p.Model = "gpt-3.5-turbo";
var res = await client.ChatCompletionsAsync(p);
foreach (var choice in res.Choices)
{
     Console.Write(choice.Message.Content);
}
Consume ChatCompletion endpoint with server sent event.

C#
var theme = "How to enjoy coffee";
await foreach (var chunk in client.ChatCompletionsStreamAsync($"Can you provide me with some ideas for blog posts about {theme}?", "gpt-3.5-turbo"))
{
    foreach (var choice in chunk.Choices)
    {
        Console.Write(choice.Delta.Content);
    }
}
Console.WriteLine();
Console.WriteLine("DONE");
ChatCompletion with function calling.

C#
Shrink ▲   
var p = new ChatCompletionsParameter();
//ChatGPT can correct Newyork,Sanflansisco to New york and San Flancisco.
p.Messages.Add(new ChatMessage(ChatMessageRole.User, $"I want to know the whether of these locations. Newyork, Sanflansisco, Paris, Tokyo."));
p.Model = "gpt-3.5-turbo";

var tool = new ToolObject("function");
tool.Function = new FunctionObject();
tool.Function.Name = "getWhether";
tool.Function.Description = "This service can get whether of specified location.";
tool.Function.Parameters = new
{
    type = "object",
    properties = new
    {
        locationList = new
        {
            type = "array",
            description = "Location list that you want to know.",
            items = new
            {
                type = "string",
            }
        }
    }
};
p.Tools = new List<ToolObject>();
p.Tools.Add(tool);

var processor = new ChatCompletionFunctionCallingProcessor();
//You must set Stream property to true to receive server sent event stream on chat completion endpoint.
p.Stream = true;
await foreach (var chunk in client.GetStreamAsync(p))
{
    foreach (var choice in chunk.Choices)
    {
        Console.Write(choice.Delta.Content);
        processor.Process(chunk);
    }
}
Console.WriteLine();

var f = processor.GetFunctionCall();
if (f != null)
{
    Console.WriteLine("■Function name is " + f.Name);
    Console.WriteLine("■Arguments is " + f.Arguments);
}
Console.WriteLine();
Console.WriteLine("DONE");
Upload file for fine tuning or pass to assitants.

C#
var p = new FileUploadParameter();
p.SetFile("my_file.pdf", File.ReadAllBytes("D:\\Data\\my_file.pdf"));
p.Purpose = "assistants";
var res = await client.FileUploadAsync(p);
Console.WriteLine(res);
Image generation

C#
var res = await client.ImagesGenerationsAsync("Blue sky and green field.");
foreach (var item in res.Data)
{
    Console.WriteLine(item.Url);
}
Create Assistant via API

C#
var p = new AssistantCreateParameter();
p.Name = "Legal tutor";
p.Instructions = "You are a personal legal tutor. Write and run code to legal questions based on passed files.";
p.Model = "gpt-4-1106-preview";

p.Tools = new List<ToolObject>();
p.Tools.Add(new ToolObject("code_interpreter"));
p.Tools.Add(new ToolObject("retrieval"));

var res = await client.AssistantCreateAsync(p);
Console.WriteLine(res);
Add files to assistant.

C#
var res = await client.FilesAsync();
foreach (var item in res.Data)
{
    if (item.Purpose == "assistants")
    {
        var res1 = await cl.AssistantFileCreateAsync(id, item.Id);
    }
}
Get run and steps intomarion of thread.

C#
var threadId = "thread_xxxxxxxxxxxx";
var res = await client.RunsAsync(threadId);
foreach (var item in res.Data)
{
    var res1 = await cl.RunStepsAsync(threadId, item.Id);
    foreach (var step in res1.Data)
    {
        if (step.Step_Details != null)
        {
            Console.WriteLine(step.Step_Details.GetDescription());
        }
    }
}
 