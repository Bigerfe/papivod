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
  namespace Easo.Web.DBMS.AminManager
{
    public partial class defaultl: AdminPage
    {
       
        SetPager_PostBack pager = new SetPager_PostBack();

        DalManager dal = DalManager.CreateInstance();

        string sql = DalManager.CreateInstance().tbkey+ " >0";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string utype = AdminDal.CreateInstance().GetCurAdminPartType(); 

                ViewState["sql"] = sql;
                pager.InitBindData(this.GridView1, this.AspNetPager1, dal.tbname, dal.tbkey, sql, dal.tbkey);


            }


        }

        protected void btnsear_Click(object sender, EventArgs e)
        {
            if (txtuesrid.Text.Trim() != "")
                sql += "  and sManager like '%" + txtuesrid.Text.Trim() + "%'";
         
            if (dropdongjie.SelectedValue != "")
                sql += " and cFrost='" + dropdongjie.SelectedValue + "'";

            if(txtuname.Text.Trim()!="")
                sql+=" and sManagerName like '%"+txtuname.Text.Trim() +"%'";

          

            if (dropistoppermissions.SelectedValue.Trim() != "")
                sql += " and [isTopPermissions] = '" + dropistoppermissions.SelectedValue.Trim() + "'";

            ViewState["sql"] = sql;

            pager.InitBindData(this.GridView1, this.AspNetPager1, dal.tbname, dal.tbkey, sql, dal.tbkey);

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string cmdname = dropcmd.SelectedValue;
            string idstr = CRequest.GetString("che"); 
           
            if (cmdname != "")
            {

                string curadminid = DoClass.GetAdminUserID();

                if ((idstr + ",").IndexOf(curadminid + ",") != -1)
                {
                    Jscript.WriteInfo("不能对自己的账号进行删除等操作!");
                    return;
                }

                if (cmdname == "delete")
                {
                    DalManager.CreateInstance().DeleteList(idstr);
                  
                }
                else if (cmdname == "dongjie")
                {
                    DalManager.CreateInstance().SetValue("cFrost", "1", idstr);
                }
                else if (cmdname == "nodongjie")
                {
                    DalManager.CreateInstance().SetValue("cFrost", "0", idstr);
                }

                Jscript.AlertAndRedirect("操作成功", this.Request.RawUrl);
 
            } 
           
        }

        protected void AspNetPager1_PageChanged1(object sender, EventArgs e)
        {
            pager.SecondBindData(this.GridView1, this.AspNetPager1, dal.tbname, dal.tbkey, ViewState["sql"].ToString(), dal.tbkey);

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
