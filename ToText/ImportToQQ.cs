using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToText
{
    public partial class ImportToQQ : Form
    {
        public ImportToQQ()
        {
            InitializeComponent();
            this.web_liu.IsWebBrowserContextMenuEnabled = true;
            this.web_liu.AllowWebBrowserDrop = false;


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        long index = 0;

        private void web_liu_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if (web_liu.DocumentText.IndexOf("删除全部分组") > -1 && e.Url.ToString().ToLower().IndexOf("ic.qq.com/pim/contact.jsp#import") == -1)
            {
                index += 1;
                if (index == 1)
                {
                    web_liu.Navigate("https://ic.qq.com/pim/contact.jsp#import");
                }
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.web_liu.Navigate("http://ic.qq.com/pim/login.jsp");
        }

        private void web_liu_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

            if (e.Url.ToString().ToLower().IndexOf("ic.qq.com/pim/contact.jsp#import") > -1)
            {
                //web_liu.Document.GetElementById("importType").Children[2].InvokeMember("Click");
            }

        }

        private void btn_toclick_Click(object sender, EventArgs e)
        {
            web_liu.Document.GetElementById("importType").Children[2].InvokeMember("onClick");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ImportToQQ_Load(object sender, EventArgs e)
        {
            Task task = Task.Factory.StartNew(() =>
            {
                this.web_liu.Invoke(new Action(delegate
                {
                    this.web_liu.Navigate("http://ic.qq.com/pim/login.jsp");
                }));

            });

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://ic.qq.com/pim/login.jsp");    
        }
    }
}
