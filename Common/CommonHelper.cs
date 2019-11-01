using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// 
    /// </summary>
    public class CommonHelper
    {
        #region 转换函数
        /// <summary>
        /// object 转换为 int
        /// </summary>
        /// <returns></returns>
        public static int ObjToInt(object obj)
        {
            if (obj == null)
                return 0;
            if (obj.Equals(DBNull.Value))
                return 0;

            int returnValue;

            if (int.TryParse(obj.ToString(), out returnValue))
            {
                return returnValue;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 转换为boolean型
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool ObjToBool(object obj)
        {
            if (obj == null)
                return false;
            if (obj.Equals(DBNull.Value))
                return false;

            bool returnValue;

            if (bool.TryParse(obj.ToString(), out returnValue))
            {
                return returnValue;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// object 转换为 int?
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int? ObjToIntNull(object obj)
        {
            if (obj == null)
                return null;
            if (obj.Equals(DBNull.Value))
                return null;

            return ObjToInt(obj);
        }


        /// <summary>
        /// object 转换为 string
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ObjToStr(object obj)
        {
            if (obj == null)
                return "";
            if (obj.Equals(DBNull.Value))
                return "";
            return Convert.ToString(obj);
        }


        /// <summary>
        /// object 转换为 decimal
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static decimal ObjToDecimal(object obj)
        {
            if (obj == null)
                return 0;
            if (obj.Equals(DBNull.Value))
                return 0;

            try
            {
                return Convert.ToDecimal(obj);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// object 转换为 decimal?
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static decimal? ObjToDecimalNull(object obj)
        {
            if (obj == null)
                return null;
            if (obj.Equals(DBNull.Value))
                return null;

            return ObjToDecimal(obj);
        }


        /// <summary>
        /// 转换为日期
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime? ObjToDateNull(object obj)
        {
            if (obj == null)
            {
                return null;
            }
            try
            {
                return Convert.ToDateTime(obj);
            }
            catch
            {
                return null;
            }
        }





        #endregion
    }
}
