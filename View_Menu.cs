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

namespace Database_Project
{
    public partial class View_Menu : Form
    {
        private int customer_id;
        public View_Menu()
        {
            InitializeComponent();
        }
        public View_Menu(int cust)
        {
            customer_id = cust;
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            string cnstring = "Data Source=FAWAD_HUMAYUN\\SQLEXPRESS01;Initial Catalog=Project_DB; Integrated Security=True; Encrypt=false";

            DataTable dataTable = new DataTable();

            string query = "SELECT * from menu_view";

            using (SqlConnection con = new SqlConnection(cnstring))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    var reader = cmd.ExecuteReader();
                    DataTable dataTable1 = new DataTable();
                    dataTable1.Load(reader);
                    dataGridView1.DataSource = dataTable1;
                }
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
