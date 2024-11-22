using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.OAuth;

public class RefreshTokenException : Exception
{
    public String Error { get; set; } = "";
    public String Error_Description { get; set; } = "";
}
