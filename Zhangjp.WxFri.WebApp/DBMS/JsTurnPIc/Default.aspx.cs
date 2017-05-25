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
 
namespace Eakia.Web.MS.JsTurnPIc
{
    public partial class Defaultl : AdminPage
    {
        string tbname = "TurnPic";
        string datakey = "ID";
        string sql = "Channel=0 ";
        SetPager_PostBack p = new SetPager_PostBack();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string action = CRequest.GetString("action");
                if (action == "delete")
                {
                    int id = CRequest.GetInt("id",0);

                    if (id <= 0)
                        Jscript.WriteInfo("ÇëÊäÈëID");
                    else {
                        DalTurnPic.CreateInstance().Delete(id);
                        Jscript.AlertAndRedirect("É¾³ý³É¹¦.", "");
                    }

                }

                p.InitBindData(this.GridList, this.AspNetPager1, tbname, datakey, sql, datakey);
            }
        }

        protected void AspNetPager1_PageChanged1(object sender, EventArgs e)
        {
            p.SecondBindData(this.GridList, this.AspNetPager1, tbname, datakey,sql, datakey);
        }
 
    }
}
