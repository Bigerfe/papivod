using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using PagerUtility;
using Linda.DAL;
using Linda.Entity;
using Linda.DAL.IServer;
namespace Easo.Web.DBMS.MsNews
{

    public partial class NewsClass : AdminPage
    {

        DalTb_Easo_NewClass dal = new DalTb_Easo_NewClass();

        Tb_Easo_NewClass md = new Tb_Easo_NewClass();

        SetPager_PostBack post = new SetPager_PostBack();
        string tbname = "Tb_Easo_NewClass";
        string key = "id";
        string sql = "1=1 ";

        string action = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            action = CRequest.GetString("action");
            if (!IsPostBack)
            {

                if (action == "update")
                {
                    int cid = CRequest.GetInt("cid",0);
                    if (cid <= 0)
                        Jscript.WriteInfo("请输入新闻id");
                    md = dal.GetModel(cid);
                    if (md == null)
                    {
                        Jscript.WriteInfo("返回的数据位null");
                    }
                    else {

                        lamsg.Text = "修改信息";
                        btnadd.Text = "提交更改";
                        ViewState["id"] = cid;

                        txtdes.Text = md.Description;
                        txtname.Text = md.CName;
                        txtsort.Text = md.OrderNum.ToString();
                    }
                }
                else if (action == "delete")
                {
                    int cid = CRequest.GetInt("cid", 0);
                    if (cid <= 0)
                    {
                        Jscript.WriteInfo("输入的id不存在");
                    }
                    else
                    {
                        dal.Delete(cid);
                        Jscript.AlertAndRedirect("删除成功.", "NewsClass.aspx");
                    }
                }

                post.InitBindData(this.GridView1, this.AspNetPager1, tbname, key, sql, key);
            }
            
        }

        protected void AspNetPager1_PageChanged1(object sender, EventArgs e)
        {
            post.SecondBindData(this.GridView1, this.AspNetPager1, tbname, key, sql, key);
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            md.CName = txtname.Text.Trim();
            md.Description = txtdes.Text.Trim();
            md.OrderNum = Utils.StrToInt(txtsort.Text.Trim());

            if (action == "")
            {
                if (dal.Add(md) > 0)
                {
                    Jscript.AlertAndRedirect("添加成功.", this.Request.RawUrl);
                }
            }
            else if (action == "update")
            {
                md.ID = Utils.StrToInt(ViewState["id"].ToString());

                if (dal.Update(md) > 0)
                {
                    Jscript.AlertAndRedirect("修改成功.", this.Request.RawUrl);
                }
            }
        }
    }
}
