﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMS
{
    public partial class FormStudent : Form
    {
        public FormStudent()
        {
            InitializeComponent();
        }

        private void buttonQuery_Click(object sender, EventArgs e)
        {
            studentMS.BLL.core bll = new studentMS.BLL.core(); //实例化BLL层的对象
            this.dataGridView1.DataSource = bll.GetStudentList(
                    this.textBoxSNO.Text.Trim(),
                    this.textBoxSName.Text.Trim()
                )
                .Tables[0]
                .DefaultView;
        }

        private void MenuItemAdd_Click(object sender, EventArgs e)
        {
            //弹出新增界面
            FormStudentEdit frm = new FormStudentEdit();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                MessageBox.Show(
                    this,
                    "新增学生档案成功!\n",
                    "友情提示",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                this.buttonQuery_Click(this.buttonQuery, e);
                return;
            }
        }

        private void MenuItemEdit_Click(object sender, EventArgs e)
        {
            string sno = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            FormStudentEdit frm = new FormStudentEdit(sno);
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                MessageBox.Show(
                    this,
                    "修改学生档案成功!\n",
                    "友情提示",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                this.buttonQuery_Click(this.buttonQuery, e);
                return;
            }
        }

        private void MenuItemDelete_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show(
                    this,
                    "您确定要删除所选的记录吗？\n",
                    "删除确认",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question
                ) == DialogResult.OK
            )
            {
                string sno = this.dataGridView1.SelectedRows[0].Cells["SNO"].Value.ToString();
                studentMS.BLL.student bll = new studentMS.BLL.student(); //实例化BLL层的对象
                try
                {
                    bll.Delete(sno);
                    this.buttonQuery_Click(this.buttonQuery, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        this,
                        "删除失败！\n" + ex.Message,
                        "出错啦",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }
            }
        }
    }
}
