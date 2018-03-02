namespace MyQQ
{
    partial class RegisterForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            this.grpBaseInfo = new System.Windows.Forms.GroupBox();
            this.txtRepUserPass = new System.Windows.Forms.TextBox();
            this.txtUserPass = new System.Windows.Forms.TextBox();
            this.lblLoginPwdAgain = new System.Windows.Forms.Label();
            this.lblLoginPwd = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.panGender = new System.Windows.Forms.Panel();
            this.rdoWomen = new System.Windows.Forms.RadioButton();
            this.rdoMan = new System.Windows.Forms.RadioButton();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.txtNickName = new System.Windows.Forms.TextBox();
            this.lblAge = new System.Windows.Forms.Label();
            this.lblSex = new System.Windows.Forms.Label();
            this.lblNickName = new System.Windows.Forms.Label();
            this.grpDetails = new System.Windows.Forms.GroupBox();
            this.cboBlood = new System.Windows.Forms.ComboBox();
            this.cboConste = new System.Windows.Forms.ComboBox();
            this.lblBloodType = new System.Windows.Forms.Label();
            this.lblStar = new System.Windows.Forms.Label();
            this.btnRegist = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.grpBaseInfo.SuspendLayout();
            this.panGender.SuspendLayout();
            this.grpDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBaseInfo
            // 
            this.grpBaseInfo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.grpBaseInfo.BackColor = System.Drawing.Color.Transparent;
            this.grpBaseInfo.Controls.Add(this.txtRepUserPass);
            this.grpBaseInfo.Controls.Add(this.txtUserPass);
            this.grpBaseInfo.Controls.Add(this.lblLoginPwdAgain);
            this.grpBaseInfo.Controls.Add(this.lblLoginPwd);
            this.grpBaseInfo.Controls.Add(this.txtUserName);
            this.grpBaseInfo.Controls.Add(this.lblName);
            this.grpBaseInfo.Controls.Add(this.panGender);
            this.grpBaseInfo.Controls.Add(this.txtAge);
            this.grpBaseInfo.Controls.Add(this.txtNickName);
            this.grpBaseInfo.Controls.Add(this.lblAge);
            this.grpBaseInfo.Controls.Add(this.lblSex);
            this.grpBaseInfo.Controls.Add(this.lblNickName);
            this.grpBaseInfo.Location = new System.Drawing.Point(114, 12);
            this.grpBaseInfo.Name = "grpBaseInfo";
            this.grpBaseInfo.Size = new System.Drawing.Size(259, 201);
            this.grpBaseInfo.TabIndex = 0;
            this.grpBaseInfo.TabStop = false;
            this.grpBaseInfo.Text = "注册基本资料";
            // 
            // txtRepUserPass
            // 
            this.txtRepUserPass.Location = new System.Drawing.Point(82, 89);
            this.txtRepUserPass.Name = "txtRepUserPass";
            this.txtRepUserPass.PasswordChar = '*';
            this.txtRepUserPass.Size = new System.Drawing.Size(142, 21);
            this.txtRepUserPass.TabIndex = 17;
            // 
            // txtUserPass
            // 
            this.txtUserPass.Location = new System.Drawing.Point(82, 61);
            this.txtUserPass.Name = "txtUserPass";
            this.txtUserPass.PasswordChar = '*';
            this.txtUserPass.Size = new System.Drawing.Size(142, 21);
            this.txtUserPass.TabIndex = 16;
            // 
            // lblLoginPwdAgain
            // 
            this.lblLoginPwdAgain.AutoSize = true;
            this.lblLoginPwdAgain.Location = new System.Drawing.Point(23, 93);
            this.lblLoginPwdAgain.Name = "lblLoginPwdAgain";
            this.lblLoginPwdAgain.Size = new System.Drawing.Size(53, 12);
            this.lblLoginPwdAgain.TabIndex = 15;
            this.lblLoginPwdAgain.Text = "重复密码";
            // 
            // lblLoginPwd
            // 
            this.lblLoginPwd.AutoSize = true;
            this.lblLoginPwd.Location = new System.Drawing.Point(47, 65);
            this.lblLoginPwd.Name = "lblLoginPwd";
            this.lblLoginPwd.Size = new System.Drawing.Size(29, 12);
            this.lblLoginPwd.TabIndex = 14;
            this.lblLoginPwd.Text = "密码";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(82, 30);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(142, 21);
            this.txtUserName.TabIndex = 13;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(34, 34);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 12);
            this.lblName.TabIndex = 12;
            this.lblName.Text = "登录名";
            // 
            // panGender
            // 
            this.panGender.Controls.Add(this.rdoWomen);
            this.panGender.Controls.Add(this.rdoMan);
            this.panGender.Location = new System.Drawing.Point(82, 171);
            this.panGender.Name = "panGender";
            this.panGender.Size = new System.Drawing.Size(142, 24);
            this.panGender.TabIndex = 7;
            // 
            // rdoWomen
            // 
            this.rdoWomen.AutoSize = true;
            this.rdoWomen.Location = new System.Drawing.Point(55, 5);
            this.rdoWomen.Name = "rdoWomen";
            this.rdoWomen.Size = new System.Drawing.Size(35, 16);
            this.rdoWomen.TabIndex = 1;
            this.rdoWomen.TabStop = true;
            this.rdoWomen.Text = "女";
            this.rdoWomen.UseVisualStyleBackColor = true;
            // 
            // rdoMan
            // 
            this.rdoMan.AutoSize = true;
            this.rdoMan.Location = new System.Drawing.Point(4, 4);
            this.rdoMan.Name = "rdoMan";
            this.rdoMan.Size = new System.Drawing.Size(35, 16);
            this.rdoMan.TabIndex = 0;
            this.rdoMan.TabStop = true;
            this.rdoMan.Text = "男";
            this.rdoMan.UseVisualStyleBackColor = true;
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(82, 146);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(42, 21);
            this.txtAge.TabIndex = 6;
            // 
            // txtNickName
            // 
            this.txtNickName.Location = new System.Drawing.Point(82, 116);
            this.txtNickName.Name = "txtNickName";
            this.txtNickName.Size = new System.Drawing.Size(142, 21);
            this.txtNickName.TabIndex = 5;
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(47, 150);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(29, 12);
            this.lblAge.TabIndex = 4;
            this.lblAge.Text = "年龄";
            // 
            // lblSex
            // 
            this.lblSex.AutoSize = true;
            this.lblSex.Location = new System.Drawing.Point(47, 177);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(29, 12);
            this.lblSex.TabIndex = 1;
            this.lblSex.Text = "性别";
            // 
            // lblNickName
            // 
            this.lblNickName.AutoSize = true;
            this.lblNickName.Location = new System.Drawing.Point(47, 120);
            this.lblNickName.Name = "lblNickName";
            this.lblNickName.Size = new System.Drawing.Size(29, 12);
            this.lblNickName.TabIndex = 0;
            this.lblNickName.Text = "昵称";
            // 
            // grpDetails
            // 
            this.grpDetails.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.grpDetails.BackColor = System.Drawing.Color.Transparent;
            this.grpDetails.Controls.Add(this.cboBlood);
            this.grpDetails.Controls.Add(this.cboConste);
            this.grpDetails.Controls.Add(this.lblBloodType);
            this.grpDetails.Controls.Add(this.lblStar);
            this.grpDetails.Location = new System.Drawing.Point(114, 237);
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.Size = new System.Drawing.Size(259, 87);
            this.grpDetails.TabIndex = 1;
            this.grpDetails.TabStop = false;
            this.grpDetails.Text = "选填详细资料";
            // 
            // cboBlood
            // 
            this.cboBlood.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBlood.FormattingEnabled = true;
            this.cboBlood.Items.AddRange(new object[] {
            "A",
            "B",
            "O",
            "AB",
            "其它"});
            this.cboBlood.Location = new System.Drawing.Point(82, 58);
            this.cboBlood.Name = "cboBlood";
            this.cboBlood.Size = new System.Drawing.Size(142, 20);
            this.cboBlood.TabIndex = 7;
            // 
            // cboConste
            // 
            this.cboConste.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboConste.FormattingEnabled = true;
            this.cboConste.Items.AddRange(new object[] {
            "白羊座",
            "金牛座",
            "双子座",
            "巨蟹座",
            "狮子座",
            "处女座",
            "天秤座",
            "天蝎座",
            "射手座",
            "摩羯座",
            "水瓶座",
            "双鱼座",
            "其它"});
            this.cboConste.Location = new System.Drawing.Point(82, 29);
            this.cboConste.Name = "cboConste";
            this.cboConste.Size = new System.Drawing.Size(142, 20);
            this.cboConste.TabIndex = 6;
            // 
            // lblBloodType
            // 
            this.lblBloodType.AutoSize = true;
            this.lblBloodType.Location = new System.Drawing.Point(47, 61);
            this.lblBloodType.Name = "lblBloodType";
            this.lblBloodType.Size = new System.Drawing.Size(29, 12);
            this.lblBloodType.TabIndex = 2;
            this.lblBloodType.Text = "血型";
            // 
            // lblStar
            // 
            this.lblStar.AutoSize = true;
            this.lblStar.Location = new System.Drawing.Point(47, 33);
            this.lblStar.Name = "lblStar";
            this.lblStar.Size = new System.Drawing.Size(29, 12);
            this.lblStar.TabIndex = 1;
            this.lblStar.Text = "星座";
            // 
            // btnRegist
            // 
            this.btnRegist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegist.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnRegist.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRegist.BackgroundImage")));
            this.btnRegist.Location = new System.Drawing.Point(234, 330);
            this.btnRegist.Name = "btnRegist";
            this.btnRegist.Size = new System.Drawing.Size(63, 23);
            this.btnRegist.TabIndex = 2;
            this.btnRegist.Text = "注册";
            this.btnRegist.UseVisualStyleBackColor = false;
            this.btnRegist.Click += new System.EventHandler(this.btnRegist_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.BackgroundImage")));
            this.btnCancel.Location = new System.Drawing.Point(303, 330);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(12, 12);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(95, 310);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picLogo.TabIndex = 4;
            this.picLogo.TabStop = false;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(386, 362);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRegist);
            this.Controls.Add(this.grpDetails);
            this.Controls.Add(this.grpBaseInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "申请号码";
            this.Load += new System.EventHandler(this.ApplyForm_Load);
            this.grpBaseInfo.ResumeLayout(false);
            this.grpBaseInfo.PerformLayout();
            this.panGender.ResumeLayout(false);
            this.panGender.PerformLayout();
            this.grpDetails.ResumeLayout(false);
            this.grpDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBaseInfo;
        private System.Windows.Forms.GroupBox grpDetails;
        private System.Windows.Forms.Label lblStar;
        private System.Windows.Forms.Label lblBloodType;
        private System.Windows.Forms.Button btnRegist;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cboConste;
        private System.Windows.Forms.ComboBox cboBlood;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtRepUserPass;
        private System.Windows.Forms.TextBox txtUserPass;
        private System.Windows.Forms.Label lblLoginPwdAgain;
        private System.Windows.Forms.Label lblLoginPwd;
        private System.Windows.Forms.Panel panGender;
        private System.Windows.Forms.RadioButton rdoWomen;
        private System.Windows.Forms.RadioButton rdoMan;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.TextBox txtNickName;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.Label lblNickName;
    }
}