using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace HigLabo.DbSharp
{
    public abstract class UserDefinedTableTypeRecord : DatabaseRecord
    {
        public abstract Object[] GetValues();
    }
}
