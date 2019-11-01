namespace SqlHelper.Context
{
    using System.Data;
    using System.Data.Common;
    using Microsoft.Practices.EnterpriseLibrary.Data;

    /// <summary>
    /// 
    /// </summary>
    public class DataAccessContext
    {
        /// <summary>
        /// 
        /// </summary>
        public Database Database { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public DbTransaction Trans { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        private DbConnection connection;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="database"></param>
        public DataAccessContext(Database database)
        {
            this.Database = database;
        }

        /// <summary>
        /// 
        /// </summary>
        public void BeginTransaction()
        {
            this.connection = this.Database.CreateConnection();
            this.connection.Open();
            this.Trans = this.connection.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Rollback()
        {
            this.Trans.Rollback();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Commit()
        {
            this.Trans.Commit();
        }

        /// <summary>
        /// 
        /// </summary>
        public void CloseConnection()
        {
            if (this.connection.State == ConnectionState.Open)
                this.connection.Close();
        }
    }
}
