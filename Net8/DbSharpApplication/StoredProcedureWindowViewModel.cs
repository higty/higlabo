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
        public GenerateSetting GenerateSetting { get; init; }
        public StoredProcedure StoredProcedure { get; init; }

        public StoredProcedureWindowViewModel(GenerateSetting generateSetting, StoredProcedure storedProcedure)
        {
            this.GenerateSetting = generateSetting;
            this.StoredProcedure = storedProcedure;
        }
    }
}
