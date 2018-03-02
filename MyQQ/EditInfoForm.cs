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
    /// ע�����
    /// </summary>
    public partial class EditInfoForm : Form
    {
        public EditInfoForm()
        {
            InitializeComponent();
            cboBlood.Text = "����";
            cboConste.Text = "����";
        }

        // �������ʱ�����������Ѫ����Ͽ��е���
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
            if (user.gender == "��")
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
                    MessageBox.Show("ע��ɹ���", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("ע��ʧ��(" + responseModel.mess + ")��", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("ע��ʧ�ܣ�������!");
                btnRegist.Enabled = true;
            }));
        }

        // ���ȡ�����رմ���
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ���ע�ᣬ�����ݿ���Ӽ�¼
        private void btnRegist_Click(object sender, EventArgs e)
        {
            if (ValidateInput()) {
                EditInfoRequestModel requestModel = new EditInfoRequestModel();
                requestModel.age = Convert.ToInt32(txtAge.Text);
                requestModel.blood = cboBlood.Text;
                requestModel.conste = cboConste.Text;
                if (rdoMan.Checked)
                {
                    requestModel.gender = "��";
                }
                else
                {
                    requestModel.gender = "Ů";
                }
                requestModel.nickname = txtNickName.Text.Trim();
                requestModel.userpass = txtUserPass.Text.Trim();
                requestModel.faceimg = Convert.ToInt32(picFace.Tag);
                SystemHelper.EditInfo(requestModel,new Action<bool>(m=> {
                    if (!m)
                    {
                        MessageBox.Show("��Ϣ����ʧ��");
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
        /// ��֤�û�������
        /// </summary>        
        private bool ValidateInput()
        {
            if (txtNickName.Text.Trim() == "")
            {
                MessageBox.Show("�������ǳƣ�","������ʾ",MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtNickName.Focus();
                return false;
            }

            if (txtAge.Text.Trim() == "")
            {
                MessageBox.Show("���������䣡", "������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAge.Focus();
                return false;
            }

            if (!rdoMan.Checked && !rdoWomen.Checked)
            {
                MessageBox.Show("��ѡ���Ա�", "������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblSex.Focus();
                return false;
            }
            if (txtUserPass.Text.Trim() == "")
            {
                MessageBox.Show("���������룡", "������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUserPass.Focus();
                return false;
            }

            if (txtUserPass.Text.Trim() == "")
            {
                MessageBox.Show("������ȷ�����룡", "������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRepUserPass.Focus();
                return false;
            }

            if (txtUserPass.Text.Trim() != txtRepUserPass.Text.Trim())
            {
                MessageBox.Show("������������벻һ����", "������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
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