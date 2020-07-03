using System;
using System.Collections.Generic;
using System.Text;

namespace HigLabo.Net.Pop3
{
    /// <summary>Specifies how to login to mail server.
	/// <remarks>
    ///	<list type="bullet">
    /// <item>
    /// <term>Pop</term>
    /// <description>With Pop authenticate to login server.</description>
    /// <term>APop</term>
	/// <description>With A-Pop authenticate to login server.</description>
    /// </item>
    /// </list>
    /// </remarks>
    /// </summary>
    public enum Pop3AuthenticateMode
    {
		/// <summary>
		/// Automatically determine authentication mode.
		/// </summary>
        Auto, 
		/// <summary>
		/// 
		/// </summary>
		Pop, 
		/// <summary>
		/// 
		/// </summary>
		APop
    }
}
