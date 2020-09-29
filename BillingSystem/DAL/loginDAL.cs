using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using BillingSystem.BLL;

namespace BillingSystem.DAL
{
    class loginDAL
    {
        //Static String to connect database
        static string mycnnstring = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;

        public bool loginCheck(loginBLL l)
        {
            //create a boolean variable and set its value to false and return it
            bool isSuccess = false;

            //Connecting to database
            SqlConnection conn = new SqlConnection(mycnnstring);

            try
            {
                string sql = "SELECT * FROM tbl_users WHERE username=@username AND password=@password AND user_type=@user_type";

                //Creating SQL Command to pass value
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@username", l.username);
                cmd.Parameters.AddWithValue("@password", l.password);
                cmd.Parameters.AddWithValue("@user_type", l.user_type);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                adapter.Fill(dt);

                //Checking the rows in DataTable
                if (dt.Rows.Count > 0)
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
    }
}
