using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamToDosEntity
{
    public class BugInfo
    {
        private string _describe = "";
        private int _bugLevel = 0;
        private int _presenterID = 0;
        private string _presenterName = "";
        private DateTime _presentDate = DateTime.Now;
        private int _sendeeID = 0;
        private string _sendeeName = "";
        private DateTime _sendeeDate = DateTime.Now;
        private int _dealState = 0;
        /// <summary>
        /// 主键ID
        /// </summary>
        public int BugID
        {
            get; set;
        }
        /// <summary>
        /// 问题描述
        /// </summary>
        public string Describe
        {
            get { return _describe; }
            set { _describe = value; }
        }
        /// <summary>
        /// 问题紧急程度
        /// </summary>
        public int BugLevel
        {
            get { return _bugLevel; }
            set { _bugLevel = value; }
        }
        /// <summary>
        /// 提交人ID
        /// </summary>
        public int PresenterID
        {
            get { return _presenterID;}
            set { _presenterID = value; }
        }
        /// <summary>
        /// 提交人名称
        /// </summary>
        public string PresenterName
        {
            get { return _presenterName;}
            set { _presenterName = value; }
        }
        /// <summary>
        /// 提交时间
        /// </summary>
        public DateTime PresentDate
        {
            get { return _presentDate; }
            set { _presentDate = value; }
        }
        /// <summary>
        /// 接收人ID
        /// </summary>
        public int SendeeID
        {
            get { return _sendeeID; }
            set { _sendeeID = value; }
        }
        /// <summary>
        /// 接收人名称
        /// </summary>
        public string SendeeName
        {
            get { return _sendeeName; }
            set { _sendeeName = value; }
        }
        /// <summary>
        /// 接收时间
        /// </summary>
        public DateTime SendDate
        {
            get { return _sendeeDate; }
            set { _sendeeDate = value; }
        }
        /// <summary>
        /// 问题处理状态
        /// </summary>
        public int DealState
        {
            get { return _dealState; }
            set { _dealState = value; }
        }
    }
}
