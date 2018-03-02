using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyQQ.Model;
using WebSocketSharp;
using System.Collections.Concurrent;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Threading;
using System.Collections;

namespace MyQQ
{
    public class SystemHelper
    {
        private static object obj = new object();
        private static int currentState = 0;
        private static WebSocket ws = null;
        private static RegisterForm registerForm = null;
        private static LoginForm loginForm = null;
        private static SearchFriendForm searchFormFriend = null;
        private static MainForm mainForm = null;
        private static BlockingCollection<CommonMess> RequestQueue = new BlockingCollection<CommonMess>();
        public static LoginResponseModel currentUser = null;
        static SystemHelper()
        {
            sendThread.Start();
        }
        public static Thread sendThread = new Thread(new ThreadStart(() =>
        {
            while (true)
            {
                CommonMess messModel = RequestQueue.Take();
                string json = JsonHelper.SerializeObject(messModel);
                while (currentState != 2)
                {
                    Thread.Sleep(1000);
                }
                ws.SendAsync(json, m =>
                {
                    if (messModel.action == null)
                    {
                        if (!m)
                        {
                            OnErrorMessSend(messModel);
                        }
                        else
                        {
                            OnSuccessMessSend(messModel);
                        }
                    }
                    else
                    {
                        messModel.action(m);
                    }
                });
            }
        }));

        public static void GetOffLineChatMess(GetOffLineChatMessRequestModel requestModel, Action<bool> action)
        {
            sendMess(MessType.GetOffLineChatMess, requestModel, action);
        }

        public static void SendChatMess(SendChatMessRequestModel requestModel, Action<bool> action)
        {
            sendMess(MessType.SendChatMess, requestModel,action);
        }

        public static void GetFriends(GetFriendsRequestModel requestModel, MainForm mainForm)
        {
            SystemHelper.mainForm = mainForm;
            sendMess(MessType.GetFriends, requestModel);
        }

        public static void AgreeAddFriend(AgreenAddFriendRequestModel requestModel, Action<bool> action)
        {
            sendMess(MessType.AgreeAddFriend, requestModel, action);
        }

        public static void EditInfo(EditInfoRequestModel requestModel, Action<bool> action)
        {
            sendMess(MessType.EditInfo, requestModel, action);
        }

        public static void GetSysMess(GetSysMessRequestModel requestModel, MainForm mainForm)
        {
            SystemHelper.mainForm = mainForm;
            sendMess(MessType.GetSysMess, requestModel);
        }

        public static void register(CommonRequestModel requestModel, RegisterForm registerForm)
        {
            SystemHelper.registerForm = registerForm;
            sendMess(MessType.Register, requestModel);
        }

        public static void Login(CommonRequestModel requestModel, LoginForm loginForm)
        {
            SystemHelper.loginForm = loginForm;
            sendMess(MessType.Login, requestModel);
        }


        public static void SearchFriends(SearchFriendRequestModel requestModel, SearchFriendForm searchFriendForm)
        {
            SystemHelper.searchFormFriend = searchFriendForm;
            sendMess(MessType.SearchFriend, requestModel);
        }

        public static void AddFriend(AddFriendRequestModel requestModel, SearchFriendForm searchFriendForm)
        {
            SystemHelper.searchFormFriend = searchFriendForm;
            sendMess(MessType.AddFriend, requestModel);
        }



        private static void sendMess(int messType, CommonRequestModel requestModel)
        {
            if (SystemHelper.currentUser != null)
            {
                requestModel.id = currentUser.id;
            }
            createConnection();
            CommonMess commonMess = new CommonMess();
            commonMess.messType = messType;
            commonMess.content = JsonHelper.SerializeObject(requestModel);
            RequestQueue.Add(commonMess);
        }

        private static void sendMess(int messType, CommonRequestModel requestModel, Action<bool> action)
        {
            if (SystemHelper.currentUser != null)
            {
                requestModel.id = currentUser.id;
            }
            createConnection();
            CommonMess commonMess = new CommonMess();
            commonMess.messType = messType;
            commonMess.content = JsonHelper.SerializeObject(requestModel);
            commonMess.action = action;
            RequestQueue.Add(commonMess);
        }

        private static void createConnection()
        {
            lock (obj)
            {
                if (ws == null || currentState == 0)
                {
                    if (ws == null)
                    {
                        ws = new WebSocket("ws://im.lainiao.net:12306");
                        ws.OnOpen += Ws_OnOpen;
                        ws.OnMessage += Ws_OnMessage;
                        ws.OnError += Ws_OnError;
                        ws.OnClose += Ws_OnClose;
                    }
                    ws.ConnectAsync();
                    currentState = 1;
                }
            }
        }

        private static void Ws_OnClose(object sender, CloseEventArgs e)
        {
            lock (obj)
            {
                currentState = 0;
                ws = null;
                if (e.Code == 1006)
                {
                    MessageBox.Show("网络错误,无法连接到远程服务器", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private static void Ws_OnError(object sender, ErrorEventArgs e)
        {
            MessageBox.Show("系统错误(" + e.Message + ")", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void Ws_OnMessage(object sender, MessageEventArgs e)
        {
            try {
                string json = e.Data;
                CommonMess responseMess = JsonHelper.DeserializeObject<CommonMess>(json);
                int messType = -responseMess.messType;
                if (messType == MessType.AddFriend)
                {
                    searchFormFriend.AddFriendOK();
                }
                else if (messType == MessType.AgreeAddFriend)
                {

                }
                else if (messType == MessType.GetFriends)
                {
                    GetFriendsResponseModel responseModel = JsonHelper.DeserializeObject<GetFriendsResponseModel>(responseMess.content);
                    mainForm.GetFriendsRespondeHandler(responseModel);
                }
                else if (messType == MessType.GetOffLineChatMess)
                {
                    GetOffLineChatMessResponseModel responseModel = JsonHelper.DeserializeObject<GetOffLineChatMessResponseModel>(responseMess.content);
                    mainForm.GetOffLineChatMessHandler(responseModel);
                }
                else if (messType == MessType.GetSysMess)
                {
                    GetSysMessResponseModel responseModel = JsonHelper.DeserializeObject<GetSysMessResponseModel>(responseMess.content);
                    SysMessHandler(responseModel);
                }
                else if (messType == MessType.Login)
                {
                    LoginResponseModel responseModel = JsonHelper.DeserializeObject<LoginResponseModel>(responseMess.content);
                    SystemHelper.currentUser = responseModel;
                    loginForm.LoginOK(responseModel);
                }
                else if (messType == MessType.LoginOut)
                {

                }
                else if (messType == MessType.Register)
                {
                    RegisetResponseModel responseModel = JsonHelper.DeserializeObject<RegisetResponseModel>(responseMess.content);
                    registerForm.RegisterOK(responseModel);
                }
                else if (messType == MessType.SearchFriend)
                {
                    SearchFriendResponseModel responseModel = JsonHelper.DeserializeObject<SearchFriendResponseModel>(responseMess.content);
                    searchFormFriend.SerarchFriendsResult(responseModel);
                }
                else if (messType == MessType.SendChatMess)
                {

                }
                else if (messType == MessType.EditInfo) {
                    EditInfoResponseModel respondeModel = JsonHelper.DeserializeObject<EditInfoResponseModel>(responseMess.content);
                    if (respondeModel.state == 1)
                    {
                        SystemHelper.currentUser.age = respondeModel.age;
                        SystemHelper.currentUser.blood = respondeModel.blood;
                        SystemHelper.currentUser.conste = respondeModel.conste;
                        SystemHelper.currentUser.faceimg = respondeModel.faceimg;
                        SystemHelper.currentUser.gender = respondeModel.gender;
                        SystemHelper.currentUser.nickname = respondeModel.nickname;
                        if (mainForm != null && mainForm.IsHandleCreated) {
                            mainForm.Invoke(new Action(()=> {
                                mainForm.ShowSelfInfo();
                            }));
                            Application.DoEvents();
                        }
                    }
                    else {
                        MessageBox.Show("用户信息修改失败!");
                    }
                }
            }
            catch (Exception err) {
                MessageBox.Show(err.ToString(),"OnMessageError");
            }

        }

        private static void SysMessHandler(GetSysMessResponseModel responseModel)
        {
            int MessType = responseModel.sysMessType;
            if (MessType == 0 || MessType == 1 || MessType == 2 || MessType == 3)
            {
                mainForm.Invoke(new Action(() =>
                {
                    SysMessForm requestForm = new SysMessForm(responseModel);
                    requestForm.Show();
                }));
                if (MessType == 2) {
                    GetFriendsRequestModel requestModel = new GetFriendsRequestModel();
                    requestModel.targetId = responseModel.fromId;
                    GetFriends(requestModel, mainForm);
                }
            }
            else if (MessType == 4)
            {
                if (mainForm != null) {
                    mainForm.OffLineFriend(responseModel.fromId);
                }
            }
            else if (MessType == 5)
            {
                if (mainForm != null) {
                    mainForm.OnLineFriend(responseModel.fromId);
                    GetFriendsRequestModel requestModel = new GetFriendsRequestModel();
                    requestModel.targetId = responseModel.fromId;
                    GetFriends(requestModel, mainForm);
                }
            }
        }

        private static void Ws_OnOpen(object sender, EventArgs e)
        {
            currentState = 2;
        }

        private static void OnSuccessMessSend(CommonMess messModel)
        {
            if (messModel.messType == MessType.AddFriend)
            {

            }
            else if (messModel.messType == MessType.AgreeAddFriend)
            {

            }
            else if (messModel.messType == MessType.GetFriends)
            {

            }
            else if (messModel.messType == MessType.GetOffLineChatMess)
            {

            }
            else if (messModel.messType == MessType.GetSysMess)
            {

            }
            else if (messModel.messType == MessType.Login)
            {
                loginForm.SendOk();
            }
            else if (messModel.messType == MessType.LoginOut)
            {

            }
            else if (messModel.messType == MessType.Register)
            {
                registerForm.SendOK();
            }
            else if (messModel.messType == MessType.SearchFriend)
            {

            }
            else if (messModel.messType == MessType.SendChatMess)
            {

            }
        }

        private static void OnErrorMessSend(CommonMess messModel)
        {
            if (messModel.messType == MessType.AddFriend)
            {

            }
            else if (messModel.messType == MessType.AgreeAddFriend)
            {

            }
            else if (messModel.messType == MessType.GetFriends)
            {

            }
            else if (messModel.messType == MessType.GetOffLineChatMess)
            {

            }
            else if (messModel.messType == MessType.GetSysMess)
            {

            }
            else if (messModel.messType == MessType.Login)
            {
                loginForm.SendNo();
            }
            else if (messModel.messType == MessType.LoginOut)
            {

            }
            else if (messModel.messType == MessType.Register)
            {
                registerForm.SendNo();
            }
            else if (messModel.messType == MessType.SearchFriend)
            {

            }
            else if (messModel.messType == MessType.SendChatMess)
            {

            }
        }


    }
}
