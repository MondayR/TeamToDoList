using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeamToDosControllers;
using TeamToDosDAL;

namespace TeamToDos
{
    public partial class FormIniList : Form
    {
        public FormIniList()
        {
            InitializeComponent();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            this.skinEngine1.SkinFile = Application.StartupPath + "//Skins/PageColor2.ssk";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.btnTestLink.Enabled = false;
            string ServerName = this.txtServer.Text;
            string Uid = this.txtUserName.Text;
            string Pwd = this.txtPwd.Text;
            string DBName = this.txtDBName.Text;
            BizController myLogin = new BizController();
            //测试数据库连通性
            string testChk = myLogin.TestDataBaseContect(ServerName,Uid,Pwd,DBName);
            MessageBox.Show(testChk);
            this.btnTestLink.Enabled = true;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            BtnSave.Enabled = false;
            if (this.txtServer.Text == "")
            {
                MessageBox.Show("服务器名称不能为空！");
                return;
            }
            if (this.txtUserName.Text == "")
            {
                MessageBox.Show("用户名不能为空！");
                return;
            }
            if (this.txtPwd.Text == "")
            {
                MessageBox.Show("登录密码不能为空！");
                return;
            }
            if (this.txtDBName.Text == "")
            {
                MessageBox.Show("数据库名称不能为空！");
                return;
            }
            string SaveSer = AESHelper.AESEncrypt(this.txtServer.Text);
            string SaveUid = AESHelper.AESEncrypt(this.txtUserName.Text);
            string SavePwd = AESHelper.AESEncrypt(this.txtPwd.Text);
            string SaveDBN = AESHelper.AESEncrypt(this.txtDBName.Text);
            try
            {
                CommentController comm = new CommentController();
                comm.IniDataBase(SaveSer, SaveUid, SavePwd, SaveDBN);
                MessageBox.Show("数据库连接初始化配置成功！");
                BtnSave.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("初始化失败!错误原因:" + ex.Message);
                BtnSave.Enabled = true;
            }
        }
    }
}
