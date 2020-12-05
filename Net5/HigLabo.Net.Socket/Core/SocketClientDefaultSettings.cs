using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Net
{
        public class SocketClientDefaultSettings
        {
            /// 認証に使用するユーザー名を取得または設定します。
            /// <summary>
            /// Get or set UserName.
            /// 認証に使用するユーザー名を取得または設定します。
            /// </summary>
            public String UserName { get; set; }
            /// 認証に使用するパスワードを取得または設定します。
            /// <summary>
            /// Get or set password.
            /// 認証に使用するパスワードを取得または設定します。
            /// </summary>
            public String Password { get; set; }
            /// POP3メールサーバーのサーバー名を取得または設定します。
            /// <summary>
            /// Get or set server.
            /// POP3メールサーバーのサーバー名を取得または設定します。
            /// </summary>
            public String ServerName { get; set; }
            /// 通信に使用するPort番号を取得または設定します。
            /// <summary>
            /// Get or set port.
            /// 通信に使用するPort番号を取得または設定します。
            /// </summary>
            public Int32 Port { get; set; }
            /// 通信をSSLで暗号化するかどうかを示す値を取得または設定します。
            /// <summary>
            /// Get or set use ssl protocol.
            /// 通信をSSLで暗号化するかどうかを示す値を取得または設定します。
            /// </summary>
            public Boolean Ssl { get; set; }
            /// 送信データのエンコーディングを取得または設定します。
            /// <summary>
            /// 送信データのエンコーディングを取得または設定します。
            /// </summary>
            public Encoding RequestEncoding { get; set; }
            /// 受信データのエンコーディングを取得または設定します。
            /// <summary>
            /// 受信データのエンコーディングを取得または設定します。
            /// </summary>
            public Encoding ResponseEncoding { get; set; }
            /// 受信処理のタイムアウトの秒数をミリ秒単位で取得または設定します。
            /// <summary>
            /// Get or set timeout milliseconds.
            /// 受信処理のタイムアウトの秒数をミリ秒単位で取得または設定します。
            /// </summary>
            public Int32 ReceiveTimeout { get; set; }
            /// 送信データのバッファサイズを取得または設定します。
            /// <summary>
            /// Get or set buffer size to send.
            /// 送信データのバッファサイズを取得または設定します。
            /// </summary>
            public Int32 SendBufferSize { get; set; }
            /// 受信データのバッファサイズを取得または設定します。
            /// <summary>
            /// Get or set buffer size to receive.
            /// 受信データのバッファサイズを取得または設定します。
            /// </summary>
            public Int32 ReceiveBufferSize { get; set; }
            public SocketClientDefaultSettings()
            {
                this.UserName = "";
                this.Password = "";
                this.ServerName = "";
                this.Port = -1;
                this.Ssl = false;
                this.RequestEncoding = Encoding.UTF8;
                this.ResponseEncoding = Encoding.UTF8;
                this.ReceiveTimeout = 60 * 1000;
                this.SendBufferSize = 8192;
                this.ReceiveBufferSize = 8192;
            }
        }
}
