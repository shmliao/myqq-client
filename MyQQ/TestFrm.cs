using MyQQ.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WebSocketSharp;

namespace MyQQ
{
    public partial class TestFrm : Form
    {
        public TestFrm()
        {
            InitializeComponent();
        }
        WebSocket ws = new WebSocket("ws://localhost:8888");
        private void button1_Click(object sender, EventArgs e)
        {

            ws.OnOpen += Ws_OnOpen;
            ws.OnError += Ws_OnError;
            ws.OnMessage += Ws_OnMessage;
            ws.OnClose += Ws_OnClose;
            ws.Connect();
        }

        private void Ws_OnClose(object sender, CloseEventArgs e)
        {
            appendUIText("This Close");
        }

        private void Ws_OnMessage(object sender, MessageEventArgs e)
        {
            appendUIText("This Message:"+e.Data);
        }

        private void Ws_OnError(object sender, ErrorEventArgs e)
        {
            appendUIText("This Error");
        }

        private void Ws_OnOpen(object sender, EventArgs e)
        {
            appendUIText("This Open");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ws.Send("hello server");
        }

        private void appendUIText(string mess) {
            textBox1.Invoke(new Action(()=> {
                textBox1.AppendText(mess+Environment.NewLine);
            }),null);
            Application.DoEvents();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CommonMess mess = new CommonMess();
            mess.messType = 0;
            mess.content = "系统消息";
            mess.action = m =>
            {

            };
            String json = JsonHelper.SerializeObject(mess);
            textBox1.Text = json;
        }
    }
}
