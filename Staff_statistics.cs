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

namespace Database_Project
{
    public partial class Staff_statistics : Form
    {
        private int staff_id;
        public Staff_statistics(int staff_id)
        {
            InitializeComponent();
            this.staff_id = staff_id;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Staff_dashboard staff_Dashboard = new Staff_dashboard(staff_id);
            staff_Dashboard.Show();
            this.Hide();
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            String con = "Data Source=FAWAD_HUMAYUN\\SQLEXPRESS01;Initial Catalog=Project_DB; Integrated Security=True; Encrypt=false";
            string str = comboBox1.Text;

            if (str == "Food items that have been ordered")
            {
                String query = "SELECT f.name AS item_name, c.name AS category_name, COUNT(o.order_id) AS order_count FROM food_items f JOIN order_details od ON f.food_id = od.food_id JOIN Order_Food o ON od.order_id = o.order_id JOIN category c ON f.category_id = c.category_id GROUP BY f.name, c.name;";
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

            else if (str == "Customers who have not given any rating")
            {
                String query = "SELECT c.F_Name, c.L_Name, f.name AS item_name, f.price FROM Customers c JOIN Order_Food o ON c.customer_id = o.customer_id JOIN order_details od ON o.order_id = od.order_id JOIN food_items f ON od.food_id = f.food_id WHERE c.customer_id NOT IN (SELECT DISTINCT customer_id FROM review);";
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

            else if (str == "All orders Take by Me")
            {
                String query = "SELECT o.order_date, f.name AS item_name, o.total_bill, c.F_Name, c.L_Name FROM Order_Food o JOIN order_details od ON o.order_id = od.order_id JOIN food_items f ON od.food_id = f.food_id JOIN Customers c ON o.customer_id = c.customer_id AND o.staff_id = " + staff_id+"";
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

            else if (str == "Orders from customers who haven't made online payments")
            {
                String query = "SELECT c.F_Name, c.L_Name, o.order_date, o.total_bill FROM Customers c JOIN Order_Food o ON c.customer_id = o.customer_id LEFT JOIN online_payment op ON c.customer_id = op.customer_id WHERE op.customer_id IS NULL";
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

        private void Staff_statistics_Load(object sender, EventArgs e)
        {

        }
    }
}






