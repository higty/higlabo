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

namespace HigLabo.Net.Ftp;

public partial class FtpClient
{
    protected static Task<T> CreateNewTask<T>(Func<T> func)
    {
        return Task.Factory.StartNew<T>(func);
    }
    protected Task CreateNewTask(Action func)
    {
        return Task.Factory.StartNew(func);
    }
    public Task<FtpConnectionState> OpenAsync()
    {
        return CreateNewTask<FtpConnectionState>(() => this.Open());
    }
    public Task<FtpConnectionState> EnsureOpenAsync()
    {
        return CreateNewTask<FtpConnectionState>(() => this.EnsureOpen());
    }
    public Task<Boolean> AuthenticateAsync()
    {
        return CreateNewTask<Boolean>(() => this.Authenticate());
    }
    public Task<Int64> UploadFileAsync(String localFilePath, String remoteFileName)
    {
        return CreateNewTask<Int64>(() => this.UploadFile(localFilePath, remoteFileName));
    }
    public Task DownloadFileAsync(String fileName)
    {
        return CreateNewTask(() => this.DownloadFile(fileName));
    }
    public Task<Int64> DownloadFileAsync(String remoteFileName, String localFilePath)
    {
        return CreateNewTask<Int64>(() => this.DownloadFile(remoteFileName, localFilePath));
    }
    public Task<Int64> GetFileSizeAsync(String fileName)
    {
        return CreateNewTask<Int64>(() => this.GetFileSize(fileName));
    }
    public Task<FtpCommandResult> ExecuteCwdAsync(String pathName)
    {
        return CreateNewTask<FtpCommandResult>(() => this.ExecuteCwd(pathName));
    }
    public Task<FtpCommandResult> ExecuteCdupAsync()
    {
        return CreateNewTask<FtpCommandResult>(() => this.ExecuteCdup());
    }
    public Task<FtpCommandResult> ExecuteSmntAsync(String pathName)
    {
        return CreateNewTask<FtpCommandResult>(() => this.ExecuteSmnt(pathName));
    }
    public Task<FtpCommandResult> ExecuteReinAsync()
    {
        return CreateNewTask<FtpCommandResult>(() => this.ExecuteRein());
    }
    public Task<FtpCommandResult> ExecuteQuitAsync()
    {
        return CreateNewTask<FtpCommandResult>(() => this.ExecuteQuit());
    }
    public Task<FtpCommandResult> ExecutePortAsync(String port)
    {
        return CreateNewTask<FtpCommandResult>(() => this.ExecutePort(port));
    }
    public Task<FtpIPCommandResult> ExecutePasvAsync()
    {
        return CreateNewTask<FtpIPCommandResult>(() => this.ExecutePasv());
    }
    public Task<FtpCommandResult> ExecuteTypeAsync(FtpDataType type)
    {
        return CreateNewTask<FtpCommandResult>(() => this.ExecuteType(type));
    }
    public Task<FtpCommandResult> ExecuteStruAsync(FtpDataStructures dataStruct)
    {
        return CreateNewTask<FtpCommandResult>(() => this.ExecuteStru(dataStruct));
    }
    public Task<FtpCommandResult> ExecuteUserAsync(String user)
    {
        return CreateNewTask<FtpCommandResult>(() => this.ExecuteUser(user));
    }
    public Task<FtpCommandResult> ExecutePassAsync(String password)
    {
        return CreateNewTask<FtpCommandResult>(() => this.ExecutePass(password));
    }
    public Task<FtpCommandResult> ExecuteModeAsync(FtpTransferMode mode)
    {
        return CreateNewTask<FtpCommandResult>(() => this.ExecuteMode(mode));
    }
    public Task<FtpCommandResult> ExecuteRetrAsync(String fileName)
    {
        return CreateNewTask<FtpCommandResult>(() => this.ExecuteRetr(fileName));
    }
    public Task<FtpCommandResult> ExecuteSizeAsync(String fileName)
    {
        return CreateNewTask<FtpCommandResult>(() => this.ExecuteSize(fileName));
    }
    public Task<FtpCommandResult> ExecuteStorAsync(String fileName)
    {
        return CreateNewTask<FtpCommandResult>(() => this.ExecuteStor(fileName));
    }
    public Task<FtpFileCommandResult> ExecuteStouAsync()
    {
        return CreateNewTask<FtpFileCommandResult>(() => this.ExecuteStou());
    }
    public Task<FtpCommandResult> ExecuteAppeAsync(String fileName)
    {
        return CreateNewTask<FtpCommandResult>(() => this.ExecuteAppe(fileName));
    }
    public Task<FtpCommandResult> ExecuteAlloAsync(Int64 bytes)
    {
        return CreateNewTask<FtpCommandResult>(() => this.ExecuteAllo(bytes));
    }
    public Task<FtpCommandResult> ExecuteRestAsync(Int64 length)
    {
        return CreateNewTask<FtpCommandResult>(() => this.ExecuteRest(length));
    }
    public Task<FtpCommandResult> ExecuteRnfrAsync(String fileName)
    {
        return CreateNewTask<FtpCommandResult>(() => this.ExecuteRnfr(fileName));
    }
    public Task<FtpCommandResult> ExecuteRntoAsync(String fileName)
    {
        return CreateNewTask<FtpCommandResult>(() => this.ExecuteRnto(fileName));
    }
    public Task<FtpCommandResult> ExecuteAborAsync()
    {
        return CreateNewTask<FtpCommandResult>(() => this.ExecuteAbor());
    }
    public Task<FtpCommandResult> ExecuteAcctAsync(String accountInfo)
    {
        return CreateNewTask<FtpCommandResult>(() => this.ExecuteAcct(accountInfo));
    }
    public Task<FtpCommandResult> ExecuteDeleAsync(String fileName)
    {
        return CreateNewTask<FtpCommandResult>(() => this.ExecuteDele(fileName));
    }
    public Task<FtpCommandResult> ExecuteRmdAsync(String directoryName)
    {
        return CreateNewTask<FtpCommandResult>(() => this.ExecuteRmd(directoryName));
    }
    public Task<FtpCommandResult> ExecuteMkdAsync(String directoryName)
    {
        return CreateNewTask<FtpCommandResult>(() => this.ExecuteMkd(directoryName));
    }
    public Task<FtpDirectoryCommandResult> ExecutePwdAsync()
    {
        return CreateNewTask<FtpDirectoryCommandResult>(() => this.ExecutePwd());
    }
    public Task<List<FtpDirectory>> ExecuteNlstAsync(FtpEntryType type)
    {
        return CreateNewTask<List<FtpDirectory>>(() => this.ExecuteNlst(type));
    }
    public Task<List<FtpDirectory>> ExecuteListAsync(FtpEntryType type)
    {
        return CreateNewTask<List<FtpDirectory>>(() => this.ExecuteList(type));
    }
    public Task<FtpCommandResult> ExecuteSiteAsync(String cmdStr)
    {
        return CreateNewTask<FtpCommandResult>(() => this.ExecuteSite(cmdStr));
    }
    public Task<FtpCommandResult> ExecuteSystAsync()
    {
        return CreateNewTask<FtpCommandResult>(() => this.ExecuteSyst());
    }
    public Task<FtpCommandResult> ExecuteStatAsync(String pathName)
    {
        return CreateNewTask<FtpCommandResult>(() => this.ExecuteStat(pathName));
    }
    public Task<FtpCommandResult> ExecuteHelpAsync()
    {
        return CreateNewTask<FtpCommandResult>(() => this.ExecuteHelp());
    }
    public Task<FtpCommandResult> ExecuteNoopAsync()
    {
        return CreateNewTask<FtpCommandResult>(() => this.ExecuteNoop());
    }
    public Task SetCreateFtpDirectoryDelegateAsync(Func<String, FtpDirectory> func)
    {
        return CreateNewTask(() => this.SetCreateFtpDirectoryDelegate(func));
    }
    public Task DisconnectAsync()
    {
        return CreateNewTask(() => this.Disconnect());
    }
}
