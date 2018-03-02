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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            cboBlood.Text = "其它";
            cboConste.Text = "其它";
        }

        // 窗体加载时，添加星座和血型组合框中的项
        private void ApplyForm_Load(object sender, EventArgs e)
        {
        
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
                RegisetRequestModel requestModel = new RegisetRequestModel();
                requestModel.age = Convert.ToInt32(txtAge.Text);
                requestModel.blood = cboBlood.Text;
                requestModel.conste = cboConste.Text;
                if (rdoMan.Checked)
                {
                    requestModel.gender = "男";
                }
                else {
                    requestModel.gender = "女";
                }
                requestModel.nickname = txtNickName.Text.Trim();
                requestModel.username = txtUserName.Text.Trim();
                requestModel.userpass = txtUserPass.Text.Trim();
                SystemHelper.register(requestModel,this);
            }    
        }

        /// <summary>
        /// 验证用户的输入
        /// </summary>        
        private bool ValidateInput()
        {
            if (txtUserName.Text.Trim() == "") {
                MessageBox.Show("请输入登录名！", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUserName.Focus();
                return false;
            }

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



        /// <summary>
        /// 取得星座的 Id
        /// </summary>        
        private int GetStarId()
        {
            return 0;
            //int starId = -1;  // 返回值
            //// 查询星座Id的 SQL 语句
            //string sql = string.Format("SELECT Id FROM Star WHERE Star = '{0}'", cboConste.Text);
            //try
            //{
            //    // 创建 Command 对象
            //    SqlCommand command = new SqlCommand(sql, DBHelper.connection);
            //    DBHelper.connection.Open();  // 打开数据库连接
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
        /// 取得血型的 Id
        /// </summary>        
        private int GetBloodType()
        {
            return 0;
        //    int bloodTypeId = -1;  // 返回值

        //    // 查询星座Id的 SQL 语句
        //    string sql = string.Format("SELECT Id FROM BloodType WHERE BloodType = '{0}'", cboBlood.Text);
        //    try
        //    {
        //        // 创建 Command 对象
        //        SqlCommand command = new SqlCommand(sql, DBHelper.connection);
        //        DBHelper.connection.Open();  // 打开数据库连接
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