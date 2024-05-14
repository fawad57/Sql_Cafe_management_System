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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Database_Project
{
    public partial class Place_order : Form
    {
        Function fn = new Function();
        String query;
        private int customer_id;
        public Place_order()
        {
            InitializeComponent();
        }
        public Place_order(int cust)
        {
            customer_id=cust;
            InitializeComponent();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            String category = comboBox1.Text;
            query = "select name from  food_items where category_id = (select category_id from category where name = '" + category + "')";
            DataSet ds = fn.getData(query);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                listBox1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            comboBox1.Items.Clear();
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
                            comboBox1.Items.Add(dr["name"].ToString());
                        }
                    }
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cnstring = "Data Source=FAWAD_HUMAYUN\\SQLEXPRESS01;Initial Catalog=Project_DB; Integrated Security=True; Encrypt=false";
            numericUpDown1.ResetText();
            textBox3.Clear();

            string str=listBox1.GetItemText(listBox1.SelectedItem);
            textBox1.Text = str;
            int price=0;
            string query = "Select price from food_items where name = @name";
           

            using (SqlConnection conn = new SqlConnection(cnstring))
            {
                conn.Open();
                using (SqlCommand cmd1 = new SqlCommand(query, conn))
                {
                    // Add parameter to the command
                    cmd1.Parameters.AddWithValue("@name", str);

                    SqlDataReader reader = cmd1.ExecuteReader();
                    if (reader.Read())
                    {
                        price = reader.GetInt32(0);
                    }
                    reader.Close();
                }
            }

            textBox2.Text=price.ToString();

        }
        public int total_price = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "0" && textBox3.Text != "")
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = textBox1.Text;
                dataGridView1.Rows[n].Cells[1].Value = textBox2.Text;
                dataGridView1.Rows[n].Cells[2].Value = numericUpDown1.Value;
                dataGridView1.Rows[n].Cells[3].Value = textBox3.Text;


                total_price = total_price + int.Parse(textBox3.Text);

                textBox4.Text = total_price.ToString();
            }
            else
            {
                MessageBox.Show("Minimum Quantity is to be 1.","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            numericUpDown1.Value = 0;

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int quantity = (int)numericUpDown1.Value;
            int price = int.Parse(textBox2.Text);

            int total = quantity * price;

            textBox3.Text= total.ToString();
        }
        int price = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            price = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
            total_price=total_price-price;

            textBox4.Text = total_price.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int c_id = 1;
            int f_id = 1;
            string cnstring = "Data Source=FAWAD_HUMAYUN\\SQLEXPRESS01;Initial Catalog=Project_DB; Integrated Security=True; Encrypt=false";

            DateTime current = DateTime.Now.Date;
            int total = int.Parse(textBox4.Text);

            query = "Insert into Cart(customer_id,total_bill,date) values (@id,@total,@date)";

            using (SqlConnection con = new SqlConnection(cnstring))
            {
                con.Open();
                using (SqlCommand cm = new SqlCommand(query, con))
                {
                    // Add parameters to the command
                    cm.Parameters.AddWithValue("@id", customer_id);
                    cm.Parameters.AddWithValue("@total",total);
                    cm.Parameters.AddWithValue("@date", current);
                    // Execute the query
                    cm.ExecuteNonQuery();
                }
            }
            int cart_id = 1;
            query = "SELECT MAX(cart_id) FROM cart";
            using(SqlConnection con = new SqlConnection(cnstring))
            {
                con.Open();
                using(SqlCommand cm = new SqlCommand(query, con))
                {
                    SqlDataReader reader = cm.ExecuteReader();
                    if (reader.Read())
                    {
                        cart_id = reader.GetInt32(0);
                    }
                    reader.Close();
                }
            }


            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if(!row.IsNewRow)
                {
                    string name = row.Cells[0].Value.ToString();
                    int quantity = Convert.ToInt32(row.Cells[2].Value.ToString());

                    query = "select food_id from food_items where name =@food";
                    using (SqlConnection conn = new SqlConnection(cnstring))
                    {
                        conn.Open();
                        using (SqlCommand cmd2 = new SqlCommand(query, conn))
                        {
                            cmd2.Parameters.AddWithValue("@food", name);
                            SqlDataReader reader = cmd2.ExecuteReader();
                            if (reader.Read())
                            {
                                f_id = reader.GetInt32(0);
                            }
                            reader.Close();
                        }
                    }

                    query = "Insert into cart_item(cart_id,food_id,quantity) values (@c_id,@f_id,@quan)";
                    using (SqlConnection con = new SqlConnection(cnstring))
                    {
                        con.Open();
                        using (SqlCommand cm = new SqlCommand(query, con))
                        {
                            // Add parameters to the command
                            cm.Parameters.AddWithValue("@c_id", cart_id);
                            cm.Parameters.AddWithValue("@f_id", f_id);
                            cm.Parameters.AddWithValue("@quan", quantity);
                            // Execute the query
                            cm.ExecuteNonQuery();
                        }
                    }

                }
            }

            MessageBox.Show("Your total bill is: " + textBox4.Text, "Total Bill", MessageBoxButtons.OK);

            Customer_Dashboard customer_Dashboard = new Customer_Dashboard(customer_id);
            customer_Dashboard.Show();
            this.Hide(); 

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Customer_Dashboard customer_Dashboard = new Customer_Dashboard(customer_id);
            customer_Dashboard.Show();
            this.Hide();
        }
    }
}
