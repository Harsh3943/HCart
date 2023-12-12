using HCart.Data;
using HCart.Method;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace HCart
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "HCartShoping" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select HCartShoping.svc or HCartShoping.svc.cs at the Solution Explorer and start debugging.
    public class HCartShoping : IHCartShoping
    {
        HCartEntities1 db;
        public void DoWork()
        {
        }

        #region API

        #region GET CategoryList
        public checkCategorylist GetCategoryList()
        {
            checkCategorylist ObjCheck = new checkCategorylist();
            try
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
                        lstCategory.Add(objcl);
                    }

                    ObjCheck.Data = lstCategory;
                    ObjCheck.status = true;
                    ObjCheck.message = "Success";
                }
                else
                {
                    ObjCheck.Data = null;
                    ObjCheck.status = false;
                    ObjCheck.message = "Failure";
                }

            }
            catch (Exception ex)
            {

                ObjCheck.Data = null;
                ObjCheck.status = false;
                ObjCheck.message = ex.Message;


            }

            return ObjCheck;
        }
        #endregion

        #region POST Category

        public checkCategoryinsert AddCategory(int CategoryId, string CategoryName, string Detail, string CategoryImage)
        {

            checkCategoryinsert objCheck = new checkCategoryinsert();
            try
            {
                int Result = 0;
                Common objc = new Common();
                Result = objc.InsertCatagory(CategoryId, CategoryName, Detail, CategoryImage);

                if (Result>0)
                {
                    objCheck.CategoryId = Result;
                    objCheck.status = true;
                    objCheck.message = "Success";
                }
                else 
                {

                    objCheck.CategoryId = CategoryId;
                    objCheck.status = false;
                    objCheck.message = "Fail";

                }
            }
            catch(Exception ex)
            {
                objCheck.CategoryId = 0;

                objCheck.status = false;
                objCheck.message = ex.Message;
            }
            return objCheck;
        }

        #endregion

        #region SubCategoryList
        public checkSubCategorylist GetSubCategoryList()
        {
            checkSubCategorylist ObjCheck = new checkSubCategorylist();
            try
            {
                Common objc = new Common();

                DataTable dt = new DataTable();

                dt = objc.GridViewS();


                if (dt != null)
                {

                    var lstCategory = new List<SubCategorylist>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        SubCategorylist objcl = new SubCategorylist();

                        objcl.SubCategoryId = Convert.ToInt32(dt.Rows[i]["SubCategoryId"]);
                        objcl.SubCategoryName = dt.Rows[i]["SubCategoryName"].ToString();
                        lstCategory.Add(objcl);
                    }

                    ObjCheck.Data = lstCategory;
                    ObjCheck.status = true;
                    ObjCheck.message = "Success";
                }
                else
                {
                    ObjCheck.Data = null;
                    ObjCheck.status = false;
                    ObjCheck.message = "Failure";
                }

            }
            catch (Exception ex)
            {

                ObjCheck.Data = null;
                ObjCheck.status = false;
                ObjCheck.message = ex.Message;


            }

            return ObjCheck;
        }
        #endregion

        #endregion

        #region Entitiy Model API

        #region GETCategory

        public checkCategorylist GetCategoryByModel()
        {

            checkCategorylist objCheck = new checkCategorylist();
            List<Categorylist> list = new List<Categorylist>();
            Categorylist objc = null;
            db = new HCartEntities1();

            try
            {

                var res = (from C in db.Categories
                           orderby C.CategoryId ascending
                           where C.IsActive == true
                           select C).ToList();




                if (res != null)
                {
                    foreach (var item in res)
                    {
                        objc = new Categorylist();
                        objc.CategoryName = item.CategoryName;
                        //objc. = item.PhoneNo;
                        //objc.EMailId = item.EmailId;

                        list.Add(objc);
                    }
                    objCheck.Data = list;
                    objCheck.status = true;
                    objCheck.message = "Success";
                }
                else
                {
                    objCheck.Data = null;
                    objCheck.status = false;
                    objCheck.message = "Failure";
                }






                //        DataTable dt = new DataTable();

                //dt = objEmp.GetEmployeeNew(EmployeeId.ToString(),Name);


                //if (dt != null)
                //{

                //    var lstmployee = new List<Employeelist>();
                //    for (int i = 0; i < dt.Rows.Count; i++)
                //    {
                //        Employeelist objE = new Employeelist();

                //        objE.EmployeeId = Convert.ToInt32(dt.Rows[i]["EmployeeId"]);
                //        objE.EmployeeName = dt.Rows[i]["Name"].ToString();
                //        objE.MobileNo= dt.Rows[i]["PhoneNo"].ToString();
                //        lstmployee.Add(objE);
                //    }

                //    ObjCheck.Data = lstmployee;
                //    ObjCheck.status = true;
                //    ObjCheck.message = "Success";
                //}
                //else
                //{
                //    ObjCheck.Data = null;
                //    ObjCheck.status = false;
                //    ObjCheck.message = "Failure";
                //}

            }
            catch (Exception ex)
            {

                objCheck.Data = null;
                objCheck.status = false;
                objCheck.message = ex.Message;


            }

            return objCheck;





        }













        #endregion

        #region GETSubCategory

        public checkSubCategorylist GetSubCategoryByModel()
        {

            checkSubCategorylist objCheck = new checkSubCategorylist();
            List<SubCategorylist> list = new List<SubCategorylist>();
            SubCategorylist objSC = null;
            db = new HCartEntities1();

            try
            {

                var res = (from SC in db.SubCategories
                           
                           where SC.IsActive == true
                           select SC).ToList();




                if (res != null)
                {
                    foreach (var item in res)
                    {
                        objSC = new SubCategorylist();
                        objSC.SubCategoryName=item.SubCategoryName;
                        //objc. = item.PhoneNo;
                        //objc.EMailId = item.EmailId;

                        list.Add(objSC);
                    }
                    objCheck.Data = list;
                    objCheck.status = true;
                    objCheck.message = "Success";
                }
                else
                {
                    objCheck.Data = null;
                    objCheck.status = false;
                    objCheck.message = "Failure";
                }
              
            }
            catch (Exception ex)
            {

                objCheck.Data = null;
                objCheck.status = false;
                objCheck.message = ex.Message;


            }


            return objCheck;






        }

        public checkSubCategorylist AddCategory()
        {
            throw new NotImplementedException();
        }

        //public checkSubCategorylist AddCategory()
        //{
        //    throw new NotImplementedException();
        //}




        #endregion


        #endregion API


    }


}
