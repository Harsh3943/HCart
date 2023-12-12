using HCart.Method;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HCart
{
    public partial class GridViewSCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack) 
            {
                GridViewSubBind();
            }
        }

        public void GridViewSubBind()
        {

            Common objc = new Common();
            DataTable dt = new DataTable();
            
            dt = objc.GridViewS();

            GridSubCategory.DataSource= dt;
            GridSubCategory.DataBind();

        }
    }
}