using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    public class HyperParameter
    {
        public string N_Epochs { get; set; } = "";
    }
    public class FineTuningJob
    {
        public string Id { get; set; } = "";
        public int CreateAt { get; set; }
        public string Error { get; set; } = "";
        public string Fine_Tuned_Model { get; set; } = "";
        public int? Finished_At { get; set; }
        public HyperParameter? HyperParameters { get; set; }
        public string Model { get; set; } = "";
        public string Object { get; set; } = "";
        public string Organization_Id { get; set; } = "";
        public List<string> Result_Files { get; set; } = new();
        public string Status { get; set; } = "";
        public int? Trained_Tokens { get; set; }
        public string Training_File { get; set; } = "";
        public string Validation_File { get; set; } = "";
    }
    public class FineTuningJobResponse : RestApiResponse
    {
        public string Id { get; set; } = "";
        public int CreateAt { get; set; }
        public string Error { get; set; } = "";
        public string Fine_Tuned_Model { get; set; } = "";
        public int? Finished_At { get; set; }
        public HyperParameter? HyperParameters { get; set; }
        public string Model { get; set; } = "";
        public string Organization_Id { get; set; } = "";
        public List<string> Result_Files { get; set; } = new();
        public string Status { get; set; } = "";
        public int? Trained_Tokens { get; set; }
        public string Training_File { get; set; } = "";
        public string Validation_File { get; set; } = "";
    }
}
