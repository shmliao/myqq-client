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
            btn2.Text = "确定";
            this.Text = "系统消息";
            switch (messType)
            {
                case 1:
                    this.Text = sysMessModel.fromNickName+"的好友申请";
                    btn1.Text = "同意";
                    btn2.Text = "拒绝";
                    btn1.Visible = true;
                    break;
                case 2:
                    this.lblMessage.Text = sysMessModel.fromNickName + "同意了你的好友申请！";
                    break;
                case 3:
                    this.lblMessage.Text = sysMessModel.fromNickName + "拒绝了你的好友申请！" + Environment.NewLine + "附加信息:"+sysMessModel.content;
                    break;
                default:
                    break;
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (btn1.Text == "同意")
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
            if (btn2.Text == "拒绝")
            {
                AgreenAddFriendRequestModel requestModel = new AgreenAddFriendRequestModel();
                requestModel.result = 0;
                requestModel.targetId = sysMessModel.fromId;
                InputForm inputForm = new InputForm("拒绝好友申请", "请输入拒绝信息(例如:你是谁?)");
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
                MessageBox.Show("消息发送失败,请重试！");
            }));
        }
    }
}