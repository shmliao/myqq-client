using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using MyQQ.Model;
using System.Text.RegularExpressions;

namespace MyQQ
{
    /// <summary>
    /// 聊天窗体
    /// </summary>
    public partial class ChatForm : Form
    {
        private int textIndex = 0;
        private GetFriendsResponseModel friendModel;
        public ChatForm(GetFriendsResponseModel friendModel)
        {
            InitializeComponent();
            this.friendModel = friendModel;
            // 设置窗体标题
            this.Text = string.Format("与{0}聊天中", friendModel.nickName);
            // 设置窗体顶部显示的好友信息
            picFace.Image = ilFaces.Images[friendModel.faceimg];
            lblFriend.Text = string.Format("{0}", friendModel.nickName);
            txtSendMess.Focus();
        }

        // 关闭窗体
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 发送消息
        private void btnSend_Click(object sender, EventArgs e)
        {
            SendChatMess();
        }

        private void SendChatMess()
        {
            if (txtSendMess.Text.Trim() == "")
            {
                return;
            }
            SendChatMessRequestModel requestModel = new SendChatMessRequestModel();
            requestModel.content = txtSendMess.Text.Trim();
            requestModel.targetId = friendModel.friendid;
            requestModel.targetType = 0;
            ShowMyMessage(DateTime.Now, SystemHelper.currentUser.nickname, requestModel.content);
            SystemHelper.SendChatMess(requestModel, new Action<bool>((m) => {
                if (!m)
                {
                    ShowSendErrorMesssage(requestModel.content);
                }
            }));
            txtSendMess.Text = "";
        }

        private void ShowSendErrorMesssage(string message)
        {
            this.Invoke(new Action(()=> {
                lock (this) {
                    String temLine = message + " 发送失败" + Environment.NewLine;
                    txtRecordMess.AppendText(message + " 发送失败" + Environment.NewLine);
                    txtRecordMess.Select(textIndex, temLine.Length);
                    txtRecordMess.SelectionColor = Color.Red;
                    textIndex += temLine.Length- getEnterCount(temLine);
                    //设置光标的位置到文本尾 
                    txtRecordMess.Select(txtRecordMess.TextLength, 0);
                    //滚动到控件光标处 
                    txtRecordMess.ScrollToCaret();
                }
            }));
            Application.DoEvents();
        }

        public int getEnterCount(string input) {
            int temCount = Regex.Matches(input, "\r\n").Count;
            return temCount;
        }

        /// <summary>
        /// 读取所有的未读消息，显示在窗体中
        /// </summary>
        public void ShowMessage(DateTime sendTime,string nickName,string message)
        {
            lock (this) {
                String temLine = sendTime.ToString("yyyy-MM-dd HH:mm:ss") + "  " + nickName + ":" + Environment.NewLine;
                txtRecordMess.AppendText(temLine);
                txtRecordMess.Select(textIndex, temLine.Length);
                txtRecordMess.SelectionColor = Color.Blue;
                textIndex += temLine.Length - 1;
                temLine = message + Environment.NewLine;
                txtRecordMess.AppendText(temLine);
                txtRecordMess.Select(textIndex, temLine.Length);
                txtRecordMess.SelectionColor = Color.Black;
                textIndex += temLine.Length - getEnterCount(temLine);
                //设置光标的位置到文本尾 
                txtRecordMess.Select(txtRecordMess.TextLength, 0);
                //滚动到控件光标处 
                txtRecordMess.ScrollToCaret();
            }
        }
        private Font myFont = new Font("宋体",9,FontStyle.Bold);
        /// <summary>
        /// 读取所有的未读消息，显示在窗体中
        /// </summary>
        public void ShowMyMessage(DateTime sendTime, string nickName, string message)
        {
            lock (this)
            {
                String temLine = sendTime.ToString("yyyy-MM-dd HH:mm:ss") + "  " + nickName + ":" + Environment.NewLine;
                txtRecordMess.AppendText(temLine);
                txtRecordMess.Select(textIndex, temLine.Length);
                txtRecordMess.SelectionColor = Color.Blue;
                textIndex += temLine.Length-1;
                temLine = message + Environment.NewLine;
                txtRecordMess.AppendText(temLine);
                txtRecordMess.Select(textIndex, temLine.Length);
                txtRecordMess.SelectionColor = Color.Black;
                txtRecordMess.SelectionFont = myFont;
                textIndex += temLine.Length - getEnterCount(temLine);
                //设置光标的位置到文本尾 
                txtRecordMess.Select(txtRecordMess.TextLength, 0);
                //滚动到控件光标处 
                txtRecordMess.ScrollToCaret();
            }
        }

        private void ChatForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void ChatForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Enter) {
                SendChatMess();
            }
        }
    }
}