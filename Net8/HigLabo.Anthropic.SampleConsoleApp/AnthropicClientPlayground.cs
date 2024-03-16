using HigLabo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Anthropic.SampleConsoleApp
{
    public class AnthropicClientPlayground
    {
        public AnthropicClient AnthropicClient { get; set; } = new();

        public async ValueTask ExecuteAsync()
        {
            SetOpenAISetting();
            await SendMessageAsStream();
            Console.WriteLine("■Completed");

        }
        private void SetOpenAISetting()
        {
            var apiKey = File.ReadAllText("C:\\Dev\\AnthropicApiKey.txt");
            AnthropicClient = new AnthropicClient(apiKey);
        }
        private async ValueTask SendMessage()
        {
            var cl = AnthropicClient;

            var p = new MessagesParameter();
            var theme = "How to enjoy coffee";
            p.Messages.Add(new ChatMessage(ChatMessageRole.User
                , $"Can you provide me with some ideas for blog posts about {theme}?"));
            p.Model = ModelNames.Claude3Opus;
            p.Max_Tokens = 1024;
            var res = await cl.SendJsonAsync<MessagesParameter, MessagesObjectResponseResponse>(p);

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
            var theme = "How to enjoy coffee";
            p.Messages.Add(new ChatMessage(ChatMessageRole.User
                , $"Can you provide me with some ideas for blog posts about {theme}?"));
            p.Model = ModelNames.Claude3Opus;
            p.Max_Tokens = 1024;
            p.Stream = true;

            var result = new MessagesStreamResult();
            await foreach (var item in cl.MessagesStreamAsync(p, result, CancellationToken.None))
            {
                Console.Write(item.Delta.Text);
            }

            Console.WriteLine("***********************");
            Console.WriteLine(result.GetContent());
            Console.WriteLine("StopReason: " + result.StopReason);
            Console.WriteLine("Usage: " + result.OutputTokens);
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
                Console.Write(item.Delta.Text);
            }

            Console.WriteLine("***********************");
        }
    }
}
