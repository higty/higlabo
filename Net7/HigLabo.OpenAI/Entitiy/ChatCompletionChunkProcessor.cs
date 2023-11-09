using HigLabo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    public class ChatCompletionChunkProcessor
    {
        public List<ChatCompletionChunk> ChunkList { get; init; } = new();

        public void Process(ChatCompletionChunk chunk)
        {
            this.ChunkList.Add(chunk);
        }
        public ChatCompletionChunk.FunctionCall? GetFunctionCall()
        {
            var f = new ChatCompletionChunk.FunctionCall();
            var functionCallExists = false;

            var sb = new StringBuilder();
            foreach (var chunk in this.ChunkList)
            {
                foreach (var choice in chunk.Choices)
                {
                    if (choice.Delta == null) { continue; }
                    foreach (var toolCall in choice.Delta.Tool_Calls)
                    {
                        if (toolCall.Function != null)
                        {
                            functionCallExists = true;
                            if (toolCall.Function.Name.IsNullOrEmpty() == false)
                            {
                                f.Name = toolCall.Function.Name;
                            }
                            if (toolCall.Function.Arguments.IsNullOrEmpty() == false)
                            {
                                sb.Append(toolCall.Function.Arguments);
                            }
                        }
                    }
                }
            }
            if (functionCallExists == false) { return null; }

            f.Arguments = sb.ToString();

            return f;
        }
    }
}
