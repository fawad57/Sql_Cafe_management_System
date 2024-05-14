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
    public partial class Check_Feedback : Form
    {
        private int customer_id;
        public Check_Feedback(int customer_id)
        {
            InitializeComponent();
            this.customer_id = customer_id;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Feedback feedback = new Feedback(customer_id);
            feedback.Show();
            this.Hide();
        }

        private void Check_Feedback_Load(object sender, EventArgs e)
        {
            string cnstring = "Data Source=FAWAD_HUMAYUN\\SQLEXPRESS01;Initial Catalog=Project_DB; Integrated Security=True; Encrypt=false";

            DataTable dataTable = new DataTable();

            string query = "SELECT * from check_feedback";

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
    }
}
