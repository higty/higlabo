using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core;

public enum ToggleState
{
    Visible,
    Hidden,
}
public static class ToggleStateExtensions
{
    public static ToggleState GetOpositeToggleState(this ToggleState state)
    {
        switch (state)
        {
            case ToggleState.Visible: return ToggleState.Hidden;
            case ToggleState.Hidden: return ToggleState.Visible;
            default: throw SwitchStatementNotImplementException.Create(state);
        }
    }
}
