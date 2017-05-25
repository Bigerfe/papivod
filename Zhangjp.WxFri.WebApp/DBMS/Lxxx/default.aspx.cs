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
using Easo.DAL;
using Linda.DAL.IServer;
using Linda.DAL;
namespace Easo.Web.DBMS.Lxxx
{
    public partial class _default : AdminPage
    {

        DalTb_Easo_News dal = new DalTb_Easo_News();

        SetPager_PostBack post = new SetPager_PostBack();
        string tbname = "v_news";
        string key = "id";
        string sql = "1=1  ";

        protected int typeid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            typeid = CRequest.GetInt("typeid", 0);
            if (!IsPostBack)
            {  
                if (typeid <= 0)
                    Jscript.WriteInfo("类别类型为空.");

                this.dropmenu.DataSource = DalTb_Easo_NewClass.CreateInstance().GetWebNewClassList(typeid);
                this.dropmenu.DataBind();
                sql += " and ClassId=" + dropmenu.SelectedValue;

                ViewState["sql"] = sql;

                post.InitBindData(this.GridView1, this.AspNetPager1, tbname, key, sql, key);
            }
        }

        protected void AspNetPager1_PageChanged1(object sender, EventArgs e)
        {
            post.SecondBindData(this.GridView1, this.AspNetPager1, tbname, key, ViewState["sql"].ToString(), key);
        }

        protected void btnsear_Click(object sender, EventArgs e)
        {
            if (txtitle.Text.Trim() != "")
                sql += " and title like '%" + Utils.ChkSQL(txtitle.Text.Trim()) + "%'";

            if (dropifcomomend.SelectedValue != "-1")
                sql += " and IfRecommend=" + dropifcomomend.SelectedValue;
            if (dropiftop.SelectedValue != "-1")
                sql += " and IfTop=" + dropiftop.SelectedValue;


            if (dropmenu.SelectedValue != "")
                sql += " and ClassId=" + Utils.StrToInt(dropmenu.SelectedValue);

            ViewState["sql"] = sql;
            post.InitBindData(this.GridView1, this.AspNetPager1, tbname, key, sql, key);
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            string strid = CRequest.GetString("che");
            if (strid == "")
                Jscript.Alert("请选择数据!", this);
            else
            {
                dal.DeleteList(strid, 1);

                Jscript.AlertAndRedirect("删除成功!", this.Request.RawUrl);
            }
        }

        protected void btnsetop_Click(object sender, EventArgs e)
        {
            string strid = CRequest.GetString("che");
            if (strid == "")
                Jscript.Alert("请选择数据!", this);
            else
            {
                dal.SetValue("IfTop", "1", strid);

                Jscript.WriteInfo("设置成功!");
            }
        }

        protected void btnsetnotop_Click(object sender, EventArgs e)
        {
            string strid = CRequest.GetString("che");
            if (strid == "")
                Jscript.Alert("请选择数据!", this);
            else
            {
                dal.SetValue("IfTop", "0", strid);

                Jscript.WriteInfo("设置成功!");
            }
        }

        protected void btnsetcommend_Click(object sender, EventArgs e)
        {
            string strid = CRequest.GetString("che");
            if (strid == "")
                Jscript.Alert("请选择数据!", this);
            else
            {
                dal.SetValue("IfRecommend", "1", strid);

                Jscript.WriteInfo("设置成功!");
            }
        }

        protected void btnnocommend_Click(object sender, EventArgs e)
        {
            string strid = CRequest.GetString("che");
            if (strid == "")
                Jscript.WriteInfo("请选择数据！");
            else
            {
                dal.SetValue("IfRecommend", "0", strid);

                Jscript.WriteInfo("设置成功！");
            }
        }

        protected void btnpx_Click(object sender, EventArgs e)
        {

            foreach (GridViewRow row in GridView1.Rows)
            {
                HtmlInputText text = (HtmlInputText)row.Cells[5].FindControl("txtorder");
                HtmlInputText textid = (HtmlInputText)row.Cells[5].FindControl("txtid");
                if (text != null)
                {
                    string id = textid.Value;
                    int order = Utils.StrToInt(text.Value, 100);

                    dal.SetValue("RecommendOrderNum", order.ToString(), id);
                }
            }

            Jscript.WriteInfo("执行成功!");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Addnews.aspx?typeid=" + typeid+"&action=add");
        }

      
    }
}
