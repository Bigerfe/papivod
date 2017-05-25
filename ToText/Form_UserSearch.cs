using Common.Uitls.Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToText
{
    public partial class Form_UserSearch : Form
    {
        public Form_UserSearch()
        {
            InitializeComponent();
        }

        private void Form_UserSearch_Load(object sender, EventArgs e)
        {
            this.webBrowser1.ScriptErrorsSuppressed = true;

            this.webBrowser1.Navigate("https://www.baidu.com/");

        }

        static Object ObjectData = new object();

        Queue<string> urlList = new Queue<string>();

        bool IsRegister = false;
        private void button2_Click(object sender, EventArgs e)
        {
            IsRegister = Utils.IsRegister();
            if (!IsRegister)
            {
                MessageBox.Show("软件未激活，请先激活！");
                return;
            }

            if (txtresult.Text.Trim() == "")
            {
                MessageBox.Show("内容为空，无法导出；请先搜索");
                return;
            }

            if (isStart)
            {
                MessageBox.Show("请先停止搜索,然后再导出!");
                return;
            }

            MessageBox.Show("导出时，数据需要处理请不要着急....,静静的等待一个好的结果");

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "表格文件（*.xls）|";
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;
            DialogResult drs = dialog.ShowDialog();
            string filename = "";
            if (drs == System.Windows.Forms.DialogResult.OK)
            {
                filename = dialog.FileName;
            }
            else
            {
                return;
            }


            //组合数据
            DataTable dt = new DataTable();
            dt.Columns.Add("姓", typeof(string));
            dt.Columns.Add("名", typeof(string));
            dt.Columns.Add("昵称", typeof(string));
            dt.Columns.Add("QQ号", typeof(string));
            dt.Columns.Add("家庭手机", typeof(string));
            dt.Columns.Add("工作手机", typeof(string));
            dt.Columns.Add("其他手机", typeof(string));
            dt.Columns.Add("家庭电话", typeof(string));
            dt.Columns.Add("工作电话", typeof(string));
            dt.Columns.Add("其他电话", typeof(string));
            dt.Columns.Add("家庭传真", typeof(string));
            dt.Columns.Add("工作传真", typeof(string));
            dt.Columns.Add("公司/部门", typeof(string));
            dt.Columns.Add("家庭地址", typeof(string));
            dt.Columns.Add("工作地址", typeof(string));
            dt.Columns.Add("其他地址", typeof(string));
            dt.Columns.Add("备注", typeof(string));
            dt.Columns.Add("电子邮件", typeof(string));
            dt.Columns.Add("家庭邮箱", typeof(string));
            dt.Columns.Add("办公邮箱", typeof(string));
            dt.Columns.Add("网址", typeof(string));
            dt.Columns.Add("家庭网址", typeof(string));
            dt.Columns.Add("办公网址", typeof(string));
            dt.Columns.Add("生日", typeof(string));
            dt.Columns.Add("职务", typeof(string));
            List<string> list = txtresult.Text.Trim().Split('\n').ToList();
            if (list != null)
            {
                foreach (string item in list)
                {
                    DataRow dr = dt.NewRow();
                    dr["姓"] = item;
                    dr["家庭手机"] = item;
                    dr["其他地址"] = item;
                    dt.Rows.Add(dr);
                }
            }

            dt.AcceptChanges();

            filename = (filename.IndexOf(".xls") > -1 ? filename : filename + ".xls");
            Task task = Task.Factory.StartNew(delegate { ExcelUils.TableToExcelForXLS(dt, filename); });
            task.Wait();
            dt = null;
            MessageBox.Show("已保存成功!  现在可以导入到通讯里了哦，点击右侧的按钮.");
        }

        string searchUrl = "https://www.baidu.com/s?wd={0}&pn={1}&oq={2}&tn=baiduhome_pg&ie=utf-8";
        string key = "";
        bool isStart = false;
        Regex regMsg = new Regex("(13[0-9]|15[0-9]|18[7-9])-?[0-9]{4}-?[0-9]{4}", RegexOptions.IgnoreCase);
        private void button1_Click(object sender, EventArgs e)
        {
            key = webBrowser1.Document.GetElementById("kw").GetAttribute("value");
            if (string.IsNullOrEmpty(key))
            {
                MessageBox.Show("请输入搜索的关键词");
                return;
            }
            webBrowser1.Document.GetElementById("su").InvokeMember("click");

            if (!isStart)
            {
                isStart = true;

                this.button1.Text = "停止搜索";
                string content = "";
                Thread thread = new Thread(() =>
                {
                    int pindex = 0;

                    while (isStart)
                    {
                        if (!isStart)
                        {
                            break;
                        }

                        if (this.webBrowser1.InvokeRequired)
                        {
                            this.webBrowser1.Invoke(new Action(() =>
                            {
                                // this.webBrowser1.Refresh();
                                this.webBrowser1.Navigate(new Uri(string.Format(searchUrl, key, pindex * 10, key)));

                            }));
                        }

                        Thread.Sleep(2000);

                        if (this.webBrowser1.InvokeRequired)
                        {
                            this.webBrowser1.Invoke(new Action(() =>
                            {
                                content = this.webBrowser1.Document.GetElementById("content_left").InnerHtml;

                            }));
                        }
                        
                        //设置url
                        SetUrlToQue(content);
                        //if (urlList.Count > 0)
                        //    MessageBox.Show(urlList.Dequeue());

                        Thread.Sleep(2000);

                        pindex += 1;
                    }

                    MessageBox.Show("已停止搜索");

                });

                thread.Start();
                thread.Join(10);

                try
                {

                    int scount = 0;
                    Thread threadCon = new Thread(() =>
                    {
                        string url = "";
                        while (isStart)
                        {
                            if (!isStart)
                            {
                                break;
                            }

                            lock (ObjectData)
                            {
                                if (urlList.Count > 0)
                                {
                                    url = urlList.Dequeue();
                                }
                            }

                            if (string.IsNullOrEmpty(url))
                            {
                                Thread.Sleep(3000);
                                continue;
                            }

                            Thread.Sleep(300);

                            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                            req.Method = "GET";
                            req.Timeout = 4000;
                            req.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.118 Safari/537.36";

                            req.BeginGetResponse(ar =>
                            {
                                try
                                {
                                    IAsyncResult ir = ar;
                                    HttpWebRequest wr = (HttpWebRequest)ar.AsyncState;
                                    HttpWebResponse res = (HttpWebResponse)wr.EndGetResponse(ir);

                                    Stream resStream = res.GetResponseStream();

                                    StreamReader sr = new StreamReader(resStream);
                                    string result = sr.ReadToEnd();
                                    sr.Close();

                                    resStream.Close();

                                    MatchCollection colls = regMsg.Matches(result);
                                    if (txtresult.InvokeRequired)
                                    {
                                        txtresult.Invoke(new Action(() =>
                                        {
                                            if (colls != null && colls.Count > 0)
                                            {
                                                foreach (Match item in colls)
                                                {
                                                    if (!string.IsNullOrEmpty(item.Value))
                                                    {
                                                        if (txtresult.Text.IndexOf(item.Value) == -1)
                                                        {
                                                            txtresult.AppendText(item.Value.Replace("-",""));
                                                            txtresult.AppendText("\n");

                                                            txtresult.SelectionStart = txtresult.TextLength;
                                                            txtresult.ScrollToCaret();
                                                            scount += 1;
                                                            la_scount.Text = scount.ToString();
                                                        }
                                                    } 
                                                }
                                            }

                                        }));
                                    }

                                }
                                catch (Exception ex)
                                {
                                    //MessageBox.Show(ex.ToString());
                                }

                            }, req);
                        }

                    });

                    threadCon.Start();

                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.ToString());
                }

            }
            else
            {
                if (MessageBox.Show("确定停止搜索吗？再次搜索将会从重新搜索!", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    isStart = false;
                    this.button1.Text = "1.开始搜索";

                }
             }
        }

        private void SetUrlToQue(string content)
        {
            if (!string.IsNullOrEmpty(content.Trim()))
            {
                Regex reg = new Regex("http://www.baidu.com[^\\s]*", RegexOptions.IgnoreCase);

                MatchCollection coll = reg.Matches(content);

                if (coll != null && coll.Count > 0)
                {
                    foreach (Match item in coll)
                    {
                        lock (ObjectData)
                        {
                            urlList.Enqueue(item.Value.Replace("\"", ""));
                        }
                    }
                }
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //将所有的链接的目标，指向本窗体
            foreach (HtmlElement archor in this.webBrowser1.Document.Links)
            {
                archor.SetAttribute("target", "_self");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            IsRegister = Utils.IsRegister();
            if (!IsRegister)
            {
                MessageBox.Show("软件未激活，导入通讯录请先激活！点击首页的激活按钮，将机器码通过微信发给作者，索要注册码！");
                return;
            }


            ImportToQQ form = new ImportToQQ();
            form.Owner = this;
            form.Show();
        }
    }
}
