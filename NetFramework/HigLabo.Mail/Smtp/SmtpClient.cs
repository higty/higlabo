using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;
using System.Net;
#if NETFX_CORE
using System.Threading.Tasks;
using Windows.Networking;
using Windows.Networking.Sockets;
#else
using System.Net.Sockets;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
#endif
using System.Net.NetworkInformation;
using HigLabo.Net.Mail;
using HigLabo.Net.Internal;
using HigLabo.Net.Pop3;
using HigLabo.Mime;
using HigLabo.Converter;
using HigLabo.Core;

namespace HigLabo.Net.Smtp
{
    /// Represent and probide functionality about smtp command.
    /// <summary>
    /// Represent and probide functionality about smtp command.
    /// </summary>
    public partial class SmtpClient : SocketClient, IDisposable
    {
        public new static readonly SmtpClientDefaultSettings Default = new SmtpClientDefaultSettings();
        private static readonly Base64Converter Base64Converter = new Base64Converter(100);
        private SmtpAuthenticateMode _Mode = Default.AuthenticateMode;
        private String _HostName = Default.HostName;
        private SmtpEncryptedCommunication _EncryptedCommunication = Default.EncryptedCommunication;
        private Pop3Client _Pop3Client = new Pop3Client("127.0.0.1");
        private SmtpConnectionState _State = SmtpConnectionState.Disconnected;
        /// 認証の方法を取得または設定します。
        /// <summary>
        /// 認証の方法を取得または設定します。
        /// </summary>
        public SmtpAuthenticateMode AuthenticateMode
        {
            get { return this._Mode; }
            set { this._Mode = value; }
        }
        /// 送信元マシンのホスト名を取得または設定します。
        /// <summary>
        /// 送信元マシンのホスト名を取得または設定します。
        /// </summary>
        public String HostName
        {
            get { return this._HostName; }
            set { this._HostName = value; }
        }
        /// 通信を暗号化するかどうかを示す値を取得または設定します。
        /// <summary>
        /// 通信を暗号化するかどうかを示す値を取得または設定します。
        /// </summary>
        public SmtpEncryptedCommunication EncryptedCommunication
        {
            get { return _EncryptedCommunication; }
            set
            {
                _EncryptedCommunication = value;
                if (value == SmtpEncryptedCommunication.Ssl)
                {
                    base.Ssl = true;
                }
            }
        }
        /// 通信をSSLで暗号化するかどうかを示す値を取得します。
        /// <summary>
        /// Get use ssl protocol.
        /// To set use ssl or tls protocol, set EncryptedCommunication property.
        /// 通信をSSLで暗号化するかどうかを示す値を取得します。
        /// </summary>
        public new Boolean Ssl
        {
            get { return base.Ssl; }
        }
        /// 接続の状態を示す値を取得します。
        /// <summary>
        /// 接続の状態を示す値を取得します。
        /// </summary>
        public SmtpConnectionState State
        {
            get { return this._State; }
        }
        /// サーバーへ接続済みかどうかを示す値を取得します。
        /// <summary>
        /// サーバーへ接続済みかどうかを示す値を取得します。
        /// </summary>
        public Boolean Available
        {
            get { return this._State != SmtpConnectionState.Disconnected; }
        }
        /// PopBeforeSmtp認証を行う場合に使用されるPop3Clientを取得します。
        /// <summary>
        /// PopBeforeSmtp認証を行う場合に使用されるPop3Clientを取得します。
        /// </summary>
        public Pop3Client Pop3Client
        {
            get { return this._Pop3Client; }
        }

        /// <summary>
        /// 
        /// </summary>
        public SmtpClient()
            : base(Default.ServerName, Default.Port)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="provider"></param>
        public SmtpClient(EmailServiceProvider provider)
            : this(provider, Default.UserName, Default.Password)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public SmtpClient(EmailServiceProvider provider, String userName, String password)
            : this()
        {
            this.SetProperty(provider);
            this.UserName = userName;
            this.Password = password;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverName"></param>
        public SmtpClient(String serverName)
            : this(serverName, Default.Port, Default.UserName, Default.Password)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverName"></param>
        /// <param name="port"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public SmtpClient(String serverName, Int32 port, String userName, String password)
            : base(serverName, port, userName, password, Default)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="provider"></param>
        public void SetProperty(EmailServiceProvider provider)
        {
            String serverName = "";
            Int32 port = Default.Port;
            SmtpEncryptedCommunication encryptedCommunication = SmtpEncryptedCommunication.None;

            switch (provider)
            {
                case EmailServiceProvider.Gmail: serverName = "smtp.gmail.com"; encryptedCommunication = SmtpEncryptedCommunication.Tls; break;
                case EmailServiceProvider.Outlook: serverName = "smtp-mail.outlook.com"; encryptedCommunication = SmtpEncryptedCommunication.Tls; break;
                case EmailServiceProvider.YahooMail: serverName = "smtp.mail.yahoo.com"; encryptedCommunication = SmtpEncryptedCommunication.Ssl; break;
                case EmailServiceProvider.AolMail: serverName = "smtp.aol.com"; encryptedCommunication = SmtpEncryptedCommunication.Tls; break;
                case EmailServiceProvider.ZohoMail: serverName = "smtp.zoho.com"; encryptedCommunication = SmtpEncryptedCommunication.Ssl; break;
                default: throw new InvalidOperationException();
            }
            this.ServerName = serverName;
        
            switch (encryptedCommunication)
            {
                case SmtpEncryptedCommunication.None: port = 25; break;
                case SmtpEncryptedCommunication.Ssl: port = 465; break;
                case SmtpEncryptedCommunication.Tls: port = 587; break;
                default: throw new InvalidOperationException();
            }
            this.Port = port;
            this.EncryptedCommunication = encryptedCommunication;
        }
        /// サーバーへの接続を開きます。
        /// <summary>
        /// サーバーへの接続を開きます。
        /// </summary>
        public SmtpConnectionState Open()
        {
            if (this.Connect() == true)
            {
                var rs = this.GetResponse();
                if (rs.StatusCode == SmtpCommandResultCode.ServiceReady)
                {
                    this._State = SmtpConnectionState.Connected;
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                this._State = SmtpConnectionState.Disconnected;
            }
            return this._State;
        }
        /// サーバーへの接続が開かれていない場合、サーバーへの接続を開きます。
        /// <summary>
        /// サーバーへの接続が開かれていない場合、サーバーへの接続を開きます。
        /// </summary>
        public SmtpConnectionState EnsureOpen()
        {
            if (this.Socket != null)
            { return this._State; }
            return this.Open();
        }
        private SmtpCommandResult GetResponse()
        {
            List<SmtpCommandResultLine> l = new List<SmtpCommandResultLine>();
            String lineText = "";
            SmtpCommandResultLine CurrentLine = null;
            Byte[] bb = this.GetResponseBytes(new SmtpDataReceiveContext(this.ResponseEncoding));
            StringReader sr = new StringReader(this.ResponseEncoding.GetString(bb));
            while (true)
            {
                lineText = sr.ReadLine();
                if (lineText.IsNullOrEmpty() == true) { break; }

                CurrentLine = new SmtpCommandResultLine(lineText);
                l.Add(CurrentLine);
                //次の行があるかチェック
                if (CurrentLine.HasNextLine == false)
                { break; }
            }
            this.SetSmtpCommandState();
            return new SmtpCommandResult(l.ToArray());
        }
        /// SMTPコマンドの種類に基づいて状態を変化させます。
        /// <summary>
        /// SMTPコマンドの種類に基づいて状態を変化させます。
        /// </summary>
        /// <param name="command"></param>
        private void SetSmtpCommandState(SmtpCommand command)
        {
            if (command is MailCommand)
            {
                this._State = SmtpConnectionState.MailFromCommandExecuting;
            }
            else if (command is RcptCommand)
            {
                this._State = SmtpConnectionState.RcptToCommandExecuting;
            }
            else if (command is DataCommand)
            {
                this._State = SmtpConnectionState.DataCommandExecuting;
            }
        }
        /// サーバーからのレスポンスの受信時に現在の状態に基づいて状態を変化させます。
        /// <summary>
        /// サーバーからのレスポンスの受信時に現在の状態に基づいて状態を変化させます。
        /// </summary>
        private void SetSmtpCommandState()
        {
            this.Commnicating = false;
            switch (this._State)
            {
                case SmtpConnectionState.MailFromCommandExecuting: this._State = SmtpConnectionState.MailFromCommandExecuted; break;
                case SmtpConnectionState.RcptToCommandExecuted: this._State = SmtpConnectionState.RcptToCommandExecuted; break;
                case SmtpConnectionState.DataCommandExecuting: this._State = SmtpConnectionState.DataCommandExecuted; break;
            }
        }
        /// SMTPサーバーに認証が必要かどうかを示す値を取得します。
        /// <summary>
        /// SMTPサーバーに認証が必要かどうかを示す値を取得します。
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private static Boolean NeedAuthenticate(String text)
        {
            return text.IndexOf("auth", StringComparison.OrdinalIgnoreCase) > -1;
        }
        /// StartTLSコマンドをサーバーに対して送信し、暗号化された通信を開始します。
        /// <summary>
        /// StartTLSコマンドをサーバーに対して送信し、暗号化された通信を開始します。
        /// </summary>
#if NETFX_CORE
        private Boolean StartTls()
        {
            SmtpCommandResult rs = null;

            if (this.EnsureOpen() == SmtpConnectionState.Connected)
            {
                rs = this.Execute("STARTTLS");
                if (rs.StatusCode != SmtpCommandResultCode.ServiceReady)
                { return false; }

                base.Ssl = true;
                this.EncryptedCommunication = SmtpEncryptedCommunication.Tls;
                var t = this.Socket.UpgradeToSslAsync(SocketProtectionLevel.Ssl, new HostName(this.ServerName)).AsTask();
                t.Wait();
                return true;
            }
            return false;
        }
#else
        private Boolean StartTls()
        {
            SmtpCommandResult rs = null;

            if (this.EnsureOpen() == SmtpConnectionState.Connected)
            {
                rs = this.Execute("STARTTLS");
                if (rs.StatusCode != SmtpCommandResultCode.ServiceReady)
                { return false; }

                base.Ssl = true;
                this.EncryptedCommunication = SmtpEncryptedCommunication.Tls;
                SslStream ssl = new SslStream(new NetworkStream(this.Socket), true, this.RemoteCertificateValidationCallback, null);
                ssl.AuthenticateAsClient(this.ServerName);
                this.Stream = ssl;
                return true;
            }
            return false;
        }
#endif
        /// <summary>
        /// Log in to smtp server.Please use TryAuthenticate method if you don't want to throw exception.
        /// </summary>
        public void Authenticate()
        {
            if (this.TryAuthenticate() == false)
            {
                throw new SmtpAuthenticateException();
            }
        }
        /// SMTPメールサーバーへログインします。
        /// <summary>
        /// SMTPメールサーバーへログインします。
        /// </summary>
        /// <returns></returns>
        public Boolean TryAuthenticate()
        {
            SmtpCommandResult rs = null;

            if (this._Mode == SmtpAuthenticateMode.Auto)
            {
                if (this.EnsureOpen() == SmtpConnectionState.Connected)
                {
                    rs = this.ExecuteEhlo();
                    String s = rs.Message.ToUpper();
                    //SMTP認証に対応している場合
                    if (s.Contains("AUTH") == true)
                    {
                        if (s.Contains("LOGIN") == true)
                        { return this.AuthenticateByLogin(); }
                        if (s.Contains("PLAIN") == true)
                        { return this.AuthenticateByPlain(); }
                        if (s.Contains("CRAM-MD5") == true)
                        { return this.AuthenticateByCramMD5(); }
                    }
                    else
                    {
                        rs = this.ExecuteEhlo();
                        return rs.StatusCode == SmtpCommandResultCode.ServiceReady;
                    }
                    //TLS認証
                    if (this.EncryptedCommunication == SmtpEncryptedCommunication.Tls)
                    {
                        if (s.Contains("STARTTLS") == false)
                        { throw new MailClientException("TLS is not allowed."); }
                        this.StartTls();
                        rs = this.ExecuteEhlo();
                        return rs.StatusCode == SmtpCommandResultCode.ServiceReady;
                    }
                }
            }
            else
            {
                switch (this._Mode)
                {
                    case SmtpAuthenticateMode.None: return true;
                    case SmtpAuthenticateMode.Plain: return this.AuthenticateByPlain();
                    case SmtpAuthenticateMode.Login: return this.AuthenticateByLogin();
                    case SmtpAuthenticateMode.Cram_MD5: return this.AuthenticateByCramMD5();
                    case SmtpAuthenticateMode.PopBeforeSmtp:
                        {
                            Boolean bl = this._Pop3Client.TryAuthenticate();
                            this._Pop3Client.Close();
                            return bl;
                        }
                }
                throw new InvalidOperationException();
            }
            return false;
        }
        /// SMTPメールサーバーへPlain認証でログインします。
        /// <summary>
        /// SMTPメールサーバーへPlain認証でログインします。
        /// </summary>
        /// <returns></returns>
        public Boolean AuthenticateByPlain()
        {
            SmtpCommandResult rs = null;

            if (this.EnsureOpen() == SmtpConnectionState.Connected)
            {
                rs = this.Execute("Auth Plain");
                if (rs.StatusCode != SmtpCommandResultCode.WaitingForAuthentication)
                { return false; }
                //ユーザー名＆パスワードの文字列を送信
                rs = this.Execute(Base64Converter.Encode(Encoding.UTF8.GetBytes(String.Format("{0}\0{0}\0{1}", this.UserName, this.Password))));
                if (rs.StatusCode == SmtpCommandResultCode.AuthenticationSuccessful)
                {
                    this._State = SmtpConnectionState.Authenticated;
                }
            }
            return this._State == SmtpConnectionState.Authenticated;
        }
        /// SMTPメールサーバーへLogin認証でログインします。
        /// <summary>
        /// SMTPメールサーバーへLogin認証でログインします。
        /// </summary>
        /// <returns></returns>
        public Boolean AuthenticateByLogin()
        {
            SmtpCommandResult rs = null;

            if (this.EnsureOpen() == SmtpConnectionState.Connected)
            {
                rs = this.Execute("Auth Login");
                if (rs.StatusCode != SmtpCommandResultCode.WaitingForAuthentication)
                { return false; }
                //ユーザー名送信
                rs = this.Execute(Base64Converter.Encode(Encoding.UTF8.GetBytes(this.UserName)));
                if (rs.StatusCode != SmtpCommandResultCode.WaitingForAuthentication)
                { return false; }
                //パスワード送信
                rs = this.Execute(Base64Converter.Encode(Encoding.UTF8.GetBytes(this.Password)));
                if (rs.StatusCode == SmtpCommandResultCode.AuthenticationSuccessful)
                {
                    this._State = SmtpConnectionState.Authenticated;
                }
            }
            return this._State == SmtpConnectionState.Authenticated;
        }
        /// SMTPメールサーバーへCRAM-MD5認証でログインします。
        /// <summary>
        /// SMTPメールサーバーへCRAM-MD5認証でログインします。
        /// </summary>
        /// <returns></returns>
        public Boolean AuthenticateByCramMD5()
        {
            SmtpCommandResult rs = null;

            if (this.EnsureOpen() == SmtpConnectionState.Connected)
            {
                rs = this.Execute("Auth CRAM-MD5");
                if (rs.StatusCode != SmtpCommandResultCode.WaitingForAuthentication)
                { return false; }
                //ユーザー名＋チャレンジ文字列をBase64エンコードした文字列を送信
                String s = SmtpClient.ToCramMd5String(rs.Message, this.UserName, this.Password);
                rs = this.Execute(s);
                if (rs.StatusCode == SmtpCommandResultCode.AuthenticationSuccessful)
                {
                    this._State = SmtpConnectionState.Authenticated;
                }
            }
            return this._State == SmtpConnectionState.Authenticated;
        }
        /// 同期でSMTPメールサーバーへコマンドを送信し、コマンドの種類によってはレスポンスデータを受信して返します。
        /// <summary>
        /// 同期でSMTPメールサーバーへコマンドを送信し、コマンドの種類によってはレスポンスデータを受信して返します。
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public SmtpCommandResult Execute(SmtpCommand command)
        {
            return this.Execute(command.GetCommandString());
        }
        private SmtpCommandResult Execute(String command)
        {
            this.Send(command);
            this.Commnicating = true;
            return this.GetResponse();
        }
        private SmtpCommandResult Execute(Byte[] command)
        {
            var mm = new MemoryStream();
            mm.Write(command);
            mm.WriteByte(13);
            mm.WriteByte(10);
            mm.Position = 0;
            this.Send(mm);
            this.Commnicating = true;
            return this.GetResponse();
        }
        /// SMTPメールサーバーへEHLOコマンドを送信します。
        /// <summary>
        /// SMTPメールサーバーへEHLOコマンドを送信します。
        /// </summary>
        /// <returns></returns>
        public SmtpCommandResult ExecuteEhlo()
        {
            this.EnsureOpen();
            return this.Execute(new EhloCommand(this._HostName));
        }
        /// SMTPメールサーバーへHELOコマンドを送信します。
        /// <summary>
        /// SMTPメールサーバーへHELOコマンドを送信します。
        /// </summary>
        /// <returns></returns>
        public SmtpCommandResult ExecuteHelo()
        {
            this.EnsureOpen();
            return this.Execute(new HeloCommand(this._HostName));
        }
        private SmtpCommandResult ExecuteEhloAndHelo()
        {
            SmtpCommandResult rs = null;
            //サーバーへメールトランザクションの開始コマンドを送信
            rs = this.ExecuteEhlo();
            if (rs.StatusCode != SmtpCommandResultCode.RequestedMailActionOkay_Completed)
            {
                rs = this.ExecuteHelo();
            }
            return rs;
        }
        /// SMTPメールサーバーへMAILコマンドを送信します。
        /// <summary>
        /// SMTPメールサーバーへMAILコマンドを送信します。
        /// </summary>
        /// <returns></returns>
        public SmtpCommandResult ExecuteMail(String reversePath)
        {
            this.EnsureOpen();
            return this.Execute(new MailCommand(reversePath));
        }
        /// SMTPメールサーバーへRCPTコマンドを送信します。
        /// <summary>
        /// SMTPメールサーバーへRCPTコマンドを送信します。
        /// </summary>
        /// <returns></returns>
        public SmtpCommandResult ExecuteRcpt(String forwardPath)
        {
            this.EnsureOpen();
            return this.Execute(new RcptCommand(forwardPath));
        }
        /// SMTPメールサーバーへDATAコマンドを送信します。
        /// <summary>
        /// SMTPメールサーバーへDATAコマンドを送信します。
        /// </summary>
        /// <returns></returns>
        public SmtpCommandResult ExecuteData()
        {
            this.EnsureOpen();
            return this.Execute(new DataCommand());
        }
        /// SMTPメールサーバーへRESETコマンドを送信します。
        /// <summary>
        /// SMTPメールサーバーへRESETコマンドを送信します。
        /// </summary>
        /// <returns></returns>
        public SmtpCommandResult ExecuteRset()
        {
            this.EnsureOpen();
            return this.Execute(new RsetCommand());
        }
        /// SMTPメールサーバーへVRFYコマンドを送信します。
        /// <summary>
        /// SMTPメールサーバーへVRFYコマンドを送信します。
        /// </summary>
        /// <returns></returns>
        public SmtpCommandResult ExecuteVrfy(String userName)
        {
            this.EnsureOpen();
            return this.Execute(new VrfyCommand(userName));
        }
        /// SMTPメールサーバーへEXPNコマンドを送信します。
        /// <summary>
        /// SMTPメールサーバーへEXPNコマンドを送信します。
        /// </summary>
        /// <returns></returns>
        public SmtpCommandResult ExecuteExpn(String mailingList)
        {
            this.EnsureOpen();
            return this.Execute(new ExpnCommand(mailingList));
        }
        /// SMTPメールサーバーへHELPコマンドを送信します。
        /// <summary>
        /// SMTPメールサーバーへHELPコマンドを送信します。
        /// </summary>
        /// <returns></returns>
        public SmtpCommandResult ExecuteHelp()
        {
            this.EnsureOpen();
            return this.Execute(new HelpCommand());
        }
        /// SMTPメールサーバーへNOOPコマンドを送信します。
        /// <summary>
        /// SMTPメールサーバーへNOOPコマンドを送信します。
        /// </summary>
        /// <returns></returns>
        public SmtpCommandResult ExecuteNoop()
        {
            this.EnsureOpen();
            return this.Execute("Noop");
        }
        /// SMTPメールサーバーへQUITコマンドを送信します。
        /// <summary>
        /// SMTPメールサーバーへQUITコマンドを送信します。
        /// </summary>
        /// <returns></returns>
        public SmtpCommandResult ExecuteQuit()
        {
            this.EnsureOpen();
            var rs = this.Execute("Quit");
            //サーバー側から強制的に接続が切断されるので一度Disposeを呼び出してTcpClient=nullにする。
            if (rs.StatusCode == SmtpCommandResultCode.ServiceClosingTransmissionChannel)
            {
                this.DisposeSocket();
            }
            return rs;
        }
        /// メールを送信し、送信結果となるSendMailResultを取得します。
        /// <summary>
        /// メールを送信し、送信結果となるSendMailResultを取得します。
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="cc"></param>
        /// <param name="bcc"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public SendMailResult SendMail(String from, String to, String cc, String bcc, Byte[] data)
        {
            List<MailAddress> l = new List<MailAddress>();
            String[] ss = null;
            MailAddress m = null;

            ss = to.Split(',');
            for (int i = 0; i < ss.Length; i++)
            {
                m = MailAddress.TryCreate(ss[i]);
                if (m == null) { continue; }
                l.Add(m);
            }
            ss = cc.Split(',');
            for (int i = 0; i < ss.Length; i++)
            {
                m = MailAddress.TryCreate(ss[i]);
                if (m == null) { continue; }
                l.Add(m);
            }
            ss = bcc.Split(',');
            for (int i = 0; i < ss.Length; i++)
            {
                m = MailAddress.TryCreate(ss[i]);
                if (m == null) { continue; }
                l.Add(m);
            }
            return this.SendMail(new SendMailCommand(from, data, l));
        }
        /// メールを送信し、送信結果となるSendMailResultを取得します。
        /// <summary>
        /// メールを送信し、送信結果となるSendMailResultを取得します。
        /// </summary>
        /// <param name="from"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public SendMailResult SendMail(String from, SmtpMessage message)
        {
            return this.SendMail(new SendMailCommand(from, message));
        }
        /// メールを送信し、送信結果となるSendMailListResultを取得します。
        /// <summary>
        /// メールを送信し、送信結果となるSendMailListResultを取得します。
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public SendMailResult SendMail(SmtpMessage message)
        {
            return this.SendMail(new SendMailCommand(message));
        }
        /// メールを送信し、送信結果となるSendMailListResultを取得します。
        /// <summary>
        /// メールを送信し、送信結果となるSendMailListResultを取得します。
        /// </summary>
        /// <param name="messages"></param>
        /// <returns></returns>
        public SendMailListResult SendMailList(IEnumerable<SmtpMessage> messages)
        {
            List<SendMailCommand> l = new List<SendMailCommand>();
            foreach (var mg in messages)
            {
                l.Add(new SendMailCommand(mg));
            }
            return this.SendMailList(l.ToArray());
        }
        /// メールを送信し、送信結果となるSendMailListResultを取得します。
        /// <summary>
        /// メールを送信し、送信結果となるSendMailListResultを取得します。
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public SendMailResult SendMail(SendMailCommand command)
        {
            var l = this.SendMailList(new[] { command });
            if (l.Results.Count == 1)
            {
                return new SendMailResult(l.Results[0].State, command);
            }
            return new SendMailResult(l.State, command);
        }
        /// メールを送信し、送信結果となるSendMailListResultを取得します。
        /// <summary>
        /// メールを送信し、送信結果となるSendMailListResultを取得します。
        /// </summary>
        /// <param name="commandList"></param>
        /// <returns></returns>
        public SendMailListResult SendMailList(IEnumerable<SendMailCommand> commandList)
        {
            SmtpCommandResult rs = null;
            Boolean HasRcpt = false;

            //接続失敗
            if (this.EnsureOpen() == SmtpConnectionState.Disconnected)
            { return new SendMailListResult(SendMailResultState.Connection); }

            //不正な状態でのメソッドの実行
            if (this.State != SmtpConnectionState.Connected &&
                this.State != SmtpConnectionState.Authenticated)
            {
                return new SendMailListResult(SendMailResultState.InvalidState);
            }
            //認証済みで無い場合
            if (this.State != SmtpConnectionState.Authenticated)
            {
                //サーバーへメールトランザクションの開始コマンドを送信
                rs = this.ExecuteEhloAndHelo();
                if (rs.StatusCode != SmtpCommandResultCode.RequestedMailActionOkay_Completed)
                { return new SendMailListResult(SendMailResultState.Helo); }
                //TLS/SSL通信
                if (this.EncryptedCommunication == SmtpEncryptedCommunication.Tls)
                {
                    if (this.StartTls() == false)
                    { return new SendMailListResult(SendMailResultState.Tls); }
                    rs = this.ExecuteEhloAndHelo();
                    if (rs.StatusCode != SmtpCommandResultCode.RequestedMailActionOkay_Completed)
                    { return new SendMailListResult(SendMailResultState.Helo); }
                }
                //ログイン認証が必要とされるかチェック
                if (SmtpClient.NeedAuthenticate(rs.Message) == true)
                {
                    this.Authenticate();
                }
            }

            List<SendMailResult> results = new List<SendMailResult>();

            foreach (var command in commandList)
            {
                //Mail Fromの送信
                if (command.From == null ||
                    command.From.Value == null)
                {
                    rs = this.ExecuteMail("");
                }
                else if (command.From.Value.StartsWith("<") == true)
                {
                    rs = this.ExecuteMail(command.From.Value);
                }
                else
                {
                    rs = this.ExecuteMail("<" + command.From.Value + ">");
                } 
                if (rs.StatusCode != SmtpCommandResultCode.RequestedMailActionOkay_Completed)
                {
                    results.Add(new SendMailResult(SendMailResultState.MailFrom, command));
                    continue;
                }
                List<MailAddress> mailAddressList = new List<MailAddress>();
                //Rcpt Toの送信
                StringBuilder sb = new StringBuilder();
                foreach (var m in command.RcptTo)
                {
                    String mailAddress = m.ToString();
                    if (mailAddress.StartsWith("<") == true && mailAddress.EndsWith(">") == true)
                    {
                        rs = this.ExecuteRcpt(mailAddress);
                    }
                    else
                    {
                        rs = this.ExecuteRcpt("<" + mailAddress + ">");
                    }
                    if (rs.StatusCode == SmtpCommandResultCode.RequestedMailActionOkay_Completed)
                    {
                        HasRcpt = true;
                    }
                    else
                    {
                        mailAddressList.Add(m);
                    }
                    sb.AppendLine(rs.Message);
                }
                if (HasRcpt == false)
                {
                    results.Add(new SendMailResult(SendMailResultState.Rcpt, command, sb.ToString(), mailAddressList));
                    continue;
                }
                //Dataの送信
                rs = this.ExecuteData();
                if (rs.StatusCode == SmtpCommandResultCode.StartMailInput)
                {
                    this.Send(command.Data);
                    rs = this.GetResponse();
                    if (rs.StatusCode == SmtpCommandResultCode.RequestedMailActionOkay_Completed)
                    {
                        results.Add(new SendMailResult(SendMailResultState.Success, command, rs.Message, mailAddressList));
                        this.ExecuteRset();
                    }
                    else
                    {
                        results.Add(new SendMailResult(SendMailResultState.Data, command, rs.Message, mailAddressList));
                    }
                }
                else
                {
                    results.Add(new SendMailResult(SendMailResultState.Data, command, rs.Message, mailAddressList));
                }
            }
            rs = this.ExecuteQuit();

            if (results.Exists(el => el.State != SendMailResultState.Success) == true)
            {
                return new SendMailListResult(SendMailResultState.SendMailData, results);
            }
            return new SendMailListResult(SendMailResultState.Success, results);
        }
        /// <summary>
        /// 
        /// </summary>
        ~SmtpClient()
        {
            this.Dispose(false);
        }

        /// Cram-MD5に従って文字列を変換します。
        /// <summary>
        /// Cram-MD5に従って文字列を変換します。
        /// </summary>
        /// <param name="challenge"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private static String ToCramMd5String(String challenge, String userName, String password)
        {
            // ユーザ名と計算したHMAC-MD5ハッシュ値をBase64エンコードしてレスポンスとして返す
            var bb = Encoding.UTF8.GetBytes(String.Format("{0} {1}", userName, Cryptography.ToCramMd5String(challenge, password)));
            return Convert.ToBase64String(bb);
        }
    }
}
