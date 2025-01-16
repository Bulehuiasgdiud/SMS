﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SMS.Views
{
    public partial class FormDept : SMS.Views.FormBase
    {
        public FormDept()
        {
            InitializeComponent();
        }

        public override void button1_Click(object sender, EventArgs e)
        {
            studentMS.BLL.core bll = new studentMS.BLL.core();
            this.dataGridView1.DataSource = bll.GetDeptList(this.textBox1.Text.Trim())
                .Tables[0]
                .DefaultView;
        }
    }
}