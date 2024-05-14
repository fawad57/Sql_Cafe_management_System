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
    public partial class Remove : Form
    {
        public Remove()
        {
            InitializeComponent();
        }
        private void load_Data()
        {
            string cnstring = "Data Source=FAWAD_HUMAYUN\\SQLEXPRESS01;Initial Catalog=Project_DB; Integrated Security=True; Encrypt=false";

            string query = "SELECT * from remove_item";
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
        private void Remove_Load(object sender, EventArgs e)
        {
            load_Data();
        }
        int food_id;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string f_name = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

            string cnstring = "Data Source=FAWAD_HUMAYUN\\SQLEXPRESS01;Initial Catalog=Project_DB; Integrated Security=True; Encrypt=false";

            string query = "SELECT food_id FROM food_items WHERE name = @food";

            using (SqlConnection conn = new SqlConnection(cnstring))
            {
                conn.Open();
                using (SqlCommand cmd1 = new SqlCommand(query, conn))
                {
                    // Add parameter to the command
                    cmd1.Parameters.AddWithValue("@food", f_name);

                    SqlDataReader reader = cmd1.ExecuteReader();
                    if (reader.Read())
                    {
                        food_id = reader.GetInt32(0);
                    }
                    reader.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select any row.","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                string query = " delete from food_items where food_id = " + food_id + "";
                string cnstring = "Data Source=FAWAD_HUMAYUN\\SQLEXPRESS01;Initial Catalog=Project_DB; Integrated Security=True; Encrypt=false";

                using (SqlConnection conn = new SqlConnection(cnstring))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Data is deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load_Data();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Manage_food_items manage_Food_Items = new Manage_food_items();
            manage_Food_Items.Show();
            this.Hide();
        }
    }
}
