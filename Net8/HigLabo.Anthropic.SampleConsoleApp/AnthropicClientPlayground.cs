using HigLabo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Anthropic.SampleConsoleApp
{
    public class AnthropicClientPlayground
    {
        public AnthropicClient AnthropicClient { get; set; } = new();

        public async ValueTask ExecuteAsync()
        {
            SetSetting();
            await SendMessageAsStream();
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
            p.Model = ModelNames.Claude3Opus;
            p.Max_Tokens = 1024;
            var res = await cl.SendJsonAsync<MessagesParameter, MessagesObjectResponse>(p);

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
            p.Model = ModelNames.Claude3Opus;
            p.Max_Tokens = 1024;
            var result = new MessagesStreamResult();
            await foreach (var item in cl.MessagesStreamAsync(p, result, CancellationToken.None))
            {
                Console.Write(item);
            }
            Console.WriteLine("***********************");
            if(result.MessageDelta != null)
            {
                Console.WriteLine("StopReason: " + result.MessageDelta.Delta.Stop_Reason);
                Console.WriteLine("Usage: " + result.MessageDelta.Usage.Output_Tokens);
            }
        }
        private async ValueTask SendMessageAsStream1()
        {
            var cl = AnthropicClient;

            var result = new MessagesStreamResult();
            await foreach (var item in cl.MessagesStreamAsync("How to enjoy coffee?", ModelNames.Claude3Opus, result, CancellationToken.None))
            {
                Console.Write(item);
            }
            if (result.MessageDelta != null)
            {
                Console.WriteLine("StopReason: " + result.MessageDelta.Delta.Stop_Reason);
                Console.WriteLine("Usage: " + result.MessageDelta.Usage.Output_Tokens);
            }
        }
        private async ValueTask CallTool()
        {
            var cl = AnthropicClient;

            var tool = new AnthropicTool("GetTickerSymbol", "Gets the stock ticker symbol for a company searched by name. Returns str: The ticker symbol for the company stock. Raises TickerNotFound: if no matching ticker symbol is found.");
            tool.Parameters.Add(new AnthropicToolParameter("company_name", "string", "The name of company"));
            var toolXml = tool.ToString();

            var p = new MessagesParameter();
            p.Messages.Add(new ChatMessage(ChatMessageRole.User, $"What is the current stock price of Microsoft?"));
            p.System = $@"In this environment you have access to a set of tools you can use to answer the user's question.

You may call them like this:
<function_calls>
<invoke>
<tool_name>$TOOL_NAME</tool_name>
<parameters>
<$PARAMETER_NAME>$PARAMETER_VALUE</$PARAMETER_NAME>
...
</parameters>
</invoke>
</function_calls>

Here are the tools available:
{toolXml}
";
            p.Model = ModelNames.Claude3Opus;
            p.Max_Tokens = 1024;
            var res = await cl.SendJsonAsync<MessagesParameter, MessagesObjectResponse>(p);

            foreach (var item in res.Content)
            {
                Console.WriteLine(item.Text);

                var calls = await AnthropicFunctionCalls.ParseAsync(item.Text);
                if (calls.InvokeList.Count > 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("■Function call list");
                    Console.WriteLine(calls.ToString());
                }
            }
        }
        private async ValueTask CallToolStream()
        {
            var cl = AnthropicClient;

            var tools = new AnthropicTools();
            var tool = new AnthropicTool("GetTickerSymbol", "Gets the stock ticker symbol for a company searched by name. Returns str: The ticker symbol for the company stock. Raises TickerNotFound: if no matching ticker symbol is found.");
            tool.Parameters.Add(new AnthropicToolParameter("company_name", "string", "The name of company"));
            tools.Add(tool);
            var toolXml = tool.ToString();

            var p = new MessagesParameter();
            p.Messages.Add(new ChatMessage(ChatMessageRole.User, $"What is the current stock price of Microsoft?"));
            p.SetTools(tools);
            p.Model = ModelNames.Claude3Opus;
            p.Max_Tokens = 1024;
            p.Stream = true;

            var result = new MessagesStreamResult();
            await foreach (var item in cl.MessagesStreamAsync(p, result, CancellationToken.None))
            {
                Console.Write(item);
            }

            var calls = await AnthropicFunctionCalls.ParseAsync(result.GetText());
            if (calls.InvokeList.Count > 0)
            {
                Console.WriteLine();
                Console.WriteLine("■Function call list");
                Console.WriteLine(calls.ToString());

                var invoke = calls.InvokeList.Find(el => el.ToolName == "GetTickerSymbol");
                if (invoke != null)
                {
                    var companyName = invoke.GetParameterValue("company_name") ?? "";
                    var tickerSymbol = GetTickerSymbol(companyName);
                }
            }
        }
        private string GetTickerSymbol(string companyName)
        {
            //Dummy value
            return "1234";
        }

        private async ValueTask CallToolArrayStream()
        {
            var cl = AnthropicClient;

            var tools = new AnthropicTools();
            var tool = new AnthropicTool("GetPlaceList", "Gets place list of specified city.");
            tool.Parameters.Add(new AnthropicToolParameter("city_list", "array", "The name of city. The value must be separated by comma."));
            tools.Add(tool);
            var toolXml = tool.ToString();

            var p = new MessagesParameter();
            p.Messages.Add(new ChatMessage(ChatMessageRole.User, $"Please list up city names in Japan at least 10."));
            p.SetTools(tools);
            p.Model = ModelNames.Claude3Opus;
            p.Max_Tokens = 1024;

            var result = new MessagesStreamResult();
            await foreach (var item in cl.MessagesStreamAsync(p, result, CancellationToken.None))
            {
                Console.Write(item);
            }

            var text = result.GetText();
            var calls = await AnthropicFunctionCalls.ParseAsync(text);
            if (calls.InvokeList.Count > 0)
            {
                Console.WriteLine();
                Console.WriteLine("■Function call list");
                Console.WriteLine(calls.ToString());

                var invoke = calls.InvokeList.Find(el => el.ToolName == "GetPlaceList");
                if (invoke != null)
                {
                    var cityList = invoke.GetParameterValue("city_list") ?? "";
                    var placeList = GetPlaceList(cityList.Split(','));
                }
            }
        }
        private string[] GetPlaceList(string[] cityList)
        {
            return ["Sky tree", "Dooutonbori", "Kokugikan", "Koukyo"];
        }

        private async ValueTask SendImage()
        {
            var cl = AnthropicClient;

            var p = new MessagesParameter();
            p.Model = "claude-3-opus-20240229";
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
    }
}
