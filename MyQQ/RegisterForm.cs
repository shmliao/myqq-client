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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            cboBlood.Text = "����";
            cboConste.Text = "����";
        }

        // �������ʱ�����������Ѫ����Ͽ��е���
        private void ApplyForm_Load(object sender, EventArgs e)
        {
        
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
                RegisetRequestModel requestModel = new RegisetRequestModel();
                requestModel.age = Convert.ToInt32(txtAge.Text);
                requestModel.blood = cboBlood.Text;
                requestModel.conste = cboConste.Text;
                if (rdoMan.Checked)
                {
                    requestModel.gender = "��";
                }
                else {
                    requestModel.gender = "Ů";
                }
                requestModel.nickname = txtNickName.Text.Trim();
                requestModel.username = txtUserName.Text.Trim();
                requestModel.userpass = txtUserPass.Text.Trim();
                SystemHelper.register(requestModel,this);
            }    
        }

        /// <summary>
        /// ��֤�û�������
        /// </summary>        
        private bool ValidateInput()
        {
            if (txtUserName.Text.Trim() == "") {
                MessageBox.Show("�������¼����", "������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUserName.Focus();
                return false;
            }

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



        /// <summary>
        /// ȡ�������� Id
        /// </summary>        
        private int GetStarId()
        {
            return 0;
            //int starId = -1;  // ����ֵ
            //// ��ѯ����Id�� SQL ���
            //string sql = string.Format("SELECT Id FROM Star WHERE Star = '{0}'", cboConste.Text);
            //try
            //{
            //    // ���� Command ����
            //    SqlCommand command = new SqlCommand(sql, DBHelper.connection);
            //    DBHelper.connection.Open();  // �����ݿ�����
            //    starId = Convert.ToInt32(command.ExecuteScalar());                
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //finally
            //{
            //    DBHelper.connection.Close();
            //}

            //if (starId > 0)
            //{
            //    return starId;
            //}
            //else
            //{
            //    return -1;
            //}                 
        }

        /// <summary>
        /// ȡ��Ѫ�͵� Id
        /// </summary>        
        private int GetBloodType()
        {
            return 0;
        //    int bloodTypeId = -1;  // ����ֵ

        //    // ��ѯ����Id�� SQL ���
        //    string sql = string.Format("SELECT Id FROM BloodType WHERE BloodType = '{0}'", cboBlood.Text);
        //    try
        //    {
        //        // ���� Command ����
        //        SqlCommand command = new SqlCommand(sql, DBHelper.connection);
        //        DBHelper.connection.Open();  // �����ݿ�����
        //        bloodTypeId = Convert.ToInt32(command.ExecuteScalar());                
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    finally
        //    {
        //        DBHelper.connection.Close();
        //    }
        //    if (bloodTypeId > 0)
        //    {
        //        return bloodTypeId;
        //    }
        //    else
        //    {
        //        return -1;
        //    }          
        }
    }
}