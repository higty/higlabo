using System;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.IO;
using System.Collections.Generic;
using G = System.Collections.Generic;
using HigLabo.Net.Mail;
using HigLabo.Net.Internal;
using HigLabo.Mime;

namespace HigLabo.Net.Pop3
{
	/// Represent and probide functionality about pop3 command.
	/// <summary>
	/// Represent and probide functionality about pop3 command.
	/// </summary>
	public partial class Pop3Client : SocketClient, IDisposable
	{
        public new static readonly Pop3ClientDefaultSettings Default = new Pop3ClientDefaultSettings();
        private Pop3AuthenticateMode _Mode = Default.AuthenticateMode;
		private Pop3ConnectionState _State = Pop3ConnectionState.Disconnected;
        public MimeParser MimeParser { get; set; }
		public Pop3AuthenticateMode AuthenticateMode
		{
			get { return this._Mode; }
			set { this._Mode = value; }
		}
		public Pop3ConnectionState State
		{
            get
            {
                if (this.Connected == false)
                {
                    this._State = Pop3ConnectionState.Disconnected;
                }
                return this._State;
            }
            private set { this._State = value; }
		}
		public Boolean Available
		{
			get { return this._State != Pop3ConnectionState.Disconnected; }
		}

        public Pop3Client(EmailServiceProvider provider)
            : this(provider, Default.UserName, Default.Password)
        {
        }
        public Pop3Client(EmailServiceProvider provider, String userName, String password)
            : this("")
        {
            this.SetProperty(provider);
            this.UserName = userName;
            this.Password = password;
        }
        public Pop3Client(String serverName)
            : this(serverName, Default.Port, Default.UserName, Default.Password)
        {
        }
		public Pop3Client(String serverName, Int32 port, String userName, String password)
            : base(serverName, port, userName, password, Default)
        {
            this.MimeParser = new MimeParser();
		}

        public void SetProperty(EmailServiceProvider provider)
        {
            String serverName = "";

            switch (provider)
            {
                case EmailServiceProvider.Gmail: serverName = "pop.gmail.com"; break;
                case EmailServiceProvider.Outlook: serverName = "pop-mail.outlook.com"; break;
                case EmailServiceProvider.YahooMail: serverName = "pop.mail.yahoo.com"; break;
                case EmailServiceProvider.AolMail: serverName = "pop.aol.com"; break;
                case EmailServiceProvider.ZohoMail: serverName = "pop.zoho.com"; break;
                default: throw new InvalidOperationException();
            }
            this.ServerName = serverName;
            this.Port = 995;
            this.Ssl = true;
        }
        /// サーバーへの接続を開きます。
		/// <summary>
		/// Open connection to a server.
		/// サーバーへの接続を開きます。
		/// </summary>
		public Pop3ConnectionState Open()
		{
            if (this.Connect() == true)
            {
                var s = this.GetResponse();
                if (s.Ok == true)
                {
                    this.State = Pop3ConnectionState.Connected;
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                this.State = Pop3ConnectionState.Disconnected;
            }
            return this._State;
		}
		/// サーバーへの接続が開かれていない場合、サーバーへの接続を開きます。
		/// <summary>
		/// Ensure connection is opened.
		/// サーバーへの接続が開かれていない場合、サーバーへの接続を開きます。
		/// </summary>
		public Pop3ConnectionState EnsureOpen()
		{
			if (this.Socket != null)
			{ return this._State; }

			return this.Open();
		}
		private void CheckAuthenticate()
		{
			if (this._State == Pop3ConnectionState.Authenticated) { return; }
            throw new MailClientException("You must authenticate to pop3 server before executing this command.");
		}
        private void CheckResponseError(Pop3CommandResult result)
        {
            if (result.Ok == true) { return; }
            throw new MailClientException(result.Text);
        }
        private Pop3CommandResult GetResponse()
		{
			return this.GetResponse(false);
		}
		private Pop3CommandResult GetResponse(Boolean isMultiLine)
		{
			MemoryStream ms = new MemoryStream();
			this.GetResponse(ms, isMultiLine);
			var s = this.ResponseEncoding.GetString(ms.ToArray());
            return new Pop3CommandResult(s);
		}
		private void GetResponse(Stream stream)
		{
			this.GetResponse(stream, false);
		}
		private void GetResponse(Stream stream, Boolean isMultiLine)
		{
            this.GetResponseStream(new Pop3DataReceiveContext(stream, this.ResponseEncoding, isMultiLine));
            this.Commnicating = false;
		}
        /// <summary>
        /// Log in to pop3 server.Please use TryAuthenticate method if you don't want to throw exception.
        /// </summary>
        public void Authenticate()
        {
            if (this.TryAuthenticate() == false)
            {
                throw new Pop3AuthenticateException();
            }
        }
        /// <summary>
        /// Log in to pop3 server by POP authenticate.
        /// </summary>
        public void AuthenticateByPop()
        {
            if (this.TryAuthenticateByPop() == false)
            {
                throw new Pop3AuthenticateException();
            }
        }
        /// <summary>
        /// Log in to pop3 server by A-POP authenticate.
        /// </summary>
        public void AuthenticateByAPop()
        {
            if (this.TryAuthenticateByAPop() == false)
            {
                throw new Pop3AuthenticateException();
            }
        }
        /// POP3メールサーバーへログインします。
		/// <summary>
		/// Log in to pop3 server and return login success or failure as bool.
		/// POP3メールサーバーへログインします。
		/// </summary>
		/// <returns></returns>
		public Boolean TryAuthenticate()
		{
			if (this._Mode == Pop3AuthenticateMode.Auto)
			{
                if (this.TryAuthenticateByPop() == true)
				{
					this._Mode = Pop3AuthenticateMode.Pop;
					return true;
				}
                else if (this.TryAuthenticateByAPop() == true)
				{
					this._Mode = Pop3AuthenticateMode.APop;
					return true;
				}
				return false;
			}
			else
			{
				switch (this._Mode)
				{
                    case Pop3AuthenticateMode.Pop: return this.TryAuthenticateByPop();
                    case Pop3AuthenticateMode.APop: return this.TryAuthenticateByAPop();
				}
			}
			return false;
		}
		/// POP3メールサーバーへPOP認証でログインします。
		/// <summary>
        /// Log in to pop3 server by POP authenticate and return login success or failure as bool.
		/// POP3メールサーバーへPOP認証でログインします。
		/// </summary>
		/// <returns></returns>
        public Boolean TryAuthenticateByPop()
		{
            Pop3CommandResult rs = null;

			if (this.EnsureOpen() == Pop3ConnectionState.Connected)
			{
				//ユーザー名送信
				rs = this.Execute("user " + this.UserName, false);
				if (rs.Ok == true)
				{
					//パスワード送信
					rs = this.Execute("pass " + this.Password, false);
					if (rs.Ok == true)
					{
						this._State = Pop3ConnectionState.Authenticated;
					}
				}
			}
			return this._State == Pop3ConnectionState.Authenticated;
		}
		/// POP3メールサーバーへAPOP認証でログインします。
		/// <summary>
        /// Log in to pop3 server by A-POP authenticate and return login success or failure as bool.
		/// POP3メールサーバーへAPOP認証でログインします。
		/// </summary>
		/// <returns></returns>
        public Boolean TryAuthenticateByAPop()
		{
            Pop3CommandResult rs = null;
			String TimeStamp = "";
			Int32 StartIndex = 0;
			Int32 EndIndex = 0;

			if (this.EnsureOpen() == Pop3ConnectionState.Connected)
			{
				//ユーザー名送信
				rs = this.Execute("user " + this.UserName, false);
				if (rs.Ok == true)
				{
					if (rs.Text.IndexOf("<") > -1 &&
						rs.Text.IndexOf(">") > -1)
					{
						StartIndex = rs.Text.IndexOf("<");
						EndIndex = rs.Text.IndexOf(">");
						TimeStamp = rs.Text.Substring(StartIndex, EndIndex - StartIndex + 1);
						//パスワード送信
						rs = this.Execute("pass " + Cryptography.ToMd5DigestString(TimeStamp + this.Password), false);
						if (rs.Ok == true)
						{
							this._State = Pop3ConnectionState.Authenticated;
						}
					}
				}
			}
			return this._State == Pop3ConnectionState.Authenticated;
		}
		/// 同期でPOP3メールサーバーへコマンドを送信し、コマンドの種類によってはレスポンスデータを受信して文字列として返します。
		/// <summary>
		/// Send a command with synchronous and get response data as string text if the command is a type to get response.
		/// 同期でPOP3メールサーバーへコマンドを送信し、コマンドの種類によってはレスポンスデータを受信して文字列として返します。
		/// </summary>
		/// <param name="command"></param>
		/// <returns></returns>
        public Pop3CommandResult Execute(Pop3Command command)
		{
			Boolean IsResponseMultiLine = false;

			if (command is TopCommand ||
				command is RetrCommand ||
				command is ListCommand ||
				command is UidlCommand)
			{
				IsResponseMultiLine = true;
			}
			return this.Execute(command.GetCommandString(), IsResponseMultiLine);
		}
		/// 同期でPOP3メールサーバーへコマンドを送信し、コマンドの種類によってはレスポンスデータを受信して文字列として返します。
		/// <summary>
		/// Send a command with synchronous and get response data as string text if the command is a type to get response.
		/// 同期でPOP3メールサーバーへコマンドを送信し、コマンドの種類によってはレスポンスデータを受信して文字列として返します。
		/// </summary>
		/// <param name="command"></param>
		/// <param name="isMultiLine"></param>
		/// <returns></returns>
        private Pop3CommandResult Execute(String command, Boolean isMultiLine)
		{
			this.Send(command);
			this.Commnicating = true;
			return this.GetResponse(isMultiLine);
		}
		/// 同期でPOP3メールサーバーへコマンドを送信し、コマンドの種類によってはレスポンスデータを受信して文字列として返します。
		/// <summary>
		/// Send a command with synchronous and get response data as string text if the command is a type to get response.
		/// 同期でPOP3メールサーバーへコマンドを送信し、コマンドの種類によってはレスポンスデータを受信して文字列として返します。
		/// </summary>
		/// <param name="stream"></param>
		/// <param name="command"></param>
		/// <returns></returns>
		public void Execute(Stream stream, Pop3Command command)
		{
			Boolean IsResponseMultiLine = false;

			if (command is TopCommand ||
				command is RetrCommand ||
				command is ListCommand ||
				command is UidlCommand)
			{
				IsResponseMultiLine = true;
			}
			this.Execute(stream, command.GetCommandString(), IsResponseMultiLine);
		}
		/// 同期でPOP3メールサーバーへコマンドを送信し、コマンドの種類によってはレスポンスデータを受信して文字列として返します。
		/// <summary>
		/// Send a command with synchronous and get response data as string text if the command is a type to get response.
		/// 同期でPOP3メールサーバーへコマンドを送信し、コマンドの種類によってはレスポンスデータを受信して文字列として返します。
		/// </summary>
		/// <param name="stream"></param>
		/// <param name="command"></param>
		/// <param name="isMultiLine"></param>
		/// <returns></returns>
		private void Execute(Stream stream, String command, Boolean isMultiLine)
		{
			this.Send(command);
			this.Commnicating = true;
			this.GetResponse(stream, isMultiLine);
		}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <param name="isMultiLine"></param>
        /// <param name="callbackFunction"></param>
        public void BeginExecute(String command, Boolean isMultiLine, Action<Pop3CommandResult> callbackFunction)
        {
            this.BeginSend(command, new Pop3DataReceiveContext(this.ResponseEncoding, isMultiLine, s => callbackFunction(new Pop3CommandResult(s)))
                , s => callbackFunction(new Pop3CommandResult(s)));
        }
		/// 非同期でPOP3メールサーバーへコマンドを送信します。受信したレスポンスの文字列はcallbackFunctionの引数として取得できます。
		/// <summary>
		/// Send a command with asynchronous and get response text by first parameter of callbackFunction.
		/// 非同期でPOP3メールサーバーへコマンドを送信します。受信したレスポンスの文字列はcallbackFunctionの引数として取得できます。
		/// </summary>
		/// <param name="command"></param>
		/// <param name="callbackFunction"></param>
        public void BeginExecute(Pop3Command command, Action<Pop3CommandResult> callbackFunction)
		{
            Boolean isMultiLine = false;

			if (command is TopCommand ||
				command is RetrCommand ||
				command is ListCommand ||
				command is UidlCommand)
			{
                isMultiLine = true;
			}
            this.BeginExecute(command.GetCommandString(), isMultiLine, callbackFunction);
		}
		/// POP3メールサーバーへListコマンドを送信します。
		/// <summary>
		/// Send list command to pop3 server.
		/// POP3メールサーバーへListコマンドを送信します。
		/// </summary>
		/// <param name="command"></param>
		/// <returns></returns>
		public List<ListCommandResult> ExecuteList(ListCommand command)
		{
			List<ListCommandResult> l = new List<ListCommandResult>();
			if (command.MailIndex.HasValue == true)
			{
				var rs = this.ExecuteList(command.MailIndex.Value);
				l.Add(rs);
			}
			else
			{
				l = this.ExecuteList();
			}
			return l;
		}
		/// POP3メールサーバーへListコマンドを送信します。
		/// <summary>
		/// Send list command to pop3 server.
		/// POP3メールサーバーへListコマンドを送信します。
		/// </summary>
		/// <param name="mailIndex"></param>
		/// <returns></returns>
		public ListCommandResult ExecuteList(Int64 mailIndex)
		{
			ListCommand cm = new ListCommand(mailIndex);
            Pop3CommandResult rs = null;

			this.CheckAuthenticate();
			rs = this.Execute(cm);
            this.CheckResponseError(rs);
			return new ListCommandResult(rs.Text);
		}
		/// POP3メールサーバーへListコマンドを送信します。
		/// <summary>
		/// Send list command to pop3 server.
		/// POP3メールサーバーへListコマンドを送信します。
		/// </summary>
		/// <returns></returns>
		public List<ListCommandResult> ExecuteList()
		{
			ListCommand cm = new ListCommand();
			List<ListCommandResult> l = new List<ListCommandResult>();
            Pop3CommandResult rs = null;
			StringReader sr = null;
			String line = "";

			this.CheckAuthenticate();
			rs = this.Execute(cm);
            this.CheckResponseError(rs);
            
            sr = new StringReader(rs.Text);
			while (sr.Peek() > -1)
			{
				line = sr.ReadLine();
				if (line == ".")
				{ break; }
				if (line.StartsWith("+OK", StringComparison.OrdinalIgnoreCase) == true)
				{ continue; }

				l.Add(new ListCommandResult(line));
			}
			return l;
		}
		/// POP3メールサーバーへUIDLコマンドを送信します。
		/// <summary>
		/// Send uidl command to pop3 server.
		/// POP3メールサーバーへUIDLコマンドを送信します。
		/// </summary>
		/// <param name="mailIndex"></param>
		/// <returns></returns>
		public UidlCommandResult ExecuteUidl(Int64 mailIndex)
		{
			UidlCommand cm = new UidlCommand(mailIndex);
            Pop3CommandResult rs = null;

			this.CheckAuthenticate();
			rs = this.Execute(cm);
            this.CheckResponseError(rs);

            return new UidlCommandResult(rs.Text);
		}
		/// POP3メールサーバーへUIDLコマンドを送信します。
		/// <summary>
		/// Send uidl command to pop3 server.
		/// POP3メールサーバーへUIDLコマンドを送信します。
		/// </summary>
		/// <returns></returns>
		public List<UidlCommandResult> ExecuteUidl()
		{
			UidlCommand cm = new UidlCommand();
			List<UidlCommandResult> l = new List<UidlCommandResult>();
            Pop3CommandResult rs = null;
			StringReader sr = null;
			String line = "";

			this.CheckAuthenticate();
			rs = this.Execute(cm);
            this.CheckResponseError(rs);
            
            sr = new StringReader(rs.Text);
			while (sr.Peek() > -1)
			{
				line = sr.ReadLine();
				if (line == ".")
				{ break; }
				if (line.StartsWith("+OK", StringComparison.OrdinalIgnoreCase) == true)
				{ continue; }

				l.Add(new UidlCommandResult(line));
			}
			return l;
		}
		/// POP3メールサーバーへRETRコマンドを送信します。
		/// <summary>
		/// Send retr command to pop3 server.
		/// POP3メールサーバーへRETRコマンドを送信します。
		/// </summary>
		/// <param name="mailIndex"></param>
		/// <returns></returns>
		public MailMessage ExecuteRetr(Int64 mailIndex)
		{
			return this.GetMessage(mailIndex);
		}
		/// POP3メールサーバーへTOPコマンドを送信します。
		/// <summary>
		/// Send top command to pop3 server.
		/// POP3メールサーバーへTOPコマンドを送信します。
		/// </summary>
		/// <param name="mailIndex"></param>
		/// <param name="lineCount"></param>
		/// <returns></returns>
		public Pop3CommandResult ExecuteTop(Int64 mailIndex, Int32 lineCount)
		{
            Pop3CommandResult rs = null;

            this.CheckAuthenticate();
            rs = this.Execute(new TopCommand(mailIndex, lineCount));
            this.CheckResponseError(rs);
            return rs;
        }
		/// POP3メールサーバーへDELEコマンドを送信します。
		/// <summary>
		/// Send dele command to pop3 server.
		/// POP3メールサーバーへDELEコマンドを送信します。
		/// </summary>
		/// <param name="mailIndex"></param>
		/// <returns></returns>
		public Pop3CommandResult ExecuteDele(Int64 mailIndex)
		{
			DeleCommand cm = new DeleCommand(mailIndex);
			Pop3CommandResult rs = null;

			this.CheckAuthenticate();
			rs = this.Execute(cm);
            this.CheckResponseError(rs);
			return rs;
		}
		/// POP3メールサーバーへSTATコマンドを送信します。
		/// <summary>
		/// Send stat command to pop3 server.
		/// POP3メールサーバーへSTATコマンドを送信します。
		/// </summary>
		/// <returns></returns>
		public StatCommandResult ExecuteStat()
		{
			Pop3CommandResult rs = null;

			this.CheckAuthenticate();
            rs = this.Execute("Stat", false);
            this.CheckResponseError(rs);
            return new StatCommandResult(rs.Text);
		}
		/// POP3メールサーバーへNOOPコマンドを送信します。
		/// <summary>
		/// Send noop command to pop3 server.
		/// POP3メールサーバーへNOOPコマンドを送信します。
		/// </summary>
		/// <returns></returns>
		public Pop3CommandResult ExecuteNoop()
		{
			Pop3CommandResult rs = null;

			this.EnsureOpen();
			rs = this.Execute("Noop", false);
			return new Pop3CommandResult(rs.Text);
		}
		/// POP3メールサーバーへRESETコマンドを送信します。
		/// <summary>
		/// Send reset command to pop3 server.
		/// POP3メールサーバーへRESETコマンドを送信します。
		/// </summary>
		/// <returns></returns>
		public Pop3CommandResult ExecuteRset()
		{
			Pop3CommandResult rs = null;

			this.CheckAuthenticate();
            rs = this.Execute("Rset", false);
            this.CheckResponseError(rs);
			return rs;
		}
		/// POP3メールサーバーへQUITコマンドを送信します。
		/// <summary>
		/// Send quit command to pop3 server.
		/// POP3メールサーバーへQUITコマンドを送信します。
		/// </summary>
		/// <returns></returns>
		public Pop3CommandResult ExecuteQuit()
		{
			Pop3CommandResult rs = null;
			
			this.EnsureOpen();
            rs = this.Execute("Quit", false);
            this.CheckResponseError(rs);
            //Server disconnect connection after server received quit command, so call Close method.
            this.Close();
            return rs;
		}
		/// メールボックスの総メール数を取得します。
		/// <summary>
		/// Get total mail count at mailbox.
		/// メールボックスの総メール数を取得します。
		/// </summary>
		/// <returns></returns>
		public Int64 GetTotalMessageCount()
		{
			StatCommandResult rs = null;
			rs = this.ExecuteStat();
			return rs.TotalMessageCount;
		}
        /// 指定したMailIndexのメールデータを取得します。
        /// <summary>
        /// Get mail data of specified mail index.
        /// 指定したMailIndexのメールデータを取得します。
        /// </summary>
        /// <param name="mailIndex"></param>
        /// <returns></returns>
        public Byte[] GetMessageData(Int64 mailIndex)
        {
            this.CheckAuthenticate();
            var cm = new RetrCommand(mailIndex);
            this.Send(cm.GetCommandString());
            this.Commnicating = true;
            var str = new MemoryStream();
            this.GetResponse(str, true);
            str.Position = 0;
            return str.ToArray();
        }
        /// 指定したMailIndexのメールデータを取得します。
		/// <summary>
		/// Get mail data of specified mail index.
		/// 指定したMailIndexのメールデータを取得します。
		/// </summary>
		/// <param name="mailIndex"></param>
		/// <returns></returns>
        public MailMessage GetMessage(Int64 mailIndex)
        {
            this.CheckAuthenticate();
            var cm = new RetrCommand(mailIndex);
            this.Send(cm.GetCommandString());
            this.Commnicating = true;
            var str = new MemoryStream();
            this.GetResponse(str, true);
            str.Position = 0;
            return this.MimeParser.ToMailMessage(str);
        }
		/// 指定したMailIndexのメールデータの文字列を取得します。
		/// <summary>
		/// Get mail text of specified mail index.
		/// 指定したMailIndexのメールデータの文字列を取得します。
		/// </summary>
		/// <param name="mailIndex"></param>
		/// <returns></returns>
		public String GetMessageText(Int64 mailIndex)
		{
			RetrCommand cm = null;

			this.CheckAuthenticate();
			try
			{
				cm = new RetrCommand(mailIndex);
				var rs = this.Execute(cm);
                return rs.Text;
			}
			catch (Exception ex)
			{
                throw new MailClientException(ex);
			}
		}
		/// 指定したMailIndexのメールデータの文字列を本文の行数を指定して取得します。
		/// <summary>
		/// Get mail text of specified mail index with indicate body line count.
		/// 指定したMailIndexのメールデータの文字列を本文の行数を指定して取得します。
		/// </summary>
		/// <param name="mailIndex"></param>
		/// <param name="lineCount"></param>
		/// <returns></returns>
		public String GetMessageText(Int64 mailIndex, Int32 lineCount)
		{
			TopCommand cm = null;

			this.CheckAuthenticate();
			try
			{
				cm = new TopCommand(mailIndex, lineCount);
				var rs = this.Execute(cm);
                return rs.Text;
			}
			catch (Exception ex)
			{
                throw new MailClientException(ex);
			}
		}
		/// 指定したMailIndexのメールデータの文字列を本文の行数を指定してストリームに出力します。
		/// <summary>
		/// Get mail text of specified mail index with indicate body line count.
		/// 指定したMailIndexのメールデータの文字列を本文の行数を指定してストリームに出力します。
		/// </summary>
		/// <param name="stream"></param>
		/// <param name="mailIndex"></param>
		/// <returns></returns>
		public void GetMessageText(Stream stream, Int64 mailIndex)
		{
			RetrCommand cm = null;

			this.CheckAuthenticate();
			try
			{
				cm = new RetrCommand(mailIndex);
				this.Execute(stream, cm);
			}
			catch (Exception ex)
			{
                throw new MailClientException(ex);
			}
		}
		/// 指定したMailIndexのメールデータの文字列を本文の行数を指定してストリームに出力します。
		/// <summary>
		/// Get mail text of specified mail index with indicate body line count.
		/// 指定したMailIndexのメールデータの文字列を本文の行数を指定してストリームに出力します。
		/// </summary>
		/// <param name="stream"></param>
		/// <param name="mailIndex"></param>
		/// <param name="lineCount"></param>
		/// <returns></returns>
		public void GetMessageText(Stream stream, Int64 mailIndex, Int32 lineCount)
		{
			TopCommand cm = null;

			this.CheckAuthenticate();
			try
			{
				cm = new TopCommand(mailIndex, lineCount);
				this.Execute(stream, cm);
			}
			catch (Exception ex)
			{
                throw new MailClientException(ex);
			}
		}
		/// 非同期で指定したMailIndexのメールデータの文字列を取得します。
		/// <summary>
		/// Get mail text of specified mail index by asynchronous request.
		/// 非同期で指定したMailIndexのメールデータの文字列を取得します。
		/// </summary>
		/// <param name="mailIndex"></param>
		/// <param name="callbackFunction"></param>
        public void GetMessageText(Int64 mailIndex, Action<Pop3CommandResult> callbackFunction)
		{
			RetrCommand cm = null;
			var md = callbackFunction;

			this.CheckAuthenticate();
			cm = new RetrCommand(mailIndex);
			this.BeginExecute(cm, md);
		}
        /// 指定したMailIndexのメールをメールサーバーから削除します。
        /// <summary>
        /// Set delete flag to specify mail index.
        /// To complete delete execution,call quit command after calling dele command.
        /// 指定したMailIndexのメールに削除フラグをたてます。
        /// 実際に削除するにはさらにQUITコマンドで削除処理を完了させる必要があります。
        /// </summary>
        /// <param name="indexList"></param>
        /// <returns></returns>
        public Boolean DeleteMail(params Int32[] indexList)
        {
            var newIndexList = new Int64[indexList.Length];
            for (int i = 0; i < indexList.Length; i++)
            {
                newIndexList[i] = indexList[i];
            }
            return DeleteMail(newIndexList);
        }
        /// 指定したMailIndexのメールをメールサーバーから削除します。
		/// <summary>
		/// Set delete flag to specify mail index.
		/// To complete delete execution,call quit command after calling dele command.
		/// 指定したMailIndexのメールに削除フラグをたてます。
		/// 実際に削除するにはさらにQUITコマンドで削除処理を完了させる必要があります。
		/// </summary>
        /// <param name="indexList"></param>
		/// <returns></returns>
		public Boolean DeleteMail(params Int64[] indexList)
		{
			DeleCommand cm = null;
            Pop3CommandResult rs = null;

            if (this.EnsureOpen() == Pop3ConnectionState.Disconnected) { return false; }
            if (this.TryAuthenticate() == false) { return false; }
            for (int i = 0; i < indexList.Length; i++)
            {
                cm = new DeleCommand(indexList[i]);
                rs = this.Execute(cm);
                if (rs.Ok == false) { return false; }
            }
            this.ExecuteQuit();
            return true;
		}
		/// 非同期でPOP3メールサーバーへListコマンドを送信します。
		/// <summary>
		/// Send asynchronous list command to pop3 server.
		/// 非同期でPOP3メールサーバーへListコマンドを送信します。
		/// </summary>
		/// <param name="mailIndex"></param>
		/// <param name="callbackFunction"></param>
		/// <returns></returns>
		public void ExecuteList(Int64 mailIndex, Action<List<ListCommandResult>> callbackFunction)
		{
			ListCommand cm = new ListCommand(mailIndex);

			Action<Pop3CommandResult> md = response =>
			{
                this.CheckResponseError(response);
                List<ListCommandResult> l = new List<ListCommandResult>();
				var rs = new ListCommandResult(response.Text);
				l.Add(rs);
				callbackFunction(l);
			};
			this.CheckAuthenticate();
			this.BeginExecute(cm, md);
		}
		/// 非同期でPOP3メールサーバーへListコマンドを送信します。
		/// <summary>
		/// Send asynchronous list command to pop3 server.
		/// 非同期でPOP3メールサーバーへListコマンドを送信します。
		/// </summary>
		/// <param name="callbackFunction"></param>
		/// <returns></returns>
		public void ExecuteList(Action<List<ListCommandResult>> callbackFunction)
		{
			ListCommand cm = new ListCommand();

			Action<Pop3CommandResult> md = response =>
			{
                this.CheckResponseError(response);
                List<ListCommandResult> l = new List<ListCommandResult>();
				StringReader sr = null;
				String line = "";

				sr = new StringReader(response.Text);
				while (sr.Peek() > -1)
				{
					line = sr.ReadLine();
					if (line == ".")
					{ break; }
					if (line.StartsWith("+OK", StringComparison.OrdinalIgnoreCase) == true)
					{ continue; }

					l.Add(new ListCommandResult(line));
				}
				callbackFunction(l);
			};
			this.CheckAuthenticate();
			this.BeginExecute(cm, md);
		}
		/// 非同期でPOP3メールサーバーへUIDLコマンドを送信します。
		/// <summary>
		/// Send asynchronous uidl command to pop3 server.
		/// 非同期でPOP3メールサーバーへUIDLコマンドを送信します。
		/// </summary>
		/// <param name="mailIndex"></param>
		/// <param name="callbackFunction"></param>
		public void ExecuteUidl(Int64 mailIndex, Action<UidlCommandResult[]> callbackFunction)
		{
			UidlCommand cm = new UidlCommand(mailIndex);

			Action<Pop3CommandResult> md = response =>
			{
                this.CheckResponseError(response);
                UidlCommandResult[] rs = new UidlCommandResult[1];
				rs[0] = new UidlCommandResult(response.Text);
				callbackFunction(rs);
			};
			this.CheckAuthenticate();
			this.BeginExecute(cm, md);
		}
		/// 非同期でPOP3メールサーバーへUIDLコマンドを送信します。
		/// <summary>
		/// Send asynchronous uidl command to pop3 server.
		/// 非同期でPOP3メールサーバーへUIDLコマンドを送信します。
		/// </summary>
		/// <param name="callbackFunction"></param>
		public void ExecuteUidl(Action<List<UidlCommandResult>> callbackFunction)
		{
			UidlCommand cm = new UidlCommand();

			Action<Pop3CommandResult> md = response =>
			{
                this.CheckResponseError(response);
                List<UidlCommandResult> l = new List<UidlCommandResult>();
				StringReader sr = null;
				String line = "";

				sr = new StringReader(response.Text);
				while (sr.Peek() > -1)
				{
					line = sr.ReadLine();
					if (line == ".")
					{ break; }
					if (line.StartsWith("+OK", StringComparison.OrdinalIgnoreCase) == true)
					{ continue; }

					l.Add(new UidlCommandResult(line));
				}
				callbackFunction(l);
			};
			this.CheckAuthenticate();
			this.BeginExecute(cm, md);
		}
		/// 非同期で指定したMailIndexのメールデータを取得します。
		/// <summary>
		/// Get mail data by asynchronous request.
		/// 非同期で指定したMailIndexのメールデータを取得します。
		/// </summary>
		/// <param name="mailIndex"></param>
		/// <param name="callbackFunction"></param>
		public void GetMessage(Int64 mailIndex, Action<MailMessage> callbackFunction)
		{
			RetrCommand cm = null;

			Action<Pop3CommandResult> md = response =>
			{
                this.CheckResponseError(response);
                this.MimeParser.Encoding = this.ResponseEncoding;
                var mg = this.MimeParser.ToMailMessage(response.Text);
                callbackFunction(mg);
			};
			this.CheckAuthenticate();
			cm = new RetrCommand(mailIndex);
			this.BeginExecute(cm, md);
		}
		/// 非同期でPOP3メールサーバーへRETRコマンドを送信します。
		/// <summary>
		/// Send asynchronous retr command to pop3 server.
		/// 非同期でPOP3メールサーバーへRETRコマンドを送信します。
		/// </summary>
		/// <param name="mailIndex"></param>
		/// <param name="callbackFunction"></param>
		public void ExecuteRetr(Int64 mailIndex, Action<MailMessage> callbackFunction)
		{
			RetrCommand cm = null;

			Action<Pop3CommandResult> md = response =>
			{
                this.CheckResponseError(response);
                this.MimeParser.Encoding = this.ResponseEncoding;
                var mg = this.MimeParser.ToMailMessage(response.Text);
                callbackFunction(mg);
			};
			this.CheckAuthenticate();
			cm = new RetrCommand(mailIndex);
			this.BeginExecute(cm, md);
		}
		/// 非同期でPOP3メールサーバーへSTATコマンドを送信します。
		/// <summary>
		/// Send asynchronous stat command to pop3 server.
		/// 非同期でPOP3メールサーバーへSTATコマンドを送信します。
		/// </summary>
		/// <param name="callbackFunction"></param>
		public void ExecuteStat(Action<StatCommandResult> callbackFunction)
		{
			Action<Pop3CommandResult> md = response =>
			{
                this.CheckResponseError(response);
                callbackFunction(new StatCommandResult(response.Text));
			};
			this.CheckAuthenticate();
			this.BeginExecute("Stat", false, md);
		}
		/// 非同期でPOP3メールサーバーへNOOPコマンドを送信します。
		/// <summary>
		/// Send asynchronous noop command to pop3 server.
		/// 非同期でPOP3メールサーバーへNOOPコマンドを送信します。
		/// </summary>
		/// <param name="callbackFunction"></param>
		public void ExecuteNoop(Action<Pop3CommandResult> callbackFunction)
		{
			Action<Pop3CommandResult> md = response =>
			{
                this.CheckResponseError(response);
                callbackFunction(response);
			};
			this.EnsureOpen();
            this.BeginExecute("Noop", false, md);
        }
		/// 非同期でPOP3メールサーバーへRESETコマンドを送信します。
		/// <summary>
		/// Send asynchronous reset command to pop3 server.
		/// 非同期でPOP3メールサーバーへRESETコマンドを送信します。
		/// </summary>
		/// <param name="callbackFunction"></param>
		public void ExecuteRset(Action<Pop3CommandResult> callbackFunction)
		{
			Action<Pop3CommandResult> md = response =>
			{
                this.CheckResponseError(response);
                callbackFunction(response);
			};
			this.CheckAuthenticate();
            this.BeginExecute("Rset", false, md);
		}
		/// 非同期でPOP3メールサーバーへQUITコマンドを送信します。
		/// <summary>
		/// Send asynchronous quit command to pop3 server.
		/// 非同期でPOP3メールサーバーへQUITコマンドを送信します。
		/// </summary>
		/// <param name="callbackFunction"></param>
		public void ExecuteQuit(Action<Pop3CommandResult> callbackFunction)
		{
            Action<Pop3CommandResult> md = response =>
			{
                this.CheckResponseError(response);
                callbackFunction(response);
			};
			this.EnsureOpen();
            this.BeginExecute("Quit", false, md);
		}
		/// メールサーバーとの接続を切断します。
		/// <summary>
		/// disconnect connection to pop3 server.
		/// メールサーバーとの接続を切断します。
		/// </summary>
		public override void Close()
		{
            base.Close();
			this._State = Pop3ConnectionState.Disconnected;
		}
		/// <summary>
		/// 
		/// </summary>
		~Pop3Client()
		{
			this.Dispose(false);
		}
	}
}