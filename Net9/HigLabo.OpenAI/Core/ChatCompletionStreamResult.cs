using HigLabo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI;

public class ChatCompletionStreamResult
{
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
    public string GetReasoningContent()
    {
        var sb = new StringBuilder(this.ChunkList.Count * 32);
        for (int i = 0; i < this.ChunkList.Count; i++)
        {
            for (int cIndex = 0; cIndex < this.ChunkList[i].Choices.Count; cIndex++)
            {
                var delta = this.ChunkList[i].Choices[cIndex].Delta;
                if (delta != null)
                {
                    sb.Append(delta.Reasoning_Content);
                }
            }
        }
        return sb.ToString();
    }
    public FunctionCallResult? GetFunctionCall()
    {
        return this.GetFunctionCallList().FirstOrDefault();
    }
    public List<FunctionCallResult> GetFunctionCallList()
    {
        var l = new List<FunctionCallResult>();
        FunctionCallResult? f = null;

        foreach (var chunk in this.ChunkList)
        {
            foreach (var choice in chunk.Choices)
            {
                if (choice.Delta == null) { continue; }
                foreach (var toolCall in choice.Delta.Tool_Calls)
                {
                    if (toolCall.Function != null)
                    {
                        if (toolCall.Function.Name.HasValue())
                        {
                            f = l.Find(el => el.Name == toolCall.Function.Name);
                            if (f == null)
                            {
                                f = new FunctionCallResult();
                                f.Name = toolCall.Function.Name;
                                l.Add(f);
                            }
                        }
                        if (f != null)
                        {
                            if (toolCall.Function.Arguments.HasValue())
                            {
                                f.Arguments += toolCall.Function.Arguments;
                            }
                        }
                    }
                }
            }
        }
        return l;
    }
    public string GetFinishReason()
    {
        for (int i = this.ChunkList.Count - 1; i >= 0; i--)
        {
            var chunk = this.ChunkList[i];
            foreach (var choice in chunk.Choices)
            {
                if (choice.Finish_Reason == null) { continue; }
                if (choice.Finish_Reason.IsNullOrEmpty()) { continue; }
                return choice.Finish_Reason;
            }
        }
        return "";
    }
    public ChatCompletionUsageResult? GetUsageResult()
    {
        for (int i = this.ChunkList.Count - 1; i > -1; i--)
        {
            if (this.ChunkList[i].Usage != null) { return this.ChunkList[i].Usage; }
        }
        return null;
    }
}
