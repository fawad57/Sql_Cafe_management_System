using Project;
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
using System.Xml.Linq;

namespace Database_Project
{
    public partial class Book_table : Form
    {
        private int customer_id;
        public Book_table()
        {
            InitializeComponent();
        }
        public Book_table(int cust)
        {
            customer_id = cust;
            InitializeComponent();
        }

        private void Book_table_Load(object sender, EventArgs e)
        {
            string cnstring = "Data Source=FAWAD_HUMAYUN\\SQLEXPRESS01;Initial Catalog=Project_DB; Integrated Security=True; Encrypt=false";
            string email = "";
            string query = "select email from customers where customer_id =@id";
            using (SqlConnection conn = new SqlConnection(cnstring))
            {
                conn.Open();
                using (SqlCommand cmd2 = new SqlCommand(query, conn))
                {
                    cmd2.Parameters.AddWithValue("@id", customer_id);
                    SqlDataReader reader = cmd2.ExecuteReader();
                    if (reader.Read())
                    {
                        email = reader.GetString(0);
                    }
                    reader.Close();
                }
            }
            textBox1.Text= email;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox2.Text!=""&&textBox3.Text!=""&&textBox4.Text!=""&& numericUpDown1.Value!=0)
            {
                string date=textBox3.Text;
                string time =textBox4.Text;

                int seats = (int)numericUpDown1.Value;
                int id = 0;
                string cnstring = "Data Source=FAWAD_HUMAYUN\\SQLEXPRESS01;Initial Catalog=Project_DB; Integrated Security=True; Encrypt=false";
                string query = "select table_id from tables where no_of_chairs =@num";
                using (SqlConnection conn = new SqlConnection(cnstring))
                {
                    conn.Open();
                    using (SqlCommand cmd2 = new SqlCommand(query, conn))
                    {
                        cmd2.Parameters.AddWithValue("@num", seats);
                        SqlDataReader reader = cmd2.ExecuteReader();
                        if (reader.Read())
                        {
                            id= reader.GetInt32(0);
                        }
                        reader.Close();
                    }
                }

                query = " insert into table_booking (table_id,customer_id,time_t,date) values (@t_id,@c_id,@time,@date)";
                using(SqlConnection conn = new SqlConnection(cnstring))
                {
                    conn.Open();
                    using(SqlCommand cmd = new SqlCommand( query, conn))
                    {
                        cmd.Parameters.AddWithValue("@t_id", id);
                        cmd.Parameters.AddWithValue ("@time", time);
                        cmd.Parameters.AddWithValue("@date", date);
                        cmd.Parameters.AddWithValue("@c_id", customer_id);

                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Your table is reserve successfully");
                Customer_Dashboard customer_Dashboard = new Customer_Dashboard(customer_id);
                customer_Dashboard.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Plesae filled all fields","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Customer_Dashboard customer_Dashboard = new Customer_Dashboard(customer_id);
            customer_Dashboard.Show();
            this.Hide();
        }
    }
}
