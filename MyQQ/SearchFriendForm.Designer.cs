namespace MyQQ
{
    partial class SearchFriendForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchFriendForm));
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.btn4 = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.chLoginId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chNickName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAge = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tpBaseSearch = new System.Windows.Forms.TabPage();
            this.pnlBaseCondition = new System.Windows.Forms.Panel();
            this.pnlBaseResult = new System.Windows.Forms.Panel();
            this.dgvBasicResult = new System.Windows.Forms.DataGridView();
            this.picBaseResult = new System.Windows.Forms.PictureBox();
            this.lblBaseResult = new System.Windows.Forms.Label();
            this.grpBaseCondition = new System.Windows.Forms.GroupBox();
            this.txtNickName = new System.Windows.Forms.TextBox();
            this.lblNickName = new System.Windows.Forms.Label();
            this.picBaseCondition = new System.Windows.Forms.PictureBox();
            this.lblBaseCondition = new System.Windows.Forms.Label();
            this.tabSearch = new System.Windows.Forms.TabControl();
            this.btn1 = new System.Windows.Forms.Button();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nickName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.tpBaseSearch.SuspendLayout();
            this.pnlBaseCondition.SuspendLayout();
            this.pnlBaseResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBasicResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBaseResult)).BeginInit();
            this.grpBaseCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBaseCondition)).BeginInit();
            this.tabSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(10, 10);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(100, 215);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // btn4
            // 
            this.btn4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn4.BackgroundImage")));
            this.btn4.Location = new System.Drawing.Point(400, 232);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(71, 24);
            this.btn4.TabIndex = 2;
            this.btn4.Text = "关闭";
            this.btn4.UseVisualStyleBackColor = true;
            this.btn4.Click += new System.EventHandler(this.btn4_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            this.btnSearch.Location = new System.Drawing.Point(323, 232);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(71, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "查找";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btn3
            // 
            this.btn3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn3.BackgroundImage")));
            this.btn3.Location = new System.Drawing.Point(323, 232);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(71, 24);
            this.btn3.TabIndex = 4;
            this.btn3.Text = "加为好友";
            this.btn3.UseVisualStyleBackColor = true;
            this.btn3.Visible = false;
            this.btn3.Click += new System.EventHandler(this.btn3_Click);
            // 
            // btn2
            // 
            this.btn2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn2.BackgroundImage")));
            this.btn2.Location = new System.Drawing.Point(246, 232);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(71, 24);
            this.btn2.TabIndex = 5;
            this.btn2.Text = "上一步";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Visible = false;
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            // 
            // chLoginId
            // 
            this.chLoginId.Text = "MyQQ号码";
            this.chLoginId.Width = 80;
            // 
            // chNickName
            // 
            this.chNickName.Text = "MyQQ昵称";
            this.chNickName.Width = 80;
            // 
            // chAge
            // 
            this.chAge.Text = "年龄";
            this.chAge.Width = 80;
            // 
            // chSex
            // 
            this.chSex.Text = "性别";
            this.chSex.Width = 80;
            // 
            // tpBaseSearch
            // 
            this.tpBaseSearch.BackColor = System.Drawing.Color.White;
            this.tpBaseSearch.Controls.Add(this.pnlBaseCondition);
            this.tpBaseSearch.ForeColor = System.Drawing.Color.Black;
            this.tpBaseSearch.Location = new System.Drawing.Point(4, 22);
            this.tpBaseSearch.Name = "tpBaseSearch";
            this.tpBaseSearch.Padding = new System.Windows.Forms.Padding(3);
            this.tpBaseSearch.Size = new System.Drawing.Size(347, 190);
            this.tpBaseSearch.TabIndex = 0;
            this.tpBaseSearch.Text = "好友查找";
            // 
            // pnlBaseCondition
            // 
            this.pnlBaseCondition.Controls.Add(this.pnlBaseResult);
            this.pnlBaseCondition.Controls.Add(this.grpBaseCondition);
            this.pnlBaseCondition.Controls.Add(this.picBaseCondition);
            this.pnlBaseCondition.Controls.Add(this.lblBaseCondition);
            this.pnlBaseCondition.Location = new System.Drawing.Point(0, 0);
            this.pnlBaseCondition.Name = "pnlBaseCondition";
            this.pnlBaseCondition.Size = new System.Drawing.Size(347, 193);
            this.pnlBaseCondition.TabIndex = 4;
            // 
            // pnlBaseResult
            // 
            this.pnlBaseResult.Controls.Add(this.dgvBasicResult);
            this.pnlBaseResult.Controls.Add(this.picBaseResult);
            this.pnlBaseResult.Controls.Add(this.lblBaseResult);
            this.pnlBaseResult.Location = new System.Drawing.Point(1, 3);
            this.pnlBaseResult.Name = "pnlBaseResult";
            this.pnlBaseResult.Size = new System.Drawing.Size(347, 190);
            this.pnlBaseResult.TabIndex = 4;
            this.pnlBaseResult.Visible = false;
            // 
            // dgvBasicResult
            // 
            this.dgvBasicResult.AllowUserToAddRows = false;
            this.dgvBasicResult.AllowUserToDeleteRows = false;
            this.dgvBasicResult.AllowUserToResizeColumns = false;
            this.dgvBasicResult.AllowUserToResizeRows = false;
            this.dgvBasicResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBasicResult.BackgroundColor = System.Drawing.Color.White;
            this.dgvBasicResult.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvBasicResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBasicResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.nickName,
            this.age,
            this.gender});
            this.dgvBasicResult.GridColor = System.Drawing.Color.White;
            this.dgvBasicResult.Location = new System.Drawing.Point(0, 37);
            this.dgvBasicResult.MultiSelect = false;
            this.dgvBasicResult.Name = "dgvBasicResult";
            this.dgvBasicResult.ReadOnly = true;
            this.dgvBasicResult.RowHeadersVisible = false;
            this.dgvBasicResult.RowTemplate.Height = 23;
            this.dgvBasicResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBasicResult.Size = new System.Drawing.Size(347, 153);
            this.dgvBasicResult.TabIndex = 0;
            // 
            // picBaseResult
            // 
            this.picBaseResult.Image = ((System.Drawing.Image)(resources.GetObject("picBaseResult.Image")));
            this.picBaseResult.Location = new System.Drawing.Point(30, 8);
            this.picBaseResult.Name = "picBaseResult";
            this.picBaseResult.Size = new System.Drawing.Size(17, 18);
            this.picBaseResult.TabIndex = 2;
            this.picBaseResult.TabStop = false;
            // 
            // lblBaseResult
            // 
            this.lblBaseResult.AutoSize = true;
            this.lblBaseResult.Location = new System.Drawing.Point(68, 12);
            this.lblBaseResult.Name = "lblBaseResult";
            this.lblBaseResult.Size = new System.Drawing.Size(161, 12);
            this.lblBaseResult.TabIndex = 3;
            this.lblBaseResult.Text = "以下是MyQQ为您找到的结果：";
            // 
            // grpBaseCondition
            // 
            this.grpBaseCondition.Controls.Add(this.txtNickName);
            this.grpBaseCondition.Controls.Add(this.lblNickName);
            this.grpBaseCondition.Location = new System.Drawing.Point(17, 45);
            this.grpBaseCondition.Name = "grpBaseCondition";
            this.grpBaseCondition.Size = new System.Drawing.Size(294, 80);
            this.grpBaseCondition.TabIndex = 3;
            this.grpBaseCondition.TabStop = false;
            this.grpBaseCondition.Text = "查找条件";
            this.grpBaseCondition.Visible = false;
            // 
            // txtNickName
            // 
            this.txtNickName.Location = new System.Drawing.Point(96, 36);
            this.txtNickName.Name = "txtNickName";
            this.txtNickName.Size = new System.Drawing.Size(159, 21);
            this.txtNickName.TabIndex = 3;
            // 
            // lblNickName
            // 
            this.lblNickName.AutoSize = true;
            this.lblNickName.Location = new System.Drawing.Point(25, 39);
            this.lblNickName.Name = "lblNickName";
            this.lblNickName.Size = new System.Drawing.Size(65, 12);
            this.lblNickName.TabIndex = 1;
            this.lblNickName.Text = "对方昵称：";
            // 
            // picBaseCondition
            // 
            this.picBaseCondition.Image = ((System.Drawing.Image)(resources.GetObject("picBaseCondition.Image")));
            this.picBaseCondition.Location = new System.Drawing.Point(30, 8);
            this.picBaseCondition.Name = "picBaseCondition";
            this.picBaseCondition.Size = new System.Drawing.Size(17, 18);
            this.picBaseCondition.TabIndex = 0;
            this.picBaseCondition.TabStop = false;
            // 
            // lblBaseCondition
            // 
            this.lblBaseCondition.AutoSize = true;
            this.lblBaseCondition.Location = new System.Drawing.Point(68, 14);
            this.lblBaseCondition.Name = "lblBaseCondition";
            this.lblBaseCondition.Size = new System.Drawing.Size(137, 12);
            this.lblBaseCondition.TabIndex = 1;
            this.lblBaseCondition.Text = "可以根据昵称查找所有人";
            // 
            // tabSearch
            // 
            this.tabSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabSearch.Controls.Add(this.tpBaseSearch);
            this.tabSearch.Location = new System.Drawing.Point(116, 11);
            this.tabSearch.Name = "tabSearch";
            this.tabSearch.SelectedIndex = 0;
            this.tabSearch.Size = new System.Drawing.Size(355, 216);
            this.tabSearch.TabIndex = 1;
            // 
            // btn1
            // 
            this.btn1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn1.BackgroundImage")));
            this.btn1.Location = new System.Drawing.Point(169, 232);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(71, 24);
            this.btn1.TabIndex = 5;
            this.btn1.Text = "上一步";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Visible = false;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "MyQQ号码";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // nickName
            // 
            this.nickName.DataPropertyName = "NickName";
            this.nickName.HeaderText = "昵称";
            this.nickName.Name = "nickName";
            this.nickName.ReadOnly = true;
            // 
            // age
            // 
            this.age.DataPropertyName = "Age";
            this.age.HeaderText = "年龄";
            this.age.Name = "age";
            this.age.ReadOnly = true;
            // 
            // gender
            // 
            this.gender.DataPropertyName = "gender";
            this.gender.HeaderText = "性别";
            this.gender.Name = "gender";
            this.gender.ReadOnly = true;
            // 
            // SearchFriendForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(483, 268);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btn4);
            this.Controls.Add(this.tabSearch);
            this.Controls.Add(this.picLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SearchFriendForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查找/添加好友";
            this.Load += new System.EventHandler(this.SearchFriendForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.tpBaseSearch.ResumeLayout(false);
            this.pnlBaseCondition.ResumeLayout(false);
            this.pnlBaseCondition.PerformLayout();
            this.pnlBaseResult.ResumeLayout(false);
            this.pnlBaseResult.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBasicResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBaseResult)).EndInit();
            this.grpBaseCondition.ResumeLayout(false);
            this.grpBaseCondition.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBaseCondition)).EndInit();
            this.tabSearch.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.ColumnHeader chLoginId;
        private System.Windows.Forms.ColumnHeader chNickName;
        private System.Windows.Forms.ColumnHeader chAge;
        private System.Windows.Forms.ColumnHeader chSex;
        private System.Windows.Forms.TabPage tpBaseSearch;
        private System.Windows.Forms.Panel pnlBaseCondition;
        private System.Windows.Forms.GroupBox grpBaseCondition;
        private System.Windows.Forms.PictureBox picBaseCondition;
        private System.Windows.Forms.TabControl tabSearch;
        private System.Windows.Forms.Panel pnlBaseResult;
        private System.Windows.Forms.DataGridView dgvBasicResult;
        private System.Windows.Forms.PictureBox picBaseResult;
        private System.Windows.Forms.Label lblBaseResult;
        private System.Windows.Forms.TextBox txtNickName;
        private System.Windows.Forms.Label lblNickName;
        private System.Windows.Forms.Label lblBaseCondition;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nickName;
        private System.Windows.Forms.DataGridViewTextBoxColumn age;
        private System.Windows.Forms.DataGridViewTextBoxColumn gender;
    }
}