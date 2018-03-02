using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Aptech.UI;
using System.Data.SqlClient;
using System.Media;
using MyQQ.Model;
using System.Threading;

namespace MyQQ
{
    /// <summary>
    /// 登录后的主窗体
    /// </summary>
    public partial class MainForm : Form
    {
        private bool isUserExit = false;
        public MainForm()
        {
            InitializeComponent();
        }
        private Dictionary<int, GetFriendsResponseModel> dicFriends = new Dictionary<int, GetFriendsResponseModel>();
        private Dictionary<GetFriendsResponseModel, MyItem> dicItems = new Dictionary<GetFriendsResponseModel, MyItem>();
        private Dictionary<int, ChatForm> dicChats = new Dictionary<int, ChatForm>();
 
        // 窗体加载时发生
        private void MainForm_Load(object sender, EventArgs e)
        {
    
            // 显示个人的信息            
            ShowSelfInfo();
            // 添加 SideBar 的两个组
            sbFriends.AddGroup("我的好友");
            TaskMenu.Text = "MyQQ(" + SystemHelper.currentUser.nickname + ")";
            //获取我的好友
            GetFriends();
            //GetSysMess();
            //GetOffLineChatMess();
        }

        private void GetSysMess()
        {
            GetSysMessRequestModel requestMdoel = new GetSysMessRequestModel();
            requestMdoel.id = SystemHelper.currentUser.id;
            SystemHelper.GetSysMess(requestMdoel, this);
        }

        private void GetOffLineChatMess()
        {
            GetOffLineChatMessRequestModel requestModel = new GetOffLineChatMessRequestModel();
            SystemHelper.GetOffLineChatMess(requestModel,m=> {
                if (!m) {
                    MessageBox.Show("获取离线消息失败!","系统提示");
                }
            });
        }

        private void GetFriends()
        {
            GetFriendsRequestModel requestModel = new GetFriendsRequestModel();
            SystemHelper.GetFriends(requestModel,this);
        }

        public void GetFriendsRespondeHandler(GetFriendsResponseModel responseModel)
        {
            this.Invoke(new Action(()=> {
                lock (this)
                {
                    MyItem item = null;
                    if (!dicFriends.ContainsKey(responseModel.friendid))
                    {
                        dicFriends.Add(responseModel.friendid, responseModel);
                        item = new MyItem();
                        sbFriends.Groups[0].Items.Add(item);
                        dicItems.Add(responseModel, item);
                    }
                    else {
                        GetFriendsResponseModel temRes = dicFriends[responseModel.friendid];
                        item = dicItems[temRes];
                        dicFriends[responseModel.friendid] = responseModel;
                        dicItems.Remove(temRes);
                        dicItems.Add(responseModel, item);
                    }
                    string nickName = responseModel.nickName;
                    if (responseModel.state == 1)
                    {
                        nickName += "(在线)";
                    }
                    else
                    {
                        nickName += "(离线)";
                    }
                    item.Text = nickName;
                    item.ImageIndex = responseModel.faceimg;
                    item.FaceImg = item.ImageIndex;
                    item.Tag = responseModel;
                    sbFriends.Invalidate();
                }
            }));
            Application.DoEvents();
        }


        // 显示个人信息窗体
        private void tsbtnPersonalInfo_Click(object sender, EventArgs e)
        {
            //PersonalInfoForm personalInfoForm = new PersonalInfoForm();
            //personalInfoForm.mainForm = this;  // 将当前窗体本身传给个人信息窗体
            //personalInfoForm.Show();

            //FacesForm faceForm = new FacesForm();
            //faceForm.Show();
            EditInfoForm infoForm = new EditInfoForm();
            infoForm.Show();
        }

        // 显示查找好友窗体
        private void tsbtnSearchFriend_Click(object sender, EventArgs e)
        {
            SearchFriendForm searchFriendForm = new SearchFriendForm();
            searchFriendForm.Show();
        }

        public void GetOffLineChatMessHandler(GetOffLineChatMessResponseModel responseModel)
        {
            this.Invoke(new Action(()=> {
                SbItemTimer.Start();
                ChatForm chatForm = null;
                lock (this)
                {
                    if (dicChats.ContainsKey(responseModel.fromid))
                    {
                        chatForm = dicChats[responseModel.fromid];
                    }
                    else if (dicFriends.ContainsKey(responseModel.fromid))
                    {
                        GetFriendsResponseModel friendModel = dicFriends[responseModel.fromid];
                        chatForm = new ChatForm(friendModel);
                        dicChats.Add(friendModel.friendid, chatForm);
                    }
                }
                if (chatForm != null)
                {
                    chatForm.ShowMessage(responseModel.createtime, responseModel.nickName, responseModel.content);
                }
                else
                {
                    lock (this)
                    {
                        GetFriendsResponseModel friendModel = new GetFriendsResponseModel();
                        friendModel.faceimg = responseModel.faceimg;
                        friendModel.friendid = responseModel.fromid;
                        friendModel.nickName = responseModel.nickName;
                        chatForm = new ChatForm(friendModel);
                        chatForm.ShowMessage(responseModel.createtime, responseModel.nickName, responseModel.content);
                    }
                }

                lock (this) {
                    if (!chatForm.Visible) {
                        if (dicFriends.ContainsKey(responseModel.fromid)) {
                            if (dicItems.ContainsKey(dicFriends[responseModel.fromid])) {
                                MyItem sbItem=dicItems[dicFriends[responseModel.fromid]];
                                sbItem.isShandong = true;
                            }
                        }
                    }
                }

            }));
            Application.DoEvents();
        }
  
        public void OffLineFriend(int friendId) {
            this.Invoke(new Action(()=> {
                if (dicFriends.ContainsKey(friendId)) {
                    GetFriendsResponseModel respondeModel = dicFriends[friendId];
                    MyItem sbItem = dicItems[respondeModel];
                    sbItem.Text = respondeModel.nickName + "(离线)";
                    sbFriends.Invalidate();
                }
            }));
            Application.DoEvents();
        }

        public void OnLineFriend(int friendId) {
            this.Invoke(new Action(() => {
                if (dicFriends.ContainsKey(friendId))
                {
                    GetFriendsResponseModel respondeModel = dicFriends[friendId];
                    MyItem sbItem = dicItems[respondeModel];
                    sbItem.Text = respondeModel.nickName + "(在线)";
                    sbFriends.Invalidate();
                }
            }));
            Application.DoEvents();
        }
        // 双击一项，弹出聊天窗体        
        private void sbFriends_ItemDoubleClick(SbItemEventArgs e)
        {
            GetFriendsResponseModel friendModel = (GetFriendsResponseModel)e.Item.Tag;
            ChatForm chatForm = null;
            lock (this) {
                if (dicChats.ContainsKey(friendModel.friendid))
                {
                    chatForm = dicChats[friendModel.friendid];
                    chatForm.Show();
                }
                else
                {
                    // 显示聊天窗体
                    chatForm = new ChatForm(friendModel);
                    dicChats.Add(friendModel.friendid, chatForm);
                    chatForm.Show();
                }
                ((MyItem)e.Item).isShandong = false;
            }
        }
        /// <summary>
        /// 登录后显示个人的信息
        /// </summary>
        public void ShowSelfInfo()
        {
            string nickName =SystemHelper.currentUser.nickname;  // 昵称
            int faceId = SystemHelper.currentUser.faceimg;        // 头像索引
            this.picFace.Image = ilFaces.Images[faceId];
            this.lblLoginId.Text = string.Format("{0}", nickName);
        }
 

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isUserExit) {
                this.Hide();
                e.Cancel = true;
            }
        }

        private void TaskMenu_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isUserExit = true;
            this.Close();
        }

        private void SbItemTimer_Tick(object sender, EventArgs e)
        {
            int count = sbFriends.Groups[0].Items.Count;
            SbItemCollection sc = sbFriends.Groups[0].Items;
            for (int i=0;i<count;i++) {
                MyItem item = (MyItem)sc[i];
                if (item.isShandong)
                {
                    if (item.ImageIndex == 100)
                    {
                        item.ImageIndex = item.FaceImg;
                    }
                    else {
                        item.ImageIndex = 100;
                    }
                }
                else {
                    if (item.ImageIndex == 100)
                    {
                        item.ImageIndex = item.FaceImg;
                    }
                }
            }
            sbFriends.Invalidate();
        }
    }
}