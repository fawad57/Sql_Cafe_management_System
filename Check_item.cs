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
    public partial class Check_item : Form
    {
        public Check_item()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Manage_food_items manage_Food_Items = new Manage_food_items();
            manage_Food_Items.Show();
            this.Hide();
        }

        private void Check_item_Load(object sender, EventArgs e)
        {
            string cnstring = "Data Source=FAWAD_HUMAYUN\\SQLEXPRESS01;Initial Catalog=Project_DB; Integrated Security=True; Encrypt=false";

            DataTable dataTable = new DataTable();

            string query = "SELECT * from check_details";

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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
