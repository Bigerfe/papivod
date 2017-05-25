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

    public partial class Zhiyuan : AdminPage
    {

        DalTb_Easo_NewClass dal = new DalTb_Easo_NewClass();

        Tb_Easo_NewClass md = new Tb_Easo_NewClass();

        SetPager_PostBack post = new SetPager_PostBack();
        string tbname = "Tb_Easo_NewClass";
        string key = "id";
        string sql = "1=1 ";

        string action = "";
        protected int typeid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            action = CRequest.GetString("action");

            typeid = CRequest.GetInt("typeid", 0);

            if (typeid <= 0)
                Jscript.WriteInfo("类型id为空");

            if (!IsPostBack)
            {
                if (action == "update")
                {
                    int cid = CRequest.GetInt("cid", 0);
                    if (cid <= 0)
                        Jscript.WriteInfo("请输入新闻id");
                    md = dal.GetModel(cid);
                    if (md == null)
                    {
                        Jscript.WriteInfo("返回的数据位null");
                    }
                    else
                    {

                        lamsg.Text = "修改信息";
                        btnadd.Text = "提交更改";
                        ViewState["id"] = cid;
                        btncancle.Visible = true;

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
                        Response.Redirect("sNewsClass.aspx?typeid=" + typeid);
                        return;
                    }
                }

                if (typeid <= 0)
                    Jscript.WriteInfo("类型id为空");

                sql += " and [Type]=" + typeid;
                ViewState["sql"] = sql;
                this.lname.Text = Global.GetTypeName(typeid);
                post.InitBindData(this.GridView1, this.AspNetPager1, tbname, key, sql, key);
            }

        }

        protected void AspNetPager1_PageChanged1(object sender, EventArgs e)
        {
            post.SecondBindData(this.GridView1, this.AspNetPager1, tbname, key, ViewState["sql"].ToString(), key);
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            md.CName = txtname.Text.Trim();
            md.Description = txtdes.Text.Trim();
            md.OrderNum = Utils.StrToInt(txtsort.Text.Trim());
            md.Type = typeid;

            if (action == "")
            {
                if (dal.Add(md) > 0)
                {
                  Response.Redirect("sNewsClass.aspx?typeid=" + typeid);
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

        protected void btncancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("sNewsClass.aspx?typeid=" + typeid);
        }
    }
}
