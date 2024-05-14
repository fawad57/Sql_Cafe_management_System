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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Database_Project
{
    public partial class Customer_Statistics : Form
    {
        private int customer_id;
        public Customer_Statistics(int customer_id)
        {
            InitializeComponent();
            this.customer_id = customer_id;
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            String con = "Data Source=FAWAD_HUMAYUN\\SQLEXPRESS01;Initial Catalog=Project_DB; Integrated Security=True; Encrypt=false";
            string str = comboBox1.Text;

            if (str == "Details of order food")
            {
                String query = "SELECT o.order_id, o.order_date, f.name AS item_name, c.name AS category_name, f.price, od.quantity FROM Order_Food o JOIN order_details od ON o.order_id = od.order_id JOIN food_items f ON od.food_id = f.food_id JOIN category c ON f.category_id = c.category_id WHERE o.customer_id ="+customer_id+"";
                using (SqlConnection conconn = new SqlConnection(con))
                {
                    conconn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conconn))
                    {
                        var reader = cmd.ExecuteReader();
                        DataTable dataTable1 = new DataTable();
                        dataTable1.Load(reader);
                        dataGridView1.DataSource = dataTable1;
                    }
                }
            }

            else if (str == "Names of categories for food items reviewed by Me")
            {
                String query = "SELECT DISTINCT c.name AS category_name FROM category c WHERE category_id IN(SELECT DISTINCT f.category_id FROM food_items f WHERE f.food_id IN (SELECT food_id FROM review WHERE customer_id = " + customer_id + "))";

                using (SqlConnection conconn = new SqlConnection(con))
                {
                    conconn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conconn))
                    {
                        var reader = cmd.ExecuteReader();
                        DataTable dataTable1 = new DataTable();
                        dataTable1.Load(reader);
                        dataGridView1.DataSource = dataTable1;
                    }
                }
            }

            else if (str == "Total number of items order online")
            {
                String query = "SELECT ci.quantity, f.name AS item_name, f.price, (f.price*ci.quantity) as Total FROM cart c JOIN cart_item ci ON c.cart_id = ci.cart_id JOIN food_items f ON ci.food_id = f.food_id WHERE c.customer_id =" + customer_id+"";

                using (SqlConnection conconn = new SqlConnection(con))
                {
                    conconn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conconn))
                    {
                        var reader = cmd.ExecuteReader();
                        DataTable dataTable1 = new DataTable();
                        dataTable1.Load(reader);
                        dataGridView1.DataSource = dataTable1;
                    }
                }
            }

            else if (str == "Total price of all items in a cart")
            {
                String query = "SELECT SUM(ci.quantity * f.price) AS total_price FROM cart c JOIN cart_item ci ON c.cart_id = ci.cart_id JOIN food_items f ON ci.food_id = f.food_id WHERE c.customer_id =" + customer_id + "";

                using (SqlConnection conconn = new SqlConnection(con))
                {
                    conconn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conconn))
                    {
                        var reader = cmd.ExecuteReader();
                        DataTable dataTable1 = new DataTable();
                        dataTable1.Load(reader);
                        dataGridView1.DataSource = dataTable1;
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

        private void Customer_Statistics_Load(object sender, EventArgs e)
        {

        }
    }
}
