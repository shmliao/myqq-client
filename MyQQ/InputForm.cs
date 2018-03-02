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
    /// �������������Ϣ����
    /// </summary>
    public partial class InputForm : Form
    {
        public InputForm(String formTitle,String lblMess)
        {
            InitializeComponent();
            this.Text = formTitle;
            this.lblMess.Text = lblMess;
        }

        // �������ʱ��ȡ��������Ϣ��ʾ
        private void RequestForm_Load(object sender, EventArgs e)
        {
 
        }

        // ͬ����Ӻ�������
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