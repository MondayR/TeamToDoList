using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamToDosEntity
{
    public class UserInfo
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        int UserID { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        string UserName { get; set; }
    }
    public static class loginUser {
        public static int UserID = 0;
        public static string UserName = "Anonymous";
        public static int ReflashChk = 0;
    }
}
