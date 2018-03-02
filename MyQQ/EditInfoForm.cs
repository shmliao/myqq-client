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
    /// 注册界面
    /// </summary>
    public partial class EditInfoForm : Form
    {
        public EditInfoForm()
        {
            InitializeComponent();
            cboBlood.Text = "其它";
            cboConste.Text = "其它";
        }

        // 窗体加载时，添加星座和血型组合框中的项
        private void ApplyForm_Load(object sender, EventArgs e)
        {
            showUserInfo();
        }

        private void showUserInfo()
        {
            var user = SystemHelper.currentUser;
            txtAge.Text = user.age.ToString();
            cboBlood.Text = user.blood;
            cboConste.Text = user.conste;
            if (user.gender == "男")
            {
                rdoMan.Checked = true;
            }
            else {
                rdoWomen.Checked = true;
            }
            txtNickName.Text = user.nickname;
            picFace.Image = ilFaces.Images[user.faceimg];
            picFace.Tag = user.faceimg;
            txtUserPass.Text = txtRepUserPass.Text = "";
        }

        public void RegisterOK(RegisetResponseModel responseModel)
        {
            this.Invoke(new Action(() =>{
                if (responseModel.state == 1)
                {
                    MessageBox.Show("注册成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("注册失败(" + responseModel.mess + ")！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnRegist.Enabled = true;
                }
            }),null);
        }

        public void ShowFace(int faceId)
        {
            picFace.Image = ilFaces.Images[faceId];
            picFace.Tag = faceId;
        }

        public void SendOK()
        {
            this.Invoke(new Action(() => {
                btnRegist.Enabled = false;
            }));
        }

        public void SendNo() {
            this.Invoke(new Action(() => {
                MessageBox.Show("注册失败，请重试!");
                btnRegist.Enabled = true;
            }));
        }

        // 点击取消，关闭窗体
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 点击注册，向数据库添加记录
        private void btnRegist_Click(object sender, EventArgs e)
        {
            if (ValidateInput()) {
                EditInfoRequestModel requestModel = new EditInfoRequestModel();
                requestModel.age = Convert.ToInt32(txtAge.Text);
                requestModel.blood = cboBlood.Text;
                requestModel.conste = cboConste.Text;
                if (rdoMan.Checked)
                {
                    requestModel.gender = "男";
                }
                else
                {
                    requestModel.gender = "女";
                }
                requestModel.nickname = txtNickName.Text.Trim();
                requestModel.userpass = txtUserPass.Text.Trim();
                requestModel.faceimg = Convert.ToInt32(picFace.Tag);
                SystemHelper.EditInfo(requestModel,new Action<bool>(m=> {
                    if (!m)
                    {
                        MessageBox.Show("信息发送失败");
                    }
                    else {
                        this.Invoke(new Action(()=> {
                            this.Close();
                        }));
                    }
                }));
            }    
        }
 

        /// <summary>
        /// 验证用户的输入
        /// </summary>        
        private bool ValidateInput()
        {
            if (txtNickName.Text.Trim() == "")
            {
                MessageBox.Show("请输入昵称！","输入提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtNickName.Focus();
                return false;
            }

            if (txtAge.Text.Trim() == "")
            {
                MessageBox.Show("请输入年龄！", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAge.Focus();
                return false;
            }

            if (!rdoMan.Checked && !rdoWomen.Checked)
            {
                MessageBox.Show("请选择性别！", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblSex.Focus();
                return false;
            }
            if (txtUserPass.Text.Trim() == "")
            {
                MessageBox.Show("请输入密码！", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUserPass.Focus();
                return false;
            }

            if (txtUserPass.Text.Trim() == "")
            {
                MessageBox.Show("请输入确认密码！", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRepUserPass.Focus();
                return false;
            }

            if (txtUserPass.Text.Trim() != txtRepUserPass.Text.Trim())
            {
                MessageBox.Show("两次输入的密码不一样！", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRepUserPass.Focus();
                return false;
            }
            return true;
        }

        private void picFace_Click(object sender, EventArgs e)
        {
            FacesForm faceForm = new FacesForm(this);
            faceForm.Show();
        }
    }
}