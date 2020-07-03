namespace HigLabo.Net.Imap
{
    /// <summary>Specifies whether server and client is connected,or disconnected or authenticated.
    /// <remarks>
    ///	<list type="bullet">
    /// <item>
    /// <term>Disconnected</term>
    /// <description>Server and client does not connected</description>
    /// <term>Connected</term>
    /// <description>Server and client communicate with tcp/ip.</description>
    /// <term>Authenticated</term>
    /// <description>Server and client authenticate success.</description>
    /// </item>
    /// </list>
    /// </remarks>
    /// </summary>
    public enum ImapConnectionState
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
        Idle,
    }

}
