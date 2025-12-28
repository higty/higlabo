using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Sockets;
using System.IO;
using HigLabo.Net.Internal;

namespace HigLabo.Net.Ftp;

public partial class FtpClient : SocketClient
{
    private class RegexList
    {
        public static readonly Regex IpAddress = new Regex("[0-9]{1-3}.[0-9]{1-3}.[0-9]{1-3}.[0-9]{1-3}", RegexOptions.IgnoreCase);
        public static readonly Regex FileSize = new Regex("((?<Size>[0-9]*) bytes)", RegexOptions.IgnoreCase);
    }
    public new static readonly FtpClientDefaultSettings Default = new FtpClientDefaultSettings();

    private SocketClient? _DataSocket = null;
    private Socket? _ListenSocket = null;

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
    public FtpConnectionState EnsureOpen()
    {
        if (this.Socket != null)
        { return this.State; }

        return this.Open();
    }
    private FtpCommandResult GetResponse()
    {
        List<FtpCommandResultLine> l = new List<FtpCommandResultLine>();
        FtpCommandResultLine? CurrentLine = null;
        Byte[] bb = this.GetResponseBytes(new FtpDataReceiveContext(this.ResponseEncoding));
        StringReader sr = new StringReader(this.ResponseEncoding.GetString(bb));
        Boolean isFirstLine = true;
        while (true)
        {
            var lineText = sr.ReadLine()!;
            if (isFirstLine == true)
            {
                CurrentLine = new FtpCommandResultLine(lineText);
            }
            else
            {
                CurrentLine = new FtpCommandResultLine(CurrentLine!.StatusCode, lineText);
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
    private FtpCommandResult Execute(String command)
    {
        this.Send(command);
        this.Commnicating = true;
        return this.GetResponse();
    }
    public Boolean Authenticate()
    {
        if (this.EnsureOpen() == FtpConnectionState.Connected)
        {
            var rs = this.Execute("user " + this.UserName);
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
        String[] pasv;

        var rs = this.ExecutePasv();
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
        if (this.Socket == null || this.Socket.LocalEndPoint == null)
        {
            throw new InvalidOperationException("Connection closed.");
        }
        this._ListenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        if (this._ListenSocket.LocalEndPoint == null)
        {
            throw new InvalidOperationException("Connection is not opened.");
        }

        String ad = this.Socket.LocalEndPoint.ToString()!;
        Int32 ix = ad.IndexOf(':');
        if (ix < 0)
        {
            throw new FtpClientException("Failed to parse the local address: " + ad);
        }
        String sIPAddr = ad.Substring(0, ix);
        var localEP = new IPEndPoint(IPAddress.Parse(sIPAddr), 0);

        this._ListenSocket.Bind(localEP);
        ad = this._ListenSocket.LocalEndPoint.ToString()!;
        ix = ad.IndexOf(':');
        if (ix < 0)
        {
            throw new FtpClientException("Failed to parse the local address: " + ad);
        }
        Int32 nPort = Int32.Parse(ad.Substring(ix + 1));

        this._ListenSocket.Listen(1);
        String port = String.Format("{0},{1},{2}", sIPAddr.Replace('.', ','), nPort / 256, nPort % 256);
        var rs = this.ExecutePort(port);
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
            //OpenDataSocket must be called before ConnectDataSocket executing.
            this._DataSocket = new SocketClient(this._ListenSocket!.Accept());
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
        Int64 fileSize = 0;

        if (this.EnsureOpen() == FtpConnectionState.Disconnected) { throw new FtpClientException("Connection must be opened"); }
        if (this.State == FtpConnectionState.Connected)
        {
            if (this.Authenticate() == false) { throw new FtpClientException("Authenticate failed"); }
        }
        this.OpenDataSocket();

        var rs = this.ExecuteType(this.DataType);
        this.OpenDataSocket();

        using (var stm = new FileStream(localFilePath, FileMode.Open))
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
            this._DataSocket!.Send(stm);

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
        Int64 size = 0;

        if (this.EnsureOpen() == FtpConnectionState.Disconnected) { throw new FtpClientException("Connection must be opened"); }
        if (this.State == FtpConnectionState.Connected)
        {
            if (this.Authenticate() == false) { throw new FtpClientException("Authenticate failed"); }
        }
        this.OpenDataSocket();

        var rs = this.ExecuteType(this.DataType);

        this.OpenDataSocket();
        rs = this.ExecuteRetr(remoteFileName);
        switch (rs.StatusCode)
        {
            case FtpCommandResultCode.DataConnectionAlreadyOpenTransferStarting: break;
            case FtpCommandResultCode.FileStatusOkayAboutToOpenDataConnection: break;
            default: throw new FtpClientException(rs);
        }
        var fileSize = this.GetFileSize(rs);

        ConnectDataSocket();

        FileStream? stm = null;
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
                this._DataSocket!.GetResponseStream(stm);
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

    public FtpCommandResult ChangeDirectory(String directoryName)
    {
        return this.ExecuteCwd(directoryName);
    }
    public FtpCommandResult ExecuteCwd(String directoryName)
    {
        this.EnsureOpen();
        var rs = this.Execute("Cwd " + directoryName);
        return rs;
    }
    public FtpCommandResult ExecuteCdup()
    {
        this.EnsureOpen();
        var rs = this.Execute("Cdup");
        return rs;
    }
    public FtpCommandResult ExecuteSmnt(String pathName)
    {
        this.EnsureOpen();
        var rs = this.Execute("Smnt " + pathName);
        return rs;
    }
    public FtpCommandResult ExecuteRein()
    {
        this.EnsureOpen();
        var rs = this.Execute("Rein");
        return rs;
    }
    public FtpCommandResult ExecuteQuit()
    {
        this.EnsureOpen();
        var rs = this.Execute("Quit");
        return rs;
    }
    public FtpCommandResult ExecutePort(String port)
    {
        this.EnsureOpen();
        var rs = this.Execute("Port " + port);
        return rs;
    }
    public FtpIPCommandResult ExecutePasv()
    {
        this.EnsureOpen();
        var rs = this.Execute("Pasv");
        return new FtpIPCommandResult(rs);
    }
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
    public FtpCommandResult ExecuteUser(String user)
    {
        this.EnsureOpen();
        var rs = this.Execute("User " + user);
        return rs;
    }
    public FtpCommandResult ExecutePass(String password)
    {
        this.EnsureOpen();
        var rs = this.Execute("Pass " + password);
        return rs;
    }
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
    public FtpCommandResult ExecuteRetr(String fileName)
    {
        this.EnsureOpen();
        var rs = this.Execute("Retr " + fileName);
        return rs;
    }
    public FtpCommandResult ExecuteSize(String fileName)
    {
        this.EnsureOpen();
        var rs = this.Execute("Size " + fileName);
        return rs;
    }
    public FtpCommandResult ExecuteStor(String fileName)
    {
        var rs = this.Execute("Stor " + fileName);
        return rs;
    }
    public FtpFileCommandResult ExecuteStou()
    {
        this.EnsureOpen();
        var rs = this.Execute("Stou");
        return new FtpFileCommandResult(rs);
    }
    public FtpCommandResult ExecuteAppe(String fileName)
    {
        this.EnsureOpen();
        var rs = this.Execute("Appe " + fileName);
        return rs;
    }
    public FtpCommandResult ExecuteAllo(Int64 bytes)
    {
        this.EnsureOpen();
        var rs = this.Execute("Allo " + bytes);
        return rs;
    }
    public FtpCommandResult ExecuteRest(Int64 length)
    {
        this.EnsureOpen();
        var rs = this.Execute("Rest " + length);
        return rs;
    }
    public FtpCommandResult ExecuteRnfr(String fileName)
    {
        this.EnsureOpen();
        var rs = this.Execute("Rnfr " + fileName);
        return rs;
    }
    public FtpCommandResult ExecuteRnto(String fileName)
    {
        this.EnsureOpen();
        var rs = this.Execute("Rnto " + fileName);
        return rs;
    }
    public FtpCommandResult ExecuteAbor()
    {
        var rs = this.Execute("Abor");
        return rs;
    }
    public FtpCommandResult ExecuteAcct(String accountInfo)
    {
        this.EnsureOpen();
        var rs = this.Execute("Acct " + accountInfo);
        return rs;
    }
    public FtpCommandResult ExecuteDele(String fileName)
    {
        this.EnsureOpen();
        var rs = this.Execute("Dele " + fileName);
        return rs;
    }
    public FtpCommandResult ExecuteRmd(String directoryName)
    {
        this.EnsureOpen();
        var rs = this.Execute("Rmd " + directoryName);
        return rs;
    }
    public FtpCommandResult ExecuteMkd(String directoryName)
    {
        this.EnsureOpen();
        var rs = this.Execute("Mkd " + directoryName);
        return rs;
    }
    public FtpDirectoryCommandResult ExecutePwd()
    {
        this.EnsureOpen();
        var rs = this.Execute("Pwd");
        return new FtpDirectoryCommandResult(rs);
    }
    public List<FtpDirectory> ExecuteNlst(FtpEntryType type)
    {
        this.EnsureOpen();
        this.OpenDataSocket();

        Byte[] bytes = new Byte[512];
        List<FtpDirectory> l = new List<FtpDirectory>();

        var rs = this.Execute("Nlst");

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
        String text = this._DataSocket!.GetResponseText();
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
            l.Add(new FtpDirectory(sr.ReadLine()!));
        }
        return l;
    }
    public List<FtpDirectory> ExecuteList(FtpEntryType type)
    {
        this.EnsureOpen();
        this.OpenDataSocket();

        Byte[] bytes = new Byte[512];
        List<FtpDirectory> l = new List<FtpDirectory>();

        var rs = this.Execute("List");

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
        String text = this._DataSocket!.GetResponseText();
        this.CloseDataSocket();

        rs = this.GetResponse();

        if (rs.StatusCode != FtpCommandResultCode.ClosingDataConnection)
        {
            throw new FtpClientException(rs);
        }
        var sr = new StringReader(text);
        while (sr.Peek() > -1)
        {
            l.Add(this.CreateFtpDirectory(sr.ReadLine()!));
        }
        return l;
    }
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
    public FtpCommandResult ExecuteStat(String pathName)
    {
        this.EnsureOpen();
        var rs = this.Execute("Stat " + pathName);
        return rs;
    }
    public FtpCommandResult ExecuteHelp()
    {
        this.EnsureOpen();
        var rs = this.Execute("Help");
        return rs;
    }
    public FtpCommandResult ExecuteNoop()
    {
        this.EnsureOpen();
        var rs = this.Execute("Noop");
        return rs;
    }
    public void SetCreateFtpDirectoryDelegate(Func<String, FtpDirectory> func)
    {
        this.CreateFtpDirectory = func;
    }
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
