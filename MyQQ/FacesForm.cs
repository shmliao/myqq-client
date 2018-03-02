using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyQQ
{
    /// <summary>
    /// 头像选择窗体
    /// </summary>
    public partial class FacesForm : Form
    {
        private EditInfoForm infoForm = null;
        public FacesForm(EditInfoForm infoForm)
        {
            InitializeComponent();
            this.infoForm = infoForm;
        }        

        // 窗体加载时显示头像图片
        private void FacesForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < ilFaces.Images.Count; i++)
            {
                lvFaces.Items.Add(i.ToString());
                lvFaces.Items[i].ImageIndex = i;  
            } 
        }       

        // 确定选择头像
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lvFaces.SelectedItems.Count == 0)
            {
                this.Close();
            }
            else
            {
                int faceId = lvFaces.SelectedItems[0].ImageIndex;  
                infoForm.ShowFace(faceId);
                this.Close(); 
            }            
        }


        // 关闭窗体
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}