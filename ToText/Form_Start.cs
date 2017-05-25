using Common.Uitls.Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToText
{
    public partial class Form_Start : Form
    {
        public Form_Start()
        {
            InitializeComponent();
        }

        private void btn_specialsearch_Click(object sender, EventArgs e)
        {
            Form_ExtendData form = new Form_ExtendData();
            form.Owner = this;
            form.Show();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            Form_SearchPhone form = new Form_SearchPhone();
            form.Owner = this;
            form.Show();

            //Form_AreaTel form = new Form_AreaTel();
            //form.Owner = this;
            //form.Show();

        }

        private void btn_keysearch_Click(object sender, EventArgs e)
        {
            MessageBox.Show("开发中，敬请期待");
        }

        private void btn_jh_Click(object sender, EventArgs e)
        {
            IsRegister = Utils.IsRegister();
            if (IsRegister)
            {
                btn_jh.Text = "已激活";
                btn_jh.Enabled = false;
                return;
            }

            Form_Register form = new Form_Register();
            form.Owner = this;
            form.ShowDialog();
        }
        bool IsRegister = false;
        private void Form_Start_Load(object sender, EventArgs e)
        {
            try
            {
                IsRegister = Utils.IsRegister();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());         
            }
            if (IsRegister)
            {
                this.btn_jh.Text = "软件已激活";
                this.btn_jh.Enabled = false;
            }
            else
            {
                this.btn_jh.Enabled = true;
            }
        }

        private void btn_customsearch_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("功能正在开发，敬请期待");

            //return;
            Form_UserSearch form = new Form_UserSearch();
            form.Owner = this;
            form.Show();
        }

        private void btn__Click(object sender, EventArgs e)
        {
             //调用系统默认的浏览器 
            System.Diagnostics.Process.Start("http://www.yigeceo.com/");
        }


    }
}
