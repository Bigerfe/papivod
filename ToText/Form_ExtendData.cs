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
    public partial class Form_ExtendData : Form
    {
        public Form_ExtendData()
        {
            InitializeComponent();
            this.comboxdatatype.SelectedIndex = 0;
            this.comboxsex.SelectedIndex = 0;
            this.comboxarea.SelectedIndex = 0;
        }

        bool IsRegister = false;

        private void Form_ExtendData_Load(object sender, EventArgs e)
        { 
        }

        Thread thread;
        bool isStart = false;
        string comboxdata = "";
        string sex = ""; string ptype = "";
        private void button1_Click(object sender, EventArgs e)
        {
           
            ptype = this.comboxdatatype.SelectedItem.ToString();//信息类型
            comboxdata = this.comboxarea.SelectedItem.ToString();
            sex = this.comboxsex.SelectedItem.ToString();
            if (!isStart)
            {
                isStart = true;
                thread = new Thread(StartGetData);
                thread.Start();
                thread.Join(10);

                this.button1.Text = "点击停止";
            }
            else
            {
                this.button1.Text = "开始搜索";
                isStart = false;
            }
        }

        /// <summary>
        /// 获得url
        /// </summary>
        /// <param name="areaname"></param>
        /// <returns></returns>
        string GetSearchUrl(string areaname, int pageindex = 1)
        {
            string url = "http://{0}.zu.anjuke.com/fangyuan/{1}l2{2}/";

            string temp = "", page = "", prefix = "";
            if (pageindex > 1)
            {
                page = "-p" + pageindex;
            }
            if (areaname.IndexOf("(全部)") > -1)
            {
                prefix = prefix = areaname.Split('-')[1];
            }

            if (page == "-p1")
            {
                page = "";
            }
            if (prefix == "")
            {
                prefix = areaname.Split('-')[2];
            }
            if (ptype.IndexOf("中介") > -1)
            {
                url = url.Replace("l2","l1");
            }

            if (areaname.IndexOf("-c") > -1)
            {
                return string.Format(url, prefix, "", "p" + page).Replace("l2", "");
            }
            else
            {
                //MessageBox.Show(string.Format(url, prefix, areaname.Split('-')[1] + "-", page));

                //richTextBox1.Text = string.Format(url, prefix, areaname.Split('-')[1] + "-", page);
                return string.Format(url, prefix, areaname.Split('-')[1] + "-", page);
            }
        }

        /// <summary>  
        /// 获取页面类容  
        /// </summary>  
        /// <param name="strUrl"></param>  
        /// <returns></returns>  
        string GetHtml(string strUrl)
        {

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(strUrl);
            req.Method = "GET";
            req.Accept = "text/html";
            req.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; Trident/4.0)";
            string html = "";
            try
            {

                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                using (StreamReader reader = new StreamReader(res.GetResponseStream()))
                {
                    html = reader.ReadToEnd();
                }
                return html;

            }
            catch (WebException we)
            {
                return html;
                throw new Exception(we.Message);
            }

        }

        /// <summary>
        /// 获得列表页的url列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        List<string> GetListPageUrls(string data)
        {
            Regex regex = new Regex("link=\"(http.*[^\"])\"", RegexOptions.IgnoreCase);
            MatchCollection mtch = regex.Matches(data);
            if (mtch != null)
            {
                List<string> list = new List<string>();
                foreach (Match item in mtch)
                {
                    list.Add(item.Groups[1].Value);
                }
                return list;
            }
            return null;
        }

        /// <summary>
        /// 获得联系人
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        string[] Phone(string data)
        {
            string[] str = { "", "", "", "" };
            Regex reg = new Regex("<span id=\"broker_true_name\".*[^>]>(.*[^<])</span>", RegexOptions.IgnoreCase);
            Match mtch = reg.Match(data);
            if (mtch != null)
            {
                str[0] = mtch.Groups[1].Value;
                if (!string.IsNullOrEmpty(str[0]))
                {
                    str[2] = str[0].Substring(0, 1) + "**";
                }
            }

            reg = new Regex(@"\d{3}\s{1}\d{4}\s{1}\d{4}", RegexOptions.IgnoreCase);
            Match mtch1 = reg.Match(data);
            if (mtch1 != null)
            {
                str[1] = mtch1.Groups[0].Value.Replace(" ", "");

            }

            reg = new Regex("发布时间：(.*[^<])</div>", RegexOptions.IgnoreCase);
            Match mtch2 = reg.Match(data);
            if (mtch2 != null)
            {
                str[3] = mtch2.Groups[1].Value;
            }
            return str;
        }

        void StartGetData()
        {
            int resultCount = 0;
            string listurl = "";
            string pagedata = "";
            List<string> urls = null;
            int pageindex = 1;
            string[] contact;
            while (isStart && pageindex > 0)
            {
                listurl = GetSearchUrl(comboxdata, pageindex);
                if (listurl == null)
                {
                    pageindex = 0;
                    break;
                }
                Thread.Sleep(200);

                urls = new List<string>();
                pagedata = GetHtml(listurl);
                urls = GetListPageUrls(pagedata);

                foreach (string ul in urls)
                {
                    //获取电话和联系人名称
                    contact = Phone(GetHtml(ul));

                    if (this.richTextBox1.InvokeRequired)
                    {
                        this.richTextBox1.Invoke(new EventHandler(delegate
                        {
                            if (contact != null)
                            {
                                if (contact[1] != "")
                                {
                                    if (sex == "性别")
                                    {
                                        //this.richTextBox1.Text += contact[2] + "\t\t\t\t\t" + contact[1] + "\t\t\t\t\t\t\t" + contact[3];
                                        this.richTextBox1.Text += contact[2] + "-" + contact[1] + "-" + contact[3];
                                        this.richTextBox1.Text += "\n";
                                        resultCount += 1;
                                        SetShowCount(resultCount);
                                    }
                                    else if (sex == "男")
                                    {
                                        if (contact[0].IndexOf("先生") > -1)
                                        {
                                            //this.richTextBox1.Text += contact[2] + "\t\t\t\t\t" + contact[1] + "\t\t\t\t\t\t\t" + contact[3];
                                            this.richTextBox1.Text += contact[2] + "-" + contact[1] + "-" + contact[3];

                                            this.richTextBox1.Text += "\n"; resultCount += 1;
                                            SetShowCount(resultCount);
                                        }
                                    }
                                    else if (sex == "女")
                                    {
                                        if (contact[0].IndexOf("女士") > -1 || (contact[0].IndexOf("小姐") > -1))
                                        {
                                            //this.richTextBox1.Text += contact[2] + "\t\t\t\t\t" + contact[1] + "\t\t\t\t\t\t\t" + contact[3];
                                            this.richTextBox1.Text += contact[2] + "-" + contact[1] + "-" + contact[3];
                                            this.richTextBox1.Text += "\n"; resultCount += 1;
                                            SetShowCount(resultCount);
                                        }
                                    }
                                    else
                                    {
                                        if (contact[0].IndexOf("先生") == -1 && contact[0].IndexOf("小姐") == -1 && contact[0].IndexOf("女士") == -1)
                                        {
                                            //this.richTextBox1.Text += contact[2] + "\t\t\t\t\t" + contact[1] + "\t\t\t\t\t\t\t" + contact[3];

                                            this.richTextBox1.Text += contact[2] + "-" + contact[1] + "-" + contact[3];
                                            this.richTextBox1.Text += "\n"; resultCount += 1;
                                            SetShowCount(resultCount);
                                        }
                                    }

                                }
                            }

                        }), null);
                    }
                    if (!isStart)
                    {
                        break;
                    }
                }

                pageindex += 1;
            }

            if (this.button1.InvokeRequired)
            {
                this.button1.Invoke(new Action(() =>
                {
                    this.button1.Text = "已停止搜索";
                }));
            }

        }

        void SetShowCount(int count)
        {
            lable_count.Text = string.Format("已从云端搜索出 {0} 条数据", count);
        }

        private void btn_copy_Click(object sender, EventArgs e)
        {
            //
            if (richTextBox1.Text != "")
            {
                Clipboard.SetDataObject(richTextBox1.Text);
                MessageBox.Show("内容已复制到剪贴板，您可以通过 Ctrl+V 进行粘贴");
            }

        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定清空数据吗？清空后就没了", "提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                richTextBox1.Text = "";
            }
        }

        private void btn_todaoru_Click(object sender, EventArgs e)
        {
            IsRegister = Utils.IsRegister();
            if (!IsRegister)
            {
                MessageBox.Show("软件未激活，导入通讯录请先激活！ 将机器码通过微信发给作者，索要注册码！");
                return;
            }


            ImportToQQ form = new ImportToQQ();
            form.Owner = this;
            form.Show();
        }

        private void btn_extend_Click(object sender, EventArgs e)
        {
            IsRegister = Utils.IsRegister();
            if (!IsRegister)
            {
                MessageBox.Show("软件未激活，请先激活！");
                return;
            }

            if (richTextBox1.Text.Trim() == "")
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
            List<string> list = richTextBox1.Text.Trim().Split('\n').ToList();
            if (list != null)
            {
                foreach (string item in list)
                {
                    DataRow dr = dt.NewRow();
                    dr["姓"] = item.Split('-')[0];
                    dr["家庭手机"] = item.Split('-')[1];
                    dr["其他地址"] = item.Split('-')[2];
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

        private void btn_jh_Click(object sender, EventArgs e)
        {
            Form_Register form = new Form_Register();
            form.Owner = this;
            form.ShowDialog(); 
        }

        private void comboxdatatype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboxdatatype.SelectedIndex == 1)
            {
                this.comboxsex.Enabled = false;
                this.comboxsex.SelectedIndex = 0;

            }
            else
            {
                this.comboxsex.Enabled = true;
            }
        }

    }
}
