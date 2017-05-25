using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Common.Uitls.Lib;
namespace ToText
{
    public partial class Form_Register : Form
    {
        public Form_Register()
        {
            InitializeComponent();
            this.txtregisterid.Text = Utils.GetEncodeCpuId();
            this.webBrowser1.Navigate(Environment.CurrentDirectory + "/reg.html");
            this.webBrowser1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cpuid = txtregisterid.Text.Trim();
            string content = txt_content.Text.Trim();

            //对比 
            string rightCode = Utils.GetLicence(cpuid);
            if (rightCode != content)
            {
                MessageBox.Show("注册码错误！不能激活的亲...");
            }
            else
            {
                File.Delete(Environment.CurrentDirectory + "\\license.ini");

                if (!File.Exists(Environment.CurrentDirectory + "\\license.ini"))
                {
                    FileStream fs = File.Create("license.ini");
                    fs.Close();
                }
                StreamWriter sw = new StreamWriter(Environment.CurrentDirectory + "\\license.ini");
                sw.Write(rightCode);
                sw.Close();

                MessageBox.Show("激活成功!");

                this.Close();
            }
        }
        public static string SCankey = "98989289182*&^%%)(<>?RTYUIOPGHJKLQWER12345890XCVBNM<>?";
        public static string ECankey = ")(*&0987654321ASDFGHJKLasdfghjklZXCVBNM,.-=0098776513edcb";


        private void btn_getcode_Click(object sender, EventArgs e)
        {
            string regid = txtregisterid.Text.Trim();
            if (string.IsNullOrEmpty(regid))
            {
                MessageBox.Show("机器码不能为空!");
                return;
            }

            int count = 35;
            string lastkey = SCankey + txtregisterid.Text.Trim() + ECankey;
            for (int i = 0; i < count; i++)
            {
                lastkey = Utils.EncryptedToSha(lastkey);
            }

            //调用系统默认的浏览器  
            //System.Diagnostics.Process.Start(string.Format("http://www.yigeceo.com/registecode?cpuid={0}&validcode={1}", regid, lastkey));

            webBrowser1.Document.GetElementById("btn_reg").SetAttribute("href", string.Format("http://www.yigeceo.com/registecode?cpuid={0}&validcode={1}", regid, lastkey));
            webBrowser1.Visible = true;
        }

        private void Form_Register_Load(object sender, EventArgs e)
        {
            //string regid = txtregisterid.Text.Trim();
            //int count = 35;
            //string lastkey = SCankey + txtregisterid.Text.Trim() + ECankey;
            //for (int i = 0; i < count; i++)
            //{
            //    lastkey = Utils.EncryptedToSha(lastkey);
            //} 

        }
    }
}
