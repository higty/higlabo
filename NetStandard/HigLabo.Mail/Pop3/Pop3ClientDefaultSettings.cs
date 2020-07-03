using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Net.Pop3
{
    public class Pop3ClientDefaultSettings : SocketClientDefaultSettings
    {
        /// 認証の方法を取得または設定します。
        /// <summary>
        /// Get or set how authenticate to server.
        /// 認証の方法を取得または設定します。
        /// </summary>
        public Pop3AuthenticateMode AuthenticateMode { get; set; }
        public Pop3ClientDefaultSettings()
        {
            this.Port = 110;
            this.AuthenticateMode = Pop3AuthenticateMode.Pop;
        }
    }
}
