using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using MyQQ.Model;

namespace MyQQ
{
    /// <summary>
    /// 好友添加请求消息窗体
    /// </summary>
    public partial class InputForm : Form
    {
        public InputForm(String formTitle,String lblMess)
        {
            InitializeComponent();
            this.Text = formTitle;
            this.lblMess.Text = lblMess;
        }

        // 窗体加载时，取出请求消息显示
        private void RequestForm_Load(object sender, EventArgs e)
        {
 
        }

        // 同意添加好友请求
        private void btnAllow_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public string getInput()
        {
            return txtInput.Text.Trim();
        }
    }
}