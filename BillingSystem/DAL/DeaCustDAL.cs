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
    class DeaCustDAL
    {
        //Static string method for database Connection
        static string myconnectstring = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;

        #region SELECT Method for Dealar and Customer

        public DataTable Select()
        {
            //SQl Connection for database Connection
            SqlConnection conn = new SqlConnection(myconnectstring);

            //DataTable to hold the value from database and return it
            DataTable dt = new DataTable();

            try
            {
                //Writing SQl Query to select all the data from database
                string sql = "SELECT * FROM tbl_dea_cust";

                //Creating SQL Command to Execute the query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Creating SQL DataAdapter to store data From DataBase
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                conn.Open();

                //Passing the value from DataAdapter to Data Table
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

        #region INSERT Method to add Details of Dealer or Customer

        public bool INSERT(DeaCustBLL dc)
        {
            //Creating SQl Connection
            SqlConnection conn = new SqlConnection(myconnectstring);

            //Create Boolean Value and set its default value to false
            bool isSuccess = false;

            try
            {
                //SQl Query to INSERT Details of Dealer and Customer
                string sql = "INSERT INTO tbl_dea_cust (type, name, email, contact, address, added_date, added_by) VALUES (@type, @name, @email, @contact, @address, @added_date, @added_by)";

                //Creating SQL Command to pass the values to query and execute
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Passing the values using parametes
                cmd.Parameters.AddWithValue("@type", dc.type);
                cmd.Parameters.AddWithValue("@name", dc.name);
                cmd.Parameters.AddWithValue("@email", dc.email);
                cmd.Parameters.AddWithValue("@contact", dc.contact);
                cmd.Parameters.AddWithValue("@address", dc.address);
                cmd.Parameters.AddWithValue("@added_date", dc.added_date);
                cmd.Parameters.AddWithValue("@added_by", dc.added_by);

                conn.Open();

                //create Int Variable to check whether the query is executed or not
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

        #region UPDATE Method for Dealer and Customer Module

        public bool Update(DeaCustBLL dc)
        {
            //SQl Connection for Database Connection
            SqlConnection conn = new SqlConnection(myconnectstring);

            //Create Boolean Variable and set its default value to false
            bool isSuccess = false;

            try
            {
                //SQL Query to UPDATE data in Database
                string sql = "UPDATE tbl_dea_cust SET type=@type, name=@name, email=@email, contact=@contact, address=@address, added_date=@added_date, added_by=@added_by WHERE id=@id";

                //create SQL Command to pass the value in SQl
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Passing the value through parameters
                cmd.Parameters.AddWithValue("@type", dc.type);
                cmd.Parameters.AddWithValue("@name", dc.name);
                cmd.Parameters.AddWithValue("@email", dc.email);
                cmd.Parameters.AddWithValue("@contact", dc.contact);
                cmd.Parameters.AddWithValue("@address", dc.address);
                cmd.Parameters.AddWithValue("@added_date", dc.added_date);
                cmd.Parameters.AddWithValue("@added_by", dc.added_by);
                cmd.Parameters.AddWithValue("@id", dc.id);

                conn.Open();

                //integer Variable to check the query is executed or not
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

        #region DELETE Method for Dealer and Customer Module

        public bool Delete(DeaCustBLL dc)
        {
            //SQL Connection for database Connection
            SqlConnection conn = new SqlConnection(myconnectstring);

            //Boolean Variable set its default value to false
            bool isSuccess = false;

            try
            {
                //SQL Query to DELETE the Data from DataBase
                string sql = "DELETE FROM tbl_dea_cust WHERE id=@id";

                //SQL Command to pass the value
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Passing the value
                cmd.Parameters.AddWithValue("@id", dc.id);

                conn.Open();

                //Create Int variable to check the query is successfully or not
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
            catch(Exception ex)
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

        #region SEARCH Method for Dealer and Customer Module

        public DataTable Search(string keywords)
        {
            //Create a SQL Connection
            SqlConnection conn = new SqlConnection(myconnectstring);

            //Creating a Data Table and returning its value
            DataTable dt = new DataTable();

            try
            {
                //SQL Query to Search Dealer or Customer based on id, type, name.
                string sql = "SELECT * FROM tbl_dea_cust WHERE id LIKE '%" + keywords + "%' OR type LIKE '%" + keywords + "%' OR name LIKE '%" + keywords + "%'";

                //SQL Command to Execute the Query
                SqlCommand cmd = new SqlCommand(sql,conn);

                //SQLDataAdapter to hold the data from database
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                conn.Open();

                //Pass the value from adapter to datatable
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

        #region Method to Search DEALER OR CUSTOMER FOR TRANSACTION MODULE

        public DeaCustBLL SearchDealerCustomerForTransaction(string keywords)
        {
            //Create an object for DeaCustBLL class
            DeaCustBLL dc = new DeaCustBLL();

            //Create SQL Connection
            SqlConnection conn = new SqlConnection(myconnectstring);

            //Create a DataTable to hold the value
            DataTable dt = new DataTable();

            try
            {
                //SQl Query to Search Dealer or Customer based on Keywords
                string sql = "SELECT name, email, contact, address from tbl_dea_cust WHERE id LIKE '%" + keywords + "%' OR name LIKE '%" + keywords + "%'";

                //Create a SQL DataAdapter to execute the query
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

                conn.Open();

                //Transfer the data from sql data adapetr to sql data table
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    dc.name = dt.Rows[0]["name"].ToString();
                    dc.email = dt.Rows[0]["email"].ToString();
                    dc.contact = dt.Rows[0]["contact"].ToString();
                    dc.address = dt.Rows[0]["address"].ToString();
                }
                else
                {
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

            return dc;
        }

        #endregion

        #region METHOD TO GET ID OF DEALER AND CUSTOMER BASED ON NAME

        public DeaCustBLL GetDeaCustIDFromName(string Name)
        {
            //create an object of DeaCustBLL and return it
            DeaCustBLL dc = new DeaCustBLL();

            //SQL Connection
            SqlConnection conn = new SqlConnection(myconnectstring);

            //DataTable to hold data
            DataTable dt = new DataTable();

            try
            {
                //SQL Query to get ID Based on Name
                string sql = "SELECT id FROM tbl_dea_cust WHERE name = '" + Name + "'";

                //Create SQL DataAdapter to execute the query
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

                conn.Open();

                //Passing the value from Adapter to DataTable
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    //Pass the value from dt to DeaCustBLL dc
                    dc.id=int.Parse(dt.Rows[0]["id"].ToString());
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

            return dc;
        }

        #endregion
    }
}
