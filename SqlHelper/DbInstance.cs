namespace SqlHelper
{
    using System.Data;
    using System.Data.Common;
    using Microsoft.Practices.EnterpriseLibrary.Data;
    /// <summary>
    /// 数据访问初始
    /// </summary>
    public class DbInstance
    {
        private readonly Database database;
        private readonly DbTransaction dbTransaction;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <param name="trans"></param>
        internal DbInstance(Database db, DbTransaction trans)
        {
            this.database = db;
            this.dbTransaction = trans;
        }
        /// <summary>
        /// 添加参数
        /// </summary>
        /// <param name="command"></param>
        /// <param name="name"></param>
        /// <param name="dbType"></param>
        public void AddInParameter(DbCommand command, string name, DbType dbType)
        {
            this.database.AddInParameter(command, name, dbType);

        }
        /// <summary>
        /// 添加参数
        /// </summary>
        /// <param name="command"></param>
        /// <param name="name"></param>
        /// <param name="dbType"></param>
        /// <param name="value"></param>
        public void AddInParameter(DbCommand command, string name, DbType dbType, object value)
        {
            this.database.AddInParameter(command, name, dbType, value);
        }
        /// <summary>
        /// 添加参数
        /// </summary>
        /// <param name="command"></param>
        /// <param name="name"></param>
        /// <param name="dbType"></param>
        /// <param name="sourceColumn"></param>
        /// <param name="sourceVersion"></param>
        public void AddInParameter(DbCommand command, string name, DbType dbType, string sourceColumn, DataRowVersion sourceVersion)
        {
            this.database.AddInParameter(command, name, dbType, sourceColumn, sourceVersion);
        }

        /// <summary>
        /// 增加多个参数
        /// </summary>
        /// <param name="command"></param>
        /// <param name="parameters"></param>
        public void AddInParameters(DbCommand command, DbParameter[] parameters)
        {
            foreach (DbParameter param in parameters)
            {
                this.database.AddInParameter(command, param.ParameterName, param.DbType, param.Value);
            }
        }

        /// <summary>
        /// 增加一个输入参数
        /// </summary>
        /// <param name="command"></param>
        /// <param name="param"></param>
        public void AddInParameters(DbCommand command, DbParameter param)
        {
            this.database.AddInParameter(command, param.ParameterName, param.DbType, param.Value);
        }

        /// <summary>
        /// 添加参数
        /// </summary>
        /// <param name="command"></param>
        /// <param name="name"></param>
        /// <param name="dbType"></param>
        /// <param name="size"></param>
        public void AddOutParameter(DbCommand command, string name, DbType dbType, int size)
        {
            this.database.AddOutParameter(command, name, dbType, size);
        }
        /// <summary>
        /// 添加参数
        /// </summary>
        /// <param name="command"></param>
        /// <param name="name"></param>
        /// <param name="dbType"></param>
        /// <param name="direction"></param>
        /// <param name="sourceColumn"></param>
        /// <param name="sourceVersion"></param>
        /// <param name="value"></param>
        public void AddParameter(DbCommand command, string name, DbType dbType, ParameterDirection direction, string sourceColumn, DataRowVersion sourceVersion, object value)
        {
            this.database.AddParameter(command, name, dbType, direction, sourceColumn, sourceVersion, value);
        }
        /// <summary>
        /// 添加参数
        /// </summary>
        /// <param name="command"></param>
        /// <param name="name"></param>
        /// <param name="dbType"></param>
        /// <param name="size"></param>
        /// <param name="direction"></param>
        /// <param name="nullable"></param>
        /// <param name="precision"></param>
        /// <param name="scale"></param>
        /// <param name="sourceColumn"></param>
        /// <param name="sourceVersion"></param>
        /// <param name="value"></param>
        public void AddParameter(DbCommand command, string name, DbType dbType, int size, ParameterDirection direction, bool nullable, byte precision, byte scale, string sourceColumn, DataRowVersion sourceVersion, object value)
        {
            this.database.AddParameter(command, name, dbType, size, direction, nullable, precision, scale, sourceColumn, sourceVersion, value);
        }

        /// <summary>
        /// 获得 dataset
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public virtual DataSet ExecuteDataSet(DbCommand command)
        {
            if (this.IsInTransaction())
            {
                return this.database.ExecuteDataSet(command, this.dbTransaction);
            }
            return this.database.ExecuteDataSet(command);
        }
        /// <summary>
        ///  获得 dataset
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public virtual DataSet ExecuteDataSet(CommandType commandType, string commandText)
        {
            if (this.IsInTransaction())
            {
                return this.database.ExecuteDataSet(this.dbTransaction, commandType, MapSql(commandText));
            }
            return this.database.ExecuteDataSet(commandType, MapSql(commandText));
        }
        /// <summary>
        ///  获得 dataset
        /// </summary>
        /// <param name="storedProcedureName"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public virtual DataSet ExecuteDataSet(string storedProcedureName, params object[] parameterValues)
        {
            if (this.IsInTransaction())
            {
                return this.database.ExecuteDataSet(this.dbTransaction, MapSql(storedProcedureName), parameterValues);
            }
            return this.database.ExecuteDataSet(MapSql(storedProcedureName), parameterValues);
        }
        /// <summary>
        ///  获得 dataset
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public virtual DataSet ExecuteDataSetBySql(string sql)
        {
            return this.ExecuteDataSet(CommandType.Text, sql);
        }

        /// <summary>
        ///  获得 DataTable
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public virtual DataTable ExecuteDataTable(DbCommand command)
        {
            return this.ExecuteDataSet(command).Tables[0];
        }
        /// <summary>
        ///   获得 DataTable
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public virtual DataTable ExecuteDataTable(CommandType commandType, string commandText)
        {
            return this.ExecuteDataSet(commandType, commandText).Tables[0];
        }

        /// <summary>
        /// 获得 DataTable
        /// </summary>
        /// <param name="storedProcedureName"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public virtual DataTable ExecuteDataTable(string storedProcedureName, params object[] parameterValues)
        {
            return this.ExecuteDataSet(storedProcedureName, parameterValues).Tables[0];
        }
        /// <summary>
        /// 获得 DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public virtual DataTable ExecuteDataTableBySql(string sql)
        {
            return this.ExecuteDataSetBySql(sql).Tables[0];
        }
        /// <summary>
        /// 执行sql
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public virtual int ExecuteNonQuery(DbCommand command)
        {
            if (this.IsInTransaction())
            {
                return this.database.ExecuteNonQuery(command, this.dbTransaction);
            }
            return this.database.ExecuteNonQuery(command);
        }
        /// <summary>
        /// 执行sql
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public virtual int ExecuteNonQuery(CommandType commandType, string commandText)
        {
            if (this.IsInTransaction())
            {
                return this.database.ExecuteNonQuery(this.dbTransaction, commandType, MapSql(commandText));
            }
            return this.database.ExecuteNonQuery(commandType, MapSql(commandText));
        }
        /// <summary>
        /// 执行sql
        /// </summary>
        /// <param name="storedProcedureName"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public virtual int ExecuteNonQuery(string storedProcedureName, params object[] parameterValues)
        {
            if (this.IsInTransaction())
            {
                return this.database.ExecuteNonQuery(this.dbTransaction, MapSql(storedProcedureName), parameterValues);
            }
            return this.database.ExecuteNonQuery(MapSql(storedProcedureName), parameterValues);
        }
        /// <summary>
        /// 执行sql
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public virtual int ExecuteNonQueryBySql(string sql)
        {
            return this.ExecuteNonQuery(CommandType.Text, sql);
        }
        /// <summary>
        /// 执行 ExecuteReader
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public virtual IDataReader ExecuteReader(DbCommand command)
        {
            return this.database.ExecuteReader(command);
        }
        /// <summary>
        /// 执行 ExecuteReader
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public virtual IDataReader ExecuteReader(CommandType commandType, string commandText)
        {
            return this.database.ExecuteReader(commandType, MapSql(commandText));
        }
        /// <summary>
        /// 执行 ExecuteReader
        /// </summary>
        /// <param name="storedProcedureName"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public virtual IDataReader ExecuteReader(string storedProcedureName, params object[] parameterValues)
        {
            return this.database.ExecuteReader(MapSql(storedProcedureName), parameterValues);
        }
        /// <summary>
        /// 执行 ExecuteReader
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public virtual IDataReader ExecuteReaderBySql(string sql)
        {
            return this.ExecuteReader(CommandType.Text, sql);
        }
        /// <summary>
        /// 执行 ExecuteReader
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public virtual object ExecuteScalar(DbCommand command)
        {
            if (this.IsInTransaction())
            {
                return this.database.ExecuteScalar(command, this.dbTransaction);
            }
            return this.database.ExecuteScalar(command);
        }
        /// <summary>
        /// 执行 ExecuteReader
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public virtual object ExecuteScalar(CommandType commandType, string commandText)
        {
            if (this.IsInTransaction())
            {
                return this.database.ExecuteScalar(this.dbTransaction, commandType, MapSql(commandText));
            }
            return this.database.ExecuteScalar(commandType, MapSql(commandText));
        }
        /// <summary>
        /// 执行 ExecuteReader
        /// </summary>
        /// <param name="storedProcedureName"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public virtual object ExecuteScalar(string storedProcedureName, params object[] parameterValues)
        {
            if (this.IsInTransaction())
            {
                return this.database.ExecuteScalar(this.dbTransaction, MapSql(storedProcedureName), parameterValues);
            }
            return this.database.ExecuteScalar(MapSql(storedProcedureName), parameterValues);
        }
        /// <summary>
        /// 执行 ExecuteReader
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public virtual object ExecuteScalarBySql(string sql)
        {
            return this.ExecuteScalar(CommandType.Text, sql);
        }
        /// <summary>
        /// 获得DataAdapter
        /// </summary>
        /// <returns></returns>
        public DbDataAdapter GetDataAdapter()
        {
            return this.database.GetDataAdapter();
        }
        /// <summary>
        /// 获得参数
        /// </summary>
        /// <param name="command"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public object GetParameterValue(DbCommand command, string name)
        {
            return this.database.GetParameterValue(command, name);
        }
        /// <summary>
        /// 获得参数
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public DbCommand GetSqlStringCommand(string query)
        {
            return this.database.GetSqlStringCommand(MapSql(query));
        }
        /// <summary>
        /// 获得存储的参数
        /// </summary>
        /// <param name="storedProcedureName"></param>
        /// <returns></returns>
        public DbCommand GetStoredProcCommand(string storedProcedureName)
        {
            return this.database.GetStoredProcCommand(MapSql(storedProcedureName));
        }
        /// <summary>
        /// 获得存储的参数
        /// </summary>
        /// <param name="storedProcedureName"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public virtual DbCommand GetStoredProcCommand(string storedProcedureName, params object[] parameterValues)
        {
            return this.database.GetStoredProcCommand(MapSql(storedProcedureName), parameterValues);
        }
        /// <summary>
        /// 获得存储的参数
        /// </summary>
        /// <param name="storedProcedureName"></param>
        /// <param name="sourceColumns"></param>
        /// <returns></returns>
        public virtual DbCommand GetStoredProcCommandWithSourceColumns(string storedProcedureName, params string[] sourceColumns)
        {
            return this.database.GetStoredProcCommandWithSourceColumns(MapSql(storedProcedureName), sourceColumns);
        }
        /// <summary>
        /// 加载DataSet
        /// </summary>
        /// <param name="command"></param>
        /// <param name="dataSet"></param>
        /// <param name="tableNames"></param>
        public virtual void LoadDataSet(DbCommand command, DataSet dataSet, string[] tableNames)
        {
            if (this.IsInTransaction())
            {
                this.database.LoadDataSet(command, dataSet, tableNames, this.dbTransaction);
            }
            else
            {
                this.database.LoadDataSet(command, dataSet, tableNames);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <param name="dataSet"></param>
        /// <param name="tableName"></param>
        public void LoadDataSet(DbCommand command, DataSet dataSet, string tableName)
        {
            this.LoadDataSet(command, dataSet, new string[] { tableName });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <param name="dataSet"></param>
        /// <param name="tableNames"></param>
        public virtual void LoadDataSet(CommandType commandType, string commandText, DataSet dataSet, string[] tableNames)
        {
            if (this.IsInTransaction())
            {
                this.database.LoadDataSet(this.dbTransaction, commandType, MapSql(commandText), dataSet, tableNames);
            }
            else
            {
                this.database.LoadDataSet(commandType, MapSql(commandText), dataSet, tableNames);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="storedProcedureName"></param>
        /// <param name="dataSet"></param>
        /// <param name="tableNames"></param>
        /// <param name="parameterValues"></param>
        public virtual void LoadDataSet(string storedProcedureName, DataSet dataSet, string[] tableNames, params object[] parameterValues)
        {
            if (this.IsInTransaction())
            {
                this.database.LoadDataSet(this.dbTransaction, MapSql(storedProcedureName), dataSet, tableNames, parameterValues);
            }
            else
            {
                this.database.LoadDataSet(MapSql(storedProcedureName), dataSet, tableNames, parameterValues);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="dataSet"></param>
        /// <param name="tableNames"></param>
        public virtual void LoadDataSetBySql(string sql, DataSet dataSet, string[] tableNames)
        {
            this.LoadDataSet(CommandType.Text, sql, dataSet, tableNames);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <param name="parameterName"></param>
        /// <param name="value"></param>
        public void SetParameterValue(DbCommand command, string parameterName, object value)
        {
            this.database.SetParameterValue(command, parameterName, value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataSet"></param>
        /// <param name="tableName"></param>
        /// <param name="insertCommand"></param>
        /// <param name="updateCommand"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        public int UpdateDataSet(DataSet dataSet, string tableName, DbCommand insertCommand, DbCommand updateCommand, DbCommand deleteCommand)
        {
            return this.UpdateDataSet(dataSet, tableName, insertCommand, updateCommand, deleteCommand, UpdateBehavior.Transactional);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataSet"></param>
        /// <param name="tableName"></param>
        /// <param name="insertCommand"></param>
        /// <param name="updateCommand"></param>
        /// <param name="deleteCommand"></param>
        /// <param name="updateBehavior"></param>
        /// <returns></returns>
        public virtual int UpdateDataSet(DataSet dataSet, string tableName, DbCommand insertCommand, DbCommand updateCommand, DbCommand deleteCommand, UpdateBehavior updateBehavior)
        {
            if (this.IsInTransaction())
            {
                return this.database.UpdateDataSet(dataSet, tableName, insertCommand, updateCommand, deleteCommand, this.dbTransaction);
            }
            return this.database.UpdateDataSet(dataSet, tableName, insertCommand, updateCommand, deleteCommand, updateBehavior);
        }

        /// <summary>
        /// 初始
        /// </summary>
        /// <returns></returns>
        private bool IsInTransaction()
        {
            return (this.dbTransaction != null);
        }

        /// <summary>
        /// 分析sql
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        private static string MapSql(string sql)
        {
            //if (sql.StartsWith("$"))
            //{
            //    return SqlMapper.GetSql(sql.Remove(0, 1));
            //}
            return sql;
        }

    }
}
