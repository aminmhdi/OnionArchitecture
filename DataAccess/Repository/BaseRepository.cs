using Dapper;
using Domain.DataAccess.DataContext;
using Domain.DataAccess.Repository;
using System.Data;

namespace DataAccess.Repository
{

    public class BaseRepository<T> : IBaseRepository<T>
    {
        private readonly IConnectionKeeper _connectionKeeper;
        public BaseRepository(IConnectionKeeper connectionKeeper)
        {
            _connectionKeeper = connectionKeeper;
        }

        //Sync
        public int Execute(string sql, object param, int? commandTimeout, CommandType? commandType)
        {
            using var db = _connectionKeeper.GetNewConnection();
            return db.Execute(sql, param, commandTimeout: commandTimeout, commandType: commandType);
        }

        public IEnumerable<T> Query(string sql, object param, bool buffered, int? commandTimeout, CommandType? commandType)
        {
            using var db = _connectionKeeper.GetNewConnection();
            return db.Query<T>(sql, param, buffered: buffered, commandTimeout: commandTimeout, commandType: commandType);
        }

        public int QueryExecute(string sql, object param, int? commandTimeout, CommandType? commandType)
        {
            using var db = _connectionKeeper.GetNewConnection();
            return db.QueryFirstOrDefault<int>(sql, param, commandTimeout: commandTimeout, commandType: commandType);
        }

        public T QueryFirstOrDefault(string sql, object param, int? commandTimeout, CommandType? commandType)
        {
            using var db = _connectionKeeper.GetNewConnection();
            return db.QueryFirstOrDefault<T>(sql, param, commandTimeout: commandTimeout, commandType: commandType);
        }

        public SqlMapper.GridReader QueryMultiple(string sql, object param, int? commandTimeout, CommandType? commandType)
        {
            var db = _connectionKeeper.GetNewConnection();
            try
            {
                return db.QueryMultiple(sql, param, commandTimeout: commandTimeout, commandType: commandType);
            }
            catch
            {
                if (db.State != ConnectionState.Closed)
                    db.Close();
            }
            return default;
        }

        //Async
        public async Task<int> ExecuteAsync(string sql, object param, int? commandTimeout, CommandType? commandType)
        {
            using var db = _connectionKeeper.GetNewConnection();
            return await db.ExecuteAsync(sql, param, commandTimeout: commandTimeout, commandType: commandType);
        }

        public async Task<IEnumerable<T>> QueryAsync(string sql, object param, int? commandTimeout, CommandType? commandType)
        {
            var db = _connectionKeeper.GetNewConnection();
            try
            {
                return await db.QueryAsync<T>(sql, param, commandTimeout: commandTimeout, commandType: commandType);
            }
            catch
            {
                if (db.State != ConnectionState.Closed)
                    db.Close();
            }
            return default;
        }
        public async Task<int> QueryExecuteAsync(string sql, object param, int? commandTimeout, CommandType? commandType)
        {
            var db = _connectionKeeper.GetNewConnection();
            try
            {
                return await db.QueryFirstOrDefaultAsync<int>(sql, param, commandTimeout: commandTimeout, commandType: commandType);
            }
            catch
            {
                if (db.State != ConnectionState.Closed)
                    db.Close();
            }
            return default;
        }

        public async Task<T> QueryFirstOrDefaultAsync(string sql, object param, int? commandTimeout, CommandType? commandType)
        {
            using var db = _connectionKeeper.GetNewConnection();
            return await db.QueryFirstOrDefaultAsync<T>(sql, param, commandTimeout: commandTimeout, commandType: commandType);
        }

        public async Task<SqlMapper.GridReader> QueryMultipleAsync(string sql, object param, int? commandTimeout, CommandType? commandType)
        {
            var db = _connectionKeeper.GetNewConnection();
            try
            {
                return await db.QueryMultipleAsync(sql, param, commandTimeout: commandTimeout, commandType: commandType);
            }
            catch
            {
                if (db.State != ConnectionState.Closed)
                    db.Close();
            }
            return default;
        }

        public void Dispose()
        {
            _connectionKeeper.Dispose();
        }
    }
}
