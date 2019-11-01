namespace SqlHelper
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.Data;
    using Microsoft.Practices.EnterpriseLibrary.Data.Configuration;
    using Context;
    using System.Data;

    /// <summary>
    /// 
    /// </summary>
    public class DbManager
    {
        #region -- fields --
        private const string KeySuffix = "@EtourTSMS.dataaccess.context";

        private static readonly Dictionary<string, Database> DatabaseLookup =
            new Dictionary<string, Database>(StringComparer.InvariantCultureIgnoreCase);

        private static object LockObject = new object();

        private static string DefaultDatabaseName =
            DatabaseSettings.GetDatabaseSettings(ConfigurationSourceFactory.Create()).DefaultDatabase;

        #endregion

        #region -- private method --

        private DbManager()
        {
        }

        /// <summary>
        /// 获取Database实例(单例)
        /// </summary>
        /// <param name="dbName"></param>
        /// <returns></returns>
        private static Database GetDatabase(string dbName)
        {
            if (!DatabaseLookup.ContainsKey(dbName))
            {
                lock (LockObject)
                {
                    if (!DatabaseLookup.ContainsKey(dbName))
                    {
                        DatabaseLookup.Add(dbName, DatabaseFactory.CreateDatabase(dbName));
                    }
                }
            }
            return DatabaseLookup[dbName];
        }
        /// <summary>
        /// 获得key
        /// </summary>
        /// <param name="dbName"></param>
        /// <returns></returns>
        private static string GetKey(string dbName)
        {
            return dbName + KeySuffix;
        }

        /// <summary>
        /// 检查数据库名
        /// </summary>
        /// <param name="dbName"></param>
        private static void CheckDbName(string dbName)
        {
            if (string.IsNullOrEmpty(dbName))
                throw new ArgumentNullException("dbName", "数据库名称不能为空");
        }

        #endregion

        #region -- public method --
        /// <summary>
        /// 初始
        /// </summary>
        /// <returns></returns>

        public static DbInstance GetDbInstance()
        {
            return GetDbInstance(DefaultDatabaseName);
        }
        /// <summary>
        /// 初始
        /// </summary>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public static DbInstance GetDbInstance(string dbName)
        {
            CheckDbName(dbName);

            string key = dbName + KeySuffix;

            if (ServiceContext.Current.Contains(key))
            {
                DataAccessContext dac = ServiceContext.Current[key] as DataAccessContext;
                if (dac == null)
                    throw new Exception("dac is null");

                return new DbInstance(dac.Database, dac.Trans);
            }

            return new DbInstance(GetDatabase(dbName), null);
        }
        /// <summary>
        /// 事物
        /// </summary>
        public static void BeginTransaction()
        {
            BeginTransaction(DefaultDatabaseName);

        }
        /// <summary>
        /// 事物
        /// </summary>
        /// <param name="dbName"></param>
        public static void BeginTransaction(string dbName)
        {
            CheckDbName(dbName);

            string key = GetKey(dbName);
            if (ServiceContext.Current.Contains(key))
            {
                throw new InvalidOperationException(string.Format("数据库{0}的上下文环境已经存在。", dbName));
            }
            DataAccessContext dac = new DataAccessContext(GetDatabase(dbName));
            ServiceContext.Current.Add(key, dac);
            dac.BeginTransaction();
        }
        /// <summary>
        /// 回滚
        /// </summary>
        public static void Rollback()
        {
            Rollback(DefaultDatabaseName);
        }
        /// <summary>
        /// 回滚
        /// </summary>
        /// <param name="dbName"></param>
        public static void Rollback(string dbName)
        {
            CheckDbName(dbName);

            string key = GetKey(dbName);
            if (!ServiceContext.Current.Contains(key))
            {
                throw new InvalidOperationException(string.Format("数据库{0}的上下文环境不存在。", dbName));
            }

            DataAccessContext dac = ServiceContext.Current[key] as DataAccessContext;
            if (dac == null)
                throw new Exception("DataAccessContext is null");

            try
            {
                dac.Rollback();
            }
            finally
            {
                dac.CloseConnection();

                ServiceContext.Current.Remove(key);
            }
        }
        /// <summary>
        /// 提交
        /// </summary>
        public static void Commit()
        {
            Commit(DefaultDatabaseName);
        }
        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="dbName"></param>
        public static void Commit(string dbName)
        {
            CheckDbName(dbName);

            string key = GetKey(dbName);
            if (!ServiceContext.Current.Contains(key))
            {
                throw new InvalidOperationException(string.Format("数据库{0}的上下文环境不存在。", dbName));
            }

            DataAccessContext dac = ServiceContext.Current[key] as DataAccessContext;
            if (dac == null)
                throw new Exception("DataAccessContext is null");

            try
            {
                dac.Commit();
            }
            finally
            {
                dac.CloseConnection();

                ServiceContext.Current.Remove(key);
            }
        }

        /// <summary>
        /// 通过dbreader填充数据到列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static IList<T> FillList<T>(System.Data.IDataReader reader)
        {
            try
            {
                //先获取列名信息
                List<string> fieldsList = new List<string>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    fieldsList.Add(reader.GetName(i));
                }

                IList<T> lst = new List<T>();
                while (reader.Read())
                {
                    T RowInstance = Activator.CreateInstance<T>();
                    foreach (System.Reflection.PropertyInfo Property in typeof(T).GetProperties())
                    {
                        //try
                        //{
                        if (!fieldsList.Contains(Property.Name))
                            continue;
                        if (reader[Property.Name] != DBNull.Value)
                        {
                            Property.SetValue(RowInstance, reader[Property.Name], null);
                        }
                        //}
                        //catch
                        //{
                        //    continue;
                        //}

                    }
                    lst.Add(RowInstance);
                }
                return lst;
            }
            finally
            {
                reader.Close();
            }
        }

        public static IList<T> FillList<T>(System.Data.DataTable dataTable)
        {
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return new List<T>();
            var result = new List<T>();
            foreach (DataRow row in dataTable.Rows)
            {
                T t = Activator.CreateInstance<T>();
                foreach (var pi in typeof(T).GetProperties())
                {
                    if (row.Table.Columns.Contains(pi.Name) && row[pi.Name] != null && row[pi.Name] != DBNull.Value)
                    {
                        pi.SetValue(t, row[pi.Name], null);
                    }
                }
                result.Add(t);
            }
            return result;
        }
        #endregion

    }
}
