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

        // 窗体加载时，填充数据集
        private void SearchFriendForm_Load(object sender, EventArgs e)
        {
            pnlBaseResult.Visible = false;
            grpBaseCondition.Visible = true;
            btn3.Visible = false;
            btn2.Visible = false;
        }

        // 点击查找按钮时，查找符合条件的用户
        private void btnSearch_Click(object sender, EventArgs e)
        {
            PageIndex = 1;
            BasicallySearch();
        }

        // 添加好友
        private void btnAdd_Click(object sender, EventArgs e)
        {
            btn1.Visible = btn2.Visible = btn3.Visible = false;
            btn4.Text = "关闭";
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (btn1.Text == "返回") {
                pnlBaseResult.Visible = false;
                grpBaseCondition.Visible = true;
            }
        }
        private void btn2_Click(object sender, EventArgs e)
        {
            if (btn2.Text == "上一页") {
                if (PageIndex > 1) {
                    PageIndex -= 1;
                    BasicallySearch();
                }
            }
        }
        private void btn3_Click(object sender, EventArgs e)
        {
            if (btn3.Text == "下一页") {
                PageIndex++;
                BasicallySearch();
            }
        }
        private void btn4_Click(object sender, EventArgs e)
        {
            if (btn4.Text == "关闭")
            {
                this.Close();
            }
            else if(btn4.Text=="加为好友") {
                if (dgvBasicResult.SelectedRows.Count == 0)
                {
                    MessageBox.Show("请选择一个好友！", "操作", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                // 确保第一个单元格有值
                else if (dgvBasicResult.SelectedRows[0].Cells[0] != null)
                {
                    InputForm inputForm = new InputForm("请输入验证信息", "例如：我是...");
                    if (inputForm.ShowDialog() == DialogResult.OK) {
                        // 获得DataGridView中选中的行的第一个单元格的值
                        int friendId = int.Parse(dgvBasicResult.SelectedRows[0].Cells[0].Value.ToString());
                        string mess = inputForm.getInput();
                        AddFriend(friendId,mess);
                    }
                }
            }
        }


        // 返回到上一步
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (btn2.Text == "上一页")
            {

            }
            else {
                pnlBaseResult.Visible = false;
                pnlBaseCondition.Visible = true;
                btn2.Visible = false;
                btn3.Visible = false;
            }
        }

        // 关闭窗体
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 基本查找
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
            btn3.Visible = true;　　
            btn4.Visible = true;
            btn1.Text = "返回";
            btn2.Text = "上一页";
            btn3.Text = "下一页";
            btn4.Text = "加为好友";
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
        /// 获得选中的好友的Id
        /// </summary>        
        private int GetSelectedFriendId()
        {
            int friendId = -1;  // 好友的号码

            //// 基本查找
            //if (tabSearch.SelectedIndex == 0)
            //{
            //    // 没有选中任何一行
            //    if (dgvBasicResult.SelectedRows.Count == 0)
            //    {
            //        MessageBox.Show("请选择一个好友！", "操作", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    // 确保第一个单元格有值
            //    else if (dgvBasicResult.SelectedRows[0].Cells[0] != null)  
            //    {
            //        // 获得DataGridView中选中的行的第一个单元格的值
            //        friendId = int.Parse(dgvBasicResult.SelectedRows[0].Cells[0].Value.ToString());                   
            //    }
            //}
            //// 高级查找
            //else if (tabSearch.SelectedIndex == 1)
            //{
            //    if (dgvAdvancedResult.SelectedRows.Count == 0)
            //    {
            //        MessageBox.Show("请选择一个好友！", "操作", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    else if (dgvAdvancedResult.SelectedRows[0].Cells[0] != null)
            //    {
            //        friendId = int.Parse(dgvAdvancedResult.SelectedRows[0].Cells[0].Value.ToString());
            //    }
            //}

            return friendId;
        }

        /// <summary>
        /// 确认对方能否被加为好友
        /// </summary>        
        private int GetFriendshipPolicyId(int userId)
        {
            //int friendshipPolicyId = 1;  // 好友策略
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
        /// 执行添加好友的操作
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
            MessageBox.Show("好友申请发送成功");
        }

    }
}