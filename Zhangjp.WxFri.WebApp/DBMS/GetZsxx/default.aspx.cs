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
using Linda.DAL.IServer;
using Linda.DAL;
using Linda.Dal.NewsDAL;
namespace Easo.Web.DBMS.GetZsxx
{
    public partial class defaultl: AdminPage
    {

        SetPager_PostBack post = new SetPager_PostBack();
        string tbname = "v_GetZhaoi";
        string key = "id";
        string sql = "1=1  ";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              
                ViewState["sql"] = sql;

                post.InitBindData(this.GridView1, this.AspNetPager1, tbname, key, sql, key);

            }


        }

        protected void btnsear_Click(object sender, EventArgs e)
        {
            if (txtuname.Text.Trim() != "")
                sql += "  and name like '%" + txtuname.Text.Trim() + "%'";

            if (txtsj.Text.Trim() != "")
                sql += " and dianh='" + txtsj.Text.Trim() + "'"; 

            ViewState["sql"] = sql;
            post.InitBindData(this.GridView1, this.AspNetPager1, tbname, key, sql, key);
 
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string cmdname = dropcmd.SelectedValue;
            string idstr = CRequest.GetString("che"); 
           
            if (cmdname != "")
            {

                string curadminid = DoClass.GetAdminUserID();

           

                if (cmdname == "delete")
                {
                    DalGetZhaoi.CreateInstance().DeleteList(idstr);
                  
                }
           

                Jscript.AlertAndRedirect("²Ù×÷³É¹¦", this.Request.RawUrl);
 
            } 
           
        }

        protected void AspNetPager1_PageChanged1(object sender, EventArgs e)
        {
            post.SecondBindData(this.GridView1, this.AspNetPager1, tbname, key, ViewState["sql"].ToString(), key);
        }
      

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string id = this.GridView1.Rows[e.NewEditIndex].Cells[1].Text;

            Response.Redirect("change.aspx?cmd=1&id=" + id);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("add.aspx");
        }

      
 
    }
}
