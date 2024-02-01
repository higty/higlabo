using HigLabo.DbSharp.MetaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbSharpApplication
{
    public class StoredProcedureWindowViewModel
    {
        public string ConnectionString { get; init; }
        public GenerateSetting GenerateSetting { get; init; }
        public StoredProcedure StoredProcedure { get; init; }

        public StoredProcedureWindowViewModel(string connectionString, GenerateSetting generateSetting, StoredProcedure storedProcedure)
        {
            this.ConnectionString = connectionString;
            this.GenerateSetting = generateSetting;
            this.StoredProcedure = storedProcedure;
        }
    }
}
