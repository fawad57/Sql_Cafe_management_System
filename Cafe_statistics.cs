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
    public partial class Cafe_statistics : Form
    {
        public Cafe_statistics()
        {
            InitializeComponent();
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            String con = "Data Source=FAWAD_HUMAYUN\\SQLEXPRESS01;Initial Catalog=Project_DB; Integrated Security=True; Encrypt=false";
            string str = comboBox1.Text;
             
            if (str == "Total sales amount for each category")
            {
                String query = "SELECT c.name AS category_name, SUM(od.price * od.quantity) AS total_sales FROM order_details od JOIN food_items fi ON od.food_id = fi.food_id Right JOIN category c ON fi.category_id = c.category_id GROUP BY c.name;";
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

            else if(str == "Total No of orders by each Customer")
            {
                String query = "SELECT c.F_Name, c.L_Name, COUNT(order_id) AS total_orders FROM Customers c Left JOIN Order_Food oof on c.customer_id=oof.customer_id GROUP BY c.F_Name,c.L_Name;";
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
            else if(str == "Average Loyalty points earned Each customer")
            {
                String query = "SELECT oof.customer_id,AVG(c.Loyality_Points) AS average_loyalty_points FROM Order_Food oof JOIN Customers c ON oof.customer_id = c.customer_id GROUP BY oof.customer_id;";
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
            else if (str == "Category with highest average price")
            {
                String query = "SELECT category_name FROM (SELECT top 1 c.name AS category_name, AVG(fi.price) AS avg_price FROM category c JOIN food_items fi ON c.category_id = fi.category_id WHERE c.category_id IN (SELECT fi.category_id FROM food_items fi WHERE fi.food_id IN (SELECT od.food_id FROM order_details od WHERE od.order_id IN (SELECT ofd.order_id FROM Order_Food ofd GROUP BY ofd.customer_id,ofd.order_id HAVING COUNT(ofd.order_id) > 1))) GROUP BY c.name ORDER BY avg_price DESC) AS subquery;";
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
            else if (str == "Customers who order food priced above average")
            {
                String query = "SELECT F_Name, L_Name FROM Customers WHERE customer_id IN (SELECT customer_id FROM Order_Food WHERE order_id IN (SELECT order_id FROM order_details WHERE food_id IN (SELECT food_id FROM food_items WHERE price > (SELECT AVG(price) FROM food_items))));";
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
            else if (str == "Customer who order at table with max chairs")
            {
                String query = "SELECT F_Name, L_Name FROM Customers WHERE customer_id IN (SELECT customer_id FROM Order_Food WHERE table_id IN (SELECT table_id FROM tables WHERE No_of_Chairs IN (SELECT MAX(No_of_Chairs) FROM tables)));";
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
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }
    }
}
