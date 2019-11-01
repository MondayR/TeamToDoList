using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamToDosDAL;
using System.Data;
using TeamToDosEntity;

namespace TeamToDosControllers
{
    public class BizController
    {
        BizDAL myDal = new BizDAL();

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Pwd"></param>
        /// <returns></returns>
        public bool Login(string UserName, string Pwd)
        {
            try
            {
                return myDal.Login(UserName, Pwd);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 测试数据库连接
        /// </summary>
        /// <param name="Server"></param>
        /// <param name="Uid"></param>
        /// <param name="Pwd"></param>
        /// <param name="DBName"></param>
        /// <returns></returns>
        public string TestDataBaseContect(string Server, string Uid, string Pwd, string DBName)
        {
            return myDal.TestDataBaseContect(Server, Uid, Pwd, DBName);
        }
        /// <summary>
        /// 新增问题记录
        /// </summary>
        /// <param name="myBug"></param>
        /// <returns></returns>
        public bool SaveBugInfo(BugInfo myBug)
        {
            return myDal.SaveBugInfo(myBug);
        }
        /// <summary>
        /// 查询问题记录
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="PresenterName"></param>
        /// <param name="SendeeName"></param>
        /// <param name="Describe"></param>
        /// <param name="State"></param>
        /// <returns></returns>
        public DataTable GetBugsInfo(DateTime BeginDate,DateTime EndDate,string PresenterName,string SendeeName,string Describe,int State)
        {
            return myDal.GetBugsInfo(BeginDate,EndDate,PresenterName,SendeeName,Describe,State);
        }
        /// <summary>
        /// 修改问题记录状态
        /// </summary>
        /// <param name="BugID"></param>
        /// <param name="State"></param>
        /// <returns></returns>
        public string ChangeState(int BugID,int State)
        {
            return myDal.ChangeState(BugID,State);
        }

        public int GetReflashChk()
        {
            return myDal.GetReflashChk();
        }

        public void RechkReflashChk()
        {
            myDal.RechkReflashChk();
        }
        /// <summary>
        /// 删除问题记录
        /// </summary>
        /// <param name="BugID"></param>
        /// <returns></returns>
        public int DelBugInfo(int BugID)
        {
            return myDal.DelBugInfo(BugID);
        }
    }
}
