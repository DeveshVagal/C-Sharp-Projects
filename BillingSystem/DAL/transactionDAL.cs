using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using BillingSystem.BLL;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace BillingSystem.DAL
{
    class transactionDAL
    {
        //Create a Connection String variable
        static string myconnectstring = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;

        #region INSERT Transaction Method

        public bool Insert_Transaction(transactionsBLL t, out int transactionID)
        {
            //Create a Boolean Value and set its default value to false
            bool isSuccess = false;

            //Set the out transactionID value to negative 1 i.e. -1
            transactionID = -1;
            
            //Create a sql connection
            SqlConnection conn = new SqlConnection(myconnectstring);


            try
            {
                //SQL Query to INSERT Transactions
                string sql = "INSERT INTO tbl_transactions (type, dea_cust_id, grandTotal, transaction_date, ig, cg, sg, discount, added_by) VALUES (@type, @dea_cust_id, @grandTotal, @transaction_date, @ig, @cg, @sg, @discount, @added_by); SELECT @@IDENTITY";

                //SQL Command to pass the value in sql query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Passing the value using sql query using cmd
                cmd.Parameters.AddWithValue("@type", t.type);
                cmd.Parameters.AddWithValue("@dea_cust_id", t.dea_cust_id);
                cmd.Parameters.AddWithValue("@grandTotal", t.grandTotal);
                cmd.Parameters.AddWithValue("@transaction_date", t.transaction_date);
                cmd.Parameters.AddWithValue("@ig", t.ig);
                cmd.Parameters.AddWithValue("@cg", t.cg);
                cmd.Parameters.AddWithValue("@sg", t.sg);
                cmd.Parameters.AddWithValue("@discount", t.discount);
                cmd.Parameters.AddWithValue("@added_by", t.added_by);

                conn.Open();

                //Execute the query
                object o = cmd.ExecuteScalar();

                if (o != null)
                {
                    transactionID = int.Parse(o.ToString());
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error",ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return isSuccess;
        }

        #endregion

        #region METHOD TO DISPLAY ALL THE TRANSACTION

        public DataTable DisplayAllTransactions()
        {
            //SQL Connection
            SqlConnection conn = new SqlConnection(myconnectstring);

            //Create a DataTable to hold the Data from DataBase
            DataTable dt = new DataTable();

            try
            {
                //SQL Query to Display All Transactions
                string sql = "SELECT * FROM tbl_transactions";

                //SQLCommand to Execute the query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //SQL DATAADAPTER to hold the data from DataBase
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                conn.Open();

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

        #region METHOD TO DISPLAY TRANSACTIONS BASED ON TRANSACTION TYPE

        public DataTable DisplayTransactionByType(string type)
        {
            //SQL Connection
            SqlConnection conn = new SqlConnection(myconnectstring);

            DataTable dt = new DataTable();

            try
            {
                //SQL Query
                string sql = "SELECT * FROM tbl_transactions WHERE type='" + type + "'";

                //SQL Command to execute the query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //SQl DataAdapterto hold the data from DataBase
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                conn.Open();

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
