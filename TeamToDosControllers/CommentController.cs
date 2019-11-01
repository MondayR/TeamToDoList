using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TeamToDosControllers
{
    public class CommentController
    {
        public void IniDataBase(string Ser, string Uid, string Pwd, string Dbname)
        {
            SetDBInfoNodeValueToXml("server", Ser, "DataBaseSource");
            SetDBInfoNodeValueToXml("uid", Uid, "DataBaseSource");
            SetDBInfoNodeValueToXml("Pwd", Pwd, "DataBaseSource");
            SetDBInfoNodeValueToXml("database", Dbname, "DataBaseSource");
        }
        /// <summary>
        /// 根据节点名称赋值数据库配置内容
        /// </summary>
        /// <param name="NodeName"></param>
        /// <returns></returns>
        public void SetDBInfoNodeValueToXml(string NodeName, string NodeValue, string NodeType)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"..\..\..\InitConfigration.xml");
            XmlNode memberlist = xmlDoc.SelectSingleNode("InitSetting");
            XmlNodeList nodelist = memberlist.ChildNodes;
            foreach (XmlNode node in nodelist)
            {
                if (node.Name == NodeType)
                {
                    XmlElement xe = (XmlElement)node;
                    XmlNodeList node0 = xe.ChildNodes;
                    foreach (XmlNode xn0 in node0)
                    {
                        if (xn0.Name == NodeName)
                        {
                            xn0.InnerText = NodeValue;
                            break;
                        }
                    }
                }
            }
            xmlDoc.Save(@"..\..\..\InitConfigration.xml");
        }
        /// <summary>
        /// 根据节点名称获取节点内容
        /// </summary>
        /// <param name="NodeName"></param>
        /// <returns></returns>
        public string GetDBInfoNodeValueFromXml(string NodeName)
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
                if (xn1.Name == "SystemItemSource")
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
