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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Database_Project
{
    public partial class Take_order : Form
    {
        private int staff_id;
        private int cust;
        public Take_order()
        {
            cust = 0;
            InitializeComponent();
        }
        public Take_order(int id)
        {
            staff_id = id;
            cust = 0;
            InitializeComponent();
        }

        private void Take_order_Load(object sender, EventArgs e)
        {

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
                String query = "select name from food_items where category_id  =(select category_id from category where name = '" + comboBox2.Text + "')";
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

        private void textBox1_Enter(object sender, EventArgs e)
        {
   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!=""&& textBox2.Text!="" && textBox3.Text!= "" &&comboBox1.Text!=""&& comboBox2.Text != "" &&numericUpDown1.Value!=0&& numericUpDown2.Value != 0)
            {
                string cnstring = "Data Source=FAWAD_HUMAYUN\\SQLEXPRESS01;Initial Catalog=Project_DB; Integrated Security=True; Encrypt=false";

                string f_name = comboBox1.Text;
                int quantity = (int)numericUpDown2.Value;

                int f_id = 0;
                int price = 0;

                string query = "select food_id,price from food_items where name =@food";
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
                            price = reader.GetInt32(1);
                        }
                        reader.Close();
                    }
                }

                query = "insert into order_details (food_id,price,quantity) values (" + f_id + "," + price + "," + quantity + ")";

                using (SqlConnection conn = new SqlConnection(cnstring))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                }

                int order_id = 0;

                query = "SELECT MAX(order_id) FROM order_details";
                using (SqlConnection con = new SqlConnection(cnstring))
                {
                    con.Open();
                    using (SqlCommand cm = new SqlCommand(query, con))
                    {
                        SqlDataReader reader = cm.ExecuteReader();
                        if (reader.Read())
                        {
                            order_id = reader.GetInt32(0);
                        }
                        reader.Close();
                    }
                }

                int table_id = 0;
                int num = (int)numericUpDown1.Value;
                query = "select table_id from tables where no_of_chairs =@num";
                using (SqlConnection conn = new SqlConnection(cnstring))
                {
                    conn.Open();
                    using (SqlCommand cmd2 = new SqlCommand(query, conn))
                    {
                        cmd2.Parameters.AddWithValue("@num", num);
                        SqlDataReader reader = cmd2.ExecuteReader();
                        if (reader.Read())
                        {
                            table_id = reader.GetInt32(0);
                        }
                        reader.Close();
                    }
                }

                DateTime dateTime = DateTime.Now.Date;
                int total = price * quantity;
               
                string email = textBox1.Text;
                
                query = "select customer_id from customers where email = @email";
                using (SqlConnection conn = new SqlConnection(cnstring))
                {
                    conn.Open();
                    using (SqlCommand cmd2 = new SqlCommand(query, conn))
                    {
                        cmd2.Parameters.AddWithValue("@email", email);
                        SqlDataReader reader = cmd2.ExecuteReader();
                        if (reader.Read())
                        {
                            cust = reader.GetInt32(0);
                        }
                        reader.Close();
                    }
                }

                if (cust != 0)
                {
                    query = " insert into Order_Food (order_id,staff_id,customer_id,table_id,order_date,total_bill) values (@oi,@si,@ci,@ti,@date,@tb)";
                    using (SqlConnection con = new SqlConnection(cnstring))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@oi", order_id);
                            cmd.Parameters.AddWithValue("@si", staff_id);
                            cmd.Parameters.AddWithValue("@ci", cust);
                            cmd.Parameters.AddWithValue("@ti", table_id);
                            cmd.Parameters.AddWithValue("@date", dateTime);
                            cmd.Parameters.AddWithValue("@tb", total);
                            cmd.ExecuteNonQuery();
                        }
                           
                    }
                }
                else
                {
                    string F_name = textBox2.Text;
                    string L_name = textBox3.Text;
                    string ph = "123-456-789";
                    int loyality = 0;
                    string query1 = "Insert into customers(F_name,L_name,Email,Loyality_points,phone_no) values (@f_n,@l_n,@email,@lp,@p)";
                    using (SqlConnection con = new SqlConnection(cnstring))
                    {
                        con.Open();
                        using (SqlCommand cm = new SqlCommand(query1, con))
                        {
                            // Add parameters to the command
                            cm.Parameters.AddWithValue("@f_n", F_name);
                            cm.Parameters.AddWithValue("@l_n", L_name);
                            cm.Parameters.AddWithValue("@email", email);
                            cm.Parameters.AddWithValue("@lp", 0.0);
                            cm.Parameters.AddWithValue("@p", ph);

                            cm.ExecuteNonQuery();
                        }
                    }

                    query = "Select max(customer_id) from customers";
                    using(SqlConnection con = new SqlConnection(cnstring))
                    {
                        con.Open() ;
                        using(SqlCommand cm = new SqlCommand(query, con))
                        {
                            SqlDataReader reader = cm.ExecuteReader();
                            if (reader.Read())
                            {
                                cust = reader.GetInt32(0);
                            }
                        }
                    }

                    query = " insert into Order_Food (order_id,staff_id,customer_id,table_id,order_date,total_bill) values (@oi,@si,@ci,@ti,@date,@tb)";
                    using (SqlConnection con = new SqlConnection(cnstring))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@oi", order_id);
                            cmd.Parameters.AddWithValue("@si", staff_id);
                            cmd.Parameters.AddWithValue("@ci", cust);
                            cmd.Parameters.AddWithValue("@ti", table_id);
                            cmd.Parameters.AddWithValue("@date", dateTime);
                            cmd.Parameters.AddWithValue("@tb", total);
                            cmd.ExecuteNonQuery();
                        }

                    }


                }

                MessageBox.Show("Order is successfully placed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Order_payment order_Payment = new Order_payment(cust, total, staff_id);
                order_Payment.Show();
                this.Hide();
/*
                Staff_dashboard staff_Dashboard = new Staff_dashboard(staff_id);
                staff_Dashboard.Show();
                this.Hide();*/
            }
            else
            {
                MessageBox.Show("Please fill all the fields.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Staff_dashboard staff_Dashboard = new Staff_dashboard(staff_id);
            staff_Dashboard.Show();
            this.Hide();
        }

        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            string cnstring = "Data Source=FAWAD_HUMAYUN\\SQLEXPRESS01;Initial Catalog=Project_DB; Integrated Security=True; Encrypt=false";

            string email = textBox1.Text;


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
                        cust = reader.GetInt32(0);
                    }
                    reader.Close();
                }
            }

            if (cust != 0)
            {
                query = "select F_name,l_name from customer where customer_id = @cust";
                string f_name = "";
                string l_name = "";
                using (SqlConnection conn = new SqlConnection(cnstring))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@cust", cust);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            f_name = reader.GetString(0);
                            l_name = reader.GetString(1);
                        }
                        reader.Close();
                    }
                }
                textBox2.Text = f_name;
                textBox2.Text = l_name;
            }
        }
    }
}
