using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Sockets;
using System.IO;
using HigLabo.Net.Internal;
using System.Threading.Tasks;

namespace HigLabo.Net.Ftp
{
	public partial class FtpClient
	{
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        protected static Task<T> CreateNewTask<T>(Func<T> func)
        {
            return Task.Factory.StartNew<T>(func);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        protected Task CreateNewTask(Action func)
        {
            return Task.Factory.StartNew(func);
        }
		/// サーバーへの接続を開きます。
		/// <summary>
		/// Open connection to a server.
		/// サーバーへの接続を開きます。
		/// </summary>
        /// <returns></returns>
		public Task<FtpConnectionState> OpenAsync()
		{
            return CreateNewTask<FtpConnectionState>(() => this.Open());
		}
		/// サーバーへの接続が開かれていない場合、サーバーへの接続を開きます。
		/// <summary>
		/// Ensure connection is opened.
		/// サーバーへの接続が開かれていない場合、サーバーへの接続を開きます。
		/// </summary>
        /// <returns></returns>
        public Task<FtpConnectionState> EnsureOpenAsync()
		{
            return CreateNewTask<FtpConnectionState>(() => this.EnsureOpen());
		}
		/// <summary>
		/// 認証を行います。
		/// </summary>
		/// <returns></returns>
		public Task<Boolean> AuthenticateAsync()
		{
            return CreateNewTask<Boolean>(() => this.Authenticate());
		}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="localFilePath"></param>
        /// <param name="remoteFileName"></param>
        /// <returns></returns>
        public Task<Int64> UploadFileAsync(String localFilePath, String remoteFileName)
		{
            return CreateNewTask<Int64>(() => this.UploadFile(localFilePath, remoteFileName));
		}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        public Task DownloadFileAsync(String fileName)
		{
            return CreateNewTask(() => this.DownloadFile(fileName));
		}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="remoteFileName"></param>
        /// <param name="localFilePath"></param>
        /// <returns></returns>
        public Task<Int64> DownloadFileAsync(String remoteFileName, String localFilePath)
		{
            return CreateNewTask<Int64>(() => this.DownloadFile(remoteFileName, localFilePath));
		}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public Task<Int64> GetFileSizeAsync(String fileName)
		{
            return CreateNewTask<Int64>(() => this.GetFileSize(fileName));
		}
        /// FTPサーバーへCWDコマンドを送信します。
        /// <summary>
        /// Send cwd command to ftp server.
        /// FTPサーバーへCWDコマンドを送信します。
        /// </summary>
        /// <param name="pathName">指定したディレクトリ名</param>
        /// <returns></returns>
        public Task<FtpCommandResult> ExecuteCwdAsync(String pathName)
		{
            return CreateNewTask<FtpCommandResult>(() => this.ExecuteCwd(pathName));
		}
        /// FTPサーバーへCDUPコマンドを送信します。
        /// <summary>
        /// Send cdup command to ftp server.
        /// FTPサーバーへCDUPコマンドを送信します。
        /// </summary>
        /// <returns></returns>
        public Task<FtpCommandResult> ExecuteCdupAsync()
		{
            return CreateNewTask<FtpCommandResult>(() => this.ExecuteCdup());
		}
        /// FTPサーバーへSMNTコマンドを送信します。
        /// <summary>
        /// Send smnt command to ftp server.
        /// FTPサーバーへSMNTコマンドを送信します。
        /// <param name="pathName">課金情報</param>
        /// <returns></returns>
		public Task<FtpCommandResult> ExecuteSmntAsync(String pathName)
		{
            return CreateNewTask<FtpCommandResult>(() => this.ExecuteSmnt(pathName));
		}
        /// FTPサーバーへREINコマンドを送信します。
        /// <summary>
        /// Send rein command to ftp server.
        /// FTPサーバーへREINコマンドを送信します。
        /// </summary>
        /// <returns></returns>
		public Task<FtpCommandResult> ExecuteReinAsync()
		{
            return CreateNewTask<FtpCommandResult>(() => this.ExecuteRein());
		}
        /// FTPサーバーへQUITコマンドを送信します。
        /// <summary>
        /// Send quit command to ftp server.
        /// FTPサーバーへQUITコマンドを送信します。
        /// </summary>
        /// <returns></returns>
		public Task<FtpCommandResult> ExecuteQuitAsync()
		{
            return CreateNewTask<FtpCommandResult>(() => this.ExecuteQuit());
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="port"></param>
		/// <returns></returns>
		public Task<FtpCommandResult> ExecutePortAsync(String port)
		{
            return CreateNewTask<FtpCommandResult>(() => this.ExecutePort(port));
		}
        /// FTPサーバーへPASVコマンドを送信します。
        /// <summary>
        /// Send pasv command to ftp server.
        /// FTPサーバーへPASVコマンドを送信します。
        /// </summary>
        /// <returns></returns>
		public Task<FtpIPCommandResult> ExecutePasvAsync()
		{
            return CreateNewTask<FtpIPCommandResult>(() => this.ExecutePasv());
		}
        /// FTPサーバーへTYPEコマンドを送信します。
        /// <summary>
        /// Send type command to ftp server.
        /// FTPサーバーへTYPEコマンドを送信します。
        /// <param name="mode">形式オプション</param>
		/// <returns></returns>
		public Task<FtpCommandResult> ExecuteTypeAsync(FtpDataType type)
		{
            return CreateNewTask<FtpCommandResult>(() => this.ExecuteType(type));
		}
        /// FTPサーバーへSTRUコマンドを送信します。
        /// <summary>
        /// Send stru command to ftp server.
        /// FTPサーバーへSTRUコマンドを送信します。
        /// <param name="dataStruct">ファイル構造オプション</param>
        /// <returns></returns>
		public Task<FtpCommandResult> ExecuteStruAsync(FtpDataStructures dataStruct)
		{
            return CreateNewTask<FtpCommandResult>(() => this.ExecuteStru(dataStruct));
		}
        /// FTPサーバーへUSERコマンドを送信します。
        /// <summary>
        /// Send user command to ftp server.
        /// FTPサーバーへUSERコマンドを送信します。
        /// <param name="user">ユーザ</param>
        /// <returns></returns>
        public Task<FtpCommandResult> ExecuteUserAsync(String user)
        {
            return CreateNewTask<FtpCommandResult>(() => this.ExecuteUser(user));
        }
        /// FTPサーバーへPASSコマンドを送信します。
        /// <summary>
        /// Send pass command to ftp server.
        /// FTPサーバーへPASSコマンドを送信します。
        /// <param name="password">パスワード</param>
        /// <returns></returns>
        public Task<FtpCommandResult> ExecutePassAsync(String password)
        {
            return CreateNewTask<FtpCommandResult>(() => this.ExecutePass(password));
        }
        /// FTPサーバーへMODEコマンドを送信します。
        /// <summary>
        /// Send mode command to ftp server.
        /// FTPサーバーへMODEコマンドを送信します。
        /// <param name="mode">転送モード</param>
        /// <returns></returns>
		public Task<FtpCommandResult> ExecuteModeAsync(FtpTransferMode mode)
		{
            return CreateNewTask<FtpCommandResult>(() => this.ExecuteMode(mode));
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="fileName"></param>
		/// <returns></returns>
		public Task<FtpCommandResult> ExecuteRetrAsync(String fileName)
		{
            return CreateNewTask<FtpCommandResult>(() => this.ExecuteRetr(fileName));
		}
        /// FTPサーバーへSIZEコマンドを送信します。
        /// <summary>
        /// Send size command to ftp server.
        /// FTPサーバーへSIZEコマンドを送信します。
		/// </summary>
		/// <param name="fileName">ファイル名</param>
		/// <returns></returns>
		public Task<FtpCommandResult> ExecuteSizeAsync(String fileName)
		{
            return CreateNewTask<FtpCommandResult>(() => this.ExecuteSize(fileName));
		}
        /// FTPサーバーへSTORコマンドを送信します。
        /// <summary>
        /// Send stor command to ftp server.
        /// FTPサーバーへSTORコマンドを送信します。
        /// <param name="fileName">ファイル名(パスも含め)</param>
        /// <returns></returns>
		public Task<FtpCommandResult> ExecuteStorAsync(String fileName)
		{
            return CreateNewTask<FtpCommandResult>(() => this.ExecuteStor(fileName));
		}
        /// FTPサーバーへSTOUコマンドを送信します。
        /// <summary>
        /// Send stou command to ftp server.
        /// FTPサーバーへSTOUコマンドを送信します。
        /// <param name="fileName">ファイル名(パスも含め)</param>
        /// <returns></returns>
        public Task<FtpFileCommandResult> ExecuteStouAsync()
		{
            return CreateNewTask<FtpFileCommandResult>(() => this.ExecuteStou());
		}
        /// FTPサーバーへAPPEコマンドを送信します。
        /// <summary>
        /// Send appe command to ftp server.
        /// FTPサーバーへAPPEコマンドを送信します。
        /// <param name="fileName">ファイル名(パスも含め)</param>
        /// <returns></returns>
		public Task<FtpCommandResult> ExecuteAppeAsync(String fileName)
		{
            return CreateNewTask<FtpCommandResult>(() => this.ExecuteAppe(fileName));
		}
        /// FTPサーバーへALLOコマンドを送信します。
        /// <summary>
        /// Send allo command to ftp server.
        /// FTPサーバーへALLOコマンドを送信します。
        /// <param name="bytes">ファイルバイト数</param>
        /// <returns></returns>
        public Task<FtpCommandResult> ExecuteAlloAsync(Int64 bytes)
		{
            return CreateNewTask<FtpCommandResult>(() => this.ExecuteAllo(bytes));
		}
        /// FTPサーバーへRESTコマンドを送信します。
        /// <summary>
        /// Send rest command to ftp server.
        /// FTPサーバーへRESTコマンドを送信します。
        /// <param name="length">maker</param>
        /// <returns></returns>
        public Task<FtpCommandResult> ExecuteRestAsync(Int64 length)
		{
            return CreateNewTask<FtpCommandResult>(() => this.ExecuteRest(length));
		}
        /// FTPサーバーへRNFRコマンドを送信します。
        /// <summary>
        /// Send rnfr command to ftp server.
        /// FTPサーバーへRNFRコマンドを送信します。
        /// <param name="fileName">ファイル名</param>
        /// <returns></returns>
        public Task<FtpCommandResult> ExecuteRnfrAsync(String fileName)
		{
            return CreateNewTask<FtpCommandResult>(() => this.ExecuteRnfr(fileName));
		}
        /// FTPサーバーへRNTOコマンドを送信します。
        /// <summary>
        /// Send rnto command to ftp server.
        /// FTPサーバーへRNTOコマンドを送信します。
        /// <param name="fileName">ファイル名</param>
        /// <returns></returns>
        public Task<FtpCommandResult> ExecuteRntoAsync(String fileName)
		{
            return CreateNewTask<FtpCommandResult>(() => this.ExecuteRnto(fileName));
		}
        /// FTPサーバーへABORコマンドを送信します。
        /// <summary>
        /// Send abor command to ftp server.
        /// FTPサーバーへABORコマンドを送信します。
        /// </summary>
        /// <returns></returns>
        public Task<FtpCommandResult> ExecuteAborAsync()
		{
            return CreateNewTask<FtpCommandResult>(() => this.ExecuteAbor());
		}
        /// FTPサーバーへACCTコマンドを送信します。
        /// <summary>
        /// Send acct command to ftp server.
        /// FTPサーバーへACCTコマンドを送信します。
        /// </summary>
        /// <param name="accountInfo"></param>
        /// <returns></returns>
        public Task<FtpCommandResult> ExecuteAcctAsync(String accountInfo)
        {
            return CreateNewTask<FtpCommandResult>(() => this.ExecuteAcct(accountInfo));
        }
        /// FTPサーバーへDELEコマンドを送信します。
        /// <summary>
        /// Send dele command to ftp server.
        /// FTPサーバーへDELEコマンドを送信します。
        /// </summary>
        /// <param name="fileName">指定したファイル</param>
        /// <returns></returns>
        public Task<FtpCommandResult> ExecuteDeleAsync(String fileName)
		{
            return CreateNewTask<FtpCommandResult>(() => this.ExecuteDele(fileName));
		}
        /// FTPサーバーへRMDコマンドを送信します。
        /// <summary>
        /// Send rmd command to ftp server.
        /// FTPサーバーへRMDコマンドを送信します。
        /// </summary>
        /// <param name="directoryName">指定したディレクトリ名</param>
        /// <returns></returns>
        public Task<FtpCommandResult> ExecuteRmdAsync(String directoryName)
		{
            return CreateNewTask<FtpCommandResult>(() => this.ExecuteRmd(directoryName));
		}
        /// FTPサーバーへMKDコマンドを送信します。
        /// <summary>
        /// Send mkd command to ftp server.
        /// FTPサーバーへMKDコマンドを送信します。
        /// </summary>
        /// <param name="directoryName">指定したディレクトリ名</param>
        /// <returns></returns>
        public Task<FtpCommandResult> ExecuteMkdAsync(String directoryName)
		{
            return CreateNewTask<FtpCommandResult>(() => this.ExecuteMkd(directoryName));
		}
        /// FTPサーバーへPWDコマンドを送信します。
        /// <summary>
        /// Send pwd command to ftp server.
        /// FTPサーバーへPWDコマンドを送信します。
        /// </summary>
        /// <returns></returns>
        public Task<FtpDirectoryCommandResult> ExecutePwdAsync()
		{
            return CreateNewTask<FtpDirectoryCommandResult>(() => this.ExecutePwd());
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
        public Task<List<FtpDirectory>> ExecuteNlstAsync(FtpEntryType type)
		{
            return CreateNewTask<List<FtpDirectory>>(() => this.ExecuteNlst(type));
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
        public Task<List<FtpDirectory>> ExecuteListAsync(FtpEntryType type)
		{
            return CreateNewTask<List<FtpDirectory>>(() => this.ExecuteList(type));
		}
        /// FTPサーバーへSITEコマンドを送信します。
        /// <summary>
        /// Send site command to ftp server.
        /// FTPサーバーへSITEコマンドを送信します。
        /// <param name="cmdStr"></param>
        /// <returns></returns>
        public Task<FtpCommandResult> ExecuteSiteAsync(String cmdStr)
		{
            return CreateNewTask<FtpCommandResult>(() => this.ExecuteSite(cmdStr));
		}
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<FtpCommandResult> ExecuteSystAsync()
		{
            return CreateNewTask<FtpCommandResult>(() => this.ExecuteSyst());
		}
        /// FTPサーバーへSTATコマンドを送信します。
        /// <summary>
        /// Send stat command to ftp server.
        /// FTPサーバーへSTATコマンドを送信します。
        /// <param name="pathName">ファイル／ディレクトリ名</param>
        /// <returns></returns>
        public Task<FtpCommandResult> ExecuteStatAsync(String pathName)
		{
            return CreateNewTask<FtpCommandResult>(() => this.ExecuteStat(pathName));
		}
		/// FTPサーバーへHELPコマンドを送信します。
		/// <summary>
		/// Send help command to ftp server.
		/// FTPサーバーへHELPコマンドを送信します。
		/// </summary>
		/// <returns></returns>
        public Task<FtpCommandResult> ExecuteHelpAsync()
		{
            return CreateNewTask<FtpCommandResult>(() => this.ExecuteHelp());
		}
		/// FTPサーバーへNOOPコマンドを送信します。
		/// <summary>
		/// Send noop command to ftp server.
		/// FTPサーバーへNOOPコマンドを送信します。
		/// </summary>
		/// <returns></returns>
        public Task<FtpCommandResult> ExecuteNoopAsync()
		{
            return CreateNewTask<FtpCommandResult>(() => this.ExecuteNoop());
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="func"></param>
        public Task SetCreateFtpDirectoryDelegateAsync(Func<String, FtpDirectory> func)
		{
            return CreateNewTask(() => this.SetCreateFtpDirectoryDelegate(func));
		}
		/// <summary>
		/// FTPサーバから切断します。
		/// </summary>
        public Task DisconnectAsync()
		{
            return CreateNewTask(() => this.Disconnect());
		}
	}
}
