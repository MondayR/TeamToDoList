using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Data.SqlClient;
using System.Data;
using TeamToDosEntity;
using Common;
using System.Data.Common;

namespace TeamToDosDAL
{
    public class DBConInfo {
        public static string strConn = "server={0};uid={1};pwd={2};database={3}";
    }
    public class BizDAL
    {
        
        public bool Login(string UserName,string Pwd) {
            try {
                if (CommonDAL.InitDataBase() && UserName.IsSafeSqlString() && UserName.ProcessSqlStr()) {
                    string Sql = "select Top 1 * from UserInfos Where UserAccount = '{0}' And UserPwd='{1}'";
                    Sql = string.Format(Sql,UserName,Pwd);
                    SqlConnection con = new SqlConnection(DBConInfo.strConn);
                    con.Open();
                    SqlCommand cmd = new SqlCommand(Sql,con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds,"[UserInfos]");
                    con.Close();
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            loginUser.UserID = ds.Tables[0].Rows[0]["UserID"].ToInt(0);
                            loginUser.UserName = ds.Tables[0].Rows[0]["UserName"].ToStr().Trim();
                            return true;
                        }
                        else return false;
                    }
                    else return false;
                }
                else return false;
            }
            catch (Exception ex) {
                return false;
            }
        }
        /// <summary>
        /// 测试数据库连通
        /// </summary>
        /// <param name="Server"></param>
        /// <param name="UserName"></param>
        /// <param name="Pwd"></param>
        /// <param name="DBName"></param>
        /// <returns></returns>
        public string TestDataBaseContect(string Server, string UserName, string Pwd, string DBName)
        {
            try
            {
                string Connect = "server={0};uid={1};pwd={2};database={3}";
                Connect = string.Format(Connect, Server, UserName, Pwd, DBName);
                string Sql = "select Top 1 * from UserInfos";
                SqlConnection con = new SqlConnection(Connect);
                con.Open();
                SqlCommand cmd = new SqlCommand(Sql, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "[UserInfo]");
                con.Close();
                return "连接成功！";
            }
            catch (Exception ex)
            {
                return "连接失败！失败原因：" + ex.Message;
            }
        }
        /// <summary>
        /// 问题记录数据插入
        /// </summary>
        /// <param name="myBug"></param>
        /// <returns></returns>
        public bool SaveBugInfo(BugInfo myBug)
        {
            string strSql = "Insert Into BugsTake(Describe,BugLevel,PresenterID,PresenterName,PresentDate,DealState,SendeeName,SendeeID)" +
                "Values(@Describe,@BugLevel,@PresenterID,@PresenterName,getdate(),@DealState,'',0);" +
                "Select SCOPE_IDENTITY() As BugID;";
            SqlConnection con = new SqlConnection(DBConInfo.strConn);
            con.Open();
            SqlCommand cmd = new SqlCommand(strSql, con);
            cmd.Parameters.Add("@Describe", DbType.String);
            cmd.Parameters["@Describe"].Value = myBug.Describe;
            cmd.Parameters.Add("@BugLevel", DbType.Int32);
            cmd.Parameters["@BugLevel"].Value = myBug.BugLevel;
            cmd.Parameters.Add("@PresenterID", DbType.Int32);
            cmd.Parameters["@PresenterID"].Value = myBug.PresenterID;
            cmd.Parameters.Add("@PresenterName", DbType.String);
            cmd.Parameters["@PresenterName"].Value = myBug.PresenterName;
            cmd.Parameters.Add("@DealState", DbType.Int32);
            cmd.Parameters["@DealState"].Value = myBug.DealState;
            int flag = cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }

        public DataTable GetBugsInfo(DateTime BeginDate, DateTime EndDate, string PresenterName, string SendeeName, string Describe, int State)
        {
            string StrWhere = " where 1=1 ";
            StrWhere += string.Format(" And PresentDate >= '{0} 00:00' ",BeginDate.ToString("yyyy-MM-dd"));
            StrWhere += string.Format(" And PresentDate <= '{0} 23:59' ", EndDate.ToString("yyyy-MM-dd"));
            if (PresenterName != "")
            {
                StrWhere += string.Format(" And PresenterName like N'%{0}%' ",PresenterName.Trim().Replace("'","''"));
            }
            if (SendeeName != "")
            {
                StrWhere += string.Format(" And SendeeName like N'%{0}%' ", SendeeName.Trim().Replace("'","''"));
            }
            if (Describe != "")
            {
                StrWhere += string.Format(" And Describe like N'%{0}%' ",Describe.Trim().Replace("'","''"));
            }
            if (State != 0)
            {
                switch (State)
                {
                    case 1:
                        StrWhere += " And DealState = 0 ";//新增
                        break;
                    case 2:
                        StrWhere += " And DealState = 1 ";//已接收未完成
                        break;
                    case 3:
                        StrWhere += " And DealState = 2 ";//已完成
                        break;
                    case 4:
                        StrWhere += " And DealState <> 2 ";//所有未完成
                        break;

                }
            }
            string StrSql = string.Format("select BugID,PresentDate as '发布时间',Describe as '描述',PresenterName as '发布人',SendeeName as '接收人',SendDate as '接收时间',"+
                "(case DealState when 0 then '新增' when 1 then '已接收' when 2 then '完成' end) as '状态',"+
                "(case BugLevel when 0 then '常规' when 1 then '较紧急(本周内)' when 2 then '紧急(当天)' when 3 then '非常紧急(优先安排完成)' end) as '紧急程度',DealState from BugsTake {0} order by DATEPART(yy,PresentDate),DATEPART(mm,PresentDate),DATEPART(dd,PresentDate),DealState,BugLevel Desc,PresentDate", StrWhere);
            SqlConnection con = new SqlConnection(DBConInfo.strConn);
            con.Open();
            SqlCommand cmd = new SqlCommand(StrSql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "[BugsInfo]");
            con.Close();
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dr["发布时间"] = dr["发布时间"].ToDateNull().Value.ToString("yyyy-MM-dd hh:mm:ss");
                    if(dr["接收时间"].ToDateNull() != null)
                        dr["接收时间"] = dr["接收时间"].ToDateNull().Value.ToString("yyyy-MM-dd hh:mm:ss");
                }
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public string ChangeState(int BugID,int State)
        {
            //确认数据当前并非处于目标状态下
            string Sql = "select DealState,SendeeID from BugsTake where BugID = " + BugID;
            SqlConnection con = new SqlConnection(DBConInfo.strConn);
            con.Open();
            SqlCommand cmd = new SqlCommand(Sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "[BugInfo]");
            con.Close();
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                int State_Now = ds.Tables[0].Rows[0]["DealState"].ToInt();
                int SendeeID = ds.Tables[0].Rows[0]["SendeeID"].ToInt();
                if ((SendeeID == loginUser.UserID)||(SendeeID == 0) && ((State_Now == 1 || State == 0) || State_Now < State))
                {
                    //修改数据
                    if (State == 1)
                        Sql = string.Format("Update BugsTake set DealState = {0},SendeeID={1},SendeeName='{2}',SendDate=Getdate() where BugID = {3}", State,loginUser.UserID,loginUser.UserName,BugID);
                    else if (State == 2)
                        Sql = string.Format("Update BugsTake set DealState = {0} where BugID = {1}",State,BugID);
                    else
                        Sql = string.Format("Update BugsTake set DealState = {0},SendeeID=0,SendeeName='',SendDate=null where BugID = {1}",State,BugID);
                    SqlConnection con1 = new SqlConnection(DBConInfo.strConn);
                    con1.Open();
                    SqlCommand cmd1 = new SqlCommand(Sql, con1);
                    int flag = cmd1.ExecuteNonQuery();
                    con1.Close();
                    if (flag == 1)
                    {
                        return "修改成功！";
                    }
                    else
                    {
                        return "修改失败！原因是未找到需要被修改的问题数据或已被删除";
                    }
                }
                else
                {
                    return "修改失败！原因是问题已经被处理";
                }
            }
            else
            {
                return "修改失败！原因是未找到需要被修改的问题数据或已被删除";
            }
            return "";
        }
        /// <summary>
        /// 轮询更新状态
        /// </summary>
        /// <returns></returns>
        public int GetReflashChk()
        {
            string SqlStr = string.Format("select ReflashChk from UserInfos where UserID = {0}",loginUser.UserID);
            SqlConnection con = new SqlConnection(DBConInfo.strConn);
            con.Open();
            SqlCommand cmd = new SqlCommand(SqlStr, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "[BugInfo]");
            con.Close();
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                if (ds.Tables[0].Rows[0]["ReflashChk"].ToBool())
                    return 1;
                else
                    return 0;
            else
                return 0;
        }

        public void RechkReflashChk()
        {
            string Sql = string.Format("Update UserInfos set ReflashChk = 0 where UserID = {0}", loginUser.UserID);
            SqlConnection con1 = new SqlConnection(DBConInfo.strConn);
            con1.Open();
            SqlCommand cmd1 = new SqlCommand(Sql, con1);
            int flag = cmd1.ExecuteNonQuery();
            con1.Close();
        }


        public int DelBugInfo(int BugID)
        {
            //确认数据当前并非处于目标状态下
            string Sql = "select DealState,PresenterID from BugsTake where BugID = " + BugID;
            SqlConnection con = new SqlConnection(DBConInfo.strConn);
            con.Open();
            SqlCommand cmd = new SqlCommand(Sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "[BugInfo]");
            con.Close();
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                int State_Now = ds.Tables[0].Rows[0]["DealState"].ToInt();
                int PresenterID = ds.Tables[0].Rows[0]["PresenterID"].ToInt();
                if (PresenterID == loginUser.UserID && State_Now == 0)
                {
                    Sql = string.Format("Delete BugsTake  where BugID = {0}", BugID);
                    SqlConnection con1 = new SqlConnection(DBConInfo.strConn);
                    con1.Open();
                    SqlCommand cmd1 = new SqlCommand(Sql, con1);
                    int flag = cmd1.ExecuteNonQuery();
                    con1.Close();
                    if (flag > 0)
                        return 0; //保存成功
                    else
                        return 1;//数据不存在
                }
                else if (PresenterID == loginUser.UserID)
                    return 2;//数据已被接收
                else
                    return 3;//只能删除自己录入的记录
            }
            else
                return 1; //数据不存在
        }
    }
}
