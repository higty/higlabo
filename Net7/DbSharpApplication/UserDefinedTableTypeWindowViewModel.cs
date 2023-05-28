using HigLabo.DbSharp.MetaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbSharpApplication
{
    public class UserDefinedTableTypeWindowViewModel
    {
        public GenerateSetting GenerateSetting { get; init; }
        public UserDefinedTableType UserDefinedTableType { get; set; }

        public UserDefinedTableTypeWindowViewModel(GenerateSetting generateSetting, UserDefinedTableType userDefinedTableType)
        {
            this.GenerateSetting = generateSetting;
            this.UserDefinedTableType = userDefinedTableType;
        }
    }
}
