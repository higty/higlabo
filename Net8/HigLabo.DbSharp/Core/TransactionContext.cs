using HigLabo.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp;

public class TransactionContext : IDisposable
{
    public static event EventHandler<EventArgs>? TransactionStarted;

    internal Database Database { get; set; }

    public TransactionContext(Database database)
        : this(database, null)
    {
    }
    public TransactionContext(Database database, IsolationLevel? isolationLevel)
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

    public void Open()
    {
        this.Database.Open();
    }
    public void Close()
    {
        this.Database.Close();
    }
    public void BeginTransaction(IsolationLevel isolationLevel)
    {
        this.Database.BeginTransaction(isolationLevel);
        TransactionContext.OnTransactionStarted(new EventArgs());
    }
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
    protected static void OnTransactionStarted(EventArgs e)
    {
        var eh = TransactionContext.TransactionStarted;
        if (eh != null)
        {
            eh(null, e);
        }
    }
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
