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
    class productsDAL
    {
        //Creating static string method for database Connection
        static string myconnectstring = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;

        #region Select Method for Product Module
        public DataTable Select()
        {
            //Create SQL Connection to Connect DataBase
            SqlConnection conn = new SqlConnection(myconnectstring);

            //DataTable to hold the data from database
            DataTable dt = new DataTable();

            try
            {
                //Writing the query to select all the products from the database
                string sql = "SELECT * FROM tbl_products";

                //Creating SQL Command to Execute Query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //SQL Data Adapter to hold the database 
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //Open Database Connection
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

        #region Method to Insert Product in database
        public bool Insert(productsBLL p)
        {
            //Creating Boolean Variable and set its default value to false
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnectstring);

            try
            {
                //SQL Query to Insert products into Database
                string sql = "INSERT INTO tbl_products(name, category, description, rate, qty, added_date, added_by)VALUES (@name, @category, @description, @rate, @qty, @added_date, @added_by)";

                //Creating SQL Command to pass the values
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Passing the value through parameters
                cmd.Parameters.AddWithValue("@name", p.name);
                cmd.Parameters.AddWithValue("@category", p.category);
                cmd.Parameters.AddWithValue("@description", p.description);
                cmd.Parameters.AddWithValue("@rate", p.rate);
                cmd.Parameters.AddWithValue("@qty", p.qty);
                cmd.Parameters.AddWithValue("@added_date", p.added_date);
                cmd.Parameters.AddWithValue("@added_by", p.added_by);

                //Opening Database Connection
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

        #region Method to Update Products in Database

        public bool Update(productsBLL p)
        {
            //Create a boolean variable and set its Initial value to false
            bool isSuccess = false;

            //Creating SQL Connection for Database
            SqlConnection conn = new SqlConnection(myconnectstring);

            try
            {
                //SQL Query to Update the data in database
                string sql = "UPDATE tbl_products SET name=@name, category=@category, description=@description, rate=@rate, added_date=@added_date, added_by=@added_by WHERE id=@id";

                //Create SQL Command to pass value to query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Passing the values using parameters and cmd
                cmd.Parameters.AddWithValue("@name", p.name);
                cmd.Parameters.AddWithValue("@category", p.category);
                cmd.Parameters.AddWithValue("@description", p.description);
                cmd.Parameters.AddWithValue("@rate", p.rate);
                cmd.Parameters.AddWithValue("@qty", p.qty);
                cmd.Parameters.AddWithValue("@added_date", p.added_date);
                cmd.Parameters.AddWithValue("@added_by", p.added_by);
                cmd.Parameters.AddWithValue("@id", p.id);

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

        #region Method to Delete Products from Database
        public bool Delete(productsBLL p)
        {
            bool isSuccess = false;

            //SQL Connection for Database Connection
            SqlConnection conn = new SqlConnection(myconnectstring);

            try
            {
                //Writing Query to Delete Product from Database
                string sql = "DELETE FROM tbl_products WHERE id=@id";

                //SQL Command to pass the value
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Passing the value using cmd
                cmd.Parameters.AddWithValue("@id", p.id);

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

        #region Search Method for product Module

        public DataTable Search(string keywords)
        {
            //SQl Connection for DataBase Connection
            SqlConnection conn = new SqlConnection(myconnectstring);

            //Creating DataTable to hold value from database
            DataTable dt = new DataTable();

            try
            {
                //SQL Query to Search the Product 
                string sql = "SELECT * FROM tbl_products WHERE id LIKE '%"+keywords+"%' OR name LIKE '%"+keywords+"%' OR category LIKE '%"+keywords+"%'";

                //SQL Command to Execute the Query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //SQl DataAdapter to hold the data from database
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

        #region Method to Search Product in Transaction Module

        public productsBLL GetProductsForTransaction(string keywords)
        {
            //Create an object of productsBLL and return it
            productsBLL p = new productsBLL();

            //Create Sql Connection
            SqlConnection conn = new SqlConnection(myconnectstring);

            //DataTable to store data
            DataTable dt = new DataTable();

            try
            {
                //Query to get the detail
                string sql = "SELECT name, rate, qty from tbl_products WHERE id LIKE '%" + keywords + "%' OR name LIKE '%" + keywords + "%'";

                //Sql DataAdapter to execute the query
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

                conn.Open();

                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    p.name = dt.Rows[0]["name"].ToString();
                    p.rate = decimal.Parse(dt.Rows[0]["rate"].ToString());
                    p.qty = decimal.Parse(dt.Rows[0]["qty"].ToString());
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

            return p;
        }

        #endregion

        #region METHOD TO GET PRODUCT ID BASED ON PRODUCT NAME
        public productsBLL GetProductIDFromName(string ProductName)
        {
            //Create object of products BLL and return it
            productsBLL p = new productsBLL();

            //SQL Connection
            SqlConnection conn = new SqlConnection(myconnectstring);

            //DataTable to hold the data
            DataTable dt = new DataTable();

            try
            {
                //SQL Query to get id based on product name
                string sql = "SELECT id FROM tbl_products WHERE name = '" + ProductName + "'";

                //Create SQL DataAdapter
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

                conn.Open();

                //Passing the value from Adapter to dataTable
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    //Pass the value from dt to productsBLL p
                    p.id = int.Parse(dt.Rows[0]["id"].ToString());
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

            return p;
        }
        #endregion

        #region METHOD TO GET CURRENT QUANTITY FROM DATABASE BASED ON PRODUCT ID

        public decimal GetProductQty(int ProductID)
        {
            //SQL Connection
            SqlConnection conn = new SqlConnection(myconnectstring);

            //Create a decimal variable and set its default value to 0
            decimal qty = 0;

            //Create DataTable to set the data from DataBase
            DataTable dt = new DataTable();

            try
            {
                //SQL Query to get Quantity from DataBase
                string sql = "SELECT qty FROM tbl_products WHERE id = " + ProductID;

                //Create a SQL Command
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Create SQL DataAdapter to execute the query
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                conn.Open();

                //Pass the value from DataAdapter to Data Table
                adapter.Fill(dt);

                //Check if DataTable has value or not
                if (dt.Rows.Count > 0)
                {
                    qty = decimal.Parse(dt.Rows[0]["qty"].ToString());
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

            return qty;
        }

        #endregion

        #region METHOD TO UPDATE QUANTITY

        public bool UpdateQuantity(int ProductID, decimal Qty)
        {
            //Create a Boolean Variable and set its value to false
            bool success = false;

            //SQL Connection
            SqlConnection conn = new SqlConnection(myconnectstring);

            try
            {
                //SQL Query to Update Quantity
                string sql = "UPDATE tbl_products SET qty=@qty WHERE id=@id";

                //Create SQL Command to pass the value into Query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Passing the value through Parameters
                cmd.Parameters.AddWithValue("@qty", Qty);
                cmd.Parameters.AddWithValue("@id", ProductID);

                conn.Open();

                //Create int Variable and check whether the query is executed successfully or not
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    success = true;
                }
                else
                {
                    success = false;
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

            return success;
        }

        #endregion

        #region METHOD TO INCREASE PRODUCT

        public bool IncreaseProduct(int ProductID, decimal IncreaseQty)
        {
            //Create a Bollean Variable and set its value to false
            bool success = false;

            //SQL Connection
            SqlConnection conn = new SqlConnection(myconnectstring);

            try
            {
                //Get the current quantity from DataBase Based on ID
                decimal currentQty = GetProductQty(ProductID);

                //Increase the Current Qty by the Qty Purchased from Dealer
                decimal newQty = currentQty + IncreaseQty;

                //Update the Product Qty 
                success = UpdateQuantity(ProductID, newQty);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return success;
        }

        #endregion

        #region METHOD TO DECREASE PRODUCT

        public bool DecreaseProduct(int ProductID, decimal Qty)
        {
            //Create a Boolean Variable and set its value to false
            bool success = false;

            //SQL Connection
            SqlConnection conn = new SqlConnection(myconnectstring);

            try
            {
                //get the Current Product Qty
                decimal currentQty = GetProductQty(ProductID);

                //Decrease Product Qty Based on Product Sales
                decimal NewQty = currentQty - Qty;

                //Update the product in DataBase
                success = UpdateQuantity(ProductID, NewQty);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return success;
        }

        #endregion

        #region DISPLAY PRODUCTS BASED ON CATEGORIES

        public DataTable DisplayProductsByCategory(string category)
        {
            //SQL Connection
            SqlConnection conn = new SqlConnection(myconnectstring);

            DataTable dt = new DataTable();

            try
            {
                //SQL Query to Display Products Based on Category
                string sql = "SELECT * FROM tbl_products WHERE category = '" + category + "'";

                //Create SQL Command to Execute the Query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Create SQL DataAdapter to hold the Data from DataBase
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
