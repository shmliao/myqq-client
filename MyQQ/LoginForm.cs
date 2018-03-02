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
    /// 登录窗体
    /// </summary>
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        // 取消按钮的事件处理
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // 打开申请号码界面
        private void llbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        }

        // 登录按钮事件处理
        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginRequestModel requestModel = new LoginRequestModel();
            requestModel.username = txtLoginId.Text.Trim();
            requestModel.userpass = txtLoginPwd.Text.Trim();
            SystemHelper.Login(requestModel,this);
        }

        public void LoginOK(LoginResponseModel responseModel) {
            this.Invoke(new Action(() => {
                if (responseModel.state == 1)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else {
                    MessageBox.Show("登录失败:"+responseModel.mess);
                }

            }));
        }

        public void SendOk() {
   
        }

        public void SendNo() {
            this.Invoke(new Action(() => {
                MessageBox.Show("登录失败，请重试!");
            }));
        }
        // 忘记密码标签
        private void llblFogetPwd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("该功能尚未开通！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        // 用户输入验证
        private bool ValidateInput()
        {
            // 验证用户输入
            if (txtLoginId.Text.Trim() == "")
            {
                MessageBox.Show("请输入登录的号码", "登录提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLoginId.Focus();
                return false;
            }            
            else if (txtLoginPwd.Text.Trim() == "")
            {
                MessageBox.Show("请输入密码", "登录提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLoginPwd.Focus();
                return false;
            }
            return true;
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}