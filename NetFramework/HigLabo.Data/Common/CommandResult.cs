using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace HigLabo.Data
{
    /// コマンドの実行結果を表現します。
    /// <summary>
    /// コマンドの実行結果を表現します。
    /// </summary>
    public class CommandResult
    {
        private DbCommand _Command = null;
        private Int32 _AffectedRecordCount = 0;
        /// 実行したコマンドを取得します。
        /// <summary>
        /// 実行したコマンドを取得します。
        /// </summary>
        public DbCommand Command
        {
            get { return this._Command; }
        }
        /// コマンドの実行によって影響を受けた列数を返します。
        /// <summary>
        /// コマンドの実行によって影響を受けた列数を返します。
        /// </summary>
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
