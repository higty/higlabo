using HigLabo.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp
{
    public class TransactionContext : IDisposable
    {
        public static event EventHandler<EventArgs> TransactionStarted;

        internal Database Database { get; set; }

        public TransactionContext(Database database)
        {
            this.Initialize(database, null);
        }
        public TransactionContext(Database database, IsolationLevel isolationLevel)
        {
            this.Initialize(database, isolationLevel);
        }
        private void Initialize(Database database, IsolationLevel? isolationLevel)
        {
            this.Database = database;
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
            TransactionContext.OnTransactionStarted(new EventArgs());
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
        /// <param name="e"></param>
        protected static void OnTransactionStarted(EventArgs e)
        {
            var eh = TransactionContext.TransactionStarted;
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
            try
            {
                db.Dispose();
            }
            catch { }
        }
    }
}
