namespace SqlHelper.Context
{
    using System;
    using System.Runtime.Remoting.Messaging;

    /// <summary>
    /// 
    /// </summary>
    internal class WebContextContainer : IContextContainer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        private static void CheckKey(string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException("key is null", "key");
        }

        #region IContextContainer 成员

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(string key, object value)
        {
            CheckKey(key);

            if (CallContext.GetData(key) != null)
            {
                throw new ArgumentException(string.Format("相同键值{0}的元素已经存在", key), "key");
            }
            CallContext.SetData(key, value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Contains(string key)
        {
            CheckKey(key);
            return (CallContext.GetData(key) != null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        public void Remove(string key)
        {
            CheckKey(key);
            CallContext.SetData(key, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object this[string key]
        {
            get
            {
                CheckKey(key);
                return CallContext.GetData(key);
            }
            set
            {
                CheckKey(key);
                CallContext.SetData(key, value);
            }
        }

        #endregion
    }
}
