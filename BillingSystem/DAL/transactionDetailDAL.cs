using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using BillingSystem.BLL;

namespace BillingSystem.DAL
{
    class transactionDetailDAL
    {
        //Create Connection String 
        static string myconnectstring = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;

        #region Insert Method for Transaction Detail

        public bool InsertTransactionDetail(transactionDetailBLL td)
        {
            //Create a boolean value and set its default value to false
            bool isSuccess = false;

            //Create SQL Connection
            SqlConnection conn = new SqlConnection(myconnectstring);

            try
            {
                //Query to Insert Transaction Details
                string sql = "INSERT INTO tbl_transaction_detail (product_id, rate, qty, total, dea_cust_id, added_date, added_by) VALUES (@product_id, @rate, @qty, @total, @dea_cust_id, @added_date, @added_by)";

                //Passing the value to the sql query
                SqlCommand cmd = new SqlCommand(sql,conn);

                //Passing the values using cmd
                cmd.Parameters.AddWithValue("@product_id" , td.product_id);
                cmd.Parameters.AddWithValue("@rate" , td.rate);
                cmd.Parameters.AddWithValue("@qty", td.qty);
                cmd.Parameters.AddWithValue("@total" , td.total);
                cmd.Parameters.AddWithValue("@dea_cust_id" , td.dea_cust_id);
                cmd.Parameters.AddWithValue("@added_date" , td.added_date);
                cmd.Parameters.AddWithValue("@added_by" , td.added_by);

                conn.Open();

                //Declare int variable and execute the query
                int rows = cmd.ExecuteNonQuery();

                if(rows > 0)
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

        #endregion
    }
}
}
