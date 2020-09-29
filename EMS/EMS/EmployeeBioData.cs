using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Data.SqlClient;
using System.Text.RegularExpressions;


namespace EMS
{
    public partial class EmployeeBioData : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6CS3N61\SQLEXPRESS;Initial Catalog=EMS;Integrated Security=True");
        string imgLoc = "";
        public EmployeeBioData()
        {
            InitializeComponent();
            error();
        }
        private void EmployeeBioData_Load(object sender, EventArgs e)
        {
            label17.Visible = false;
        }



        private void Next_Click(object sender, EventArgs e)
        {
            EmployeeDept empdoc = new EmployeeDept();
            empdoc.Show();
            this.Hide();
        }

        

        

        private void Next_Click_1(object sender, EventArgs e)
        {
            EmployeeDept empdoc = new EmployeeDept();
            empdoc.Show();
            this.Hide();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            AddDept ad = new AddDept();
            ad.Show();
            this.Hide();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            EmployeeAttendanceAdmin ea = new EmployeeAttendanceAdmin();
            ea.Show();
            this.Hide();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            EmployeeSalary esal = new EmployeeSalary();
            esal.Show();
            this.Hide();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string barcode = textBox5.Text;
            Bitmap bitmap = new Bitmap(barcode.Length * 40, 150);

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                Font oFont = new System.Drawing.Font("IDAutomationHC39M", 12);
                PointF point = new PointF(2f, 2f);
                SolidBrush black = new SolidBrush(Color.Black);
                SolidBrush white = new SolidBrush(Color.White);
                graphics.FillRectangle(white, 0, 0, bitmap.Width, bitmap.Height);
                graphics.DrawString("*" + barcode + "*", oFont, black, point);
            }

            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Jpeg);
                pictureBox6.Image = bitmap;
                pictureBox6.Height = 73;
                pictureBox6.Width = 270;

            }

            try
            {
                string sql = "INSERT INTO LOGIN (Username, Password, Usertype) VALUES ('"+textBox5.Text+"','"+textBox6.Text+"','"+label17.Text+"')";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }


        }

        

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            string gender = string.Empty;

            if (radioButton1.Checked)
            {
                gender = "MALE";
            }

            else if (radioButton2.Checked)
            {
                gender = "FEMALE";
            }
        
            

            try
            {
                byte[] img = null;
                FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                img = br.ReadBytes((int)fs.Length);
                string sql = "Insert into Employee (Firstname,Lastname,DOB,Age,Gender,MaritalStatus,Email,EmployeeId,EmployeePassword,ContactNumber,Address,EmployeeName,BloodGroup,Image) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + dateTimePicker1.Value.ToLongDateString() + "','" + textBox3.Text + "','" + gender + "','" + comboBox1.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + comboBox3.Text + "',@img)";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add(new SqlParameter("@img", img));
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Inserted Successfully...");
                Clear();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void photoUpload_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|All Files (*.*)|*.*";
                dlg.Title = "Select Employee picture";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    imgLoc = dlg.FileName.ToString();
                    pictureBox5.ImageLocation = imgLoc;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            string firstname;
            string lastname;

            firstname = textBox1.Text;
            lastname = textBox2.Text;

            textBox9.Text = (textBox1.Text + " " + textBox2.Text);

        }

        private void textBox7_KeyUp(object sender, KeyEventArgs e)
        {
                 //empID

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan age = DateTime.Now - dateTimePicker1.Value;
            int years = DateTime.Now.Year - dateTimePicker1.Value.Year;
            if (dateTimePicker1.Value.AddYears(years) > DateTime.Now) years--;
            textBox3.Text = years.ToString();
        }

        private void Clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            comboBox1.SelectedItem = null;
            comboBox3.SelectedItem = null;
            pictureBox5.Image = null;
            dateTimePicker1.ResetText();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();        
        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] img = null;
                FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                img = br.ReadBytes((int)fs.Length);
                string sql = "UPDATE Employee SET Firstname ='"+textBox1.Text+"', Lastname ='"+textBox2.Text+"', DOB ='"+dateTimePicker1.Value.ToLongDateString()+"', Age ='"+textBox3.Text+"', Gender ='"+label16.Text+"', MaritalStatus ='"+comboBox1.Text+"', Email ='"+textBox4.Text+"', EmployeePassword ='"+textBox6.Text+"', ContactNumber ='"+textBox7.Text+"', Address ='"+textBox8.Text+"', EmployeeName ='"+textBox9.Text+"', BloodGroup ='"+comboBox3.Text+"', Image = @img Where EmployeeId='"+textBox5.Text+"'";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add(new SqlParameter("@img", img));
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Updated Successfully...");
                Clear();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }      

        private void textBox5_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void EmployeeBioData_Load_1(object sender, EventArgs e)
        {
            bunifuFlatButton6.Visible = true;
            bunifuFlatButton7.Visible = false;
            bunifuFlatButton8.Visible = false;
            label17.Visible = false;
            label19.Text = Login1.passingText;
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] img = null;
                FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                img = br.ReadBytes((int)fs.Length);
                string sql = "Delete from Employee Where EmployeeId='"+textBox5.Text+"'";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add(new SqlParameter("@img", img));
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Deleted Successfully...");
                Clear();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox7_KeyUp_1(object sender, KeyEventArgs e)
        {
            string fn, ln, mystrf, mystrl, mystrd, email, dob, add;

            fn = textBox1.Text;
            ln = textBox2.Text;
            dob = dateTimePicker1.Text.ToString();
            mystrf = fn.Substring(0, 3);
            mystrl = ln.Substring(0, 3);
            mystrd = dob.Substring(0, 2);
            email = textBox4.Text;
            add = textBox8.Text;

            textBox6.Text = mystrf + mystrl + email.Substring(1, 5); //empPassword
            textBox5.Text = mystrf + ln + dob.Substring(0, 2);
        }

        private void textBox5_KeyUp_1(object sender, KeyEventArgs e)
        {
            try
            {
                string sql = "SELECT * FROM Employee WHERE EmployeeId = '" + textBox5.Text + "'";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    textBox1.Text = reader[0].ToString();
                    textBox2.Text = reader[1].ToString();
                    dateTimePicker1.Value = Convert.ToDateTime(reader[2]);
                    textBox3.Text = reader[3].ToString();
                    label16.Text = reader[4].ToString();
                    comboBox1.Text = reader[5].ToString();
                    textBox4.Text = reader[6].ToString();
                    textBox9.Text = reader[11].ToString();
                    //textBox5.Text = reader[7].ToString();
                    comboBox3.Text = reader[12].ToString();
                    textBox8.Text = reader[10].ToString();
                    textBox7.Text = reader[9].ToString();
                    textBox6.Text = reader[8].ToString();
                    byte[] img = (byte[])(reader[13]);
                    if (img == null)
                    {
                        pictureBox5.Image = null;
                    }
                    else
                    {
                        MemoryStream ms = new MemoryStream(img);
                        pictureBox5.Image = Image.FromStream(ms);
                    }
                    if (label16.Text == "MALE")
                    {
                        radioButton1.Checked = true;
                    }
                    if (label16.Text == "FEMALE")
                    {
                        radioButton2.Checked = true;
                    }
                }
                con.Close();

                bunifuFlatButton6.Visible = false;
                bunifuFlatButton7.Visible = true;
                bunifuFlatButton8.Visible = true;
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }

            if (textBox5.Text == "")
            {
                Clear();
                bunifuFlatButton8.Visible = false;
                bunifuFlatButton7.Visible = false;
                bunifuFlatButton6.Visible = true;
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                errorProvider1.SetError(textBox1, "Please Enter FirstName");
            }
            else
            {
                errorProvider1.SetError(textBox1, "");
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (textBox2.Text == string.Empty)
            {
                errorProvider1.SetError(textBox2, "Please Enter LastName");
            }
            else
            {
                errorProvider1.SetError(textBox2, "");
            }
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {

        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (Regex.IsMatch(textBox4.Text, pattern))
            {
                errorProvider1.Clear();
            }
            else
            {
                errorProvider1.SetError(textBox4, "Please Enter Valid Email Id");
                return;
            }
        }

        private void textBox7_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
                errorProvider1.SetError(textBox7, "");
            }
            else
            {
                errorProvider1.SetError(textBox7, "Please Enter Valid Contact Number");
            }

         /*   if (textBox7.MaxLength == 10)
            {
                
            }
            else
            {
                errorProvider1.SetError(textBox7, "Please Enter Valid Contact Number");
            }*/
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void error()
        {
            errorProvider1.SetError(textBox1, "Please Enter FirstName");
            errorProvider1.SetError(textBox2, "Please Enter LastName");
            errorProvider1.SetError(textBox4, "Please Enter Valid Email Id");
            errorProvider1.SetError(textBox7, "Please Enter Valid Contact Number");
            errorProvider1.SetError(comboBox1, "Please Select Marital Status");
            errorProvider1.SetError(comboBox3, "Please Select Blood Group");
            errorProvider1.SetError(textBox8, "Please Enter Address");
        }

        private void comboBox1_Validating(object sender, CancelEventArgs e)
        {
            if (comboBox1.Text == string.Empty)
            {
                errorProvider1.SetError(comboBox1, "Please Select Marital Status");
            }
            else
            {
                errorProvider1.SetError(comboBox1, "");
            }
        }

        private void comboBox3_Validating(object sender, CancelEventArgs e)
        {
            if (comboBox3.Text == string.Empty)
            {
                errorProvider1.SetError(comboBox3, "Please Select Blood Group");
            }
            else
            {
                errorProvider1.SetError(comboBox3, "");
            }
        }

        private void textBox8_Validating(object sender, CancelEventArgs e)
        {
            if (textBox8.Text == string.Empty)
            {
                errorProvider1.SetError(textBox8, "Please Enter Address");
            }
            else
            {
                errorProvider1.SetError(textBox8, "");
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Login1 l = new Login1();
            l.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dashboard d = new Dashboard();
            d.Show();
            this.Hide();
        }
    }
    }

    