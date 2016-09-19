using HigLabo.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp
{
	/// <summary>
	/// 
	/// </summary>
    public class DatabaseContext : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        public static event EventHandler<EventArgs> TransactionStarted;

        /// <summary>
        /// Thread固有なのでロックは不要。
        /// ここでnewするとこのスレッドだけしか値がセットされないのでContextsプロパティ内部でインスタンスをセットする。
        /// Lock in unnecessary because of thread static.
        /// We will set instance inside Contexts property to ensure each thread has instance.
        /// </summary>
        [ThreadStatic]
        private static Dictionary<String, DatabaseContext> _Contexts = null;
        private static Dictionary<String, DatabaseContext> Contexts
        {
            get
            {
                if (_Contexts == null)
                {
                    _Contexts = new Dictionary<String, DatabaseContext>();
                }
                return _Contexts;
            }
        }
        internal Database Database { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String TransactionKey { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public DatabaseContext(Database database)
        {
            this.Initialize(database, "", null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionKey"></param>
        public DatabaseContext(Database database, String transactionKey)
        {
            this.Initialize(database, transactionKey, null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionKey"></param>
        /// <param name="isolationLevel"></param>
        public DatabaseContext(Database database, String transactionKey, IsolationLevel isolationLevel)
        {
            this.Initialize(database, transactionKey, isolationLevel);
        }
        private void Initialize(Database database, String transactionKey, IsolationLevel? isolationLevel)
        {
            this.TransactionKey = transactionKey;
            this.Database = database;
            DatabaseContext.SetDatabaseContext(this.TransactionKey, this);
            if (isolationLevel.HasValue == true)
            {
                try
                {
                    this.BeginTransaction(isolationLevel.Value);
                }
                finally
                {
                    this.Dispose();
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void Open()
        {
            this.Database.Open();
        }
        /// <summary>
        /// 
        /// </summary>
        public void Close()
        {
            this.Database.Close();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="isolationLevel"></param>
        public void BeginTransaction(IsolationLevel isolationLevel)
        {
            this.Database.BeginTransaction(isolationLevel);
            DatabaseContext.OnTransactionStarted(new EventArgs());
        }
        /// <summary>
        /// 
        /// </summary>
        public void CommitTransaction()
        {
            Database db = this.Database;
            if (db.OnTransaction == false)
            {
                throw new InvalidOperationException("Transaction does not start or finished."
                  + "Please call BeginTransaction method of DatabaseContext object before call this method."
                  + "Or ensure call once CommitTransaction or RollbackTransaction.");
            }
            db.CommitTransaction();
        }
        /// <summary>
        /// 
        /// </summary>
        public void RollbackTransaction()
        {
            Database db = this.Database;
            if (db.OnTransaction == false)
            {
                throw new InvalidOperationException("Transaction does not start or finished."
                  + "Please call BeginTransaction method of DatabaseContext object before call this method."
                  + "Or ensure call once CommitTransaction or RollbackTransaction.");
            }
            db.RollBackTransaction();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionKey"></param>
        /// <returns></returns>
        internal static DatabaseContext GetDatabaseContext(String transactionKey)
        {
            if (transactionKey == null)
            {
                return null;
            }
            var dcs = DatabaseContext.Contexts;
            DatabaseContext dc = null;
            dcs.TryGetValue(transactionKey, out dc);
            return dc;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionKey"></param>
        /// <param name="database"></param>
        private static void SetDatabaseContext(String transactionKey, DatabaseContext database)
        {
            var dcs = DatabaseContext.Contexts;
            if (dcs.ContainsKey(transactionKey) == true) throw new TransactionKeyAlreadyUsedException();
            dcs[transactionKey] = database;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected static void OnTransactionStarted(EventArgs e)
        {
            var eh = DatabaseContext.TransactionStarted;
            if (eh != null)
            {
                eh(null, e);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            Database db = this.Database;

            var dcs = DatabaseContext.Contexts;
            if (dcs.ContainsKey(this.TransactionKey) == true)
            {
                dcs.Remove(this.TransactionKey);
            }
            db.Dispose();
        }
    }
}
