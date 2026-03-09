using HigLabo.Core;
using Newtonsoft.Json;

namespace HigLabo.Anthropic.SampleConsoleApp;

public class AnthropicClientPlayground
{
    private sealed class GetTickerSymbolToolCallResult
    {
        public string Company_Name { get; set; } = "";
    }
    private sealed class GetPlaceListToolCallResult
    {
        public string[] City_List { get; set; } = [];
    }

    public AnthropicClient AnthropicClient { get; set; } = new();

    public async ValueTask ExecuteAsync()
    {
        SetSetting();
        await CallToolStream();
        Console.WriteLine("■Completed");
    }
    private void SetSetting()
    {
        var apiKey = File.ReadAllText("C:\\Dev\\AnthropicApiKey.txt");
        AnthropicClient = new AnthropicClient(apiKey);
    }
    private async ValueTask SendMessage()
    {
        var cl = AnthropicClient;

        var p = new MessagesParameter();
        p.Messages.Add(new ChatMessage(ChatMessageRole.User, $"How to enjoy coffee?"));
        p.Model = ModelNames.ClaudeSonnet4;
        p.Max_Tokens = 1024;
        var res = await cl.MessagesAsync(p);

        foreach (var item in res.Content)
        {
            Console.WriteLine(item.Text);
        }
        var iRes = res as IRestApiResponse;
        Console.WriteLine(iRes.RequestBodyText);
        Console.WriteLine();
        Console.WriteLine(iRes.ResponseBodyText);
    }
    private async ValueTask SendMessageAsStream()
    {
        var cl = AnthropicClient;

        var p = new MessagesParameter();
        p.AddUserMessage("How to enjoy coffee?");
        p.Model = ModelNames.ClaudeSonnet4;
        p.Max_Tokens = 1024;
        var result = new MessagesStreamResult();
        await foreach (var item in cl.MessagesStreamAsync(p, result, CancellationToken.None))
        {
            Console.Write(item);
        }
        Console.WriteLine("***********************");
        if (result.MessageDelta != null)
        {
            Console.WriteLine("StopReason: " + result.MessageDelta.Delta.Stop_Reason);
            Console.WriteLine("Usage: " + result.MessageDelta.Usage.Output_Tokens);
        }
    }
    private async ValueTask SendMessageAsStream1()
    {
        var cl = AnthropicClient;

        var result = new MessagesStreamResult();
        await foreach (var item in cl.MessagesStreamAsync("How to enjoy coffee?", ModelNames.ClaudeSonnet4, result, CancellationToken.None))
        {
            Console.Write(item);
        }
        if (result.MessageDelta != null)
        {
            Console.WriteLine("StopReason: " + result.MessageDelta.Delta.Stop_Reason);
            Console.WriteLine("Usage: " + result.MessageDelta.Usage.Output_Tokens);
        }
    }
    private async ValueTask SendMessageWithTool()
    {
        var cl = AnthropicClient;

        var p = new MessagesParameter();
        p.AddUserMessage("What is the weather like in Tokyo?");
        p.Model = ModelNames.ClaudeSonnet4;
        p.Max_Tokens = 1024;
        p.Tools = new();
        var tool = new AnthropicTool("get_weather", "Get the current weather in a given location.");
        tool.Input_Schema = new
        {
            type = "object",
            properties = new
            {
                location = new
                {
                    type = "string",
                    description = "The city and state, e.g. San Francisco, CA.",
                },
                unit = new
                {
                    type = "string",
                    @enum = new string[] { "celsius", "fahrenheit" },
                    description = "The unit of temperature, either \"celsius\" or \"fahrenheit\""
                }
            }
        };
        p.Tools.Add(tool);

        var res = await cl.MessagesAsync(p);
        foreach (var item in res.Content)
        {
            if (item.Type == "text")
            {
                Console.WriteLine(item.Text);
            }
            else if (item.Type == "tool_use")
            {
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Input);
            }
        }

        var iRes = res as IRestApiResponse;
        Console.WriteLine();
        Console.WriteLine("■Request");
        Console.WriteLine(iRes.RequestBodyText);
        Console.WriteLine();
        Console.WriteLine("■Response");
        Console.WriteLine(iRes.ResponseBodyText);
    }
    private async ValueTask SendMessageStreamWithTool()
    {
        var cl = AnthropicClient;

        var p = new MessagesParameter();
        p.AddUserMessage("What is the weather like in Tokyo?");
        p.Model = ModelNames.ClaudeSonnet4;
        p.Max_Tokens = 1024;
        p.Tools = new();
        var tool = new AnthropicTool("get_weather", "Get the current weather in a given location.");
        tool.Input_Schema = new
        {
            type = "object",
            properties = new
            {
                location = new
                {
                    type = "string",
                    description = "The city and state, e.g. San Francisco, CA.",
                },
                unit = new
                {
                    type = "string",
                    @enum = new string[] { "celsius", "fahrenheit" },
                    description = "The unit of temperature, either \"celsius\" or \"fahrenheit\""
                }
            }
        };
        p.Tools.Add(tool);

        var result = new MessagesStreamResult();
        await foreach (var item in cl.MessagesStreamAsync(p, result, CancellationToken.None))
        {
            Console.Write(item);
        }
        Console.WriteLine(result.GetInputJson());
    }
    private async ValueTask CallTool()
    {
        var cl = AnthropicClient;

        var tools = new AnthropicTools();
        tools.Add(CreateGetTickerSymbolTool());

        var p = new MessagesParameter();
        p.Messages.Add(new ChatMessage(ChatMessageRole.User, $"What is the current stock price of Microsoft?"));
        p.SetTools(tools);
        p.Model = ModelNames.ClaudeSonnet4;
        p.Max_Tokens = 1024;
        var res = await cl.MessagesAsync(p);

        foreach (var item in res.Content)
        {
            if (item.Type == "text")
            {
                Console.WriteLine(item.Text);
            }
        }
        var functionCalls = res.GetFunctionCallList();
        WriteFunctionCalls(functionCalls);
    }
    private async ValueTask CallToolStream()
    {
        var cl = AnthropicClient;


        var p = new MessagesParameter();
        p.Model = ModelNames.ClaudeSonnet4;
        p.Messages.Add(new ChatMessage(ChatMessageRole.User, $"What is the current stock price of Microsoft?"));

        var tools = new AnthropicTools();
        tools.Add(CreateGetTickerSymbolTool());
        p.SetTools(tools);

        p.Tool_Choice = new
        {
            type = "any",
        };
        p.Max_Tokens = 1024;
        p.Stream = true;

        var result = new MessagesStreamResult();
        await foreach (var item in cl.MessagesStreamAsync(p, result, CancellationToken.None))
        {
            Console.Write(item);
        }

        Console.WriteLine(result.GetInputJson());

        var functionCalls = result.GetFunctionCallList();
        WriteFunctionCalls(functionCalls);
        var functionCall = functionCalls.Find(el => el.Name == "GetTickerSymbol");
        if (functionCall != null)
        {
            Console.WriteLine(functionCall.ToString());
            var toolCallResult = JsonConvert.DeserializeObject<GetTickerSymbolToolCallResult>(functionCall.Arguments);
            var companyName = toolCallResult?.Company_Name ?? "";
            var tickerSymbol = GetTickerSymbol(companyName);
        }
    }
    private string GetTickerSymbol(string companyName)
    {
        return "1234";
    }

    private async ValueTask CallToolArrayStream()
    {
        var cl = AnthropicClient;

        var tools = new AnthropicTools();
        tools.Add(CreateGetPlaceListTool());

        var p = new MessagesParameter();
        p.Messages.Add(new ChatMessage(ChatMessageRole.User, $"Please list up city names in Japan at least 10."));
        p.SetTools(tools);
        p.Model = ModelNames.ClaudeSonnet4;
        p.Max_Tokens = 1024;

        var result = new MessagesStreamResult();
        await foreach (var item in cl.MessagesStreamAsync(p, result, CancellationToken.None))
        {
            Console.Write(item);
        }

        var functionCalls = result.GetFunctionCallList();
        WriteFunctionCalls(functionCalls);
        var functionCall = functionCalls.Find(el => el.Name == "GetPlaceList");
        if (functionCall != null)
        {
            var toolCallResult = JsonConvert.DeserializeObject<GetPlaceListToolCallResult>(functionCall.Arguments);
            var cityList = toolCallResult?.City_List ?? [];
            var placeList = GetPlaceList(cityList);
        }
    }
    private string[] GetPlaceList(string[] cityList)
    {
        return ["Sky tree", "Dooutonbori", "Kokugikan", "Koukyo"];
    }
    private static AnthropicTool CreateGetTickerSymbolTool()
    {
        var tool = new AnthropicTool("GetTickerSymbol", "Gets the stock ticker symbol for a company searched by name. Returns str: The ticker symbol for the company stock. Raises TickerNotFound: if no matching ticker symbol is found.");
        var schema = new JsonSchema();
        schema.Properties.Add("company_name", new JsonSchemaProperty("string", "The name of company"));
        schema.Required = ["company_name"];
        tool.Input_Schema = schema;
        return tool;
    }
    private static AnthropicTool CreateGetPlaceListTool()
    {
        var tool = new AnthropicTool("GetPlaceList", "Gets place list of specified city.");
        var schema = new JsonSchema();
        schema.Properties.Add("city_list", new JsonSchemaProperty("array", "The name of city.")
        {
            Items = new JsonSchema("string"),
        });
        schema.Required = ["city_list"];
        tool.Input_Schema = schema;
        return tool;
    }

    private async ValueTask SendImage()
    {
        var cl = AnthropicClient;

        var p = new MessagesParameter();
        p.Model = ModelNames.ClaudeSonnet4;
        p.Max_Tokens = 1024;

        var msg = new ChatImageMessage(ChatMessageRole.User);
        msg.AddTextContent($"What is this image include?");
        msg.AddImageFile(Path.Combine(Environment.CurrentDirectory, "Image", "Rock.jpg"));
        p.Messages.Add(msg);
        p.Stream = true;

        var result = new MessagesStreamResult();
        await foreach (var item in cl.MessagesStreamAsync(p, result, CancellationToken.None))
        {
            Console.Write(item);
        }
    }
    private static void WriteFunctionCalls(List<FunctionCallResult> functionCalls)
    {
        if (functionCalls.Count == 0) { return; }

        Console.WriteLine();
        Console.WriteLine("■Function call list");
        foreach (var item in functionCalls)
        {
            Console.WriteLine($"{item.Name} {item.Arguments}");
        }
    }
}
