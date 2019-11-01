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
using Common;
using TeamToDosControllers;

namespace TeamToDos
{
    public partial class AddBug : Form
    {
        public AddBug()
        {
            InitializeComponent();

            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            this.skinEngine1.SkinFile = Application.StartupPath + "//Skins/PageColor2.ssk";
            BindComboBox();
        }

        private void BindComboBox()
        {
            CBBLevel.Items.Add("常规");
            CBBLevel.Items.Add("较紧急(本周内)");
            CBBLevel.Items.Add("紧急(当天)");
            CBBLevel.Items.Add("非常紧急(优先安排完成)");
            CBBLevel.SelectedIndex = 0;
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (TxtDescribe.Text == "")
            {
                MessageBox.Show("为获取到需要保存的数据！请重新输入！");
                return;
            }
            BugInfo myBug = new BugInfo();
            myBug.Describe = TxtDescribe.Text;
            myBug.BugLevel = CBBLevel.SelectedIndex;
            myBug.PresenterID = loginUser.UserID;
            myBug.PresenterName = loginUser.UserName;
            BizController myBiz = new BizController();
            try
            {
                bool SaveFlag = myBiz.SaveBugInfo(myBug);
                if (SaveFlag)
                {
                    MessageBox.Show("保存成功！");
                    FormDataList ParentForm = (FormDataList)this.Owner;
                    ParentForm.Refresh_Window();
                    this.Close();
                }
                else {
                    MessageBox.Show("保存失败！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败！原因是："+ex.Message);
            }
        }
    }
}
