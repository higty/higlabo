using System;
using System.Collections.Generic;
using System.Text;

namespace HigLabo.Net.Smtp
{
    /// Specify the way to login mail server.
    /// <summary>
    /// Specify the way to login mail server.
    /// <remarks>
    ///	<list type="bullet">
    /// <item>
    /// <term>Auto</term>
    /// <description>Select authenticate mode automatically.</description>
    /// <term>Plain</term>
    /// <description>Use plain authenticate mode.</description>
    /// <term>Login</term>
    /// <description>Use login authenticate mode.</description>
    /// <term>Cram_MD5</term>
    /// <description>Use CRAM-MD5 authenticate mode.</description>
    /// </item>
    /// </list>
    /// </remarks>
    /// </summary>
    public enum SmtpAuthenticateMode
    {
		/// <summary>
		/// 
		/// </summary>
        Auto, 
		/// <summary>
		/// 
		/// </summary>
		None, 
		/// <summary>
		/// 
		/// </summary>
		Plain, 
		/// <summary>
		/// 
		/// </summary>
		Login, 
		/// <summary>
		/// 
		/// </summary>
		Cram_MD5,
        /// <summary>
        /// 
        /// </summary>
        PopBeforeSmtp,
    }
}
