using Common.Uitls.Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToText
{
    public partial class Form_SearchPhone : Form
    {
        public Form_SearchPhone()
        {
            InitializeComponent();
        }

        bool isstart = false;

        int p1 = 0, p2 = 0, p3 = 0, count = 0, index = 0;

        private void btn_start_Click(object sender, EventArgs e)
        {
            index = 0;
            try
            {
                p1 = Convert.ToInt32(txtp1.Text.Trim());
                p2 = Convert.ToInt32(txtp2.Text.Trim());
                p3 = Convert.ToInt32(txtp3.Text.Trim());
                index = p3;
                count = Convert.ToInt32(txtcount.Text.Trim());

            }
            catch
            {
                MessageBox.Show("请输入正确的数字!");
                return;
            }

            if (this.btn_start.Text == "1)开始生成")
            {



                isstart = true;
                btn_start.Text = "停止生成";


                Task task = Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(5);
                    StringBuilder sb = new StringBuilder();

                    while (isstart && index < count+p3 && index<10000)
                    {
                        if (txt_content.InvokeRequired)
                        {

                            sb.AppendFormat("{0}{1}{2}", p1, p2.ToString().PadLeft(4,'0'), index.ToString().PadLeft(4, '0'));
                            sb.Append("\n");

                            if (index % 50 == 0)
                            {
                                txt_content.Invoke(new Action(() =>
                                {

                                    txt_content.Text = sb.ToString();
                                    txt_content.SelectionStart = txt_content.TextLength;
                                    txt_content.Focus();

                                }));
                            }
                        }
                        index += 1;
                    }

                    if (index == count)
                    {
                        MessageBox.Show("生成完成!");
                    }
                    else
                    {
                        MessageBox.Show("已停止生成!");
                    }
                    isstart = false;
                    btn_start.Invoke(new Action(() =>
                    {
                        btn_start.Text = "1)开始生成";
                    }));

                    txt_content.Invoke(new Action(() =>
                    {

                        txt_content.Text = sb.ToString();
                        txt_content.SelectionStart = txt_content.TextLength;
                        txt_content.Focus();

                    }));

                    sb = null;

                });

            }
            else
            {
                isstart = false;
                btn_start.Text = "1)开始生成";

            }

        }
        bool IsRegister = false;
        private void btn_export_Click(object sender, EventArgs e)
        {
            IsRegister = Utils.IsRegister();
            if (isstart)
            {
                MessageBox.Show("请先停止生成!");
                return;
            }

            if (!IsRegister)
            {
                MessageBox.Show("软件未激活，请先激活！点击首页的激活按钮，将机器码通过微信发给作者，索要注册码！");
                return;
            }

            if (txt_content.Text.Trim() == "")
            {
                MessageBox.Show("内容为空，无法导出；请先搜索");
                return;
            }
            this.btn_export.Text = "2)正在导出";
            this.btn_export.Enabled = false;
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
            List<string> list = txt_content.Text.Trim().Split('\n').ToList();
            if (list != null)
            {
                foreach (string item in list)
                {
                    DataRow dr = dt.NewRow();
                    dr["姓"] = "自定义的";
                    dr["家庭手机"] = item;
                    dr["其他地址"] = item;
                    dt.Rows.Add(dr);
                }
            }

            dt.AcceptChanges();
            filename = (filename.IndexOf(".xls") > -1 ? filename : filename + ".xls");
            //Task task = Task.Factory.StartNew(delegate { Utils.ExportExcel(dt, filename); });
            Task task = Task.Factory.StartNew(delegate { ExcelUils.TableToExcelForXLS(dt, filename); });
            task.Wait();
            dt = null;
            MessageBox.Show("已保存成功!  现在可以导入到通讯里了哦，点击右侧的按钮.");
            this.btn_export.Enabled = true;
            this.btn_export.Text = "2)导出结果";
        }

        private void btn_daoru_Click(object sender, EventArgs e)
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

        private void Form_SearchPhone_Load(object sender, EventArgs e)
        {

        }

        private void btn_jh_Click(object sender, EventArgs e)
        {

        }
    }
}
