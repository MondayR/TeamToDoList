namespace TeamToDos
{
    partial class FormDataList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.DTBegin = new CCWin.SkinControl.SkinDateTimePicker();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.DTEnd = new CCWin.SkinControl.SkinDateTimePicker();
            this.skinLabel3 = new CCWin.SkinControl.SkinLabel();
            this.txtReleaseMan = new CCWin.SkinControl.SkinTextBox();
            this.skinLabel4 = new CCWin.SkinControl.SkinLabel();
            this.txtReceiveMan = new CCWin.SkinControl.SkinTextBox();
            this.skinLabel5 = new CCWin.SkinControl.SkinLabel();
            this.txtDescribe = new CCWin.SkinControl.SkinTextBox();
            this.CBState = new CCWin.SkinControl.SkinComboBox();
            this.BtnSearch = new CCWin.SkinControl.SkinButton();
            this.BtnReceive = new System.Windows.Forms.Button();
            this.BtnRet = new System.Windows.Forms.Button();
            this.BtnFin = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.skinLabel6 = new CCWin.SkinControl.SkinLabel();
            this.BugsList = new CCWin.SkinControl.SkinDataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.LBreflash = new System.Windows.Forms.Label();
            this.BtnDel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.BugsList)).BeginInit();
            this.SuspendLayout();
            // 
            // skinEngine1
            // 
            this.skinEngine1.@__DrawButtonFocusRectangle = true;
            this.skinEngine1.DisabledButtonTextColor = System.Drawing.Color.Gray;
            this.skinEngine1.DisabledMenuFontColor = System.Drawing.SystemColors.GrayText;
            this.skinEngine1.InactiveCaptionColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.skinEngine1.SerialNumber = "";
            this.skinEngine1.SkinFile = null;
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(18, 32);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(32, 17);
            this.skinLabel1.TabIndex = 1;
            this.skinLabel1.Text = "日期";
            // 
            // DTBegin
            // 
            this.DTBegin.BackColor = System.Drawing.Color.Transparent;
            this.DTBegin.DropDownHeight = 180;
            this.DTBegin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.DTBegin.DropDownWidth = 120;
            this.DTBegin.font = new System.Drawing.Font("微软雅黑", 9F);
            this.DTBegin.Items = null;
            this.DTBegin.Location = new System.Drawing.Point(47, 27);
            this.DTBegin.Name = "DTBegin";
            this.DTBegin.Size = new System.Drawing.Size(114, 22);
            this.DTBegin.TabIndex = 2;
            this.DTBegin.text = "";
            // 
            // skinLabel2
            // 
            this.skinLabel2.AutoSize = true;
            this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel2.BorderColor = System.Drawing.Color.White;
            this.skinLabel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel2.Location = new System.Drawing.Point(160, 27);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(13, 17);
            this.skinLabel2.TabIndex = 3;
            this.skinLabel2.Text = "-";
            // 
            // DTEnd
            // 
            this.DTEnd.BackColor = System.Drawing.Color.Transparent;
            this.DTEnd.DropDownHeight = 180;
            this.DTEnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.DTEnd.DropDownWidth = 120;
            this.DTEnd.font = new System.Drawing.Font("微软雅黑", 9F);
            this.DTEnd.Items = null;
            this.DTEnd.Location = new System.Drawing.Point(172, 27);
            this.DTEnd.Name = "DTEnd";
            this.DTEnd.Size = new System.Drawing.Size(114, 22);
            this.DTEnd.TabIndex = 4;
            this.DTEnd.text = "";
            // 
            // skinLabel3
            // 
            this.skinLabel3.AutoSize = true;
            this.skinLabel3.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel3.BorderColor = System.Drawing.Color.White;
            this.skinLabel3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel3.Location = new System.Drawing.Point(300, 30);
            this.skinLabel3.Name = "skinLabel3";
            this.skinLabel3.Size = new System.Drawing.Size(44, 17);
            this.skinLabel3.TabIndex = 5;
            this.skinLabel3.Text = "发布人";
            // 
            // txtReleaseMan
            // 
            this.txtReleaseMan.BackColor = System.Drawing.Color.Transparent;
            this.txtReleaseMan.DownBack = null;
            this.txtReleaseMan.Icon = null;
            this.txtReleaseMan.IconIsButton = false;
            this.txtReleaseMan.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtReleaseMan.IsPasswordChat = '\0';
            this.txtReleaseMan.IsSystemPasswordChar = false;
            this.txtReleaseMan.Lines = new string[0];
            this.txtReleaseMan.Location = new System.Drawing.Point(340, 21);
            this.txtReleaseMan.Margin = new System.Windows.Forms.Padding(0);
            this.txtReleaseMan.MaxLength = 32767;
            this.txtReleaseMan.MinimumSize = new System.Drawing.Size(28, 28);
            this.txtReleaseMan.MouseBack = null;
            this.txtReleaseMan.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtReleaseMan.Multiline = false;
            this.txtReleaseMan.Name = "txtReleaseMan";
            this.txtReleaseMan.NormlBack = null;
            this.txtReleaseMan.Padding = new System.Windows.Forms.Padding(5);
            this.txtReleaseMan.ReadOnly = false;
            this.txtReleaseMan.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtReleaseMan.Size = new System.Drawing.Size(156, 28);
            // 
            // 
            // 
            this.txtReleaseMan.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtReleaseMan.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReleaseMan.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txtReleaseMan.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.txtReleaseMan.SkinTxt.Name = "BaseText";
            this.txtReleaseMan.SkinTxt.Size = new System.Drawing.Size(146, 18);
            this.txtReleaseMan.SkinTxt.TabIndex = 0;
            this.txtReleaseMan.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtReleaseMan.SkinTxt.WaterText = "";
            this.txtReleaseMan.TabIndex = 6;
            this.txtReleaseMan.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtReleaseMan.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtReleaseMan.WaterText = "";
            this.txtReleaseMan.WordWrap = true;
            // 
            // skinLabel4
            // 
            this.skinLabel4.AutoSize = true;
            this.skinLabel4.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel4.BorderColor = System.Drawing.Color.White;
            this.skinLabel4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel4.Location = new System.Drawing.Point(502, 32);
            this.skinLabel4.Name = "skinLabel4";
            this.skinLabel4.Size = new System.Drawing.Size(44, 17);
            this.skinLabel4.TabIndex = 7;
            this.skinLabel4.Text = "接收人";
            // 
            // txtReceiveMan
            // 
            this.txtReceiveMan.BackColor = System.Drawing.Color.Transparent;
            this.txtReceiveMan.DownBack = null;
            this.txtReceiveMan.Icon = null;
            this.txtReceiveMan.IconIsButton = false;
            this.txtReceiveMan.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtReceiveMan.IsPasswordChat = '\0';
            this.txtReceiveMan.IsSystemPasswordChar = false;
            this.txtReceiveMan.Lines = new string[0];
            this.txtReceiveMan.Location = new System.Drawing.Point(547, 21);
            this.txtReceiveMan.Margin = new System.Windows.Forms.Padding(0);
            this.txtReceiveMan.MaxLength = 32767;
            this.txtReceiveMan.MinimumSize = new System.Drawing.Size(28, 28);
            this.txtReceiveMan.MouseBack = null;
            this.txtReceiveMan.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtReceiveMan.Multiline = false;
            this.txtReceiveMan.Name = "txtReceiveMan";
            this.txtReceiveMan.NormlBack = null;
            this.txtReceiveMan.Padding = new System.Windows.Forms.Padding(5);
            this.txtReceiveMan.ReadOnly = false;
            this.txtReceiveMan.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtReceiveMan.Size = new System.Drawing.Size(171, 28);
            // 
            // 
            // 
            this.txtReceiveMan.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtReceiveMan.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReceiveMan.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txtReceiveMan.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.txtReceiveMan.SkinTxt.Name = "BaseText";
            this.txtReceiveMan.SkinTxt.Size = new System.Drawing.Size(161, 18);
            this.txtReceiveMan.SkinTxt.TabIndex = 0;
            this.txtReceiveMan.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtReceiveMan.SkinTxt.WaterText = "";
            this.txtReceiveMan.TabIndex = 8;
            this.txtReceiveMan.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtReceiveMan.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtReceiveMan.WaterText = "";
            this.txtReceiveMan.WordWrap = true;
            // 
            // skinLabel5
            // 
            this.skinLabel5.AutoSize = true;
            this.skinLabel5.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel5.BorderColor = System.Drawing.Color.White;
            this.skinLabel5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel5.Location = new System.Drawing.Point(19, 82);
            this.skinLabel5.Name = "skinLabel5";
            this.skinLabel5.Size = new System.Drawing.Size(32, 17);
            this.skinLabel5.TabIndex = 9;
            this.skinLabel5.Text = "描述";
            // 
            // txtDescribe
            // 
            this.txtDescribe.BackColor = System.Drawing.Color.Transparent;
            this.txtDescribe.DownBack = null;
            this.txtDescribe.Icon = null;
            this.txtDescribe.IconIsButton = false;
            this.txtDescribe.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtDescribe.IsPasswordChat = '\0';
            this.txtDescribe.IsSystemPasswordChar = false;
            this.txtDescribe.Lines = new string[0];
            this.txtDescribe.Location = new System.Drawing.Point(47, 72);
            this.txtDescribe.Margin = new System.Windows.Forms.Padding(0);
            this.txtDescribe.MaxLength = 32767;
            this.txtDescribe.MinimumSize = new System.Drawing.Size(28, 28);
            this.txtDescribe.MouseBack = null;
            this.txtDescribe.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtDescribe.Multiline = false;
            this.txtDescribe.Name = "txtDescribe";
            this.txtDescribe.NormlBack = null;
            this.txtDescribe.Padding = new System.Windows.Forms.Padding(5);
            this.txtDescribe.ReadOnly = false;
            this.txtDescribe.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDescribe.Size = new System.Drawing.Size(239, 28);
            // 
            // 
            // 
            this.txtDescribe.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescribe.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescribe.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txtDescribe.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.txtDescribe.SkinTxt.Name = "BaseText";
            this.txtDescribe.SkinTxt.Size = new System.Drawing.Size(229, 18);
            this.txtDescribe.SkinTxt.TabIndex = 0;
            this.txtDescribe.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtDescribe.SkinTxt.WaterText = "";
            this.txtDescribe.TabIndex = 10;
            this.txtDescribe.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDescribe.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtDescribe.WaterText = "";
            this.txtDescribe.WordWrap = true;
            // 
            // CBState
            // 
            this.CBState.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CBState.FormattingEnabled = true;
            this.CBState.Location = new System.Drawing.Point(340, 75);
            this.CBState.Name = "CBState";
            this.CBState.Size = new System.Drawing.Size(156, 22);
            this.CBState.TabIndex = 11;
            this.CBState.WaterText = "";
            // 
            // BtnSearch
            // 
            this.BtnSearch.BackColor = System.Drawing.Color.Transparent;
            this.BtnSearch.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.BtnSearch.DownBack = null;
            this.BtnSearch.Location = new System.Drawing.Point(547, 74);
            this.BtnSearch.MouseBack = null;
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.NormlBack = null;
            this.BtnSearch.Size = new System.Drawing.Size(171, 23);
            this.BtnSearch.TabIndex = 12;
            this.BtnSearch.Text = "查询";
            this.BtnSearch.UseVisualStyleBackColor = false;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // BtnReceive
            // 
            this.BtnReceive.Location = new System.Drawing.Point(1107, 145);
            this.BtnReceive.Name = "BtnReceive";
            this.BtnReceive.Size = new System.Drawing.Size(117, 51);
            this.BtnReceive.TabIndex = 14;
            this.BtnReceive.Text = "接收";
            this.BtnReceive.UseVisualStyleBackColor = true;
            this.BtnReceive.Click += new System.EventHandler(this.BtnReceive_Click);
            // 
            // BtnRet
            // 
            this.BtnRet.Location = new System.Drawing.Point(1107, 226);
            this.BtnRet.Name = "BtnRet";
            this.BtnRet.Size = new System.Drawing.Size(117, 51);
            this.BtnRet.TabIndex = 15;
            this.BtnRet.Text = "退回";
            this.BtnRet.UseVisualStyleBackColor = true;
            this.BtnRet.Click += new System.EventHandler(this.BtnRet_Click);
            // 
            // BtnFin
            // 
            this.BtnFin.Location = new System.Drawing.Point(1107, 307);
            this.BtnFin.Name = "BtnFin";
            this.BtnFin.Size = new System.Drawing.Size(117, 47);
            this.BtnFin.TabIndex = 16;
            this.BtnFin.Text = "完成";
            this.BtnFin.UseVisualStyleBackColor = true;
            this.BtnFin.Click += new System.EventHandler(this.BtnFin_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(808, 19);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(128, 78);
            this.BtnAdd.TabIndex = 17;
            this.BtnAdd.Text = "新增";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // skinLabel6
            // 
            this.skinLabel6.AutoSize = true;
            this.skinLabel6.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel6.BorderColor = System.Drawing.Color.White;
            this.skinLabel6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel6.Location = new System.Drawing.Point(305, 80);
            this.skinLabel6.Name = "skinLabel6";
            this.skinLabel6.Size = new System.Drawing.Size(32, 17);
            this.skinLabel6.TabIndex = 18;
            this.skinLabel6.Text = "状态";
            // 
            // BugsList
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.BugsList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.BugsList.BackgroundColor = System.Drawing.SystemColors.Window;
            this.BugsList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.BugsList.ColumnFont = null;
            this.BugsList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.BugsList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.BugsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BugsList.ColumnSelectForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(188)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.BugsList.DefaultCellStyle = dataGridViewCellStyle3;
            this.BugsList.EnableHeadersVisualStyles = false;
            this.BugsList.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BugsList.HeadFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BugsList.HeadSelectForeColor = System.Drawing.SystemColors.HighlightText;
            this.BugsList.Location = new System.Drawing.Point(26, 118);
            this.BugsList.Name = "BugsList";
            this.BugsList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.BugsList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.BugsList.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.BugsList.RowTemplate.Height = 23;
            this.BugsList.Size = new System.Drawing.Size(1046, 350);
            this.BugsList.TabIndex = 19;
            this.BugsList.TitleBack = null;
            this.BugsList.TitleBackColorBegin = System.Drawing.Color.White;
            this.BugsList.TitleBackColorEnd = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(196)))), ((int)(((byte)(242)))));
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // LBreflash
            // 
            this.LBreflash.AutoSize = true;
            this.LBreflash.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LBreflash.ForeColor = System.Drawing.Color.Coral;
            this.LBreflash.Location = new System.Drawing.Point(942, 40);
            this.LBreflash.Name = "LBreflash";
            this.LBreflash.Size = new System.Drawing.Size(0, 31);
            this.LBreflash.TabIndex = 20;
            // 
            // BtnDel
            // 
            this.BtnDel.Location = new System.Drawing.Point(1107, 421);
            this.BtnDel.Name = "BtnDel";
            this.BtnDel.Size = new System.Drawing.Size(117, 47);
            this.BtnDel.TabIndex = 21;
            this.BtnDel.Text = "删除";
            this.BtnDel.UseVisualStyleBackColor = true;
            this.BtnDel.Click += new System.EventHandler(this.BtnDel_Click);
            // 
            // FormDataList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1274, 499);
            this.Controls.Add(this.BtnDel);
            this.Controls.Add(this.LBreflash);
            this.Controls.Add(this.BugsList);
            this.Controls.Add(this.skinLabel6);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.BtnFin);
            this.Controls.Add(this.BtnRet);
            this.Controls.Add(this.BtnReceive);
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.CBState);
            this.Controls.Add(this.txtDescribe);
            this.Controls.Add(this.skinLabel5);
            this.Controls.Add(this.txtReceiveMan);
            this.Controls.Add(this.skinLabel4);
            this.Controls.Add(this.txtReleaseMan);
            this.Controls.Add(this.skinLabel3);
            this.Controls.Add(this.DTEnd);
            this.Controls.Add(this.skinLabel2);
            this.Controls.Add(this.DTBegin);
            this.Controls.Add(this.skinLabel1);
            this.Name = "FormDataList";
            this.Text = "FormDataList";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDataList_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.BugsList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private CCWin.SkinControl.SkinDateTimePicker DTBegin;
        private CCWin.SkinControl.SkinLabel skinLabel2;
        private CCWin.SkinControl.SkinDateTimePicker DTEnd;
        private CCWin.SkinControl.SkinLabel skinLabel3;
        private CCWin.SkinControl.SkinTextBox txtReleaseMan;
        private CCWin.SkinControl.SkinLabel skinLabel4;
        private CCWin.SkinControl.SkinTextBox txtReceiveMan;
        private CCWin.SkinControl.SkinLabel skinLabel5;
        private CCWin.SkinControl.SkinTextBox txtDescribe;
        private CCWin.SkinControl.SkinComboBox CBState;
        private CCWin.SkinControl.SkinButton BtnSearch;
        private System.Windows.Forms.Button BtnReceive;
        private System.Windows.Forms.Button BtnRet;
        private System.Windows.Forms.Button BtnFin;
        private System.Windows.Forms.Button BtnAdd;
        private CCWin.SkinControl.SkinLabel skinLabel6;
        private CCWin.SkinControl.SkinDataGridView BugsList;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label LBreflash;
        private System.Windows.Forms.Button BtnDel;
    }
}