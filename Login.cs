using Project;
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
using System.Xml.Linq;

namespace Database_Project
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (emailbox.Text == "" || passwordbox.Text == "")
            {
                label3.Text = "Please fill all the fields";
            }
            else if (!rbtnadmin.Checked && !rbtncustomer.Checked && !rbtnshipper.Checked && !rbtnstaff.Checked)
            {
                label3.Text = "Please select your roll";
            }
            else
            {
                string cnstring = "Data Source=FAWAD_HUMAYUN\\SQLEXPRESS01;Initial Catalog=Project_DB; Integrated Security=True; Encrypt=false";
                string email = emailbox.Text;

                int cust_id = 0;
                int admin_id = 0;
                int staff_id = 0;
                int shipper_id = 0;
                if (rbtnadmin.Checked)
                {
                    string query = "select admin_id from admin where email = @email";
                    using (SqlConnection conn = new SqlConnection(cnstring))
                    {
                        conn.Open();
                        using (SqlCommand cmd2 = new SqlCommand(query, conn))
                        {
                            cmd2.Parameters.AddWithValue("@email", email);
                            SqlDataReader reader = cmd2.ExecuteReader();
                            if (reader.Read())
                            {
                                admin_id = reader.GetInt32(0);
                            }
                            reader.Close();
                        }
                    }

                    if (admin_id != 0)
                    {
                        Dashboard dashboard = new Dashboard();
                        dashboard.Show();
                        this.Hide();
                    }
                    else
                    {
                        label3.Text = "Incorrect username or password";
                    }
                }
                else if (rbtncustomer.Checked)
                {
                    string query = "select customer_id from customers where email = @email";
                    using (SqlConnection conn = new SqlConnection(cnstring))
                    {
                        conn.Open();
                        using (SqlCommand cmd2 = new SqlCommand(query, conn))
                        {
                            cmd2.Parameters.AddWithValue("@email", email);
                            SqlDataReader reader = cmd2.ExecuteReader();
                            if (reader.Read())
                            {
                                cust_id = reader.GetInt32(0);
                            }
                            reader.Close();
                        }
                    }
                    if (cust_id != 0)
                    {
                        Customer_Dashboard customer_Dashboard = new Customer_Dashboard(cust_id);
                        customer_Dashboard.Show();
                        this.Hide();
                    }
                    else
                    {
               
                        label3.Text = "Incorrect username or password";
                    }
                }
                else if (rbtnstaff.Checked)
                {
                    string query = "select staff_id from staff where email = @email";
                    using (SqlConnection conn = new SqlConnection(cnstring))
                    {
                        conn.Open();
                        using (SqlCommand cmd2 = new SqlCommand(query, conn))
                        {
                            cmd2.Parameters.AddWithValue("@email", email);
                            SqlDataReader reader = cmd2.ExecuteReader();
                            if (reader.Read())
                            {
                                staff_id = reader.GetInt32(0);
                            }
                            reader.Close();
                        }
                    }
                    if (staff_id != 0)
                    {
                        Staff_dashboard staff_Dashboard = new Staff_dashboard(staff_id);
                        staff_Dashboard.Show();
                        this.Hide();
                    }
                    else
                    {
                        
                        label3.Text = "Incorrect username or password";
                    }
                }
                else if (rbtnshipper.Checked)
                {
                    string query = "select shipper_id from shipper where email = @email";
                    using (SqlConnection conn = new SqlConnection(cnstring))
                    {
                        conn.Open();
                        using (SqlCommand cmd2 = new SqlCommand(query, conn))
                        {
                            cmd2.Parameters.AddWithValue("@email", email);
                            SqlDataReader reader = cmd2.ExecuteReader();
                            if (reader.Read())
                            {
                                shipper_id = reader.GetInt32(0);
                            }
                            reader.Close();
                        }
                    }
                    if (shipper_id != 0)
                    {
                        Shipper shipper = new Shipper(shipper_id);
                        shipper.Show();
                        this.Hide();
                    }
                    else
                    {
                        label3.Text = "Incorrect username or password";
                    }
                }
            }
 
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void linkSignup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUp sign = new SignUp();
            sign.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
