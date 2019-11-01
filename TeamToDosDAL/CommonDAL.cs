using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TeamToDosDAL
{
    class CommonDAL
    {

        /// <summary>
        /// 初始化数据库连接字符串
        /// </summary>
        /// <returns></returns>
        public static bool InitDataBase()
        {
            try
            {
                string UserName = AESHelper.AESDecrypt(GetDBInfoNodeValueFromXml("uid"));
                string Pwd = AESHelper.AESDecrypt(GetDBInfoNodeValueFromXml("Pwd"));
                string Server = AESHelper.AESDecrypt(GetDBInfoNodeValueFromXml("server"));
                string DBName = AESHelper.AESDecrypt(GetDBInfoNodeValueFromXml("database"));
                DBConInfo.strConn = string.Format(DBConInfo.strConn, Server, UserName, Pwd, DBName);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 根据节点名称获取金蝶数据库配置内容
        /// </summary>
        /// <param name="NodeName"></param>
        /// <returns></returns>
        public static string GetDBInfoNodeValueFromXml(string NodeName)
        {
            XmlDocument doc = new XmlDocument();
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;//忽略文档里面的注释
            XmlReader reader = XmlReader.Create(@"..\..\..\InitConfigration.xml", settings);
            doc.Load(reader);
            // 得到根节点bookstore
            XmlNode xn = doc.SelectSingleNode("InitSetting");
            // 得到根节点的所有子节点
            XmlNodeList xnl = xn.ChildNodes;
            string Values = "";
            foreach (XmlNode xn1 in xnl)
            {
                if (xn1.Name == "DataBaseSource")
                {
                    XmlElement xe = (XmlElement)xn1;
                    XmlNodeList xnl0 = xe.ChildNodes;
                    foreach (XmlNode xn2 in xnl0)
                    {
                        if (xn2.Name == NodeName)
                        {
                            Values += xn2.InnerText;
                        }
                    }
                }
            }
            reader.Close();
            return Values;
        }
    }
}
