using System;
using System.Collections.Generic;
using System.Text;

namespace HigLabo.Csv
{
    public interface ICsvExport
    {
        IEnumerable<String> GetHeader();
        IEnumerable<String[]> GetRows();
    }
}
