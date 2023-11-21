using HigLabo.Core;
using HigLabo.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Service
{
    public class LogAddCommand : ServiceCommand
    {
        public WebAccessLogTable WebAccessLogTable { get; init; }
        public ErrorLogTable ErrorLogTable { get; init; }
        public List<ErrorLogTable.Record> ErrorList { get; private set; } = new List<ErrorLogTable.Record>();
        public List<WebAccessLogTable.Record> WebAccessLogList { get; private set; } = new List<WebAccessLogTable.Record>();

        public LogAddCommand(WebAccessLogTable webAccessLogTable, ErrorLogTable errorLogTable)
        {
            this.WebAccessLogTable = webAccessLogTable;
            this.ErrorLogTable = errorLogTable;
        }

        public override async ValueTask ExecuteAsync()
        {
            try
            {
                if (this.WebAccessLogList.Count > 0)
                {
                    _ = await this.WebAccessLogTable.InsertAsync(this.WebAccessLogList);
                }
                if (this.ErrorList.Count > 0)
                {
                    _ = await this.ErrorLogTable.InsertAsync(this.ErrorList);
                }
            }
            catch
            {

            }
        }
    }
}
