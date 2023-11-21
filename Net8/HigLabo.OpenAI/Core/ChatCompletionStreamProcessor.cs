using HigLabo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    public class ChatCompletionStreamProcessor
    {
        public class FunctionCallResult
        {
            public string Name { get; set; } = "";
            public string Arguments { get; set; } = "";
        }
        public List<ChatCompletionChunk> ChunkList { get; init; } = new();

        public void Process(ChatCompletionChunk chunk)
        {
            this.ChunkList.Add(chunk);
        }
        public string GetContent()
        {
            var sb = new StringBuilder(this.ChunkList.Count * 32);
            for (int i = 0; i < this.ChunkList.Count; i++)
            {
                for (int cIndex = 0; cIndex < this.ChunkList[i].Choices.Count; cIndex++)
                {
                    var delta = this.ChunkList[i].Choices[cIndex].Delta;
                    if(delta != null)
                    {
                        sb.Append(delta.Content);
                    }
                }
            }
            return sb.ToString();
        }
        public FunctionCallResult? GetFunctionCall()
        {
            var f = new FunctionCallResult();
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
