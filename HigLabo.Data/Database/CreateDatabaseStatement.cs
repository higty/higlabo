using System;
using System.Collections.Generic;
using System.Text;

namespace HigLabo.Data.SqlServer
{
    /// データベース作成スクリプトを生成する機能を提供します。
    /// <summary>
    /// データベース作成スクリプトを生成する機能を提供します。
    /// </summary>
    public class CreateDatabaseStatement
    {
        private String _DatabaseName = "";
        private String _Name = "";
        private String _FileName = "";
        private Int32 _Size = 10;
        private Int32? _MaxSize = null;
        private Int32 _FileGrowthByte = 1024;
        private Int32 _FileGrowthPercent = 10;
        private FileGrowthSizeUnit _FileGrowthUnit = FileGrowthSizeUnit.KB;
        private String _LogName = "";
        private String _LogFileName = "";
        private Int32 _LogSize = 10;
        private Int32? _LogMaxSize = null;
        private Int32 _LogFileGrowthByte = 1024;
        private Int32 _LogFileGrowthPercent = 10;
        private FileGrowthSizeUnit _LogFileGrowthUnit = FileGrowthSizeUnit.Percent;
        private String zCollate = "JAPANESE_CI_AS";
        private CompatibilityLevel _CompatibilityLevel = CompatibilityLevel.Default;
        private RecoveryModel _RecoveryModel = RecoveryModel.Default;
        /// <summary>
        /// 
        /// </summary>
        public String DatabaseName
        {
            get { return this._DatabaseName; }
            set { this._DatabaseName = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public String Name
        {
            get { return this._Name; }
            set { this._Name = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public String FileName
        {
            get { return this._FileName; }
            set { this._FileName = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Int32 Size
        {
            get { return this._Size; }
            set { this._Size = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Int32? MaxSize
        {
            get { return this._MaxSize; }
            set { this._MaxSize = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Int32 FileGrowthByte
        {
            get { return this._FileGrowthByte; }
            set { this._FileGrowthByte = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Int32 FileGrowthPercent
        {
            get { return this._FileGrowthPercent; }
            set { this._FileGrowthPercent = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public FileGrowthSizeUnit FileGrowthUnit
        {
            get { return this._FileGrowthUnit; }
            set { this._FileGrowthUnit = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public String LogName
        {
            get { return this._LogName; }
            set { this._LogName = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public String LogFileName
        {
            get { return this._LogFileName; }
            set { this._LogFileName = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Int32 LogSize
        {
            get { return this._LogSize; }
            set { this._LogSize = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Int32? LogMaxSize
        {
            get { return this._LogMaxSize; }
            set { this._LogMaxSize = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Int32 LogFileGrowthByte
        {
            get { return this._LogFileGrowthByte; }
            set { this._LogFileGrowthByte = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Int32 LogFileGrowthPercent
        {
            get { return this._LogFileGrowthByte; }
            set { this._LogFileGrowthPercent = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public FileGrowthSizeUnit LogFileGrowthUnit
        {
            get { return this._LogFileGrowthUnit; }
            set { this._LogFileGrowthUnit = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public String Collate
        {
            get { return this.zCollate; }
            set { this.zCollate = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public CompatibilityLevel CompatibilityLevel
        {
            get { return this._CompatibilityLevel; }
            set { this._CompatibilityLevel = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public RecoveryModel RecoveryModel
        {
            get { return this._RecoveryModel; }
            set { this._RecoveryModel = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="databaseName"></param>
        public CreateDatabaseStatement(String databaseName)
        {
            this._DatabaseName = databaseName;
            this._Name = databaseName;
            this._LogName = databaseName + "_log";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public String CreateStatement()
        {
            StringBuilder sb = new StringBuilder();
            String Name = "";
            String MaxSize = "Unlimited";

            sb.AppendLine("Use [master]");
            sb.AppendFormat("Create Database [{0}] On Primary", this._DatabaseName);
            sb.AppendLine();
            if (String.IsNullOrEmpty(this._Name) == true)
            {
                Name = this._DatabaseName;
            }
            else
            {
                Name = this._Name;
            }
            if (this._MaxSize.HasValue == true)
            {
                MaxSize = this._MaxSize.Value.ToString();
            }
            else
            {
                MaxSize = "Unlimited";
            }
            if (this._FileGrowthUnit == FileGrowthSizeUnit.Percent)
            {
                sb.AppendFormat("(Name = N'{0}', FileName = N'{1}' , Size = {2} , MaxSize = {3} , FileGrowth = {4}%)"
                    , Name, this._FileName, this._Size, MaxSize, this._FileGrowthPercent);
            }
            else
            {
                sb.AppendFormat("(Name = N'{0}', FileName = N'{1}' , Size = {2} , MaxSize = {3} , FileGrowth = {4}{5})"
                    , Name, this._FileName, this._Size, MaxSize, this._FileGrowthByte, this._FileGrowthUnit);
            }
            sb.AppendLine();

            sb.AppendLine("Log On");
            if (String.IsNullOrEmpty(this._LogName) == true)
            {
                Name = this._DatabaseName + "_log";
            }
            else
            {
                Name = this._LogName;
            }
            if (this._LogMaxSize.HasValue == true)
            {
                MaxSize = this._LogMaxSize.Value.ToString();
            }
            else
            {
                MaxSize = "Unlimited";
            }
            if (this._LogFileGrowthUnit == FileGrowthSizeUnit.Percent)
            {
                sb.AppendFormat("(Name = N'{0}', FileName = N'{1}' , Size = {2} , MaxSize = {3} , FileGrowth = {4}%)"
                    , Name, this._LogFileName, this._LogSize, MaxSize, this._LogFileGrowthPercent);
            }
            else
            {
                sb.AppendFormat("(Name = N'{0}', FileName = N'{1}' , Size = {2} , MaxSize = {3} , FileGrowth = {4}{5})"
                    , Name, this._LogFileName, this._LogSize, MaxSize, this._LogFileGrowthByte, this._LogFileGrowthUnit);
            }
            sb.AppendLine();

            sb.AppendLine("Collate " + this.zCollate);
            if (this._CompatibilityLevel != CompatibilityLevel.Default)
            {
                sb.AppendFormat("Exec dbo.sp_dbcmptlevel @dbname = N'{0}', @new_cmptlevel={1}", this._DatabaseName, (short)this._CompatibilityLevel);
            }
            sb.AppendLine();

            if (this._RecoveryModel != RecoveryModel.Default)
            {
                sb.AppendFormat("ALTER DATABASE [{0}] SET RECOVERY {1}", this._DatabaseName, GetRecoveryModelQuery(this._RecoveryModel));
            }

            return sb.ToString();
        }

        private static string GetRecoveryModelQuery(RecoveryModel recoveryModel)
        {
            switch (recoveryModel)
            {
                case RecoveryModel.Simple:
                    return "SIMPLE";
                case RecoveryModel.BulkLogged:
                    return "BULK_LOGGED";
                case RecoveryModel.Default:
                case RecoveryModel.Full:
                default:
                    return "FULL";
            }
        }
    }
}
