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
    public partial class ForMVC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindCategory();
        }




        public void BindCategory()
        {

           
           
                Common objc = new Common();

                DataTable dt = new DataTable();

                dt = objc.GetCategories();


                if (dt != null)
                {

                    var lstCategory = new List<Categorylist>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Categorylist objcl = new Categorylist();

                        objcl.CategoryId = Convert.ToInt32(dt.Rows[i]["CategoryId"]);
                        objcl.CategoryName = dt.Rows[i]["CategoryName"].ToString();
                        objcl.IsActive = Convert.ToBoolean(dt.Rows[i]["IsActive"]);
                        lstCategory.Add(objcl);
                    }

                    GridCategory.DataSource = lstCategory;
                    GridCategory.DataBind();

                }
 
        }
    }
}