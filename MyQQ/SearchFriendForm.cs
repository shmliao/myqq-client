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
    public partial class SearchFriendForm : Form
    {
        private int PageIndex = 1;
        public SearchFriendForm()
        {
            InitializeComponent();
            dgvBasicResult.AutoGenerateColumns = false;
        }

        // �������ʱ��������ݼ�
        private void SearchFriendForm_Load(object sender, EventArgs e)
        {
            pnlBaseResult.Visible = false;
            grpBaseCondition.Visible = true;
            btn3.Visible = false;
            btn2.Visible = false;
        }

        // ������Ұ�ťʱ�����ҷ����������û�
        private void btnSearch_Click(object sender, EventArgs e)
        {
            PageIndex = 1;
            BasicallySearch();
        }

        // ��Ӻ���
        private void btnAdd_Click(object sender, EventArgs e)
        {
            btn1.Visible = btn2.Visible = btn3.Visible = false;
            btn4.Text = "�ر�";
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (btn1.Text == "����") {
                pnlBaseResult.Visible = false;
                grpBaseCondition.Visible = true;
            }
        }
        private void btn2_Click(object sender, EventArgs e)
        {
            if (btn2.Text == "��һҳ") {
                if (PageIndex > 1) {
                    PageIndex -= 1;
                    BasicallySearch();
                }
            }
        }
        private void btn3_Click(object sender, EventArgs e)
        {
            if (btn3.Text == "��һҳ") {
                PageIndex++;
                BasicallySearch();
            }
        }
        private void btn4_Click(object sender, EventArgs e)
        {
            if (btn4.Text == "�ر�")
            {
                this.Close();
            }
            else if(btn4.Text=="��Ϊ����") {
                if (dgvBasicResult.SelectedRows.Count == 0)
                {
                    MessageBox.Show("��ѡ��һ�����ѣ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                // ȷ����һ����Ԫ����ֵ
                else if (dgvBasicResult.SelectedRows[0].Cells[0] != null)
                {
                    InputForm inputForm = new InputForm("��������֤��Ϣ", "���磺����...");
                    if (inputForm.ShowDialog() == DialogResult.OK) {
                        // ���DataGridView��ѡ�е��еĵ�һ����Ԫ���ֵ
                        int friendId = int.Parse(dgvBasicResult.SelectedRows[0].Cells[0].Value.ToString());
                        string mess = inputForm.getInput();
                        AddFriend(friendId,mess);
                    }
                }
            }
        }


        // ���ص���һ��
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (btn2.Text == "��һҳ")
            {

            }
            else {
                pnlBaseResult.Visible = false;
                pnlBaseCondition.Visible = true;
                btn2.Visible = false;
                btn3.Visible = false;
            }
        }

        // �رմ���
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// ��������
        /// </summary>
        private void BasicallySearch()
        {
           
            string nickName = txtNickName.Text.Trim();
            SearchFriendRequestModel requestModel = new SearchFriendRequestModel();
            requestModel.id = SystemHelper.currentUser.id;
            requestModel.keyWord = txtNickName.Text.Trim();
            requestModel.pageIndex = PageIndex;
            requestModel.pageSize = 5;
            SystemHelper.SearchFriends(requestModel,this);
            pnlBaseResult.Location = pnlBaseCondition.Location;
            pnlBaseResult.Visible = true;
            grpBaseCondition.Visible = false;
            btn1.Visible = true;
            btn2.Visible = true;
            btn3.Visible = true;����
            btn4.Visible = true;
            btn1.Text = "����";
            btn2.Text = "��һҳ";
            btn3.Text = "��һҳ";
            btn4.Text = "��Ϊ����";
        }


        public void SerarchFriendsResult(SearchFriendResponseModel respondeModel) {
            this.Invoke(new Action(()=> {
                if (PageIndex == respondeModel.dataList.pageCount)
                {
                    btn3.Enabled = false;
                }
                else
                {
                    btn3.Enabled = true;
                }
                if (PageIndex > 1)
                {
                    btn2.Enabled = true;
                }
                else
                {
                    btn2.Enabled = false;
                }
                dgvBasicResult.DataSource = respondeModel.dataList.data;
            }));
        }

        /// <summary>
        /// ���ѡ�еĺ��ѵ�Id
        /// </summary>        
        private int GetSelectedFriendId()
        {
            int friendId = -1;  // ���ѵĺ���

            //// ��������
            //if (tabSearch.SelectedIndex == 0)
            //{
            //    // û��ѡ���κ�һ��
            //    if (dgvBasicResult.SelectedRows.Count == 0)
            //    {
            //        MessageBox.Show("��ѡ��һ�����ѣ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    // ȷ����һ����Ԫ����ֵ
            //    else if (dgvBasicResult.SelectedRows[0].Cells[0] != null)  
            //    {
            //        // ���DataGridView��ѡ�е��еĵ�һ����Ԫ���ֵ
            //        friendId = int.Parse(dgvBasicResult.SelectedRows[0].Cells[0].Value.ToString());                   
            //    }
            //}
            //// �߼�����
            //else if (tabSearch.SelectedIndex == 1)
            //{
            //    if (dgvAdvancedResult.SelectedRows.Count == 0)
            //    {
            //        MessageBox.Show("��ѡ��һ�����ѣ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    else if (dgvAdvancedResult.SelectedRows[0].Cells[0] != null)
            //    {
            //        friendId = int.Parse(dgvAdvancedResult.SelectedRows[0].Cells[0].Value.ToString());
            //    }
            //}

            return friendId;
        }

        /// <summary>
        /// ȷ�϶Է��ܷ񱻼�Ϊ����
        /// </summary>        
        private int GetFriendshipPolicyId(int userId)
        {
            //int friendshipPolicyId = 1;  // ���Ѳ���
            //string sql = "SELECT FriendshipPolicyId FROM Users WHERE Id=" + userId;
            //try
            //{
            //    SqlCommand command = new SqlCommand(sql, DBHelper.connection);
            //    DBHelper.connection.Open();

            //    friendshipPolicyId = Convert.ToInt32(command.ExecuteScalar());
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //finally
            //{
            //    DBHelper.connection.Close();
            //}
            //return friendshipPolicyId;
            return 0;
        }

 

        /// <summary>
        /// ִ����Ӻ��ѵĲ���
        /// </summary>        
        private void AddFriend(int friendId,string mess)
        {
            AddFriendRequestModel requestModel = new AddFriendRequestModel();
            requestModel.id = SystemHelper.currentUser.id;
            requestModel.mess =mess;
            requestModel.targetId = friendId;
            SystemHelper.AddFriend(requestModel,this);
        }

        public void AddFriendOK() {
            MessageBox.Show("�������뷢�ͳɹ�");
        }

    }
}