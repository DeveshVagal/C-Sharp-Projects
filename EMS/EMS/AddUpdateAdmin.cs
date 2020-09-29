using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMS
{
    public partial class AddUpdateAdmin : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6CS3N61\SQLEXPRESS;Initial Catalog=EMS;Integrated Security=True");
        

        public AddUpdateAdmin()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {

            try
            {
                string sql = "INSERT INTO LOGIN (Username, Question, Answer) VALUES ('" + bunifuMaterialTextbox5.Text + "','" + comboBox1.Text + "','" + bunifuCustomTextbox1.Text + "')";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                Clear();
                panel1.Visible = true;
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void Clear()
        {
            bunifuMaterialTextbox5.Text = "";
            comboBox1.SelectedIndex = -1;
            bunifuCustomTextbox1.Text = "";
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            if(bunifuMaterialTextbox2.Text == bunifuMaterialTextbox4.Text)
            {
                try
                {
                    string sql = "UPDATE LOGIN SET Password ='" + bunifuMaterialTextbox2.Text + "', Usertype ='" + label5.Text + "' Where Username='" + bunifuMaterialTextbox3.Text + "'";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Admin Added Successfully....");
                    Clear();
                    Login1 l = new Login1();
                    l.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    con.Close();
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Password Does not Match...");
            }
            
        }

       
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddUpdateAdmin_Load(object sender, EventArgs e)
        {
            error();
            label5.Visible = false;
        }

        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select * From LOGIN Where username='" + bunifuMaterialTextbox5.Text + "' and Question='" + comboBox1.Text + "' and Answer='" + bunifuCustomTextbox1.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                bunifuMaterialTextbox3.Text = bunifuMaterialTextbox5.Text;
                bunifuFlatButton1.Visible = false;
                panel1.Visible = true;
            }
            else
            {
                MessageBox.Show("Information Entered is Incorrect..");
            }
        }

        private void bunifuMaterialTextbox5_Validating(object sender, CancelEventArgs e)
        {
            if (bunifuMaterialTextbox5.Text == string.Empty)
            {
                errorProvider1.SetError(bunifuMaterialTextbox5, "Please Enter Username");
            }
            else
            {
                errorProvider1.SetError(bunifuMaterialTextbox5, "");
            }
        }

        private void comboBox1_Validating(object sender, CancelEventArgs e)
        {
            if (comboBox1.Text == string.Empty)
            {
                errorProvider1.SetError(comboBox1, "Please Select an Security Question");
            }
            else
            {
                errorProvider1.SetError(comboBox1, "");
            }
        }

        private void bunifuCustomTextbox1_Validating(object sender, CancelEventArgs e)
        {
            if (bunifuCustomTextbox1.Text == string.Empty)
            {
                errorProvider1.SetError(bunifuCustomTextbox1, "Please Enter the Answer");
            }
            else
            {
                errorProvider1.SetError(bunifuCustomTextbox1, "");
            }
        }

        private void bunifuMaterialTextbox3_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void bunifuMaterialTextbox2_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void bunifuMaterialTextbox4_Validating(object sender, CancelEventArgs e)
        {
            
        }

        void error()
        {
            errorProvider1.SetError(bunifuMaterialTextbox5, "Please Enter Username");
            errorProvider1.SetError(comboBox1, "Please Select an Security Question");
            errorProvider1.SetError(bunifuCustomTextbox1, "Please Enter the Answer");
        }

        
    }
}
