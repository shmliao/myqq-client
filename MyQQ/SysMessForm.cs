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
    public partial class SysMessForm : Form
    {
        private GetSysMessResponseModel sysMessModel;
        public SysMessForm(GetSysMessResponseModel sysMessModel)
        {
            InitializeComponent();
            this.sysMessModel = sysMessModel;
            ShowInfo();
        }

        private void ShowInfo()
        {
            int messType = sysMessModel.sysMessType;
            this.picIcon.Image = ilIcons.Images[sysMessModel.faceimg];
            this.lblMessage.Text = sysMessModel.content;
            btn1.Visible = false;
            btn2.Visible = true;
            btn2.Text = "ȷ��";
            this.Text = "ϵͳ��Ϣ";
            switch (messType)
            {
                case 1:
                    this.Text = sysMessModel.fromNickName+"�ĺ�������";
                    btn1.Text = "ͬ��";
                    btn2.Text = "�ܾ�";
                    btn1.Visible = true;
                    break;
                case 2:
                    this.lblMessage.Text = sysMessModel.fromNickName + "ͬ������ĺ������룡";
                    break;
                case 3:
                    this.lblMessage.Text = sysMessModel.fromNickName + "�ܾ�����ĺ������룡" + Environment.NewLine + "������Ϣ:"+sysMessModel.content;
                    break;
                default:
                    break;
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (btn1.Text == "ͬ��")
            {
                AgreenAddFriendRequestModel requestModel = new AgreenAddFriendRequestModel();
                requestModel.result = 1;
                requestModel.targetId = sysMessModel.fromId;
                SystemHelper.AgreeAddFriend(requestModel, (m) =>
                {
                    if (m)
                    {
                        SendOk();
                    }
                    else
                    {
                        SendNo();
                    }
                });
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (btn2.Text == "�ܾ�")
            {
                AgreenAddFriendRequestModel requestModel = new AgreenAddFriendRequestModel();
                requestModel.result = 0;
                requestModel.targetId = sysMessModel.fromId;
                InputForm inputForm = new InputForm("�ܾ���������", "������ܾ���Ϣ(����:����˭?)");
                inputForm.ShowDialog();
                requestModel.resultMess = inputForm.getInput();
                SystemHelper.AgreeAddFriend(requestModel, (m) =>
                {
                    if (m)
                    {
                        SendOk();
                    }
                    else
                    {
                        SendNo();
                    }
                });
            }
            else
            {
                this.Close();
            }
        }

        public void SendOk()
        {
            this.Invoke(new Action(() =>
            {
                this.Close();
            }));
        }

        public void SendNo()
        {
            this.Invoke(new Action(() =>
            {
                MessageBox.Show("��Ϣ����ʧ��,�����ԣ�");
            }));
        }
    }
}