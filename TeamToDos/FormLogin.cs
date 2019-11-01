using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using TeamToDosControllers;

namespace TeamToDos
{
    public partial class FormLogin : Form
    {
        bool OpenLink = false;              //是否显示初始化连接
        public FormLogin()
        {
            InitializeComponent();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            this.skinEngine1.SkinFile = Application.StartupPath + "//Skins/PageColor2.ssk";
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "") { 
                MessageBox.Show("请输入用户名！");
                return;
            }
            if (txtUserName.Text == "recode" && txtPassword.Text == "")
            {
                this.BtnLink.Show();
                return;
            }
            if (txtPassword.Text == "")
            {
                MessageBox.Show("请输入密码！");
                return;
            }
            string UserName = txtUserName.Text;
            byte[] btPwd = Encoding.Default.GetBytes(this.txtPassword.Text.Trim());
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] outPutPwd = md5.ComputeHash(btPwd);
            string PwdResult = BitConverter.ToString(outPutPwd).Replace("-","");
            try {
                BizController myLogin = new BizController();
                if (myLogin.Login(UserName, PwdResult))
                {
                    MessageBox.Show("登录成功！");
                    FormDataList ini = new FormDataList();
                    ini.StartPosition = FormStartPosition.CenterScreen;
                    ini.Owner = this;
                    ini.Show();
                    this.Hide();
                }
                else
                { 
                    MessageBox.Show("登录失败！请重试！");
                    this.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("登录错误,错误原因：" + ex.Message);
                this.Refresh();
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            this.BtnLink.Hide();
        }

        private void BtnLink_Click(object sender, EventArgs e)
        {
            FormIniList ini = new FormIniList();
            ini.StartPosition = FormStartPosition.CenterScreen;
            ini.Show();
        }
    }
}
