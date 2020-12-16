using Dapper;
using Infrastruct.Configs;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastruct.DB
{
    public abstract class PGSqlHelper
    {
        private IDbConnection connection;
        private IDbTransaction transaction;
        private IDbConnection Connection { get { if (IsClose) connection.Open(); if (!IsConnected) { connection.Close(); connection.Open(); } return connection; } set { connection = value; } }
        private IDbTransaction Transaction { get { return transaction; } set { transaction = value; } }

        private static readonly ConnectionState[] ConnectedStateCollection = new ConnectionState[] { ConnectionState.Executing, ConnectionState.Fetching, ConnectionState.Open };
        protected bool IsConnected { get { return ConnectedStateCollection.Contains(connection.State); } }
        protected bool IsClose { get { return connection.State == ConnectionState.Closed; } }
        protected bool IsTransaction { get { return transaction != null; } }
        public PGSqlHelper(string connectionString)
        {
            Connection = new NpgsqlConnection(connectionString);
        }

        public void BeginTransaction(IsolationLevel l = IsolationLevel.Serializable)
        {
            if (IsTransaction) throw new Exception("事务重复开启");
            Transaction = Connection.BeginTransaction(l);
        }

        public void Commit()
        {
            if (!IsTransaction) return;
            Transaction.Commit();
            Transaction = null;
        }

        public void Rollback()
        {
            if (!IsTransaction) return;
            Transaction.Rollback();
            Transaction = null;
        }

        public int Execute(string sql, object data = null)
        {
            return Connection.Execute(sql, data, Transaction);
        }

        public Task<int> ExecuteAsync(string sql, object data = null)
        {
            return Connection.ExecuteAsync(sql, data, Transaction);
        }

        public T Query<T>(string sql, object data = null)
        {
            return Connection.QueryFirstOrDefault<T>(sql, data, Transaction);
        }

        public Task<T> QueryAsync<T>(string sql, object data = null)
        {
            return Connection.QueryFirstOrDefaultAsync<T>(sql, data, Transaction);
        }

        public IEnumerable<T> QueryList<T>(string sql, object data = null)
        {
            return Connection.Query<T>(sql, data, Transaction);
        }

        public Task<IEnumerable<T>> QueryListAsync<T>(string sql, object data = null)
        {
            return Connection.QueryAsync<T>(sql, data, Transaction);
        }

    }
}
