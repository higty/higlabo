using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp
{
    public interface ISaveMode
    {
        SaveMode SaveMode { get; set; }
    }
    public enum SaveMode
    {
        Unknown,
        Insert,
        Update, 
        Delete,
    }
}
