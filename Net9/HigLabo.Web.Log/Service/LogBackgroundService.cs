using HigLabo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Service;

public class LogBackgroundService : BackgroundService
{
    public WebAccessLogTable WebAccessLogTable { get; init; }
    public ErrorLogTable ErrorLogTable { get; init; }

    public LogBackgroundService(WebAccessLogTable webAccessLogTable, ErrorLogTable errorLogTable)
        :base(nameof(LogBackgroundService), 0)
    {
        this.WebAccessLogTable = webAccessLogTable;
        this.ErrorLogTable = errorLogTable;
    }
    public void AddWebAccessLog(WebAccessLogTable.Record record)
    {
        var cm = new LogAddCommand(this.WebAccessLogTable, this.ErrorLogTable);
        cm.WebAccessLogList.Add(record);
        this.AddCommand(cm);
    }
    public void AddWebAccessLog(WebAccessLogTable.Record record, ErrorLogTable.Record errorRecord)
    {
        var cm = new LogAddCommand(this.WebAccessLogTable, this.ErrorLogTable);
        cm.WebAccessLogList.Add(record);
        cm.ErrorList.Add(errorRecord);
        this.AddCommand(cm);
    }
    public void AddErrorLog(Exception exception, Int32 errorLevel)
    {
        this.AddErrorLog(exception, errorLevel, "", "");
    }
    public void AddErrorLog(Exception exception, Int32 errorLevel, string userId, string message)
    {
        var cm = new LogAddCommand(this.WebAccessLogTable, this.ErrorLogTable);
        var r = ErrorLogTable.Record.Create(exception, errorLevel, userId, message);
        cm.ErrorList.Add(r);
        this.AddCommand(cm);
    }
}
