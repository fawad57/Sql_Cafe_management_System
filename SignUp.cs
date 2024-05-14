using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_Project
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!=""&& textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "") {
                string f_name = textBox1.Text;
                string l_name = textBox6.Text;
                string email = textBox2.Text;
                string ph_no = textBox5.Text;

                string cnstring = "Data Source=FAWAD_HUMAYUN\\SQLEXPRESS01;Initial Catalog=Project_DB; Integrated Security=True; Encrypt=false";
                string query = "Insert into customers(F_name,L_name,Email,Phone_no,Loyality_points) values (@f_n,@l_n,@email,@ph,@lp)";
                using (SqlConnection con = new SqlConnection(cnstring))
                {
                    con.Open();
                    using (SqlCommand cm = new SqlCommand(query, con))
                    {
                        // Add parameters to the command
                        cm.Parameters.AddWithValue("@f_n", f_name);
                        cm.Parameters.AddWithValue("@l_n", l_name);
                        cm.Parameters.AddWithValue("@email", email);
                        cm.Parameters.AddWithValue("@ph", ph_no);
                        cm.Parameters.AddWithValue("@lp", 0.0);
                        // Execute the query
                        cm.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("You're register Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Login login = new Login();
                login.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please fill all the field.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}
