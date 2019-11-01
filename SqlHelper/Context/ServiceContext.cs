namespace SqlHelper.Context
{
    /// <summary>
    /// 
    /// </summary>
    public class ServiceContext
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly ServiceContext Current = new ServiceContext();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(string key, object value)
        {
            ContextContainer.Add(key, value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Contains(string key)
        {
            return ContextContainer.Contains(key);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        public void Remove(string key)
        {
            ContextContainer.Remove(key);
        }

        /// <summary>
        /// 
        /// </summary>
        private static IContextContainer ContextContainer
        {
            get
            {
                //if (HttpContext.Current == null)
                //{
                //    return new WebContextContainer();
                //}
                return new WebContextContainer();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object this[string key]
        {
            get { return ContextContainer[key]; }
            set { ContextContainer[key] = value; }
        }
    }
}
