using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeamToDosEntity;
using TeamToDosControllers;
using Common;
using System.Runtime.InteropServices;

namespace TeamToDos
{
    public partial class FormDataList : Form
    {
        BizController myBiz = new BizController();
        [DllImport("User32.dll", CharSet = CharSet.Unicode, EntryPoint = "FlashWindow")]
        public static extern bool FlashWindow(
        IntPtr hWnd,     // handle to window
        bool bInvert   // flash status
        );
        public FormDataList()
        {
            InitializeComponent();

            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            this.skinEngine1.SkinFile = Application.StartupPath + "//Skins/PageColor2.ssk";
            DTBegin.Text = DateTime.Now.ToString("yyyy-MM-dd");
            DTEnd.Text = DateTime.Now.ToString("yyyy-MM-dd");
            BindComboBox();
            GetBugsInfo();
            timer1.Start();
        }

        private void BindComboBox() {
            CBState.Items.Add("全部");
            CBState.Items.Add("新增");
            CBState.Items.Add("已接收");
            CBState.Items.Add("已完成");
            CBState.Items.Add("未完成");
            CBState.SelectedIndex = 0;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            GetBugsInfo();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            AddBug addBug = new AddBug();
            addBug.StartPosition = FormStartPosition.CenterScreen;
            addBug.Owner = this;
            addBug.Show();
        }

        private void BtnReceive_Click(object sender, EventArgs e)
        {
            int index = BugsList.CurrentRow.Index;
            int BugID = BugsList.Rows[index].Cells[0].Value.ToInt();
            int BugState = BugsList.Rows[index].Cells[8].Value.ToInt();
            if (BugState != 0)
            {
                MessageBox.Show("问题已经被接收，请接收其他问题");
                Refresh_Window();
                return;
            }
            else
            {
                try
                {
                    string Erro = myBiz.ChangeState(BugID, 1);
                    MessageBox.Show(Erro);
                    Refresh_Window();
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("接收失败，原因是"+ex.Message);
                    Refresh_Window();
                    return;
                }
            }
        }

        private void BtnRet_Click(object sender, EventArgs e)
        {
            int index = BugsList.CurrentRow.Index;
            int BugID = BugsList.Rows[index].Cells[0].Value.ToInt();
            int BugState = BugsList.Rows[index].Cells[8].Value.ToInt();
            if (BugState != 1)
            {
                MessageBox.Show("退回失败！问题已完成或已被退回");
                Refresh_Window();
                return;
            }
            else
            {
                try
                {
                    string Erro = myBiz.ChangeState(BugID, 0);
                    MessageBox.Show(Erro);
                    Refresh_Window();
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("退回失败，原因是" + ex.Message);
                    Refresh_Window();
                    return;
                }
            }
        }

        private void BtnFin_Click(object sender, EventArgs e)
        {
            int index = BugsList.CurrentRow.Index;
            int BugID = BugsList.Rows[index].Cells[0].Value.ToInt();
            int BugState = BugsList.Rows[index].Cells[8].Value.ToInt();
            if (BugState != 1)
            {
                MessageBox.Show("完成失败！问题已完成或已被退回");
                Refresh_Window();
                return;
            }
            else
            {
                try
                {
                    string Erro = myBiz.ChangeState(BugID, 2);
                    MessageBox.Show(Erro);
                    Refresh_Window();
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("完成失败，原因是" + ex.Message);
                    Refresh_Window();
                    return;
                }
            }
        }
        public void Refresh_Window() {
            GetBugsInfo();
        }

        private void GetBugsInfo()
        {
            DateTime BeginDate = DateTime.Now;
            DateTime.TryParse(DTBegin.Text, out BeginDate);
            DateTime EndDate = DateTime.Now;
            DateTime.TryParse(DTEnd.Text, out EndDate);
            string PresenterName = txtReleaseMan.Text;
            string SendeeName = txtReceiveMan.Text;
            string Describe = txtDescribe.Text;
            int State = CBState.SelectedIndex;
            DataTable BugsInfo = myBiz.GetBugsInfo(BeginDate, EndDate, PresenterName, SendeeName,Describe, State) ;
            BugsList.DataSource = BugsInfo;
            if (BugsInfo != null)
            {
                BugsList.Columns[0].Visible = false;
                BugsList.Columns[8].Visible = false;
                BugsList.Columns[1].Width = 120;
                BugsList.Columns[3].Width = 100;
                BugsList.Columns[4].Width = 100;
                BugsList.Columns[5].Width = 120;
                BugsList.Columns[6].Width = 80;
                BugsList.Columns[7].Width = 100;
                BugsList.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                BugsList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
                BugsList.RowsDefaultCellStyle.WrapMode = (DataGridViewTriState.True);
                BugsList.AllowUserToAddRows = false;
            }
            myBiz.RechkReflashChk();
            loginUser.ReflashChk = myBiz.GetReflashChk();
        }

        private void FormDataList_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (loginUser.ReflashChk == 0)
            {
                loginUser.ReflashChk = myBiz.GetReflashChk();
            }
            if (loginUser.ReflashChk == 1)
            {
                FlashWindow(this.Handle, true);
                LBreflash.Text = "有数据新增！请及时刷新数据！";
            }
            else
            {
                LBreflash.Text = "";
            }
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            int index = BugsList.CurrentRow.Index;
            int BugID = BugsList.Rows[index].Cells[0].Value.ToInt();
            int BugState = BugsList.Rows[index].Cells[8].Value.ToInt();
            if (BugState != 0)
            {
                MessageBox.Show("删除失败！问题已被接收或已完成");
                Refresh_Window();
                return;
            }
            else
            {
                try
                {
                    int flag = myBiz.DelBugInfo(BugID);
                    string Msg = "";
                    switch (flag)
                    {
                        case 0:
                            Msg = "删除成功！";
                            break;
                        case 1:
                            Msg = "未查到数据或数据不存在！";
                            break;
                        case 2:
                            Msg = "数据已被接收！";
                            break;
                        case 3:
                            Msg = "只能删除自己录入的记录！";
                            break;
                    }
                    MessageBox.Show(Msg);
                    Refresh_Window();
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("删除失败！原因是"+ex.Message);
                    return;
                }
            }
        }
    }
}
