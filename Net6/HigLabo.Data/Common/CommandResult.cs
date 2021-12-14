using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace HigLabo.Data
{
    public class CommandResult
    {
        private DbCommand _Command = null;
        private Int32 _AffectedRecordCount = 0;

        public DbCommand Command
        {
            get { return this._Command; }
        }
        public Int32 AffectedRecordCount
        {
            get { return this._AffectedRecordCount; }
        }

        public CommandResult(DbCommand inCommand, Int32 inAffectedRecordCount)
        {
            this._Command = inCommand;
            this._AffectedRecordCount = inAffectedRecordCount;
        }
    }
}
