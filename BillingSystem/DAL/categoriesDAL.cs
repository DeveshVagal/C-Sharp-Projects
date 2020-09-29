using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using BillingSystem.BLL;

namespace BillingSystem.DAL
{
    class categoriesDAL
    {
        //Static string method for Database Connection
        static string myconnectstring = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;

        #region Select Method
        public DataTable Select()
        {
            //Creating Database Connection
            SqlConnection conn = new SqlConnection(myconnectstring);

            DataTable dt = new DataTable();

            try
            {
                //Writing SQL Query to get all the data from database
                string sql = "SELECT * FROM tbl_categories";

                SqlCommand cmd = new SqlCommand(sql,conn);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                conn.Open();

                //Adding the value from adapter to data table dt
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        #endregion

        #region Insert New Categories
        public bool Insert(categoriesBLL c)
        {
            //Creating a boolean variable and set its default value to false
            bool isSuccess = false;

            //Connecting to Database
            SqlConnection conn = new SqlConnection(myconnectstring);

            try
            {
                //Writing Query to add new category
                string sql = "INSERT INTO tbl_categories (title, description, added_date, added_by) VALUES (@title, @description, @added_date, @added_by)";

                //Creating SQL Commands to pass values in our query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Passing the values through Parameters
                cmd.Parameters.AddWithValue("@title", c.title);
                cmd.Parameters.AddWithValue("@description", c.description);
                cmd.Parameters.AddWithValue("@added_date", c.added_date);
                cmd.Parameters.AddWithValue("@added_by", c.added_by);

                conn.Open();

                //Creating the int variable to execute the query
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
        #endregion

        #region Update Method
        public bool Update(categoriesBLL c)
        {

             bool isSuccess = false;

            //Creating SQL Connection
            SqlConnection conn = new SqlConnection(myconnectstring);

            try
            {
                //Query to update category
                string sql = "UPDATE tbl_categories SET title=@title, description=@description, added_date=@added_date, added_by=@added_by WHERE id=@id";

                //SQL Command to pass the value on Sql Query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Passing Value using cmd
                cmd.Parameters.AddWithValue("@title", c.title);
                cmd.Parameters.AddWithValue("@description", c.description);
                cmd.Parameters.AddWithValue("@added_date", c.added_date);
                cmd.Parameters.AddWithValue("@added_by", c.added_by);
                cmd.Parameters.AddWithValue("@id", c.id);

                conn.Open();

                //Creating int variable to execute query
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
        #endregion

        #region Delete Category Method
        public bool Delete(categoriesBLL c)
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnectstring);

            try
            {
                //SQL Query to Delete from database
                string sql = "DELETE FROM tbl_categories WHERE id=@id";

                SqlCommand cmd = new SqlCommand(sql, conn);

                //Passing the value using cmd
                cmd.Parameters.AddWithValue("@id", c.id);

                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return isSuccess;
        }
        #endregion

        #region Method for Search Functionality

        public DataTable Search(string keywords)
        {
            //SQL Connection to Database Connection
            SqlConnection conn = new SqlConnection(myconnectstring);

            //Creating DataTable to hold the data from database
            DataTable dt = new DataTable();

            try
            {
                //SQL Query to Search categories from Database
                string sql = "SELECT * FROM tbl_categories WHERE id LIKE '%" + keywords + "%' OR title LIKE '%" + keywords + "%' OR description LIKE '%" + keywords + "%'";
                //Creating SQl Command to Execute the Query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Getting data from database
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                conn.Open();
                //Passing values from adapter to Data Table dt
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        #endregion

    }
}
