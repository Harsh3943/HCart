using HCart.Data;
using HCart.Method;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HCart
{
    public partial class SubCategory : System.Web.UI.Page
    {
        HCartEntities1 db;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCategory();
                //gridSubCategory();
                SerechCategory();
                GridBindSubCategory();
            }
        }

        public void BindCategory()
        {
            Common objc = new Common();
            DataTable dt = new DataTable();
            string str = string.Empty;
            dt = objc.GetCategories();

            ddlCategory.DataSource = dt;
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "CategoryId";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("---Select Category---", "0"));


        }

        public void SerechCategory()
        {

            Common objc = new Common();
            SqlDataReader dataReader = null;
            string str = string.Empty;

            dataReader = objc.BindCategory();

            ddlSerechCategory.DataSource = dataReader;
            ddlSerechCategory.DataTextField = "CategoryName";
            ddlSerechCategory.DataValueField = "CategoryId";
            ddlSerechCategory.DataBind();
            ddlSerechCategory.Items.Insert(0, new ListItem("---Select Category---", "0"));

        }
        public void AddSC()
        {
            int Result = 0;
            Common objc= new Common();

            Result=objc.AddSubCategory(Convert.ToInt32(ddlCategory.SelectedItem.Value),txtSCName.Text,txtDetail.Text);


        }

        public void gridSubCategory()
        {
            DataTable dt = new DataTable();
            Common objc= new Common();

            dt = objc.GridViewS();

            GridSubCategory.DataSource = dt;
            GridSubCategory.DataBind();



        }

        public void GridBindSubCategory()
        {
            db = new HCartEntities1();

            var res = (from C in db.Categories
                       orderby C.CategoryId ascending
                       where C.IsActive == true
                       select C).ToList();

            var res1 = (from SC in db.SubCategories join C in db.Categories on SC.CategoryId equals C.CategoryId select new {C.CategoryName,SC.SubCategoryName,SC.SubCategoryId}).ToList();

            GridSubCategory.DataSource = res1;
            GridSubCategory.DataBind();

        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            AddPanel.Visible = true;
            ListPanel.Visible = false;
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            AddSC();
        }

        protected void btnserch_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtserch.Text) || !string.IsNullOrEmpty(ddlSerechCategory.SelectedItem.Text))
            {

                Common objc= new Common();
                DataTable dt = new DataTable();

              dt=  objc.SerechSubcategory(txtserch.Text,Convert.ToInt32(ddlCategory.SelectedItem.Value));
                GridSubCategory.DataSource = dt;
                GridSubCategory.DataBind();


            }
            else
            {
               
               gridSubCategory();
            }
        }
    }
}