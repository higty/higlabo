using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Sockets;
using System.IO;
using HigLabo.Net.Internal;

namespace HigLabo.Net.Ftp
{
	public partial class FtpClient : SocketClient
	{
		private class RegexList
		{
            public static readonly Regex IpAddress = new Regex("[0-9]{1-3}.[0-9]{1-3}.[0-9]{1-3}.[0-9]{1-3}", RegexOptions.IgnoreCase);
            public static readonly Regex FileSize = new Regex("((?<Size>[0-9]*) bytes)", RegexOptions.IgnoreCase);
		}
        public new static readonly FtpClientDefaultSettings Default = new FtpClientDefaultSettings();
		private SocketClient _DataSocket = null;
		private Socket _ListenSocket = null;
		public FtpConnectionState State { get; private set; }
		public FtpConnectionMode ConnectionMode { get; set; }
		public FtpDataType DataType { get; set; }
		public Boolean Resume { get; set; }
		private Func<String, FtpDirectory> CreateFtpDirectory { get; set; }
		public FtpClient(String serverName)
			: this(serverName, Default.Port, Default.UserName, Default.Password)
		{
		}
		public FtpClient(String serverName, Int32 port, String userName, String password)
			: base(serverName, port)
		{
            this.SetDefault(Default);
            this.CreateFtpDirectory = Default.CreateFtpDirectory;
            
            this.ServerName = serverName;
            this.Port = port;
			this.UserName = userName;
			this.Password = password;
			this.ConnectionMode = FtpConnectionMode.Passive;
		}
		/// サーバーへの接続を開きます。
		/// <summary>
		/// Open connection to a server.
		/// サーバーへの接続を開きます。
		/// </summary>
		public FtpConnectionState Open()
		{
			if (this.Connect() == true)
			{
				var s = this.GetResponseText();
				if (s.StartsWith("220") == true)
				{
					this.State = FtpConnectionState.Connected;
				}
				else
				{
					this.Socket = null;
					this.Stream = null;
					this.State = FtpConnectionState.Disconnected;
				}
			}
			else
			{
				this.State = FtpConnectionState.Disconnected;
			}
			return this.State;
		}
		/// サーバーへの接続が開かれていない場合、サーバーへの接続を開きます。
		/// <summary>
		/// Ensure connection is opened.
		/// サーバーへの接続が開かれていない場合、サーバーへの接続を開きます。
		/// </summary>
		public FtpConnectionState EnsureOpen()
		{
			if (this.Socket != null)
			{ return this.State; }

			return this.Open();
		}
		private FtpCommandResult GetResponse()
		{
			List<FtpCommandResultLine> l = new List<FtpCommandResultLine>();
			String lineText = "";
			FtpCommandResultLine CurrentLine = null;
			Byte[] bb = this.GetResponseBytes(new FtpDataReceiveContext(this.ResponseEncoding));
			StringReader sr = new StringReader(this.ResponseEncoding.GetString(bb));
			Boolean isFirstLine = true;
			while (true)
			{
				lineText = sr.ReadLine();
				if (isFirstLine == true)
				{
					CurrentLine = new FtpCommandResultLine(lineText);
				}
				else
				{
					CurrentLine = new FtpCommandResultLine(CurrentLine.StatusCode, lineText);
				}
				isFirstLine = false;
				l.Add(CurrentLine);
				//次の行があるかチェック
				if (CurrentLine.LastLine == true)
				{ break; }
			}
			this.Commnicating = false;
			return new FtpCommandResult(l.ToArray());
		}
		/// 同期でFTPメールサーバーへコマンドを送信し、コマンドの種類によってはレスポンスデータを受信して文字列として返します。
		/// <summary>
		/// Send a command with synchronous and get response data as string text if the command is a type to get response.
		/// 同期でFTPメールサーバーへコマンドを送信し、コマンドの種類によってはレスポンスデータを受信して文字列として返します。
		/// </summary>
		/// <param name="stream"></param>
		/// <param name="command"></param>
		/// <param name="isMultiLine"></param>
		/// <returns></returns>
		private FtpCommandResult Execute(String command)
		{
			this.Send(command);
			this.Commnicating = true;
			return this.GetResponse();
		}
		/// <summary>
		/// 認証を行います。
		/// </summary>
		/// <returns></returns>
		public Boolean Authenticate()
		{
			FtpCommandResult rs = null;

			if (this.EnsureOpen() == FtpConnectionState.Connected)
			{
				rs = this.Execute("user " + this.UserName);
				if (rs.StatusCode == FtpCommandResultCode.UserNameOkey)
				{
					rs = this.Execute("pass " + this.Password);
					if (rs.StatusCode == FtpCommandResultCode.UserLoggedIn)
					{
						this.State = FtpConnectionState.Authenticated;
						return true;
					}
				}
			}
			return false;
		}
		private void OpenDataSocket()
		{
			if (_DataSocket != null) { return; }

			switch (this.ConnectionMode)
			{
				case FtpConnectionMode.Active: this.OpenActiveConnection(); break;
				case FtpConnectionMode.Passive: this.OpenPassiveConnection(); break;
				default: throw new FtpClientException();
			}
		}
		private void OpenPassiveConnection()
		{
			FtpCommandResult rs = null;
			String[] pasv;

			rs = this.ExecutePasv();
			if (rs.StatusCode != FtpCommandResultCode.EnteringPassiveMode)
			{
				throw new FtpClientException(rs);
			}

			Int32 i1 = rs.Text.IndexOf('(') + 1;
			Int32 i2 = rs.Text.IndexOf(')') - i1;
			pasv = rs.Text.Substring(i1, i2).Split(',');
			if (pasv.Length < 6)
			{
				throw new FtpClientException(rs);
			}
			String server = String.Format("{0}.{1}.{2}.{3}", pasv[0], pasv[1], pasv[2], pasv[3]);
			Int32 port = (Int32.Parse(pasv[4]) << 8) + Int32.Parse(pasv[5]);

			this._DataSocket = new SocketClient(server, port);
			this._DataSocket.Connect();
		}
		private void OpenActiveConnection()
		{
			FtpCommandResult rs = null;
			
			this._ListenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

			String ad = this.Socket.LocalEndPoint.ToString();
			Int32 ix = ad.IndexOf(':');
			if (ix < 0)
			{
				throw new FtpClientException("Failed to parse the local address: " + ad);
			}
			String sIPAddr = ad.Substring(0, ix);
			var localEP = new IPEndPoint(IPAddress.Parse(sIPAddr), 0);

			this._ListenSocket.Bind(localEP);
			ad = this._ListenSocket.LocalEndPoint.ToString();
			ix = ad.IndexOf(':');
			if (ix < 0)
			{
				throw new FtpClientException("Failed to parse the local address: " + ad);
			}
			Int32 nPort = Int32.Parse(ad.Substring(ix + 1));

			this._ListenSocket.Listen(1);
			String port = String.Format("{0},{1},{2}", sIPAddr.Replace('.', ','), nPort / 256, nPort % 256);
			rs = this.ExecutePort(port);
			if (rs.StatusCode != FtpCommandResultCode.CommandOkey)
			{
				throw new FtpClientException(rs);
			}
		}
		private void ConnectDataSocket()
		{
			if (this._DataSocket != null) return;

			try
			{
				this._DataSocket = new SocketClient(this._ListenSocket.Accept());
				this._DataSocket.Connect();
				this._DataSocket.SetProperty(this);
				
				this._ListenSocket.Close();
				this._ListenSocket = null;
			}
			catch (Exception ex)
			{
				throw new Exception("Failed to connect for data transfer: " + ex.Message);
			}
		}
		private void CloseDataSocket()
		{
			if (this._DataSocket != null)
			{
				this._DataSocket.Dispose();
				this._DataSocket = null;
			}
		}
		public Int64 UploadFile(String localFilePath, String remoteFileName)
		{
			FtpCommandResult rs = null;
			Int64 fileSize = 0;
			FileStream stm = null;

			if (this.EnsureOpen() == FtpConnectionState.Disconnected) { throw new FtpClientException("Connection must be opened"); }
			if (this.State == FtpConnectionState.Connected)
			{
				if (this.Authenticate() == false) { throw new FtpClientException("Authenticate failed"); }
			}
			this.OpenDataSocket();

			rs = this.ExecuteType(this.DataType);
			this.OpenDataSocket();

            using (stm = new FileStream(localFilePath, FileMode.Open))
            {
                fileSize = stm.Length;

                if (this.Resume == true)
                {
                    Int64 size = this.GetFileSize(remoteFileName);
                    rs = this.ExecuteRest(size);

                    if (rs.StatusCode == FtpCommandResultCode.RequestedFileActionPendingFurtherInformation)
                    {
                        stm.Seek(size, SeekOrigin.Begin);
                    }
                }
                rs = this.ExecuteStor(remoteFileName);

                switch (rs.StatusCode)
                {
                    case FtpCommandResultCode.DataConnectionAlreadyOpenTransferStarting:
                    case FtpCommandResultCode.FileStatusOkayAboutToOpenDataConnection:
                        break;
                    default:
                        {
                            stm.Close();
                            throw new FtpClientException(rs);
                        }
                }
                ConnectDataSocket();
                this._DataSocket.Send(stm);

                this.Disconnect();
            }            
            return fileSize;
		}
        public void DownloadFile(String fileName)
        {
            this.DownloadFile(fileName, fileName);
        }
        public Int64 DownloadFile(String remoteFileName, String localFilePath)
		{
			FtpCommandResult rs = null;
			FileStream stm = null;
			Int64 size = 0;

			if (this.EnsureOpen() == FtpConnectionState.Disconnected) { throw new FtpClientException("Connection must be opened"); }
			if (this.State == FtpConnectionState.Connected)
			{
				if (this.Authenticate() == false) { throw new FtpClientException("Authenticate failed"); }
			}
			this.OpenDataSocket();

			rs = this.ExecuteType(this.DataType);

			OpenDataSocket();
			rs = this.ExecuteRetr(remoteFileName);
			switch (rs.StatusCode)
			{
				case FtpCommandResultCode.DataConnectionAlreadyOpenTransferStarting: break;
				case FtpCommandResultCode.FileStatusOkayAboutToOpenDataConnection: break;
				default: throw new FtpClientException(rs);
			}
            var fileSize = this.GetFileSize(rs);

			ConnectDataSocket();
			try
			{
				if (this.Resume == true && File.Exists(localFilePath) == true)
				{
					stm = new FileStream(localFilePath, FileMode.Open);

					rs = this.ExecuteRest(stm.Length);
					if (rs.StatusCode != FtpCommandResultCode.RequestedFileActionPendingFurtherInformation)
					{
						throw new FtpClientException(rs);
					}
					stm.Seek(stm.Length, SeekOrigin.Begin);
				}
				else
				{
					stm = new FileStream(localFilePath, FileMode.Create);
				}
                if (fileSize.HasValue)
                {
                    this.GetResponseStream(new FtpDataDownloadContext(stm, this.ResponseEncoding, fileSize.Value));
                }
                else
                {
                    this._DataSocket.GetResponseStream(stm);
                }
				size = stm.Length;
				stm.Flush();
			}
			finally
			{
				if (stm != null)
				{
					stm.Dispose();
				}
			}
			this.Disconnect();

			return size;
		}
        private Int32? GetFileSize(FtpCommandResult result)
        {
            var rx = RegexList.FileSize;
            var m = rx.Match(result.Text);
            if (m.Success == false) { return null; }
            Int32 size = 0;
            if (Int32.TryParse(m.Groups["Size"].Value, out size) == true)
            {
                return size;
            }
            return null;
        }
		public Int64 GetFileSize(String fileName)
		{
			this.EnsureOpen();
			var rs = this.ExecuteSize(fileName);
			if (rs.StatusCode != FtpCommandResultCode.FileStatus) { throw new FtpClientException(rs); }

			return Int64.Parse(rs.Text.Substring(4));
		}

        /// <summary>
        /// Change remote directory.
        /// </summary>
        /// <param name="directoryName"></param>
        /// <returns></returns>
        public FtpCommandResult ChangeDirectory(String directoryName)
        {
            return this.ExecuteCwd(directoryName);
        }
        /// FTPサーバーへCWDコマンドを送信します。
        /// <summary>
        /// Send cwd command to ftp server.
        /// FTPサーバーへCWDコマンドを送信します。
        /// </summary>
        /// <param name="pathName">指定したディレクトリ名</param>
        /// <returns></returns>
        public FtpCommandResult ExecuteCwd(String directoryName)
		{
            this.EnsureOpen();
            var rs = this.Execute("Cwd " + directoryName);
			return rs;
		}
        /// FTPサーバーへCDUPコマンドを送信します。
        /// <summary>
        /// Send cdup command to ftp server.
        /// FTPサーバーへCDUPコマンドを送信します。
        /// </summary>
        /// <returns></returns>
        public FtpCommandResult ExecuteCdup()
		{
            this.EnsureOpen();
			var rs = this.Execute("Cdup");
			return rs;
		}
        /// FTPサーバーへSMNTコマンドを送信します。
        /// <summary>
        /// Send smnt command to ftp server.
        /// FTPサーバーへSMNTコマンドを送信します。
        /// <param name="pathName">課金情報</param>
        /// <returns></returns>
		public FtpCommandResult ExecuteSmnt(String pathName)
		{
			this.EnsureOpen();
			var rs = this.Execute("Smnt " + pathName);
			return rs;
		}
        /// FTPサーバーへREINコマンドを送信します。
        /// <summary>
        /// Send rein command to ftp server.
        /// FTPサーバーへREINコマンドを送信します。
        /// </summary>
        /// <returns></returns>
		public FtpCommandResult ExecuteRein()
		{
			this.EnsureOpen();
			var rs = this.Execute("Rein");
			return rs;
		}
        /// FTPサーバーへQUITコマンドを送信します。
        /// <summary>
        /// Send quit command to ftp server.
        /// FTPサーバーへQUITコマンドを送信します。
        /// </summary>
        /// <returns></returns>
		public FtpCommandResult ExecuteQuit()
		{
			this.EnsureOpen();
			var rs = this.Execute("Quit");
			return rs;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="port"></param>
		/// <returns></returns>
		public FtpCommandResult ExecutePort(String port)
		{
			this.EnsureOpen();
			var rs = this.Execute("Port " + port);
			return rs;
		}
        /// FTPサーバーへPASVコマンドを送信します。
        /// <summary>
        /// Send pasv command to ftp server.
        /// FTPサーバーへPASVコマンドを送信します。
        /// </summary>
        /// <returns></returns>
		public FtpIPCommandResult ExecutePasv()
		{
			this.EnsureOpen();
			var rs = this.Execute("Pasv");
			return new FtpIPCommandResult(rs);
		}
        /// FTPサーバーへTYPEコマンドを送信します。
        /// <summary>
        /// Send type command to ftp server.
        /// FTPサーバーへTYPEコマンドを送信します。
        /// <param name="mode">形式オプション</param>
		/// <returns></returns>
		public FtpCommandResult ExecuteType(FtpDataType type)
		{
            switch (type)
			{
                case FtpDataType.Image: return this.Execute("Type I");
                case FtpDataType.Ebcdic: throw new NotImplementedException();
                case FtpDataType.Ascii: return this.Execute("Type A"); 
				default: throw new FtpClientException();
			}
		}
        /// FTPサーバーへSTRUコマンドを送信します。
        /// <summary>
        /// Send stru command to ftp server.
        /// FTPサーバーへSTRUコマンドを送信します。
        /// <param name="dataStruct">ファイル構造オプション</param>
        /// <returns></returns>
		public FtpCommandResult ExecuteStru(FtpDataStructures dataStruct)
		{
            switch (dataStruct)
            {
                case FtpDataStructures.FileStructure: return this.Execute("Stru F");
                case FtpDataStructures.RecordStructure: return this.Execute("Stru R");
                case FtpDataStructures.PageStructure: return this.Execute("Stru P");
                default: throw new FtpClientException();
            }
		}
        /// FTPサーバーへUSERコマンドを送信します。
        /// <summary>
        /// Send user command to ftp server.
        /// FTPサーバーへUSERコマンドを送信します。
        /// <param name="user">ユーザ</param>
        /// <returns></returns>
        public FtpCommandResult ExecuteUser(String user)
        {
            this.EnsureOpen();
            var rs = this.Execute("User " + user);
            return rs;
        }
        /// FTPサーバーへPASSコマンドを送信します。
        /// <summary>
        /// Send pass command to ftp server.
        /// FTPサーバーへPASSコマンドを送信します。
        /// <param name="password">パスワード</param>
        /// <returns></returns>
        public FtpCommandResult ExecutePass(String password)
        {
            this.EnsureOpen();
            var rs = this.Execute("Pass " + password);
            return rs;
        }
        /// FTPサーバーへMODEコマンドを送信します。
        /// <summary>
        /// Send mode command to ftp server.
        /// FTPサーバーへMODEコマンドを送信します。
        /// </summary>
        /// <param name="mode">転送モード</param>
        /// <returns></returns>
        public FtpCommandResult ExecuteMode(FtpTransferMode mode)
		{
            switch (mode)
            {
                case FtpTransferMode.Stream: return this.Execute("Mode S");
                case FtpTransferMode.Block: return this.Execute("Mode B");
                case FtpTransferMode.Compression: return this.Execute("Mode C");
                default: throw new FtpClientException();
            }
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="fileName"></param>
		/// <returns></returns>
		public FtpCommandResult ExecuteRetr(String fileName)
		{
			this.EnsureOpen();
			var rs = this.Execute("Retr " + fileName);
			return rs;
		}
        /// FTPサーバーへSIZEコマンドを送信します。
        /// <summary>
        /// Send size command to ftp server.
        /// FTPサーバーへSIZEコマンドを送信します。
		/// </summary>
		/// <param name="fileName">ファイル名</param>
		/// <returns></returns>
		public FtpCommandResult ExecuteSize(String fileName)
		{
			this.EnsureOpen();
			var rs = this.Execute("Size " + fileName);
			return rs;
		}
        /// FTPサーバーへSTORコマンドを送信します。
        /// <summary>
        /// Send stor command to ftp server.
        /// FTPサーバーへSTORコマンドを送信します。
        /// <param name="fileName">ファイル名(パスも含め)</param>
        /// <returns></returns>
		public FtpCommandResult ExecuteStor(String fileName)
		{
			var rs = this.Execute("Stor " + fileName);
			return rs;
		}
        /// FTPサーバーへSTOUコマンドを送信します。
        /// <summary>
        /// Send stou command to ftp server.
        /// FTPサーバーへSTOUコマンドを送信します。
        /// <param name="fileName">ファイル名(パスも含め)</param>
        /// <returns></returns>
        public FtpFileCommandResult ExecuteStou()
		{
			this.EnsureOpen();
            var rs = this.Execute("Stou");
			return new FtpFileCommandResult(rs);
		}
        /// FTPサーバーへAPPEコマンドを送信します。
        /// <summary>
        /// Send appe command to ftp server.
        /// FTPサーバーへAPPEコマンドを送信します。
        /// <param name="fileName">ファイル名(パスも含め)</param>
        /// <returns></returns>
		public FtpCommandResult ExecuteAppe(String fileName)
		{
			this.EnsureOpen();
            var rs = this.Execute("Appe " + fileName);
			return rs;
		}
        /// FTPサーバーへALLOコマンドを送信します。
        /// <summary>
        /// Send allo command to ftp server.
        /// FTPサーバーへALLOコマンドを送信します。
        /// <param name="bytes">ファイルバイト数</param>
        /// <returns></returns>
		public FtpCommandResult ExecuteAllo(Int64 bytes)
		{
			this.EnsureOpen();
			var rs = this.Execute("Allo " + bytes);
			return rs;
		}
        /// FTPサーバーへRESTコマンドを送信します。
        /// <summary>
        /// Send rest command to ftp server.
        /// FTPサーバーへRESTコマンドを送信します。
        /// <param name="length">maker</param>
        /// <returns></returns>
		public FtpCommandResult ExecuteRest(Int64 length)
		{
			this.EnsureOpen();
			var rs = this.Execute("Rest " + length);
			return rs;
		}
        /// FTPサーバーへRNFRコマンドを送信します。
        /// <summary>
        /// Send rnfr command to ftp server.
        /// FTPサーバーへRNFRコマンドを送信します。
        /// <param name="fileName">ファイル名</param>
        /// <returns></returns>
		public FtpCommandResult ExecuteRnfr(String fileName)
		{
			this.EnsureOpen();
			var rs = this.Execute("Rnfr " + fileName);
			return rs;
		}
        /// FTPサーバーへRNTOコマンドを送信します。
        /// <summary>
        /// Send rnto command to ftp server.
        /// FTPサーバーへRNTOコマンドを送信します。
        /// <param name="fileName">ファイル名</param>
        /// <returns></returns>
        public FtpCommandResult ExecuteRnto(String fileName)
		{
			this.EnsureOpen();
            var rs = this.Execute("Rnto " + fileName);
			return rs;
		}
        /// FTPサーバーへABORコマンドを送信します。
        /// <summary>
        /// Send abor command to ftp server.
        /// FTPサーバーへABORコマンドを送信します。
        /// </summary>
        /// <returns></returns>
		public FtpCommandResult ExecuteAbor()
		{
			var rs = this.Execute("Abor");
			return rs;
		}
        /// FTPサーバーへACCTコマンドを送信します。
        /// <summary>
        /// Send acct command to ftp server.
        /// FTPサーバーへACCTコマンドを送信します。
        /// </summary>
        /// <param name="accountInfo"></param>
        /// <returns></returns>
        public FtpCommandResult ExecuteAcct(String accountInfo)
        {
            this.EnsureOpen();
            var rs = this.Execute("Acct " + accountInfo);
            return rs;
        }
        /// FTPサーバーへDELEコマンドを送信します。
        /// <summary>
        /// Send dele command to ftp server.
        /// FTPサーバーへDELEコマンドを送信します。
        /// </summary>
        /// <param name="fileName">指定したファイル</param>
        /// <returns></returns>
        public FtpCommandResult ExecuteDele(String fileName)
		{
            this.EnsureOpen();
            var rs = this.Execute("Dele " + fileName);
			return rs;
		}
        /// FTPサーバーへRMDコマンドを送信します。
        /// <summary>
        /// Send rmd command to ftp server.
        /// FTPサーバーへRMDコマンドを送信します。
        /// </summary>
        /// <param name="directoryName">指定したディレクトリ名</param>
        /// <returns></returns>
		public FtpCommandResult ExecuteRmd(String directoryName)
		{
			this.EnsureOpen();
            var rs = this.Execute("Rmd " + directoryName);
			return rs;
		}
        /// FTPサーバーへMKDコマンドを送信します。
        /// <summary>
        /// Send mkd command to ftp server.
        /// FTPサーバーへMKDコマンドを送信します。
        /// </summary>
        /// <param name="directoryName">指定したディレクトリ名</param>
        /// <returns></returns>
        public FtpCommandResult ExecuteMkd(String directoryName)
		{
			this.EnsureOpen();
            var rs = this.Execute("Mkd " + directoryName);
			return rs;
		}
        /// FTPサーバーへPWDコマンドを送信します。
        /// <summary>
        /// Send pwd command to ftp server.
        /// FTPサーバーへPWDコマンドを送信します。
        /// </summary>
        /// <returns></returns>
		public FtpDirectoryCommandResult ExecutePwd()
		{
			this.EnsureOpen();
			var rs = this.Execute("Pwd");
			return new FtpDirectoryCommandResult(rs);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public List<FtpDirectory> ExecuteNlst(FtpEntryType type)
		{
			FtpCommandResult rs = null;

			this.EnsureOpen();
			this.OpenDataSocket();

			Byte[] bytes = new Byte[512];
			List<FtpDirectory> l = new List<FtpDirectory>();

			rs = this.Execute("Nlst");

			switch (rs.StatusCode)
			{
				case FtpCommandResultCode.DataConnectionAlreadyOpenTransferStarting: break;
				case FtpCommandResultCode.FileStatusOkayAboutToOpenDataConnection: break;
				default:
					{
						CloseDataSocket();
						throw new FtpClientException(rs);
					}
			}
			this.ConnectDataSocket();
			String text = this._DataSocket.GetResponseText();
            text = this.GetResponseText();
			this.CloseDataSocket();

			rs = this.GetResponse();

			if (rs.StatusCode != FtpCommandResultCode.ClosingDataConnection)
			{
				throw new FtpClientException(rs);
			}
			StringReader sr = new StringReader(text);
			while (sr.Peek() > -1)
			{
				l.Add(new FtpDirectory(sr.ReadLine()));
			}
			return l;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public List<FtpDirectory> ExecuteList(FtpEntryType type)
		{
			FtpCommandResult rs = null;

			this.EnsureOpen();
			this.OpenDataSocket();

			Byte[] bytes = new Byte[512];
			List<FtpDirectory> l = new List<FtpDirectory>();

			rs = this.Execute("List");

			switch (rs.StatusCode)
			{
				case FtpCommandResultCode.DataConnectionAlreadyOpenTransferStarting: break;
				case FtpCommandResultCode.FileStatusOkayAboutToOpenDataConnection: break;
				default:
					{
						CloseDataSocket();
						throw new FtpClientException(rs);
					}
			}
			this.ConnectDataSocket();
			String text = this._DataSocket.GetResponseText();
			this.CloseDataSocket();

			rs = this.GetResponse();

			if (rs.StatusCode != FtpCommandResultCode.ClosingDataConnection)
			{
				throw new FtpClientException(rs);
			}
			StringReader sr = new StringReader(text);
			while (sr.Peek() > -1)
			{
				l.Add(this.CreateFtpDirectory(sr.ReadLine()));
			}
			return l;
		}
        /// FTPサーバーへSITEコマンドを送信します。
        /// <summary>
        /// Send site command to ftp server.
        /// FTPサーバーへSITEコマンドを送信します。
        /// <param name="cmdStr"></param>
        /// <returns></returns>
		public FtpCommandResult ExecuteSite(String cmdStr)
		{
			this.EnsureOpen();
            var rs = this.Execute("Site " + cmdStr);
			return rs;
		}
		public FtpCommandResult ExecuteSyst()
		{
			this.EnsureOpen();
			var rs = this.Execute("Syst");
			return rs;
		}
        /// FTPサーバーへSTATコマンドを送信します。
        /// <summary>
        /// Send stat command to ftp server.
        /// FTPサーバーへSTATコマンドを送信します。
        /// <param name="pathName">ファイル／ディレクトリ名</param>
        /// <returns></returns>
		public FtpCommandResult ExecuteStat(String pathName)
		{
			this.EnsureOpen();
            var rs = this.Execute("Stat " + pathName);
			return rs;
		}
		/// FTPサーバーへHELPコマンドを送信します。
		/// <summary>
		/// Send help command to ftp server.
		/// FTPサーバーへHELPコマンドを送信します。
		/// </summary>
		/// <returns></returns>
		public FtpCommandResult ExecuteHelp()
		{
			this.EnsureOpen();
			var rs = this.Execute("Help");
			return rs;
		}
		/// FTPサーバーへNOOPコマンドを送信します。
		/// <summary>
		/// Send noop command to ftp server.
		/// FTPサーバーへNOOPコマンドを送信します。
		/// </summary>
		/// <returns></returns>
		public FtpCommandResult ExecuteNoop()
		{
			this.EnsureOpen();
			var rs = this.Execute("Noop");
			return rs;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="func"></param>
		public void SetCreateFtpDirectoryDelegate(Func<String, FtpDirectory> func)
		{
			this.CreateFtpDirectory = func;
		}
		/// <summary>
		/// FTPサーバから切断します。
		/// </summary>
		public void Disconnect()
		{
			CloseDataSocket();
			if (this.State == FtpConnectionState.Connected)
			{
				this.ExecuteQuit();
			}
			this.DisposeSocket();
		}
	}
}
