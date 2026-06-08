using HigLabo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.GoogleAI;

public class GenerateContentStreamResult
{
    public List<ModelsGenerateContentObject> ResponseList { get; init; } = new();
    public List<Candidate> Candidates => this.GetCandidates().ToList();

    public void Process(ModelsGenerateContentObject response)
    {
        this.ResponseList.Add(response);
    }
    public IEnumerable<Candidate> GetCandidates()
    {
        foreach (var response in this.ResponseList)
        {
            foreach (var candidate in response.Candidates)
            {
                yield return candidate;
            }
        }
    }
    public UsageMetadata? GetUsageResult()
    {
        for (int i = this.ResponseList.Count - 1; i > -1; i--)
        {
            var usage = this.ResponseList[i].UsageMetadata;
            if (usage.TotalTokenCount > 0 ||
                usage.PromptTokenCount > 0 ||
                usage.CandidatesTokenCount > 0 ||
                usage.ThoughtsTokenCount > 0)
            {
                return usage;
            }
        }
        return null;
    }
    public string GetText()
    {
        var sb = new StringBuilder(512);
        foreach (var candidate in this.GetCandidates())
        {
            foreach (var part in candidate.Content.Parts)
            {
                sb.Append(part.ToString()!);
            }
        }
        return sb.ToString();
    }
    public FunctionCall? GetFunctionCall()
    {
        return this.GetFunctionCallList().FirstOrDefault();
    }
    public List<FunctionCall> GetFunctionCallList()
    {
        var l = new List<FunctionCall>();
        foreach (var candidate in this.GetCandidates())
        {
            foreach (var part in candidate.Content.Parts)
            {
                if (part.FunctionCall != null)
                {
                    l.Add(part.FunctionCall);
                }
            }
        }
        return l;
    }
}
