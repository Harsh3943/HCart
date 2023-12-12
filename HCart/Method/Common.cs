using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace HCart.Method
{
    public class Common
    {

        public int InsertCatagory(int CategoryId, string CategoryName, string Detail, string CategoryImage)
        {
            int Result = 0;
            General objg = new General();
            string str = String.Empty;
            if (CategoryId == 0)
            {
                str = "insert into Category(CategoryName,Detail,CategoryImage,IsActive) values('" + CategoryName + "','" + Detail + "','" + CategoryImage + "',1)";
            }
            else
            {
                str = "Update Category set CategoryName ='" + CategoryName + "',Detail='" + Detail + "' where CategoryId=" + CategoryId + " ";
            }
            Result = objg.GetExecuteNonQueryByCommand(str);
            return Result;

        }
        public SqlDataReader BindCategory()
        {
            General objg = new General();
            string str = String.Empty;

            str = "Select * From Category";

            SqlDataReader dataReader = null;

            dataReader = objg.GetReaderByCmd(str);
            return dataReader;



        }
        public DataTable GetCategories() 
        { 
          General objg= new General();
          string str = string.Empty;
            DataTable dt = new DataTable();

            str = "Select * From Category";

            dt=objg.GetDatasetByCommand(str);

            return dt;


        }
        
        public DataTable BindSubCategory(int CategoryId )
        {
            General objg=new General();
            DataTable dt = new DataTable();
            string str = string.Empty;

            str = "select * from SubCategory where CategoryId='" + CategoryId + "'";

            dt=objg.GetDatasetByCommand(str);

            return dt;


        }
        public int InsertSubCategory(int CategoryId,string SubCategoryName,string Detail)
        {

            int Result = 0;
            General objg = new General();
            string str=String.Empty;

            str = "insert into SubCategory(CategoryId,SubCategoryName,Detail,IsActive) values('"+CategoryId+"','"+SubCategoryName+"','"+Detail+"',1)";

            Result = objg.GetExecuteNonQueryByCommand(str);

            return Result;
        }
        public DataTable Login(String UserName,string Password)
        {
            General objg=new General();
            DataTable dt = new DataTable();
            string str=string.Empty;
            str = "Select * From Login Where UserName='"+UserName+"' and Password='"+Password+"'";

            dt=objg.GetDatasetByCommand(str);

            return dt;


        }
        public DataTable GridViewC()
        {
            General objg = new General();
            DataTable dt = new DataTable();
            string str = string.Empty;
            str = "Select * From Category Where IsActive=1 ";

            dt = objg.GetDatasetByCommand(str);

            return dt;
        }

        public DataTable GridViewS()
        {
            General objg= new General();
            DataTable dt = new DataTable();
            string str=string.Empty;
            str = "select * from SubCategory inner join Category on SubCategory.CategoryId=Category.CategoryId where SubCategory.IsActive=1";
            dt=objg.GetDatasetByCommand(str);
             return dt;

        }

        public int DeleteCategory(int CategoryId)
        {
            General objG = new General();
            int IsResult = 0;
            string str = string.Empty;
            str = "Update Category set IsActive=0 where CategoryId='" + CategoryId + "'";
            IsResult = objG.GetExecuteNonQueryByCommand(str);
            return IsResult;



        }
        public DataTable GetSelectCategory(string CategoryId)
        {
            General objG = new General();
            DataTable dt = new DataTable(); 
            string str = string.Empty;
            str = "Select * From Category where IsActive=1 and CategoryId ='" + CategoryId + "'";
            dt = objG.GetDatasetByCommand(str);
            return dt;
        }
        public DataTable SearchCategoryByName(string CategoryName)
        {
            General objg = new General();
            DataTable dt = new DataTable();

            string str = "SELECT * FROM Category WHERE CategoryName  = @CategoryName";
            objg.AddParameterWithValueToSQLCommand("@CategoryName", CategoryName);
            dt = objg.GetDatasetByCommand(str);

            return dt;
        }

        public int AddProduct(int CategoryId, int SubCategoryId , string ProductTitle , string ProductName,decimal ProductPrice , int ProductQuantity , string ShortDiscription , string LongDiscription , string ProductImage)
        {
            int result = 0;
            General objg=new General();
            string str = string.Empty;

            str = "insert into Product( [CategoryId], [SubCategoryId], [ProductTitle], [ProductName], [ProductPrice], [ProductQuantity], [ShortDiscription], [LongDiscription], [ProductImage], [IsActive]) " +
                "values('"+CategoryId+"','"+SubCategoryId+"','"+ProductTitle+"','"+ProductName+ "','"+ ProductPrice + "','"+ ProductQuantity + "','"+ ShortDiscription + "','"+ LongDiscription + "','"+ ProductImage + "',1)";
            
            result=objg.GetExecuteNonQueryByCommand(str);

            return result;

        }
        public DataTable GridViewProduct()
        {
            General objg= new General();
            DataTable dt = new DataTable();
            string str=string.Empty;

            str = "select * from Product inner join Category on Product.CategoryId=Category.CategoryId inner join SubCategory on Product.SubCategoryId=SubCategory.SubCategoryId";

            dt=objg.GetDatasetByCommand(str);
            return dt;
        }
        
        public int UserandLoginADD(string FullName,string Email,string Password)
        {
            General objg = new General();
            int Result = 0;

            string  str = string.Empty;

            str = "exec GET_LoginAndUser @FullName='"+FullName+"',@Email='"+Email+"',@Password='"+Password+"'";

            Result = objg.GetExecuteNonQueryByCommand(str);

            return Result;


        }

        public int AddSubCategory(int CategoryId , string SubCategoryName, string Detail)
        {

            General objg = new General();
            int Result = 0;
            string str = string.Empty;

            str = "insert into SubCategory( [CategoryId], [SubCategoryName], [Detail], [IsActive]) values('" + CategoryId + "','" + SubCategoryName + "','" + Detail + "',1)";

            Result=objg.GetExecuteNonQueryByCommand(str); 
            return Result;
        }

        public DataTable SerechSubcategory(string SubCategoryName,int CategoryId)
        {
            General objg= new General();
            DataTable dt = new DataTable();
            string str = string.Empty;

            str = "select * from SubCategory inner join Category on SubCategory.CategoryId=Category.CategoryId where SubCategory.SubCategoryName= '"+ SubCategoryName + "' or Category.CategoryId= '"+ CategoryId + "'";

            dt = objg.GetDatasetByCommand(str);

            return dt;



        }
        public DataTable serechProduct(string ProductName)
        {

            General objg = new General();
            DataTable dt = new DataTable();
            string str = string.Empty;

            str = "select * from Product where ProductName ="+ ProductName + "";

            dt = objg.GetDatasetByCommand(str);

            return dt;

        }
        public DataTable GetProduct(int ProductId) 
        { 
           General objg=new General();
            DataTable dt = new DataTable();
            string str = string.Empty;
            str = "select * from Product where ProductId='"+ ProductId + "'";

            dt= objg.GetDatasetByCommand(str);

            return dt;
        
        
        
        
        }
        
       public int Sum()
        {
            int A = 0;
            int B = 0;
            int C = 0;

            C=A+B;

            return C;


        }

    }
    public class Categorylist
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public bool IsActive { get; set; }
        //public string MobileNo { get; set; }
        //public string EMailId { get; set; }
        //public string Address { get; set; }

    }

    public class checkCategorylist
    {
        public List<Categorylist> Data { get; set; }
        public bool status { get; set; }
        public string message { get; set; }
        public int CategoryId { get; internal set; }
    }

    public class checkCategoryinsert
    {
        
        public bool status { get; set; }
        public string message { get; set; }
        public int CategoryId { get; internal set; }
    }


    public class SubCategorylist
    {
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        //public string MobileNo { get; set; }
        //public string EMailId { get; set; }
        //public string Address { get; set; }

    }

    public class checkSubCategorylist
    {
        public List<SubCategorylist> Data { get; set; }
        public bool status { get; set; }
        public string message { get; set; }

    }

    
}