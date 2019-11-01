namespace TeamToDos
{
    partial class AddBug
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
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
            this.TxtDescribe = new CCWin.SkinControl.SkinWaterTextBox();
            this.CBBLevel = new CCWin.SkinControl.SkinComboBox();
            this.BtnSubmit = new System.Windows.Forms.Button();
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
            // TxtDescribe
            // 
            this.TxtDescribe.Location = new System.Drawing.Point(35, 38);
            this.TxtDescribe.Multiline = true;
            this.TxtDescribe.Name = "TxtDescribe";
            this.TxtDescribe.Size = new System.Drawing.Size(748, 77);
            this.TxtDescribe.TabIndex = 1;
            this.TxtDescribe.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.TxtDescribe.WaterText = "请输入要提交的问题详情描述...";
            // 
            // CBBLevel
            // 
            this.CBBLevel.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CBBLevel.FormattingEnabled = true;
            this.CBBLevel.Location = new System.Drawing.Point(35, 139);
            this.CBBLevel.Name = "CBBLevel";
            this.CBBLevel.Size = new System.Drawing.Size(153, 22);
            this.CBBLevel.TabIndex = 2;
            this.CBBLevel.WaterText = "";
            // 
            // BtnSubmit
            // 
            this.BtnSubmit.Location = new System.Drawing.Point(613, 131);
            this.BtnSubmit.Name = "BtnSubmit";
            this.BtnSubmit.Size = new System.Drawing.Size(169, 29);
            this.BtnSubmit.TabIndex = 3;
            this.BtnSubmit.Text = "提交";
            this.BtnSubmit.UseVisualStyleBackColor = true;
            this.BtnSubmit.Click += new System.EventHandler(this.BtnSubmit_Click);
            // 
            // AddBug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 209);
            this.Controls.Add(this.BtnSubmit);
            this.Controls.Add(this.CBBLevel);
            this.Controls.Add(this.TxtDescribe);
            this.Name = "AddBug";
            this.Text = "AddBug";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
        private CCWin.SkinControl.SkinWaterTextBox TxtDescribe;
        private CCWin.SkinControl.SkinComboBox CBBLevel;
        private System.Windows.Forms.Button BtnSubmit;
    }
}