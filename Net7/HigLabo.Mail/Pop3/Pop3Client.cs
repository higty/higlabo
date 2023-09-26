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
				case EmailServiceProvider.Yandex: serverName = "pop.yandex.ru"; break;
				default: throw new InvalidOperationException();
            }
            this.ServerName = serverName;
            this.Port = 995;
            this.Ssl = true;
        }
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
        public void Authenticate()
        {
            if (this.TryAuthenticate() == false)
            {
                throw new Pop3AuthenticateException();
            }
        }
        public void AuthenticateByPop()
        {
            if (this.TryAuthenticateByPop() == false)
            {
                throw new Pop3AuthenticateException();
            }
        }
        public void AuthenticateByAPop()
        {
            if (this.TryAuthenticateByAPop() == false)
            {
                throw new Pop3AuthenticateException();
            }
        }
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
        public Boolean TryAuthenticateByPop()
		{
			if (this.EnsureOpen() == Pop3ConnectionState.Connected)
			{
				//ユーザー名送信
				var rs = this.Execute("user " + this.UserName, false);
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
        public Boolean TryAuthenticateByAPop()
		{
			String TimeStamp = "";
			Int32 StartIndex = 0;
			Int32 EndIndex = 0;

			if (this.EnsureOpen() == Pop3ConnectionState.Connected)
			{
				//ユーザー名送信
				var rs = this.Execute("user " + this.UserName, false);
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
        private Pop3CommandResult Execute(String command, Boolean isMultiLine)
		{
			this.Send(command);
			this.Commnicating = true;
			return this.GetResponse(isMultiLine);
		}
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
		private void Execute(Stream stream, String command, Boolean isMultiLine)
		{
			this.Send(command);
			this.Commnicating = true;
			this.GetResponse(stream, isMultiLine);
		}
        public void BeginExecute(String command, Boolean isMultiLine, Action<Pop3CommandResult> callbackFunction)
        {
            this.BeginSend(command, new Pop3DataReceiveContext(this.ResponseEncoding, isMultiLine, s => callbackFunction(new Pop3CommandResult(s)))
                , s => callbackFunction(new Pop3CommandResult(s)));
        }
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
		public ListCommandResult ExecuteList(Int64 mailIndex)
		{
			ListCommand cm = new ListCommand(mailIndex);

			this.CheckAuthenticate();
			var rs = this.Execute(cm);
            this.CheckResponseError(rs);
			return new ListCommandResult(rs.Text);
		}
		public List<ListCommandResult> ExecuteList()
		{
			ListCommand cm = new ListCommand();
			List<ListCommandResult> l = new List<ListCommandResult>();

			this.CheckAuthenticate();
			var rs = this.Execute(cm);
            this.CheckResponseError(rs);
            
            var sr = new StringReader(rs.Text);
			while (sr.Peek() > -1)
			{
				var line = sr.ReadLine()!;
				if (line == ".")
				{ break; }
				if (line.StartsWith("+OK", StringComparison.OrdinalIgnoreCase) == true)
				{ continue; }

				l.Add(new ListCommandResult(line));
			}
			return l;
		}
		public UidlCommandResult ExecuteUidl(Int64 mailIndex)
		{
			UidlCommand cm = new UidlCommand(mailIndex);

			this.CheckAuthenticate();
			var rs = this.Execute(cm);
            this.CheckResponseError(rs);

            return new UidlCommandResult(rs.Text);
		}
		public List<UidlCommandResult> ExecuteUidl()
		{
			UidlCommand cm = new UidlCommand();
			List<UidlCommandResult> l = new List<UidlCommandResult>();

			this.CheckAuthenticate();
			var rs = this.Execute(cm);
            this.CheckResponseError(rs);
            
            var sr = new StringReader(rs.Text);
			while (sr.Peek() > -1)
			{
				var line = sr.ReadLine()!;
				if (line == ".")
				{ break; }
				if (line.StartsWith("+OK", StringComparison.OrdinalIgnoreCase) == true)
				{ continue; }

				l.Add(new UidlCommandResult(line));
			}
			return l;
		}
		public MailMessage ExecuteRetr(Int64 mailIndex)
		{
			return this.GetMessage(mailIndex);
		}
		public Pop3CommandResult ExecuteTop(Int64 mailIndex, Int32 lineCount)
		{
            this.CheckAuthenticate();
            var rs = this.Execute(new TopCommand(mailIndex, lineCount));
            this.CheckResponseError(rs);
            return rs;
        }
		public Pop3CommandResult ExecuteDele(Int64 mailIndex)
		{
			DeleCommand cm = new DeleCommand(mailIndex);

			this.CheckAuthenticate();
			var rs = this.Execute(cm);
            this.CheckResponseError(rs);
			return rs;
		}
		public StatCommandResult ExecuteStat()
		{
			this.CheckAuthenticate();
            var rs = this.Execute("Stat", false);
            this.CheckResponseError(rs);
            return new StatCommandResult(rs.Text);
		}
		public Pop3CommandResult ExecuteNoop()
		{
			this.EnsureOpen();
			var rs = this.Execute("Noop", false);
			return new Pop3CommandResult(rs.Text);
		}
		public Pop3CommandResult ExecuteRset()
		{
			this.CheckAuthenticate();
            var rs = this.Execute("Rset", false);
            this.CheckResponseError(rs);
			return rs;
		}
		public Pop3CommandResult ExecuteQuit()
		{	
			this.EnsureOpen();
            var rs = this.Execute("Quit", false);
            this.CheckResponseError(rs);
            //Server disconnect connection after server received quit command, so call Close method.
            this.Close();
            return rs;
		}
		public Int64 GetTotalMessageCount()
		{
			var rs = this.ExecuteStat();
			return rs.TotalMessageCount;
		}
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
		public String GetMessageText(Int64 mailIndex)
		{
			this.CheckAuthenticate();
			try
			{
				var cm = new RetrCommand(mailIndex);
				var rs = this.Execute(cm);
                return rs.Text;
			}
			catch (Exception ex)
			{
                throw new MailClientException(ex);
			}
		}
		public String GetMessageText(Int64 mailIndex, Int32 lineCount)
		{
			this.CheckAuthenticate();
			try
			{
				var cm = new TopCommand(mailIndex, lineCount);
				var rs = this.Execute(cm);
                return rs.Text;
			}
			catch (Exception ex)
			{
                throw new MailClientException(ex);
			}
		}
		public void GetMessageText(Stream stream, Int64 mailIndex)
		{
			this.CheckAuthenticate();
			try
			{
				var cm = new RetrCommand(mailIndex);
				this.Execute(stream, cm);
			}
			catch (Exception ex)
			{
                throw new MailClientException(ex);
			}
		}
		public void GetMessageText(Stream stream, Int64 mailIndex, Int32 lineCount)
		{
			this.CheckAuthenticate();
			try
			{
				var cm = new TopCommand(mailIndex, lineCount);
				this.Execute(stream, cm);
			}
			catch (Exception ex)
			{
                throw new MailClientException(ex);
			}
		}
        public void GetMessageText(Int64 mailIndex, Action<Pop3CommandResult> callbackFunction)
		{
			var md = callbackFunction;

			this.CheckAuthenticate();
			var cm = new RetrCommand(mailIndex);
			this.BeginExecute(cm, md);
		}
        public Boolean DeleteMail(params Int32[] indexList)
        {
            var newIndexList = new Int64[indexList.Length];
            for (int i = 0; i < indexList.Length; i++)
            {
                newIndexList[i] = indexList[i];
            }
            return DeleteMail(newIndexList);
        }
		public Boolean DeleteMail(params Int64[] indexList)
		{
            if (this.EnsureOpen() == Pop3ConnectionState.Disconnected) { return false; }
            if (this.TryAuthenticate() == false) { return false; }
            for (int i = 0; i < indexList.Length; i++)
            {
                var cm = new DeleCommand(indexList[i]);
                var rs = this.Execute(cm);
                if (rs.Ok == false) { return false; }
            }
            this.ExecuteQuit();
            return true;
		}
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
		public void ExecuteList(Action<List<ListCommandResult>> callbackFunction)
		{
			ListCommand cm = new ListCommand();

			Action<Pop3CommandResult> md = response =>
			{
                this.CheckResponseError(response);
                List<ListCommandResult> l = new List<ListCommandResult>();

				var sr = new StringReader(response.Text);
				while (sr.Peek() > -1)
				{
					var line = sr.ReadLine()!;
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
		public void ExecuteUidl(Action<List<UidlCommandResult>> callbackFunction)
		{
			UidlCommand cm = new UidlCommand();

			Action<Pop3CommandResult> md = response =>
			{
                this.CheckResponseError(response);
                List<UidlCommandResult> l = new List<UidlCommandResult>();

				var sr = new StringReader(response.Text);
				while (sr.Peek() > -1)
				{
					var line = sr.ReadLine()!;
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
		public void GetMessage(Int64 mailIndex, Action<MailMessage> callbackFunction)
		{
			Action<Pop3CommandResult> md = response =>
			{
                this.CheckResponseError(response);
                this.MimeParser.Encoding = this.ResponseEncoding;
                var mg = this.MimeParser.ToMailMessage(response.Text);
                callbackFunction(mg);
			};
			this.CheckAuthenticate();
			var cm = new RetrCommand(mailIndex);
			this.BeginExecute(cm, md);
		}
		public void ExecuteRetr(Int64 mailIndex, Action<MailMessage> callbackFunction)
		{
			Action<Pop3CommandResult> md = response =>
			{
                this.CheckResponseError(response);
                this.MimeParser.Encoding = this.ResponseEncoding;
                var mg = this.MimeParser.ToMailMessage(response.Text);
                callbackFunction(mg);
			};
			this.CheckAuthenticate();
			var cm = new RetrCommand(mailIndex);
			this.BeginExecute(cm, md);
		}
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
		public override void Close()
		{
            base.Close();
			this._State = Pop3ConnectionState.Disconnected;
		}
		~Pop3Client()
		{
			this.Dispose(false);
		}
	}
}