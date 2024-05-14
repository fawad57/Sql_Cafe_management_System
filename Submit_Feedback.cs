using Project;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Database_Project
{
    public partial class Submit_Feedback : Form
    {
        private int customer_id;
        public Submit_Feedback()
        {
            InitializeComponent();
        }
        public Submit_Feedback(int cust)
        {
            customer_id = cust;
            InitializeComponent();
        }

        private void comboBox2_MouseClick(object sender, MouseEventArgs e)
        {
            comboBox2.Items.Clear();
            String con = "Data Source=FAWAD_HUMAYUN\\SQLEXPRESS01;Initial Catalog=Project_DB; Integrated Security=True; Encrypt=false";
            using (SqlConnection cn = new SqlConnection(con))
            {
                cn.Open();
                String query = "select * from category_view";
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            comboBox2.Items.Add(dr["name"].ToString());
                        }
                    }
                }
            }
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            comboBox1.Items.Clear();
            String con = "Data Source=FAWAD_HUMAYUN\\SQLEXPRESS01;Initial Catalog=Project_DB; Integrated Security=True; Encrypt=false";
            using (SqlConnection cn = new SqlConnection(con))
            {
                cn.Open();
                String query = "select name from food_items where category_id  =(select category_id from category where name = '"+comboBox2.Text+"')";
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            comboBox1.Items.Add(dr["name"].ToString());
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Customer_Dashboard customer_Dashboard = new Customer_Dashboard(customer_id);
            customer_Dashboard.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && comboBox2.Text != "" && numericUpDown1.Value != 0)
            {
                int c_id = 1;
                int f_id = 1;

                String f_name = comboBox1.Text;
                string c_name = comboBox2.Text;
                string cnstring = "Data Source=FAWAD_HUMAYUN\\SQLEXPRESS01;Initial Catalog=Project_DB; Integrated Security=True; Encrypt=false";
                string query = "select food_id from food_items where name =@food";
                using (SqlConnection conn = new SqlConnection(cnstring))
                {
                    conn.Open();
                    using (SqlCommand cmd2 = new SqlCommand(query, conn))
                    {
                        cmd2.Parameters.AddWithValue("@food", f_name);
                        SqlDataReader reader = cmd2.ExecuteReader();
                        if (reader.Read())
                        {
                            f_id = reader.GetInt32(0);
                        }
                        reader.Close();
                    }
                }

                int rating = (int)numericUpDown1.Value;

                DateTime dateTime = DateTime.Now.Date;

                query = "insert into review (food_id,customer_id,rating,review_date) values (@f_id,@c_id,@rate,@date)";

                using (SqlConnection conn = new SqlConnection(cnstring))
                {
                    conn.Open();
                    using (SqlCommand cmd2 = new SqlCommand(query, conn))
                    {
                        cmd2.Parameters.AddWithValue("@f_id", f_id);
                        cmd2.Parameters.AddWithValue("@c_id", customer_id);
                        cmd2.Parameters.AddWithValue("@rate", rating);
                        cmd2.Parameters.AddWithValue("@date", dateTime);

                        cmd2.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("You're feedback is submitted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Customer_Dashboard customer_Dashboard = new Customer_Dashboard(customer_id);
                customer_Dashboard.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please fill all the fields.","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
    }
}
