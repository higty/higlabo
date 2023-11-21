using System;
using System.Collections.Generic;
using System.Text;

namespace HigLabo.Net.Smtp
{
    /// Specify about connection state to server.
    /// <summary>
    /// Specify about connection state to server.
    /// <remarks>
    ///	<list type="bullet">
    /// <item>
    /// <term>Disconnected</term>
    /// <description>Not connected to server</description>
    /// <term>Connected</term>
    /// <description>Connect to server with TCP/IP protocol</description>
    /// <term>Authenticated</term>
    /// <description>Success to authenticate to server</description>
    /// </item>
    /// </list>
    /// </remarks>
    /// </summary>
    public enum SmtpConnectionState
    {
		/// <summary>
		/// 
		/// </summary>
        Disconnected, 
		/// <summary>
		/// 
		/// </summary>
		Connected, 
		/// <summary>
		/// 
		/// </summary>
		Authenticated, 
		/// <summary>
		/// 
		/// </summary>
        MailFromCommandExecuting, 
		/// <summary>
		/// 
		/// </summary>
		MailFromCommandExecuted, 
		/// <summary>
		/// 
		/// </summary>
        RcptToCommandExecuting, 
		/// <summary>
		/// 
		/// </summary>
		RcptToCommandExecuted,
		/// <summary>
		/// 
		/// </summary>
        DataCommandExecuting, 
		/// <summary>
		/// 
		/// </summary>
		DataCommandExecuted
    }
}
