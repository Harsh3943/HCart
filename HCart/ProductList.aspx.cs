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
    public partial class ProductList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindProductList();
        }

        public void BindProductList()
        {
            Common objc = new Common();
            DataTable dt = new DataTable();

            dt = objc.GridViewProduct();

            DataListProduct.DataSource = dt;
            DataListProduct.DataBind();


        }

        protected void btnserch_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtProductName.Text))
            {
                Common objc = new Common();
                DataTable dt = new DataTable();
                dt = objc.serechProduct(txtProductName.Text);

                DataListProduct.DataSource = dt;
                DataListProduct.DataBind();

            }
            else
            {
                BindProductList();
            }
        }
        private long ProductID
        {
            get
            {
                if (ViewState["ProductId"] != null)
                {
                    return (long)ViewState["ProductId"];
                }
                return 0;

            }
            set
            {
                ViewState["ProductId"] = value;
            }


        }

        protected void LinkViewProduct_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "ProductView")
            {
                // ListPanel.Visible = false;
                // ViewPanel.Visible = true;

                ProductID = Convert.ToInt32(e.CommandArgument);

                Response.Redirect("ViewProductUser.aspx?ProductId=" + ProductID + " ");



            }

        }
    }
}