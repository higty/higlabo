using HigLabo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.GoogleAI
{
    public class GenerateContentStreamResult
    {
        public List<Candidate> Candidates { get; init; } = new();

        public void Process(Candidate candidate)
        {
            this.Candidates.Add(candidate);
        }
        public string GetText()
        {
            var sb = new StringBuilder(512);
            foreach (var candidate in this.Candidates)
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
            foreach (var candidate in this.Candidates)
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
}
