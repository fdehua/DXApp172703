namespace DXApp172703
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.btLogin = new DevExpress.XtraEditors.SimpleButton();
            this.txtUserPwd = new DevExpress.XtraEditors.TextEdit();
            this.txtUserName = new DevExpress.XtraEditors.MRUEdit();
            this.btClose = new DevExpress.XtraEditors.SimpleButton();
            this.toggleSwitch1 = new DevExpress.XtraEditors.ToggleSwitch();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserPwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btLogin
            // 
            this.btLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btLogin.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btLogin.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btLogin.ImageOptions.Image")));
            this.btLogin.Location = new System.Drawing.Point(425, 352);
            this.btLogin.Name = "btLogin";
            this.btLogin.Size = new System.Drawing.Size(122, 58);
            this.btLogin.TabIndex = 3;
            this.btLogin.Click += new System.EventHandler(this.btLogin_Click);
            // 
            // txtUserPwd
            // 
            this.txtUserPwd.Location = new System.Drawing.Point(187, 255);
            this.txtUserPwd.Name = "txtUserPwd";
            this.txtUserPwd.Properties.PasswordChar = '*';
            this.txtUserPwd.Size = new System.Drawing.Size(136, 20);
            this.txtUserPwd.TabIndex = 2;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(187, 217);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtUserName.Size = new System.Drawing.Size(136, 20);
            this.txtUserName.TabIndex = 1;
            // 
            // btClose
            // 
            this.btClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btClose.ImageOptions.Image")));
            this.btClose.Location = new System.Drawing.Point(558, 12);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(38, 48);
            this.btClose.TabIndex = 4;
            // 
            // toggleSwitch1
            // 
            this.toggleSwitch1.Location = new System.Drawing.Point(114, 292);
            this.toggleSwitch1.Name = "toggleSwitch1";
            this.toggleSwitch1.Properties.OffText = "Off";
            this.toggleSwitch1.Properties.OnText = "On";
            this.toggleSwitch1.Size = new System.Drawing.Size(95, 25);
            this.toggleSwitch1.TabIndex = 5;
            // 
            // simpleButton1
            // 
            this.simpleButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(248, 293);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 6;
            this.simpleButton1.Text = "忘记密码";
            // 
            // loginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Stretch;
            this.BackgroundImageStore = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImageStore")));
            this.ClientSize = new System.Drawing.Size(619, 425);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.toggleSwitch1);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtUserPwd);
            this.Controls.Add(this.btLogin);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "loginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            ((System.ComponentModel.ISupportInitialize)(this.txtUserPwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btLogin;
        private DevExpress.XtraEditors.TextEdit txtUserPwd;
        private DevExpress.XtraEditors.MRUEdit txtUserName;
        private DevExpress.XtraEditors.SimpleButton btClose;
        private DevExpress.XtraEditors.ToggleSwitch toggleSwitch1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}